package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0107;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0107Repository extends JpaRepository<Nur0107, Long>, Nur0107RepositoryCustom {
}

