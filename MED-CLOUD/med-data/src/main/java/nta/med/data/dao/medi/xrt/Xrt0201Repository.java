package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0201Repository extends JpaRepository<Xrt0201, Long>, Xrt0201RepositoryCustom {
}

