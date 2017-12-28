package nta.med.data.mongo.medi;

import nta.med.core.domain.event.BookingEvent;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public interface BookingEventRepository extends CrudRepository<BookingEvent, Long> {

    List<BookingEvent> findByIdGreaterThan(long id);

    BookingEvent findFirstByOrderByIdDesc();

}
