package nta.med.ext.support.service.patient.impl;

import nta.med.common.remoting.ServiceExecutionException;
import nta.med.common.remoting.rpc.glossary.RpcListener;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.proto.PatientServiceProto.GetPatientDiseaseRequest;
import nta.med.ext.support.proto.PatientServiceProto.GetPatientDiseaseResponse;
import nta.med.ext.support.proto.PatientServiceProto.GetPatientMedicineRequest;
import nta.med.ext.support.proto.PatientServiceProto.GetPatientMedicineResponse;
import nta.med.ext.support.proto.PatientServiceProto.PatientEvent;
import nta.med.ext.support.proto.PatientServiceProto.SyncReservationRequest;
import nta.med.ext.support.proto.PatientServiceProto.SyncReservationResponse;
import nta.med.ext.support.proto.PatientServiceProto.VerifyPatientAccountRequest;
import nta.med.ext.support.proto.PatientServiceProto.VerifyPatientAccountResponse;
import nta.med.ext.support.rpc.RpcExtContext;
import nta.med.ext.support.rpc.RpcExtSession;
import nta.med.ext.support.service.AbstractRpcExtService;
import nta.med.ext.support.service.patient.PatientRpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * @author dainguyen.
 */
public class PatientRpcServiceImpl extends AbstractRpcExtService implements PatientRpcService {

    private static final Logger LOGGER = LoggerFactory.getLogger(PatientRpcServiceImpl.class);

    private RpcExtContext.Listener<PatientEvent> listener;

    private RpcExtContext.Listener<PatientServiceProto.UserEvent> userEventListener;

    private PatientRpcService.Service service;

    public PatientRpcServiceImpl() {
        super("api.patient", PatientServiceProto.class, PatientServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String version) {
        return true;
    }
    @RpcListener(name = "UserEvent")
    public void onUserEvent(RpcExtSession session, PatientServiceProto.UserEvent event) {
        if(userEventListener != null) try {
            userEventListener.onEvent(event);
        } catch (InterruptedException e) {
            LOGGER.warn("hospital event was interrupted, event = " + format(event));
        }
    }

    @RpcListener(name = "PatientEvent")
    public void onPatientEvent(RpcExtSession session, PatientEvent event) {
        if(listener != null) try {
            listener.onEvent(event);
        } catch (InterruptedException e) {
            LOGGER.warn("patient event was interrupted, event = " + format(event), e);
        }
    }

    @RpcService(name = "CreatePatientRequest")
    public PatientServiceProto.CreatePatientResponse createPatient(RpcExtSession session, PatientServiceProto.CreatePatientRequest request) {
        if(service != null) try {
            return service.createPatient(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke createPatient, request = " + format(request), e);
        }
        throw new ServiceExecutionException();
    }

    @RpcService(name = "SaveExaminationRequest")
    public PatientServiceProto.SaveExaminationResponse saveExamination(RpcExtSession session, PatientServiceProto.SaveExaminationRequest request){
    	if(service != null) try {
            return service.saveExamination(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke createPatient, request = " + format(request), e);
        }
    	
        throw new ServiceExecutionException();
    }
    
    public void setListener(RpcExtContext.Listener<PatientEvent> listener) {
        this.listener = listener;
    }

    public void setUserEventListener(RpcExtContext.Listener<PatientServiceProto.UserEvent> userEventListener) {
        this.userEventListener = userEventListener;
    }

    public void setService(Service service) {
        this.service = service;
    }

    @Override
    public PatientServiceProto.SearchPatientResponse searchPatient(PatientServiceProto.SearchPatientRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
    public PatientServiceProto.SyncPatientResponse syncPatient(PatientServiceProto.SyncPatientRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
    public PatientServiceProto.SyncExaminationResponse syncExamination(PatientServiceProto.SyncExaminationRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
	public SyncReservationResponse syncReservation(SyncReservationRequest request) {
    	return invoke(request, 10000L, true);
	}

    @Override
    public PatientServiceProto.SyncAccountResponse syncAccount(PatientServiceProto.SyncAccountRequest request) {
        return invoke(request, 10000L, true);
    }



    @Override
    public PatientServiceProto.SubscribePatientEventResponse subscribePatient(PatientServiceProto.SubscribePatientEventRequest request) {
        return invoke(request, 10000L, true);
    }

	@Override
	public VerifyPatientAccountResponse verifyPatientAccount(VerifyPatientAccountRequest request) {
		return invoke(request, 10000L, true);
	}
	
	@Override
	public GetPatientDiseaseResponse getPatientDisease(GetPatientDiseaseRequest request) {
		return invoke(request, 10000L, true);
	}

	@Override
	public GetPatientMedicineResponse getPatientMedicine(GetPatientMedicineRequest request) {
		return invoke(request, 10000L, true);
	}

    @Override
    public PatientServiceProto.GetPatientResponse getPatient(PatientServiceProto.GetPatientRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
    public PatientServiceProto.GetWaitingPatientResponse getWaitingPatient(PatientServiceProto.GetWaitingPatientRequest request) {
        return invoke(request, 10000L, true);
    }
    @Override
    public PatientServiceProto.SubscribeUserEventResponse subscribeUser(PatientServiceProto.SubscribeUserEventRequest request) {
        return invoke(request, 10000L, true);
    }

}
