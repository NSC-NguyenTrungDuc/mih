package nta.med.data.dao.medi.inj;

import nta.med.core.domain.inj.Inj2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj2001Repository extends JpaRepository<Inj2001, Long>, Inj2001RepositoryCustom {
}

