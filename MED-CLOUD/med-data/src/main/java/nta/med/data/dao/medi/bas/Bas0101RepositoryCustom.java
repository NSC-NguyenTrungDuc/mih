package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.adma.BAS0101U04GrdMasterInfo;
import nta.med.data.model.ihis.bass.BAS0101U00PrBasGridColumnChangedItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0101RepositoryCustom {
	public List<ComboListItemInfo> listGrdMaster(String hospCode, String language, String codeType); 
	public BAS0101U00PrBasGridColumnChangedItemInfo callPrBasGridColumnChanged(String hospCode,String language,String masterCheck,String codeType,String colId);
	public List<ComboListItemInfo> getListBAS0001U00grdMaster(String hospCode, String language, String codeType);

	public String getBas0101U00TransactionAddedChk(String hospCode, String language, String codeType);
	
	public List<BAS0101U04GrdMasterInfo> getBAS0101U04GrdMasterInfo(String hospCode, String language, String codeType, Integer startNum, Integer offset);
	
	public List<ComboListItemInfo> getListDRGOCSCHKLoadCbxCHK(String hospCode, String language);
}

