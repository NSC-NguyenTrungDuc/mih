package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1007Repository extends JpaRepository<Nur1007, Long>, Nur1007RepositoryCustom {
}

