package nta.mss.repository;

import java.util.List;

import nta.mss.entity.Vaccine;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Class VaccineRepository.
 */
@Repository
public interface VaccineRepository extends JpaRepository<Vaccine, Integer> {
	
	/**
	 * Find vaccine by active flg.
	 *
	 * @param activeFlg the active flg
	 * @return the list
	 * @throws Exception the exception
	 */
	@Query("SELECT v FROM Vaccine v WHERE v.activeFlg = :activeFlg")
	public List<Vaccine> findVaccineByActiveFlg(@Param("activeFlg") Integer activeFlg) throws Exception;
	
	@Query("SELECT v FROM Vaccine v, VaccineHospital vh WHERE v.vaccineId = vh.vaccine.vaccineId AND vh.hospital.hospitalCode = :hospitalCode AND v.activeFlg = 1 AND vh.activeFlg = 1 AND (vh.toDate is null OR vh.toDate >= CURDATE()) ORDER BY v.vaccineName ASC")
	public List<Vaccine> findVaccineByHospitalCode(@Param("hospitalCode") String hospitalCode) throws Exception;
}
