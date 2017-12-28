package nta.med.data.dao.medi.nur;

import nta.med.data.model.ihis.cpls.PrOcsoChkResultMsgListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur1040RepositoryCustom {
	public PrOcsoChkResultMsgListItemInfo prOcsoChkResultMsg(String hospCode, String ocskey, String userId);
}

