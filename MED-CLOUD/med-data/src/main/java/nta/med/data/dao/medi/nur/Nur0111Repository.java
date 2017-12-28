package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0111;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0111Repository extends JpaRepository<Nur0111, Long>, Nur0111RepositoryCustom {

	@Query("SELECT T FROM Nur0111 T WHERE T.hospCode = :hospCode AND T.nurMdCode = :nurMdCode")
	public List<Nur0111> findByHospCodeNurMdCode(@Param("hospCode") String hospCode,
			@Param("nurMdCode") String nurMdCode);

	@Query("SELECT T FROM Nur0111 T WHERE T.hospCode = :hospCode AND T.nurGrCode = :nurGrCode AND T.nurMdCode = :nurMdCode")
	public List<Nur0111> findByHospCodeNurGrCodeNurMdCode(@Param("hospCode") String hospCode,
			@Param("nurGrCode") String nurGrCode, 
			@Param("nurMdCode") String nurMdCode);
	
	@Modifying
	@Query(   " UPDATE Nur0111                             "
			+ " SET updId           = :q_user_id,          "
			+ " 	updDate         = SYSDATE(),           "
			+ " 	nurMdName       = :f_nur_md_name,      "
			+ " 	sortKey         = :f_sort_key,         "
			+ " 	ment            = :f_ment,             "
			+ " 	vald            = :f_vald,             "
			+ "     jisiGubun       = :f_jisi_gubun,       "
			+ " 	cntPerhourYn    = :f_cnt_perhour_yn,   "
			+ "     cntPerdayYn     = :f_cnt_perday_yn,    "
			+ " 	actDayYn        = :f_act_day_yn,       "
			+ "     frenchYn        = :f_french_yn,        "
			+ " 	actDq1Yn        = :f_act_dq1_yn,       "
			+ "     actDq2Yn        = :f_act_dq2_yn,       "
			+ " 	actDq3Yn        = :f_act_dq3_yn,       "
			+ "     actDq4Yn        = :f_act_dq4_yn,       "
			+ " 	actTimeYn       = :f_act_time_yn,      "
			+ "     directContYn    = :f_direct_cont_yn,   "
			+ " 	actingYn        = :f_acting_yn,        "
			+ "     worklistDispYn  = :f_worklist_disp_yn, "
			+ " 	jisiOrderGubun  = :f_jisi_order_gubun, "
			+ "     jisiContinueYn  = :f_jisi_continue_yn  "
			+ " WHERE hospCode      = :f_hosp_code         "
			+ "   AND nurGrCode     = :f_nur_gr_code       "
			+ "   AND nurMdCode     = :f_nur_md_code       ")
	public Integer updateByHospCodeNurGrCodeNurMdCode(@Param("q_user_id") String updId,
													  @Param("f_nur_md_name") String nurMdName,
													  @Param("f_sort_key") Double sortKey,
													  @Param("f_ment") String ment,
													  @Param("f_vald") String vald,
													  @Param("f_jisi_gubun") String jisiGubun,
													  @Param("f_cnt_perhour_yn") String cntPerhourYn,
													  @Param("f_cnt_perday_yn") String cntPerdayYn,
													  @Param("f_act_day_yn") String actDayYn,
													  @Param("f_french_yn") String frenchYn,
													  @Param("f_act_dq1_yn") String actDq1Yn,
													  @Param("f_act_dq2_yn") String actDq2Yn,
													  @Param("f_act_dq3_yn") String actDq3Yn,
													  @Param("f_act_dq4_yn") String actDq4Yn,
													  @Param("f_act_time_yn") String actTimeYn,
													  @Param("f_direct_cont_yn") String directContYn,
													  @Param("f_acting_yn") String actingYn,
													  @Param("f_worklist_disp_yn") String worklistDispYn,
													  @Param("f_jisi_order_gubun") String jisiOrderGubun,
													  @Param("f_jisi_continue_yn") String jisiContinueYn,
													  @Param("f_hosp_code") String hospCode,
													  @Param("f_nur_gr_code") String nurGrCode,
													  @Param("f_nur_md_code") String nurMdCode);
	
	@Modifying
	@Query(   " UPDATE Nur0111                             "
			+ " SET updId           = :q_user_id,          "
			+ " 	updDate         = SYSDATE(),           "
			+ " 	vald            = :f_vald              "
			+ " WHERE hospCode      = :f_hosp_code         "
			+ "   AND nurGrCode     = :f_nur_gr_code       "
			+ "   AND nurMdCode     = :f_nur_md_code       ")
	public Integer updateValdByHospCodeNurGrCodeNurMdCode(@Param("q_user_id") String updId,
														  @Param("f_vald") String vald,
														  @Param("f_hosp_code") String hospCode,
														  @Param("f_nur_gr_code") String nurGrCode,
														  @Param("f_nur_md_code") String nurMdCode);
}
