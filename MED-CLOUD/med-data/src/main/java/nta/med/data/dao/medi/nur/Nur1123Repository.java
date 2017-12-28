package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1123;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1123Repository extends JpaRepository<Nur1123, Long>, Nur1123RepositoryCustom {
	
	@Query(	" SELECT T FROM Nur1123 T WHERE hospCode = :hospCode AND codeType = :codeType ORDER BY sortKey")
	public List<Nur1123> findByHospCodeAndCodeType (
			@Param("hospCode") String hospCode,
			@Param("codeType") String codeType);
	
	@Query("SELECT T FROM Nur1123 T WHERE hospCode = :hospCode AND codeType = :codeType AND code = :code")
	public List<Nur1123> findByHospCodeAndCodeTypeAndCode (
				@Param("hospCode") String hospCode,
				@Param("codeType") String codeType,
				@Param("code") String code);
	
	@Modifying		
	@Query("	UPDATE Nur1123	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeName = :f_code_name,	"
			+ "	sortKey = :f_sort_key	"
			+ "	WHERE hospCode = :f_hosp_code	"
			+ "	AND codeType = :f_code_type	"
			+ "	AND code = :f_code	")
	public Integer updateNUR1123U00ByHospCodeAndCodeTypeAndCode (
			@Param("q_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_code_name") String codeName,
			@Param("f_sort_key") Double sortKey,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE FROM Nur1123 WHERE hospCode = :hospCode AND codeType = :codeType AND code = :code")
	public Integer deleteByHospCodeAndCodeTypeAndCode(@Param("hospCode") String hospCode,
										 		      @Param("codeType") String codeType,
										 		      @Param("code") String code);
	
}
