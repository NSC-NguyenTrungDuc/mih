package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0118;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0118Repository extends JpaRepository<Ocs0118, Long>, Ocs0118RepositoryCustom {
	@Modifying
	@Query(" UPDATE Ocs0118									  "
		  +"   SET updId        = :updId	                  " 
		  +"     , updDate      = SYSDATE()                 " 
		  +"     , convHangmog  = :convHangmog             " 
		  +"     , startDate    = :startDate               " 
		  +"     , remark       = :remark                  " 
		  +" WHERE convClass    = :convClass               " 
		  +"   AND convGubun    = :convGubun               " 
		  +"   AND hangmogCode  = :hangmogCode             " 
		  +"   AND hospCode     = :hospCode                ")
	public Integer updateOCS0118U00GrdSaveLayout(
			@Param("updId") String updId,
			@Param("convHangmog") String convHangmog,
			@Param("startDate") Date startDate,
			@Param("remark") String remark,
			@Param("convClass") String convClass,
			@Param("convGubun") String convGubun,
			@Param("hangmogCode") String hangmogCode,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("	DELETE Ocs0118								  "
			+"	  WHERE convClass   = :convClass              "
			+"	  AND convGubun   = :convGubun                "
			+"	  AND hangmogCode = :hangmogCode              "
			+"	  AND hospCode    = :hospCode                   ")
	public Integer deleteOCS0118U00GrdSaveLayout(
			@Param("convClass") String convClass,
			@Param("convGubun") String convGubun,
			@Param("hangmogCode") String hangmogCode,
			@Param("hospCode") String hospCode);
}

