package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0101Repository extends JpaRepository<Oif0101, Long>, Oif0101RepositoryCustom {
}

