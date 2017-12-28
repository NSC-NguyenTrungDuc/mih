package nta.med.data.mongo.emr;

import nta.med.core.domain.emr.ExaminationHistory;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public interface ExaminationHistoryRepository extends CrudRepository<ExaminationHistory, String>, ExaminationHistoryRepositoryCustom {

    ExaminationHistory findByHospCodeAndPatientIdAndRevision(String hospCode, String patientId, Integer revision);

    List<ExaminationHistory> findByHospCodeAndPatientId(String hospCode, String patientId);
}
