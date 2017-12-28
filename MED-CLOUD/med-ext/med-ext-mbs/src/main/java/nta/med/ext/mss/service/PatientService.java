package nta.med.ext.mss.service;

import java.util.List;

import nta.med.data.model.mss.ReservationOnlineInfo;
import nta.med.ext.mss.model.PatientBasicInfoModel;
import nta.med.ext.mss.model.PatientInfoModel;
import nta.med.ext.mss.model.ReservationModel;

/**
 * @author DEV-TiepNM
 */
public interface PatientService {

    public PatientBasicInfoModel getPatient(String hospCode, String patientCode);

    public List<ReservationModel> getWaitingPatient(String examinationDate, String examinationSituation, String departmentCode,
                                                    String doctorCode, String hospCode, String locale,List<String> patientCodes);

    public ReservationModel saveCallingId(String reservationCode,String callingId, String hospitalId);
    
    public ReservationModel updateCallingId(String reservationCode,String callingId, String hospitalCode);
    
    public PatientInfoModel getPatientInfo(String hospitalId, String patientCode);
    
    public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(String hospId, List<String> reservationCodes);
    
    public List<PatientInfoModel> findPatientInfoByProfileId(String profileId);
}
