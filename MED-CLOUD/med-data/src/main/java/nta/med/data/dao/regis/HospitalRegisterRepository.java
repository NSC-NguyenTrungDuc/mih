package nta.med.data.dao.regis;


import nta.med.core.domain.hp.HospitalRegister;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * The Interface MailTemplateRepository.
 *
 * @author Quan.Le.Minh
 * @crtDate 2015/07/02
 */
@Repository
public interface HospitalRegisterRepository extends JpaRepository<HospitalRegister, Integer> {

	
	/**
	 * Get all Hospital Register by Status
	 * @param status
	 * @return
	 */
	@Query("SELECT hr FROM HospitalRegister hr WHERE hr.status = ?1")
	public List<HospitalRegister> findByStatus(Integer status);
	
	@Query("SELECT hr FROM HospitalRegister hr WHERE hr.status = 3 AND hr.vpnYn = 'Y' ")
	public List<HospitalRegister> findHospitalUseVpn();
	
	@Query("SELECT hr FROM HospitalRegister hr WHERE hr.sessionId = ?1")
	public HospitalRegister findBySessionId(String sessionId);
	
	@Query("SELECT MAX(hr.hospitalRegisterId) FROM HospitalRegister hr")
	public Integer maxHospitalRegisterId();
	
	@Query("SELECT COUNT(hr.hospitalRegisterId) FROM HospitalRegister hr WHERE hr.registerEmail = :email AND activeFlg = 1")
	public Integer countHospitalRegisterIdByEmail(@Param("email") String email);
}
