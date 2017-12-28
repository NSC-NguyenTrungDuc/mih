package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur2001Repository extends JpaRepository<Nur2001, Long>, Nur2001RepositoryCustom {
}

