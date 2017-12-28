package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur4003;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur4003Repository extends JpaRepository<Nur4003, Long>, Nur4003RepositoryCustom {
	
	@Query("SELECT T FROM Nur4003 T WHERE T.hospCode = :hospCode AND T.nurPlan = :nurPlan")
	public List<Nur4003> findByHospCodeNurPlan(@Param("hospCode") String hospCode, 
											   @Param("nurPlan") Double nurPlan);
	
	@Modifying
	@Query(	  " UPDATE Nur4003                          "
			+ " SET updId        = :f_user_id        ,  "
			+ "     updDate      = SYSDATE()         ,  "
			+ "     nurPlanName  = :f_nur_plan_name  ,  "
			+ "     vald         = :f_nur4003_vald      "
			+ " WHERE hospCode   = :f_hosp_code         "
			+ "   AND pknur4003  = :f_pknur4003         ")
	public Integer updateByHospCodeNur4003(@Param("f_user_id") String updId,
										   @Param("f_nur_plan_name") String nurPlanName,
										   @Param("f_nur4003_vald") String vald,
										   @Param("f_hosp_code") String hospCode,
										   @Param("f_pknur4003") Double pknur4003);
	
}