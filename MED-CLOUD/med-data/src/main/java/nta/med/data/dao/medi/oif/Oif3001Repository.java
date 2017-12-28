package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif3001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif3001Repository extends JpaRepository<Oif3001, Long>, Oif3001RepositoryCustom {
}

