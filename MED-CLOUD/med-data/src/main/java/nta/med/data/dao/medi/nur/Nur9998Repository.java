package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur9998;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur9998Repository extends JpaRepository<Nur9998, Long>, Nur9998RepositoryCustom {
}

