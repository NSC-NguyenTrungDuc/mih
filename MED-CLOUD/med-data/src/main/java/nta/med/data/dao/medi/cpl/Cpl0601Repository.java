package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0601;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0601Repository extends JpaRepository<Cpl0601, Long>, Cpl0601RepositoryCustom {
}

