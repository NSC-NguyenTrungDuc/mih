package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0155;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0155Repository extends JpaRepository<Cpl0155, Long>, Cpl0155RepositoryCustom {
	@Query("SELECT DISTINCT 'Y' FROM Cpl0155 A WHERE A.hospCode = :hospCode AND A.resultCodeGubun = :resultCodeGubun")
	public String checkExitCPL3020U02FwkResult(@Param("hospCode") String hospCode,@Param("resultCodeGubun") String resultCodeGubun);
	
}

