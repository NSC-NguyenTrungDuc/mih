package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm1110;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm1110Repository extends JpaRepository<Adm1110, Long>, Adm1110RepositoryCustom {
	@Modifying	
	@Query("	UPDATE Adm1110				 "
	      +"	SET colNm = :f_code_nm     "
	      +"	,upMemb = :f_up_memb        "
	      +"	,upTime = :f_upd_date      "
	      +"	WHERE colId = :f_col_id     "
	      +"	AND code = :f_code  AND language = :language       ")
	public Integer updateAdm1110SaveLayout(
			@Param("f_code_nm") String colNm,
			@Param("f_up_memb") String upMemb,
			@Param("f_upd_date") Date upTime,
			@Param("f_col_id") String colId,
			@Param("f_code") String code,
			@Param("language") String language);
	
	@Modifying
	@Query("DELETE Adm1110 WHERE colId = :f_col_id AND code = :f_code AND language = :language ")
	public Integer deleteAdm1110SaveLayout(@Param("f_col_id") String colId, @Param("f_code") String code, @Param("language") String language);
	
}

