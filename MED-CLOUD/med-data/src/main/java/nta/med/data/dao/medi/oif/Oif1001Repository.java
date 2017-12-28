package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1001Repository extends JpaRepository<Oif1001, Long>, Oif1001RepositoryCustom {
}

