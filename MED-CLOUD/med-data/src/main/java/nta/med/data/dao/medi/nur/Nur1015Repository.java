package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1015;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1015Repository extends JpaRepository<Nur1015, Long>, Nur1015RepositoryCustom {
}

