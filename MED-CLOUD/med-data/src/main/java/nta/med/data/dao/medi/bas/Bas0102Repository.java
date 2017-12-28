package nta.med.data.dao.medi.bas;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.dao.medi.CacheRepository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0102Repository extends Bas0102RepositoryCustom, CacheRepository<Bas0102> {
	public String getTChkBAS0101U00Execute( String hospCode, String codeType, String code, String language);
	
	public Integer updateBAS0101U00Execute( String hospCode, String userId, Date updDate, String codeName,
			 String groupKey, String remark, Double sortKey,
			 String codeType, String code, String language);
	
	public Integer deleteBAS0101U00Execute( String hospCode, String codeType, String code, String language);

	public List<Bas0102> getByCodeAndCodeNameAndCodeType(
			 String hospCode,
			 String code,
			 String find1,
			 String language);
	
	public List<Bas0102> getByCodeAndCodeType(
			 String hospCode,
			 String code,
			 String codeType,
			 String language);

	public List<Bas0102> getByHospCodeAndCodeType(
			String hospCode,
			String codeType1,
			String codeType2,
			String codeType3);

	public List<Bas0102> getAllByLikeCodeAndCodeType(
			 String hospCode,
			 String code,
			 String codeType,
			 String language);
	
	public String getBAS0210U00layDupCheck( String hospCode, String language, String code);
	
	public String getCodeNameByCodeTypeAndCode( String hospCode, String language, String codeType, String code);

	public String checkExitsByCodeType( String hospCode, String codeType,  String language);
	
	public List<Bas0102> getByCodeType(
			 String hospCode,
			 String codeType,
			 String language);

	public List<Bas0102> getByCodeTypeAndCodeAndCodeName(String codeType, String code, String codeName);
	
	public List<Bas0102> findByHospCodeAndCodeType(String hospCode, String codeType);
	
	public List<Bas0102> findByHospCodeAndCodeTypeAndCodename(String hospCode, String codeType, List<String> codeNameList);
	
	public List<Bas0102> findByCodeTypeAndCodename(String codeType, List<String> codeNameList);
	
	public List<ComboListItemInfo> getPersonListItemInfo(String hospCode, String language);
	
	//[Start] Med-1.5.2 Basic Design: MED-8065
	public Integer updateBas0102U04(String userId, Date updDate, String codeName, String codeType, String code, String hospCode, String language);
	public BigDecimal getSeqValue(String seqName, String hospCode);
	public Integer updateSequencePidSeq(String codeName, String seqName, String hospCode);
	public Integer updateSequenceSeqStep(String codeName, String seqName, String hospCode);
	//[End] Med-1.5.2 Basic Design: MED-8065
}

