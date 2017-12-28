package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT1002U00DsvSideEffectInfo;

/**
 * @author dainguyen.
 */
public interface Xrt1001RepositoryCustom {
	public List<XRT1002U00DsvSideEffectInfo> getXRT1002U00DsvSideEffectInfo(String hospCode, String bunho);
}

