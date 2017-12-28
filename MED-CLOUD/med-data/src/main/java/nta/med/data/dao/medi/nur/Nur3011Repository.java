package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur3011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur3011Repository extends JpaRepository<Nur3011, Long>, Nur3011RepositoryCustom {
}

