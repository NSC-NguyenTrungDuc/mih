package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0241;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0241Repository extends JpaRepository<Bas0241, Long>, Bas0241RepositoryCustom {
}

