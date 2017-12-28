package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur2005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur2005Repository extends JpaRepository<Nur2005, Long>, Nur2005RepositoryCustom {
}

