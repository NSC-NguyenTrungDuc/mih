package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT0101U00GrdMcodeInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0101RepositoryCustom {
	public List<XRT0101U00GrdMcodeInfo> getXRT0101U00GrdMCodeListItemInfo(String hospCode, String codeType, String language);
}

