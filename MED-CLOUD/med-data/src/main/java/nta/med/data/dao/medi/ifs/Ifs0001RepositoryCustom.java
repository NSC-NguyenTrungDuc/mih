package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.adma.IFS0001U00GrdMasterInfo;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0001Info;

/**
 * @author dainguyen.
 */
public interface Ifs0001RepositoryCustom {
	
	public List<IFS0001U00GrdMasterInfo> getIFS0001U00GrdMasterInfo(String hospCode, String codeType, String acctType);
	
	public String checkGrdDetailColumnChanged(String masterCheck, String hospCode, String codeType, String colId);
	
	public List<ComBizLoadIFS0001Info> getComBizLoadIFS0001ListItem(String hospCode, String codeType);
}

