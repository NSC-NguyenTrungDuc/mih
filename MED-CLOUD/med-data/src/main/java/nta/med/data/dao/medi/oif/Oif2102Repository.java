package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2102Repository extends JpaRepository<Oif2102, Long>, Oif2102RepositoryCustom {
}

