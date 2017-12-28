package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1033;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1033Repository extends JpaRepository<Nur1033, Long>, Nur1033RepositoryCustom {
}

