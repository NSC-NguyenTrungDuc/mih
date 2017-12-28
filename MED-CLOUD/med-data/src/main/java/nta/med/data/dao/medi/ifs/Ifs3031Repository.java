package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3031;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3031Repository extends JpaRepository<Ifs3031, Long>, Ifs3031RepositoryCustom {
}

