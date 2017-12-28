package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8152;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8152Repository extends JpaRepository<Ifs8152, Long>, Ifs8152RepositoryCustom {
}

