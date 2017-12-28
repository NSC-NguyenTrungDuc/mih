package nta.med.data.dao.medi.cht;

import nta.med.core.domain.cht.Cht0115;
import nta.med.core.domain.cht.Cht0115S;
import nta.med.core.domain.inp.Inp0106;
import nta.med.data.dao.medi.CacheRepository;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author DEV-TiepNM
 */
@Repository
public interface Cht0115SRepository extends JpaRepository<Cht0115S, Long>, Cht0115SRepositoryCustom {
}
