package nta.med.data.dao.medi.inj;

import nta.med.core.domain.inj.Inj0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj0201Repository extends JpaRepository<Inj0201, Long>, Inj0201RepositoryCustom {
}

