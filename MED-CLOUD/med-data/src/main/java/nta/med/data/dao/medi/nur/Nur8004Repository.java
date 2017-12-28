package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8004Repository extends JpaRepository<Nur8004, Long>, Nur8004RepositoryCustom {
}

