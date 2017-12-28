package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1040;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1040Repository extends JpaRepository<Nur1040, Long>, Nur1040RepositoryCustom {
}

