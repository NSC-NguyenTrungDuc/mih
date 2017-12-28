package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0201Repository extends JpaRepository<Nur0201, Long>, Nur0201RepositoryCustom {
}

