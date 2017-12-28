package nta.med.data.dao.medi.res;

import java.util.List;

import nta.med.data.model.ihis.drgs.DRG9001GetLay9001Info;
import nta.med.data.model.ihis.drgs.DRG9001R03lay9001RInfo;
import nta.med.data.model.ihis.drgs.DRG9001R04lay9001RInfo;


/**
 * @author dainguyen.
 */
public interface Res0101RepositoryCustom {
	
	public List<DRG9001GetLay9001Info> getDRG9001R01GetLay9001Info(String hospCode, String date);
	
	public List<DRG9001GetLay9001Info> getDRG9001R02GetLay9001Info(String hospCode, String date);
	
	public List<DRG9001R03lay9001RInfo> getDRG9001R03lay9001RInfo(String hospCode, String date, String hoDong);
	
	public List<DRG9001R04lay9001RInfo> getDRG9001R04lay9001RInfo(String hospCode, String date, String hoDong);
	
}

