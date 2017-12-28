package nta.med.data.dao.medi.adm;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.adm.Adm3400;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3400Repository extends JpaRepository<Adm3400, Long>, Adm3400RepositoryCustom {
	@Modifying
	@Query("UPDATE Adm3400 A SET A.entrTime = :f_sys_date WHERE A.hospCode  = :f_hosp_code "
			+ " AND A.userId = :f_user_id AND A.sysId  = :f_system_id AND A.ipAddr = :f_ip_addr")
	public Integer updateUserInfoSetSystemUserToRegistry(@Param("f_sys_date") Date entrTime,
			@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_system_id") String sysId,
			@Param("f_ip_addr") String ipAddr);
	
	@Modifying
	@Query("DELETE Adm3400 A WHERE A.hospCode = :f_hosp_code AND A.userId = :f_user_id AND A.sysId = :f_system_id AND A.ipAddr = :f_ip_addr")
	public Integer deleteFormUserInfoUnRegisterSystemUser(@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_system_id") String sysId,
			@Param("f_ip_addr") String ipAddr);
	
	@Query("SELECT DISTINCT A.ipAddr FROM Adm3400 A WHERE A.hospCode  = :f_hosp_code AND A.userId = :f_user_id "
			+ " AND STR_TO_DATE(DATE_FORMAT(A.entrTime,'%Y%m%d'),'%Y%m%d') = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d')")
	public List<String> getListIpAddr(@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId);
	
	@Modifying
	@Query("UPDATE Adm3400 A SET A.entrTime = :f_sys_date , A.userId = :af_user_id WHERE A.hospCode  = :f_hosp_code "
			+ " AND A.userId = :bf_user_id AND A.sysId  = :f_system_id AND A.ipAddr = :f_ip_addr")
	public Integer updateChangeSystemUser(@Param("f_sys_date") Date entrTime,
			@Param("af_user_id") String afUserId,
			@Param("f_hosp_code") String hospCode,
			@Param("bf_user_id") String bfUserId,
			@Param("f_system_id") String systemId,
			@Param("f_ip_addr") String ipAddr);
}

