package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl5003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl5003Repository extends JpaRepository<Cpl5003, Long>, Cpl5003RepositoryCustom {
}

