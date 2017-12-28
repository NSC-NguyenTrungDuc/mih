package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0902;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0902Repository extends JpaRepository<Drg0902, Long>, Drg0902RepositoryCustom {
}

