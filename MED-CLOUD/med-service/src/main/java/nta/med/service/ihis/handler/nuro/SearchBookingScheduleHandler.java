package nta.med.service.ihis.handler.nuro;

import static nta.med.core.utils.BookingUtils.createBookingDate;
import static nta.med.core.utils.BookingUtils.isIn;

import java.time.DayOfWeek;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.joda.time.DateTime;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.util.DateTimes;
import nta.med.common.util.Strings;
import nta.med.common.util.type.Pair;
import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BookingUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.nuro.BookedDetailInfo;
import nta.med.data.model.ihis.nuro.DoctorScheduleInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class SearchBookingScheduleHandler extends ScreenHandler<NuroServiceProto.SearchBookingScheduleRequest, NuroServiceProto.SearchBookingScheduleResponse> {

    private static final Log LOGGER = LogFactory.getLog(SearchBookingScheduleHandler.class);

    @Resource
    private Bas0001Repository bas0001Repository;

    @Resource
    private Res0102Repository res0102Repository;


    @Override
    @Transactional(readOnly = true)
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.SearchBookingScheduleRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if (!org.springframework.util.CollectionUtils.isEmpty(bas0001List)) {
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        } else {
            LOGGER.info("SearchBookingScheduleHandler preHandle not found hosp code");
        }
    }

    @Override
    public NuroServiceProto.SearchBookingScheduleResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.SearchBookingScheduleRequest request) throws Exception {
        NuroServiceProto.SearchBookingScheduleResponse.Builder r = NuroServiceProto.SearchBookingScheduleResponse.newBuilder();
        String departmentAvgTimeFrame = null;
        boolean isDifferentTimeFrame = res0102Repository.isDifferentTimeFrameByCondition(request.getHospCode(), request.getDepartment(), request.getStartDate(), request.getEndDate());
        List<DoctorScheduleInfo> scheduleDetails = res0102Repository.findScheduleByCondition(request.getHospCode(), request.getDepartment(), request.getStartDate(), request.getEndDate());
        List<BookedDetailInfo> bookedDetails = res0102Repository.findBookDetails(request.getHospCode(), request.getDepartment(), request.getStartDate(), request.getEndDate());
        Map<String, List<BookedDetailInfo>> mapDetails = bookedDetails.stream().collect(Collectors.groupingBy(v -> v.getDoctorCode() + v.getBookingDate()));
        if(isDifferentTimeFrame){
        	departmentAvgTimeFrame = res0102Repository.getDepartmentTimeFrameByCondition(request.getHospCode(), request.getDepartment(), getLanguage(vertx, sessionId));
        	LOGGER.info("[SEARCHBOOKINGSCHEDULE] DEPARTMENT AVG_TIME:" + departmentAvgTimeFrame);
            LOGGER.info("[SEARCHBOOKINGSCHEDULE] DEPARTMENT AVG_TIME:" + (StringUtils.isEmpty(departmentAvgTimeFrame) ? "30": departmentAvgTimeFrame));
        	r.setAvgTime(StringUtils.isEmpty(departmentAvgTimeFrame) ? "30": departmentAvgTimeFrame);
        } else {
        	if(!CollectionUtils.isEmpty(scheduleDetails)){
        		r.setAvgTime(scheduleDetails.get(0).getTimeFrame());
        	}
        }
        for (DoctorScheduleInfo doctorSchedule : scheduleDetails) {
            Map<DayOfWeek, List<Pair<String>>> frames = createTimeFrames(doctorSchedule);
            Map<DayOfWeek, List<Pair<String>>> ranges = createWorkTimeRange(doctorSchedule);
            for (String bookingDate : createBookingDate(maxDateYYYYMMDD(doctorSchedule.getStartDate(), 
            		request.getStartDate()), minDateYYYYMMDD(doctorSchedule.getEndDate(), request.getEndDate()))) {
            	Pair<String> rangeAm = ranges.get(toDow(bookingDate)).get(0);
            	Pair<String> rangePm = ranges.get(toDow(bookingDate)).get(1);
            	 NuroModelProto.BookingSchedule.Builder bookingSchedule = NuroModelProto.BookingSchedule.newBuilder()
                         .setDoctorCode(doctorSchedule.getDoctorCode())
                         .setBookingDate(bookingDate)
                         .setTotalSlots(doctorSchedule.getTotalSlots())
                         .setOtherSlots(doctorSchedule.getOtherSlots())
                         .setDoctorGrade(doctorSchedule.getDoctorGrade())
                         .setAvgTime(doctorSchedule.getTimeFrame())
                         .setResAmStartHhmm(rangeAm.getV1())
                         .setResAmEndHhmm(rangeAm.getV2())
                         .setResPmStartHhmm(rangePm.getV1())
                         .setResPmEndHhmm(rangePm.getV2());
                 
            	for (Pair<String> frame : frames.get(toDow(bookingDate))) {
                    NuroModelProto.BookingScheduleDetail.Builder scheduleDetail = NuroModelProto.BookingScheduleDetail.newBuilder();
                    int totalBookedInOther = 0 , totalBookedInSelf = 0, totalBookedOut = 0;
                    if(mapDetails.containsKey(doctorSchedule.getDepartmentCode() + doctorSchedule.getDoctorCode() + bookingDate)) {
                        for(BookedDetailInfo info : mapDetails.get(doctorSchedule.getDepartmentCode() + doctorSchedule.getDoctorCode() + bookingDate)) {
                            if(isIn(info.getBookingTime(), frame)) {
                                switch (Strings.upper(info.getBookingType())) {
                                    case "D":
                                        totalBookedInSelf++;
                                        break;
                                    case "O":
                                        totalBookedOut++;
                                        break;
                                    default:
                                        totalBookedInOther++;
                                        break;
                                }
                            }
                        }
                    }
                    scheduleDetail.setStartTime(frame.getV1());
                    scheduleDetail.setEndTime(frame.getV2());
                    scheduleDetail.setTotalBookedInOther(Strings.toString(totalBookedInOther));
                    scheduleDetail.setTotalBookedInSelf(Strings.toString(totalBookedInSelf));
                    scheduleDetail.setTotalBookedOut(Strings.toString(totalBookedOut));
                    bookingSchedule.addPeriod(scheduleDetail.build());
                }
            	r.addSchedules(bookingSchedule);
            }
        }
        r.setIsDifferentTimeFrame(isDifferentTimeFrame);
        return r.build();
    }

    private DayOfWeek toDow(String bookingDate) {
        DateTime dt = new DateTime(DateTimes.toDate("yyyyMMdd", bookingDate));
        return DayOfWeek.of(dt.getDayOfWeek());
    }

    private Map<DayOfWeek, List<Pair<String>>> createTimeFrames(DoctorScheduleInfo doctorSchedule) {
        Map<DayOfWeek, List<Pair<String>>> r = new HashMap<>();
        r.put(DayOfWeek.MONDAY, createTimeFrames(doctorSchedule.getMondayStartAm(), doctorSchedule.getMondayEndAm(), doctorSchedule.getMondayStartPm(), doctorSchedule.getMondayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.TUESDAY, createTimeFrames(doctorSchedule.getTuesdayStartAm(), doctorSchedule.getTuesdayEndAm(), doctorSchedule.getTuesdayStartPm(), doctorSchedule.getTuesdayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.WEDNESDAY, createTimeFrames(doctorSchedule.getWednesdayStartAm(), doctorSchedule.getWednesdayEndAm(), doctorSchedule.getWednesdayStartPm(), doctorSchedule.getWednesdayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.THURSDAY, createTimeFrames(doctorSchedule.getThursdayStartAm(), doctorSchedule.getThursdayEndAm(), doctorSchedule.getThursdayStartPm(), doctorSchedule.getThursdayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.FRIDAY, createTimeFrames(doctorSchedule.getFridayStartAm(), doctorSchedule.getFridayEndAm(), doctorSchedule.getFridayStartPm(), doctorSchedule.getFridayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.SATURDAY, createTimeFrames(doctorSchedule.getSaturdayStartAm(), doctorSchedule.getSaturdayEndAm(), doctorSchedule.getSaturdayStartPm(), doctorSchedule.getSaturdayEndPm(), doctorSchedule.getTimeFrame()));
        r.put(DayOfWeek.SUNDAY, createTimeFrames(doctorSchedule.getSundayStartAm(), doctorSchedule.getSundayEndAm(), doctorSchedule.getSundayStartPm(), doctorSchedule.getSundayEndPm(), doctorSchedule.getTimeFrame()));
        return r;
    }
    
    private Map<DayOfWeek, List<Pair<String>>> createWorkTimeRange(DoctorScheduleInfo doctorSchedule) {
        Map<DayOfWeek, List<Pair<String>>> r = new HashMap<>();
        r.put(DayOfWeek.MONDAY, createRangeWorking(doctorSchedule.getMondayStartAm(), doctorSchedule.getMondayEndAm(), doctorSchedule.getMondayStartPm(), doctorSchedule.getMondayEndPm()));
        r.put(DayOfWeek.TUESDAY, createRangeWorking(doctorSchedule.getTuesdayStartAm(), doctorSchedule.getTuesdayEndAm(), doctorSchedule.getTuesdayStartPm(), doctorSchedule.getTuesdayEndPm()));
        r.put(DayOfWeek.WEDNESDAY, createRangeWorking(doctorSchedule.getWednesdayStartAm(), doctorSchedule.getWednesdayEndAm(), doctorSchedule.getWednesdayStartPm(), doctorSchedule.getWednesdayEndPm()));
        r.put(DayOfWeek.THURSDAY, createRangeWorking(doctorSchedule.getThursdayStartAm(), doctorSchedule.getThursdayEndAm(), doctorSchedule.getThursdayStartPm(), doctorSchedule.getThursdayEndPm()));
        r.put(DayOfWeek.FRIDAY, createRangeWorking(doctorSchedule.getFridayStartAm(), doctorSchedule.getFridayEndAm(), doctorSchedule.getFridayStartPm(), doctorSchedule.getFridayEndPm()));
        r.put(DayOfWeek.SATURDAY, createRangeWorking(doctorSchedule.getSaturdayStartAm(), doctorSchedule.getSaturdayEndAm(), doctorSchedule.getSaturdayStartPm(), doctorSchedule.getSaturdayEndPm()));
        r.put(DayOfWeek.SUNDAY, createRangeWorking(doctorSchedule.getSundayStartAm(), doctorSchedule.getSundayEndAm(), doctorSchedule.getSundayStartPm(), doctorSchedule.getSundayEndPm()));
        return r;
    }

    public static void main(String[] args) {
    	
    }
    private List<Pair<String>> createTimeFrames(String startAm, String endAm, String startPm, String endPm, String timeFrame) {
        List<Pair<String>> r = new ArrayList<>();
       // if(Strings.isEmpty(timeFrame) || Strings.isEmpty(startAm) || Strings.isEmpty(endAm) || Strings.isEmpty(startPm) || Strings.isEmpty(endPm)) return r;
        if(timeFrame.equals("0"))
        {
            return r;
        }
        int frame = Integer.parseInt(Strings.ltrim(timeFrame, '0')); if(frame == 0) return r;
        //fixed case set startAM = empty end EndAM != empty
        if(Strings.isEmpty(startAm) && !Strings.isEmpty(endAm))
        {
            r.addAll(BookingUtils.createTimeFrames("0800", endAm, frame));
        }
        if(!Strings.isEmpty(startAm) && Strings.isEmpty(endAm))
        {
            r.addAll(BookingUtils.createTimeFrames(startAm, "1200", frame));
        }

        if(Strings.isEmpty(startPm) && !Strings.isEmpty(endPm))
        {
            r.addAll(BookingUtils.createTimeFrames("1200", endPm, frame));
        }
        if(!Strings.isEmpty(startPm) && Strings.isEmpty(endPm))
        {
            r.addAll(BookingUtils.createTimeFrames(startPm, "1800", frame));
        }

        /*if(Strings.isEmpty(startAm) && Strings.isEmpty(endAm))
        {
            r.addAll(BookingUtils.createTimeFrames("0800", "1200", frame));
        }

        if(Strings.isEmpty(startPm) && Strings.isEmpty(endPm))
        {
            r.addAll(BookingUtils.createTimeFrames("1200", "1800", frame));
        }*/


        if(!Strings.isEmpty(startAm) && !Strings.isEmpty(endAm) )
        {
            r.addAll(BookingUtils.createTimeFrames(startAm, endAm, frame));
        }
        if(!Strings.isEmpty(startPm) && !Strings.isEmpty(endPm) )
        {
            r.addAll(BookingUtils.createTimeFrames(startPm, endPm, frame));
        }

        return r;
    }

    private String minDateYYYYMMDD(String date1, String date2) {
        if(date1 == null) return date2;
        return date1.compareTo(date2) > 0 ? date2 : date1;
    }
    private String maxDateYYYYMMDD(String date1, String date2) {
        if(date1 == null) return date2;
        return date1.compareTo(date2) < 0 ? date2 : date1;
    }
    
    private List<Pair<String>> createRangeWorking(String startAm, String endAm, String startPm, String endPm) {
        List<Pair<String>> r = new ArrayList<>();
        if(Strings.isEmpty(startAm) && !Strings.isEmpty(endAm))
        {
            r.add(new Pair<>("0800", endAm));
        }
        if(!Strings.isEmpty(startAm) && Strings.isEmpty(endAm))
        {
            r.add(new Pair<>(startAm, "1200"));
        }
        if(Strings.isEmpty(startAm) && Strings.isEmpty(endAm))
        {
            r.add(new Pair<>("0800", "1200"));
        }
        if(!Strings.isEmpty(startAm) && !Strings.isEmpty(endAm) )
        {
            r.add(new Pair<>(startAm, endAm));
        }

        if(Strings.isEmpty(startPm) && !Strings.isEmpty(endPm))
        {
            r.add(new Pair<>("1200", endPm));
        }
        if(!Strings.isEmpty(startPm) && Strings.isEmpty(endPm))
        {
            r.add(new Pair<>(startPm, "1800"));
        }      
        if(Strings.isEmpty(startPm) && Strings.isEmpty(endPm))
        {
            r.add(new Pair<>("1200", "1800"));
        }
        if(!Strings.isEmpty(startPm) && !Strings.isEmpty(endPm) )
        {
            r.add(new Pair<>(startPm, endPm));
        }

        return r;
    }
}
