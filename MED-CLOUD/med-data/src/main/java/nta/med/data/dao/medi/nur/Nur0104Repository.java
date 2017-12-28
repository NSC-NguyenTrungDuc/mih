package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0104;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0104Repository extends JpaRepository<Nur0104, Long>, Nur0104RepositoryCustom {
}

