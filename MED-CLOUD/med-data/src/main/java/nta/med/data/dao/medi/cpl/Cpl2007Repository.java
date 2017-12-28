package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl2007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl2007Repository extends JpaRepository<Cpl2007, Long>, Cpl2007RepositoryCustom {
}

