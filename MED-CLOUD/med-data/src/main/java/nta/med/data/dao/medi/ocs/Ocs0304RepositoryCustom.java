package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0304Q00layOCS0304Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0304ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0305ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0306ListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0304RepositoryCustom {
	
	public List<OcsaOCS0304U00GrdOCS0304ListInfo> getOcsaOCS0304U00GrdOCS0304ListInfo(String hospCode, String membGubun, String doctor, String yaksokDirectCode);
	
	public List<OcsaOCS0304U00GrdOCS0305ListInfo> getOcsaOCS0304U00GrdOCS0305ListInfo(String hospCode, String membGubun, String doctor, String yaksokDirectCode);
	
	public List<OcsaOCS0304U00GrdOCS0306ListInfo> getOcsaOCS0304U00GrdOCS0306ListInfo(String hospCode, String membGubun, String doctor, String yaksokDirectCode);
	
	public String getOCS0304U00GetYaksokDirectName(String hospCode, String membGubun,String code, String doctor);
	
	public List<OcsaOCS0304U00GrdOCS0305ListInfo> getOcsaOCS0304U00GrdOCS0305ListInfoext(String hospCode, String memb);
	
	public List<OCS0304Q00layOCS0304Info> getOCS0304Q00layOCS0304Info(String hospCode, String memb);
}

