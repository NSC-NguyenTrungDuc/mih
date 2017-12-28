package nta.med.data.dao.medi.res;

import nta.med.core.domain.res.Res0105;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0105Repository extends JpaRepository<Res0105, Long>, Res0105RepositoryCustom {
}

