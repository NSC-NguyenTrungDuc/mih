package nta.med.data.dao.medi.adm;

import nta.med.data.model.ihis.system.LoginExtInfo;

public interface LoginExtRepositoryCustom {

	public LoginExtInfo getLoginExt(String userId, String hospCode);
	
} 

