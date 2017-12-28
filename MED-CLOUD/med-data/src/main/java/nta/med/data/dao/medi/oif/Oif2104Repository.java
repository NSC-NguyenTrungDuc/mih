package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2104;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2104Repository extends JpaRepository<Oif2104, Long>, Oif2104RepositoryCustom {
}

