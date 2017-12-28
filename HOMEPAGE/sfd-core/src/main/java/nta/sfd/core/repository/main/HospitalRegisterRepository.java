package nta.sfd.core.repository.main;

import java.math.BigDecimal;
import java.util.List;

import nta.sfd.core.entity.HospitalRegister;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface MailTemplateRepository.
 *
 * @author Quan.Le.Minh
 * @crtDate 2015/07/02
 */
@Repository
public interface HospitalRegisterRepository extends JpaRepository<HospitalRegister, Integer>{

	
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
	
	@Query("SELECT COUNT(hr.hospitalRegisterId) FROM HospitalRegister hr WHERE hr.registerEmail = :email AND activeFlg = 1 AND demoFlg = :demoFlg ")
	public Integer countHospitalRegisterIdByEmail(@Param("email") String email, @Param("demoFlg") BigDecimal demoFlg);
}
