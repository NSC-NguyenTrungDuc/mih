package nta.med.data.dao.medi.res;

import nta.med.core.domain.res.Res0101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0101Repository extends JpaRepository<Res0101, Long>, Res0101RepositoryCustom {
}

