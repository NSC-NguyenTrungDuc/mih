package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1001U00LayNUR1001Info;
import nta.med.data.model.ihis.nuri.NUR9999R11layPaInfoInfo;

public interface Nur1001RepositoryCustom {

	public List<NUR1001U00LayNUR1001Info> getNUR1001U00LayNUR1001Info(String hospCode, String bunho, String ipwonDate,
			Double fkinp1001);

	public String checkNUR1001U00isExist(String hospCode, String bunho, Double fkinp1001);

	public List<NUR9999R11layPaInfoInfo> getNUR9999R11layPaInfoInfo(String hospCode, String language, Date writeDate,
			Double fkinp1001);

}
