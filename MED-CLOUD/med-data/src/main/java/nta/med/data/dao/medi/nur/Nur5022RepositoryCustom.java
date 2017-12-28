package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00layNur5020Info;
import nta.med.data.model.ihis.nuri.NUR5020U00layNurCntInfo;

/**
 * @author dainguyen.
 */
public interface Nur5022RepositoryCustom {

	public List<NUR5020U00layNurCntInfo> getNUR5020U00layNurCntInfo(String hospCode, String language);

	public List<NUR5020U00layNur5020Info> getNUR5020U00layNur5020Info(String hospCode, String language, String hoDong,
			Date fDate);
}
