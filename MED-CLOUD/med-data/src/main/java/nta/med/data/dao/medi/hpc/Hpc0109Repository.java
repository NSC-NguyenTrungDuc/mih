package nta.med.data.dao.medi.hpc;

import nta.med.core.domain.hpc.Hpc0109;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Hpc0109Repository extends JpaRepository<Hpc0109, Long>, Hpc0109RepositoryCustom {
}

