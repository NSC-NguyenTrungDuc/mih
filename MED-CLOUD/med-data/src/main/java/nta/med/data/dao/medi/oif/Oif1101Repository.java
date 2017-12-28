package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1101Repository extends JpaRepository<Oif1101, Long>, Oif1101RepositoryCustom {
}

