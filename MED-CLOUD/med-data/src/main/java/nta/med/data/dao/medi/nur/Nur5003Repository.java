package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5003Repository extends JpaRepository<Nur5003, Long>, Nur5003RepositoryCustom {
}

