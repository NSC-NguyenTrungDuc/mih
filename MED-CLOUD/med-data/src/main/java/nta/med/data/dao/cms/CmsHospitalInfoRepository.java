package nta.med.data.dao.cms;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsHospitalInfo;

public interface CmsHospitalInfoRepository extends JpaRepository<CmsHospitalInfo, Long>, CmsHospitalInfoRepositoryCustom{
	
	@Query("SELECT T FROM CmsHospitalInfo T WHERE T.hospCode = :hosp_code and T.activeFlg = 1")
	public CmsHospitalInfo findByHospCode(@Param("hosp_code") String hospCode);
	
}
