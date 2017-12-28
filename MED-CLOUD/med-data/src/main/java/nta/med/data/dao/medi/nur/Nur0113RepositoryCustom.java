package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0113Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdNUR0114Info;

/**
 * @author dainguyen.
 */
public interface Nur0113RepositoryCustom {
	public List<OCS6010U10PopupTAgrdNUR0114Info> getOCS6010U10PopupTAgrdNUR0114Info(String hospCode, String directGubun, String directCode, String vald);
	public List<OCS6010U10PopupTAgrdNUR0114Info> getOCS6010U10frmDirectActinggrdNUR0113Info(String hospCode, String directCode, String vald, Integer startNum, Integer offset);
	public List<NUR0110U00GrdNUR0113Info> getNUR0110U00GrdNUR0113Info(String hospCode, String nurGrCode, String nurMdCode, Integer startNum, Integer offset);
}

