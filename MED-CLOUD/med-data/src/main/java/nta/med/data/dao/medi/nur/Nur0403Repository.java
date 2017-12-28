package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0403;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0403Repository extends JpaRepository<Nur0403, Long>, Nur0403RepositoryCustom {
	
	@Query("SELECT DISTINCT nurPlanOte FROM Nur0403 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin")
	public List<String> findNurPlanOteByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			@Param("nurPlanJin") String nurPlanJin);
	
	@Modifying
	@Query("DELETE Nur0403 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin")
	public Integer deleteByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			 								  @Param("nurPlanJin") String nurPlanJin);
	
	@Query("SELECT T FROM Nur0403 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin AND T.nurPlan = :nurPlan")
	public List<Nur0403> findByHospCodeNurPlanJinNurPlan(@Param("hospCode") String hospCode,
													     @Param("nurPlanJin") String nurPlanJin,
													     @Param("nurPlan") Double nurPlan);
	
	@Modifying
	@Query(	  " UPDATE Nur0403                      "
			+ " SET updId       = :f_user_id,       "
			+ "     updDate     = SYSDATE(),        "
			+ "     nurPlanName = :f_nur_plan_name, "
			+ "     sortKey     = :f_sort_key,      "
			+ "     vald        = :f_vald           "
			+ " WHERE hospCode  = :f_hosp_code      "
			+ " AND nurPlanJin  = :f_nur_plan_jin   "
			+ " AND nurPlan     = :f_nur_plan       ")
	public Integer updateByHospCodeNurPlanJinNurPlan(@Param("f_user_id") String userId,
													 @Param("f_nur_plan_name") String nurPlanName,
													 @Param("f_sort_key") Double sortKey,
													 @Param("f_vald") String vald,
													 @Param("f_hosp_code") String hospCode,
													 @Param("f_nur_plan_jin") String nurPlanJin,
													 @Param("f_nur_plan") Double nurPlan);
	
	@Modifying
	@Query("DELETE Nur0403 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin AND nurPlan = :nurPlan")
	public Integer deleteByHospCodeNurPlanJinNurPlan(@Param("hospCode") String hospCode,
					 								 @Param("nurPlanJin") String nurPlanJin,
					 								 @Param("nurPlan") Double nurPlan);
}

