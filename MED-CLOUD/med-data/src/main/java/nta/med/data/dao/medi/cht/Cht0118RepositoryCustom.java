package nta.med.data.dao.medi.cht;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.chts.CHT0117GrdCHT0118InitListItemInfo;
import nta.med.data.model.ihis.chts.CHT0117Q00GrdCHT0118Info;

/**
 * @author dainguyen.
 */
public interface Cht0118RepositoryCustom {
	
	public List<CHT0117GrdCHT0118InitListItemInfo> getCHT0117GrdCHT0118InitListItem(String hospCode, String language, String buwi, Date queryDate, Integer startNum, Integer endNum);
	
	public String getCHT0117LayNextSubBuwiCd(String hospCode, String language);
	
	public String getCHT0117layCheckCht0118(String hospCode, String language, String buwi, String subBuwi, Date startDate);
	
	public List<CHT0117Q00GrdCHT0118Info> getCHT0117Q00GrdCHT0118Request(String hospCode, String language, String gubun, String buwi, String buwiName);
	public String getOCS2005U00BuwiName(String hospCode, String buwiCode);
}

