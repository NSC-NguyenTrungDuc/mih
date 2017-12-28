package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1030;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1030Repository extends JpaRepository<Nur1030, Long>, Nur1030RepositoryCustom {
}

