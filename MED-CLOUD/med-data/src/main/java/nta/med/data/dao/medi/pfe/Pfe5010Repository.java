package nta.med.data.dao.medi.pfe;

import nta.med.core.domain.pfe.Pfe5010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe5010Repository extends JpaRepository<Pfe5010, Long>, Pfe5010RepositoryCustom {
}

