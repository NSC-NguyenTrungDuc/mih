package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8023;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8023Repository extends JpaRepository<Nur8023, Long>, Nur8023RepositoryCustom {
}

