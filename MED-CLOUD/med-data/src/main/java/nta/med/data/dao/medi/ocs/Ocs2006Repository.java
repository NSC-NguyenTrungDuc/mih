package nta.med.data.dao.medi.ocs;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs2006;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2006Repository extends JpaRepository<Ocs2006, Long>, Ocs2006RepositoryCustom {
	
	@Modifying
	@Query("    DELETE FROM Ocs2006				   "
			+ " WHERE hospCode    = :f_hosp_code   "
			+ "   AND bunho       = :f_bunho	   "
			+ "   AND fkinp1001   = :f_fkinp1001   "
			+ "   AND inputGubun  = :f_input_gubun "
			+ "   AND pkSeq       = :f_pk		   ")
	public Integer deleteOcs2006InOCS6010U10SaveLayout(@Param("f_hosp_code") 	String hospCode
													  ,@Param("f_bunho") 		String bunho
													  ,@Param("f_fkinp1001") 	Double fkinp1001
													  ,@Param("f_input_gubun") 	String inputGubun
													  ,@Param("f_pk") 			Double pk);
	
	@Modifying
	@Query(" DELETE FROM Ocs2006 WHERE hospCode = :f_hosp_code AND fkocs2005 = :f_fkocs2005")
	public Integer deleteByHospCodefkOcs2005(@Param("f_hosp_code") 	String hospCode,
											 @Param("f_fkocs2005") 	Double fkocs2005);
	
	
	@Modifying
	@Query("      UPDATE Ocs2006"
			+ "   SET updId         = :f_user_id        ,"
			+ "       updDate       =  SYSDATE()        ,"
			+ "       hangmogCode   = :f_hangmog_code   ,"
			+ "       suryang       = :f_suryang        ,"
			+ "       nalsu         = :f_nalsu          ,"
			+ "       ordDanui      = :f_ord_danui      ,"
			+ "       bogyongCode   = :f_bogyong_code   ,"
			+ "       jusaCode      = :f_jusa_code      ,"
			+ "       jusaSpdGubun  = :f_jusa_spd_gubun ,"
			+ "       dv            = :f_dv             ,"
			+ "       dvTime        = :f_dv_time        ,"
			+ "       insulinFrom   = :f_insulin_from   ,"
			+ "       insulinTo     = :f_insulin_to     ,"
			+ "       timeGubun     = :f_time_gubun     ,"
			+ "       bomYn         = :f_bom_yn         ,"
			+ "       bomSourceKey  = :f_bom_source_key ,"
			+ "       directGubun   = :f_direct_gubun   ,"
			+ "       directCode    = :f_direct_code    ,"
			+ "       directDetail  = :f_direct_detail"
			+ "   WHERE fkocs2005   = :f_fkocs2005"
			+ "     AND seq         = :f_seq"
			+ "     AND hospCode    = :f_hosp_code")
	public Integer updateOcs2006InOCS2004U00SaveLayout( @Param("f_user_id") 		String userId,
														@Param("f_hangmog_code") 	String hangmogCode,
														@Param("f_suryang") 		Double suryang,
														@Param("f_nalsu") 			Double nalsu,
														@Param("f_ord_danui") 		String ordDanui,
														@Param("f_bogyong_code") 	String bogyongCode,
														@Param("f_jusa_code") 		String jusaCode,
														@Param("f_jusa_spd_gubun") 	String jusaSpdGubun,
														@Param("f_dv") 				Double dv,
														@Param("f_dv_time") 		String dvTime,
														@Param("f_insulin_from") 	Double insulinFrom,
														@Param("f_insulin_to") 		Double insulinTo,
														@Param("f_time_gubun") 		String timeGubun,
														@Param("f_bom_yn") 			String bomYn,
														@Param("f_bom_source_key") 	Double bomSourceKey,
														@Param("f_direct_gubun") 	String directGubun,
														@Param("f_direct_code") 	String directCode,
														@Param("f_direct_detail") 	String directDetail,
														@Param("f_fkocs2005") 		Double fkocs2005,
														@Param("f_seq") 			Double seq,
														@Param("f_hosp_code") 		String hospCode);
}

