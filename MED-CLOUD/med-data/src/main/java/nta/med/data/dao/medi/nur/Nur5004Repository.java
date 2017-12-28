package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5004Repository extends JpaRepository<Nur5004, Long>, Nur5004RepositoryCustom {
}

