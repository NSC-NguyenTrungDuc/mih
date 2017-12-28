package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6011Repository extends JpaRepository<Nur6011, Long>, Nur6011RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur6011 SET updId = :f_user_id, updDate = SYSDATE(), endDate = STR_TO_DATE(:f_end_date, '%Y/%m/%d'), bedsoreBuwi1 = :f_bedsore_buwi1, "
			+ " bedsoreBuwi2 = :f_bedsore_buwi2, bedsoreBuwi3 = :f_bedsore_buwi3, bedsoreBuwi4 = :f_bedsore_buwi4, bedsoreBuwi5 = :f_bedsore_buwi5, "
			+ " bedsoreBuwi6 = :f_bedsore_buwi6   WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') " )
	public Integer updateNur6011SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_user_id") String userId,
			@Param("f_end_date") String endDate,
			@Param("f_bedsore_buwi1") String bedsoreBuwi1,
			@Param("f_bedsore_buwi2") String bedsoreBuwi2,
			@Param("f_bedsore_buwi3") String bedsoreBuwi3,
			@Param("f_bedsore_buwi4") String bedsoreBuwi4,
			@Param("f_bedsore_buwi5") String bedsoreBuwi5,
			@Param("f_bedsore_buwi6") String bedsoreBuwi6,			
			@Param("f_from_date") String fromDate);
	
	@Modifying
	@Query("DELETE FROM Nur6011 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') " )
	public Integer deleteNur6011SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,	
			@Param("f_from_date") String fromDate);
}

