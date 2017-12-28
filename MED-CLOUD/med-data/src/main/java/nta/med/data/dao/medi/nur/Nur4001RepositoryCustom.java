package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR4001U00GrdNUR4001Info;
import nta.med.data.model.ihis.nuri.NUR9001U00layComboNur4001Info;
import nta.med.data.model.ihis.nuri.NUR9001U00layNur4001Info;

/**
 * @author dainguyen.
 */
public interface Nur4001RepositoryCustom {

	public List<NUR4001U00GrdNUR4001Info> getNUR4001U00GrdNUR4001Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset);
	
	public void callPrNurNur4001Delete(String hospCode, Double pknur4001);

	public List<NUR9001U00layNur4001Info> getNUR9001U00layNur4001Info(String hospCode, String bunho, Double fkinp1001);

	public List<NUR9001U00layComboNur4001Info> getNUR9001U00layComboNur4001Info(String hospCode, Double fkinp1001);
}

