package nta.med.data.dao.medi.drg;

import java.util.Date;

import nta.med.core.domain.drg.Drg9041;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9041Repository extends JpaRepository<Drg9041, Long>, Drg9041RepositoryCustom {
	@Query("SELECT 'Y' FROM Drg9041 WHERE bunho = :f_bunho AND hospCode = :f_hosp_code")
	public String DRG9040U01XSavePerformerCheckExit(
			@Param("f_bunho") String bunho,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query(" UPDATE Drg9041 SET updId = :f_user_id, updDate = :f_sys_date, inputDate = :f_sys_date "
			+ ", inputUser = :f_user_id, orderRemark = :f_order_remark, drgRemark = :f_drg_remark "
			+ " WHERE bunho = :f_bunho AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerUpdate(
			@Param("f_user_id") String userId,
			@Param("f_sys_date") Date sysDate,
			@Param("f_order_remark") String orderRemark,
			@Param("f_drg_remark") String drgRemark,
			@Param("f_bunho") String bunho,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE Drg9041 WHERE bunho = :f_bunho AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerDelete(
			@Param("f_bunho") String bunho,
			@Param("f_hosp_code") String hospCode);
	
}

