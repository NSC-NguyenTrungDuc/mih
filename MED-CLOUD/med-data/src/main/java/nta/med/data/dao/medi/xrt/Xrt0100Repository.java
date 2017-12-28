package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt0100;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0100Repository extends JpaRepository<Xrt0100, Long>, Xrt0100RepositoryCustom {
}

