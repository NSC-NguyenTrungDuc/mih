package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogListInfo;
import nta.med.data.model.ihis.ocso.OCSACTDefaultJearyoInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdJaeryoGridColumnChangedInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0313RepositoryCustom {
	public List<OCS0311U00grdSetHangmogListInfo> getOCS0311U00grdSetHangmogListInfo(String hospCode,String setPart,String hangmogCode,String setCode, String language);
	public List<OCSACTDefaultJearyoInfo> getOCSACTDefaultJearyoInfo(String hospCode,String language,String hangmogCode);
	public List<OCSACTGrdJaeryoGridColumnChangedInfo> getOCSACTGrdJaeryoGridColumnChangedInfo(String hospCode,String language,String hangmogCode,
			String setHangmogCode, boolean xrts);
	public List<OCSACTGrdJaeryoGridColumnChangedInfo> getOCSACTGrdJaeryoGridColumnChangedInfoCaseElse(String hospCode,String language,String hangmogCode, 
			boolean xrts);
	public List<OCS0311Q00LayDownListInfo> getOCS0311Q00LayDownListInfo(String hospCode,String setPart,String hangmogCode,String setCode, String language);
}

