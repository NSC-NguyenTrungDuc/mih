//package nta.med.service.helper;
//
//import java.util.ArrayList;
//import java.util.Collections;
//import java.util.Comparator;
//import java.util.Date;
//import java.util.HashSet;
//import java.util.List;
//import java.util.Set;
//
//import org.apache.commons.collections.CollectionUtils;
//import org.apache.commons.lang.StringUtils;
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//
//import nta.med.core.infrastructure.SpringBeanFactory;
//import nta.med.core.utils.CommonUtils;
//import nta.med.core.utils.DateUtil;
//import nta.med.data.dao.medi.out.Out1001Repository;
//import nta.med.data.dao.medi.res.Res0102Repository;
//import nta.med.data.model.ihis.nuro.KCCKCountTotalOfBookingInfo;
//import nta.med.data.model.ihis.nuro.KCCKGetDoctorWorkingTimeInfo;
//import nta.med.data.model.ihis.nuro.KCCKGetEnableScheduleDoctorInfo;
//import nta.med.data.model.ihis.nuro.KCCKGetLimitScheduleDoctorInfo;
//
//public class DoctorScheduleHelper {
//	private static final Log LOG = LogFactory.getLog(DoctorScheduleHelper.class);
//	
//	private synchronized static <T> T getRepository(Class<T> clazz) {
//		return SpringBeanFactory.beanFactory.getBean(clazz);
//	}
//	
//	public static List<KCCKGetEnableScheduleDoctorInfo> getEnableSchedule(String hospCode, String doctorCode, Date startDate, Date endDate){
//		Res0102Repository res0102Repository = getRepository(Res0102Repository.class);
//		Out1001Repository out1001Repository = getRepository(Out1001Repository.class);
//		
//		Integer timeSlotAm ;
//		Integer timeSlotPm ;
//		Integer avgTime ;
//		Integer startTimeAm ;
//		Integer startTimePm ;
//		List<KCCKGetEnableScheduleDoctorInfo> enableSchedules =  new ArrayList<KCCKGetEnableScheduleDoctorInfo>();
//		if(startDate != null && endDate != null){
//			while(startDate.before(endDate) || startDate.equals(endDate)) {
//				List<KCCKGetDoctorWorkingTimeInfo> doctorWorkingTime =  res0102Repository.getKCCKGetScheduleDoctorInfo(hospCode, startDate, doctorCode);
////				get limit schedule
//				List<KCCKGetLimitScheduleDoctorInfo> limitDoctorSchedule = res0102Repository.getKCCKGetLimitScheduleDoctorInfo(hospCode, startDate, doctorCode);
////				get count total booking 
//				List<KCCKCountTotalOfBookingInfo> countBooking = out1001Repository.getKCCKCountTotalOfBookingInfo(hospCode, doctorCode, startDate, endDate);
//				if(!CollectionUtils.isEmpty(doctorWorkingTime)){
//					for (KCCKGetDoctorWorkingTimeInfo item : doctorWorkingTime) {
////					get time slot Am
//					avgTime = CommonUtils.parseInteger(item.getAvgTime());
//					timeSlotAm = DateUtil.subTimeHHmm(item.getResAmStart(), item.getResAmEnd()) != null ? (DateUtil.subTimeHHmm(item.getResAmStart(), item.getResAmEnd()) / avgTime) : 0;
//					startTimeAm = CommonUtils.parseInteger(item.getResAmStart());
////					 get time slot Pm
//					timeSlotPm = DateUtil.subTimeHHmm(item.getResPmStart(), item.getResPmEnd()) != null ? (DateUtil.subTimeHHmm(item.getResPmStart(), item.getResPmEnd())  / avgTime) : 0;
//					startTimePm = CommonUtils.parseInteger(item.getResPmStart());
////					get eanable slot AM
//					List<KCCKGetEnableScheduleDoctorInfo> listEnScheduleAm = validateEnableSlot(limitDoctorSchedule, countBooking, timeSlotAm, startTimeAm, avgTime, startDate);
////					get eanable slot PM
//					List<KCCKGetEnableScheduleDoctorInfo> listEnSchedulePm = validateEnableSlot(limitDoctorSchedule, countBooking, timeSlotPm, startTimePm, avgTime, startDate);
//					enableSchedules.addAll(listEnScheduleAm);
//					enableSchedules.addAll(listEnSchedulePm);
//					}
//				}
//				startDate = DateUtil.increaseDateByOne(startDate);
//			}
//		}
//		return enableSchedules;
//	}
//	
//
//
//	private static  List<KCCKGetEnableScheduleDoctorInfo> validateEnableSlot(List<KCCKGetLimitScheduleDoctorInfo> limitSchedule, List<KCCKCountTotalOfBookingInfo> countBooking,
//			Integer timeSlot, Integer startTime ,Integer avgTime, Date startDate){
//		Integer totalBookIn = 0; 
//		Integer totablBookOut = 0;
//		Integer totalBookOutHosp = 0;
//		Integer nextEndTimeSlot =  null;
//		Integer nextStartTimeSlot = startTime;
//		Integer jubsuTime = null; // time already book
//		String addTime = null;
//		Set<KCCKGetEnableScheduleDoctorInfo> setEnableSlot = new HashSet<KCCKGetEnableScheduleDoctorInfo>();
//		KCCKGetEnableScheduleDoctorInfo enableInfo = null;
//		if(!CollectionUtils.isEmpty(limitSchedule)){
//			for(int i = 0 ; i < timeSlot; i++ ){
//				if(!CollectionUtils.isEmpty(countBooking)){
//					for(KCCKCountTotalOfBookingInfo booking : countBooking){
//						jubsuTime = CommonUtils.parseInteger(booking.getJubsuTime());
//						nextEndTimeSlot = CommonUtils.parseInteger(DateUtil.addTimeHHmm(StringUtils.leftPad(nextStartTimeSlot.toString(), 4, "0"), StringUtils.leftPad(avgTime.toString(), 4, "0")));
//						if(nextStartTimeSlot <= jubsuTime &&  jubsuTime <= nextEndTimeSlot){
//							if("D".equals(booking.getResInputGubun())){
//								totalBookIn = totalBookIn + 1;
//							}else if("O".equals(booking.getResInputGubun())){
//								totalBookOutHosp = totalBookOutHosp + 1;
//							}else{
//								totablBookOut = totablBookOut + 1;
//							}
//							enableInfo = new KCCKGetEnableScheduleDoctorInfo(booking.getNaewonDate(), nextStartTimeSlot.toString());
//						}else {
//							enableInfo = new KCCKGetEnableScheduleDoctorInfo(booking.getNaewonDate(), nextStartTimeSlot.toString());
//							setEnableSlot.add(enableInfo);
//						}
//					}
//					if(CommonUtils.parseInteger(limitSchedule.get(0).getMaxBookingSlot()) > totalBookIn + totablBookOut + totalBookOutHosp
//							&& CommonUtils.parseInteger(limitSchedule.get(0).getMaxBookingOther()) > totablBookOut){
//						setEnableSlot.add(enableInfo);
//					}
////					reset total booking slot
//					totalBookIn = 0;
//					totablBookOut = 0;
//					totalBookOutHosp = 0;
//				}else{
//					enableInfo = new KCCKGetEnableScheduleDoctorInfo(DateUtil.toString(startDate, DateUtil.PATTERN_YYMMDD_BLANK), nextStartTimeSlot.toString());
//					setEnableSlot.add(enableInfo);
//				}
////				get next time slot
//				addTime = DateUtil.addTimeHHmm(StringUtils.leftPad(nextStartTimeSlot.toString(), 4, "0"), StringUtils.leftPad(avgTime.toString(), 4, "0"));
//				nextStartTimeSlot = CommonUtils.parseInteger(addTime);
//			}
//		}
////		sort set
//		 List<KCCKGetEnableScheduleDoctorInfo> listEnSchedule = new ArrayList<KCCKGetEnableScheduleDoctorInfo>(setEnableSlot);
//	     Collections.sort(listEnSchedule, new Comparator<KCCKGetEnableScheduleDoctorInfo>(){
//			@Override
//			public int compare(KCCKGetEnableScheduleDoctorInfo e1, KCCKGetEnableScheduleDoctorInfo e2) {
//				int firstCompare = e1.getEnableDateSlot().compareTo(e2.getEnableDateSlot());
//					if(firstCompare == 0){
//						return CommonUtils.parseInteger(e1.getEnableTimeSlot()).compareTo(CommonUtils.parseInteger(e2.getEnableTimeSlot()));
//					}
//				return firstCompare;
//			}
//	     });				
//		return listEnSchedule;
//	}
//
//}
