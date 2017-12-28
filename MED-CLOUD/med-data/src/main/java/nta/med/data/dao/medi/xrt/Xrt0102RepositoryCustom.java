package nta.med.data.dao.medi.xrt;


import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayMakeTabPageListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayPacsInfoListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0101U00GrdDcodeInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayCPLInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0102RepositoryCustom {
	public List<XRT0000Q00LayMakeTabPageListItemInfo> getXRT0000Q00LayMakeTabPage(String hospCode,String language);
	public List<XRT0101U00GrdDcodeInfo> getXRT0101U00GrdDCodeListItemInfo(String hospCode,String language,String codeType);
	public List<ComboListItemInfo> getXRT0001U00InitializeComboListItemInfo(String hospCode,String language);
	public List<ComboListItemInfo> getXRT0001U00MakeFindWorker(String hospCode, String language, String codeType, String find1,String orderBy);
	public List<XRT0000Q00LayPacsInfoListItemInfo> getXRT0000Q00LayPacsInfo(String hospCode,String codeType, String language, boolean orderByCode);
	
	public List<ComboListItemInfo> getXRT0122U00LayComboItemInfo(String hospCode, String language);
	
	public String getXRT0122U00LayCodeName(String hospCode, String code, String language);
	
	public List<ComboListItemInfo> getComboListItemInfoFromXRT0102(String hospCode, String language);
	public String getCodeNameFromXRT0102(String hospCode, String language, String code);
	public List<ComboListItemInfo> getXRT1002U00GrdXrayMethod(String hospCode,String language,String codeType);
	public List<XRT1002U00LayCPLInfo> getXRT1002U00LayCPLInfo(String hospCode, String bunho);
	public boolean isExistedXrt0102(String hospCode, String codeType, String code, String language);
}

