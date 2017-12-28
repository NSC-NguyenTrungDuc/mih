package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1002Repository extends JpaRepository<Oif1002, Long>, Oif1002RepositoryCustom {
}

