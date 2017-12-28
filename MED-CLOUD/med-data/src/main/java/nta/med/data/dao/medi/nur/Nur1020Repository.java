package nta.med.data.dao.medi.nur;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1020;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1020Repository extends JpaRepository<Nur1020, Long>, Nur1020RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Nur1020						"
			+ " SET updId       = :q_user_id		"
			+ "   , updDate     = SYSDATE()			"
			+ "   , prValue     = :f_blood_sugar	"
			+ " WHERE hospCode  = :f_hosp_code 		"
			+ "   AND bunho     = :f_bunho			"
			+ "   AND fkinp1001 = :f_fkinp1001		"
			+ "   AND ymd       = :f_ymd			"
			+ "   AND timeGubun = :f_act_time		"
			+ "   AND prGubun   = 'BS'				")
	public Integer updateNur1020PopupIASaveLayout(
			@Param("q_user_id") String userId,
			@Param("f_blood_sugar") Double bloodSugar,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_fkinp1001") Double fkinp1001,
			@Param("f_ymd") Date ymd,
			@Param("f_act_time") String actTime);

	@Modifying
	@Query("        	UPDATE Nur1020                          "
			+ "        	SET udpId     	= :f_userId,           	" 
			+ "         	updDate     = SYSDATE(),      		"
			+ "            	prValue		= :f_blood_sugar,       "
			+ "            	timeGubun	= :f_act_time           "
			+ "        	WHERE hospCode	= :f_hosp_code         	"
			+ "          	AND bunho 		= :f_bunho        	"
			+ "          	AND fkinp1001 	= :f_fkinp1001      "
			+ "          	AND ymd 		= :f_ymd        	"
			+ "          	AND timeGubun 	= :f_time_gubun     "
			+ "          	AND prGubun	= 'BS'            		")
	public Integer updateNur1020PopupIASaveLayoutCaseOcs2016(
			@Param("f_userId") String updId,
			@Param("f_blood_sugar") String bloodSugar,
			@Param("f_act_time") String actTime,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_fkinp1001") String fkinp1001,
			@Param("f_ymd") String ymd,
			@Param("f_time_gubun") String timeGubun);
	
	@Modifying
	@Query(" DELETE FROM Nur1020 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkocs2016 = :f_pkocs2016 AND prGubun = :f_pr_gubun")
	public Integer deleteByHospCodeBunhoPkocs2016PrGubun(@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_pkocs2016") Double pkocs2016,
			@Param("f_pr_gubun") String prGubun);
	
	
	@Modifying
	@Query("DELETE FROM Nur1020 WHERE hospCode = :hospCode AND bunho = :bunho AND fkinp1001 = :fkinp1001 AND ymd = :ymd AND timeGubun = :timeGubun")
	public Integer deleteByHospCodeBunhoFkinp1001YmdTimeGubun(@Param("hospCode") String hospCode,
															  @Param("bunho") String bunho,
															  @Param("fkinp1001") Double fkinp1001,
															  @Param("ymd") Date ymd,
															  @Param("timeGubun") String timeGubun);
	
}

