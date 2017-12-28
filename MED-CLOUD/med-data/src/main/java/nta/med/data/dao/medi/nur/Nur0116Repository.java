package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0116;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0116Repository extends JpaRepository<Nur0116, Long>, Nur0116RepositoryCustom {
}

