package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0112Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNur0112Info;

/**
 * @author dainguyen.
 */
public interface Nur0112RepositoryCustom {

	public List<ComboListItemInfo> getOCS2005U02AutoMaSetCombo(String hospCode, String code);
	public List<OCS2005U00grdNur0112Info> getOCS2005U00grdNur0112Info(String hospCode, String nurGrCode, String nurMdCode, String vald, Integer startNum, Integer offset);
	public String fnIsSikaCode(String hospCode, String cont1, String cont1d, String cont2, String cont2d, String cont3,	String cont3d);
	
	public List<NUR0110U00GrdNUR0112Info> getNUR0110U00GrdNUR0112Info(String hospCode, String nurGrCode,
			String nurMdCode, Integer startNum, Integer offset);
}

