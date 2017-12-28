package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.drg.Drg0141;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0141Repository extends JpaRepository<Drg0141, Long>, Drg0141RepositoryCustom {
	@Query("SELECT a FROM Drg0141 a WHERE a.code = :code  AND a.hospCode = :hospCode AND a.language = :f_language ORDER BY code1")
	public List<Drg0141> getByCode(@Param("hospCode") String hospCode, @Param("code") String code, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Drg0141 SET updId = :updId,updDate = :updDate,codeName1 = :codeName1 "
			+ "WHERE code = :code AND code1 = :code1 AND hospCode = :hospCode AND language = :f_language")
	public Integer updateDrg0141ByCode(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeName1") String codeName1,
			@Param("code") String code,
			@Param("code1") String code1,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE FROM Drg0141 WHERE code = :code AND code1 = :code1 AND hospCode = :hospCode AND language = :f_language")
	public Integer deleteDrg0141ByCode(
			@Param("code") String code,
			@Param("code1") String code1,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);
	
	@Query("SELECT codeName1 FROM Drg0141 WHERE hospCode = :f_hosp_code AND code1 = :f_code1 AND language = :f_language")
	public String getDRGOCSCHKSmallCodeDataValidating(
			@Param("f_code1") String code1,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	@Query(" SELECT code1 FROM Drg0141 WHERE code  = :f_code AND code1 = :f_code1 AND hospCode = :f_hosp_code AND language = :f_language")
	public String getCode1ByCodeAndCode1(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code") String code,
			@Param("f_code1") String code1,
			@Param("f_language") String language);
}

