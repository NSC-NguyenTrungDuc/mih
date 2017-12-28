package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1021;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1021Repository extends JpaRepository<Nur1021, Long>, Nur1021RepositoryCustom {
}

