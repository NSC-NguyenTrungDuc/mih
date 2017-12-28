package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0201Repository extends JpaRepository<Oif0201, Long>, Oif0201RepositoryCustom {
}

