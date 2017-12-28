package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur4004;

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
public interface Nur4004Repository extends JpaRepository<Nur4004, Long>, Nur4004RepositoryCustom {
	
	@Query("SELECT T FROM Nur4004 T WHERE T.hospCode = :hospCode AND T.nurPlan = :nurPlan AND T.nurPlanDetail = :nurPlanDetail")
	public List<Nur4004> findByHospCodeNurPlanNurPlanDetail(@Param("hospCode") String hospCode, 
															@Param("nurPlan") Double nurPlan, 
															@Param("nurPlanDetail") String nurPlanDetail);
	
	@Modifying
	@Query(	  " UPDATE Nur4004                            "
			+ " SET updId           = :f_user_id        , "
			+ "     updDate         = SYSDATE()         , "
			+ "     nurPlanDename   = :f_nur_plan_dename, "
			+ "     vald            = :f_nur4004_vald     "
			+ " WHERE hospCode      = :f_hosp_code        "
			+ "   AND pknur4004     = :f_pknur4004        ")
	public Integer updateByHospCodePknur4004(
			@Param("f_user_id") 		String updId,
			@Param("f_nur_plan_dename") String nurPlanDename,
			@Param("f_nur4004_vald") 	String vald         ,
			@Param("f_hosp_code") 		String hospCode ,
			@Param("f_pknur4004") 		Double pknur4004);
}

