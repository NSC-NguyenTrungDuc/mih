package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur3012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur3012Repository extends JpaRepository<Nur3012, Long>, Nur3012RepositoryCustom {
}

