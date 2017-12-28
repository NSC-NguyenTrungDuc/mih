package nta.med.data.dao.mss;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.Patient;
import nta.med.data.model.mss.PatientInfo;

@Repository
public interface PatientRepository extends JpaRepository<Patient, Long>, PatientRepositoryCustom {
	
	@Query("SELECT p FROM Patient p WHERE p.cardNumber = :patientCode")
	public List<Patient> findKcckPatientByPatientCode(@Param("patientCode") String patientCode);
	
	@Query("SELECT p FROM Patient p WHERE p.hospitalId = :hospitalId and p.cardNumber = :patientCode")
	public List<Patient> findKcckPatientByPatientCodeHospCode(@Param("hospitalId") Integer hospitalId, @Param("patientCode") String patientCode);
	
	List<PatientInfo> findPatientInfoByProfileId(BigInteger profileId);
}
