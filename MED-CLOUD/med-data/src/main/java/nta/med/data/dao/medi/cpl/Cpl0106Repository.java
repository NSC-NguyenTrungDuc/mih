package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl0106;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0106Repository extends JpaRepository<Cpl0106, Long>, Cpl0106RepositoryCustom {
	@Modifying                                                 
	@Query("UPDATE Cpl0106                                     " +
			"   SET updId           = :updId                   " +
			"     , updDate         = :updDate                 " +
			"     , subSpecimenCode = :subSpecimenCode         " +
			"     , subEmergency    = :subEmergency            " +  
			"     , continueYn      = :continueYn              " +  
			"     , modifyFlg       = :modifyFlg               " +  
			" WHERE hospCode        = :hospCode                " +
			"   AND groupGubun      = :groupGubun              " +
			"   AND hangmogCode     = :hangmogCode             " + 
			"   AND specimenCode    = :specimenCode            " +
			"   AND emergency       = IFNULL(:emergency, 'N')  " +
			"   AND subHangmogCode  = :subHangmogCode          " )
	public Integer updateCpl0106(
			@Param("updId") String updId  ,
			@Param("updDate") Date updDate,
			@Param("subSpecimenCode") String subSpecimenCode,
			@Param("subEmergency") String subEmergency,
			@Param("continueYn") String continueYn,
			@Param("modifyFlg") String modifyFlg,
			@Param("hospCode") String hospCode,
			@Param("groupGubun") String groupGubun,
			@Param("hangmogCode") String hangmogCode,
			@Param("specimenCode") String specimenCode,
			@Param("emergency") String emergency,
			@Param("subHangmogCode") String subHangmogCode);
	
	@Modifying
	@Query(" DELETE FROM Cpl0106                           "+
			" WHERE hospCode        = :hospCode            " +
			"   AND groupGubun      = :groupGubun          " +
			"   AND hangmogCode     = :hangmogCode         " + 
			"   AND specimenCode    = :specimenCode        " +
			"   AND emergency       = IFNULL(:emergency, 'N') " +
			"   AND subHangmogCode  = :subHangmogCode      " )
	public Integer deleteCpl0106(
		@Param("hospCode") String hospCode,
		@Param("groupGubun") String groupGubun,
		@Param("hangmogCode") String hangmogCode,
		@Param("specimenCode") String specimenCode,
		@Param("emergency") String emergency,
		@Param("subHangmogCode") String subHangmogCode);
}

