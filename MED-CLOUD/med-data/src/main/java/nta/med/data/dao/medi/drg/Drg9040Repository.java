package nta.med.data.dao.medi.drg;

import java.util.Date;

import nta.med.core.domain.drg.Drg9040;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9040Repository extends JpaRepository<Drg9040, Long>, Drg9040RepositoryCustom {
	@Query("SELECT 'Y' FROM Drg9040 WHERE inOutGubun = 'I' AND jubsuDate = :f_jubsu_date "
			+ "AND orderDate = :f_order_date AND drgBunho = :f_drg_bunho AND hospCode = :f_hosp_code")
	public String DRG9040U01XSavePerformerCheckExitCase1(
			@Param("f_jubsu_date") Date jubsuDate,
			@Param("f_order_date") Date orderDate,
			@Param("f_drg_bunho") Double drgBunho,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query(" UPDATE Drg9040 SET updId = :f_user_id, updDate = :f_sys_date, inputDate = :f_sys_date"
			+ " , inputUser = :f_user_id, orderRemark = :f_order_remark, drgRemark = :f_drg_remark "
			+ " WHERE inOutGubun = 'I' AND jubsuDate = :f_jubsu_date "
			+ " AND orderDate = :f_order_date AND drgBunho = :f_drg_bunho AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerUpdateCase1(
			@Param("f_user_id") String userId,
			@Param("f_sys_date") Date sysDate,
			@Param("f_order_remark") String orderRemark,
			@Param("f_drg_remark") String drgRemark,
			@Param("f_jubsu_date") Date jubsuDate,
			@Param("f_order_date") Date orderDate,
			@Param("f_drg_bunho") Double drgBunho,
			@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT 'Y' FROM Drg9040 WHERE inOutGubun = 'O' AND jubsuDate = :f_jubsu_date "
			+ "AND orderDate = :f_order_date AND drgBunho = :f_drg_bunho AND hospCode = :f_hosp_code")
	public String DRG9040U01XSavePerformerCheckExitCase4(
			@Param("f_jubsu_date") Date jubsuDate,
			@Param("f_order_date") Date orderDate,
			@Param("f_drg_bunho") Double drgBunho,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query(" UPDATE Drg9040 SET updId = :f_user_id, updDate = :f_sys_date, inputDate = :f_sys_date"
			+ " , inputUser = :f_user_id, orderRemark = :f_order_remark, drgRemark = :f_drg_remark "
			+ " WHERE inOutGubun = 'O' AND jubsuDate = :f_jubsu_date "
			+ " AND orderDate = :f_order_date AND drgBunho = :f_drg_bunho AND hospCode = :f_hosp_code")
	public Integer DRG9040U01XSavePerformerUpdateCase4(
			@Param("f_user_id") String userId,
			@Param("f_sys_date") Date sysDate,
			@Param("f_order_remark") String orderRemark,
			@Param("f_drg_remark") String drgRemark,
			@Param("f_jubsu_date") Date jubsuDate,
			@Param("f_order_date") Date orderDate,
			@Param("f_drg_bunho") Double drgBunho,
			@Param("f_hosp_code") String hospCode);
}

