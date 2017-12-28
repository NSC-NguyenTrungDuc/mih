package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl9000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl9000Repository extends JpaRepository<Cpl9000, Long>, Cpl9000RepositoryCustom {
}

