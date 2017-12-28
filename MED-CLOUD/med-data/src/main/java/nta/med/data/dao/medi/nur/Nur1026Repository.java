package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1026;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1026Repository extends JpaRepository<Nur1026, Long>, Nur1026RepositoryCustom {
}

