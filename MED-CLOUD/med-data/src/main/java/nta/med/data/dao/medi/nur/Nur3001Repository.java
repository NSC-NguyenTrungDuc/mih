package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur3001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur3001Repository extends JpaRepository<Nur3001, Long>, Nur3001RepositoryCustom {
}

