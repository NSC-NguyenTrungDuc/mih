package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0110;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0110Repository extends JpaRepository<Cpl0110, Long>, Cpl0110RepositoryCustom {
}

