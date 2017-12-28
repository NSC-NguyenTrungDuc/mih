package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3013;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3013Repository extends JpaRepository<Ifs3013, Long>, Ifs3013RepositoryCustom {
}

