package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0613;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0613Repository extends JpaRepository<Cpl0613, Long>, Cpl0613RepositoryCustom {
}

