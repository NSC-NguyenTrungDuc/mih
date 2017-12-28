package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg5010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg5010Repository extends JpaRepository<Drg5010, Long>, Drg5010RepositoryCustom {
}

