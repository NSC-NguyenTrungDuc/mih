package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1093;

@Repository
public interface Nur1093Repository extends JpaRepository<Nur1093, Long>, Nur1093RepositoryCustom {

	@Query("SELECT T FROM Nur1093 T WHERE T.hospCode = :hospCode ORDER BY code")
	public List<Nur1093> findByHospCode(@Param("hospCode") String hospCode);
	
	@Modifying
	@Query(   " UPDATE Nur1093                       "
			+ " SET updId        = :q_user_id        "
			+ "  , updDate       = SYSDATE()         "
			+ "  , toDate        = :f_to_date        "
			+ "  , codeName      = :f_code_name      "
			+ "  , fromScore     = :f_from_score     "
			+ "  , toScore       = :f_to_score       "
			+ "  , sortSeq       = :f_sort_seq       "
			+ "  , codeCmt       = :f_code_cmt       "
			+ "  , bedDisplayYn  = :f_bed_display_yn "
			+ " WHERE hospCode   = :f_hosp_code      "
			+ " AND code         = :f_code           "
			+ " AND fromDate 	 = :f_from_date      ")
	public Integer updateByHospCodeCodeFromDate(
			@Param("q_user_id") 	    String updId       ,
			@Param("f_to_date")	 	    Date   toDate      ,
			@Param("f_code_name") 	    String codeName    ,
			@Param("f_from_score") 	    Double fromScore   ,
			@Param("f_to_score") 	    Double toScore     ,
			@Param("f_sort_seq") 	    Double sortSeq     ,
			@Param("f_code_cmt") 	    String codeCmt     ,
			@Param("f_bed_display_yn") 	String bedDisplayYn,
			@Param("f_hosp_code") 		String hospCode    ,
			@Param("f_code") 			String code        ,
			@Param("f_from_date") 		Date fromDate);
	
	
	@Modifying
	@Query(   " DELETE Nur1093                       "
			+ " WHERE hospCode   = :f_hosp_code      "
			+ " AND code         = :f_code           "
			+ " AND fromDate 	 = :f_from_date      ")
	public Integer deleteByHospCodeCodeFromDate(@Param("f_hosp_code") 		String hospCode    ,
												@Param("f_code") 			String code        ,
												@Param("f_from_date") 		Date fromDate);
	
	@Query("SELECT T FROM Nur1093 T " + "WHERE T.hospCode = :hospCode "
			+ "AND :f_date BETWEEN fromDate AND IFNULL(toDate, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) "
			+ "AND :f_sum BETWEEN fromScore AND IFNULL(toScore, 999)")
	public List<Nur1093> findByHospCodeFDateFSum(@Param("hospCode") String hospCode, @Param("f_date") Date fDate,
			@Param("f_sum") Double fSum);
}
