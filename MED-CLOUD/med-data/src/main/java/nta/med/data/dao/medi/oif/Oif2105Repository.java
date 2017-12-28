package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2105;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2105Repository extends JpaRepository<Oif2105, Long>, Oif2105RepositoryCustom {
}

