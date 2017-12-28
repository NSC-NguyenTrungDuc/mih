package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1092;

@Repository
public interface Nur1092Repository extends JpaRepository<Nur1092, Long>, Nur1092RepositoryCustom {

	@Query("SELECT T FROM Nur1092 T WHERE T.hospCode = :hospCode AND T.codeType = :codeType ORDER BY T.codeType")
	public List<Nur1092> findByHospCodeAndCodeType(@Param("hospCode") String hospCode,
			@Param("codeType") String codeType);
	
	@Query("SELECT T FROM Nur1092 T WHERE T.hospCode = :hospCode AND T.codeType = :codeType AND T.code = :code")
	public List<Nur1092> findByHospCodeAndCodeTypeAndCode(@Param("hospCode") String hospCode,
			@Param("codeType") String codeType, @Param("code") String code);
	
	@Modifying
	@Query(   " UPDATE Nur1092                   "
			+ "  SET updId      = :q_user_id     "
			+ "    , updDate    = SYSDATE()      "
			+ "    , toDate     = :f_to_date     "
			+ "    , codeName   = :f_code_name   "
			+ "    , score      = :f_score       "
			+ "    , sortSeq    = :f_sort_seq    "
			+ " WHERE hospCode  = :f_hosp_code   "
			+ "  AND codeType   = :f_code_type   "
			+ "  AND code       = :f_code        "
			+ "  AND fromDate   = :f_from_date   ")
	public Integer updateByHospCodeCodeTypeCodeFromdate(@Param("q_user_id") 	String updId    ,
														@Param("f_to_date") 	Date toDate   ,
														@Param("f_code_name") 	String codeName ,
														@Param("f_score") 		Double score    ,
														@Param("f_sort_seq") 	Double sortSeq  ,
														@Param("f_hosp_code") 	String  hospCode ,
														@Param("f_code_type") 	String codeType  ,
														@Param("f_code") 		String code      ,
														@Param("f_from_date") 	Date fromdate);
	
	@Modifying
	@Query(   " DELETE Nur1092                   "
			+ " WHERE hospCode  = :f_hosp_code   "
			+ "  AND codeType   = :f_code_type   "
			+ "  AND code       = :f_code        "
			+ "  AND fromdate   = :f_from_date   ")
	public Integer deleteByHospCodeCodeTypeCodeFromdate(@Param("f_hosp_code") 	String  hospCode ,
														@Param("f_code_type") 	String codeType  ,
														@Param("f_code") 		String code      ,
														@Param("f_from_date") 	Date fromdate);
}
