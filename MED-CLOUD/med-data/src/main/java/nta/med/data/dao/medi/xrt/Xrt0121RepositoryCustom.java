package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT0122U00GrdMcodeInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0121RepositoryCustom {
	public List<XRT0122U00GrdMcodeInfo> getInitializeItem(String hospCode, String buwibunryu, String language);
	
	public String getXRT0122U00LayDupM(String hospCode, String buwiBunryu, String language);
}

