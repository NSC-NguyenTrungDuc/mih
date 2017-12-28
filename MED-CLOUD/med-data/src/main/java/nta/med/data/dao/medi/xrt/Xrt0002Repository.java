package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.core.domain.xrt.Xrt0002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0002Repository extends JpaRepository<Xrt0002, Long>, Xrt0002RepositoryCustom {
//	@Query("SELECT A.xrayCode , A.xrayGubun , A.xrayCodeIdx, A.xrayCodeIdxNm, "
//			+ " A.tubeVol, A.tubeCur, A.xrayTime, A.tubeCurTime, A.irradiationTime, A.xrayDistance FROM Xrt0002 A "
//			+ "WHERE A.hospCode = :f_hosp_code  AND A.xrayCode = :f_xray_code ORDER BY A.xrayGubun, A.xrayCode, A.xrayCodeIdx")
//	public List<XRT0001U00GrdRadioListItemInfo> getXRT0001U00GrdRadioListItemInfo(@Param("f_hosp_code") String hospCode,@Param("f_xray_code") String xrayCode);
	@Modifying
	@Query("DELETE Xrt0002 WHERE hospCode = :f_hosp_code AND xrayCode  = :f_xray_code AND xrayCodeIdx  = :f_xray_code_idx") 
	public Integer deleteXRT0001U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_xray_code") String xrayCode,@Param("f_xray_code_idx") String xrayCodeIdx);
	
	@Query("SELECT xrt FROM Xrt0002 xrt WHERE hospCode = :f_hosp_code AND xrayCode = :f_xray_code AND xrayCodeIdx = :f_xray_code_idx ")
	public List<Xrt0002> getObjectXrt0002ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_xray_code") String xrayCode,@Param("f_xray_code_idx") String xrayCodeIdx);
}

