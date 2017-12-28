package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl5001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl5001Repository extends JpaRepository<Cpl5001, Long>, Cpl5001RepositoryCustom {
}

