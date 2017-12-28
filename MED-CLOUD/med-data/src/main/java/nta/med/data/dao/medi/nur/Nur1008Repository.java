package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1008;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1008Repository extends JpaRepository<Nur1008, Long>, Nur1008RepositoryCustom {
}

