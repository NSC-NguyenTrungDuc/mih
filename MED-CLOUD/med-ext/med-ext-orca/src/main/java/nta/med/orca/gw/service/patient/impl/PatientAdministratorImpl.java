package nta.med.orca.gw.service.patient.impl;

import nta.med.common.glossary.Lifecyclet;
import nta.med.core.glossary.OrcaApiConfig;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.BookingServiceProto.GetMisSurveyLinkRequest;
import nta.med.ext.support.proto.BookingServiceProto.GetMisSurveyLinkResponse;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.AbstractRpcExtListener;
import nta.med.ext.support.service.booking.BookingRpcService;
import nta.med.ext.support.service.patient.PatientRpcService;
import nta.med.orca.gw.api.command.AcceptModCommand;
import nta.med.orca.gw.api.command.AppointmentCommand;
import nta.med.orca.gw.api.command.PatientInfoCommand;
import nta.med.orca.gw.api.command.PatientModCommand;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.api.contracts.service.*;
import nta.med.orca.gw.model.patient.*;
import nta.med.orca.gw.service.patient.PatientAdministrator;
import nta.med.orca.gw.service.system.SystemAdministrator;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;
import java.util.concurrent.TimeUnit;

/**
 * @author DEV-TiepNM
 */
@Component("patientAdministrator")
public class PatientAdministratorImpl extends Lifecyclet implements PatientAdministrator, PatientRpcService.Service, BookingRpcService.Service{

	private static final Log LOGGER = LogFactory.getLog(PatientAdministratorImpl.class);

	@Resource
    private PatientInfoCommand patientInfoCommand;

	@Resource
	private PatientRpcService patientRpcService;

    @Resource
    private SystemAdministrator systemAdministrator;
	
    @Resource
    private PatientModCommand patientModCommand;
    
    @Resource
    private AcceptModCommand acceptModCommand;
	
    @Resource
    private AppointmentCommand appointmentCommand;
    
    
	@Override
	protected void doStart() throws Exception {

	}

	@Override
	protected long doStop(long timeout, TimeUnit timeUnit) throws Exception {
		return timeout;
	}

	public PatientAdministratorImpl() {
    }

	@Override
	public boolean acceptingSynchronization(List<SyncExamination> exams, String hospCode) {

		List<PatientModelProto.SyncExamination> proto = new ArrayList<>();
		
		for (SyncExamination info : exams) {
			proto.add(info.toProto());
		}
		
		final PatientServiceProto.SyncExaminationRequest.Builder builder = PatientServiceProto.SyncExaminationRequest.newBuilder()
        		.addAllExamInfo(proto)
        		.setHospCode(hospCode)
				.setRoute(PatientServiceProto.SyncExaminationRequest.TraceRoute.ORCA);
		
		final PatientServiceProto.SyncExaminationResponse response = patientRpcService.syncExamination(builder.build());
		return response == null ? false : PatientServiceProto.SyncExaminationResponse.Result.SUCCESS.equals(response.getResult());
	}
	
	@Override
    public boolean patientSynchronization(SyncPatient syncPatient,
    									  List<PublicInsurance> publicInsuranceList,
								    	  List<PrivateInsurance> privateInsuranceList,
								    	  String userId, String hospCode,
								    	  String autoBunhoFlg,
								    	  String orcaGigwanCode) {

		PatientModelProto.SyncPatient patientInfo = syncPatient.toProto();
		
		List<PatientModelProto.PublicInsurance> boheomListInfo = new ArrayList<>();
		for (PublicInsurance boheom : publicInsuranceList) {
			boheomListInfo.add(boheom.toProto());
		}

		List<PatientModelProto.PrivateInsurance> gongbiListInfo = new ArrayList<>();
		for (PrivateInsurance gongbi : privateInsuranceList) {
			gongbiListInfo.add(gongbi.toProto());
		}

		PatientServiceProto.SyncPatientRequest.Builder request = PatientServiceProto.SyncPatientRequest.newBuilder();
		request.addPatients(patientInfo);
		request.addAllPublicInsurances(boheomListInfo);
		request.addAllPrivateInsurances(gongbiListInfo);
		request.setDoctorId(userId);
		request.setHospCode(hospCode);
		request.setRoute(PatientServiceProto.SyncPatientRequest.TraceRoute.ORCA);

		PatientServiceProto.SyncPatientResponse response = patientRpcService.syncPatient(request.build());

		return response == null ? false : PatientServiceProto.SyncPatientResponse.Result.SUCCESS.equals(response.getResult());
    }

	@Override
    public boolean patientListSynchronization(List<SyncPatient> syncPatientList,
    									  List<PublicInsurance> publicInsuranceList,
								    	  List<PrivateInsurance> privateInsuranceList,
								    	  String userId, String hospCode,
								    	  String autoBunhoFlg,
								    	  String orcaGigwanCode) {

		List<PatientModelProto.SyncPatient> syncPatientListInfo = new ArrayList<>();
		for (SyncPatient syncPatient : syncPatientList) {
			PatientModelProto.SyncPatient patientInfo = syncPatient.toProto();
			syncPatientListInfo.add(patientInfo);
		}
		
		List<PatientModelProto.PublicInsurance> boheomListInfo = new ArrayList<>();
		for (PublicInsurance boheom : publicInsuranceList) {
			boheomListInfo.add(boheom.toProto());
		}

		List<PatientModelProto.PrivateInsurance> gongbiListInfo = new ArrayList<>();
		for (PrivateInsurance gongbi : privateInsuranceList) {
			gongbiListInfo.add(gongbi.toProto());
		}

		PatientServiceProto.SyncPatientRequest.Builder request = PatientServiceProto.SyncPatientRequest.newBuilder();
		request.addAllPatients(syncPatientListInfo);
		request.addAllPublicInsurances(boheomListInfo);
		request.addAllPrivateInsurances(gongbiListInfo);
		request.setDoctorId(userId);
		request.setHospCode(hospCode);
		request.setRoute(PatientServiceProto.SyncPatientRequest.TraceRoute.ORCA);
		
		PatientServiceProto.SyncPatientResponse response = patientRpcService.syncPatient(request.build());
		return response == null ? false : PatientServiceProto.SyncPatientResponse.Result.SUCCESS.equals(response.getResult());
    }
	
	@Override
	public boolean reservationListSynchronization(List<SyncReservation> syncReservationList, String hospCode) {
		List<PatientModelProto.SyncReservation> syncReservationListInfo = new ArrayList<>();
		for (SyncReservation syncReservation : syncReservationList) {
			PatientModelProto.SyncReservation info = syncReservation.toProto();
			syncReservationListInfo.add(info);
		}
		
		PatientServiceProto.SyncReservationRequest.Builder request = PatientServiceProto.SyncReservationRequest.newBuilder();
		request.setUserId("ORCA");
		request.addAllReservation(syncReservationListInfo);
		request.setHospCodeLink("");
		request.setTabIsAll(false);
		request.setIsMssRequest(false);
		request.setIsExtAccounting(true);
		request.setHospCode(hospCode);
		request.setRoute(PatientServiceProto.SyncReservationRequest.TraceRoute.ORCA);
		
		PatientServiceProto.SyncReservationResponse response = patientRpcService.syncReservation(request.build());
		return response == null ? false : PatientServiceProto.SyncReservationResponse.Result.SUCCESS.equals(response.getResult());
	}

	
	@Override
	public PatientServiceProto.CreatePatientResponse createPatient(PatientServiceProto.CreatePatientRequest request) throws Exception{
		PatientServiceProto.CreatePatientResponse.Builder response = PatientServiceProto.CreatePatientResponse.newBuilder();
		response.setId(request.getId());
		response.setHospCode(request.getHospCode());
		response.setResult(PatientServiceProto.CreatePatientResponse.Result.INTERNAL_ERROR);
		
		PatientModRequest patientModRequest = new PatientModRequest();
		patientModRequest.toRequest(request.getProfile().getBunho(), request.getProfile(), request.getPublicInsuranceList(), request.getPrivateInsuranceList(), request.getModKey());
		
		OrcaEnvInfo orcaEnvInfo = getOrcaInfo(request.getHospCode());
		patientModRequest.setOrcaEnvInfo(orcaEnvInfo);		
		
		PatientModResponse rp = patientModCommand.execute(patientModRequest);
		if(rp == null) {
			LOGGER.info("CALL ORCA API To Save Patient - RESPONSE = NULL");
			return response.build();
		}
		
		String newPatientCode = (rp.getPatientInformation() != null && !StringUtils.isEmpty(rp.getPatientInformation().getPatientId())) ? rp.getPatientInformation().getPatientId() : ""; 
		if (rp.getApiResult().equals(OrcaApiConfig.API_RESULT_SUCCESS.getValue())
				|| (!StringUtils.isEmpty(newPatientCode) && !OrcaApiConfig.PATIENT_CODE_CREATE_NEW.getValue().equals(newPatientCode)
						&& OrcaApiConfig.PATIENT_CODE_DEFAULT.getValue().equals(request.getProfile().getBunho()))) {
			response.setNewPatientCode(newPatientCode);
			response.setMessageCode(rp.getApiResult());
			response.setResult(PatientServiceProto.CreatePatientResponse.Result.SUCCESS);
		} else {
			response.setMessageCode(rp.getApiResult());
		}
		
		LOGGER.info("CALL ORCA API To Save Patient - API RESULT = " + rp.getApiResult() + " - " + rp.getApiResultMessage());
		return response.build();
	}

	@Override
	public PatientServiceProto.SaveExaminationResponse saveExamination(PatientServiceProto.SaveExaminationRequest request) throws Exception{
		PatientServiceProto.SaveExaminationResponse.Builder response = PatientServiceProto.SaveExaminationResponse .newBuilder();
		response.setId(request.getId());
		response.setHospCode(request.getHospCode());
		response.setResult(PatientServiceProto.SaveExaminationResponse.Result.INTERNAL_ERROR);
		
		AcceptModRequest acceptModRequest = new AcceptModRequest();
		acceptModRequest.toRequest(request.getExamInfo());
		
		OrcaEnvInfo orcaEnvInfo = getOrcaInfo(request.getHospCode());
		acceptModRequest.setOrcaEnvInfo(orcaEnvInfo);
		
		AcceptModResponse rp = acceptModCommand.execute(acceptModRequest);
		if(rp == null) {
			LOGGER.info("CALL ORCA API To Save Examination- RESPONSE = NULL");
			return response.build();
		}
		
		String apiResult = rp.getApiResult();
		response.setMessageCode(apiResult);		
		response.setMessageDetail(rp.getApiResultMessage());
		LOGGER.info("CALL ORCA API To Save Examination - API RESULT = " + apiResult + " - " + rp.getApiResultMessage());
		
		boolean isSuccess = OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W1.getValue().equals(apiResult)
				|| OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W2.getValue().equals(apiResult)
				|| OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W3.getValue().equals(apiResult)
				|| "17".equals(apiResult);
		
		if(isSuccess){
			response.setRefId(rp.getAcceptanceId() == null ? "" : rp.getAcceptanceId());
			response.setResult(PatientServiceProto.SaveExaminationResponse.Result.SUCCESS);
		} else {
			response.setResult(PatientServiceProto.SaveExaminationResponse.Result.FAIL);
		}
		
		return response.build();
	}
	
	@Override
	public BookingServiceProto.BookingExaminationResponse bookExamToExternalSystem(BookingServiceProto.BookingExaminationRequest request) throws Exception {
		LOGGER.info("PatientAdministrator : bookExamToExternalSystem : patient_code = " + request.getPatientCode());
		BookingServiceProto.BookingExaminationResponse.Builder response = BookingServiceProto.BookingExaminationResponse.newBuilder();
		AppointmentRequest appointmentRequest = new AppointmentRequest();
		appointmentRequest.toRequest(request);
		
		OrcaEnvInfo orcaEnvInfo = getOrcaInfo(request.getHospCode());
		appointmentRequest.setOrcaEnvInfo(orcaEnvInfo);
		AppointmentResponse rp = appointmentCommand.execute(appointmentRequest);
		
		if(rp == null){
			LOGGER.info("CALL ORCA API To Booking Examination- RESPONSE = NULL");
			response.setResult(false);
			return response.build();
		}
		
		String apiResult = rp.getApiResult();
		String action = request.getAction() == BookingServiceProto.BookingExaminationRequest.Action.BOOKING ? "Booking " : "Cancel Booking ";
		LOGGER.info("CALL ORCA API To " + action + "Examination- Api_Result = " + apiResult + ", Api_Result_Message = " + rp.getApiResultMessage());
		boolean isSuccess = OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W3.getValue().equals(apiResult)
				|| OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W4.getValue().equals(apiResult)
				|| OrcaApiConfig.API_ACCEPT_MOD_SUCCESS_W5.getValue().equals(apiResult)
				|| OrcaApiConfig.API_RESULT_SUCCESS.getValue().equals(apiResult);
		
		if(isSuccess){
			response.setResult(true);
			response.setDoctorCode(rp.getPhysicianCode());
			response.setDoctorName(rp.getPhysicianWholeName());
			response.setDepartmentName(rp.getDepartmentWholeName());
			response.setReservationCode(rp.getAppointmentId());
			response.setErrCode(apiResult);
			response.setReservationTime(rp.getAppointmentTime());
		} else {
			response.setResult(false);
			response.setErrCode(apiResult);
		}
		
		return response.build();
	}
	
	private OrcaEnvInfo getOrcaInfo(String gigwanCode) throws Exception {
        return systemAdministrator.findOrcaInfoByGigwanCode(gigwanCode);
    }
	
	public static class ListenerImpl extends AbstractRpcExtListener<PatientServiceProto.PatientEvent> {

		@Resource
		private PatientRpcService patientRpcService;

	    @Resource
	    private SystemAdministrator systemAdministrator;
		
	    @Resource
	    private PatientModCommand patientModCommand;
	    
	    @Resource
	    private AcceptModCommand acceptModCommand;

		protected ListenerImpl() {
			super(PatientServiceProto.PatientEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.PATIENT;
		}

		@Override
		public void handleEvent(PatientServiceProto.PatientEvent event) throws Exception {
			//System.out.println("event: " + event.getPatientCode());
		}

		@Override
		public Collection<PatientServiceProto.PatientEvent> invokeSubscribe(long eventId) throws Exception {
			// Do not need to subscribe PatientEvent here
			
			PatientServiceProto.SubscribePatientEventRequest request = PatientServiceProto.SubscribePatientEventRequest
					.newBuilder().setEventId(-1L).build();
			PatientServiceProto.SubscribePatientEventResponse response = patientRpcService.subscribePatient(request);
			if(response != null && PatientServiceProto.SubscribePatientEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if(isVerbose()) LOGGER.info("{} was successfully subscribed");
				return response.getEventsList();
			}
			
			return Collections.emptyList();
		}
	}

	@Override
	public GetMisSurveyLinkResponse getMisSurveyLink(GetMisSurveyLinkRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
