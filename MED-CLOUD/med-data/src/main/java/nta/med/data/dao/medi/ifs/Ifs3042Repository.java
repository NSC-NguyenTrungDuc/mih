package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3042;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3042Repository extends JpaRepository<Ifs3042, Long>, Ifs3042RepositoryCustom {
}

