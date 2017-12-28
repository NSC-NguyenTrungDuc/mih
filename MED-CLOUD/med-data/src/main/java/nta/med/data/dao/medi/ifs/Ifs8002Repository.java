package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8002Repository extends JpaRepository<Ifs8002, Long>, Ifs8002RepositoryCustom {
}

