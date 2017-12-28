package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

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
import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
@Transactional
public class KcckApiChangeBookingHandler extends ScreenHandler<NuroServiceProto.KcckApiChangeBookingRequest, NuroServiceProto.KcckApiChangeBookingResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(KcckApiChangeBookingHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private OUT0101U02SaveGridHandler out0101U02SaveGridHandler;

	@Resource
	private RES1001U00SaveLayoutItemHandler res1001U00SaveLayoutItemHandler;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;  
	
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository; 
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);

	
	@Override
	@Transactional(readOnly = true)
    @Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.KcckApiChangeBookingRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("KcckApiChangeBookingRequest preHandle not found hosp code");
		}
	}
	
	@Override
	public boolean isValid(NuroServiceProto.KcckApiChangeBookingRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReservationDate()) && DateUtil.toDate(request.getReservationDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public NuroServiceProto.KcckApiChangeBookingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.KcckApiChangeBookingRequest request) throws Exception {
		NuroServiceProto.KcckApiChangeBookingResponse.Builder response = NuroServiceProto.KcckApiChangeBookingResponse.newBuilder();
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder changeBookingResponse =  NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();

		if(!StringUtils.isEmpty(request.getDoctorCode())){
			response.setDoctorCode(request.getDoctorCode());
			String doctorName = bas0270Repository.getDoctorNameBAS0270(getHospitalCode(vertx, sessionId), request.getDepartmentCode(), request.getDoctorCode(), DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD));
			if(!StringUtils.isEmpty(doctorName)){
				response.setDoctorName(doctorName);
			}
		}
		if(!StringUtils.isEmpty(request.getDepartmentCode())){
			response.setDepartmentCode(request.getDepartmentCode());
			String departmentName = bas0260Repository.getOcsaOCS0503Q00DepartmentNameList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getDepartmentCode());
			if(!StringUtils.isEmpty(departmentName)){
				response.setDepartmentName(departmentName);
			}
		}
		
		changeBookingResponse = bookingExamination(vertx, clientId, sessionId, contextId, request).toBuilder();
		if(!changeBookingResponse.getResult()){
			response.setResult(false);
			//response.setErrCode(changeBookingResponse.getErrCode());
			throw new ExecutionException(response.build());
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private NuroServiceProto.RES1001U00SaveLayoutItemResponse bookingExamination(Vertx vertx, String clientId,
			String sessionId, long contextId, NuroServiceProto.KcckApiChangeBookingRequest request) throws Exception{
		
		Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(getHospitalCode(vertx, sessionId), Double.parseDouble(request.getReservationCode().replace(",", ".")));
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder rp = NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();   
		try {
			// booking examination
			NuroServiceProto.RES1001U00SaveLayoutItemRequest.Builder reBookingRequest = NuroServiceProto.RES1001U00SaveLayoutItemRequest.newBuilder();
			NuroModelProto.RES1001U00SaveLayoutItemInfo.Builder bookingInfo = NuroModelProto.RES1001U00SaveLayoutItemInfo.newBuilder();
			bookingInfo.setBunho(request.getPatientCode());
			if(!StringUtils.isEmpty(request.getDepartmentCode())){
				bookingInfo.setGwa(request.getDepartmentCode());
			}
			if(!StringUtils.isEmpty(request.getDoctorCode())){
				bookingInfo.setDoctor(request.getDoctorCode());
			}
			bookingInfo.setJinryoPreDate(request.getReservationDate());
			bookingInfo.setJinryoPreTime(request.getReservationTime());
			bookingInfo.setPkout1001(request.getReservationCode());
			bookingInfo.setRowState(DataRowState.MODIFIED.getValue());
			reBookingRequest.addLayoutItem(bookingInfo);
			reBookingRequest.setIsMssRequest(true);
			rp = res1001U00SaveLayoutItemHandler.handle(vertx, clientId, sessionId, contextId, reBookingRequest.build()).toBuilder();
			
		} catch (Exception e) {
			LOGGER.error("FAILURE !!! KcckApiChangeBookingHandler: bookingExamination", e);
			rp.setResult(false);
			return rp.build();
		}
		if(!rp.getResult()) return rp.build();
		
		boolean useOrcaCloud = false;
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(request.getHospCode(), AccountingConfig.ACCT_TYPE.getValue());
		useOrcaCloud = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
		
		if(!useOrcaCloud) return rp.build();
		
		List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(getHospitalCode(vertx, sessionId), AccountingConfig.IF_ORCA_GWA.getValue(), out1001.getGwa());
		List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(getHospitalCode(vertx, sessionId), AccountingConfig.IF_ORCA_DOCTOR.getValue(), out1001.getDoctor().substring(2, out1001.getDoctor().length()));
		String dept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
		String doctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
		
		LOGGER.info("Request Change Booking Examination to external system: patient_code = " + out1001.getBunho());
		
		// cancel booking in external system
		NuroServiceProto.BookingExaminationRequest.Builder builder = NuroServiceProto.BookingExaminationRequest
				.newBuilder()
				.setHospCode(getHospitalCode(vertx, sessionId))
				.setDepartmentCode(dept)
				.setDoctorCode(doctor)
				.setReservationDate(DateUtil.toString(out1001.getNaewonDate(), DateUtil.PATTERN_YYMMDD))
				.setReservationTime(out1001.getJubsuTime())
				.setPatientCode(out1001.getBunho())
				.setPatientNameKanji("")
				.setPatientNameKana("")
				.setPatientTel("")
				.setPatientSex("")
				.setPatientBirthday("")
				.setLocale("")
				.setPatientType("")
				.setType("")
				.setUserId("")
				.setReservationCode("")
				.setAction(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING); 
		
		FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
		NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
		
		if(r == null || !r.getResult()){
			String errCode = "";
			if(r.hasErrCode()){
				errCode = r.getErrCode();
				LOGGER.info("Fail to Cancel Booking Examination to External System (Case Change Booking), Error Code = " + errCode);
			} else {
				LOGGER.info("Fail to Cancel Booking Examination to External System (Case Change Booking) !");
			}
			
			NuroServiceProto.KcckApiChangeBookingResponse.Builder errResponse = NuroServiceProto.KcckApiChangeBookingResponse.newBuilder().setResult(false).setErrCode(errCode);
			throw new ExecutionException(errResponse.build());
		}
		
		// booking-new in external system
		NuroServiceProto.BookingExaminationRequest.Builder builderNew = NuroServiceProto.BookingExaminationRequest
				.newBuilder()
				.setHospCode(getHospitalCode(vertx, sessionId))
				.setDepartmentCode(dept)
				.setDoctorCode(doctor)
				.setReservationDate(request.getReservationDate())
				.setReservationTime(request.getReservationTime())
				.setPatientCode(out1001.getBunho())
				.setPatientNameKanji("")
				.setPatientNameKana("")
				.setPatientTel("")
				.setPatientSex("")
				.setPatientBirthday("")
				.setLocale("")
				.setPatientType("")
				.setType("")
				.setUserId("")
				.setReservationCode("")
				.setAction(NuroServiceProto.BookingExaminationRequest.Action.BOOKING); 
		
		FutureEx<NuroServiceProto.BookingExaminationResponse> resNew = send(vertx, parser, builderNew.build(), getHospitalCode(vertx, sessionId));
		NuroServiceProto.BookingExaminationResponse rNew = resNew.get(30, TimeUnit.SECONDS);
		
		if(rNew == null || !rNew.getResult()){
			String errCode = "";
			if(r.hasErrCode()){
				errCode = r.getErrCode();
				LOGGER.info("Fail to Booking Examination to External System (Case Change Booking), Error Code = " + errCode);
			} else {
				LOGGER.info("Fail to Booking Examination to External System (Case Change Booking) !");
			}
			
			NuroServiceProto.KcckApiChangeBookingResponse.Builder errResponse = NuroServiceProto.KcckApiChangeBookingResponse.newBuilder().setResult(false).setErrCode(errCode);
			throw new ExecutionException(errResponse.build());
		}
		
		return rp.build();
	}
}
