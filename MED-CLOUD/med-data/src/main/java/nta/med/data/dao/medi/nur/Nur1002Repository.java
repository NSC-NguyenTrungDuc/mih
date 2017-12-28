package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1002Repository extends JpaRepository<Nur1002, Long>, Nur1002RepositoryCustom {
}

