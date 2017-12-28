package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1006Repository extends JpaRepository<Nur1006, Long>, Nur1006RepositoryCustom {
}

