package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0101U00grdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR0101U00grdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdMasterInfo;

/**
 * @author dainguyen.
 */
public interface Nur0101RepositoryCustom {
	public List<ComboListItemInfo> getCodeTypeCodeTypeNameListItemInfo (String language);
	public List<NUR0101U01GrdMasterInfo> getNUR0101U01GrdMasterInfo(String codeType, String language);
	public List<NUR0101U00grdDetailInfo> getNUR0101U00grdDetailInfo(String hospCode, String language, String codeType, Integer startNum, Integer offset);
	public List<NUR0101U00grdMasterInfo> getNUR0101U00grdMasterInfo(String language, String codeType, Integer startNum,	Integer offset);
	public List<ComboListItemInfo> getNUR0101U00layComboItems(String language);
	public String getNUR0101U00grdDetailGridColumnChanged(String hospCode, String language, String codeType, String code);
	public String getNUR0101U00grdMasterGridColumnChanged(String language, String codeType);
}

