package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0124;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0124Repository extends JpaRepository<Cpl0124, Long>, Cpl0124RepositoryCustom {
}

