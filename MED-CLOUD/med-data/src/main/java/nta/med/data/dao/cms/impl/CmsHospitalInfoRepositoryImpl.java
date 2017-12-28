package nta.med.data.dao.cms.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsHospitalInfoRepositoryCustom;
import nta.med.data.model.cms.CmsHospitalInfoInfo;



public class CmsHospitalInfoRepositoryImpl implements CmsHospitalInfoRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CmsHospitalInfoInfo> getListCmsHospitalInfo(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.HOSP_CODE,													");
		sql.append("	        A.HOSP_NAME,													");
		sql.append("	        A.LOGO,															");
		sql.append("	        A.ADDRESS,														");
		sql.append("	        A.LOCALE														");
		sql.append("	FROM    cms_hospital_info A												");
		sql.append("	WHERE   A.HOSP_CODE = :f_hospcode										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospcode", hospCode);
		
		List<CmsHospitalInfoInfo> listQuestion = new JpaResultMapper().list(query, CmsHospitalInfoInfo.class);
		
		return listQuestion;
	}
}
