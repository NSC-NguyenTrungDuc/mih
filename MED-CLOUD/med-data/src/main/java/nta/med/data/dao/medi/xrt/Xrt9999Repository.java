package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt9999;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt9999Repository extends JpaRepository<Xrt9999, Long>, Xrt9999RepositoryCustom {
}

