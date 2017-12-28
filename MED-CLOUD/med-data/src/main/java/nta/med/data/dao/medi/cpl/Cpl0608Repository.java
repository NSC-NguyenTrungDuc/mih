package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0608;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0608Repository extends JpaRepository<Cpl0608, Long>, Cpl0608RepositoryCustom {
}

