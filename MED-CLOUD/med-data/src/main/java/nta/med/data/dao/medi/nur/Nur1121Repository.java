package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1121;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1121Repository extends JpaRepository<Nur1121, Long>, Nur1121RepositoryCustom {
}

