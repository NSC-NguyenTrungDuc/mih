package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0003Repository extends JpaRepository<Cpl0003, Long>, Cpl0003RepositoryCustom {
}

