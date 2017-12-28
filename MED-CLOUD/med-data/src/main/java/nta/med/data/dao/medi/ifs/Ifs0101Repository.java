package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs0101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0101Repository extends JpaRepository<Ifs0101, Long>, Ifs0101RepositoryCustom {
}

