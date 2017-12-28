package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0355;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0355Repository extends JpaRepository<Bas0355, Long>, Bas0355RepositoryCustom {
}

