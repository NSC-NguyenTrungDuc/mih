package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsCHTAPPROVEgrdAPP1001Info;

public interface App1001RepositoryCustom {

	public String getOBGetNotApproveDeseaseCnt(String hospCode, String ioGubun, String insteadYn, String approveYn,
			String doctorId, String bunho);

	public List<OcsCHTAPPROVEgrdAPP1001Info> getOcsCHTAPPROVEgrdAPP1001Info(String hospCode, String language,
			String outsangYn, String bunho, String doctor, String ioGubun, String approveYn, String prePostGubun, String allSangYn, Date gijunDate);
	
	public String getApproveYnByPkapp1001(String hospCode, String pkapp1001);
	public List<ComboListItemInfo> getOcsCHTAPPROVEgrdPatientInfo(String hospCode, String ioGubun, String userId, String approveYn);
}
