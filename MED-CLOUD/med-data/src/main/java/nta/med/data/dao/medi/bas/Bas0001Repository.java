package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0001Repository extends JpaRepository<Bas0001, Long>, Bas0001RepositoryCustom {
	@Query("SELECT 'Y' FROM Bas0001 A WHERE A.hospCode = :f_hosp_code AND A.language = :f_language AND DATE_FORMAT(A.startDate,'%Y/%m/%d')  = :f_start_date AND A.yoyangGiho = :f_yoyang_giho ")
	public String getBAS0001U00ExecuteTDupCheck(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_start_date") String startDate,
			@Param("f_yoyang_giho") String yoyangGiho);
	
	@Modifying
	@Query(" UPDATE Bas0001 A  SET A.updId  = :q_user_id, A.updDate = SYSDATE(), A.endDate  = STR_TO_DATE(:f_start_date, '%Y/%m/%d') - 1 "
			+ "WHERE A.hospCode   = :f_hosp_code AND A.language = :f_language AND A.yoyangGiho = :f_yoyang_giho "
			+ "AND A.endDate    = STR_TO_DATE('9998/12/31', '%Y/%m/%d') "
			+ "AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.startDate AND A.endDate ")
	public Integer caseAddBAS0001U00ExecuteUpdateBAS0001(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("q_user_id") String userId,
			@Param("f_start_date") Date startDate,
			@Param("f_yoyang_giho") String yoyangGiho);
	
	@Modifying
	@Query("UPDATE Bas0001 SET endDate  = STR_TO_DATE('9998/12/31', '%Y/%m/%d') "
			+ "WHERE hospCode   = :f_hosp_code AND language = :f_language  AND endDate = :f_start_date "
			+ "AND yoyangGiho     = :f_yoyang_giho ")
	public Integer caseDeleteBAS0001U00ExecuteUpdateBAS0001(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_start_date") Date startDate,
			@Param("f_yoyang_giho") String yoyangGiho);
	
	@Modifying
	@Query("DELETE FROM Bas0001 WHERE hospCode  = :f_hosp_code AND language = :f_language  AND DATE_FORMAT(startDate,'%Y/%m/%d') = :f_start_date AND yoyangGiho  = :f_yoyang_giho")
	public Integer caseDeleteBAS0001U00ExecuteDeleteBAS0001(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_start_date") String startDate,
			@Param("f_yoyang_giho") String yoyangGiho);
	
	@Query("Select bas from Bas0001 bas WHERE hospCode = :f_hosp_code  AND language = :f_language  AND DATE_FORMAT(startDate,'%Y/%m/%d') = :f_start_date AND yoyangGiho = :f_yoyang_giho ")
	public  List<Bas0001> caseModifygetBas0001(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_start_date") String startDate,
			@Param("f_yoyang_giho") String yoyangGiho);
	
	@Query("Select bas from Bas0001 bas WHERE hospCode = :f_hosp_code AND language = :f_language  AND SYSDATE() BETWEEN bas.startDate AND bas.endDate ")
	public  List<Bas0001> getPHY8002U00DtHospInfo(@Param("f_hosp_code") String hospCode, @Param("f_language") String language);
	


	
	@Query("Select T from Bas0001 T WHERE hospCode = :f_hosp_code ")
	public List<Bas0001> findByHospCode(@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT T FROM Bas0001 T WHERE hospCode = :f_hosp_code AND startDate = (Select MAX(startDate) From Bas0001 Where hospCode = :f_hosp_code)")
	public List<Bas0001>findLatestByHospCode(@Param("f_hosp_code") String hospCode);
}

