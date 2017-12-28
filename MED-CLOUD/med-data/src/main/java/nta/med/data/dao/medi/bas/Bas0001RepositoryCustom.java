package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.core.domain.bas.Bas0001;
import nta.med.data.model.ihis.adma.ADMS2015U00GetHospitalInfo;
import nta.med.data.model.ihis.bass.BAS0001U00GrdBAS0001Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdHospListInfo;
import nta.med.data.model.ihis.nuro.OUT1001R01GrdListInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicNameInfo;
import nta.med.data.model.ihis.nuro.RES1001U00FbxHospCodeLinkListItemInfo;
import nta.med.data.model.ihis.ocsa.DOC4003U00GetHospInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02DTHospListItemInfo;
import nta.med.data.model.ihis.orca.ORCALibGetDocInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHeaderInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHealthInsuranceInfo;
import nta.med.data.model.ihis.phys.Phy8002U01BtnPrintGetDataWindowInfo;


/**
 * @author dainguyen.
 */
public interface Bas0001RepositoryCustom {
	public List<String> getNuroInspectionOrderGetTel(String hospitalCode, String reserDate);
	public List<BAS0001U00GrdBAS0001Info> getBAS0001U00GrdBAS0001Info(String hospCode, String language);
	public String getYoyangNameInfo (String hospCode, String language);
	
	public List<Phy8002U01BtnPrintGetDataWindowInfo> getPhy8002U01BtnPrintGetDataWindowListItem(String hospCode);
	public List<ComboListItemInfo> loadHospitalList(String language);
	
	public List<ComboListItemInfo> getHospital(String hospCode, String language);
	public List<ComboListItemInfo> getAdm103UHospitalInfo(String hospCode, String language);
	public String getBas0001YoYangName(String hospCode, String language);
	public ADMS2015U00GetHospitalInfo getADMS2015U00GetHospitalInfo(String hospCode, String language);
	
	public String checkAutoGenHospital(String hospCode, String language);
	public List<OCS1003R02DTHospListItemInfo> getOCS1003R02DTHospListItemInfo(String hospCode, String language);
	
	public List<OUT1001R01GrdListInfo> getOUT1001R01GrdListInfo(String hospCode, String language, String bunho, String naewonDate);
	
	public List<DOC4003U00GetHospInfo> getDOC4003U00GetHospInfo(String hospCode);
	public List<ORCATransferOrdersHeaderInfo> getORCATransferOrdersHeaderInfo(String hospCode, String language);
	public List<ORCATransferOrdersHealthInsuranceInfo> getORCATransferOrdersHealthInsuranceInfo(String hospCode, String bunho, Double pkout1001, String language);
	public List<ORCALibGetDocInfo> getORCALibGetDocInfo(String hospCode, String language);

	public Bas0001 getHospCodeByAcctRefId(String orcaGigwanCode);
	public Bas0001 getByHospCode(String hospCode);

	public List<NUR2016Q00GrdHospListInfo> getNUR2016Q00GrdHospListInfo(String hospCode, String language, String yoyangName, String address, Integer startNum, Integer offset);
	public List<RES1001R00ClinicNameInfo> getRES1001R00ClinicName(String hospCodeLink, String language);
	public List<RES1001R00ClinicInfo> getRES1001R00ClinicInfo(String hospCode, String hospCodeLink, String language, String bunho);
	public List<RES1001U00FbxHospCodeLinkListItemInfo> getRES1001U00FbxHospCodeLinkInfo(String hospCode, String language, String bunho);
	public List<ComboListItemInfo> getHospitalInShard(String hospCode, String language);
	public String checkAdminUser(String hospCode);
	public String getGroupCodeByHospCode(String hospCode, String language);
	
	public List<String> getHospCodeInGroup(String hospitalCode);
}

