package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif3002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif3002Repository extends JpaRepository<Oif3002, Long>, Oif3002RepositoryCustom {
}

