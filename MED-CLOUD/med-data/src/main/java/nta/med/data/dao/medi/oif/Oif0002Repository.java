package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0002Repository extends JpaRepository<Oif0002, Long>, Oif0002RepositoryCustom {
}

