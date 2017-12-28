package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6002Repository extends JpaRepository<Nur6002, Long>, Nur6002RepositoryCustom {
}

