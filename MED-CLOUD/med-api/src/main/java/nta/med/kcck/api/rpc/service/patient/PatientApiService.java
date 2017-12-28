package nta.med.kcck.api.rpc.service.patient;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;

/**
 * @author dainguyen.
 */
public interface PatientApiService {

    PatientServiceProto.GetPatientResponse getPatient(RpcApiSession session, PatientServiceProto.GetPatientRequest request);

    PatientServiceProto.SearchPatientResponse searchPatient(RpcApiSession session, PatientServiceProto.SearchPatientRequest request);

    PatientServiceProto.SyncPatientResponse syncPatient(RpcApiSession session, PatientServiceProto.SyncPatientRequest request);

    PatientServiceProto.SyncExaminationResponse syncExamination(RpcApiSession session, PatientServiceProto.SyncExaminationRequest request);

    PatientServiceProto.SyncReservationResponse syncReservation(RpcApiSession session, PatientServiceProto.SyncReservationRequest request);
    
    PatientServiceProto.SubscribePatientEventResponse subscribePatient(RpcApiSession session, PatientServiceProto.SubscribePatientEventRequest request);
    
    PatientServiceProto.VerifyPatientAccountResponse verifyPatientAccount(RpcApiSession session, PatientServiceProto.VerifyPatientAccountRequest request);
    
    PatientServiceProto.GetPatientDiseaseResponse getPatientDisease(RpcApiSession session, PatientServiceProto.GetPatientDiseaseRequest request);
    
    PatientServiceProto.GetPatientMedicineResponse getPatientMedicine(RpcApiSession session, PatientServiceProto.GetPatientMedicineRequest request);
    
    PatientServiceProto.CreatePatientResponse createPatient(PatientServiceProto.CreatePatientRequest request) throws Exception;

    PatientServiceProto.SaveExaminationResponse saveExamination(PatientServiceProto.SaveExaminationRequest request) throws Exception;


    PatientServiceProto.GetWaitingPatientResponse getWaitingResponse(RpcApiSession session, PatientServiceProto.GetWaitingPatientRequest request) throws Exception;

    public PatientServiceProto.SubscribeUserEventResponse subscribeUser(RpcApiSession session, PatientServiceProto.SubscribeUserEventRequest request);
}
