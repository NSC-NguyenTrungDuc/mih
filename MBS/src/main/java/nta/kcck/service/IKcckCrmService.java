package nta.kcck.service;

import nta.kcck.model.KcckCrmModel;
import nta.mss.model.CrmModel;

public interface IKcckCrmService {

	public CrmModel getListCrm(KcckCrmModel model);
	
}
