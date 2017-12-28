package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm1100;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm1100Repository extends JpaRepository<Adm1100, Long>, Adm1100RepositoryCustom {
	@Modifying
	@Query("UPDATE Adm1100             "
			+" SET colNm   = :f_col_nm "
			+"   ,colTp   = :f_col_tp  "
			+"   ,colLen  = :f_col_len "
			+"   ,colScal = :f_col_scal "
			+"   ,cmmt     = :f_cmmt   "
			+"   ,upMemb  = :f_up_memb "
			+"   ,upTime  = :f_up_time "
			+"WHERE colId   = :f_col_id ")
	public Integer updateAdm1100SaveLayout(
			@Param("f_col_nm") String colNm,
			@Param("f_col_tp") String colTp,
			@Param("f_col_len") Double colLen,
			@Param("f_col_scal") Double colScal,
			@Param("f_cmmt") String cmmt,
			@Param("f_up_memb") String upMemb,
			@Param("f_up_time") Date  upTime,
			@Param("f_col_id") String colId);
	
	@Modifying
	@Query("DELETE Adm1100 WHERE colId = :f_col_id")
	public Integer deleteAdm1100SaveLayout(@Param("f_col_id") String colId);

}

