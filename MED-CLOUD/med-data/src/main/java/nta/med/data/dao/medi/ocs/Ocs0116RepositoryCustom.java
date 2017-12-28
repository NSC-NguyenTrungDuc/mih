package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0116RepositoryCustom {
	public String getOCS0116GetCodeNameByCode(String code, String hospCode);
	
	public List<ComboListItemInfo> getOCS0113U00GetFindWorker(String hospCode, boolean isOrder);
	
	public String getLoadColumnNameSpecimenCodeHangmogCase(String argu2, String argu1, String hospCode);
	
	public String getCpl0108U00DupYn(String hospCode, String code, String gubun);
}

