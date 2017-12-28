package nta.med.data.dao.medi.scan;

import nta.med.core.domain.scan.Scan001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Scan001Repository extends JpaRepository<Scan001, Long>, Scan001RepositoryCustom {
}

