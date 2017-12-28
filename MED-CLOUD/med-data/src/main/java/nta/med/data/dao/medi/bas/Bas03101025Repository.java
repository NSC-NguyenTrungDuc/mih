package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas03101025;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas03101025Repository extends JpaRepository<Bas03101025, Long>, Bas03101025RepositoryCustom {
}

