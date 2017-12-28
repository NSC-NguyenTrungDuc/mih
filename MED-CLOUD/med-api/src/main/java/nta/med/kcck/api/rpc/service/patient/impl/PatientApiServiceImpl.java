package nta.med.kcck.api.rpc.service.patient.impl;

import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.domain.event.PatientEvent;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.listener.AbstractListener;
import nta.med.core.utils.BeanUtils;
import nta.med.data.mongo.medi.PatientEventRepository;
import nta.med.kcck.api.adapter.NuroAdapter;
import nta.med.kcck.api.adapter.OcsoAdapter;
import nta.med.kcck.api.adapter.SystemAdapter;
import nta.med.kcck.api.rpc.RpcApiContext;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.*;
import nta.med.kcck.api.rpc.proto.PatientServiceProto.*;
import nta.med.kcck.api.rpc.service.AbstractRpcApiService;
import nta.med.kcck.api.rpc.service.patient.PatientApiService;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.annotation.Resource;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class PatientApiServiceImpl extends AbstractRpcApiService implements PatientApiService {
    private static final Log LOG = LogFactory.getLog(PatientApiServiceImpl.class);
    private PatientEventAdapter adapter = new PatientEventAdapter();
    private final RpcMessageParser parser;

    @Resource
    private PatientEventRepository eventRepository;

    @Resource
    private NuroAdapter nuroAdapter;

    @Resource
    private RpcApiContext context;
    
    @Resource
    private SystemAdapter systemAdapter;

    @Resource
    private OcsoAdapter ocsoAdapter;
    
    public PatientApiServiceImpl() {
        super(PatientServiceProto.class, PatientServiceProto.getDescriptor());
        parser = new RpcMessageParser(PatientServiceProto.class);
    }

    @Override
    public boolean isCompatible(String s) {
        return true;
    }

    @RpcService(name = "GetPatientRequest", authenticate = true)
    public GetPatientResponse getPatient(RpcApiSession session, GetPatientRequest request) {
        return systemAdapter.getPatient(session, request);
    }

    @RpcService(name = "SearchPatientRequest", authenticate = true)
    public PatientServiceProto.SearchPatientResponse searchPatient(RpcApiSession session, PatientServiceProto.SearchPatientRequest request) {
        return nuroAdapter.searchPatient(session, request);
    }

    @RpcService(name = "SyncPatientRequest", authenticate = true)
    public PatientServiceProto.SyncPatientResponse syncPatient(RpcApiSession session, PatientServiceProto.SyncPatientRequest request) {
    	return nuroAdapter.syncPatient(session, request);
    }

    @RpcService(name = "SyncExaminationRequest", authenticate = true)
    public PatientServiceProto.SyncExaminationResponse syncExamination(RpcApiSession session, PatientServiceProto.SyncExaminationRequest request) {
        return nuroAdapter.syncExamination(session, request);
    }

    @RpcService(name = "SyncReservationRequest", authenticate = true)
	public SyncReservationResponse syncReservation(RpcApiSession session, PatientServiceProto.SyncReservationRequest request) {
		return nuroAdapter.syncReservation(session, request);
	}
    
    @RpcService(name = "VerifyPatientAccountRequest", authenticate = true)
	public VerifyPatientAccountResponse verifyPatientAccount(RpcApiSession session, PatientServiceProto.VerifyPatientAccountRequest request) {
		return systemAdapter.verifyPatientAccount(session, request);
	}

    @RpcService(name = "GetPatientDiseaseRequest", authenticate = true)
	public GetPatientDiseaseResponse getPatientDisease(RpcApiSession session, PatientServiceProto.GetPatientDiseaseRequest request) {
		return ocsoAdapter.getPatientDisease(session, request);
	}

    @RpcService(name = "GetPatientMedicineRequest", authenticate = true)
	public GetPatientMedicineResponse getPatientMedicine(RpcApiSession session, PatientServiceProto.GetPatientMedicineRequest request) {
		return ocsoAdapter.getPatientMedicine(session, request);
	}
    
    @RpcService(name = "SubscribePatientEventRequest", authenticate = true)
    public PatientServiceProto.SubscribePatientEventResponse subscribePatient(RpcApiSession session, PatientServiceProto.SubscribePatientEventRequest request) {
        PatientServiceProto.SubscribePatientEventResponse.Builder r = PatientServiceProto.SubscribePatientEventResponse.newBuilder();
        r.setResult(PatientServiceProto.SubscribePatientEventResponse.Result.SUCCESS);

        if(request.hasEventId() && request.getEventId() > 0) {
            List<PatientEvent> lostEvents = eventRepository.findByIdGreaterThan(request.getEventId());
            for (PatientEvent event : lostEvents) {
                r.addEvents(toEvent(event));
            }
        }

        session.subscribePatient(session.getHospCode());
        return r.build();
    }

    @Override
    public PatientServiceProto.CreatePatientResponse createPatient(PatientServiceProto.CreatePatientRequest request) throws Exception {
        for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.CREATE_PATIENT)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }
        throw new ServiceUnavailableException();
    }

    @Override
	public SaveExaminationResponse saveExamination(SaveExaminationRequest request) throws Exception {
        for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.BOOK_EXAM)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }
        throw new ServiceUnavailableException();
	}

    @RpcService(name = "GetWaitingPatientRequest", authenticate = true)
    public GetWaitingPatientResponse getWaitingResponse(RpcApiSession session, GetWaitingPatientRequest request) throws Exception {
        return systemAdapter.getWaitingPatient(session, request);
    }

    private PatientServiceProto.PatientEvent toEvent(PatientEvent event) {
        PatientServiceProto.PatientEvent.Builder r = PatientServiceProto.PatientEvent.newBuilder()
                .setId(event.getId()).setTimestamp(event.getTimestamp())
                .setType("1122").setPatientCode("");

        if(event != null){
            BeanUtils.copyProperties(event, r, Language.JAPANESE.toString());
        }
        
        if(event.getAcceptInfo() != null){
            PatientModelProto.AcceptInformation.Builder acceptInformation = PatientModelProto.AcceptInformation.newBuilder();
            BeanUtils.copyProperties(event.getAcceptInfo(), acceptInformation, Language.JAPANESE.toString());
            r.setAcceptInfo(acceptInformation);
        }

        return r.build();
    }

    @RpcService(name = "SubscribeUserEventRequest", authenticate = true)
    public PatientServiceProto.SubscribeUserEventResponse subscribeUser(RpcApiSession session, PatientServiceProto.SubscribeUserEventRequest request) {
        PatientServiceProto.SubscribeUserEventResponse.Builder r = PatientServiceProto.SubscribeUserEventResponse.newBuilder();
        r.setResult(PatientServiceProto.SubscribeUserEventResponse.Result.SUCCESS);

        session.subscribePatient(session.getHospCode());
        return r.build();
    }


    @RpcService(name = "SyncAccountRequest", authenticate = true)
    public SyncAccountResponse syncAccount(RpcApiSession session, SyncAccountRequest request) {
        SyncAccountResponse.Builder response  =   SyncAccountResponse.newBuilder();
        for(RpcApiSession s : context.getSessions()) {
            PatientServiceProto.UserEvent event = request.getUserEvent();
            final Rpc.RpcMessage m = RpcMessageBuilder.build(event, Rpc.RpcMessage.Result.SUCCESS);
            if(m != null && s.hasSubscribedBooking(event.getHospitalCode())) async(null, null, "ON_USER_EVENT", () -> { s.send(m); });
        }
        response.setResult("ok");
        return response.build();
    }


    public PatientEventAdapter getAdapter() {
        return adapter;
    }

//    @Override
//    protected void doStart() throws Exception {
//        super.doStart();
//        ScheduledExecutorService service = Executors.newScheduledThreadPool(1);
//        NuroServiceProto.PatientEvent.Builder event = NuroServiceProto.PatientEvent.newBuilder()
//                .setHospCode("316");
//        service.scheduleAtFixedRate(() -> adapter.onEvent(event.setPatientCode(UUID.randomUUID().toString()).build()), 10l, 10l, TimeUnit.SECONDS);
//    }

    public class PatientEventAdapter extends AbstractListener<NuroServiceProto.PatientEvent> {

        @Override
        public void onEvent(NuroServiceProto.PatientEvent event) {
            LOG.info("---------PATIENT ON EVENT---------");
            for(RpcApiSession s : context.getSessions()) {
                LOG.info(String.format("ON_PATIENTS %s %s", event.getHospCode(), event.getPatientCode()));
                final Rpc.RpcMessage m = RpcMessageBuilder.build(toApiEvent(event), Rpc.RpcMessage.Result.SUCCESS);
                if(m != null && s.hasSubscribedPatient(event.getHospCode())) async(null, null, "ON_PATIENTS", () -> { s.send(m); });
            }
        }

        private PatientServiceProto.PatientEvent toApiEvent(NuroServiceProto.PatientEvent event) {
            PatientServiceProto.PatientEvent.Builder eventBuilder = PatientServiceProto.PatientEvent.newBuilder();
            eventBuilder.setId(event.getId()).setType("11").setTimestamp(event.getTimestamp());
            eventBuilder.setPatientCode(event.getPatientCode());
            eventBuilder.setHospCode(event.getHospCode());
            
            PatientModelProto.PatientProfile.Builder profileBuilder = PatientModelProto.PatientProfile.newBuilder();  
            BeanUtils.copyProperties(event.getPatientProfile(), profileBuilder, Language.JAPANESE.toString());
            eventBuilder.setProfile(profileBuilder.build());
	        
            List<NuroModelProto.NuroOUT0101U02GridBoheomInfo>  publicInsList = event.getPublicInsuranceList();
	        for (NuroModelProto.NuroOUT0101U02GridBoheomInfo info : publicInsList) {
				PatientModelProto.PublicInsurance.Builder item = PatientModelProto.PublicInsurance.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPublicInsurance(item.build());
			}
            
	        List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo>  privateInsList = event.getPrivateInsuranceList();
	        for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : privateInsList) {
				PatientModelProto.PrivateInsurance.Builder item = PatientModelProto.PrivateInsurance.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPrivateInsurance(item);
			}
	        
	        // sync disease
	        List<NuroModelProto.SyncDisease> diseaseList = event.getDiseaseInfoList();
	        for (NuroModelProto.SyncDisease syncDisease : diseaseList) {
	        	PatientModelProto.SyncDisease.Builder item = PatientModelProto.SyncDisease.newBuilder();
				BeanUtils.copyProperties(syncDisease, item, Language.JAPANESE.toString());
				eventBuilder.addDiseaseInfo(item);
			}
	        // sync prescription
	        List<NuroModelProto.SyncPrescription> prescriptionList = event.getPrescriptionInfoList();
	        for (NuroModelProto.SyncPrescription syncPrescription : prescriptionList) {
	        	PatientModelProto.SyncPrescription.Builder item = PatientModelProto.SyncPrescription.newBuilder();
				BeanUtils.copyProperties(syncPrescription, item, Language.JAPANESE.toString());
				eventBuilder.addPrescriptionInfo(item);
			}
	        // sync drug
	        List<NuroModelProto.SyncDrug> drugList = event.getDrugInfoList();
	        for (NuroModelProto.SyncDrug syncDrug : drugList) {
	        	PatientModelProto.SyncDrug.Builder item = PatientModelProto.SyncDrug.newBuilder();
				BeanUtils.copyProperties(syncDrug, item, Language.JAPANESE.toString());
				eventBuilder.addDrugInfo(item);
			}
	        // sync vitals
	        List<NuroModelProto.SyncHeight> patientHeights = event.getPatientHeightInfoList();
	        for (NuroModelProto.SyncHeight info : patientHeights) {
	        	PatientModelProto.SyncHeight.Builder item = PatientModelProto.SyncHeight.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientHeightInfo(item);
			}
	        
	        List<NuroModelProto.SyncWeight> patientWeights = event.getPatientWeightInfoList();
	        for (NuroModelProto.SyncWeight info : patientWeights) {
	        	PatientModelProto.SyncWeight.Builder item = PatientModelProto.SyncWeight.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientWeightInfo(item);
			}
	        
	        List<NuroModelProto.SyncTemperature> patientTemperatures = event.getPatientTemperatureInfoList();
	        for (NuroModelProto.SyncTemperature info : patientTemperatures) {
	        	PatientModelProto.SyncTemperature.Builder item = PatientModelProto.SyncTemperature.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientTemperatureInfo(item);
			}
	        
	        List<NuroModelProto.SyncHeartRate> patientHeartRates = event.getPatientHeartRateInfoList();
	        for (NuroModelProto.SyncHeartRate info : patientHeartRates) {
	        	PatientModelProto.SyncHeartRate.Builder item = PatientModelProto.SyncHeartRate.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientHeartRateInfo(item);
			}
	        
	        List<NuroModelProto.SyncRespirationRate> patientRespirationRates = event.getPatientRespirationRateInfoList();
	        for (NuroModelProto.SyncRespirationRate info : patientRespirationRates) {
	        	PatientModelProto.SyncRespirationRate.Builder item = PatientModelProto.SyncRespirationRate.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientRespirationRateInfo(item);
			}
	        
	        List<NuroModelProto.SyncBloodPressure> patientBloodPressures = event.getPatientBloodPressureInfoList();
	        for (NuroModelProto.SyncBloodPressure info : patientBloodPressures) {
	        	PatientModelProto.SyncBloodPressure.Builder item = PatientModelProto.SyncBloodPressure.newBuilder();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				eventBuilder.addPatientBloodPressureInfo(item);
			}
	        
	        PatientModelProto.AcceptInformation.Builder examInfo = PatientModelProto.AcceptInformation.newBuilder(); 
	        BeanUtils.copyProperties(event.getAcceptInfo(), examInfo, Language.JAPANESE.toString());
	        examInfo.setPhysicianCode(event.getAcceptInfo().getDoctorCode());
            examInfo.setReservationCode(event.getAcceptInfo().getPkout1001());
            examInfo.setAcceptanceDate(event.getAcceptInfo().getComingDate());
            examInfo.setAcceptanceTime(event.getAcceptInfo().getReceptionTime());
	        eventBuilder.setAcceptInfo(examInfo.build());
	        
	        return eventBuilder.build();
        }
    }

}
