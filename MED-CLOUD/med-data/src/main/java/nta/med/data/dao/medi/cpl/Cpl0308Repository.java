package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0308;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0308Repository extends JpaRepository<Cpl0308, Long>, Cpl0308RepositoryCustom {
}

