package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0101Repository extends JpaRepository<Cpl0101, Long>, Cpl0101RepositoryCustom {
	
	@Modifying                                            
	@Query("  UPDATE Cpl0101                              "
			+"   SET updId           = :updId             "
			+"     , updDate         = SYSDATE()          "
			+"     , jukyongDate     = :jukyongDate       "
			+"     , specimenCode    = :specimenCode      "
			+"     , emergency       = :emergency         "
			+"     , defaultYn       = :defaultYn         "
			+"     , jundalGubun     = :jundalGubun       "          
			+"     , danui           = :danui             "
			+"     , tubeCode        = :tubeCode          "
			+"     , uitakCode       = :uitakCode         "            
			+"     , sutakCode       = :sutakCode         "              
			+"     , slipCode        = :slipCode          "             
			+"     , jangbiCode      = :jangbiCode        "
			+"     , jangbiOutCode   = :jangbiOutCode     "
			+"     , jangbiCode2     = :jangbiCode2       "
			+"     , jangbiOutCode2  = :jangbiOutCode2    "
			+"     , jangbiCode3     = :jangbiCode3       "
			+"     , jangbiOutCode3  = :jangbiOutCode3    "
			+"     , groupGubun      = :groupGubun        "
			+"     , gumsaNameRe     = :gumsaNameRe       "
			+"     , barcode         = :barcode           "
			+"     , gumsaName       = :gumsaName         "
			+"     , defaultResult   = :defaultResult     "
			+"     , medicalJundal   = :medicalJundal     "
			+"     , commentJuCode   = :commentJuCode     "
			+"     , serial          = :serial            "
			+"     , chubangYn       = :chubangYn         "
			+"     , resultYn        = :resultYn          "
			+"     , resultForm      = :resultForm        "
			+"     , tongGubun       = :tongGubun         "
			+"     , specimenAmt     = :specimenAmt       "
			+"     , oldSlipCode     = :oldSlipCode       "
			+"     , detailInfo      = :detailInfo        "
			+"     , displayYn       = :displayYn         "
			+"     , jundalGubunName = :jundalGubunName   "
			+"     , spcialName      = :spcialName        "
			+"     , tongSerial      = :tongSerial        "
			+"     , point            = :point            "
			+"     , point2           = :point2           "
			+"     , point3           = :point3           "
			+"     , outTube         = :outTube           "
			+"     , outTube2        = :outTube2          "
			+"     , hangmogMarkName= :hangmogMarkName    "
			+"     , middleResult    = :middleResult      "
			+"     , userGubun       = :userGubun         "
			+"     , modifyFlg     	  = :modifyFlg        "
			+"  WHERE hospCode        = :hospCode         "
			+"   AND hangmogCode     = :hangmogCode       ")
	public Integer updateCPL0101U000101(
			@Param("updId") String updId,
			@Param("jukyongDate") Date jukyongDate,
			@Param("specimenCode") String specimenCode,
			@Param("emergency") String emergency,
			@Param("defaultYn") String defaultYn,
			@Param("jundalGubun") String jundalGubun,
			@Param("danui") String danui,
			@Param("tubeCode") String tubeCode,
			@Param("uitakCode") String uitakCode,
			@Param("sutakCode") String sutakCode,
			@Param("slipCode") String slipCode,
			@Param("jangbiCode") String jangbiCode,
			@Param("jangbiOutCode") String jangbiOutCode,
			@Param("jangbiCode2") String jangbiCode2,
			@Param("jangbiOutCode2") String jangbiOutCode2,
			@Param("jangbiCode3") String jangbiCode3,
			@Param("jangbiOutCode3") String jangbiOutCode3,
			@Param("groupGubun") String groupGubun,
			@Param("gumsaNameRe") String gumsaNameRe,
			@Param("barcode") String barcode,
			@Param("gumsaName") String gumsaName,
			@Param("defaultResult") String defaultResult,
			@Param("medicalJundal") String medicalJundal,
			@Param("commentJuCode") String commentJuCode,
			@Param("serial") Double serial,
			@Param("chubangYn") String chubangYn,
			@Param("resultYn") String resultYn,
			@Param("resultForm") String resultForm,
			@Param("tongGubun") String tongGubun,
			@Param("specimenAmt") Double specimenAmt,
			@Param("oldSlipCode") String oldSlipCode,
			@Param("detailInfo") String detailInfo,
			@Param("displayYn") String displayYn,
			@Param("jundalGubunName") String jundalGubunName,
			@Param("spcialName") String spcialName,
			@Param("tongSerial") Double tongSerial,
			@Param("point") Double point,
			@Param("point2") Double point2,
			@Param("point3") Double point3,
			@Param("outTube") String outTube,
			@Param("outTube2") String outTube2,
			@Param("hangmogMarkName") String hangmogMarkName,
			@Param("middleResult") String middleResult,
			@Param("userGubun") String userGubun,
			@Param("modifyFlg") String modifyFlg,
			@Param("hospCode") String hospCode,
			@Param("hangmogCode") String hangmogCode);
	
	
	@Modifying
	@Query("DELETE Cpl0101 WHERE hospCode = :hospCode"
			+ " AND hangmogCode     = :hangmogCode")
	public Integer deleteCPL0101U00(@Param("hospCode") String hospCode,
			@Param("hangmogCode") String hangmogCode);
}

