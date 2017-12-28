package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7204;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7204Repository extends JpaRepository<Ifs7204, Long>, Ifs7204RepositoryCustom {
}

