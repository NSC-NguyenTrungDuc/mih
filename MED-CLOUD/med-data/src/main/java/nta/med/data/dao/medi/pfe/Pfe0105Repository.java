package nta.med.data.dao.medi.pfe;

import nta.med.core.domain.pfe.Pfe0105;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe0105Repository extends JpaRepository<Pfe0105, Long>, Pfe0105RepositoryCustom {
}

