package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1061;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1061Repository extends JpaRepository<Nur1061, Long>, Nur1061RepositoryCustom {
}

