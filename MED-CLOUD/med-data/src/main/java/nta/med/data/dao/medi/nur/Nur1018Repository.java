package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1018;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1018Repository extends JpaRepository<Nur1018, Long>, Nur1018RepositoryCustom {
}

