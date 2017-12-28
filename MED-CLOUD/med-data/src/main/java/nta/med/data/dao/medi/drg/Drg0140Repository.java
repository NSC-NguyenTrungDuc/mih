package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.drg.Drg0140;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0140Repository extends JpaRepository<Drg0140, Long>, Drg0140RepositoryCustom {
	@Query("SELECT a FROM Drg0140 a WHERE a.code LIKE :code AND a.hospCode = :hospCode AND a.language = :f_language ORDER BY 1")
	public List<Drg0140> findByCode(@Param("hospCode") String hospCode, @Param("code") String code, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Drg0140  SET updId = :updId,updDate = :updDate,codeName = :codeName WHERE code = :code AND hospCode = :hospCode AND language = :f_language")
	public Integer updateDrg0140ByCode(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeName") String codeName,
			@Param("code") String code,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);

	@Modifying
	@Query("DELETE FROM Drg0140  WHERE code = :code AND hospCode = :hospCode AND language = :f_language")
	public Integer deleteDrg0140ByCode(
			@Param("code") String code,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);

	@Query("SELECT codeName FROM Drg0140 WHERE hospCode = :f_hosp_code AND code = :f_code AND language = :f_language")
	public String getDRGOCSCHKPreSmallCodeDataValidating(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code") String code,
			@Param("f_language") String language);
	@Query(" SELECT code  FROM Drg0140 WHERE code  = :f_code AND hospCode = :f_hosp_code AND language = :f_language")
	public String getCodebyCodeAndHosp(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code") String code, 
			@Param("f_language") String language);
}

