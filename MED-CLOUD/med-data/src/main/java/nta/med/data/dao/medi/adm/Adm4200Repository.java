package nta.med.data.dao.medi.adm;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.adm.Adm4200;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4200Repository extends JpaRepository<Adm4200, Long>, Adm4200RepositoryCustom {
	@Query("select count(1) from Adm4200 where hospCode = :hospCode "
			+ "AND userId = :userId AND sysId = :sysId AND trId = :trId ")
	public Integer countAdm107uExecute(
			@Param("hospCode") String hospCode,
			@Param("userId") String userId,
			@Param("sysId") String sysId,
			@Param("trId") String trId);
	
	@Modifying
	@Query("delete from Adm4200 where hospCode = :hospCode "
			+ "AND userId = :userId AND sysId = :sysId AND trId = :trId ")
	public Integer deleteAdm107uExecute(
			@Param("hospCode") String hospCode,
			@Param("userId") String userId,
			@Param("sysId") String sysId,
			@Param("trId") String trId);

	@Query("select count(1) from Adm4200 where hospCode = :hospCode "
			+ "AND userId = :userId AND sysId = :sysId")
	public Integer getMenuByHospCodeAndUserIdAndSysID(
			@Param("hospCode") String hospCode,
			@Param("userId") String userId,
			@Param("sysId") String sysId);

	public List<Adm4200> findByHospCodeAndUserId(String hospCode, String userId);
	
	@Query("select distinct sysId from Adm4200 where hospCode = :hospCode "
			+ "AND userId = :userId")
	public List<String> getMenuByHospCodeAndUserIdAndSysIDs(
			@Param("hospCode") String hospCode,
			@Param("userId") String userId);
}

