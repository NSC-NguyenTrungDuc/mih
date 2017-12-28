package nta.med.data.dao.medi.hpc;

import nta.med.core.domain.hpc.Hpc1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Hpc1001Repository extends JpaRepository<Hpc1001, Long>, Hpc1001RepositoryCustom {
}

