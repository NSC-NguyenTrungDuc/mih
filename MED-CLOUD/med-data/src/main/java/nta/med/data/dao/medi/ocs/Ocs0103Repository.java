package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs0103;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0103Repository extends JpaRepository<Ocs0103, Long>, Ocs0103RepositoryCustom {
	@Query("SELECT hangmogName FROM Ocs0103 WHERE hospCode = :f_hosp_code AND hangmogCode = :f_code AND ( jundalPartOut = :f_code2 OR jundalPartInp = :f_code2)")
	public String getOCS0311U00InitializeLayHangmogCode(@Param("f_hosp_code") String hospCode,@Param("f_code") String code,@Param("f_code2") String code2 );
	
	@Query(" SELECT jaeryoCode FROM Ocs0103 WHERE hangmogCode = :f_jaeryo_code AND hospCode = :f_hosp_code ")
	public String getOJaeryoCodeOCS0208Q01(@Param("f_hosp_code") String hospCode,@Param("f_jaeryo_code") String jaeryoCode);

	@Query(" SELECT yjCode FROM Ocs0103 WHERE hangmogCode = :hangmogCode and hospCode = :f_hosp_code ")
	public List<String> getYjCode(@Param("hangmogCode") String hangmogCode, @Param("f_hosp_code") String hospCode);

	@Query("SELECT DISTINCT 'Y' FROM Ocs0103 WHERE hospCode = :f_hosp_code "
			+ " AND ((jundalPartOut = :f_jundal_part AND reserYnOut = 'Y' ) "
			+ " OR (jundalPartInp = :f_jundal_part AND reserYnInp = 'Y'))")
	public String getLayDupOCS0103(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_part") String jundalPart);
	
	@Query("SELECT 'X' FROM Ocs0103 WHERE hangmogNameInx LIKE :hangmogNameInx ")
	public List<String> checkHangmogNameInx(@Param("hangmogNameInx") String hangmogNameInx);
	
	@Query("SELECT 'Y' FROM Ocs0103 WHERE hospCode = :f_hosp_code AND sgCode = :f_sg_code")
	public String getYFromOCS0103ItemInfo(@Param("f_hosp_code") String hospCode,
			@Param("f_sg_code") String sgCode);
	
	@Query("SELECT DISTINCT 'Y' FROM Ocs0103  WHERE hospCode = :f_hosp_code AND hangmogCode = :f_hangmog_code AND startDate   = :f_start_date ")
	public String getYOCS0103U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_start_date") Date startDate);
	
	//END_DATE = TO_DATE(:f_start_date) - 1
	@Modifying
	@Query(" UPDATE Ocs0103  SET updDate = SYSDATE() , updId   = :f_user_id, "
			+ "endDate = :f_start_date_minus1 , modifyFlg = :modifyFlg "
			+ " WHERE hospCode = :f_hosp_code AND hangmogCode = :f_hangmog_code "
			+ "AND startDate  <= :f_start_date AND endDate     = STR_TO_DATE('99981231', '%Y%m%d') ")
	public Integer updateOCS0103U00(@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String updId,
			@Param("f_start_date_minus1") Date startDateMinus1,
			@Param("modifyFlg") String modifyFlg,
			@Param("f_start_date") Date startDate,
			@Param("f_hangmog_code") String hangmogCode);
	
	@Query("SELECT MAX(seq) + 1 FROM Ocs0103  WHERE hospCode = :f_hosp_code  AND slipCode = :f_slip_code ")
	public Double getMaxSeqOcs0103(@Param("f_hosp_code") String hospCode,@Param("f_slip_code") String slipCode);
	
	@Modifying
	@Query("DELETE FROM Ocs0103 WHERE hospCode  = :f_hosp_code  AND hangmogCode = :f_hangmog_code ")
	public Integer deleteOcs0103U00(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode);
	
	@Query("Select ocs FROM Ocs0103 ocs WHERE ocs.hospCode = :f_hosp_code AND ocs.hangmogCode = :f_hangmog_code AND ocs.startDate   = :f_start_date ")
	public List<Ocs0103> getListOcs0103ByHangmogCodeAndStartDate(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_start_date") Date startDate);
	
	@Query("SELECT hangmogName  FROM Ocs0103 WHERE hangmogCode = :f_code   AND hospCode    = :f_hosp_code")
	public List<String> getHangmogNameByHospCodeAndHangmogCode(@Param("f_hosp_code") String hospCode, @Param("f_code") String code);
	
//	@Query("SELECT hangmogCodeExt FROM Ocs0103 WHERE hospCode = :f_hosp_code AND hangmogCode = :f_hangmog_code")
//	public List<String> findHangmogCodeExt(@Param("f_hosp_code") String hospCode, @Param("f_hangmog_code") String hangmogCode);
	
	@Query("Select ocs FROM Ocs0103 ocs WHERE ocs.hospCode = :f_hosp_code AND ocs.hangmogCode = :f_hangmog_code ")
	public List<Ocs0103> getListOcs0103ByHangmogCode(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode);
	
	@Query("SELECT T FROM Ocs0103 T WHERE T.hospCode = :hospCode AND T.hangmogCode = :hangmogCode AND DATE(SYSDATE()) BETWEEN DATE(startDate) AND DATE(endDate)")
	public List<Ocs0103> findByHospCodeHangmogCodeSysDate(@Param("hospCode") String hospCode, @Param("hangmogCode") String hangmogCode);
	
}

