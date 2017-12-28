package nta.med.data.dao.medi.out;

import java.util.Date;

import nta.med.core.domain.out.Out0112;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0112Repository extends JpaRepository<Out0112, Long>, Out0112RepositoryCustom {
	
	@Query("SELECT A.patientInfoName FROM Out0112 A WHERE A.hospCode = :f_hosp_code AND A.patientInfo = :f_patient_info "
			+ "AND IFNULL(:f_naewon_date, SYSDATE()) BETWEEN A.startDate AND IFNULL(A.endDate, STR_TO_DATE('9998/12/31','%Y/%m/%d'))")
	public String getOUT0106U00PatientInfoName(@Param("f_hosp_code") String hospCode,
			@Param("f_patient_info") String patientInfo,
			@Param("f_naewon_date") Date naewonDate);
	
	@Query("SELECT DISTINCT 'Y' FROM Out0112 A WHERE A.hospCode = :f_hosp_code AND A.patientInfo = :f_patient_info "
			+ "AND :f_start_date BETWEEN A.startDate AND IFNULL(A.endDate, STR_TO_DATE('9998/12/31','%Y/%m/%d'))")
	public String checkExitsOUT0106U00SaveComments(@Param("f_hosp_code") String hospCode,
			@Param("f_patient_info") String patientInfo,
			@Param("f_start_date") Date startDate);
}

