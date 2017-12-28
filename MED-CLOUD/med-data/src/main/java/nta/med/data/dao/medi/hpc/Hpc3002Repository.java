package nta.med.data.dao.medi.hpc;

import nta.med.core.domain.hpc.Hpc3002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Hpc3002Repository extends JpaRepository<Hpc3002, Long>, Hpc3002RepositoryCustom {
}

