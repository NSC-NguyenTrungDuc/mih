package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8001Repository extends JpaRepository<Nur8001, Long>, Nur8001RepositoryCustom {
}

