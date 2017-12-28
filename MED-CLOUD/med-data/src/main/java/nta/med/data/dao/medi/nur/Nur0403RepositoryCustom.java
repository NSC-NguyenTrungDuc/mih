package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0401U01GrdNur0403Info;
import nta.med.data.model.ihis.nuri.NUR4001U00LayPlanQueryStartInfo;

/**
 * @author dainguyen.
 */
public interface Nur0403RepositoryCustom {
	
	public List<NUR0401U01GrdNur0403Info> getNUR0401U01GrdNur0403Info(String hospCode, String nurPlanJin,
			String nurPlanOte, Integer startNum, Integer offset);
	
	public Integer deleteNUR0403InNUR0401U01(String hospCode, String code);
	
	public List<NUR4001U00LayPlanQueryStartInfo> getNUR4001U00LayPlanQueryStartInfoCase1(String hospCode,
			String nurPlanJin, Double fknur4001);
	
	public List<NUR4001U00LayPlanQueryStartInfo> getNUR4001U00LayPlanQueryStartInfoCase2(String hospCode,
			Double fknur4001);
}
