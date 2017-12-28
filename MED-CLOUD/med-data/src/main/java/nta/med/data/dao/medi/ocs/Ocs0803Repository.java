package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0803;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0803Repository extends JpaRepository<Ocs0803, Long>, Ocs0803RepositoryCustom {
	@Query("SELECT A.patStatusGrName FROM Ocs0803 A WHERE A.hospCode  = :f_hosp_code AND A.patStatusGr = :f_code AND A.language = :f_language ")
	public String getOCS0803U00GetCodeNameCasePatStatusGr(@Param("f_hosp_code") String hospCode,@Param("f_code") String code,@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Ocs0803 "
			+ " SET updId = :q_user_id ,                     "                   
			+ " updDate = :updDate  ,                        "
			+ " patStatusGrName = :f_pat_status_gr_name,     "
			+ " ment = :f_ment  ,                            "
			+ " seq   = :f_seq                               "
			+ " WHERE patStatusGr = :f_pat_status_gr         "
			+ " AND hospCode = :f_hosp_code                  "
			+ " AND language = :f_language                   ")
	public Integer updateOCS0803U00ExecuteCase1(
			@Param("f_hosp_code") String hospCode,
			@Param("q_user_id") String userId,
			@Param("f_pat_status_gr_name") String patStatusGrName,
			@Param("updDate") Date updDate,
			@Param("f_ment") String ment,
			@Param("f_seq") Double seq,
			@Param("f_pat_status_gr") String patStatusGr,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Ocs0803  WHERE patStatusGr  = :f_pat_status_gr AND hospCode = :f_hosp_code AND language = :f_language ")
	public Integer deleteOCS0803U00ExecuteCase1(@Param("f_hosp_code") String hospCode,@Param("f_pat_status_gr") String patStatusGr,@Param("f_language") String language);
}

