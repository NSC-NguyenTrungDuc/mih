package nta.med.data.dao.medi.nrs;

import nta.med.core.domain.nrs.Nrs0110;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nrs0110Repository extends JpaRepository<Nrs0110, Long>, Nrs0110RepositoryCustom {
}

