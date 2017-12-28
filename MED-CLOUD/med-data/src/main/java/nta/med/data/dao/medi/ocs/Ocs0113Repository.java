package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0113;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0113Repository extends JpaRepository<Ocs0113, Long>, Ocs0113RepositoryCustom {
	@Modifying
	@Query("        UPDATE Ocs0113                            "
	     + "          SET updId        = :updId     ,         " 
	     + "                  updDate      = SYSDATE() ,      "
	     + "                  seq           = :seq ,          "
	     + "                  defaultYn    = :defaultYn       "
	     + "        WHERE hangmogCode  = :hangmogCode         "
	     + "          AND specimenCode = :specimenCode        "  
	     + "          AND hospCode     = :hospCode            ")
	public Integer updateOcs0113TransactionModified(
			@Param("updId") String updId,
			@Param("seq") Double seq,
			@Param("defaultYn") String defaultYn,
			@Param("hangmogCode") String hangmogCode,
			@Param("specimenCode") String specimenCode,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("  DELETE Ocs0113                        "
			+"  WHERE hangmogCode  = :hangmogCode   "
			+"    AND specimenCode = :specimenCode  "
			+"    AND hospCode     = :hospCode      ")
	public Integer deleteOcs0113TransactionDeleted(
			@Param("hangmogCode") String hangmogCode,
			@Param("specimenCode") String specimenCode,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("DELETE FROM Ocs0113 WHERE hospCode = :f_hosp_code  AND hangmogCode  = :f_hangmog_code "
			+ " AND hangmogStartDate = :f_hangmog_start_date  AND specimenCode  = :f_specimen_code ")
	public Integer deleteOCS0103U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate,@Param("f_specimen_code") String specimenCode);
	
	@Modifying
	@Query("UPDATE Ocs0113  SET defaultYn  = :f_default_yn , updDate = SYSDATE()  , updId = :f_user_id "
			+ "WHERE hospCode = :f_hosp_code  AND hangmogCode  = :f_hangmog_code AND hangmogStartDate = :f_hangmog_start_date "
			+ " AND specimenCode   = :f_specimen_code")
	public Integer updateOCS0103U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_default_yn") String defaultYn,
			@Param("f_user_id") String updId, @Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate, @Param("f_specimen_code") String specimenCode);
	
	@Query("SELECT MAX(A.seq) + 1 FROM Ocs0113 A WHERE A.hospCode   = :f_hosp_code "
			+ " AND A.hangmogStartDate  = :f_hangmog_start_date  AND A.hangmogCode  = :f_hangmog_code ")
	public Double getMaxSeqOcs0113(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_hangmog_code") String hangmogCode);
	
	@Query("SELECT 'Y' FROM Ocs0113 A  WHERE A.hospCode  = :f_hosp_code AND A.hangmogCode   = :f_hangmog_code "
			+ "  AND A.hangmogStartDate  = :f_hangmog_start_date  AND A.specimenCode    = :f_specimen_code ")
	public String getCheckYOcs0113(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate,@Param("f_specimen_code") String specimenCode);
}

