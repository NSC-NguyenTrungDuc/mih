package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR6011U01grdImageInfo;

/**
 * @author dainguyen.
 */
public interface Nur6014RepositoryCustom {

	public List<NUR6011U01grdImageInfo> getNUR6011U01grdImageInfo(String hospCode, String bunho, String fromDate, String buwiGubun, String assessorDate, Integer startNum, Integer offset);

	public String getNUR6011U01layImage(String hospCode, String bunho, String fromDate, String buwi, String assessorDate);

	public Double getNextSeq(String hospCode, String bunho, String fromDate, String bedsoreBuwi, String assessorDate);

	public List<String> getNUR6011U01PrintSetlayImage(String hospCode, String bunho, String buwi, String fromDate,
			String assessorDate);
}

