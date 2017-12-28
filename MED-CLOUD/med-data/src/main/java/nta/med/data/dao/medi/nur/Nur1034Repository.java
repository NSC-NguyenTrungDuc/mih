package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1034;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1034Repository extends JpaRepository<Nur1034, Long>, Nur1034RepositoryCustom {
}

