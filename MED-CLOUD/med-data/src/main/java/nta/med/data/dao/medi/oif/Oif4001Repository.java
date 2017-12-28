package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif4001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif4001Repository extends JpaRepository<Oif4001, Long>, Oif4001RepositoryCustom {
}

