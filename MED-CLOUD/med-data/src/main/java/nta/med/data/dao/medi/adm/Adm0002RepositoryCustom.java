package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.Adm501UListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm0002RepositoryCustom {
	public List<Adm501UListItemInfo> getAdm501UListItem(String msgGubun, String searchMsg, String condition);
}

