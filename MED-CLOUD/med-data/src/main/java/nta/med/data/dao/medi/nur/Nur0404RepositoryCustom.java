package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0401U01GrdNur0404Info;

/**
 * @author dainguyen.
 */
public interface Nur0404RepositoryCustom {
	
	public List<NUR0401U01GrdNur0404Info> getNUR0401U01GrdNur0404Info(String hospCode, String nurPlanJin,
			String nurPlan, Integer startNum, Integer offset);
	
	public String getNUR0401U01SelectNewCode0404(String hospCode, String maxVal, String nurPlanJin, String nurPlan);
	
	public Integer deleteNur0404InNUR0401U01(String hospCode, String code);
}

