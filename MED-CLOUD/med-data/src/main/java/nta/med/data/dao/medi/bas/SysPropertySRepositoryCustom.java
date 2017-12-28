package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.LoadCbxLanguageInfo;

public interface SysPropertySRepositoryCustom {
	public List<LoadCbxLanguageInfo> getCbxLanguageInfo(String propertyCode, String activeFlg);
}
