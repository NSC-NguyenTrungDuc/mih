package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0303;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0303Repository extends JpaRepository<Ocs0303, Long>, Ocs0303RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Ocs0303 WHERE hospCode = :hospCode AND pkocs0303 = :pkocs0303 ")
	public Integer deleteOcs0301u00(@Param("hospCode") String hospCode, @Param("pkocs0303") Double pkocs0303);
	
	@Query("Select MAX(ocs.seq) + 1 FROM Ocs0303 ocs WHERE ocs.hospCode =:hospCode AND ocs.memb =:memb "
			+ "AND ocs.yaksokCode =:yaksokCode AND ocs.fkocs0300Seq = :fkocs0300Seq ")
	public Double getMaxSeqByYakSokCodeAndFkocs0300Seq(
			@Param("hospCode") String hospCode,
			@Param("memb") String memb,
			@Param("yaksokCode") String yaksokCode,
			@Param("fkocs0300Seq") Double fkocs0300Seq);
	
	@Query("Select ocs FROM Ocs0303 ocs WHERE ocs.hospCode =:hospCode AND ocs.pkocs0303 = :pkocs0303 ")
	public List<Ocs0303> findByPkocs0303(
			@Param("hospCode") String hospCode,
			@Param("pkocs0303") Double pkocs0303);
	
	@Modifying
	@Query("UPDATE Ocs0303 SET updDate = :updDate "
			+ "		 , updId = :updId "
			+ "      , ndayYn = :ndayYn "
			+ "		 , suryang = :suryang "
			+ "		 , nalsu            = :nalsu "
			+ "      , jusa             = :jusa "
			+ "      , bogyongCode     = :bogyongCode "
            + "      , emergency        = :emergency "
            + "      , muhyo            = :muhyo "
            + "      , powderYn        = :powderYn "
            + "      , dv1             = :dv1 "
            + "      , dv2             = :dv2 "
            + "      , dv3             = :dv3 "
            + "      , dv4             = :dv4 "
            + "      , dv5             = :dv5 "
            + "      , dv6             = :dv6 "
            + "      , dv7             = :dv7 "
            + "      , dv8             = :dv8 "
            + "      , mixGroup        = :mixGroup "
            + "      , orderRemark     = :orderRemark "
            + "      , nurseRemark     = :nurseRemark "
            + "      , wonyoiOrderYn  = :wonyoiOrderYn "
            + "      , bomSourceKey   = :bomSourceKey "
            + "      , hubalChangeYn  = :hubalChangeYn "
            + "      , pharmacy         = :pharmacy "
            + "      , jusaSpdGubun   = :jusaSpdGubun "
            + "      , drgPackYn      = :drgPackYn "
            + "      , dangilGumsaOrderYn = :dangilGumsaOrderYn "
            + "      , dangilGumsaResultYn = :dangilGumsaResultYn "
            + "      , dvTime          = :dvTime "
            + "      , dv               = :dv "
            + "      , ordDanui        = :ordDanui "
            + "      , specimenCode    = :specimenCode "
            + "      , jundalTableOut = :jundalTableOut "
            + "      , jundalPartOut  = :jundalPartOut "
            + "      , jundalTableInp = :jundalTableInp "
            + "      , jundalPartInp  = :jundalPartInp "
            + "      , movePartOut    = :movePartOut "
            + "      , movePartInp    = :movePartInp "
            + "      , generalDispYn  = :generalDispYn "
            + "      , seq              = :seq "
            + "  WHERE hospCode = :hospCode "
            + "    AND pkocs0303 = :pkocs0303 ")
	public Integer updateOcs0301u00(@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("ndayYn") String ndayYn,
			@Param("suryang") Double suryang,
			@Param("nalsu") Double nalsu,
			@Param("jusa") String jusa,
			@Param("bogyongCode") String bogyongCode,
			@Param("emergency") String emergency,
			@Param("muhyo") String muhyo,
			@Param("powderYn") String powderYn,
			@Param("dv1") Double dv1,
			@Param("dv2") Double dv2,
			@Param("dv3") Double dv3,
			@Param("dv4") Double dv4,
			@Param("dv5") Double dv5,
			@Param("dv6") Double dv6,
			@Param("dv7") Double dv7,
			@Param("dv8") Double dv8,
			@Param("mixGroup") String mixGroup,
			@Param("orderRemark") String orderRemark,
			@Param("nurseRemark") String nurseRemark,
			@Param("wonyoiOrderYn") String wonyoiOrderYn,
			@Param("bomSourceKey") Double bomSourceKey,
			@Param("hubalChangeYn") String hubalChangeYn,
			@Param("pharmacy") String pharmacy,
			@Param("jusaSpdGubun") String jusaSpdGubun,
			@Param("drgPackYn") String drgPackYn,
			@Param("dangilGumsaOrderYn") String dangilGumsaOrderYn,
			@Param("dangilGumsaResultYn") String dangilGumsaResultYn,
			@Param("dvTime") String dvTime,
			@Param("dv") Double dv,
			@Param("ordDanui") String ordDanui,
			
			@Param("specimenCode") String specimenCode,
			@Param("jundalTableOut") String jundalTableOut,
			@Param("jundalPartOut") String jundalPartOut,
			@Param("jundalTableInp") String jundalTableInp,
			@Param("jundalPartInp") String jundalPartInp,
			@Param("movePartOut") String movePartOut,
			@Param("movePartInp") String movePartInp,
			@Param("generalDispYn") String generalDispYn,
			@Param("seq") Double seq,
			@Param("hospCode") String hospCode,
			@Param("pkocs0303") Double pkocs0303
			);
}

