package nta.med.service.ihis.handler.nuro;

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
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.Booking;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroModelProto.RES1001U00SaveLayoutItemInfo;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
@Transactional
public class RES1001U00SaveLayoutHandler extends ScreenHandler<NuroServiceProto.RES1001U00SaveLayoutRequest, NuroServiceProto.RES1001U00SaveLayoutItemResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(RES1001U00SaveLayoutHandler.class);
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private RES1001U00SaveLayoutItemHandler res1001U00SaveLayoutItemHandler;
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	
	@Override
	public boolean isValid(NuroServiceProto.RES1001U00SaveLayoutRequest request, Vertx vertx, String clientId, String sessionId) {
		for(RES1001U00SaveLayoutItemInfo info : request.getLayoutItemList()){
			if (!StringUtils.isEmpty(info.getJinryoPreDate()) && DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
				return false;
			}
		}
		return true;
	}

	@Override
	public NuroServiceProto.RES1001U00SaveLayoutItemResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.RES1001U00SaveLayoutRequest request) throws Exception {
		
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder response = NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();
		List<NuroModelProto.RES1001U00SaveLayoutItemInfo> bookingInfoList = request.getLayoutItemList();
		if(CollectionUtils.isEmpty(bookingInfoList)){
			response.setResult(false);
			return response.build();
		}
		
		NuroModelProto.RES1001U00SaveLayoutItemInfo bookingInfo = bookingInfoList.get(0);
		boolean isBookingOut = !StringUtils.isEmpty(request.getHospCodeLink()) && !StringUtils.isEmpty(request.getBunhoLink());
		String extHospCode = isBookingOut ? request.getHospCodeLink() : getHospitalCode(vertx, sessionId);
		String extPatientCode = isBookingOut ? request.getBunhoLink() : bookingInfo.getBunho();
		
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(extHospCode, AccountingConfig.ACCT_TYPE.getValue());
		if(CollectionUtils.isEmpty(bas0102List) || !AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())){
			return forwardRequest(vertx, clientId, sessionId, contextId, request);
		}
		
		int bookingType = CommonUtils.parseInteger(request.getBookingType());

		if(Booking.CHANGE_BOOKING.getValue() == bookingType){
			double pkOut1001 = CommonUtils.parseDouble(bookingInfo.getPkout1001());
			Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(extHospCode, pkOut1001);
			if(out1001 == null){
				LOGGER.error("Can not find OUT1001 by PKOUT1001 = " + pkOut1001 + ", HOSP_CODE = " + extHospCode);
				response.setResult(false);
				return response.build();
			}
			
			// Cancel booking
			NuroModelProto.RES1001U00SaveLayoutItemInfo cancelBookingInfo = bookingInfo.toBuilder()
					.setJinryoPreDate(DateUtil.toString(out1001.getNaewonDate(), DateUtil.PATTERN_YYMMDD))
					.setJinryoPreTime(out1001.getJubsuTime())
					.build();
			
			NuroServiceProto.BookingExaminationRequest rqCancel = toApiRequest(cancelBookingInfo, extHospCode, extPatientCode, Booking.DELETE_BOOKING.getValue());
			FutureEx<NuroServiceProto.BookingExaminationResponse> resCancel = send(vertx, parser, rqCancel, extHospCode);
			NuroServiceProto.BookingExaminationResponse rCancel = resCancel.get(30, TimeUnit.SECONDS);
			
			if(rCancel == null || !rCancel.getResult()){
				LOGGER.error("Cancel booking fail: hosp_code = " + extHospCode + ", patient_code = " + extPatientCode + ", PKOUT1001 = " + pkOut1001);
				response.setResult(false);
				response.setErrCode(rCancel != null ? rCancel.getErrCode() : "");
				return response.build();
			}
			
			// New booking again
			bookingType = Booking.BOOKING.getValue();
		}
		
		NuroServiceProto.BookingExaminationRequest rq = toApiRequest(bookingInfo, extHospCode, extPatientCode, bookingType);
		FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, rq, extHospCode);
		NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
		
		if(r == null){
			LOGGER.error("Booking fail, respose is null !!!");
			response.setResult(false);
			return response.build();
		}
		
		if(r.getResult()){
			NuroServiceProto.RES1001U00SaveLayoutItemResponse rp = forwardRequest(vertx, clientId, sessionId, contextId, request);
			if(!rp.getResult()){
				NuroServiceProto.BookingExaminationRequest rqDel = toApiRequest(bookingInfo, extHospCode, extPatientCode, Booking.DELETE_BOOKING.getValue());
				FutureEx<NuroServiceProto.BookingExaminationResponse> resDel = send(vertx, parser, rqDel, extHospCode);
				NuroServiceProto.BookingExaminationResponse rDel = res.get(30, TimeUnit.SECONDS);
			}
			
			return rp;
		}
		
		response.setResult(r.getResult());
		response.setErrCode(r.getErrCode());
		return response.build();
	}

	private NuroServiceProto.BookingExaminationRequest toApiRequest(NuroModelProto.RES1001U00SaveLayoutItemInfo info, String hospCode, String patientCode, int type){
		List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), info.getGwa());
		List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), info.getDoctor().substring(2, info.getDoctor().length()));
		String dept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
		String doctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
	
		NuroServiceProto.BookingExaminationRequest.Action extAction = NuroServiceProto.BookingExaminationRequest.Action.BOOKING;
		if(Booking.BOOKING.getValue() == type){
			extAction = NuroServiceProto.BookingExaminationRequest.Action.BOOKING;
		} else if(Booking.DELETE_BOOKING.getValue() == type){
			extAction = NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING;
		}
		
		NuroServiceProto.BookingExaminationRequest.Builder builder = NuroServiceProto.BookingExaminationRequest
				.newBuilder()
				.setHospCode(hospCode)
				.setDepartmentCode(dept)
				.setDoctorCode(doctor)
				.setReservationDate(info.getJinryoPreDate().replace("/", "-"))
				.setReservationTime(info.getJinryoPreTime().replace(":", ""))
				.setPatientCode(patientCode)
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
				.setAction(extAction);
		
		return builder.build();
	}
	
	private NuroServiceProto.RES1001U00SaveLayoutItemResponse forwardRequest(Vertx vertx, String clientId,
			String sessionId, long contextId, NuroServiceProto.RES1001U00SaveLayoutRequest request) {
		NuroServiceProto.RES1001U00SaveLayoutItemResponse.Builder rp = NuroServiceProto.RES1001U00SaveLayoutItemResponse.newBuilder();
		
		try {
			NuroServiceProto.RES1001U00SaveLayoutItemRequest.Builder rq = NuroServiceProto.RES1001U00SaveLayoutItemRequest.newBuilder();
			rq.setUserId(request.getUserId());
			rq.setHospCodeLink(request.getHospCodeLink());
			rq.setIsMssRequest(false);
			rq.addAllLayoutItem(request.getLayoutItemList());
			
			rp = res1001U00SaveLayoutItemHandler.handle(vertx, clientId, sessionId, contextId, rq.build()).toBuilder();
		} catch (Exception e) {
			LOGGER.error("Exception when call RES1001U00SaveLayoutItemRequest: ", e);
			rp.setResult(false);
			return rp.build();
		}
		
		return rp.build();
	}
}
