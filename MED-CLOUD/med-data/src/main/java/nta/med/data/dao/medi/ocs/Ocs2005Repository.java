package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs2005;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2005Repository extends JpaRepository<Ocs2005, Long>, Ocs2005RepositoryCustom {
	
	@Query("SELECT T FROM Ocs2005 T WHERE hospCode = :f_hosp_code AND orderDate = :f_order_date AND fkocs6015 = :f_fkocs6015 ")
	public List<Ocs2005> findByHospCodeOrderDateFkocs6015(@Param("f_hosp_code") String hospCode,
														  @Param("f_order_date") Date orderDate,
														  @Param("f_fkocs6015") Double fkocs6015);
	
	@Modifying
	@Query("    DELETE FROM Ocs2005				   "
			+ " WHERE hospCode    = :f_hosp_code   "
			+ "   AND bunho       = :f_bunho	   "
			+ "   AND fkinp1001   = :f_fkinp1001   "
			+ "   AND inputGubun  = :f_input_gubun "
			+ "   AND pkSeq       = :f_pk		   ")
	public Integer deleteOcs2005InOCS6010U10SaveLayout(@Param("f_hosp_code") 	String hospCode
													  ,@Param("f_bunho") 		String bunho
													  ,@Param("f_fkinp1001") 	Double fkinp1001
													  ,@Param("f_input_gubun") 	String inputGubun
													  ,@Param("f_pk") 			Double pk);
	
	@Modifying
	@Query("    UPDATE Ocs2005						   "
			+ " SET updId         = :f_user_id       , "
			+ "     updDate       =  SYSDATE()       , "
			+ "     directCont1   = :f_direct_cont1  , "
			+ "     directCont2   = :f_direct_cont2  , "
			+ "     directText    = :f_direct_text   , "
			+ "     drtFromDate   = :f_drt_from_date , "
			+ "     drtToDate     = :f_drt_to_date   , "
			+ "     drtToTime     = :f_drt_to_time   , "
			+ "     drtFromTime   = :f_drt_from_time , "
			+ "     continueYn    = :f_continue_yn   , "
			+ "     jusikYudong   = :f_jusik_yudong  , "
			+ "     busikYudong   = :f_busik_yudong  , "
			+ "     joriType      = :f_jori_type     , "
			+ "     kumjisik      = :f_kumjisik        "
			+ " WHERE pkocs2005   = :f_pkocs2005       "
			+ "   AND hospCode    = :f_hosp_code       ")
	public Integer updateOcs2005InOCS2004U00SaveLayout( @Param("f_user_id")       String userId,
														@Param("f_direct_cont1")  String directCont1,
														@Param("f_direct_cont2")  String directCont2,
														@Param("f_direct_text")   String directText,
														@Param("f_drt_from_date") Date   drtFromDate,
														@Param("f_drt_to_date")   Date   drtToDate,
														@Param("f_drt_to_time")   String drtToTime,
														@Param("f_drt_from_time") String drtFromTime,
														@Param("f_continue_yn")   String continueYn,
														@Param("f_jusik_yudong")  String jusikYudong,
														@Param("f_busik_yudong")  String busikYudong,
														@Param("f_jori_type")     String joriType,
														@Param("f_kumjisik")      String kumjisik,
														@Param("f_pkocs2005")     Double pkocs2005,
														@Param("f_hosp_code") 	  String hospCode);         

	@Modifying
	@Query(" DELETE FROM Ocs2005 WHERE pkocs2005 = :f_pkocs2005 AND hospCode = :f_hosp_code ")
	public Integer deleteByHospCodePkOcs2005(@Param("f_hosp_code") String hospCode
										   , @Param("f_pkocs2005") Double pkocs2005);
	
	@Query("SELECT T FROM Ocs2005 T WHERE hospCode = :f_hosp_code AND pkocs2005 = :f_pkocs2005 ")
	public List<Ocs2005> findByHospCodePkocs2005(@Param("f_hosp_code") String hospCode,
												 @Param("f_pkocs2005") Double pkocs2005);
	
	
	@Modifying
	@Query("    UPDATE Ocs2005							"
			+ " SET updId           = :f_user_id		"
			+ "   , updDate         = SYSDATE()			"
			+ "   , drtFromDate     = :f_drt_from_date	"
			+ "   , drtToDate       = :f_drt_to_date    "
			+ "   , directCode      = :f_direct_code    "
			+ "   , directCont1     = :f_direct_cont1   "
			+ "   , directCont2     = :f_direct_cont2   "
			+ "   , directCont3     = :f_direct_cont3   "
			+ "   , directCodeD     = :f_direct_code_d  "
			+ "   , directCont1D    = :f_direct_cont1_d "
			+ "   , directCont2D    = :f_direct_cont2_d "
			+ "   , directCont3D    = :f_direct_cont3_d "
			+ "   , continueYn      = :f_continue_yn    "
			+ "   , kumjisik        = :f_kumjisik       "
			+ "   , nomimono        = :f_nomimono       "
			+ " WHERE pkocs2005     = :f_pkocs2005      "
			+ "   AND hospCode      = :f_hosp_code      ")
	public Integer updateOcs2005InOCS2005U02SaveLayout(
			@Param("f_user_id") 		String userId, 
			@Param("f_drt_from_date") 	Date drtFromDate,
			@Param("f_drt_to_date") 	Date drtToDate,
			@Param("f_direct_code") 	String directCode,
			@Param("f_direct_cont1") 	String directCont1,
			@Param("f_direct_cont2") 	String directCont2,
			@Param("f_direct_cont3") 	String directCont3,
			@Param("f_direct_code_d") 	String directCodeD,
			@Param("f_direct_cont1_d")  String directCont1D,
			@Param("f_direct_cont2_d")  String directCont2D,
			@Param("f_direct_cont3_d")  String directCont3D,
			@Param("f_continue_yn")     String continueYn,
			@Param("f_kumjisik")        String kumjisik,
			@Param("f_nomimono")        String nomimono,
			@Param("f_pkocs2005")       Double pkocs2005,
			@Param("f_hosp_code")       String hospCode);
}

