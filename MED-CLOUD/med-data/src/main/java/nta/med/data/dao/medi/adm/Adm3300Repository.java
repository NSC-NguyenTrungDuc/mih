package nta.med.data.dao.medi.adm;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.adm.Adm3300;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3300Repository extends JpaRepository<Adm3300, Long>, Adm3300RepositoryCustom {
	@Query("SELECT a FROM Adm3300 a WHERE a.hospCode  = :hospCode AND a.ipAddr = :ipAddr")
	public List<Adm3300> findByIpAddr(@Param("hospCode") String hospCode, @Param("ipAddr") String ipAddr);
	
	@Modifying
	@Query("UPDATE Adm3300 SET userId = :userId, upTime = :upTime, bPrintName = :bPrintName "
       +" WHERE hospCode  = :hospCode AND ipAddr = :ipAddr ")
	public Integer updateAdm3300(@Param("hospCode") String hospCode, @Param("userId") String userId,
			@Param("upTime") Date upTime,
			@Param("bPrintName") String bPrintName,
			@Param("ipAddr") String ipAddr);
	
//	@Query(" SELECT TRIM(CONCAT('TRM',LPAD(CAST(SUBSTR(IFNULL(MAX(trmId),'TRM000'),4,3))+1,3,'0'))) FROM Adm3300 "
//          +" WHERE hospCode = :hospCode ")
//	public String getNexTrmId(@Param("hospCode") String hospCode);
	
	//@Query(" SELECT gwaRoom FROM Adm3300 WHERE hospCode = :f_hosp_code AND ipAddr = :f_ip_addr ")
	//public String getLayPrintName(@Param("f_hosp_code") String hospCode , @Param("f_ip_addr") String ipAddr);
}

