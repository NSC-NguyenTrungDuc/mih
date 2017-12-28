package nta.med.data.dao.medi.ocs;

import java.util.Collection;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0132;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0132Repository extends JpaRepository<Ocs0132, Long>, Ocs0132RepositoryCustom {
	@Query("SELECT a.codeName FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.code = :code AND a.language = :language")
	public List<String> getCodeNameByCodeAndCodeType(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType,@Param("code") String code);
	
	@Query("SELECT a.codeName FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.code like :code AND a.language = :language order by a.sortKey, a.code")
	public List<String> getCodeNameOrderBySortKey(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType,@Param("code") String code);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.language = :language")
	public List<Ocs0132> getByCodeType(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.language = :language ORDER BY sortKey")
	public List<Ocs0132> getByCodeTypeOrderBySortKey(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.language = :language ORDER BY code")
	public List<Ocs0132> getByCodeTypeOrderByCode(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.language = :language ORDER BY sortKey, code")
	public List<Ocs0132> getByCodeTypeOrderBySortKeyAndCode(@Param("hospitalCode") String hospitalCode, @Param("language") String language, @Param("codeType") String codeType);
	
	@Modifying
	@Query("UPDATE Ocs0132 SET updId = :f_user_id, updDate = :f_sys_date, codeName = :f_code_name, sortKey = IFNULL(:f_sort_key,'0') "
			+ ", groupKey = :f_group_key, ment = :f_ment, valuePoint = IFNULL(:f_value_point,'0') "
			+ " WHERE codeType = :f_code_type AND code = :f_code AND hospCode = :f_hosp_code")
	public Integer updateXSavePerformer(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_name") String codeName,
			@Param("f_sort_key") Double sortKey,
			@Param("f_group_key") String groupKey,
			@Param("f_ment") String ment,
			@Param("f_value_point") Double valuePoint,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE Ocs0132 WHERE codeType = :f_code_type AND code = :f_code AND hospCode = :f_hosp_code")
	public Integer deleteXSavePerformer(@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT code  FROM Ocs0132 WHERE hospCode = :f_hosp_code AND language = :f_language "
			+ "AND codeType = :f_code_type AND groupKey = :f_group_key")
	public List<String> getCodebyCodeTypeAndGroupKey(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_group_key") String groupKey);
	
	@Query("SELECT a FROM Ocs0132 a WHERE hospCode = :f_hosp_code AND language = :f_language "
			+ "AND codeType = :f_code_type AND groupKey = :f_group_key order by sortKey")
	public List<Ocs0132> getByCodeTypeAndGroupKey(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_group_key") String groupKey);
	
	@Query("SELECT ment FROM Ocs0132 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type AND code = :f_code ")
	public List<String> getMintByCodeAndCodeType(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code);
	
	@Modifying
	@Query("UPDATE Ocs0132 SET codeName = :f_code_name WHERE hospCode = :f_hosp_code "
			+ "AND language = :f_language AND codeType = :f_code_type AND code = :f_code")
	public Integer updatePHY0001U00SaveLayout(
			@Param("f_code_name") String codeName,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code);

	@Query
	public List<Ocs0132> findByHospCodeAndCodeTypeAndCodeIn(String hospCode, String codeType, Collection<String> code);
	
	
	@Query("SELECT 'Y' FROM Ocs0132  WHERE hospCode = :f_hosp_code AND language = :f_language ")
	public String getOcsoOCS2016U02CheckY(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospitalCode AND a.codeType = :codeType AND a.valuePoint = :valuePoint AND a.language = :language order by sortKey ")
	public List<Ocs0132> findByHospCodeCodeTypeValuePoint(@Param("hospitalCode") String hospitalCode
														, @Param("language") String language
														, @Param("codeType") String codeType
														, @Param("valuePoint") Double valuePoint);
	
	@Query("SELECT a FROM Ocs0132 a WHERE a.hospCode = :hospCode AND a.codeType = :codeType AND a.code = :code AND a.language = :language ORDER BY code ")
	public List<Ocs0132> findByHospCodeCodeTypeCode(@Param("hospCode") String hospCode
											      , @Param("language") String language
											      , @Param("codeType") String codeType
											      , @Param("code") String code);
	
}

