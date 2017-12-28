package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl9001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl9001Repository extends JpaRepository<Cpl9001, Long>, Cpl9001RepositoryCustom {
}

