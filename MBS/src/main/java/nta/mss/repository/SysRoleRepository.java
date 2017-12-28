package nta.mss.repository;

import java.util.List;

import nta.mss.entity.SysRole;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

/**
 * The Interface PatientRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface SysRoleRepository extends JpaRepository<SysRole, Integer>{
	
	List<SysRole> findByRoleName(String roleName);
	
	List<SysRole> findByRoleId(Integer roleId); 
	
	@Query("Select s from SysRole s where s.activeFlg = 1")
	List<SysRole> getAllSysRole();
	
	
}
