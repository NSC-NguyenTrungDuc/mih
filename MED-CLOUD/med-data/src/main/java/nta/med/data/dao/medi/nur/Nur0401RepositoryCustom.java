package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR4001U00FwkJinInfo;

/**
 * @author dainguyen.
 */
public interface Nur0401RepositoryCustom {

	public String getNUR0401U01SelectNewCode0401(String hospCode, String maxVal, String nurPlanBunryu);

	public List<NUR4001U00FwkJinInfo> getNUR4001U00FwkJinInfo(String hospCode, String nurPlanBunryu);
}

