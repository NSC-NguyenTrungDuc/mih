package nta.med.data.dao.medi.bas;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.Bas0270;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0270Repository extends JpaRepository<Bas0270, Long>, Bas0270RepositoryCustom {
	@Query("SELECT 'Y' FROM Bas0270 WHERE hospCode = :f_hosp_code AND doctor = :f_doctor AND SYSDATE()   BETWEEN startDate AND endDate")
	public String getOCS0301Q09IsDoctor(@Param("f_hosp_code") String hospCode,@Param("f_doctor") String doctor);
	
	@Query("SELECT A.doctor FROM Bas0270  A WHERE A.hospCode  = :f_hosp_code AND A.sabun  = :f_sabun AND A.doctorGwa = :f_doctor_gwa")
	public String getDoctorBySabunAndDoctorGwa(@Param("f_hosp_code") String hospCode,@Param("f_sabun") String sabun,
			@Param("f_doctor_gwa") String doctorGwa);
	
	@Query("SELECT A.doctorGwa FROM Bas0270  A WHERE A.hospCode  = :f_hosp_code AND A.sabun  = :f_sabun")
	public List<String> getGwaBySabunAndHospCode(@Param("f_hosp_code") String hospCode,@Param("f_sabun") String sabun);
	
	@Query("SELECT A.doctor FROM Bas0270  A WHERE A.hospCode  = :f_hosp_code AND A.doctorGwa = :f_doctor_gwa AND doctor = :f_doctor AND STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d') BETWEEN A.startDate AND A.endDate")
	public List<String> findByHospCodeDoctorGwaDoctorFDate(@Param("f_hosp_code") String hospCode
															,@Param("f_doctor_gwa") String doctorGwa
															,@Param("f_doctor") String doctor
															,@Param("f_ipwon_date") String ipwonDate);
	
}

