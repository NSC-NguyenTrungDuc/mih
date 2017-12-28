package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif4003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif4003Repository extends JpaRepository<Oif4003, Long>, Oif4003RepositoryCustom {
}

