package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetgrdPrintInfo;
import nta.med.data.model.ihis.nuri.NUR6011U01grdNur6012Info;
import nta.med.data.model.ihis.nuri.NUR6011U01layCalendarInfo;

/**
 * @author dainguyen.
 */
public interface Nur6012RepositoryCustom {

	public List<NUR6011U01grdNur6012Info> getNUR6011U01grdNur6012Info(String hospCode, String bunho, String fromDate, String bedsoreBuwi, String assessorDate, 
			Integer startNum, Integer offset, boolean isCopy);

	public List<NUR6011U01layCalendarInfo> getNUR6011U01layCalendarInfo(String hospCode, String bunho, String fromDate,
			String fromMonth, Integer startNum, Integer offset);

	public String NUR6012CheckIsExist(String hospCode, String bunho, String fromDate);

	public List<NUR6011U01PrintSetgrdPrintInfo> getNUR6011U01PrintSetgrdPrintInfo(String hospCode, String language,
			String bunho, String fromDate, String buwi1, String buwi2, String buwi3, String buwi4, String buwi5,
			String buwi6, String assessorStartDate, String assessorEndDate);

}

