package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0281;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0281Repository extends JpaRepository<Bas0281, Long>, Bas0281RepositoryCustom {
}

