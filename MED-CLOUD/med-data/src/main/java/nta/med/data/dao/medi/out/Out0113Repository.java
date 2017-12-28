package nta.med.data.dao.medi.out;

import java.util.Date;

import nta.med.core.domain.out.Out0113;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0113Repository extends JpaRepository<Out0113, Long>, Out0113RepositoryCustom {
	
	@Query("SELECT DISTINCT 'Y' FROM Out0113 A WHERE A.hospCode = :f_hosp_code AND A.bunho = :f_bunho "
			+ "AND A.patientInfo = :f_patient_info AND A.startDate >= :f_start_date ")
	public String checkExitsOUT0106U00SaveComments(@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_patient_info") String patientInfo,
			@Param("f_start_date") Date startDate);
	
	@Modifying
	@Query("UPDATE Out0113 SET comments = :f_comment, endDate = :f_end_date WHERE hospCode = :f_hosp_code AND bunho = :f_bunho"
			+ " AND patientInfo = :f_patient_info AND startDate = :f_start_date")
	public Integer updateOUT0106U00SaveComments2(@Param("f_comment") String comments,
			@Param("f_hosp_code") String hospCode,
			@Param("f_end_date") Date endDate,
			@Param("f_bunho") String bunho,
			@Param("f_patient_info") String patientInfo,
			@Param("f_start_date") Date startDate);
	
	@Modifying
	@Query("UPDATE Out0113 SET endDate = :f_end_date WHERE hospCode = :f_hosp_code AND bunho = :f_bunho"
			+ " AND patientInfo = :f_patient_info AND(endDate IS NULL OR endDate = STR_TO_DATE('9998/12/31', '%Y/%m/%d'))")
	public Integer updateOUT0106U00SaveComments1(
			@Param("f_hosp_code") String hospCode,
			@Param("f_end_date") Date endDate,
			@Param("f_bunho") String bunho,
			@Param("f_patient_info") String patientInfo);
	
	@Modifying
	@Query("UPDATE Out0113 SET endDate = :f_end_date WHERE hospCode = :f_hosp_code AND bunho = :f_bunho"
			+ " AND patientInfo = :f_patient_info AND endDate = :f_start_date ")
	public Integer updateOUT0106U00SaveComments3(
			@Param("f_hosp_code") String hospCode,
			@Param("f_end_date") Date endDate,
			@Param("f_bunho") String bunho,
			@Param("f_patient_info") String patientInfo,
			@Param("f_start_date") Date startDate);
	
	@Modifying
	@Query("DELETE FROM Out0113 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho "
			+ " AND patientInfo = :f_patient_info AND startDate = :f_start_date")
	public Integer deleteOUT0106U00SaveComments(@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_patient_info") String patientInfo,
			@Param("f_start_date") Date startDate);
}

