package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0114Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0114Info;

/**
 * @author dainguyen.
 */
public interface Nur0114RepositoryCustom {
	public List<OCS2005U00grdNUR0114Info> getOCS2005U00grdNur0114Info(String hospCode, String nurGrCode, String nurMdCode, String vald, Integer startNum, Integer offset);
	public List<NUR0110U00GrdNUR0114Info> getNUR0110U00GrdNUR0114Info(String hospCode, String nurGrCode, String nurMdCode, Integer startNum, Integer offset);
}

