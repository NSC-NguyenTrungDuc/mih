package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp9999;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp9999Repository extends JpaRepository<Inp9999, Long>, Inp9999RepositoryCustom {
}

