package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10PostLoadInfo;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdDetailItemInfo;
import nta.med.data.model.ihis.drug.DRG0102U00GrdDetailInfo;
import nta.med.data.model.ihis.drug.DrugTripleListItemInfo;
import nta.med.data.model.ihis.invs.INV0101U01GridDetailInfo;
import nta.med.data.model.ihis.invs.LoadGrdDetailINV0101Info;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayTabGubunInfo;
import nta.med.data.model.ihis.system.LayConstantInfo;

/**
 * @author dainguyen.
 */
public interface Inv0102RepositoryCustom {
	
	public List<DRG0102U00GrdDetailInfo> getDRG0102U00GrdDetailInfo(String hospCode, String codeType, String language);
	
	public List<DrugTripleListItemInfo> getTripleListItemInfo(String hospCode, String language);
	public List<LayConstantInfo> getLayConstantInfo(String hospCode, String language);
	public List<OCS0208Q00LayTabGubunInfo> getOCS0208Q00LayTabGubunInfo(String hospCode, String language);
	public List<ComboListItemInfo> getComboListItemInfoOCS0208Q01GrdDrg0120(String hospCode, String language);
	public List<ComboListItemInfo> getDRG0120U00ComboListItem(String hospCode, String codeType, String language);
	
	public List<Drg0102U01GrdDetailItemInfo> getDrg0102U01GrdDetailListItem(String hospCode, String codeType, String language);
	
	public String getDRG5100P01CheckActInfo(String hospCode, String codeType, String code, String codeName, String language);
	public List<ComboListItemInfo> getINV4001U00LoadCodeName(String hospCode, String codeType, String language);
	public List<LoadGrdDetailINV0101Info> getGrdDetailINV0101Info(String hospCode, String codeType, String language);
	
	public List<INV0101U01GridDetailInfo> getGridDetailInfo(String hospCode, String codeType, String language);

	public List<LayConstantInfo> getLayConstantInfo(String hospCode, String language, String codeType);
	
	public List<DRG3010P10PostLoadInfo> getDRG3010P10PostLoadInfo(String hospCode);
}

