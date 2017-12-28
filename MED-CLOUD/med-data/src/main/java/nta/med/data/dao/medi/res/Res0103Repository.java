package nta.med.data.dao.medi.res;

import java.util.Date;

import nta.med.core.domain.res.Res0103;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0103Repository extends JpaRepository<Res0103, Long>, Res0103RepositoryCustom {
	@Modifying
	@Query("DELETE Res0103 WHERE hospCode = :hospCode "
			+ "AND doctor = :doctor "
			+ "AND jinryoPreDate = DATE_FORMAT(:jinryoPreDate, '%Y/%m/%d') "
			+ "AND resAmStartHhmm IS NULL "
			+ "AND resAmEndHhmm   IS NULL "
			+ "AND resPmStartHhmm IS NULL "
			+ "AND resPmEndHhmm   IS NULL "
			+ "AND (amStartHhmm IS NOT NULL OR pmStartHhmm IS NOT NULL)")
	public Integer deleteRES0104Request1(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("jinryoPreDate") String jinryoPreDate);
	
	@Modifying
	@Query("DELETE Res0103 WHERE hospCode = :hospCode "
			+ "AND doctor = :doctor "
			+ "AND jinryoPreDate = DATE_FORMAT(:jinryoPreDate, '%Y/%m/%d') "
			+ "AND amStartHhmm IS NULL "
			+ "AND amEndHhmm   IS NULL "
			+ "AND pmStartHhmm IS NULL "
			+ "AND pmEndHhmm   IS NULL "
			+ "AND (resAmStartHhmm IS NOT NULL OR resPmStartHhmm IS NOT NULL)")
	public Integer deleteRES0104Request2(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("jinryoPreDate") String jinryoPreDate);
	
	@Modifying
	@Query(" UPDATE Res0103 "
			+ " SET updId = :updId, "
			+ " updDate   = :updDate, "
			+ " amStartHhmm   = :amStartHhmm  , "
			+ " amEndHhmm     = :amEndHhmm    , "
			+ " pmStartHhmm   = :pmStartHhmm  , "
			+ " pmEndHhmm     = :pmEndHhmm    , "
			+ " remark          = :remark         , "
			+ " amGwaRoom     = :amGwaRoom    , "
			+ " pmGwaRoom     = :pmGwaRoom "
			+ " WHERE hospCode       = :hospCode "
			+ " AND doctor          = :doctor "
			+ " AND jinryoPreDate = :jinryoPreDate ) "
			+ " AND resAmStartHhmm IS NULL "
			+ " AND resAmEndHhmm   IS NULL "
			+ " AND resPmStartHhmm IS NULL "
			+ " AND resPmEndHhmm   IS NULL "
			+ " AND (amStartHhmm IS NOT NULL OR pmStartHhmm IS NOT NULL) ")
	public Integer updateRES0103Request1(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("amStartHhmm") String amStartHhmm,
			@Param("amEndHhmm") String amEndHhmm,
			@Param("pmStartHhmm") String pmStartHhmm,
			@Param("pmEndHhmm") String pmEndHhmm,
			@Param("remark") String remark,
			@Param("amGwaRoom") String amGwaRoom,
			@Param("pmGwaRoom") String pmGwaRoom,
			@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("jinryoPreDate") Date jinryoPreDate);
	
	@Modifying
	@Query(" UPDATE Res0103 "
			+ " SET updId              = :updId        , "
			+ " updDate            = :updDate         , "
			+ " resAmStartHhmm   = :resAmStartHhmm  , "
			+ " resAmEndHhmm     = :resAmEndHhmm    , "
			+ " resPmStartHhmm   = :resPmStartHhmm  , "
			+ " resPmEndHhmm     = :resPmEndHhmm    , "
			+ " remark              = :remark "
			+ " WHERE hospCode           = :hospCode "
			+ " AND doctor              = :doctor "
			+ " AND jinryoPreDate     = :jinryoPreDate "
			+ " AND amStartHhmm IS NULL "
			+ " AND amEndHhmm   IS NULL "
			+ " AND pmStartHhmm IS NULL "
			+ " AND pmEndHhmm   IS NULL "
			+ " AND (resAmStartHhmm IS NOT NULL OR resPmStartHhmm IS NOT NULL) ")
	public Integer updateRES0103Request2(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("resAmStartHhmm") String resAmStartHhmm,
			@Param("resAmEndHhmm") String resAmEndHhmm,
			@Param("resPmStartHhmm") String resPmStartHhmm,
			@Param("resPmEndHhmm") String resPmEndHhmm,
			@Param("remark") String remark,
			@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("jinryoPreDate") Date jinryoPreDate);
	
}

