package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemHospitalInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00SystemHospitalInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;


/**
 * @author dainguyen.
 */
public interface AdmsGroupSystemRepositoryCustom {
	public List<ComboListItemInfo> getADMS2015U01System(String hospCode, String language);

	public List<ADMS2015U00GetSystemHospitalInfo> getADMS2015U00GetSystemHospitalInfo(String hospitalCode, String admsGroupId, String language);

	public String getADMS2015U01SystemIdValidating(String hospCode, String language, String sysId);

}

