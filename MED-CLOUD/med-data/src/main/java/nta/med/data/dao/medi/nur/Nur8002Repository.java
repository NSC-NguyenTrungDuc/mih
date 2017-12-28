package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8002Repository extends JpaRepository<Nur8002, Long>, Nur8002RepositoryCustom {
}

