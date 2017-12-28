package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupHospitalInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GroupHospitalInfo;


/**
 * @author dainguyen.
 */
public interface AdmsGroupRepositoryCustom {
	public List<ADMS2015U00GetGroupHospitalInfo> getADMS2015U00GetGroupHospitalInfo (String hospCode, String language);
}

