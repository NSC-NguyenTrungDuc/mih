package nta.med.data.mongo.emr;

import nta.med.core.domain.emr.ExaminationPatient;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface ExaminationPatientRepository extends CrudRepository<ExaminationPatient, String> {
}
