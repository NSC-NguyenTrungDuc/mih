package nta.med.data.dao.medi.res;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.res.Res0102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0102Repository extends JpaRepository<Res0102, Long>, Res0102RepositoryCustom {
	
	
/*	@Modifying
	@Query("DELETE Res0102 WHERE hospCode = :hospCode AND doctor = :doctor "
			+ "AND startDate > STR_TO_DATE(:startDate, '%Y/%m/%d') AND OUT_HOSP_YN = :outHospYn ")
	public Integer deleteRES0102(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate,
			@Param("outHospYn") String outHospYn);*/
	
	/*@Modifying
	@Query("UPDATE Res0102 SET endDate = :startDate "
			+ "WHERE hospCode  = :hospCode "
			+ "AND doctor     = :doctor "
			+ "AND DATE_FORMAT(endDate, '%Y/%m/%d') = DATE_FORMAT('9998/12/31', '%Y/%m/%d') AND OUT_HOSP_YN = :outHospYn")
	public Integer updateRES0102Request1(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") Date startDate,
			@Param("outHospYn") String outHospYn);*/
	
	@Modifying
	@Query("DELETE Res0102 WHERE hospCode = :hospCode AND doctor = :doctor "
			+ "AND startDate > STR_TO_DATE(:startDate, '%Y/%m/%d') ")
	public Integer deleteRES0102(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate);

	//+ " ANDDATE_FORMAT(endDate, '%Y/%m/%d') = DATE_FORMAT('9998/12/31', '%Y/%m/%d') 		")
	@Modifying
	@Query("    UPDATE Res0102 SET endDate = :startDate 											"
			+ " WHERE hospCode  = :hospCode 														"
			+ " AND doctor     = :doctor 															"
			+ " AND DATE_FORMAT(endDate, '%Y/%m/%d') > DATE_FORMAT(:startDate, '%Y/%m/%d') 	    ")
	public Integer updateRES0102Request1(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") Date startDate);
	
	@Modifying
	@Query("UPDATE Res0102 SET endDate = STR_TO_DATE('9998/12/31', '%Y/%m/%d') "
			+ "WHERE hospCode  = :hospCode "
			+ "AND doctor     = :doctor "
			+ "AND DATE_FORMAT(endDate, '%Y/%m/%d')    = DATE_FORMAT(:startDate, '%Y/%m/%d') ")
	public Integer updateRES0102Request3(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") Date startDate);
	
/*	@Modifying
	@Query("UPDATE Res0102 SET endDate = STR_TO_DATE('9998/12/31', '%Y/%m/%d') "
			+ "WHERE hospCode  = :hospCode "
			+ "AND doctor     = :doctor "
			+ "AND DATE_FORMAT(endDate, '%Y/%m/%d')    = DATE_FORMAT(:startDate, '%Y/%m/%d')  AND OUT_HOSP_YN = :outHospYn")
	public Integer updateRES0102Request3(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") Date startDate,
			@Param("outHospYn") String outHospYn);*/
	
	@Modifying
	@Query("DELETE Res0102 WHERE hospCode = :hospCode AND doctor = :doctor AND DATE_FORMAT(startDate, '%Y/%m/%d') = DATE_FORMAT(:startDate, '%Y/%m/%d') ")
	public Integer deleteRES0102Req2(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate);
	
/*	@Modifying
	@Query("DELETE Res0102 WHERE hospCode = :hospCode AND doctor = :doctor AND DATE_FORMAT(startDate, '%Y/%m/%d') = DATE_FORMAT(:startDate, '%Y/%m/%d') AND OUT_HOSP_YN = :outHospYn")
	public Integer deleteRES0102Req2(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate,
			@Param("outHospYn") String outHospYn);*/
	
//	@Query("SELECT DATE_FORMAT(CONCAT('resAmStartHhmm', :intweek),'hh24mi') AS AM_START, "
//			+ "DATE_FORMAT(CONCAT('resAmEndHhmm', :intweek),'hh24mi') AS AM_END , "
//			+ "DATE_FORMAT(CONCAT('resPmStartHhmm', :intweek),'hh24mi') AS PM_START, "
//			+ "DATE_FORMAT(CONCAT('resPmEndHhmm', :intweek ),'hh24mi') AS PM_END  , avgTime FROM Res0102 "
//			+ "WHERE doctor = :doctor AND hospCode = :hospCode AND :date BETWEEN startDate AND endDate")
//	public List<OcsaOCS0503U00CreateTimeComboInfo> createTimeComboOCS0503U00(@Param("hospCode") String hospCode,
//			@Param("doctor") String doctor, @Param("intweek") String intweek,@Param("date") Date date);
	@Query("SELECT r FROM Res0102 r WHERE r.hospCode = :hospCode AND r.doctor = :doctor AND :endDate BETWEEN r.startDate AND r.endDate AND IFNULL(r.jinryoBreakYn, 'N') = 'N' ")
	public List<Res0102> getRes0102(@Param("hospCode") String hospCode, @Param("doctor") String doctor, @Param("endDate") Date endDate);
}

