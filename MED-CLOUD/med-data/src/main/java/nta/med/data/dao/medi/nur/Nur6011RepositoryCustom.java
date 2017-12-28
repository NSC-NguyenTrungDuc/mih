package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetlayBuwiInfo;
import nta.med.data.model.ihis.nuri.NUR6011U01grdNur6011Info;

/**
 * @author dainguyen.
 */
public interface Nur6011RepositoryCustom {

	public List<NUR6011U01grdNur6011Info> getNUR6011U01grdNur6011Info(String hospCode, String language, String bunho, Integer startNum, Integer offset);

	public Integer nUR6011U01SaveLayoutUpdateNUR6011(String hospCode, String bunho, String fromDate);

	public String getNUR6011SaveLayoutIsExist(String hospCode, String bunho, String fromDate, String assessorDate);

	public List<NUR6011U01PrintSetlayBuwiInfo> getNUR6011U01PrintSetlayBuwiInfo(String hospCode, String language, String bunho,
			String fromDate);
}

