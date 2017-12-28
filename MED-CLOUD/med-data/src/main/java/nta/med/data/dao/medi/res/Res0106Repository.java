package nta.med.data.dao.medi.res;

import nta.med.core.domain.res.Res0106;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0106Repository extends JpaRepository<Res0106, Long>, Res0106RepositoryCustom {
}

