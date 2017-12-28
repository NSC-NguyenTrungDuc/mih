package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1104;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1104Repository extends JpaRepository<Oif1104, Long>, Oif1104RepositoryCustom {
}

