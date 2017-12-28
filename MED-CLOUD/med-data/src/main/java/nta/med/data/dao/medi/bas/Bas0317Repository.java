package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0317;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0317Repository extends JpaRepository<Bas0317, Long>, Bas0317RepositoryCustom {
}

