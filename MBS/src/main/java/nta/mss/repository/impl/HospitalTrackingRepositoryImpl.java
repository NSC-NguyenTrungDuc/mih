package nta.mss.repository.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.model.HospitalTrackingModel;
import nta.mss.repository.HospitalTrackingRepositoryCustom;

public class HospitalTrackingRepositoryImpl implements HospitalTrackingRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	

	@Override
	public List<HospitalTrackingModel> getTrackingCodeByPageCode(Integer hospitalId) {		
		
		StringBuilder sql =  new StringBuilder();
		sql.append("   SELECT                              				");		
		sql.append("   A.hospital_id                   					");			
		sql.append("   ,A.tracking_script                    			");		
		sql.append("   ,A.page_code                  					");		
		sql.append("   FROM hospital_tracking 	A             			");
		sql.append("   WHERE A.active_flg = 1               			");
		sql.append("   AND A.hospital_id = :hospitalId  				");		
			
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalId", hospitalId);
		List<HospitalTrackingModel> list  =  new JpaResultMapper().list(query, HospitalTrackingModel.class);	
	
		return list;	
		
		}



}
