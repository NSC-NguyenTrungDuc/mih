package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0202;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0202Repository extends JpaRepository<Ocs0202, Long>, Ocs0202RepositoryCustom {
}

