package nta.med.data.dao.cms;

import java.util.List;

import nta.med.data.model.cms.CmsHospitalInfoInfo;;

public interface CmsHospitalInfoRepositoryCustom {

	public List<CmsHospitalInfoInfo> getListCmsHospitalInfo(String hospCode);
}
