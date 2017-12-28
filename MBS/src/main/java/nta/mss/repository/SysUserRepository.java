package nta.mss.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.mss.entity.SysUser;

/**
 * The Interface SysUserRepository.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface SysUserRepository extends JpaRepository<SysUser, Integer>{
	
	@Query("Select u from SysUser u where u.loginId = :loginId and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1")
	List<SysUser> findByLoginId(@Param("loginId") String loginId, @Param("hospitalId") Integer hospitalId);
	
	@Query("Select s from SysUser s where s.activeFlg = 1 and s.hospital.hospitalId = :hospitalId")
	List<SysUser> getAllSysUser(@Param("hospitalId") Integer hospitalId);
	
	@Query("Select u from SysUser u where u.loginId = :loginId and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1")
	List<SysUser> findByLoginIdAndHospitalId (@Param("loginId") String loginId, @Param("hospitalId") Integer hospitalId);
	
	@Query("Select u from SysUser u where u.email = :email and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1")
	List<SysUser> findByEmailAndHospitalId (@Param("email") String email, @Param("hospitalId") Integer hospitalId);
}
