package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1020Q00layIOInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layInOutTotalInfo;

/**
 * @author dainguyen.
 */
public interface Nur1022RepositoryCustom {

	public List<NUR1020Q00layInOutTotalInfo> getNUR1020Q00layInOutTotalInfo(String hospCode, String bunho,
			Double fkinp1001, String fromOpDate, String toOpDate);

	public List<NUR1020Q00layIOInfo> getNUR1020Q00layIOInfo(String hospCode, String language, String bunho,
			Double fkinp1001, String ymd);
}
