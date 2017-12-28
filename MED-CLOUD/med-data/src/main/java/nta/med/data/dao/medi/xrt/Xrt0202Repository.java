package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt0202;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0202Repository extends JpaRepository<Xrt0202, Long>, Xrt0202RepositoryCustom {
	@Modifying
	@Query("UPDATE Xrt0202 SET updId           = :q_user_id "
			+ ", updDate         = SYSDATE(), tubeVol         = :f_tube_vol "
			+ " , tubeCur         = :f_tube_cur, xrayTime        = :f_xray_time "
			+ " , tubeCurTime    = :f_tube_cur_time, irradiationTime = :f_irradiation_time "
			+ ", xrayDistance    = :f_xray_distance  "
			+ "WHERE hospCode        = :f_hosp_code AND fkxrt0201        = :f_fkxrt0201 "
			+ "AND xrayCodeIdx    = :f_xray_code_idx ")
	public Integer updateXRT0201U00RadioSaveLayout(@Param("f_hosp_code") String hospCode,@Param("q_user_id") String userId,
			@Param("f_tube_vol") String tubeVol,@Param("f_tube_cur") String tubeCur,@Param("f_xray_time") String xrayTime,
			@Param("f_tube_cur_time") String tubeCurTime,@Param("f_irradiation_time") String irradiationTime,
			@Param("f_xray_distance") String xrayDistance,@Param("f_fkxrt0201") Double fkxrt0201,
			@Param("f_xray_code_idx") String xrayCodeIdx);
}

