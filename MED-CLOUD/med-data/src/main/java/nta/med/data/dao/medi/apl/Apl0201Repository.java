package nta.med.data.dao.medi.apl;

import nta.med.core.domain.apl.Apl0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Apl0201Repository extends JpaRepository<Apl0201, Long>, Apl0201RepositoryCustom {
}

