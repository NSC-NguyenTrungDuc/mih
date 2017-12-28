package nta.med.data.mongo.medi;

import nta.med.core.domain.event.HospitalEvent;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public interface HospitalEventRepository extends CrudRepository<HospitalEvent, Long> {

    List<HospitalEvent> findByIdGreaterThan(long id);

    HospitalEvent findFirstByOrderByIdDesc();

}
