package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8013;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8013Repository extends JpaRepository<Nur8013, Long>, Nur8013RepositoryCustom {
}

