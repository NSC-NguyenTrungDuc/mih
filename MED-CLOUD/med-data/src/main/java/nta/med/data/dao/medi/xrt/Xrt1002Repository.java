package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.core.domain.xrt.Xrt1002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt1002Repository extends JpaRepository<Xrt1002, Long>, Xrt1002RepositoryCustom {
	@Query("select a from Xrt1002 a WHERE a.hospCode = :hospCode AND a.fkocs = :fkocs")
	public List<Xrt1002> getByFkOcs(@Param("hospCode") String hospCode, @Param("fkocs")Double fkocs);
	
	@Query("SELECT 'Y' FROM Xrt1002 A  WHERE A.fkocs  = :f_fkocs  AND A.hospCode = :f_hosp_code")
	public List<String> getCheckY(@Param("f_hosp_code") String hospCode, @Param("f_fkocs") Double fkocs);
	
	@Modifying
	@Query(" UPDATE Xrt1002 SET updId   = :f_upd_id , "
			+ "updDate  = SYSDATE()  , inOutGubun  = :f_in_out_gubun , "
			+ "hangmogCode = :f_hangmog_code  , bunho = :f_bunho , "
			+ "gumsaMokjuk = :f_gumsa_mokjuk  , xrayMethod  = :f_xray_method  , "
			+ "pandokRequestYn = :f_pandok_request_yn "
			+ " WHERE fkocs  = :f_fkocs AND hospCode  = :f_hosp_code ")
	public Integer updateXrt1002(@Param("f_hosp_code") String hospCode, @Param("f_upd_id") String updId,
			@Param("f_in_out_gubun") String inOutGubun, @Param("f_hangmog_code") String hangmogCode,
			@Param("f_bunho") String bunho, @Param("f_gumsa_mokjuk") String gumsaMokjuk,
			@Param("f_xray_method") String xrayMethod, @Param("f_pandok_request_yn") String pandokRequestYn,
			@Param("f_fkocs") Double fkocs);
	
	@Modifying
	@Query("DELETE Xrt1002 WHERE hospCode = :hospCode AND fkocs = :fkocs")
	public Integer deleteXRT1002U00BtnDeleteClick(@Param("hospCode") String hospCode, @Param("fkocs")Double fkocs);
}

