package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0804;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0804Repository extends JpaRepository<Ocs0804, Long>, Ocs0804RepositoryCustom {
	@Modifying
	@Query("DELETE Ocs0804  WHERE patStatusGr = :f_pat_status_gr  AND patStatus  = :f_pat_status AND hospCode  = :f_hosp_code ")
	public Integer deleteOCS0803U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_pat_status_gr") String patStatusGr,
			@Param("f_pat_status") String patStatus);
	
	@Modifying
	@Query("UPDATE Ocs0804 SET updId = :q_user_id  ,			"
			+ "updDate = :updDate  ,						    "
			+ "indispensableYn  = :f_indispensable_yn  ,        "
			+ "breakPatStatusCode = :f_break_pat_status_code,   "
			+ "ment = :f_ment  ,                                "
			+ "seq  = :f_seq                                    "
			+ "WHERE patStatusGr = :f_pat_status_gr             "
			+ "AND patStatus = :f_pat_status                    "
			+ "AND hospCode = :f_hosp_code                      ")
	public Integer updateOCS0803U00ExecuteCase2(
			@Param("f_hosp_code") String hospCode,
			@Param("q_user_id") String userId,
			@Param("updDate") Date updDate,
			@Param("f_indispensable_yn") String indispensableYn,
			@Param("f_break_pat_status_code") String breakPatStatusCode,
			@Param("f_ment") String ment,
			@Param("f_seq") Double seq,
			@Param("f_pat_status_gr") String patStatusGr,
			@Param("f_pat_status") String patStatus);
}

