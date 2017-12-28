package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U03AllLinkClinicInfo;
import nta.med.data.model.ihis.nuro.LinkEMRPatientInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02GrdListInfo;

public interface Out2016RepositoryCustom {
	public List<OCS2015U03AllLinkClinicInfo> getOCS2015U03AllLinkClinicInfo(String hospCode, String bunho);
	
	public String getEmrLinkFlg(String hospCode, String bunho, String hospCodeLink, String bunhoLink);
	
	public boolean verifyKcckAccount(String hospCodeLink, String bunhoLink, String password);

	public List<NUR2016U02GrdListInfo> getNUR2016U02GrdListInfo(String hospCode, String bunho);
	public List<ComboListItemInfo> getRES1001U00FbxHospCodeLinkDataValidating(String hospCode, String language, String bunho);
	public String getOut2016Id(String hospCode, String bunho, String hospCodeLink, String bunhoLink);

	boolean verifyPatientLinkYn(String hospCode, String bunho, String hospCodeLink, String bunhoLink);
	
	public List<LinkEMRPatientInfo> getLinkEMRPatientInfo(String hospCode, String bunho, String hospCodeLink, String bunhoLink);

}
