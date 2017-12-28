package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1091;

@Repository
public interface Nur1091Repository extends JpaRepository<Nur1091, Long>, Nur1091RepositoryCustom {

	@Query("SELECT T FROM Nur1091 T WHERE T.hospCode = :hospCode ORDER BY T.codeType")
	public List<Nur1091> findByHospCode(@Param("hospCode") String hospCode);

	@Query("SELECT T FROM Nur1091 T WHERE T.hospCode = :hospCode AND T.codeType = :codeType")
	public List<Nur1091> findByHospCodeAndCodeType(@Param("hospCode") String hospCode,
			@Param("codeType") String codeType);
	
	@Modifying
	@Query(   " UPDATE Nur1091                         "
			+ "  SET updId         = :f_user_id        "
			+ "    , updDate       = SYSDATE()         "
			+ "    , toDate        = :f_to_date        "
			+ "    , codeTypeName  = :f_code_type_name "
			+ "    , maxScore      = :f_max_score      "
			+ "    , sortSeq       = :f_sort_seq       "
			+ " WHERE hospCode     = :f_hosp_code      "
			+ "  AND codeType      = :f_code_type      "
			+ "  AND fromDate      = :f_from_date      ")
	public Integer updateByHospCodeCodeTypeFromDate(@Param("f_user_id") 		String updId,
													@Param("f_to_date") 		Date toDate,
													@Param("f_code_type_name") 	String codeTypeName,
													@Param("f_max_score") 		Double maxScore,
													@Param("f_sort_seq") 		Double sortSeq,
													@Param("f_hosp_code")       String hospCode,
													@Param("f_code_type")       String codeType,
													@Param("f_from_date")       Date fromDate);
	
	@Modifying
	@Query(   " DELETE Nur1091                         "
			+ " WHERE hospCode     = :f_hosp_code      "
			+ "  AND codeType      = :f_code_type      "
			+ "  AND fromDate      = :f_from_date      ")
	public Integer deleteByHospCodeCodeTypeFromDate(@Param("f_hosp_code")       String hospCode,
													@Param("f_code_type")       String codeType,
													@Param("f_from_date")       Date fromDate);
	
	@Query("SELECT T FROM Nur1091 T WHERE T.hospCode = :hospCode AND :f_date BETWEEN T.fromDate AND IFNULL(T.toDate, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ")
	public List<Nur1091> findByHospCodeFDate(@Param("hospCode") String hospCode, @Param("f_date") Date fDate);
}
