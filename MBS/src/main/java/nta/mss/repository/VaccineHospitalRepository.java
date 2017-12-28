package nta.mss.repository;

import java.util.List;

import nta.mss.entity.VaccineHospital;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface VaccineHospitalRepository extends JpaRepository<VaccineHospital, Integer> {
	@Query("SELECT v FROM VaccineHospital v WHERE v.activeFlg = 1 order by v.vaccine.vaccineName ASC")
	public List<VaccineHospital> findAllVaccineHospital();
	
	@Query("SELECT v FROM VaccineHospital v WHERE v.vaccine.vaccineId = :vaccineId AND v.hospital.hospitalId = :hospitalId AND v.activeFlg = 1")
	public List<VaccineHospital> findByVaccineIdHospitalId(@Param("vaccineId") Integer vaccineId, @Param("hospitalId") Integer hospitalId);
	
	@Query("SELECT v FROM VaccineHospital v WHERE v.activeFlg = 1 AND v.hospital.hospitalId = :hospitalId order by v.vaccine.vaccineName ASC")
	public List<VaccineHospital> getVaccineHospitalByHospitalId(@Param("hospitalId") Integer hospitalId);
}
