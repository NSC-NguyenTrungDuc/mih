package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8001Repository extends JpaRepository<Ifs8001, Long>, Ifs8001RepositoryCustom {
}

