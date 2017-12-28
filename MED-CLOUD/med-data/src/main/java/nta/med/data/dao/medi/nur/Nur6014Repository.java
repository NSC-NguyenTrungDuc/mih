package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6014;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6014Repository extends JpaRepository<Nur6014, Long>, Nur6014RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Nur6014 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') "
			+ " AND bedsoreBuwi = :f_besore_buwi AND assessorDate = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d') ")
	public Integer deleteNur6014FromNUR6011(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_from_date") String fromDate,
			@Param("f_besore_buwi") String bedsoreBuwi,
			@Param("f_assessor_date") String assessorDate);
	
	@Modifying
	@Query("DELETE FROM Nur6014 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') "
			+ " AND bedsoreBuwi = :f_besore_buwi AND assessorDate = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d') AND seq = :f_seq")
	public Integer deleteNur6014SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_from_date") String fromDate,
			@Param("f_besore_buwi") String bedsoreBuwi,
			@Param("f_assessor_date") String assessorDate,
			@Param("f_seq") Double seq);
}

