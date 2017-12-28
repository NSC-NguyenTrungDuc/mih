package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl1000;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl1000Repository extends JpaRepository<Cpl1000, Long>, Cpl1000RepositoryCustom {
	
	@Query("SELECT IFNULL(MAX(pkcpl1000), 0) + 1 FROM Cpl1000 WHERE hospCode = :f_hosp_code")
	public String checkCPL3010U00BtnUrineClick(@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("UPDATE Cpl1000 SET updId = :f_user_id, updDate = :f_sys_date, urineRyang  = IFNULL(:f_urine_ryang,'0') "
			+ ", stabilityYn = :f_stability_yn WHERE hospCode = :f_hosp_code AND specimenSer = :f_specimen_ser")
	public Integer updateCPL3010U00Execute(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_urine_ryang") String urineRyang,
			@Param("f_stability_yn") String stabilityYn,
			@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
}

