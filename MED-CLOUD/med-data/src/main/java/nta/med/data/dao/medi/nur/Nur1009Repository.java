package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1009;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1009Repository extends JpaRepository<Nur1009, Long>, Nur1009RepositoryCustom {
}
