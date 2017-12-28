package nta.med.data.dao.medi.inv;

import java.math.BigDecimal;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv0001;

@Repository
public interface Inv0001Repository extends JpaRepository<Inv0001, Long>, Inv0001RepositoryCustom {
	@Modifying
	@Query("UPDATE Inv0001 							"
			+ "SET updId = :f_user_id,				"
			+ " activeFlg = :active_flg		    "
			+ "WHERE hospCode = :hosp_code          "
			+ "AND fkocs1003 = :fkocs1003 		    ")
	public Integer updateInv0001(@Param("f_user_id") String updId,
			@Param("active_flg") BigDecimal activeFlg,
			@Param("hosp_code") String hospCode,
			@Param("fkocs1003") Double fkocs1003);
	@Modifying
	@Query(" UPDATE Inv0001 SET activeFlg = :f_active, updId = :f_updId WHERE hospCode = :f_hosp_code AND fkocs1003 = :f_fkocs1003 ")
	public Integer setActiveInv0001(@Param("f_hosp_code") String hospCode, @Param("f_fkocs1003") Double fkocs1003, @Param("f_updId") String updId, @Param("f_active") BigDecimal activeFlg);
	
	@Modifying
	@Query(" UPDATE Inv0001 SET reserveQty = :f_reserveQty WHERE hospCode = :f_hosp_code AND fkocs1003 = :f_fkocs1003 ")
	public Integer updateQTy(@Param("f_reserveQty") Double reserveQty, @Param("f_hosp_code") String hospCode, @Param("f_fkocs1003") Double fkocs1003);
	
	@Query(" select count(*) from Inv0001 where  hospCode = :hospCode and fkocs1003 = :fkocs1003 ")
	public Integer countByHospCodeAndFkOcs1003( @Param("hospCode") String hospCode, @Param("fkocs1003") Double fkocs1003);

}
