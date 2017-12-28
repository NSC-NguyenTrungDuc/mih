package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl9999;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl9999Repository extends JpaRepository<Cpl9999, Long>, Cpl9999RepositoryCustom {
}

