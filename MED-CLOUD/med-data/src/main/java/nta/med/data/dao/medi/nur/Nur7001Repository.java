package nta.med.data.dao.medi.nur;

import java.math.BigDecimal;
import java.util.Date;

import nta.med.core.domain.nur.Nur7001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur7001Repository extends JpaRepository<Nur7001, Long>, Nur7001RepositoryCustom {
	@Query("SELECT IFNULL(MAX(seq), 0) + 1  FROM Nur7001 WHERE hospCode = :hospCode AND bunho = :bunho AND measureDate = STR_TO_DATE(:measureDate, '%Y/%m/%d')")
	public String getNuriNUR7001U00GetMaxSeqInNUR7001(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("measureDate") String measureDate);
	
	@Modifying
	@Query("  UPDATE Nur7001                                            "
			+"SET updId       = :updId        ,                         "  
			+"    updDate     = :updDate      ,                         "
			+"    bunho       = :bunho        ,                         "
			+"    measureDate = :measureDate  ,                         "
			+"    seq         = :seq          ,                         "
			+"    vald         ='Y'           ,                         "
			+"    height      = :height       ,                         "
			+"    weight      = :weight       ,                         "
			+"    bpFrom      = :bpFrom       ,                         "
			+"    bpTo        = :bpTo         ,                         "
			+"    bodyHeat    = :bodyHeat     ,                         "
			+"    pulse       = :pulse        ,                         "
			+"    spo2        = :spo2         ,                         "
			+"    measureTime = :measureTime  ,                         "
			+"    breath      = :breath                                 "
			+"WHERE hospCode    = :hospCode                             "
			+"AND bunho       = :bunho                                  "
			+"AND measureDate = :measureDate                            "
			+"AND seq          = :seq                                   ")
	public Integer updateNUR7001(@Param("hospCode") String hospCode,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("bunho") String bunho,
			@Param("measureDate") Date measureDate,
			@Param("seq") Double seq,
			@Param("height") Double height,
			@Param("weight") Double weight,
			@Param("bpFrom") Double bpFrom,
			@Param("bpTo") Double bpTo,
			@Param("bodyHeat") Double bodyHeat,
			@Param("pulse") BigDecimal pulse,
			@Param("spo2") Double spo2,
			@Param("measureTime") String measureTime,
			@Param("breath") Double breath);
	
	@Modifying
	@Query("UPDATE Nur7001 "
			+"  SET updId       = :updId,                              "
			+"      updDate     = :updDate,                            "
			+"      vald        ='N'                                   "
			+"WHERE hospCode    = :hospCode                            "
			+"  AND bunho       = :bunho                               "
			+"  AND measureDate  = :measureDate                        "
			+"  AND seq         = :seq                                ")
	public Integer updateValidStatusNUR7001(@Param("hospCode") String hospCode,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("bunho") String bunho,
			@Param("measureDate") Date measureDate,
			@Param("seq") Double seq);
}

