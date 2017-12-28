package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0203;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0203Repository extends JpaRepository<Bas0203, Long>, Bas0203RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Bas0203 WHERE hospCode   = :f_hosp_code "
			+ " AND symyaGubun = :f_old_symya_gubun AND bunCode    = :f_old_bun_code  "
			+ " AND sgCode     = :f_old_sg_code AND fromTime   = :f_old_from_time "
			+ "AND jyDate     = :f_old_jy_date AND yoilGubun  = :f_old_yoil_gubun "
			+ "  AND fromMonth  = :f_old_from_month  AND toMonth    = :f_old_to_month "
			+ " AND toTime     = :f_old_to_time")
	public Integer deleteBas0203(@Param("f_hosp_code") String hospCode, @Param("f_old_symya_gubun") String oldSymyaGubun, 
			@Param("f_old_bun_code") String oldBunCode, @Param("f_old_sg_code") String oldSgCode, @Param("f_old_from_time") String oldFromTime, 
			@Param("f_old_jy_date") Date oldJyDate, @Param("f_old_yoil_gubun") String oldYoilGubun, @Param("f_old_from_month") Double oldFromMonth,
			@Param("f_old_to_month") Double oldToMonth, @Param("f_old_to_time") String oldToTime );
	
	@Modifying
	@Query("UPDATE Bas0203  SET updId  = :q_user_id , updDate  = :updDate  "
			+ " , toTime  = :f_to_time , toMonth   = :f_to_month "
			+ "WHERE hospCode  = :f_hosp_code AND symyaGubun  = :f_old_symya_gubun "
			+ " AND bunCode    = :f_old_bun_code AND sgCode   = :f_old_sg_code "
			+ "AND fromTime  = :f_old_from_time AND jyDate      = :f_old_jy_date "
			+ " AND yoilGubun   = :f_old_yoil_gubun AND fromMonth   = :f_old_from_month "
			+ " AND toMonth     = :f_old_to_month AND toTime      = :f_old_to_time ")
	public Integer updateBas0203(@Param("f_hosp_code") String hospCode, @Param("f_old_symya_gubun") String oldSymyaGubun, 
			@Param("f_old_bun_code") String oldBunCode, @Param("f_old_sg_code") String olgSgCode, @Param("f_old_from_time") String oldFromTime, 
			@Param("f_old_jy_date") Date oldJyDate, @Param("f_old_yoil_gubun") String oldYoilGubun, @Param("f_old_from_month") Double fromFromMonth,
			@Param("f_old_to_month") Double oldToMonth, @Param("f_old_to_time") String oldToTime, @Param("q_user_id") String updId, 
			@Param("updDate") Date updDate, @Param("f_to_time") String toTime, @Param("f_to_month") Double toMonth);
	
	@Query("SELECT 'Y' FROM Bas0203  WHERE hospCode   = :f_hosp_code  "
			+ " AND symyaGubun = :f_symya_gubun  AND bunCode    = :f_bun_code "
			+ "AND sgCode     = :f_sg_code AND jyDate     = :f_jy_date "
			+ " AND yoilGubun  = :f_yoil_gubun  AND fromMonth  = :f_from_month "
			+ " AND toMonth    = :f_to_month  AND fromTime   = :f_from_time"
			+ "  AND toTime     = :f_to_time ")
	public String getYFromBas0203(@Param("f_hosp_code") String hospCode, @Param("f_symya_gubun") String symyaGubun,
			@Param("f_bun_code") String bunCode, @Param("f_sg_code") String sgCode, @Param("f_jy_date") Date jyDate,
			@Param("f_yoil_gubun") String yoilGubun, @Param("f_from_month") Double fromMonth, @Param("f_to_month") Double toMonth,
			@Param("f_from_time") String fromTime, @Param("f_to_time") String toTime);
}

