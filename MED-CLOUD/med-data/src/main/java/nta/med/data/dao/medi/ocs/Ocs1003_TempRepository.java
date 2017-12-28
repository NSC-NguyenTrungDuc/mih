package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.ocs.Ocs1003_Temp;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author DEV-TiepNM
 */
@Repository
public interface Ocs1003_TempRepository extends JpaRepository<Ocs1003_Temp, Long>, Ocs1003_TempRepositoryCustom {
    public void callProcedureInsertOcs1003();
}
