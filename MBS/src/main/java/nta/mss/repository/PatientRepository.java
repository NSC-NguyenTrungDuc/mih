package nta.mss.repository;

import java.util.List;

import nta.mss.entity.Patient;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface PatientRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface PatientRepository extends JpaRepository<Patient, Integer>{
	
	/**
	 * Find patient by card number.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @return the list
	 */
	@Query("SELECT p FROM Patient p, Reservation r WHERE p.patientId = r.patient.patientId AND r.reservationStatus = 1 AND p.cardNumber = :cardNumber AND p.hospital.hospitalId = :hospitalId")
	public List<Patient> findPatientByCardNumber(@Param("cardNumber") String cardNumber, @Param("hospitalId") Integer hospitalId);
	
	@Query("SELECT p FROM Patient p WHERE p.activeFlg = :activeFlg")
	public List<Patient> findPatientByActiveFlg(@Param("activeFlg") Integer activeFlg);
	
	@Query("SELECT p FROM Patient p WHERE lower(p.email) like :email ORDER BY updated desc" )
	public List<Patient> findPatientByEmail(@Param("email") String email);
	
	@Query("SELECT p FROM Patient p WHERE p.cardNumber = :cardNumber AND p.hospital.hospitalId = :hospitalId")
	public List<Patient> findKcckPatientByCardNumber(@Param("cardNumber") String cardNumber, @Param("hospitalId") Integer hospitalId);
	
	@Query("SELECT p FROM Patient p WHERE p.patientId = :patientId")
	public List<Patient> findPatientById(@Param("patientId") Integer patientId);
	
	@Query("SELECT p FROM Patient p WHERE p.kcckParentCode = :kcckParentCode")
	public List<Patient> getListPatientByKcckParentCode(@Param("kcckParentCode") String kcckParentCode);
}
