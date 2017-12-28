package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface Nur0802RepositoryCustom {

	public List<ComboListItemInfo> getNUR0802U00xEditGridCel1(String hospCode, String language);
	
	public Integer updateByHospCodeNeedGubunNeedTypeNeedAsmtCode(String userId, String makeHFileYn, String hospCode,
			String needGubun, String needType, String needAsmtCode);
	
	public Integer deleteByHospCodeNeedGubunNeedTypeNeedAsmtCode(String hospCode, String needGubun, String needType,
			String needAsmtCode);
}
