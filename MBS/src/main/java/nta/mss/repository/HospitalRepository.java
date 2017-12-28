package nta.mss.repository;

import java.util.List;

import nta.mss.entity.Hospital;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface HospitalRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface HospitalRepository extends JpaRepository<Hospital, Integer>, HospitalRepositoryCustom {
	
	/**
	 * Find by hospital code.
	 *
	 * @param hospitalCode the hospital code
	 * @return the list
	 */
	@Query("SELECT h FROM Hospital h WHERE h.hospitalCode = :hospitalCode AND h.activeFlg = 1 ")
	public List<Hospital> findByHospitalCode(@Param("hospitalCode") String hospitalCode);
	
	@Query("SELECT h FROM Hospital h WHERE h.activeFlg = :activeFlg")
	public List<Hospital> findHospitalByActiveFlg(@Param("activeFlg") Integer activeFlg);
	
	@Query("SELECT h FROM Hospital h WHERE h.hospitalId = :hospitalId AND h.activeFlg = :activeFlg")
	public Hospital findHospital(@Param("hospitalId") Integer hospitalId, @Param("activeFlg") Integer activeFlg);
	
	@Query("SELECT h FROM Hospital h WHERE h.hospitalCode = :hospCode AND h.locale = :locale")
	public Hospital findHospitalByHospCodeAndLocate(@Param("hospCode") String hospCode, @Param("locale") String locale);
	
}
