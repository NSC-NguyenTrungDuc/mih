package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0105;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0105Repository extends JpaRepository<Cpl0105, Long>, Cpl0105RepositoryCustom {
}

