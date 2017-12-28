package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7304;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7304Repository extends JpaRepository<Ifs7304, Long>, Ifs7304RepositoryCustom {
}

