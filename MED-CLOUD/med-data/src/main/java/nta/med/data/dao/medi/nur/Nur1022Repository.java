package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1022;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1022Repository extends JpaRepository<Nur1022, Long>, Nur1022RepositoryCustom {
}

