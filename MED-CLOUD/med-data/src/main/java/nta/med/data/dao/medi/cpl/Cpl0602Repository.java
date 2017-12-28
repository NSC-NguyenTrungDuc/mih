package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0602;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0602Repository extends JpaRepository<Cpl0602, Long>, Cpl0602RepositoryCustom {
}

