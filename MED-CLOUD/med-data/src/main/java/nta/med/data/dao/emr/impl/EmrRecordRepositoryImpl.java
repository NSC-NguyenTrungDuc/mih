package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.EMRUserGetLockEditingInfo;
import nta.med.data.model.ihis.emr.EmrRecordGetOldDataInfo;
import nta.med.data.model.ihis.emr.OCS2015U00LoadPatientMedicalRecordInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrRecordInfo;
import nta.med.data.model.ihis.emr.PatientEmailInfo;

import org.springframework.util.CollectionUtils;

public class EmrRecordRepositoryImpl implements EmrRecordRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS2015U06EmrRecordInfo> getOCS2015U06EmrRecordInfo( String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 						    ");
		sql.append("	A.EMR_RECORD_ID,                ");
		sql.append("	A.BUNHO,                        ");
		sql.append("	'' PKOUT1001,   	             ");
		sql.append("	'' NAEWON_DATE,            		 ");
		sql.append("	A.CONTENT,                      ");
		sql.append("	A.METADATA,                     ");
		sql.append("	A.VERSION,                      ");
		sql.append("	A.ACTIVE_FLG,                   ");
		sql.append("	A.CREATED,                      ");
		sql.append("	A.UPDATED,                      ");
		sql.append("	'' AS GWA 						");
		sql.append("	FROM EMR_RECORD A                ");
		sql.append("	WHERE A.BUNHO = :f_bunho        ");
		sql.append("	AND A.HOSP_CODE = :f_hosp_code  ");
		sql.append("	AND A.ACTIVE_FLG = '1'          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);

		List<OCS2015U06EmrRecordInfo> list = new JpaResultMapper().list(query, OCS2015U06EmrRecordInfo.class);
		return list;
	}
		
	//[1] Check user created bookmark
	public boolean checkUserCreateBookmark (String recordId, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT COUNT(*) FROM EMR_RECORD WHERE EMR_RECORD_ID = :f_record_id AND SYS_ID = :f_user_id	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_record_id", recordId);
		query.setParameter("f_user_id", userId);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null 
				&& CommonUtils.parseInteger(result.get(0).toString()) > 0 ) { 
			return true;
		}
		return false;
	}
	
	//[2] Get user who is editing record
	public String getUserEditingRecord (String recordId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT UPD_ID FROM EMR_RECORD WHERE EMR_RECORD_ID = :f_record_id ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_record_id", recordId);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	//[3] Processing get lock editing
	public EMRUserGetLockEditingInfo getEMRUserGetLockEditingInfo(String recordId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT LOCK_FLG, UPD_ID, UPDATED FROM EMR_RECORD WHERE EMR_RECORD_ID = :f_record_id AND ACTIVE_FLG = 1");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_record_id", recordId);
		
		List<EMRUserGetLockEditingInfo> result = new JpaResultMapper().list(query, EMRUserGetLockEditingInfo.class);
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}
	
	//[4] Get editing time
	public boolean getEditingTime (String recordId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT COUNT(*) FROM EMR_RECORD WHERE EMR_RECORD_ID = :f_record_id AND (TIME_TO_SEC(UPDATED) > (TIME_TO_SEC(CURRENT_TIMESTAMP()) - 2 * 60 * 60))  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_record_id", recordId);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null 
				&& CommonUtils.parseInteger(result.get(0).toString()) > 0 ) { 
			return true;
		}
		return false;
	}
	
	@Override
	public ComboListItemInfo getOCS2015U40EmrMedicalRecordContentListItem(
			String emrReCordId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CONTENT, METADATA				");								
		sql.append("	FROM EMR_RECORD							");	
		sql.append("	WHERE EMR_RECORD_ID = :record_id		");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("record_id", emrReCordId);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}

	@Override
	public Integer getEmrRecordId(String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT EMR_RECORD_ID				");
		sql.append("	FROM EMR_RECORD                     ");
		sql.append("	WHERE BUNHO = :bunho                ");
		sql.append("	AND HOSP_CODE =:hospCode            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<Integer> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	public PatientEmailInfo getCreatedRecordLog (String emrRecordId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CREATED, RECORD_LOG FROM EMR_RECORD WHERE EMR_RECORD_ID = :f_emr_record_id");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_emr_record_id", emrRecordId);
		
		List<PatientEmailInfo> result = new JpaResultMapper().list(query, PatientEmailInfo.class);
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}

	@Override
	public Integer getEmrRecordMaxVersion(Integer recordId) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT MAX(VERSION)     			");
		sql.append("	FROM EMR_RECORD			            ");
		sql.append("	WHERE EMR_RECORD_ID = :recordId     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("recordId", recordId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		return null;
	}
	
	public EmrRecordGetOldDataInfo getEmrRecordGetOldDataInfo (String emrRecordId) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMR_RECORD_ID					");
		sql.append("	     , CONTENT                          ");
		sql.append("	     , VERSION                          ");
		sql.append("	     , SYS_ID                           ");
		sql.append("	     , RECORD_LOG                       ");
		sql.append("	     , METADATA                         ");
		sql.append("	     , CREATED                         ");
		sql.append("	FROM EMR_RECORD                         ");
		sql.append("	WHERE EMR_RECORD_ID = :f_emr_record_id  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_emr_record_id", emrRecordId);
		
		List<EmrRecordGetOldDataInfo> result = new JpaResultMapper().list(query, EmrRecordGetOldDataInfo.class);
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public OCS2015U00LoadPatientMedicalRecordInfo getOCS2015U00LoadPatientMedicalRecordInfo (String bunho, String hospCode) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMR_RECORD_ID, 	");
		sql.append("	CONTENT,                ");
		sql.append("	METADATA,               ");
		sql.append("	VERSION,                ");
		sql.append("	RECORD_LOG,             ");
		sql.append("	LOCK_FLG,               ");
		sql.append("	HOSP_CODE,              ");
		sql.append("	BUNHO,                  ");
		sql.append("	SYS_ID,                 ");
		sql.append("	UPD_ID,                 ");
		sql.append("	CREATED,                ");
		sql.append("	UPDATED                 ");
		sql.append("	FROM EMR_RECORD         ");
		sql.append("	WHERE BUNHO = :f_bunho and HOSP_CODE = :hospCode");
		sql.append("	AND ACTIVE_FLG = '1'    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("hospCode", hospCode);

		List<OCS2015U00LoadPatientMedicalRecordInfo> result = new JpaResultMapper().list(query, OCS2015U00LoadPatientMedicalRecordInfo.class);
		if (!CollectionUtils.isEmpty(result)) {
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public Integer getOcs2015U00EmrNoInfo(String hospCode,String patientCode) {
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT  EMR_RECORD_ID															");
		 sql.append("FROM EMR_RECORD                                                                ");
		 sql.append("WHERE HOSP_CODE = :f_hosp_code                            		                ");
		 sql.append(" AND BUNHO = :f_patient_code                                                   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return Integer.parseInt(result.get(0).toString());
		}
		
		return null;
	}
}
