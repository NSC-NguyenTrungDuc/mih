package nta.med.data.dao.medi.cht;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.chts.CHT0117GrdCHT0117InitListItemInfo;
import nta.med.data.model.ihis.chts.CHT0117Q00DloCHT0117Info;

/**
 * @author dainguyen.
 */
public interface Cht0117RepositoryCustom {
	public List<CHT0117GrdCHT0117InitListItemInfo> getCHT0117GrdCHT0117InitListItem(String hospCode, String language, Date queryDate, String searchWord, Integer startNum, Integer endNum);
	
	public String getCHT0117grdCHT0117Check(String hospCode, String language, String buwi);
	
	public String getCHT0117TransactionalLayCheck(String buwi, Date startDate, String hospCode, String language);
	
	public List<CHT0117Q00DloCHT0117Info> getCHT0117Q00DloCHT0117Info(String hospCode, String language);
}

