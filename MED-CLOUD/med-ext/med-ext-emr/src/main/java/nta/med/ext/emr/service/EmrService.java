package nta.med.ext.emr.service;

import nta.med.core.domain.emr.ExaminationHistory;
import nta.med.core.domain.emr.ExaminationItemVo;
import nta.med.core.domain.emr.ExaminationPatient;
import nta.med.ext.emr.model.EmrRecordModel;
import nta.med.ext.emr.model.HistoryListModel;
import nta.med.ext.emr.model.PatientModel;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface EmrService {

    PatientModel findPatient(String hospCode, String patientId);

    PatientModel savePatient(PatientModel patient);

    ExaminationPatient findEmrByID(String hospCode, String patientId);

    ExaminationPatient saveAll(ExaminationPatient examPatient);

    void updateExamination(String hospCode, String patientId, List<ExaminationItemVo> exams);

    List<HistoryListModel> findAllHistories(String hospCode, String patientId);

    ExaminationHistory findHistoryDetail(String hospCode, String patientId, String revision);
    
    EmrRecordModel findEmrRecordByPatientCodeAndHospCode(String patientCode, String hospCode);
}
