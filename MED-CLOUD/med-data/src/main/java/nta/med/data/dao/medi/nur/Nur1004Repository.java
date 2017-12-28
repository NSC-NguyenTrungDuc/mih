package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1004Repository extends JpaRepository<Nur1004, Long>, Nur1004RepositoryCustom {
}

