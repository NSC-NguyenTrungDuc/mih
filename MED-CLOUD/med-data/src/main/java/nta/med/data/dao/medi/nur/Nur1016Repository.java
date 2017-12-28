package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.nur.Nur1016;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1016Repository extends JpaRepository<Nur1016, Long>, Nur1016RepositoryCustom {
	@Query("SELECT DISTINCT 'Y'  FROM Nur1016 WHERE hospCode = :hospCode AND bunho = :bunho "
			+ " AND allergyGubun = :allergyGubun AND startDate = STR_TO_DATE(:startDate, '%Y/%m/%d') AND IFNULL(cancelYn, 'N') = 'N' ")
	public String getNuriValidationDuplicateCheck(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("allergyGubun") String allergyGubun,
			@Param("startDate") String startDate);
	
	@Modifying
	@Query("UPDATE Nur1016 SET updId = :updId, updDate = :updDate,  allergyInfo = :allergyInfo, endDate = :endDate, "
			+ " endSayu = :endSayu, inputText = :inputText, cancelYn = 'N' WHERE hospCode = :hospCode AND pknur1016 = :pknur1016 "
			+ " AND bunho = :bunho AND allergyGubun = :allergyGubun AND startDate = STR_TO_DATE(:startDate, '%Y/%m/%d')")
	public Integer updateNur1016(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("allergyInfo") String allergyInfo,
			@Param("endDate") Date endDate,
			@Param("endSayu") String endSayu,
			@Param("inputText") String inputText,
			@Param("hospCode") String hospCode,
			@Param("pknur1016") Double pknur1016,
			@Param("bunho") String bunho,
			@Param("allergyGubun") String allergyGubun,
			@Param("startDate") String startDate); 
	
	@Modifying
	@Query("UPDATE Nur1016 SET updId = :updId, updDate = :updDate, cancelYn = 'Y' WHERE hospCode = :hospCode "
			+ " AND pknur1016 = :pknur1016 AND bunho = :bunho AND allergyGubun = :allergyGubun AND startDate = DATE_FORMAT(:startDate, '%Y/%m/%d')")
	public Integer updateCancelStatusNur1016(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("hospCode") String hospCode,
			@Param("pknur1016") Double pknur1016,
			@Param("bunho") String bunho,
			@Param("allergyGubun") String allergyGubun,
			@Param("startDate") String startDate);
	
	@Query("SELECT allergyInfo  FROM Nur1016  WHERE hospCode = :hospCode  AND bunho = :bunho  AND :queryDate BETWEEN startDate AND IFNULL(endDate,'9998/12/31') "
		+ "AND IFNULL(cancelYn, 'N') = 'N'  ORDER BY startDate DESC ")
	public List<String> getInjsINJ1001U01AllergyList(@Param("hospCode") String hospCode, @Param("bunho") String bunho, @Param("queryDate") Date queryDate);
	
	@Query("SELECT COUNT(a) FROM Nur1016 a WHERE hospCode = :hospCode  AND bunho = :bunho AND IFNULL(cancelYn, 'N') = 'N'")
	public Integer checkExistAllergyData(@Param("hospCode") String hospCode, @Param("bunho") String bunho);
}

