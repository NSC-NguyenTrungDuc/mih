package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0106;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0106Repository extends JpaRepository<Nur0106, Long>, Nur0106RepositoryCustom {
}

