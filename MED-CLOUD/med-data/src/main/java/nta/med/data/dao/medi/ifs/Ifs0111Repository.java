package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs0111;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0111Repository extends JpaRepository<Ifs0111, Long>, Ifs0111RepositoryCustom {
}

