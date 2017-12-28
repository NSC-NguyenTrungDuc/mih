package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1011Repository extends JpaRepository<Nur1011, Long>, Nur1011RepositoryCustom {
}

