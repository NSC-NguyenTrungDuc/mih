package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs1023;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1023Repository extends JpaRepository<Ocs1023, Long>, Ocs1023RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ocs1023								   "		
			+"	  SET updId           = :updId                "
			+"	      , updDate         = :updDate             "
			+"	      , seq              = :seq                "
			+"	      , specimenCode    = :specimenCode        "
			+"	      , suryang          = :suryang            "
			+"	      , ordDanui        = :ordDanui            "
			+"	      , dvTime          = :dvTime              "
			+"	      , dv               = :dv                 "
			+"	      , dv1             = :dv1                 "
			+"	      , dv2             = :dv2                 "
			+"	      , dv3             = :dv3                 "
			+"	      , dv4             = :dv4                 "
			+"	      , nalsu            = :nalsu              "
			+"	      , jusa             = :jusa               "
			+"	      , bogyongCode     = :bogyongCode         "
			+"	      , portableYn      = :portableYn          "
			+"	      , antiCancerYn   = :antiCancerYn         "
			+"	      , powderYn        = :powderYn            "
			+"	WHERE pkocs1023        = :pkocs1023	          "
			+ " AND   hospCode         = :hospCode            ")
	public Integer updateOcs1023U00(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("seq") Double seq,
			@Param("specimenCode") String specimenCode,
			@Param("suryang") Double suryang,
			@Param("ordDanui") String ordDanui,
			@Param("dvTime") String dvTime,
			@Param("dv") Double dv,
			@Param("dv1") Double dv1,
			@Param("dv2") Double dv2,
			@Param("dv3") Double dv3,
			@Param("dv4") Double dv4,
			@Param("nalsu") Double nalsu,
			@Param("jusa") String jusa,
			@Param("bogyongCode") String bogyongCode,
			@Param("portableYn") String portableYn,
			@Param("antiCancerYn") String antiCancerYn,
			@Param("powderYn") String powderYn,
			@Param("pkocs1023") Double pkocs1023,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query(" DELETE Ocs1023                     "
		  +"	WHERE pkocs1023 = :pkocs1023    "
		  +"	AND hospCode = :hospCode        ")
	public Integer deleteOcs1023U00(
			@Param("pkocs1023") Double pkocs1023,
			@Param("hospCode") String hospCode);
	
}

