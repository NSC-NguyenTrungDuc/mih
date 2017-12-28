package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1020U00layNUR7002Info;
import nta.med.data.model.ihis.nuri.NUR1020U00layWriterBAInfo;

/**
 * @author dainguyen.
 */
public interface Nur7002RepositoryCustom {

	public List<NUR1020U00layNUR7002Info> getNUR1020U00layNUR7002Info(String hospCode, Date ymd, String bunho, Double fkinp1001);
	
	public List<NUR1020U00layWriterBAInfo> getNUR1020U00layWriterBAInfo(String hospCode, String ymd, String bunho, Double fkinp1001);
}
