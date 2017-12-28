package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2015;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2015Repository extends JpaRepository<Ocs2015, Long>, Ocs2015RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ocs2015 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 "
			+ " AND orderDate = :f_order_date AND inputGubun = :f_input_gubun AND pkSeq = :f_pk_seq AND actDate = :f_act_date AND siksaCode = :f_siksa_code")
	public Integer deleteOcs2015InOCS6010U10(	@Param("f_hosp_code") String hospCode,
												@Param("f_bunho") String bunho,
												@Param("f_fkinp1001") Double fkinp1001,
												@Param("f_order_date") Date orderDate,
												@Param("f_input_gubun") String inputGubun,
												@Param("f_pk_seq") Double pkSeq,
												@Param("f_act_date") Date actDate,
												@Param("f_siksa_code") String siksaCode);
	
	@Modifying
	@Query("UPDATE Ocs2015 SET updDate = SYSDATE() , 			"
					+ " updId          = :f_user_id, 			"
					+ " actDate        = :f_act_date, 			"
					+ " actId          = :f_act_id, 			"
					+ " actResultCode  = :f_act_result_code, 	"
					+ " actResultText  = :f_act_result_text 	"
					+ " WHERE hospCode = :f_hosp_code AND pkocs2015 = :f_pkocs2015 ")
	public Integer updateOCS6010U10(	@Param("f_hosp_code") String hospCode,
										@Param("f_pkocs2015") Double pkocs2015,
										@Param("f_user_id") String userId,
										@Param("f_act_date") Date actDate,
										@Param("f_act_id") String actId,
										@Param("f_act_result_code") String actResultCode,
										@Param("f_act_result_text") String actResultText);

	@Modifying
	@Query("DELETE FROM Ocs2015 WHERE hospCode = :f_hosp_code AND pkocs2015 = :f_pkocs2015")
	public Integer deleteOcs2015InOCS6010Ext(	@Param("f_hosp_code") String hospCode,
			@Param("f_pkocs2015") Double pkocs2015);

	@Modifying
	@Query("DELETE FROM Ocs2015 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 "
			+ " AND orderDate = :f_order_date AND inputGubun = :f_input_gubun AND pkSeq = :f_pk_seq")
	public Integer deleteOCS6010U10PopupIASaveLayout(	@Param("f_hosp_code") String hospCode,
												@Param("f_bunho") String bunho,
												@Param("f_fkinp1001") Double fkinp1001,
												@Param("f_order_date") Date orderDate,
												@Param("f_input_gubun") String inputGubun,
												@Param("f_pk_seq") Double pkSeq);
	
	@Modifying
	@Query("    UPDATE Ocs2015 "
			+ " SET updId          = :f_user_id          , 			       "
			+ "     updDate        = SYSDATE()          , 			       "
			+ "     actDate        = :f_act_date        , 			       "
			+ "     actid          = :f_act_id          , 			       "
			+ "     actResultText  = :f_act_result_text ,                  "
			+ "     suryang        = :f_suryang         ,                  "
			+ "     dv             = :f_dv              ,                  "
			+ "     changeQty      = :f_change_qty      ,                  "
			+ "     fio2           = :f_fio2            ,                  "
			+ "     startTime      = :f_start_time      ,                  "
			+ "     endTime        = :f_end_time        ,                  "
			+ "     endDate        = :f_end_date                           "
			+ " WHERE hospCode = :f_hosp_code AND pkocs2015 = :f_pkocs2015 ")
	public Integer updateOcs2015InOCS6010U10frmARActingSave(@Param("f_hosp_code") String hospCode,
															@Param("f_pkocs2015") Double pkocs2015,
															@Param("f_user_id") String userId,
															@Param("f_act_date") Date actDate,
															@Param("f_act_id") String actId,
															@Param("f_act_result_text") String actResultText,
															@Param("f_suryang") Double suryang,
															@Param("f_dv") Double dv,
															@Param("f_change_qty") Double changeQty,
															@Param("f_fio2") Double fio2,
															@Param("f_start_time") String startTime,
															@Param("f_end_time") String endTime,
															@Param("f_end_date") Date endDate);
}

