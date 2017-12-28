package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt1001Repository extends JpaRepository<Xrt1001, Long>, Xrt1001RepositoryCustom {
}

