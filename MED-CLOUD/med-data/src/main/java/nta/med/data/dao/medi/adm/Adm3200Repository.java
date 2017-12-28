package nta.med.data.dao.medi.adm;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.adm.Adm3200;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3200Repository extends JpaRepository<Adm3200, Long>, Adm3200RepositoryCustom {
	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :hospCode AND a.deptCode IN ('30010', '30100') ORDER BY a.deptCode, a.userId")
	public List<Adm3200> getInjsINJ1001U01ActorListItemInfo(@Param("hospCode") String hospCode);
	 
	@Query("SELECT userNm FROM Adm3200 WHERE hospCode = :hospCode AND userId = :userId")
	public List<String> getUserNameList(@Param("hospCode") String hospCode,
			@Param("userId") String userId);
	
	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :hospCode AND a.userGroup = :userGroup AND IFNULL(a.userEndYmd, STR_TO_DATE('9998/12/31','%Y/%m/%d')) >= :currentDate ORDER BY a.userId")
	public List<Adm3200> getByUserGroupAndUserEndYmd(@Param("hospCode") String hospCode,
			@Param("userGroup") String userGroup,
			@Param("currentDate") Date currentDate);
	
	@Query("SELECT userGubun FROM Adm3200 WHERE hospCode = :f_hosp_code AND userId  = :f_code ")
	public String getUserGubun(@Param("f_hosp_code") String hospCode,@Param("f_code") String code);
	
	@Modifying
	@Query("UPDATE Adm3200                                       " +
			"   SET userNm       = :userNm                        " +
			"     , userScrt     = :userScrt                      " +
			"     , deptCode     = :deptCode                      " +
			"     , userGroup    = :userGroup                     " +
			"     , userLevel    = :userLevel                     " +
			"     , userEndYmd   = :userEndYmd                    " +
			"     , userGubun    = :userGubun                     " +
			"     , upMemb       = :upMemb                        " +
			"     , upTime       = :upTime                        " +
			"     , nurseConfirmEnableYn = :nurseConfirmEnableYn  " +
			"     , coId         = :coId                          " +
			"     , email        = :email                         " +
			"     , clisSmoId    = :clisSmoId                     " +
			"     , loginFlg     = :loginFlg                      " +
			" WHERE hospCode     = :hospCode                      " +
			"   AND userId       = :userId                        ")
	public Integer updateADM104U(
			@Param("userNm") String  userNm,    
			@Param("userScrt") String  userScrt,
			@Param("deptCode") String  deptCode,
			@Param("userGroup") String  userGroup,
			@Param("userLevel") Double  userLevel,
			@Param("userEndYmd") Date  userEndYmd,
			@Param("userGubun") String  userGubun,
			@Param("upMemb") String  upMemb,
			@Param("upTime") Date  upTime,
			@Param("nurseConfirmEnableYn") String  nurseConfirmEnableYn,
			@Param("coId") String  coId,
			@Param("hospCode") String  hospCode,
			@Param("userId") String  userId,
			@Param("email") String  email,
			@Param("clisSmoId") Integer  clisSmoId,
			@Param("loginFlg") BigDecimal  loginFlg);
	
	@Modifying
	@Query("DELETE FROM Adm3200                                   " +
			" WHERE hospCode     = :hospCode                      " +
			" AND ( userId       = :userId                        " +
			"   OR userId       = :pfeUserId )                    ")
	public Integer deleteADM104U(
			@Param("hospCode") String  hospCode,
			@Param("userId") String  userId,
			@Param("pfeUserId") String  pfeUserId);
	
	@Query("SELECT userId  FROM Adm3200  WHERE hospCode  = :f_hosp_code AND userGroup = :f_user_id ")
	public List<String> getListUserId(@Param("f_hosp_code") String  hospCode,@Param("f_user_id") String  userId);
	
	@Modifying
	@Query("UPDATE Adm3200 A SET   A.userScrt = :f_new_pswd WHERE A.hospCode  = :f_hosp_code AND A.userId = :f_user_id")
	public Integer updateFwUserInfoChangePsw(@Param("f_hosp_code") String  hospCode, @Param("f_new_pswd") String  userScrt, 
			@Param("f_user_id") String  userId);
	
	@Query("SELECT hospCode FROM Adm3200 WHERE userId = :f_user_id order by hospCode asc  ")
	public List<String> getHospCodeFwUserInfoChangePsw(@Param("f_user_id") String  userId);
	
	@Modifying
	@Query("UPDATE Adm3200  SET loginFlg   = :loginFlg, upTime = :timeStamp WHERE userId = :userId " )
	public Integer updateLoginFlgByUserId(@Param("userId") String userId, @Param("timeStamp") Date timeStamp, @Param("loginFlg") BigDecimal loginFlg);
	
	@Modifying
	@Query("DELETE FROM Adm3200                                   " +
			" WHERE hospCode     = :hospCode                      " +
			" AND userId       = :userId                          ")
	public Integer deleteADM104UByUserId(
			@Param("hospCode") String  hospCode,
			@Param("userId") String  userId);
	
	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :f_hosp_code AND a.userId  = :f_user_id ")
	public List<Adm3200> getAdm3200ByUserId(@Param("f_hosp_code") String hospCode, @Param("f_user_id") String userId);
	
	@Query("SELECT T FROM Adm3200 T WHERE T.hospCode = :f_hosp_code AND T.userId  = :f_code ")
	public List<Adm3200> findByHospCodeUserId(@Param("f_hosp_code") String hospCode,@Param("f_code") String userId);


	public List<Adm3200> findByHospCodeAndUserId(String hospCode, String userId);
	
	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :hospCode AND a.deptCode = :deptCode ORDER BY a.deptCode, a.userId")
	public List<Adm3200> findByHospCodeDeptCode(@Param("hospCode") String hospCode, @Param("deptCode") String deptCode);
	
	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :hospCode AND(userEndYmd IS NULL OR SYSDATE() < userEndYmd) AND userId like :f_sabun AND a.deptCode = :f_buseo_code ORDER BY a.userId, a.userNm")
	public List<Adm3200> getNUR8050U00fwkNurse(@Param("hospCode") String hospCode, @Param("f_sabun") String sabun,
			@Param("f_buseo_code") String buseoCode);

	@Query("SELECT a FROM Adm3200 a WHERE a.hospCode = :hospCode AND a.userId = :userId AND a.userGubun = '2' AND SYSDATE() < IFNULL(a.userEndYmd, STR_TO_DATE('99981231', '%Y/%m/%d'))")
	public List<Adm3200> findByHospCodeUserIdSysDate(@Param("hospCode") String hospCode, @Param("userId") String userId);
	
}

