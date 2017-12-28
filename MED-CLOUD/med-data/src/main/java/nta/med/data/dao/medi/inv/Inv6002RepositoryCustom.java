package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002LoadcbxActorInfo;

public interface Inv6002RepositoryCustom {
	public List<ComboListItemInfo> getINV6002U00GrdINV6002LoadcbxActorInfo(String hospCode, String language);
	public List<INV6002U00GrdINV6002LoadcbxActorInfo> getINV6002LoadcbxActorInfos(String hospCode);
}
