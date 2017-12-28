package nta.med.data.dao.medi.pfe;

import java.util.List;

import nta.med.data.model.ihis.adma.PFE0101U01GrdMcodeInfo;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdMCodeInfo;

/**
 * @author dainguyen.
 */
public interface Pfe0101RepositoryCustom {
	public List<PFE0101U00GrdMCodeInfo> getPFE0101U00GrdMCodeInfo(String codeType, String language);
	
	public List<PFE0101U01GrdMcodeInfo> getPFE0101U01GrdMcodeInfo(String codeType, String language);
}

