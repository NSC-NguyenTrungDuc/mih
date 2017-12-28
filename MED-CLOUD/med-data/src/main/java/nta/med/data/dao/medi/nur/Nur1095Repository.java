package nta.med.data.dao.medi.nur;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1095;

@Repository
public interface Nur1095Repository extends JpaRepository<Nur1095, Long>, Nur1095RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur1095      A             "
			+ "    SET A.updDate   = SYSDATE()    "
			+ "      , A.updId     = :f_user_id   "
			+ "  WHERE A.hospCode  = :f_hosp_code "
			+ "    AND A.fknur1094 = :f_fknur1094 "
			+ "    AND A.codeType  = :f_code_type "
			+ "    AND A.code      = :f_code      ")
	public Integer updateByHospCodeFknur1094CodeTypeCode(
			@Param("f_user_id") 	String updId    ,
			@Param("f_hosp_code") 	String hospCode ,
			@Param("f_fknur1094") 	Double fknur1094,
			@Param("f_code_type") 	String codeType ,
			@Param("f_code") 		String code);
	
	@Modifying
	@Query(   " DELETE Nur1095					"
			+ "  WHERE hospCode  = :f_hosp_code "
			+ "    AND fknur1094 = :f_fknur1094 "
			+ "    AND codeType  = :f_code_type "
			+ "    AND code      = :f_code      ")
	public Integer deleteByHospCodeFknur1094CodeTypeCode(
			@Param("f_hosp_code") 	String hospCode ,
			@Param("f_fknur1094") 	Double fknur1094,
			@Param("f_code_type") 	String codeType ,
			@Param("f_code") 		String code);
}
