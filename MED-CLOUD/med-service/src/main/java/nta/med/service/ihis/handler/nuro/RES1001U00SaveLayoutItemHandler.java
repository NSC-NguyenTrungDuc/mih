package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out0123;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.Booking;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.model.mss.BookingExamInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroModelProto.RES1001U00SaveLayoutItemInfo;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class RES1001U00SaveLayoutItemHandler extends ScreenHandler<NuroServiceProto.RES1001U00SaveLayoutItemRequest, NuroServiceProto.RES1001U00SaveLayoutItemResponse>{                     
	
	private static final Log LOGGER = LogFactory.getLog(RES1001U00SaveLayoutItemHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource
	private Out0123Repository out0123Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	 
	@Override
	public boolean isValid(NuroServiceProto.RES1001U00SaveLayoutItemRequest request, Vertx vertx, String clientId, String sessionId) {
		for(RES1001U00SaveLayoutItemInfo info : request.getLayoutItemList()){
			if (!StringUtils.isEmpty(info.getJinryoPreDate()) && DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
				return false;
			}
		}
		
		return true;
	}

	@Override
	public NuroServiceProto.RES1001U00SaveLayoutItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00SaveLayoutItemRequest request) throws Exception {
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder response = NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();   
		String hospCode = getHospitalCode(vertx, sessionId);
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		
  	   	Integer result = null;
  	  	String errCode = null;
		String tGubun = null;
		String doctorName = null;
		String tChk = null;
		String tJubsuNo = null;
		String pkOut1001 = null;
		Booking booking = null;
		String bunho = "";
		String patientName = "";
		String patientNameFurigana = "";
		String phoneNumber = "";
		String email = "";
		String birth = "";
		String sex = "";
		String patientPwd = "";
		List<BookingExamInfo> listData = new ArrayList<>();
		for(RES1001U00SaveLayoutItemInfo info : request.getLayoutItemList()){
			LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00CheckingReservation: hospCode=" + hospCode 
					+ ", doctor=" + info.getDoctor() + ", reservationDate=" + info.getJinryoPreDate() 
					+ ", reservationTime=" + info.getJinryoPreTime() + ", inputGubun=" + info.getInputGubun() + ", bunho=" + info.getBunho());
			//get t_gubun
			 List<String> listObjectTGubun = out1001Repository.getNuroRES1001U00TypeRequest(hospCode, sessionHospCode, info.getBunho(), info.getGwa(), isOtherClinic);
			 if (!CollectionUtils.isEmpty(listObjectTGubun)) {
				 tGubun = listObjectTGubun.get(0);
			 }else{
//				 tGubun = "G1" ;
				 tGubun = "Z0" ;
			 }
			 //save
			 if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				//do not process this case
			} else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {

				// check doctor
				List<String> listObjectDoctorName = out1001Repository.getDoctorName(hospCode, sessionHospCode,
						info.getBunho(), info.getGwa(), info.getJinryoPreDate(), info.getJinryoPreTime(),
						isOtherClinic);
				if (!CollectionUtils.isEmpty(listObjectDoctorName)) {
					errCode = "1";
					doctorName = listObjectDoctorName.get(0);
					response.setErrCode(errCode);
					if (!StringUtils.isEmpty(doctorName)) {
						response.setDoctorName(doctorName);
					}
					response.setResult(false);
					LOGGER.info("RES1001U00SaveLayoutItemHandler : getDoctorName: errCode=" + errCode); 
					throw new ExecutionException(response.build());
				}
				// check t_chk
				tChk = res0103Repository.getNuroRES1001U00CheckingReservation(hospCode, sessionHospCode,
						info.getDoctor(), info.getJinryoPreDate(), info.getJinryoPreTime(), info.getInputGubun(),
						isOtherClinic);
				if (!StringUtils.isEmpty(tChk)) {
					if ("1".equals(tChk)) {
						errCode = "2";
						response.setErrCode(errCode);
						response.setResult(false);
						LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00CheckingReservation: errCode=" + errCode); 
						throw new ExecutionException(response.build());
					} else if ("2".equals(tChk)) {
						errCode = "3";
						response.setErrCode(errCode);
						response.setResult(false);
						LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00CheckingReservation: errCode=" + errCode);
						throw new ExecutionException(response.build());
					}
				}
				// check t_jubsu_no
				List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(hospCode,
						sessionHospCode, info.getBunho(), info.getJinryoPreDate(), isOtherClinic);
				if (CollectionUtils.isEmpty(listTJubsuNo)) {
					errCode = "4";
					response.setErrCode(errCode);
					response.setResult(false);
					LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00ReceptionNumber: errCode=" + errCode); 
					throw new ExecutionException(response.build());
				} else {
					tJubsuNo = listTJubsuNo.get(0).toString();
				}

				if ("Y".equals(info.getNewrow())) {
					List<String> listRetVal = out0123Repository.getNuroRES1001U00CheckingPatientExistence(hospCode,
							info.getBunho(), CommonUtils.parseDouble(info.getPkout1001()));
					// inner if
					if (!CollectionUtils.isEmpty(listRetVal)) {
						if ("Y".equalsIgnoreCase(listRetVal.get(0))) {
							result = out0123Repository.updateNuroRES1001U00ReservationOut0123(request.getUserId(),
									info.getReserComment(), info.getReserGubun(), new Date(), hospCode, info.getBunho(),
									CommonUtils.parseDouble(info.getPkout1001()));
						}
					} else {
						// if(!"".equals(info.getReserComment()) ||
						// !"".equals(info.getReserGubun())){
						if (!StringUtils.isEmpty(info.getReserComment())
								|| !StringUtils.isEmpty(info.getReserGubun())) {
							result = insertOut0123(info, request.getUserId(), hospCode);
							if (result < 0) {
								errCode = "5";
								response.setErrCode(errCode);
								response.setResult(false);
								LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00ReceptionNumber: errCode=" + errCode); 
								throw new ExecutionException(response.build());
							}
						}
						insertOut1001(info, request.getUserId(), tGubun, tJubsuNo, hospCode, sessionHospCode,
								isOtherClinic, getLanguage(vertx, sessionId));
						pkOut1001 = info.getPkout1001();
						result = 1;
						booking = Booking.BOOKING;
					} // end inner if
				} else {
					List<String> listTChk = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode,
							info.getBunho(), DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD),
							info.getGwa(), info.getDoctor());
					if (!CollectionUtils.isEmpty(listTChk)) {
						if (!"N".equals(listTChk.get(0))) {
							errCode = "6";
							response.setErrCode(errCode);
							response.setResult(false);
							LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00ReceptionNumber: errCode=" + errCode); 
							throw new ExecutionException(response.build());
						}
					}
					List<String> listRetVal = out0123Repository.getNuroRES1001U00CheckingPatientExistence(hospCode,
							info.getBunho(), CommonUtils.parseDouble(info.getPkout1001()));
					// inner if
					if (!CollectionUtils.isEmpty(listRetVal)) {
						if ("Y".equalsIgnoreCase(listRetVal.get(0))) {
							result = out0123Repository.updateNuroRES1001U00ReservationOut0123(request.getUserId(),
									info.getReserComment(), info.getReserGubun(), new Date(), hospCode, info.getBunho(),
									CommonUtils.parseDouble(info.getPkout1001()));
						}
					} else {
						if (!"".equals(info.getReserComment()) || !"".equals(info.getReserGubun())) {
							result = insertOut0123(info, request.getUserId(), hospCode);
							if (result < 0) {
								errCode = "7";
								response.setErrCode(errCode);
								response.setResult(false);
								LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00ReceptionNumber: errCode=" + errCode); 
								throw new ExecutionException(response.build());
							}
						}
						if (isOtherClinic) {
							result = out1001Repository
									.updateRES1001U00FrmModifyReserGrdRES1001SavePerformerIsOtherClinic(
											request.getUserId(), new Date(),
											DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD),
											info.getJinryoPreTime(), new BigDecimal(tJubsuNo), hospCode,
											sessionHospCode, CommonUtils.parseDouble(info.getPkout1001()));
							pkOut1001 = info.getPkout1001();
						} else {
							result = out1001Repository.updateRES1001U00FrmModifyReserGrdRES1001SavePerformer(
									request.getUserId(), new Date(),
									DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD),
									info.getJinryoPreTime(), new BigDecimal(tJubsuNo), hospCode,
									CommonUtils.parseDouble(info.getPkout1001()));
							pkOut1001 = info.getPkout1001();
						}
						booking = Booking.CHANGE_BOOKING;

					} // end inner if
				}

			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				 listData = out1001Repository.getPatientSurveyInfo(hospCode, info.getPkout1001(), getLanguage(vertx, sessionId));

				 List<String> listChkDeleted = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode, info.getBunho(), DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), info.getGwa(), info.getDoctor());
	 	            if (!CollectionUtils.isEmpty(listChkDeleted)) {
	 	            	tChk = listChkDeleted.get(0);	
	 	            	if(!"N".equals(tChk)){
	 	            		errCode = "8";
	 	            		response.setErrCode(errCode);
	    					response.setResult(false);
	    					LOGGER.info("RES1001U00SaveLayoutItemHandler : getNuroRES1001U00ReceptionNumber: errCode=" + errCode); 
	    					throw new ExecutionException(response.build());
	 	             	}
	 	            }
	 	          //delete OUT0123
	 	           result = out0123Repository.updateNuroRES1001U00ReservationOut0123(request.getUserId(), info.getReserComment(), info.getReserGubun(), new Date(),
	 						hospCode, info.getBunho(),CommonUtils.parseDouble(info.getPkout1001()) );
	 	         //delete OUT1001
	 	           if(isOtherClinic){
	 	        	  result = out1001Repository.deleteOut1001ByIdIsOtherClinic(hospCode, sessionHospCode, CommonUtils.parseDouble(info.getPkout1001()));
	 	           }else{
	 	        	   result = out1001Repository.deleteOut1001ById(hospCode, CommonUtils.parseDouble(info.getPkout1001()));
	 	           }
				 pkOut1001 = info.getPkout1001();
				 booking = Booking.DELETE_BOOKING;
			 } 
			 
			 bunho = info.getBunho();
			 List<Out0101> out0101 = out0101Repository.getByBunho(hospCode, bunho);
			 if (!CollectionUtils.isEmpty(out0101)) {
				 Out0101 firsRecord = out0101.get(0);
				 patientName = firsRecord.getSuname();
				 LOGGER.info("RES1001U00SaveLayoutItemHandler : patientName = " + patientName);
				 patientNameFurigana = firsRecord.getSuname2();
				 LOGGER.info("RES1001U00SaveLayoutItemHandler : patientNameFurigana = " + patientNameFurigana);
				 email = firsRecord.getEmail();
				 birth = firsRecord.getBirth().toString();
				 sex = firsRecord.getSex();
				 patientPwd = firsRecord.getPwd();
			 }
		}
		
		response.setResult(result != null && result > 0);
		if(result != null && result > 0) {
			LOGGER.info("Booking_Event: RES1001U00SaveLayoutItemHandler: " + result);
			if(!StringUtils.isEmpty(pkOut1001))
			{	
				NuroModelProto.BookingExamInfo.Builder bookingExamIfo = NuroModelProto.BookingExamInfo.newBuilder();
				bookingExamIfo.setIsMssRequest(request.getIsMssRequest());
				if(booking != null && booking.equals(Booking.DELETE_BOOKING))
				{
					if(!CollectionUtils.isEmpty(listData))
					{
						BookingExamInfo bookingInfo = listData.get(0);
						BeanUtils.copyProperties(bookingInfo, bookingExamIfo, getLanguage(vertx, sessionId));
					}

					LOGGER.info("Booking_Event: RES1001U00SaveLayoutItemHandler: Action.CANCEL_BOOKING)");
					bookingExamIfo.setPatientCode("");
					bookingExamIfo.setPatientName("");
					bookingExamIfo.setReservationCode(pkOut1001);
					bookingExamIfo.setAction(NuroModelProto.BookingExamInfo.Action.CANCEL_BOOKING);
					bookingExamIfo.setReserYn("Y");
					NuroServiceProto.BookingEvent.Builder message = NuroServiceProto.BookingEvent.newBuilder()
							.setPatientCode(bunho)
							.setPatientName("")
							.setBookingExamInfo(bookingExamIfo)
							.setHospCode(hospCode);
					publish(vertx, message.build());
				} else {
					List<BookingExamInfo> bookingExamInfos = out1001Repository.getPatientSurveyInfo(hospCode, pkOut1001, getLanguage(vertx, sessionId));
					if(!org.apache.commons.collections.CollectionUtils.isEmpty(bookingExamInfos)){
						BookingExamInfo bookingInfo = bookingExamInfos.get(0);
						BeanUtils.copyProperties(bookingInfo, bookingExamIfo, getLanguage(vertx, sessionId));
						bookingExamIfo.setDoctorId(bookingInfo.getDoctorId().intValue());
						bookingExamIfo.setDepartmentId(bookingInfo.getDepartmentId().intValue());
						bookingExamIfo.setBirth(birth);
						bookingExamIfo.setPatientNameFurigana(patientNameFurigana);
						bookingExamIfo.setPatientName(patientName);
						bookingExamIfo.setPhoneNumber(phoneNumber);
						bookingExamIfo.setEmail(StringUtils.isEmpty(email) ? "" : email);
						bookingExamIfo.setSex(sex);
						bookingExamIfo.setReservationDate(bookingInfo.getReservationDate());
						if(booking != null && booking.equals(Booking.CHANGE_BOOKING)){
							bookingExamIfo.setAction(NuroModelProto.BookingExamInfo.Action.CHANGE_BOOKING);
							LOGGER.info("Booking_Event: RES1001U00SaveLayoutItemHandler: Action.CHANGE_BOOKING)");
						}
						else{
							bookingExamIfo.setAction(NuroModelProto.BookingExamInfo.Action.BOOKING);
							LOGGER.info("Booking_Event: RES1001U00SaveLayoutItemHandler: Action.BOOKING)");
						}
						bookingExamIfo.setPatientPwd(StringUtils.isEmpty(patientPwd) ? "" : patientPwd);
						bookingExamIfo.setReserYn("Y");
						
						NuroServiceProto.BookingEvent.Builder message = NuroServiceProto.BookingEvent.newBuilder()
								.setPatientCode(bookingInfo.getPatientCode())
								.setPatientName(patientName)
								.setBookingExamInfo(bookingExamIfo)
								.setHospCode(hospCode);
						publish(vertx, message.build());
					}
				}
			}

			MonitorLog.writeMonitorLog(MonitorKey.REG_RESERVATION, "New reservation have been successfully registered");
		}
		
		return response.build();
	}
	
	public Integer insertOut0123(RES1001U00SaveLayoutItemInfo info , String userId, String hospCode){
			Out0123 out0123 = new Out0123();
			out0123.setSysDate(new Date());
			out0123.setSysId(userId);
			out0123.setUpdDate(new Date());
			out0123.setUpdId(userId);
			out0123.setHospCode(hospCode);
			out0123.setBunho(info.getBunho());
			out0123.setSeq(new Double(1));
			out0123.setReqDate(new Date());
			out0123.setReqTime(DateUtil.getCurrentHH24MI());
			out0123.setReqGwa(info.getGwa());
			out0123.setReqDoctor(info.getDoctor());
			out0123.setAnswerDate(DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) );
			out0123.setAnswerTime(info.getJinryoPreTime());
			out0123.setAnswerGwa("%");
			out0123.setAnswerDoctor("%");
			out0123.setAnswerEndYn("Y");
			out0123.setInOutGubun("O");
			out0123.setComments(info.getReserComment());
			out0123.setFkout1001(CommonUtils.parseDouble(info.getPkout1001()));
			out0123.setFkinp1001(new Double(0));
			out0123.setCommentType("1");
			out0123.setReserGubun(info.getReserGubun());
			
			out0123Repository.save(out0123);
			return 1;
	}
	
	private void insertOut1001(RES1001U00SaveLayoutItemInfo info , String userId, String tGubun, String tJubsuNo, String hospCode, String sessionHospCode, boolean isOtherClinic, String language) {
		String jubsuGubun = "99";
		Out1001 out1001 = new Out1001();
		out1001.setSysDate(new Date());
		out1001.setSysId(userId);
		out1001.setUpdDate(new Date());
		out1001.setUpdId(userId);
		out1001.setHospCode(isOtherClinic ? hospCode : sessionHospCode);
		out1001.setPkout1001(StringUtils.isEmpty(info.getPkout1001()) ? null : new Double(info.getPkout1001()));
		out1001.setReserYn("Y");
		out1001.setNaewonDate(DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
		out1001.setBunho(info.getBunho());
		out1001.setGwa(info.getGwa());
		out1001.setGubun(tGubun);
		out1001.setDoctor(info.getDoctor());
		out1001.setResChanggu(info.getChanggu());
		out1001.setJubsuTime(info.getJinryoPreTime());
		out1001.setChojae(info.getChojae());
		out1001.setResGubun(info.getResGubun());
		out1001.setNaewonType("0");
		out1001.setJubsuNo(new BigDecimal(tJubsuNo));
		out1001.setResInputGubun(info.getInputGubun());
		out1001.setNaewonYn("N");
		out1001.setJubsuGubun(jubsuGubun);
		out1001.setOutHospCode(sessionHospCode);
		
		out1001Repository.save(out1001);
	}

}