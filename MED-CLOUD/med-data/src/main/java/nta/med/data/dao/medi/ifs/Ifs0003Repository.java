package nta.med.data.dao.medi.ifs;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.ifs.Ifs0003;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0003Repository extends JpaRepository<Ifs0003, Long>, Ifs0003RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ifs0003 						   "
			+"	SET updId            = :updId          " 
			+"	  , updDate          = :updDate        " 
			+"	  , remark           = :remark         " 
			+"	WHERE hospCode       = :hospCode       " 
			+"	AND mapGubun         = :mapGubun       " 
			+"	AND mapGubunYmd      = :mapGubunYmd    " 
			+"	AND ocsCode          = :ocsCode        " )
	public Integer updateIfs003U03TransactionalAdded(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("remark") String remark,
			@Param("hospCode") String hospCode,
			@Param("mapGubun") String mapGubun,
			@Param("mapGubunYmd") Date mapGubunYmd,
			@Param("ocsCode") String ocsCode);
	
	@Modifying	
	@Query("	UPDATE Ifs0003 					   "
			+ "	SET updId = :f_user_id              "
			+ "	, updDate = :f_sys_date              "
			+ "	, mapGubunYmd = :f_map_gubun_ymd     "
			+ "	, ocsCode = :f_ocs_code               "
			+ "	, ocsDefaultYn = :f_ocs_default_yn   "
			+ "	, ifCode = :f_if_code                 "
			+ "	, ifDefaultYn = :f_if_default_yn     "
			+ "	, remark = :f_remark                 "
			+ "	WHERE hospCode = :f_hosp_code       "
			+ "	AND mapGubun = :f_map_gubun         "
			+ "	AND mapGubunYmd = :f_map_gubun_ymd "
			+ "	AND ocsCode = :f_ocs_code           ")
	public Integer updateIFS0003U03Modified (
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_map_gubun_ymd") Date mapGubunYmd,
			@Param("f_ocs_code") String ocsCode,
			@Param("f_ocs_default_yn") String ocsDefaultYn,
			@Param("f_if_code") String ifCode,
			@Param("f_if_default_yn") String ifDefaultYn,
			@Param("f_remark") String remark,
			@Param("f_hosp_code") String hospCode,
			@Param("f_map_gubun") String mapGubun
			);
	
	
	@Modifying
	@Query("	UPDATE Ifs0003 						   "
			+"	SET updId            = :updId          " 
			+"	  , updDate          = :updDate        " 
			+"	  , remark           = :remark         " 
			+"	  , acctType         = :acctType       " 
			+"	WHERE hospCode       = :hospCode       " 
			+"	AND mapGubun         = :mapGubun       " 
			+"	AND mapGubunYmd      = :mapGubunYmd    " 
			+"	AND ocsCode          = :ocsCode        " )
	public Integer updateIfs003U00TransactionalAdded(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("remark") String remark,
			@Param("acctType") String acctType,
			@Param("hospCode") String hospCode,
			@Param("mapGubun") String mapGubun,
			@Param("mapGubunYmd") Date mapGubunYmd,
			@Param("ocsCode") String ocsCode);
	
	@Modifying	
	@Query("	UPDATE Ifs0003 					   "
			+ "	SET updId = :f_user_id              "
			+ "	, updDate = :f_sys_date              "
			+ "	, mapGubunYmd = :f_map_gubun_ymd     "
			+ "	, ocsCode = :f_ocs_code               "
			+ "	, ocsDefaultYn = :f_ocs_default_yn   "
			+ "	, ifCode = :f_if_code                 "
			+ "	, ifDefaultYn = :f_if_default_yn     "
			+ "	, remark = :f_remark                 "
			+"	, acctType         = :acctType       " 
			+ "	WHERE hospCode = :f_hosp_code       "
			+ "	AND mapGubun = :f_map_gubun         "
			+ "	AND mapGubunYmd = :f_map_gubun_ymd "
			+ "	AND ifCode = :f_if_code 			"
			+ "	AND ocsCode = :f_ocs_code           ")
	public Integer updateIFS0003U00Modified (
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_map_gubun_ymd") Date mapGubunYmd,
			@Param("f_ocs_code") String ocsCode,
			@Param("f_ocs_default_yn") String ocsDefaultYn,
			@Param("f_if_code") String ifCode,
			@Param("f_if_default_yn") String ifDefaultYn,
			@Param("f_remark") String remark,
			@Param("acctType") String acctType,
			@Param("f_hosp_code") String hospCode,
			@Param("f_map_gubun") String mapGubun
			);
			
	@Modifying	
	@Query("	DELETE								   "
			+ "	FROM Ifs0003 A                         "
			+ "	WHERE A.hospCode = :f_hosp_code       "
			+ "	AND A.mapGubun = :f_map_gubun         "
			+ "	AND A.mapGubunYmd = :f_map_gubun_ymd "
			+ "	AND A.ocsCode = :f_ocs_code           "
			+ "	AND A.ifCode = :f_if_code             ")
	public Integer deleteIFS003U03Deleted(
			@Param("f_hosp_code") String hospCode,
			@Param("f_map_gubun") String mapGubun,
			@Param("f_map_gubun_ymd") Date mapGubunYmd,
			@Param("f_ocs_code") String ocsCode,
			@Param("f_if_code") String ifCode
			);
	
	@Query("SELECT 'Y' FROM Ifs0003 A WHERE A.hospCode = :f_hosp_code AND A.mapGubun = :f_map_gubun "
			+ " AND A.ocsCode = :f_ocs_code  AND  A.ifCode  = :f_if_code")
	public String getYByMapGubunOcsCodeAndIfCode(@Param("f_hosp_code") String hospCode, @Param("f_map_gubun") String mapGubun,
			@Param("f_ocs_code") String ocsCode, @Param("f_if_code") String ifCode);
	
	@Modifying
	@Query("UPDATE Ifs0003 SET mapGubunYmd = :f_map_gubun_ymd, "
			+ " ocsDefaultYn = :f_ocs_default_yn , "
			+ " ifDefaultYn = :f_if_default_yn ,"
			+ " remark = :f_remark  "
			+ " WHERE hospCode = :f_hosp_code AND mapGubun = :f_map_gubun"
			+ " AND ocsCode = :f_ocs_code AND ifCode = :f_if_code  ")
	public Integer updateIFS0003ByMapGubunOcsCodeAndIfCode(@Param("f_hosp_code") String hospCode, @Param("f_map_gubun_ymd") Date mapGubunYmd,
			@Param("f_ocs_default_yn") String ocsDefaultYn,@Param("f_if_default_yn") String ifDefaultYn,@Param("f_remark") String remark,
			@Param("f_map_gubun") String mapGubun, @Param("f_ocs_code") String ocsCode, @Param("f_if_code") String ifCode );
	
	@Query("SELECT A FROM Ifs0003 A WHERE A.hospCode = :f_hosp_code AND A.mapGubun = :f_map_gubun "
			+ " AND A.ocsCode = :f_ocs_code")
	public List<Ifs0003> findByHospCodeAndMapGubunAndOcsCode(@Param("f_hosp_code") String hospCode, @Param("f_map_gubun") String mapGubun,
			@Param("f_ocs_code") String ocsCode);
	
	@Query("SELECT A FROM Ifs0003 A WHERE A.hospCode = :f_hosp_code AND A.mapGubun = :f_map_gubun "
			+ " AND A.ifCode = :f_if_code")
	public List<Ifs0003> findByHospCodeAndMapGubunAndIfCode(@Param("f_hosp_code") String hospCode, @Param("f_map_gubun") String mapGubun,
			@Param("f_if_code") String ifCode);
	
	@Query("SELECT A FROM Ifs0003 A WHERE A.hospCode = :f_hosp_code AND A.mapGubun = :f_map_gubun AND A.ocsCode IN :f_ocs_code")
	public List<Ifs0003> findByHospCodeMapGubunOcsCodeList(@Param("f_hosp_code") String hospCode, 
														@Param("f_map_gubun") String mapGubun,
														@Param("f_ocs_code") List<String> ocsCodeList);
}

