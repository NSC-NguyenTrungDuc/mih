package nta.med.data.dao.medi.jis;

import nta.med.core.domain.jis.Jiscode;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface JiscodeRepository extends JpaRepository<Jiscode, Long>, JiscodeRepositoryCustom {
}

