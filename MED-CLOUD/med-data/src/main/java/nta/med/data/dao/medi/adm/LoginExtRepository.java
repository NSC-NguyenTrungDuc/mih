package nta.med.data.dao.medi.adm;

import java.math.BigDecimal;
import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.adm.LoginExt;

@Repository
public interface LoginExtRepository extends JpaRepository<LoginExt, Long>, LoginExtRepositoryCustom {

	@Modifying
	@Query("UPDATE LoginExt  SET changePwdFlg = :changePwdFlg, pwdHistory = :pwdHistory, lastChangePwd = :lastChangePwd WHERE userId = :userId and hospCode = :hospCode ")
	public Integer updateLoginExt(@Param("changePwdFlg") BigDecimal changePwdFlg, @Param("pwdHistory") String pwdHistory,
			@Param("lastChangePwd") Date lastChangePwd, @Param("userId") String userId,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("UPDATE LoginExt  SET changePwdFlg = :changePwdFlg WHERE userId = :userId and hospCode = :hospCode ")
	public Integer changeLockStatus(@Param("changePwdFlg") BigDecimal changePwdFlg, @Param("userId") String userId,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query( " 	DELETE from LoginExt 	            						" +
			" 		WHERE (userId      = :userId                       		" +
			"				OR userId  = :pfeUserId ) 						" +
			"   	AND hospCode       = :hospCode                      	")
	public Integer deleteLoginExt(
			@Param("hospCode") String  hospCode,
			@Param("userId") String  userId,
			@Param("pfeUserId") String  pfeUserId);
	
	@Modifying
	@Query(" 	DELETE from LoginExt  										" +
			" 		WHERE userId     = :userId                      		" +
			"   	AND hospCode       = :hospCode                      	")
	public Integer deleteLoginExtByUserId(
			@Param("hospCode") String  hospCode,
			@Param("userId") String  userId);
	
	@Modifying
	@Query("UPDATE LoginExt  SET firstLoginFlg = :firstLoginFlg, changePwdFlg = :changePwdFlg, pwdHistory = :pwdHistory, lastChangePwd = :lastChangePwd WHERE userId = :userId and hospCode = :hospCode ")
	public Integer updateLoginExt(@Param("firstLoginFlg") BigDecimal firstLoginFlg, @Param("changePwdFlg") BigDecimal changePwdFlg, @Param("pwdHistory") String pwdHistory,
			@Param("lastChangePwd") Date lastChangePwd, @Param("userId") String userId,
			@Param("hospCode") String hospCode);

	@Modifying
	@Query(" UPDATE LoginExt  SET firstLoginFlg = :firstLoginFlg, 				"
			+ " changePwdFlg = :changePwdFlg, pwdHistory = :pwdHistory, 		"
			+ " lastChangePwd = :lastChangePwd,  activeFlg = '1', 				"
			+ " sysId = :sysId WHERE userId = :userId and hospCode = :hospCode 	")
	public Integer activeLoginExt(@Param("firstLoginFlg") BigDecimal firstLoginFlg, 
			@Param("changePwdFlg") BigDecimal changePwdFlg, 
			@Param("pwdHistory") String pwdHistory, 
			@Param("lastChangePwd") Date lastChangePwd, 
			@Param("sysId") String sysId, 
			@Param("userId") String userId, 
			@Param("hospCode") String hospCode);
}
