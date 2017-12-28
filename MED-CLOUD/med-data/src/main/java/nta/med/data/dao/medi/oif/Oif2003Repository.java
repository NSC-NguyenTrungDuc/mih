package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2003Repository extends JpaRepository<Oif2003, Long>, Oif2003RepositoryCustom {
}

