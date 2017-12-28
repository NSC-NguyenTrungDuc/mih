package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2004Repository extends JpaRepository<Oif2004, Long>, Oif2004RepositoryCustom {
}

