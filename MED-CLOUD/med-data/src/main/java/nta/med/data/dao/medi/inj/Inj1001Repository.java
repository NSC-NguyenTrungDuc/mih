package nta.med.data.dao.medi.inj;

import nta.med.core.domain.inj.Inj1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj1001Repository extends JpaRepository<Inj1001, Long>, Inj1001RepositoryCustom {
}

