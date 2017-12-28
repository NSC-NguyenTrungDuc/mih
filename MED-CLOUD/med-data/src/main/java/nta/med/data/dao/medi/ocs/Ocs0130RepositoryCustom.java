package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.OcsLoadInputControlListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0130RepositoryCustom {
	public String getOCS0304U00GetDoctorYaksokOpenId(String hospCode, String doctor);
	
	public List<OcsLoadInputControlListItemInfo> getOcslibControlListItem(String hospCode, String language, String inputControl);
	
	public String getMembName(String hospCode, String userId);
	
	public List<ComboListItemInfo> getSangOpenDoctorNameInfo(String hospCode, String doctorGwa);
	
	public String getOcsComUserId(String hospCode, String userGubun, String userId);
}

