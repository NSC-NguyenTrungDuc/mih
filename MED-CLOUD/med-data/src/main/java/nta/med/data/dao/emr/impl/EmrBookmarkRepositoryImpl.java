package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.emr.EmrBookmarkRepositoryCustom;
import nta.med.data.model.ihis.emr.OCS2015U04EmrRecordLoadBookmarkContentInfo;
import nta.med.data.model.ihis.emr.OCS2015U04LoadBookmarkByPk0ut1001Info;

public class EmrBookmarkRepositoryImpl implements EmrBookmarkRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	public List<OCS2015U04EmrRecordLoadBookmarkContentInfo> getOCS2015U04EmrRecordLoadBookmarkContentInfo (String emrRecordId, String hospCode, String language){
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT DISTINCT																	");
		sql.append("	A.EMR_BOOKMARK_ID,                                                              ");
		sql.append("	A.BOOKMARK_TEXT,                                                                ");
		sql.append("	A.NAEWON_DATE,                                                                  ");
		sql.append("	A.SYS_ID,                                                                       ");
		sql.append("	B.USER_NM,                                                                      ");
		sql.append("	C.GWA,                                                                          ");
		sql.append("	FN_BAS_LOAD_GWA_NAME(C.GWA,A.NAEWON_DATE, :f_hosp_code, :f_language) GWA_NAME   ");
		sql.append("	FROM                                                                            ");
		sql.append("	EMR_BOOKMARK A, ADM3200 B, OUT1001 C                                            ");
		sql.append("	WHERE                                                                           ");
		sql.append("	A.EMR_RECORD_ID = :f_record_id                                                  ");
		sql.append("	AND B.USER_ID = A.SYS_ID AND A.PKOUT1001 = C.PKOUT1001                          ");
		sql.append("	AND A.ACTIVE_FLG = 1                                                            ");
		sql.append("	ORDER BY EMR_BOOKMARK_ID DESC                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_record_id", emrRecordId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		List<OCS2015U04EmrRecordLoadBookmarkContentInfo> list = new JpaResultMapper().list(query, OCS2015U04EmrRecordLoadBookmarkContentInfo.class);
		return list;

	}
	
	public List<OCS2015U04LoadBookmarkByPk0ut1001Info> getOCS2015U04LoadBookmarkByPk0ut1001Info (String pkout1001, String sysId, String emrRecordId){
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMR_BOOKMARK_ID					");
		sql.append("	, EMR_RECORD_ID                         ");
		sql.append("	, PKOUT1001                             ");
		sql.append("	, BOOKMARK_TEXT                         ");
		sql.append("	, NAEWON_DATE                           ");
		sql.append("	, SYS_ID                                ");
		sql.append("	, UPD_ID                                ");
		sql.append("	, CREATED                               ");
		sql.append("	, UPDATED                               ");
		sql.append("	, ACTIVE_FLG                            ");
		sql.append("	FROM EMR_BOOKMARK                       ");
		sql.append("	WHERE PKOUT1001 = :f_pkout1001          ");
		sql.append("	AND SYS_ID = :f_sys_id                  ");
		sql.append("	AND EMR_RECORD_ID = :f_emr_record_id    ");
		sql.append("	AND ACTIVE_FLG = '1'                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_pkout1001", pkout1001);
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_emr_record_id", emrRecordId);

		List<OCS2015U04LoadBookmarkByPk0ut1001Info> list = new JpaResultMapper().list(query, OCS2015U04LoadBookmarkByPk0ut1001Info.class);
		return list;
	}
}
