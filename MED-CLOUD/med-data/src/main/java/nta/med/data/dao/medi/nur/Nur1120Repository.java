package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1120;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1120Repository extends JpaRepository<Nur1120, Long>, Nur1120RepositoryCustom {
}

