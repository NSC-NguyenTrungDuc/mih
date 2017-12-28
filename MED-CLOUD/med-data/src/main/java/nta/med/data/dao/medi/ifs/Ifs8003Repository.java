package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8003Repository extends JpaRepository<Ifs8003, Long>, Ifs8003RepositoryCustom {
}

