package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0402;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0402Repository extends JpaRepository<Bas0402, Long>, Bas0402RepositoryCustom {
}

