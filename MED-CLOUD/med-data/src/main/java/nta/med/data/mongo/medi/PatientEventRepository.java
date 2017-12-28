package nta.med.data.mongo.medi;

import nta.med.core.domain.event.PatientEvent;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public interface PatientEventRepository extends CrudRepository<PatientEvent, Long> {

    List<PatientEvent> findByIdGreaterThan(long id);

    PatientEvent findFirstByOrderByIdDesc();

}
