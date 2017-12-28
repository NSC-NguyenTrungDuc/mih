package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1003Repository extends JpaRepository<Oif1003, Long>, Oif1003RepositoryCustom {
}

