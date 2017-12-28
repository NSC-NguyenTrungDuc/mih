package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0271;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0271Repository extends JpaRepository<Bas0271, Long>, Bas0271RepositoryCustom {
	@Query("SELECT DISTINCT a.doctorName FROM Bas0271 a WHERE a.hospCode = :hospCode AND STR_TO_DATE(:doctorYmd, '%Y/%m/%d') "
			+ "BETWEEN a.startDate AND a.endDate AND a.doctor = :doctor ")
	public List<String> getBAS0270LayDoctorName(
			@Param("hospCode") String hospCode,
			@Param("doctorYmd") String doctorYmd,
			@Param("doctor") String doctor);
	
	@Query("SELECT DISTINCT 'Y' FROM Bas0271 a WHERE a.hospCode = :hospCode AND "
			+ " a.doctor = :doctor AND a.startDate = STR_TO_DATE(:doctorYmd, '%Y/%m/%d') ")
	public List<String> getBAS0270LayDupCheckRequest(
			@Param("hospCode") String hospCode,
			@Param("doctorYmd") String doctorYmd,
			@Param("doctor") String doctor);
	
	@Modifying
	@Query("UPDATE Bas0271                           " +
			"  SET updId          = :updId            " +
			"    , updDate        = :updDate          " +
			"    , doctorName     = :doctorName       " +
			"    , doctorGrade    = :doctorGrade      " +
			"    , reserYn        = :reserYn          " +
			"    , endDate        = :endDate          " +
			"    , licenseBunho   = :licenseBunho     " +
			"    , sabun          = :sabun            " +
			"    , ocsStatus      = :ocsStatus        " +
			"    , jubsuYn        = :jubsuYn          " +
			"    , doctorSign     = :doctorSign       " +
			"    , cpDoctorYn     = :cpDoctorYn       " +
			"    , doctorName2    = :doctorName2      " +
			"    , mayakLicense   = :mayakLicense     " +
			"    , tonggyeDoctor  = :tonggyeDoctor    " +
			"    , commonDoctorYn = :commonDoctorYn   " +
			"    , doctorColor    = :doctorColor      " +
			"WHERE hospCode       = :hospCode         " +
			"  AND doctor         = :doctor           " +
			"  AND DATE_FORMAT(startDate, '%Y/%m/%d') = :startDate  ")
	public Integer updateBas0271(
			@Param("hospCode") String hospCode,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("doctorName") String doctorName,
			@Param("doctorGrade") String doctorGrade,
			@Param("reserYn") String reserYn,
			@Param("endDate") Date endDate,
			@Param("licenseBunho") String licenseBunho,
			@Param("sabun") String sabun,
			@Param("ocsStatus") String ocsStatus,
			@Param("jubsuYn") String jubsuYn,
			@Param("doctorSign") String doctorSign,
			@Param("cpDoctorYn") String cpDoctorYn,
			@Param("doctorName2") String doctorName2,
			@Param("mayakLicense") String mayakLicense,
			@Param("tonggyeDoctor") String tonggyeDoctor,
			@Param("commonDoctorYn") String commonDoctorYn,
			@Param("doctorColor") String doctorColor,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate
			);
	
	@Modifying
	@Query("DELETE FROM Bas0271                       " +
			"WHERE hospCode       = :hospCode         " +
			"  AND doctor         = :doctor           " +
			"  AND DATE_FORMAT(startDate, '%Y/%m/%d') = :startDate  ")
	public Integer deleteBas0271(
			@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("startDate") String startDate
			);
	
	@Query("SELECT DISTINCT 'Y' FROM Bas0271 a WHERE a.hospCode = :hospCode AND "
			+ " a.doctor = :doctor AND a.sabun = :sabun ")
	public List<String> checkDoctorExistInBas0271(
			@Param("hospCode") String hospCode,
			@Param("sabun") String sabun,
			@Param("doctor") String doctor);
}

