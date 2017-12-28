package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0123;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0123Repository extends JpaRepository<Drg0123, Long>, Drg0123RepositoryCustom {
}
