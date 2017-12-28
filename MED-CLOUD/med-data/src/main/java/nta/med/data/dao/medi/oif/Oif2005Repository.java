package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2005Repository extends JpaRepository<Oif2005, Long>, Oif2005RepositoryCustom {
}

