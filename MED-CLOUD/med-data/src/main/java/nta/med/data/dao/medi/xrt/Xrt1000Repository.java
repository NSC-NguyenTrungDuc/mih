package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt1000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt1000Repository extends JpaRepository<Xrt1000, Long>, Xrt1000RepositoryCustom {
}

