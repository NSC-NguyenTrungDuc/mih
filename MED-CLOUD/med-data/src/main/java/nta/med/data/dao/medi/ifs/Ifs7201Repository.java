package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7201Repository extends JpaRepository<Ifs7201, Long>, Ifs7201RepositoryCustom {
}

