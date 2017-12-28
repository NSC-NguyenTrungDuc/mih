package nta.med.data.dao.medi.inj;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.injs.INJ0101U00GrdDetailInfo;
import nta.med.data.model.ihis.injs.INJ0101U01GrdDetailItemInfo;

/**
 * @author dainguyen.
 */
public interface Inj0102RepositoryCustom {
	
	public List<INJ0101U00GrdDetailInfo> getINJ0101U00GrdDetailInfo(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getINJ1001U01MlayConstantInfo(String hospCode, String language);
	public List<INJ0101U01GrdDetailItemInfo> getInj0101U01GrdDetailListItemInfo (String hospCode, String codeType, String language);
}

