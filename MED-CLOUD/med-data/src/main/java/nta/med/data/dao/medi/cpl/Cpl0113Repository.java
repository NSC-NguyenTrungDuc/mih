package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0113;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0113Repository extends JpaRepository<Cpl0113, Long>, Cpl0113RepositoryCustom {
}

