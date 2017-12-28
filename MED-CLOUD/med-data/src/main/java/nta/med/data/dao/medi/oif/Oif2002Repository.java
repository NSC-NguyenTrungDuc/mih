package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2002Repository extends JpaRepository<Oif2002, Long>, Oif2002RepositoryCustom {
}

