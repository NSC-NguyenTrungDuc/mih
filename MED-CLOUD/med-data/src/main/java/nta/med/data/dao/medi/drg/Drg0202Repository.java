package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0202;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0202Repository extends JpaRepository<Drg0202, Long>, Drg0202RepositoryCustom {
}

