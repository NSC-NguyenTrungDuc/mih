package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1005Repository extends JpaRepository<Nur1005, Long>, Nur1005RepositoryCustom {
}

