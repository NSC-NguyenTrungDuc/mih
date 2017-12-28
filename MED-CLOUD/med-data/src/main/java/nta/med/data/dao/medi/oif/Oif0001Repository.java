package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0001Repository extends JpaRepository<Oif0001, Long>, Oif0001RepositoryCustom {
}

