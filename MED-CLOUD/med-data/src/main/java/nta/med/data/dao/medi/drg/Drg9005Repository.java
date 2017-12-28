package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg9005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9005Repository extends JpaRepository<Drg9005, Long>, Drg9005RepositoryCustom {
}

