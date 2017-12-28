package nta.med.data.dao.medi.res;

import nta.med.core.domain.res.Res1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res1001Repository extends JpaRepository<Res1001, Long>, Res1001RepositoryCustom {
}

