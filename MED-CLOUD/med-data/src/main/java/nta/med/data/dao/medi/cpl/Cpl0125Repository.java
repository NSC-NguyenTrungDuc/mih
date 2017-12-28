package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0125;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0125Repository extends JpaRepository<Cpl0125, Long>, Cpl0125RepositoryCustom {
}

