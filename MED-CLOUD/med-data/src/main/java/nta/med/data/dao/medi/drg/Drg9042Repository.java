package nta.med.data.dao.medi.drg;

import java.util.Date;

import nta.med.core.domain.drg.Drg9042;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9042Repository extends JpaRepository<Drg9042, Long>, Drg9042RepositoryCustom {
	@Query("SELECT 'Y' FROM Drg9042 WHERE inOutGubun = 'I' AND fkocs = :f_fkocs2003 AND hospCode = :f_hosp_code")
	public String DRG9040U01XSavePerformerCheckExitCase2(
			@Param("f_fkocs2003") Double fkocs,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query(" UPDATE Drg9042 SET updId = :f_user_id, updDate = :f_sys_date, orderRemark = :f_order_remark, drgRemark = :f_drg_remark "
			+ " WHERE inOutGubun = 'I' AND fkocs = :f_fkocs2003 AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerUpdateCase2(
			@Param("f_user_id") String userId,
			@Param("f_sys_date") Date sysDate,
			@Param("f_order_remark") String orderRemark,
			@Param("f_drg_remark") String drgRemark,
			@Param("f_fkocs2003") Double fkocs,
			@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT 'Y' FROM Drg9042 WHERE inOutGubun = 'O' AND fkocs = :f_fkocs2003 AND hospCode = :f_hosp_code")
	public String DRG9040U01XSavePerformerCheckExitCase5(
			@Param("f_fkocs2003") Double fkocs,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query(" UPDATE Drg9042 SET updId = :f_user_id, updDate = :f_sys_date, orderRemark = :f_order_remark, drgRemark = :f_drg_remark "
			+ " WHERE inOutGubun = 'O' AND fkocs = :f_fkocs2003 AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerUpdateCase5(
			@Param("f_user_id") String userId,
			@Param("f_sys_date") Date sysDate,
			@Param("f_order_remark") String orderRemark,
			@Param("f_drg_remark") String drgRemark,
			@Param("f_fkocs2003") Double fkocs,
			@Param("f_hosp_code") String hospCode);
}

