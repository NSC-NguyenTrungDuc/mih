package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0404;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0404Repository extends JpaRepository<Nur0404, Long>, Nur0404RepositoryCustom {

	@Query("SELECT T FROM Nur0404 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin AND T.nurPlan = :nurPlan")
	public List<Nur0404> findByHospCodeNurPlanJinNurPlan(@Param("hospCode") String hospCode,
														 @Param("nurPlanJin") String nurPlanJin, 
														 @Param("nurPlan") Double nurPlan);
	
	@Modifying
	@Query("DELETE Nur0404 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin")
	public Integer deleteByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			 								  @Param("nurPlanJin") String nurPlanJin);
	
	@Modifying
	@Query("DELETE Nur0404 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin AND nurPlan = :nurPlan")
	public Integer deleteByHospCodeNurPlanJinNurPlan(@Param("hospCode") String hospCode,
					 								 @Param("nurPlanJin") String nurPlanJin,
					 								 @Param("nurPlan") Double nurPlan);
	
	@Query("SELECT T FROM Nur0404 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin AND T.nurPlan = :nurPlan AND T.nurPlanDetail = :nurPlanDetail")
	public List<Nur0404> findByHospCodeNurPlanJinNurPlanNurPlanDetail(@Param("hospCode") String hospCode,
														 @Param("nurPlanJin") String nurPlanJin, 
														 @Param("nurPlan") Double nurPlan,
														 @Param("nurPlanDetail") String nurPlanDetail);
	
	@Modifying
	@Query(	  " UPDATE Nur0404                            "
			+ "  SET updId          = :f_user_id,         "
			+ "      updDate        = SYSDATE(),          "
			+ "      nurPlanDename  = :f_nur_plan_dename, "
			+ "      sortKey        = :f_sort_key,        "
			+ "      vald           = :f_vald             "
			+ " WHERE hospCode      = :f_hosp_code        "
			+ "  AND nurPlanJin     = :f_nur_plan_jin     "
			+ "  AND nurPlan        = :f_nur_plan         "
			+ "  AND nurPlanDetail  = :f_nur_plan_detail  ")
	public Integer updateByHospCodeNurPlanJinNurPlanNurPlanDetail(@Param("f_user_id") String userId,
																  @Param("f_nur_plan_dename") String nurPlanDename,
																  @Param("f_sort_key") Double sortKey,
																  @Param("f_vald") String vald,
																  @Param("f_hosp_code") String hospCode,
																  @Param("f_nur_plan_jin") String nurPlanJin,
																  @Param("f_nur_plan") Double nurPlan,
																  @Param("f_nur_plan_detail") String nurPlanDetail);
	
	@Modifying
	@Query(	  " DELETE Nur0404                            "
			+ " WHERE hospCode      = :f_hosp_code        "
			+ "  AND nurPlanJin     = :f_nur_plan_jin     "
			+ "  AND nurPlan        = :f_nur_plan         "
			+ "  AND nurPlanDetail  = :f_nur_plan_detail  ")
	public Integer deleteByHospCodeNurPlanJinNurPlanNurPlanDetail(@Param("f_hosp_code") String hospCode,
																  @Param("f_nur_plan_jin") String nurPlanJin,
																  @Param("f_nur_plan") Double nurPlan,
																  @Param("f_nur_plan_detail") String nurPlanDetail);
}
