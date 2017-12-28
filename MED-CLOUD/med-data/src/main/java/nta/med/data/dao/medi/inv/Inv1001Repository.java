package nta.med.data.dao.medi.inv;

import nta.med.core.domain.inv.Inv1001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv1001Repository extends JpaRepository<Inv1001, Long>, Inv1001RepositoryCustom {
	@Modifying
	@Query("DELETE Inv1001 WHERE hospCode = :f_hosp_code AND pkinv1001  = :f_pkinv1001")
	public Integer deleteINV1001ByPkinv1001(@Param("f_hosp_code") String hospCode,@Param("f_pkinv1001") Double pkinv1001);
	
	@Modifying
	@Query("UPDATE Inv1001 SET updId = :f_upd_id, updDate   = SYSDATE()  , "
			+ "jaeryoCode  = :f_jaeryo_code, suryang   = :f_subul_suryang , "
			+ "ordDanui = :f_subul_danui, nalsu   = :f_nalsu "
			+ " WHERE hospCode = :f_hosp_code AND pkinv1001  = :f_pkinv1001")
	public Integer updateInv1001(@Param("f_hosp_code") String hospCode,@Param("f_upd_id") String updId,
			@Param("f_jaeryo_code") String jaeryoCode,@Param("f_subul_suryang") Double suryang,@Param("f_subul_danui") String ordDanui,
			@Param("f_nalsu") Double nalsu,@Param("f_pkinv1001") Double pkinv1001);
	
	@Modifying
	@Query("DELETE Inv1001 WHERE hospCode = :f_hosp_code AND fkocs1003  = :fkocs1003")
	public Integer deleteINV1001ByFkocs1003(@Param("f_hosp_code") String hospCode, @Param("fkocs1003") Double fkocs1003);
	
	@Modifying
	@Query("UPDATE Inv1001 SET updId = :f_upd_id, "
			+ " updDate   = SYSDATE()  , "
			+ " jaeryoCode  = :f_jaeryo_code, "
			+ " inOutGubun  = :inOutGubun, "
			+ " inputPart  = :inputPart, "
			+ " subulBuseo  = :subulBuseo, "
			+ "suryang   = :f_subul_suryang , "
			+ "dvTime   = :dvTime, "
			+ "dv   = :dv, "
			+ "ordDanui = :f_subul_danui, "
			+ "nalsu   = :f_nalsu, "
			+ "actBuseo   = :actBuseo "
			+ " WHERE hospCode = :f_hosp_code AND fkocs1003  = :fkocs1003")
	public Integer updateInv1001ByFkocs1003(@Param("f_hosp_code") String hospCode, 
			@Param("f_upd_id") String updId,
			@Param("f_jaeryo_code") String jaeryoCode, 
			@Param("inOutGubun") String inOutGubun,
			@Param("inputPart") String inputPart, 
			@Param("subulBuseo") String subulBuseo, 
			@Param("f_subul_suryang") Double suryang, 
			@Param("dvTime") String dvTime, 
			@Param("dv") Double dv, 
			@Param("f_subul_danui") String ordDanui,
			@Param("f_nalsu") Double nalsu,
			@Param("actBuseo") String actBuseo, 
			@Param("fkocs1003") Double fkocs1003);
}

