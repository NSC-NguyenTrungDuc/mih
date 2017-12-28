package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.core.domain.adm.Adm3100;
import nta.med.core.domain.xrt.Xrt0102;
import nta.med.data.dao.medi.CacheRepository;
import nta.med.data.dao.medi.adm.Adm3100RepositoryCustom;

import org.springframework.data.repository.query.Param;

/**
 * @author dainguyen.
 */
public interface Xrt0102Repository extends Xrt0102RepositoryCustom , CacheRepository<Xrt0102>{
	
	public String getYValueLayDupD(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,@Param("f_code_type") String codeType,@Param("f_code") String code);
	
	public List<String> checkExistValueXrt0101U00ExecuteCase1(@Param("f_hosp_code") String hospCode,@Param("f_language") String language, @Param("f_code_type") String codeType);
	
	public Integer deleteXrt0102XRT0101U00ExecuteCase1(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,@Param("f_code_type") String codeType);
	
	public Integer updateXrt0102XRT0101U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,@Param("q_user_id") String userId,
			@Param("f_code2") String code2,@Param("f_code_name") String codeName,@Param("f_seq") Double seq,
			@Param("f_code_value") String codeValue,@Param("f_code_type") String codeType,@Param("f_code") String code);
	
	public Integer deleteXrt0102XRT0101U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code);
	
	public String getXRT0001U00FbxDataValidatingSelectXRT0102(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code);

	public List<Xrt0102> getByCodeTypeAndCode(@Param("hospCode") String hospCode,@Param("f_language") String language,
			@Param("codeType") String codeType, @Param("code") String code);

	public List<Xrt0102> getByCodeType(@Param("hospCode") String hospCode,@Param("f_language") String language,@Param("codeType") String codeType);
}

