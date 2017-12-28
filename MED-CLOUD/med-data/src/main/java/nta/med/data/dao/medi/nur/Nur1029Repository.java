package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1029;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1029Repository extends JpaRepository<Nur1029, Long>, Nur1029RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur1029 SET updId = :f_user_id, updDate = SYSDATE(), buwi = :f_buwi, startDate = STR_TO_DATE(:f_start_date,'%Y/%m/%d'), "
			+ " buwiComment = :f_buwi_comment WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND pknur1029 = :f_pknur1029")
	public Integer updateNur1029SaveLayout(@Param("f_user_id") String userId,
			@Param("f_buwi") String buwi,
			@Param("f_start_date") String startDate,
			@Param("f_buwi_comment") String buwiComment,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_pknur1029") Double pknur1029);
	
	@Modifying
	@Query("DELETE FROM Nur1029 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND pknur1029 = :f_pknur1029")
	public Integer deleteNur1029SaveLayout(@Param("f_pknur1029") Double pknur1029,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho);
}

