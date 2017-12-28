package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0108;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0108Repository extends JpaRepository<Ocs0108, Long>, Ocs0108RepositoryCustom {
	
	@Modifying
	@Query("DELETE Ocs0108 WHERE hangmogCode = :f_hangmog_code AND hangmogStartDate = :f_hangmog_start_date  AND ordDanui = :f_ord_danui AND hospCode = :f_hosp_code ")
	public Integer deleteOCS0108U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate,@Param("f_ord_danui") String ordDanui);
	
	@Modifying
	@Query("UPDATE Ocs0108 SET updId = :f_user_id , "
			+ "updDate = SYSDATE(),seq   = :f_seq   , "
			+ "changeQty1  = :f_change_qty1 , "
			+ "changeQty2  = :f_change_qty2 "
			+ "WHERE hangmogCode = :f_hangmog_code "
			+ "AND hangmogStartDate = :f_hangmog_start_date "
			+ "AND ordDanui    = :f_ord_danui "
			+ "AND hospCode    = :f_hosp_code  ")
	public Integer updateOCS0108U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_user_id") String userId,
			@Param("f_seq") Double seq,@Param("f_change_qty1") Double changeQty1,@Param("f_change_qty2") Double changeQty2,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_ord_danui") String ordDanui);
	
	@Query("SELECT DISTINCT 'Y'  FROM Ocs0108  WHERE hangmogCode  = :f_hangmog_code "
			+ "AND hospCode  = :f_hosp_code AND hangmogStartDate = :f_hangmog_start_date  AND ordDanui  = :f_ord_danui ")
	public String checkExitYOcs0108(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate,@Param("f_ord_danui") String ordDanui);
	
	@Query("SELECT MAX(seq) + 1  FROM Ocs0108 WHERE hospCode = :f_hosp_code  "
			+ "AND hangmogStartDate = :f_hangmog_start_date AND hangmogCode   = :f_hangmog_code")
	public Double getMaxSeqOcs0108(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_hangmog_code") String hangmogCode);
	
	@Modifying
	@Query("UPDATE Ocs0108 SET changeQty1  = :f_change_qty1 , changeQty2  = :f_change_qty2, "
			+ "updDate  = SYSDATE() , updId   = :f_user_id , modifyFlg = :modifyFlg  WHERE hospCode    = :f_hosp_code "
			+ "AND hangmogCode = :f_hangmog_code  AND hangmogStartDate = :f_hangmog_start_date AND ordDanui    = :f_ord_danui  ")
	public Integer updateOCS0103U00(@Param("f_hosp_code") String hospCode,
			@Param("f_change_qty1") Double changeQty1,
			@Param("f_change_qty2") Double changeQty2,
			@Param("f_user_id") String updId,
			@Param("modifyFlg") String modifyFlg,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_ord_danui") String ordDanui);
	
}

