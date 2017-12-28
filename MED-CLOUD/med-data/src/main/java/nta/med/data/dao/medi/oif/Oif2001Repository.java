package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2001Repository extends JpaRepository<Oif2001, Long>, Oif2001RepositoryCustom {
}

