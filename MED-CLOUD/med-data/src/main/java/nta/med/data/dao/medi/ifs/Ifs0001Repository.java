package nta.med.data.dao.medi.ifs;

import java.util.Date;

import nta.med.core.domain.ifs.Ifs0001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0001Repository extends JpaRepository<Ifs0001, Long>, Ifs0001RepositoryCustom {
	@Query("SELECT DISTINCT 'Y' FROM Ifs0001 A WHERE A.hospCode = :f_hosp_code AND A.codeType = :f_code_type ")
	public String checkExitsByCodeType(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType);
	
	@Modifying
	@Query("UPDATE Ifs0001 SET updId = :f_user_id, updDate = :f_sys_date, codeTypeName = :f_code_type_name,"
			+ " remark = :f_remark, acctType = :acctType  WHERE hospCode = :f_hosp_code AND codeType = :f_code_type ")
	public Integer getUpdateIFS0001U00SaveLayout(
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_remark") String remark,
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("acctType") String acctType);
	
	@Modifying
	@Query("DELETE FROM Ifs0001 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type")
	public Integer getDeleteIFS0001U00SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType);
}

