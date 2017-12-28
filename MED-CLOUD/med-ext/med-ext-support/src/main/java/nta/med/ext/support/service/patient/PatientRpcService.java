package nta.med.ext.support.service.patient;

import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientServiceProto;

/**
 * @author dainguyen.
 */
public interface PatientRpcService {


    PatientServiceProto.SearchPatientResponse searchPatient(PatientServiceProto.SearchPatientRequest request);

    PatientServiceProto.SyncPatientResponse syncPatient(PatientServiceProto.SyncPatientRequest request);

    PatientServiceProto.SyncExaminationResponse syncExamination(PatientServiceProto.SyncExaminationRequest request);

    PatientServiceProto.SubscribePatientEventResponse subscribePatient(PatientServiceProto.SubscribePatientEventRequest request);
    
    PatientServiceProto.VerifyPatientAccountResponse verifyPatientAccount(PatientServiceProto.VerifyPatientAccountRequest request);
    
    PatientServiceProto.GetPatientDiseaseResponse getPatientDisease(PatientServiceProto.GetPatientDiseaseRequest request);
    
    PatientServiceProto.GetPatientMedicineResponse getPatientMedicine(PatientServiceProto.GetPatientMedicineRequest request);

    PatientServiceProto.GetPatientResponse getPatient(PatientServiceProto.GetPatientRequest request);

    PatientServiceProto.GetWaitingPatientResponse getWaitingPatient(PatientServiceProto.GetWaitingPatientRequest request);

    PatientServiceProto.SubscribeUserEventResponse subscribeUser(PatientServiceProto.SubscribeUserEventRequest request);

    
    PatientServiceProto.SyncReservationResponse syncReservation(PatientServiceProto.SyncReservationRequest request);

    PatientServiceProto.SyncAccountResponse syncAccount(PatientServiceProto.SyncAccountRequest request);

    interface Service {
        PatientServiceProto.CreatePatientResponse createPatient(PatientServiceProto.CreatePatientRequest request) throws Exception;
        PatientServiceProto.SaveExaminationResponse saveExamination(PatientServiceProto.SaveExaminationRequest request) throws Exception;
    }
}
