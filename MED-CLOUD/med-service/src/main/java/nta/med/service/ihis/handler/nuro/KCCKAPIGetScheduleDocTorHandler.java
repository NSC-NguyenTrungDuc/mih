//package nta.med.service.ihis.handler.nuro;
//
//import java.util.ArrayList;
//import java.util.Collections;
//import java.util.Date;
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.core.utils.CommonUtils;
//import nta.med.data.dao.medi.bas.Bas0270Repository;
//import nta.med.data.model.ihis.nuro.KcckApiDoctorInfo;
//import org.apache.commons.lang.StringUtils;
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.springframework.util.CollectionUtils;
//import org.vertx.java.core.Vertx;
//
//import nta.med.core.common.annotation.Route;
//import nta.med.core.domain.bas.Bas0001;
//import nta.med.core.domain.res.Res0102;
//import nta.med.core.infrastructure.SessionUserInfo;
//import nta.med.core.infrastructure.socket.handler.ScreenHandler;
//import nta.med.core.utils.BeanUtils;
//import nta.med.core.utils.DateUtil;
//import nta.med.data.dao.medi.bas.Bas0001Repository;
//import nta.med.data.dao.medi.out.Out1001Repository;
//import nta.med.data.dao.medi.res.Res0102Repository;
//import nta.med.data.model.ihis.nuro.KCCKGetDoctorWorkingTimeInfo;
//import nta.med.data.model.ihis.nuro.KCCKGetEnableScheduleDoctorInfo;
//import nta.med.data.model.ihis.nuro.KCCKScheduleDoctorStartEndDateHistory;
//import nta.med.service.helper.DoctorScheduleHelper;
//import nta.med.service.ihis.proto.NuroModelProto;
//import nta.med.service.ihis.proto.NuroServiceProto;
//import nta.med.service.ihis.proto.NuroServiceProto.KCCKAPIGetScheduleDocTorRequest;
//import nta.med.service.ihis.proto.NuroServiceProto.KCCKAPIGetScheduleDocTorResponse;
//
//@Service
//@Scope("prototype")
//public class KCCKAPIGetScheduleDocTorHandler extends ScreenHandler<NuroServiceProto.KCCKAPIGetScheduleDocTorRequest, NuroServiceProto.KCCKAPIGetScheduleDocTorResponse>{
//	private static final Log LOGGER = LogFactory.getLog(KCCKAPIGetScheduleDocTorHandler.class);
//	@Resource
//	private Res0102Repository res0102Repository;
//	@Resource
//	private Bas0001Repository bas0001Repository;
//	@Resource
//	private Out1001Repository out1001Repository;
//	@Resource
//	private Bas0270Repository bas0270Repository;
//	public boolean isAuthorized(Vertx vertx, String sessionId){
//        return true;
//    }
//
//
//    @Override
//    @Transactional(readOnly = true)
//    @Route(global = true)
//    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, KCCKAPIGetScheduleDocTorRequest request) throws Exception {
//        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
//        if(!CollectionUtils.isEmpty(bas0001List))
//        {
//            Bas0001 bas0001 = bas0001List.get(0);
//            setSessionInfo(vertx, sessionId,
//                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
//        }
//        else
//        {
//            LOGGER.info("KCCKAPIGetScheduleDocTorRequest preHandle not found hosp code");
//        }
//    }
//	
//	@Override
//	@Transactional(readOnly = true)
//	public KCCKAPIGetScheduleDocTorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
//			KCCKAPIGetScheduleDocTorRequest request) throws Exception {
//		NuroServiceProto.KCCKAPIGetScheduleDocTorResponse.Builder response = NuroServiceProto.KCCKAPIGetScheduleDocTorResponse.newBuilder();
//		if (StringUtils.isEmpty(request.getDoctorCode()) && !StringUtils.isEmpty(request.getAgvTime())) {
//			String hospCode = request.getHospCode();
//			Date startDate = DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD_BLANK);
//			Date endDate = DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD_BLANK);
//			String department = request.getDepartment();
//			List<KcckApiDoctorInfo> kcckApiDoctorInfoList = bas0270Repository.getKcckApiSearchDoctors(hospCode,
//					request.getDepartment(), request.getStartDate(), request.getEndDate(), null, null, null, null, null);
//
//			String startTimeAM = "0800";
//			String endTimeAM = "1200";
//			String startTimePM = "1200";
//			String endTimePM = "1800";
//
//			List<KCCKGetEnableScheduleDoctorInfo> enableSlotList = new ArrayList<>();
//			for (KcckApiDoctorInfo doctorInfo : kcckApiDoctorInfoList) {
//				List<KCCKGetEnableScheduleDoctorInfo> enableSlots = DoctorScheduleHelper.getEnableSchedule(hospCode, department + doctorInfo.getDoctor(), startDate, endDate);
//				enableSlotList.addAll(enableSlots);
//			}
//
//
//			NuroModelProto.KCCKGetScheduleDoctorInfo.Builder info = NuroModelProto.KCCKGetScheduleDoctorInfo.newBuilder();
//			info.setResAmStart(startTimeAM);
//			info.setResAmEnd(endTimeAM);
//			info.setResPmStart(startTimePM);
//			info.setResPmEnd(endTimePM);
//
//			List<String> timesList = new ArrayList<>();
//
//			String startTime =  startTimeAM;
//			while(CommonUtils.parseDouble(startTime) <= CommonUtils.parseInteger(endTimePM))
//			{
//				timesList.add(startTime);
//				startTime = DateUtil.addTimeHHmm(StringUtils.leftPad(startTime.toString(), 4, "0"), StringUtils.leftPad(request.getAgvTime(), 4, "0"));
//			}
//			List<KCCKGetEnableScheduleDoctorInfo> enableSlotMerger = new ArrayList<>();
////			while(startDate.before(endDate) || startDate.equals(endDate)) {
////				for(String time : timesList)
////				{
////					for(KCCKGetEnableScheduleDoctorInfo doctorInfo : enableSlotList)
////					{
////						if(doctorInfo.getEnableDateSlot().equals(DateUtil.toString(startDate, DateUtil.PATTERN_YYMMDD)))
////						{
////							if(CommonUtils.parseInteger(doctorInfo.getEnableTimeSlot()) <= CommonUtils.parseInteger(time)  &&
////									CommonUtils.parseInteger(time) < CommonUtils.parseInteger(doctorInfo.getEnableEndTimeSlot()))
////							{
////								KCCKGetEnableScheduleDoctorInfo kcckGetEnableScheduleDoctorInfo = new KCCKGetEnableScheduleDoctorInfo( DateUtil.toString(startDate, DateUtil.PATTERN_YYMMDD), time);
////								enableSlotMerger.add(kcckGetEnableScheduleDoctorInfo);
////								break;
////							}
////						}
////					}
////				}
////				startDate = DateUtil.increaseDateByOne(startDate);
////			}
//
//			NuroModelProto.KCCKGetScheduleDoctorInfo.Builder kCCKGetScheduleDoctorInfo = NuroModelProto.KCCKGetScheduleDoctorInfo.newBuilder();
//			kCCKGetScheduleDoctorInfo.setResAmStart(startTimeAM);
//			kCCKGetScheduleDoctorInfo.setResAmEnd(endTimeAM);
//			kCCKGetScheduleDoctorInfo.setResPmStart(startTimePM);
//			kCCKGetScheduleDoctorInfo.setResPmEnd(endTimePM);
//
//
//			for(KCCKGetEnableScheduleDoctorInfo enable : enableSlotMerger){
//				NuroModelProto.KCCKGetEnableScheduleDoctorInfo.Builder enableSlot = NuroModelProto.KCCKGetEnableScheduleDoctorInfo.newBuilder();
//				if(!StringUtils.isEmpty(enable.getEnableDateSlot())){
//					enableSlot.setEnableDateSlot(enable.getEnableDateSlot());
//				}
//				enableSlot.setEnableTimeSlot(StringUtils.leftPad(enable.getEnableTimeSlot(), 4, "0"));
//				kCCKGetScheduleDoctorInfo.addEnableSlot(enableSlot);
//			}
//
//
//			response.addContent(kCCKGetScheduleDoctorInfo);
//		}
//		else
//		{
//			String doctorCode = request.getDepartment() + request.getDoctorCode();
//			String hospCode = request.getHospCode();
//			Date startDate = DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD_BLANK);
//			Date endDate = DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD_BLANK);
//			Integer nextDoctorHistory = 0;
//			List<KCCKScheduleDoctorStartEndDateHistory> startEndDateHistorys = res0102Repository.getKCCKScheduleDoctorStartEndTime(hospCode, doctorCode, startDate, endDate);
//			if(!CollectionUtils.isEmpty(startEndDateHistorys)){
//				for(KCCKScheduleDoctorStartEndDateHistory startEndDateHistory : startEndDateHistorys){
//					List<Res0102> res0102s = res0102Repository.getRes0102(hospCode, doctorCode, startEndDateHistory.getStartDate());
//					KCCKGetDoctorWorkingTimeInfo doctorWorkingTime = null;
//					if(!CollectionUtils.isEmpty(res0102s)){
//						doctorWorkingTime = getMinMaxStartEndTime(res0102s.get(0));
//					}
////					if doctor have more than one setting shedule
//					if(startEndDateHistorys.size() > 1){
//						if(nextDoctorHistory == 0){
//							endDate = startEndDateHistory.getEndDate();
//						}else{
//							startDate = startEndDateHistory.getStartDate();
//							endDate = DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD_BLANK);
//						}
//						
//					}
//						if(doctorWorkingTime != null){
//							NuroModelProto.KCCKGetScheduleDoctorInfo.Builder info = NuroModelProto.KCCKGetScheduleDoctorInfo.newBuilder();
//							BeanUtils.copyProperties(doctorWorkingTime, info, getLanguage(vertx, sessionId));
//							List<KCCKGetEnableScheduleDoctorInfo> enableSlots = DoctorScheduleHelper.getEnableSchedule(hospCode, doctorCode, startDate, endDate);
//							for(KCCKGetEnableScheduleDoctorInfo enable : enableSlots){
//								NuroModelProto.KCCKGetEnableScheduleDoctorInfo.Builder enableSlot = NuroModelProto.KCCKGetEnableScheduleDoctorInfo.newBuilder();
//								if(!StringUtils.isEmpty(enable.getEnableDateSlot())){
//									enableSlot.setEnableDateSlot(enable.getEnableDateSlot());
//								}
//								enableSlot.setEnableTimeSlot(StringUtils.leftPad(enable.getEnableTimeSlot(), 4, "0"));
//								info.addEnableSlot(enableSlot);
//							}
//						response.addContent(info);
//					}
//					nextDoctorHistory = nextDoctorHistory + 1;
//				}
//			}
////			List<Res0102> res0102s = res0102Repository.getRes0102(hospCode, doctorCode);
////			KCCKGetDoctorWorkingTimeInfo doctorWorkingTime = null;
////			if(!CollectionUtils.isEmpty(res0102s)){
////				doctorWorkingTime = getMinMaxStartEndTime(res0102s.get(0));
////			}
//////		List<KCCKGetDoctorWorkingTimeInfo> doctorWorkingTime =  res0102Repository.getKCCKGetScheduleDoctorInfo(request.getHospCode(), startDate, doctorCode);
////			if(doctorWorkingTime != null){
////				NuroModelProto.KCCKGetScheduleDoctorInfo.Builder info = NuroModelProto.KCCKGetScheduleDoctorInfo.newBuilder();
////				BeanUtils.copyProperties(doctorWorkingTime, info, getLanguage(vertx, sessionId));
////				List<KCCKGetEnableScheduleDoctorInfo> enableSlots = DoctorScheduleHelper.getEnableSchedule(hospCode, doctorCode, startDate, endDate);
////				for(KCCKGetEnableScheduleDoctorInfo enable : enableSlots){
////					NuroModelProto.KCCKGetEnableScheduleDoctorInfo.Builder enableSlot = NuroModelProto.KCCKGetEnableScheduleDoctorInfo.newBuilder();
////					if(!StringUtils.isEmpty(enable.getEnableDateSlot())){
////						enableSlot.setEnableDateSlot(enable.getEnableDateSlot());
////					}
////					enableSlot.setEnableTimeSlot(StringUtils.leftPad(enable.getEnableTimeSlot(), 4, "0"));
////					info.addEnableSlot(enableSlot);
////				}
////				response.addContent(info);
////			}
//		}
//
//		return response.build();
//	}
//
//	private KCCKGetDoctorWorkingTimeInfo getMinMaxStartEndTime(Res0102 res0102){
//		if(res0102 != null){
//			List<String> startAm = new ArrayList<String>();
//			List<String> endAm = new ArrayList<String>();
//			List<String> startPm = new ArrayList<String>();
//			List<String> endPm =  new ArrayList<String>();
////			am start
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm1())) startAm.add(res0102.getResAmStartHhmm1());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm2())) startAm.add(res0102.getResAmStartHhmm2());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm3())) startAm.add(res0102.getResAmStartHhmm3());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm4())) startAm.add(res0102.getResAmStartHhmm4());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm5())) startAm.add(res0102.getResAmStartHhmm5());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm6())) startAm.add(res0102.getResAmStartHhmm6());
//			if(!StringUtils.isEmpty(res0102.getResAmStartHhmm7())) startAm.add(res0102.getResAmStartHhmm7());
////			am end
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm1())) endAm.add(res0102.getResAmEndHhmm1());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm2())) endAm.add(res0102.getResAmEndHhmm2());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm3())) endAm.add(res0102.getResAmEndHhmm3());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm4())) endAm.add(res0102.getResAmEndHhmm4());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm5())) endAm.add(res0102.getResAmEndHhmm5());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm6())) endAm.add(res0102.getResAmEndHhmm6());
//			if(!StringUtils.isEmpty(res0102.getResAmEndHhmm7())) endAm.add(res0102.getResAmEndHhmm7());
////			pm start
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm1())) startPm.add(res0102.getResPmStartHhmm1());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm2())) startPm.add(res0102.getResPmStartHhmm2());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm3())) startPm.add(res0102.getResPmStartHhmm3());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm4())) startPm.add(res0102.getResPmStartHhmm4());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm5())) startPm.add(res0102.getResPmStartHhmm5());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm6())) startPm.add(res0102.getResPmStartHhmm6());
//			if(!StringUtils.isEmpty(res0102.getResPmStartHhmm7())) startPm.add(res0102.getResPmStartHhmm7());
////			pm end
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm1())) endPm.add(res0102.getResPmEndHhmm1());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm2())) endPm.add(res0102.getResPmEndHhmm2());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm3())) endPm.add(res0102.getResPmEndHhmm3());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm4())) endPm.add(res0102.getResPmEndHhmm4());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm5())) endPm.add(res0102.getResPmEndHhmm5());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm6())) endPm.add(res0102.getResPmEndHhmm6());
//			if(!StringUtils.isEmpty(res0102.getResPmEndHhmm7())) endPm.add(res0102.getResPmEndHhmm7());
//
////			sort
//			Collections.sort(startAm);
//			Collections.sort(endAm);
//			Collections.sort(startPm);
//			Collections.sort(endPm);
//			KCCKGetDoctorWorkingTimeInfo startEndTime = new KCCKGetDoctorWorkingTimeInfo(!CollectionUtils.isEmpty(startAm) ? startAm.get(0) : "",
//					!CollectionUtils.isEmpty(endAm) ? endAm.get(endAm.size() - 1) : "",
//					!CollectionUtils.isEmpty(startPm) ? startPm.get(0) : "",
//					!CollectionUtils.isEmpty(endPm) ? endPm.get(endPm.size() - 1) : "",
//					String.format("%.0f",res0102.getAvgTime()));
//			return startEndTime;
//		}
//		return null;
//	}
//}
