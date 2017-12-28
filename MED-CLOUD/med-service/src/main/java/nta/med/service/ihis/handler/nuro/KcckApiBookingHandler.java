package nta.med.service.ihis.handler.nuro;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.lang.RandomStringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.common.util.i18n.HalfFullConverter;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out0106;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.AutoBunhoFlg;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.MaxSequence;
import nta.med.core.glossary.PrefixCode;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
@Transactional
public class KcckApiBookingHandler extends ScreenHandler<NuroServiceProto.KcckApiBookingRequest, NuroServiceProto.KcckApiBookingResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(KcckApiBookingHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private OUT0101U02SaveGridHandler out0101U02SaveGridHandler;

	@Resource
	private RES1001U00SaveLayoutItemHandler res1001U00SaveLayoutItemHandler;
	
	@Resource
	private SearchBookingScheduleHandler searchBookingScheduleHandler;
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;  
	
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository; 
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out0106Repository out0106Repository;
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Override
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.KcckApiBookingRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("KcckApiBookingRequest preHandle not found hosp code");
		}
	}
	
	@Override
	public boolean isValid(NuroServiceProto.KcckApiBookingRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReservationDate()) && DateUtil.toDate(request.getReservationDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		if (!StringUtils.isEmpty(request.getPatientBirthday()) && DateUtil.toDate(request.getPatientBirthday(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public NuroServiceProto.KcckApiBookingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.KcckApiBookingRequest request) throws Exception {
		NuroServiceProto.KcckApiBookingResponse.Builder response = NuroServiceProto.KcckApiBookingResponse.newBuilder();
		NuroServiceProto.OUT0101U02SaveGridResponse.Builder registerPatientResponse = NuroServiceProto.OUT0101U02SaveGridResponse.newBuilder();
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder bookingExaminationResponse =  NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();

		String pkOut1001 = "";
		String doctorCode = "";
		if(StringUtils.isEmpty(request.getDoctorCode())){
			response.setResult(false);
			response.setErrCode("not.found.doctor.enable.slot");
			throw new ExecutionException(response.build());
		} else {
			doctorCode = request.getDoctorCode();
			response.setDoctorCode(doctorCode);
		}
		
		String departmentName = bas0260Repository.getOcsaOCS0503Q00DepartmentNameList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getDepartmentCode());
		String doctorName = bas0270Repository.getDoctorNameBAS0270(getHospitalCode(vertx, sessionId), request.getDepartmentCode(), doctorCode, DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD));
		if(!StringUtils.isEmpty(departmentName)){
			response.setDepartmentName(departmentName);
		}
		if(!StringUtils.isEmpty(doctorName)){
			response.setDoctorName(doctorName);
		}
		
		// new booking
		boolean useOrcaCloud = false;
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(request.getHospCode(), AccountingConfig.ACCT_TYPE.getValue());
		useOrcaCloud = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
		String refPwd = "";
		String patientCodeMis = "";
		
		if(StringUtils.isEmpty(request.getPatientCode())){
			LOGGER.info("KCCK_BEGIN_NEW_BOOKING: department_code=" + request.getDepartmentCode() + ", doctor_code=" + request.getDoctorCode());
			
			// register patient
			String bunho = "";
			if(useOrcaCloud){
				bunho = "00000000*";
			} else {
				String autoGen = bas0001Repository.checkAutoGenHospital(request.getHospCode(), getLanguage(vertx, sessionId));
				String seqInc = commonRepository.getSeqInc("OUT0101_SEQ", request.getHospCode());
				String checkBunho = commonRepository.getNextBunho("OUT0101_SEQ", seqInc, request.getHospCode());
				if (!StringUtils.isEmpty(checkBunho)) {
					if((new BigDecimal(checkBunho).compareTo(MaxSequence.OUT0101_MAX_SEQUENCE.getValue())) == 1){
						response.setResult(false);
						throw new ExecutionException(response.build()); 
					}
				}
				
				if(AutoBunhoFlg.NORMAL.getValue().equals(autoGen)){
					bunho = PrefixCode.MBS.getValue().concat(CommonUtils.formatNumericSeqN(new Long(checkBunho), 6));
				} else {
					bunho = CommonUtils.formatNumericSeqN(new Long(checkBunho));
				}
			}
			
			registerPatientResponse = registerPatient(vertx, clientId, sessionId, contextId, request, bunho).toBuilder();
			if(!registerPatientResponse.getResult()){
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
			if(useOrcaCloud && !StringUtils.isEmpty(registerPatientResponse.getNewPatientCode())){
				bunho = registerPatientResponse.getNewPatientCode();
			}
			refPwd = registerPatientResponse.getRefPwd() == null ? "" : registerPatientResponse.getRefPwd();
			
			// booking examination request
			pkOut1001 = commonRepository.getNextVal("OUT1001_SEQ");
			bookingExaminationResponse = bookingExamination(vertx, clientId, sessionId, contextId, request, pkOut1001, bunho, doctorCode, useOrcaCloud).toBuilder();
			if(!bookingExaminationResponse.getResult()){
				response.setResult(false);
				//response.setErrCode(bookingExaminationResponse.getErrCode());
				throw new ExecutionException(response.build());
			}
			response.setNewPatientCode(bunho);
			response.setReservationCode(pkOut1001);
			
			// update parent for collection child 
			if(!StringUtils.isEmpty(request.getChildCodeList()) && StringUtils.isEmpty(request.getParentCode())){
				String[] listChildPatientCode = request.getChildCodeList().split(";");
				List<String> listChild = Arrays.asList(listChildPatientCode); 
				updateChildPatient(response, bunho, listChild, request.getHospCode());
			}
			
			// note for doctor
			if(!StringUtils.isEmpty(request.getHangmogCode()) && !StringUtils.isEmpty(request.getHangmogName())){
				saveNoteVaccineForDoctor(response, request.getHospCode(), bunho, request.getHangmogCode(), request.getHangmogName(), request.getUserId());	
			}
			
			patientCodeMis = response.getNewPatientCode();
			LOGGER.info("KCCK_END_NEW_BOOKING: SUCCESS!!! patient_code="+ bunho + ", department_code=" + request.getDepartmentCode() + ", doctor_code=" + request.getDoctorCode());
		}
		
		// re-booking
		if(!StringUtils.isEmpty(request.getPatientCode())){
			pkOut1001 = commonRepository.getNextVal("OUT1001_SEQ");
			bookingExaminationResponse = bookingExamination(vertx, clientId, sessionId, contextId, request, pkOut1001, request.getPatientCode(), doctorCode, useOrcaCloud).toBuilder();
			if(!bookingExaminationResponse.getResult()){
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
			
			// update parent for collection child 
			if(!StringUtils.isEmpty(request.getChildCodeList()) && StringUtils.isEmpty(request.getParentCode())){
				String[] listChildPatientCode = request.getChildCodeList().split(";");
				List<String> listChild = Arrays.asList(listChildPatientCode); 
				updateChildPatient(response, request.getPatientCode(), listChild, request.getHospCode());
			}
			
			// note for doctor
			if(!StringUtils.isEmpty(request.getHangmogCode()) && !StringUtils.isEmpty(request.getHangmogName())){
				saveNoteVaccineForDoctor(response, request.getHospCode(), request.getPatientCode(), request.getHangmogCode(), request.getHangmogName(), request.getUserId());	
			}
			response.setReservationCode(pkOut1001);
			patientCodeMis = request.getPatientCode();
		}
		
		LOGGER.info("Request to MIS API: hosp_code = " + request.getHospCode() + ", patient_code = "
				+ patientCodeMis + ", department_code = " + request.getDepartmentCode()
				+ ", reservation_code = " + pkOut1001 + ", SurveyYn = " + request.getSurveyYn());
		if("Y".equals(request.getSurveyYn())){
			// request to MIS-API to get link survey
			if(StringUtils.isEmpty(refPwd)){
				List<Out0101> ptList = out0101Repository.getByBunho(request.getHospCode(), patientCodeMis);
				if(CollectionUtils.isEmpty(ptList)){
					LOGGER.warn("Patient not found: patient_code = " + patientCodeMis + ", hosp_code = " + request.getHospCode());
				} else {
					refPwd = ptList.get(0).getPwd();
				}
			}
			
			NuroServiceProto.GetMisSurveyLinkResponse rp = getMisSurveyLink(vertx, request.getHospCode(), patientCodeMis, request.getDepartmentCode(), departmentName, String.valueOf(CommonUtils.parseDouble(pkOut1001)), request, getLanguage(vertx, sessionId), refPwd);
			response.setMisSurveyLink(rp.getSurveyLink());
		} else {
			response.setMisSurveyLink("");
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private void updateChildPatient(NuroServiceProto.KcckApiBookingResponse.Builder response, String parentCode, List<String> listChildPatientCode, String hospCode) {
		try {
			out0101Repository.updateParentCodeByPatient(parentCode, listChildPatientCode, hospCode);
		} catch (Exception e) {
			e.printStackTrace();
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
	}
	
	
	private void saveNoteVaccineForDoctor(NuroServiceProto.KcckApiBookingResponse.Builder response, String hospCode, String bunho, String hangmogCode, String hangmogName, String userId){
		 Double retVal = out0106Repository.getSerOUT0106U00SaveComments(hospCode, bunho);
		 if( retVal == null){
			 throw new ExecutionException(response.build());
		 }
		 Out0106 out0106 = new Out0106();
		 out0106.setSysDate(new Date());
		 out0106.setSysId(userId);
		 out0106.setUpdDate(new Date());
		 out0106.setUpdId(userId);
		 out0106.setHospCode(hospCode);
		 out0106.setComments(hangmogName);
		 out0106.setSer(retVal);
		 out0106.setBunho(bunho);
		 out0106.setDisplayYn(YesNo.NO.getValue());
		 out0106.setCmmtGubun("B");
		 out0106.setHangmogCode(hangmogCode);
		 out0106Repository.save(out0106);
		 LOGGER.info("SAVE_VACCINE_HANMONG: SUCCESS!!! hangmog_code="+ hangmogCode + ", hangmog_name=" + hangmogName);
	}
	

	private NuroServiceProto.OUT0101U02SaveGridResponse registerPatient(Vertx vertx, String clientId,
			String sessionId, long contextId, NuroServiceProto.KcckApiBookingRequest request, String bunho) throws Exception {
		NuroServiceProto.OUT0101U02SaveGridResponse.Builder response = NuroServiceProto.OUT0101U02SaveGridResponse.newBuilder();
		try {
			// register patient
			NuroServiceProto.OUT0101U02SaveGridRequest.Builder registerPatientRequest = NuroServiceProto.OUT0101U02SaveGridRequest.newBuilder();
			NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder patientInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
			
			patientInfo.setBunho(bunho);
			if(Language.JAPANESE.toString().equalsIgnoreCase(getLanguage(vertx, sessionId))){
				patientInfo.setSuname(HalfFullConverter.toFullWidth(request.getPatientNameKanji()));
				patientInfo.setSuname2(HalfFullConverter.toFullWidthKana(request.getPatientNameKana()));
			} else {
				patientInfo.setSuname(request.getPatientNameKanji());
				patientInfo.setSuname2(request.getPatientNameKana());
			}
			patientInfo.setSex(request.getPatientSex());
			patientInfo.setBirth(request.getPatientBirthday());
		    patientInfo.setDeleteYn("N");
		    patientInfo.setIuGubun("I");

			patientInfo.setTel(request.getPatientTel());
			patientInfo.setTelType("1");
			patientInfo.setPatientType(request.getPatientType()); //  - ＭＳＳから登録
			patientInfo.setEmail(request.getPatientEmail());
		    patientInfo.setType(request.getType());
		    patientInfo.setPass(RandomStringUtils.randomAlphabetic(8).toUpperCase());
		    patientInfo.setParentCode(request.getParentCode());
			registerPatientRequest.addPatientList(patientInfo);
			registerPatientRequest.setUserId(request.getUserId());
			response = out0101U02SaveGridHandler.handle(vertx, clientId, sessionId, contextId, registerPatientRequest.build()).toBuilder();
		} catch (Exception e) {
			LOGGER.warn("ExecutionException!!! FAILURE!!! KcckApiBookingHandler: registerPatient", e);
			response.setResult(false);
			return response.build();
		}
		return response.build();
	}
	
	private NuroServiceProto.RES1001U00SaveLayoutItemResponse bookingExamination(Vertx vertx, String clientId,
			String sessionId, long contextId, NuroServiceProto.KcckApiBookingRequest request, String pkOut1001, String patientCode, String doctorCode, boolean useOrcaCloud) throws Exception{
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder rp = NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder(); 
		try {
			// booking examination
			NuroServiceProto.RES1001U00SaveLayoutItemRequest.Builder reBookingRequest = NuroServiceProto.RES1001U00SaveLayoutItemRequest.newBuilder();
			NuroModelProto.RES1001U00SaveLayoutItemInfo.Builder bookingInfo = NuroModelProto.RES1001U00SaveLayoutItemInfo.newBuilder();
			bookingInfo.setBunho(patientCode);
			bookingInfo.setGwa(request.getDepartmentCode());
			bookingInfo.setJinryoPreDate(request.getReservationDate());
			bookingInfo.setJinryoPreTime(request.getReservationTime());
			bookingInfo.setDoctor(doctorCode);
			bookingInfo.setInputGubun("E");
			bookingInfo.setPkout1001(pkOut1001);
//			bookingInfo.setGubun("G1");
			bookingInfo.setGubun("Z0");
			bookingInfo.setChojae("3");
			bookingInfo.setResGubun("2");
			bookingInfo.setNewrow("Y");
			bookingInfo.setJubsuNo("1");
			bookingInfo.setBirth(request.getPatientBirthday());
			bookingInfo.setPatientName(request.getPatientNameKanji());
			bookingInfo.setPatientNameFurigana(request.getPatientNameKana());
			bookingInfo.setPhone(request.getPatientTel());
			bookingInfo.setEmail(request.getPatientEmail());
			bookingInfo.setSex(request.getPatientSex());
			bookingInfo.setRowState(DataRowState.MODIFIED.getValue());
			reBookingRequest.addLayoutItem(bookingInfo);
			reBookingRequest.setUserId(request.getUserId());
			reBookingRequest.setIsMssRequest(true);
			rp = res1001U00SaveLayoutItemHandler.handle(vertx, clientId, sessionId, contextId, reBookingRequest.build()).toBuilder();
		} catch (Exception e) {
			LOGGER.warn("ExecutionException!!! FAILURE!!! KcckApiBookingHandler: bookingExamination", e);
			rp.setResult(false);
			return rp.build();
		}
		if(!rp.getResult()){
			rp.setResult(false);
			return rp.build();
		}
		
		if(useOrcaCloud){
			List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(getHospitalCode(vertx, sessionId), AccountingConfig.IF_ORCA_GWA.getValue(), request.getDepartmentCode());
			List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(getHospitalCode(vertx, sessionId), AccountingConfig.IF_ORCA_DOCTOR.getValue(), doctorCode.substring(2, doctorCode.length()));
			String dept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
			String doctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
			
			NuroServiceProto.BookingExaminationRequest.Builder builder = NuroServiceProto.BookingExaminationRequest
					.newBuilder()
					.setHospCode(getHospitalCode(vertx, sessionId))
					.setDepartmentCode(dept)
					.setDoctorCode(doctor)
					.setReservationDate(request.getReservationDate())
					.setReservationTime(request.getReservationTime())
					.setPatientCode(patientCode)
					.setPatientNameKanji(request.getPatientNameKanji())
					.setPatientNameKana(request.getPatientNameKana())
					.setPatientTel("")
					.setPatientSex("")
					.setPatientBirthday(request.getPatientBirthday())
					.setLocale("")
					.setPatientType("")
					.setType("")
					.setUserId("")
					.setReservationCode("")
					.setAction(NuroServiceProto.BookingExaminationRequest.Action.BOOKING); 
			
			LOGGER.info("Request Booking Examination to external system: patient_code = " + patientCode);
			FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
			NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
			
			if(r == null || !r.getResult()){
				String errCode = "";
				if(r.hasErrCode()){
					errCode = r.getErrCode();
					LOGGER.info("Fail to Booking Examination to External System, Error Code = " + errCode);
				} else {
					LOGGER.info("Fail to Booking Examination to External System !");
				}
				
				NuroServiceProto.KcckApiBookingResponse.Builder errResponse = NuroServiceProto.KcckApiBookingResponse.newBuilder().setResult(false).setErrCode(errCode);
				throw new ExecutionException(errResponse.build());
			}
		}
		
		return rp.build();
	}

	private NuroServiceProto.GetMisSurveyLinkResponse getMisSurveyLink(Vertx vertx, String hospCode, String patientCode,
			String departmentCode, String departmentName, String reservationCode, NuroServiceProto.KcckApiBookingRequest rq, String language, String refPwd) {
		NuroServiceProto.GetMisSurveyLinkResponse.Builder response = NuroServiceProto.GetMisSurveyLinkResponse.newBuilder();
		Long rqId = System.currentTimeMillis();
		try {
			String deptName = bas0260Repository.getBasLoadGwaName(departmentCode,DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD), hospCode, language);
			
			NuroServiceProto.GetMisSurveyLinkRequest.Builder request = NuroServiceProto.GetMisSurveyLinkRequest.newBuilder();
			request.setId(rqId);
			request.setHospCode(hospCode);
			request.setPatientCode(patientCode);
			request.setDepartmentCode(departmentCode);
			request.setReservationCode(reservationCode);
			
			NuroModelProto.BookingExamInfo.Builder bookingExam = NuroModelProto.BookingExamInfo.newBuilder();
			if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
				bookingExam.setPatientName(HalfFullConverter.toFullWidth(rq.getPatientNameKanji()));
				bookingExam.setPatientNameFurigana(HalfFullConverter.toFullWidthKana(rq.getPatientNameKana()));
			} else {
				bookingExam.setPatientName(rq.getPatientNameKanji());
				bookingExam.setPatientNameFurigana(rq.getPatientNameKana());
			}
			
			bookingExam.setPatientCode(patientCode);
			bookingExam.setPhoneNumber("");
			bookingExam.setDepartmentCode(departmentCode);
			bookingExam.setDepartmentName(deptName == null ? "" : deptName);
			bookingExam.setDoctorCode("");
			bookingExam.setDoctorName("");
			bookingExam.setReservationDate(rq.getReservationDate());
			bookingExam.setReservationTime(rq.getReservationTime());
			bookingExam.setReservationCode(reservationCode);
			bookingExam.setPatientPwd(refPwd == null ? "" : refPwd);
			bookingExam.setEmail("");
			bookingExam.setHospCode(hospCode);
			
			request.setBookingExamInfo(bookingExam);
			
			FutureEx<NuroServiceProto.GetMisSurveyLinkResponse> res = send(vertx, parser, request.build(), hospCode);
			NuroServiceProto.GetMisSurveyLinkResponse r = res.get(30, TimeUnit.SECONDS);
			
			LOGGER.info("Response from MIS-API: " + (r == null ? "NULL" : format(r)));
			return r;
		} catch (Exception e) {
			LOGGER.warn("Exception when get link survey: ", e);
			response.setId(rqId);
			response.setResult("0");
			response.setSurveyLink("");
		}
		
		return response.build();
	}
}
