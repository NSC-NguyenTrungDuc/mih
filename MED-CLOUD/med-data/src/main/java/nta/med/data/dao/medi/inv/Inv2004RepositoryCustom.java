package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.invs.INV2003U00GrdINV2004Info;

public interface Inv2004RepositoryCustom {
	
	public List<INV2003U00GrdINV2004Info> getGridINV2004Info(String hospCode, Double fkinv2003, String language);

}
