package nta.med.data.dao.medi.xrt;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.xrt.Xrt0123;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0123Repository extends JpaRepository<Xrt0123, Long>, Xrt0123RepositoryCustom {
	@Query("SELECT DISTINCT 'X' FROM Xrt0123 WHERE hospCode = :hospCode AND xrayGubun = :xrayGubun AND buwiCode = :buwiCode")
	public String checkExistByXrayGubunAndBuwiCode (
			@Param("hospCode") String hospCode, 
			@Param("xrayGubun") String xrayGubun, 
			@Param("buwiCode") String buwiCode);
	
	@Modifying
	@Query("UPDATE Xrt0123                     " + 
		 "  SET updId          = :updId        " + 
		 "    , updDate        = :updDate      " + 
		 "    , valtage        = :valtage      " + 
		 "    , curElectric    = :curElectric  " + 
		 "    , time           = :time         " + 
		 "    , distance       = :distance     " + 
		 "    , grid           = :grid         " + 
		 "    , note           = :note         " + 
		 "    , fromAge        = :fromAge      " + 
		 "    , toAge          = :toAge        " + 
		 "    , masVal         = :masVal       " + 
		 "WHERE hospCode       = :hospCode     " + 
		 "  AND xrayGubun      = :xrayGubun    " + 
		 "  AND buwiCode       = :buwiCode     ")
	public Integer updateXrt0123 (
			@Param("updId") String updId, 
			@Param("updDate") Date updDate, 
			@Param("valtage") Double valtage,
			@Param("curElectric") Double curElectric,
			@Param("time") Double time,
			@Param("distance") Double distance,
			@Param("grid") String grid,
			@Param("note") String note,
			@Param("fromAge") Double fromAge,
			@Param("toAge") Double toAge,
			@Param("masVal") Double masVal,
			@Param("hospCode") String hospCode,
			@Param("xrayGubun") String xrayGubun,
			@Param("buwiCode") String buwiCode
			);

	@Modifying
	@Query("DELETE FROM Xrt0123                " + 
		 "WHERE hospCode       = :hospCode     " + 
		 "  AND xrayGubun      = :xrayGubun    " + 
		 "  AND buwiCode       = :buwiCode     ")
	public Integer deleteXrt0123 (
			@Param("hospCode") String hospCode,
			@Param("xrayGubun") String xrayGubun,
			@Param("buwiCode") String buwiCode
			);
	
	@Query("SELECT a FROM Xrt0123 a WHERE hospCode = :f_hosp_code AND buwiCode = :f_buwi_code "
			+ "AND :f_age BETWEEN fromAge AND toAge AND xrayGubun = :f_xray_gubun")
	public List<Xrt0123> getXRT1002U00LayXRT0123Info(@Param("f_hosp_code") String hospCode,
			@Param("f_buwi_code") String buwiCode,
			@Param("f_age") Double age,
			@Param("f_xray_gubun") String xrayGubun); 
}

