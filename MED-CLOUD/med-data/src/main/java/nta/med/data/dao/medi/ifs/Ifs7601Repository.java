package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7601;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7601Repository extends JpaRepository<Ifs7601, Long>, Ifs7601RepositoryCustom {
}

