package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT0001U00GrdRadioListInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0002RepositoryCustom {
	public List<XRT0001U00GrdRadioListInfo> getXRT0001U00GrdRadioListItemInfo(String hospCode, String xrayCode);
}

