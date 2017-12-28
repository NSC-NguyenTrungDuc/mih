package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6003Repository extends JpaRepository<Nur6003, Long>, Nur6003RepositoryCustom {
}

