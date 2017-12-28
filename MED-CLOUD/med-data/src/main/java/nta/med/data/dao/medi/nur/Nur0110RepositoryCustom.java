package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0110Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00layDirectInfoInfo;

/**
 * @author dainguyen.
 */
public interface Nur0110RepositoryCustom {
	public List<OCS2005U00layDirectInfoInfo> getOCS2005U00layDirectInfoInfo(String hospCode); 
	public List<NUR0110U00GrdNUR0110Info> getNUR0110U00GrdNUR0110Info(String hospCode, Integer startNum, Integer offset);
}

