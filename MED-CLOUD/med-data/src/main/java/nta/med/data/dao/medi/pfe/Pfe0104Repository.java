package nta.med.data.dao.medi.pfe;

import nta.med.core.domain.pfe.Pfe0104;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe0104Repository extends JpaRepository<Pfe0104, Long>, Pfe0104RepositoryCustom {
}

