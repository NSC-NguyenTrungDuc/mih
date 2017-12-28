package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8004Repository extends JpaRepository<Ifs8004, Long>, Ifs8004RepositoryCustom {
}

