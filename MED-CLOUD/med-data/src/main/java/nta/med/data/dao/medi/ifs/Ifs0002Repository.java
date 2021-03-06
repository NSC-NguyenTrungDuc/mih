package nta.med.data.dao.medi.ifs;

import java.util.Date;

import nta.med.core.domain.ifs.Ifs0002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0002Repository extends JpaRepository<Ifs0002, Long>, Ifs0002RepositoryCustom {
	@Query("SELECT DISTINCT 'Y' FROM Ifs0002 A WHERE A.hospCode = :f_hosp_code AND A.codeType = :f_code_type ")
	public String checkExitsByCodeType(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType);
	
	@Query("SELECT DISTINCT 'Y' FROM Ifs0002 A WHERE A.hospCode = :f_hosp_code AND A.codeType = :f_code_type AND A.code = :f_code")
	public String checkExitsByCodeAndCodeType(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code);
	
	@Modifying
	@Query("UPDATE Ifs0002 SET updId = :f_user_id, updDate = :f_sys_date, codeName = :f_code_name, "
			+ " remark = :f_remark, acctType = :acctType WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code = :f_code")
	public Integer getUpdateIFS0001U00SaveLayout(
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_name") String codeName,
			@Param("f_remark") String remark,
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("acctType") String acctType);
	
	@Modifying
	@Query("DELETE FROM Ifs0002 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code = :f_code")
	public Integer getDeleteIFS0001U00SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code);
}

