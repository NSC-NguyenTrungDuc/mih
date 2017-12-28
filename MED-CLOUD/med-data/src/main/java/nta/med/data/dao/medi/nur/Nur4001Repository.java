package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur4001;

import java.util.Date;
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
public interface Nur4001Repository extends JpaRepository<Nur4001, Long>, Nur4001RepositoryCustom {
	
	@Query("SELECT T FROM Nur4001 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin")
	public List<Nur4001> findByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			@Param("nurPlanJin") String nurPlanJin);
	
	@Modifying
	@Query(   " UPDATE Nur4001                                  "
			+ " SET  updDate             = SYSDATE()            "
			+ "    , updId               = :f_user_id           "
			+ "    , nurPlanJin          = :f_nur_plan_jin      "
			+ "    , nurPlanJinName      = :f_nur_plan_jin_name "
			+ "    , planUser            = :f_plan_user         "
			+ "    , planDate            = :f_plan_date         "
			+ "    , vald                = :f_vald              "
			+ "    , sortKey             = :f_sort_key          "
			+ "    , endDate             = :f_end_date          "
			+ "    , purpose             = :f_purpose           "
			+ " WHERE hospCode  = :f_hosp_code                  "
			+ "   AND pknur4001 = :f_pknur4001                  ")
	public Integer updateByHospCodePknur4001(
			@Param("f_user_id") 			String updId,
			@Param("f_nur_plan_jin") 		String nurPlanJin,
			@Param("f_nur_plan_jin_name") 	String nurPlanJinName,
			@Param("f_plan_user") 			String planUser,
			@Param("f_plan_date") 			Date planDate,
			@Param("f_vald") 				String vald,
			@Param("f_sort_key") 			Double sortKey,
			@Param("f_end_date") 			Date endDate,
			@Param("f_purpose") 			String purpose,
			@Param("f_hosp_code") 			String hospCode,
			@Param("f_pknur4001") 			Double pknur4001);
}

