package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdOCS0208Info;
import nta.med.data.model.ihis.ocsa.OCS0208U00GrdOCS0208Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0208U00GrdOCS0208U00ListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0208RepositoryCustom {
	
	public List<OcsaOCS0208U00GrdOCS0208U00ListInfo> getOcsaOCS0208U00GrdOCS0208U00List(String hospCode, String doctor, String bunryu1, String language);
	
	public List<String> getBogyongNameOcsaOCS0208U00CommonData(String hospCode, String doctor, String bogyongCode);
	public List<OCS0208U00GrdOCS0208Info> getOCS0208U00GrdOCS0208Info(String hospCode,String doctor, String language);
	public List<OCS0208Q01GrdOCS0208Info> getOCS0208Q01GrdOCS0208Info(String hospCode,String doctor, String language);
}

