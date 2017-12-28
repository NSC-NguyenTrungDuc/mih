package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0380;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0380Repository extends JpaRepository<Bas0380, Long>, Bas0380RepositoryCustom {
}

