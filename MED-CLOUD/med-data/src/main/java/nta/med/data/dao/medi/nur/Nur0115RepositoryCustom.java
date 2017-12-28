package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR01152Info;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0115Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR01152Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0115Info;

/**
 * @author dainguyen.
 */
public interface Nur0115RepositoryCustom {
	public String getMsgInsulin(String hospCode, String directGubun, String hangmogCode);
	public List<OCS2005U00grdNUR0115Info> getOCS2005U00grdNUR0115Info(String hospCode, String language, String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset);
	public List<OCS2005U00grdNUR01152Info> getOCS2005U00grdNUR01152Info(String hospCode, String language, String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset);
	public List<ComboListItemInfo> getOCS2005U00layoutComboInfo(String hospCode, String nurGrCode, String nurMdCode, String nurSoCode);
	
	public List<ComboListItemInfo> getOCS6010U10PopupIAxEditGridCell3(String hospCode, String nurGrCode, String nurMdCode);
	
	public List<NUR0110U00GrdNUR0115Info> getNUR0110U00GrdNUR0115Info(String hospCode, String language, String nurGrCode, String nurMdCode, String nurSoCode);
	
	public List<NUR0110U00GrdNUR01152Info> getNUR0110U00GrdNUR01152Info(String hospCode, String language,  String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset);
	
	public Double getNextSeqNur0115(String hospCode, String nurGrCode, String nurMdCode, String nurSoCode);
}

