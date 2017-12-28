package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl2006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl2006Repository extends JpaRepository<Cpl2006, Long>, Cpl2006RepositoryCustom {
}

