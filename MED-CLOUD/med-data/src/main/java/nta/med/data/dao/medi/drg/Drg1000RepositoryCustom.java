package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.drgs.DRG3010P10LayAntiDataInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01AntiDataListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LayAntiDataListItemInfo;

/**
 * @author dainguyen.
 */
public interface Drg1000RepositoryCustom {
	public List<DrgsDRG5100P01AntiDataListItemInfo> getDrgsDRG5100P01OrderListItemInfo(String hospitalCode, String fkocs);
	
	public List<String> getDrgsDRG5100P01FkocList(String hospCode, String jubsuDate, String drgBunho);
	
	public List<DrgsDRG5100P01LayAntiDataListItemInfo> getDrgsDRG5100P01LayAntiDataListItemInfo(String hospCode, String language,
			String fkocs);
	
	public List<DRG3010P10LayAntiDataInfo> getDRG3010P10LayAntiDataInfo(String hospCode, String fkocs);
}

