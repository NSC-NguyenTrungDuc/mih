package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2101Repository extends JpaRepository<Oif2101, Long>, Oif2101RepositoryCustom {
}

