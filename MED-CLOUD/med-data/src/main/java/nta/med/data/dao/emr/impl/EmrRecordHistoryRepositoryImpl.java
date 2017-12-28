package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.emr.EmrRecordHistoryRepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U40EmrHistoryMedicalRecordInfo;

public class EmrRecordHistoryRepositoryImpl implements EmrRecordHistoryRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public Integer getOcs2015U44LastVerSionInsert(String recordId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT MAX(VERSION)     			");
		sql.append("	FROM EMR_RECORD_HISTORY             ");
		sql.append("	WHERE EMR_RECORD_ID = :recordId     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("recordId", recordId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		return null;
	}

	
	@Override
	public Integer getOcs2015U44OldestVerSionInsert(String recordId) {
StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT MIN(VERSION)  				");
		sql.append("	FROM EMR_RECORD_HISTORY             ");
		sql.append("	WHERE EMR_RECORD_ID = :recordId     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("recordId", recordId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		return null;
	}


	@Override
	public Integer getOcs2015U44TotalVersionCount(String recordId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COUNT(*)	FROM EMR_RECORD_HISTORY ");
		sql.append(" WHERE EMR_RECORD_ID = :recordId            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("recordId", recordId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		return null;
	}

	@Override
	public Integer getOcs2015U44OldestVersionCount(String recordId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT MIN(VERSION)	FROM EMR_RECORD_HISTORY		 ");
		sql.append(" WHERE EMR_RECORD_ID = :recordId 		           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("recordId", recordId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		return null;
	}


	@Override
	public ComboListItemInfo getOCS2015U40EmrMedicalRecordHisotryContentListItem(
			Integer recordId, Integer version) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CONTENT, METADATA						");		
		sql.append("	FROM EMR_RECORD_HISTORY						    ");
		sql.append("	WHERE EMR_RECORD_ID = :record_id	            ");
		sql.append("	AND VERSION = :version                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("record_id", recordId);
		query.setParameter("version", version);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2015U40EmrHistoryMedicalRecordInfo> getOCS2015U40EmrHistoryMedicalRecordListItem(
			Integer emrReCordId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																							");
		sql.append("		  H.EMR_RECORD_ID, 																			");
		sql.append("		  H.SYS_ID, 						       													");
		sql.append("		  H.CREATED, 							   													");
		sql.append("		  H.RECORD_LOG, 							   												");
		sql.append("		  H.ACTIVE_FLG, 							   												");
		sql.append("		  H.VERSION,                                												");
		sql.append("		  A.USER_NM		                       														");
		sql.append("	FROM EMR_RECORD H, ADM3200 A WHERE   H.EMR_RECORD_ID = :record_id  AND  H.SYS_ID = A.USER_ID 	");
		sql.append("	UNION ALL                                              											");
		sql.append("	SELECT											       											");
		sql.append("		H.EMR_RECORD_ID, 																			");
		sql.append("		H.SYS_ID, 										       										");
		sql.append("		H.CREATED,										   											");
		sql.append("		H.RECORD_LOG, 								   												");
		sql.append("		H.ACTIVE_FLG, 										   										");
		sql.append("		H.VERSION, 				                           											");
		sql.append("		A.USER_NM			                   														");
		sql.append("	FROM EMR_RECORD_HISTORY H, EMR_RECORD E, ADM3200 A 		                  						");
		sql.append("	WHERE H.EMR_RECORD_ID = :record_id AND H.EMR_RECORD_ID = E.EMR_RECORD_ID               			");
		sql.append("	 AND E.HOSP_CODE = A.HOSP_CODE  AND H.SYS_ID = A.USER_ID 	               						");
		sql.append("	ORDER BY VERSION DESC 							   												");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("record_id", emrReCordId);
		
		List<OCS2015U40EmrHistoryMedicalRecordInfo> list = new JpaResultMapper().list(query, OCS2015U40EmrHistoryMedicalRecordInfo.class);
		return list;
	}

}
