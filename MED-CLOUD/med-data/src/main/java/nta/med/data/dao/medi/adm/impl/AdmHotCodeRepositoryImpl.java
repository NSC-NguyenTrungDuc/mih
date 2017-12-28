package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.AdmHotCodeRepositoryCustom;
import nta.med.data.model.ihis.bass.HOTCODEMASTERGetGrdListInfo;

public class AdmHotCodeRepositoryImpl implements AdmHotCodeRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Integer truncateAdmHotCode() {
		StringBuilder sql = new StringBuilder();
		sql.append(" Truncate ADM_HOTCODE ");
		Query query = entityManager.createNativeQuery(sql.toString());
		return query.executeUpdate();
	}

	@Override
	public List<HOTCODEMASTERGetGrdListInfo> getHOTCODEMASTERGetGrdListInfo(String hotCode, String hangmogName, Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT	HOTCODE, HOTCODE7, CIN_CODE, DISPENSE_CODE, LOGISTIC_CODE,		");
		sql.append("			JAN_CODE, YAK_KIJUN_CODE, YJ_CODE, SG_CODE, SG_CODE1,			");
		sql.append("			HANGMOG_NAME, HANGMOG_NAME1, HANGMOG_NAME2, STANDARD_UNIT,		");
		sql.append("			PKG_STATUS, PKG_NUM_UNIT, ORD_DANUI, PKG_TOTAL, PKG_TOTAL_UNIT,	");
		sql.append("			CLASSIF, MANUF_COMP, SALES_COMP, CLASSIF_UPD, SG_YMD			");
		sql.append("	FROM 	ADM_HOTCODE														");
		sql.append("	WHERE	HOTCODE like :f_hot_code										");
		sql.append("	AND		HANGMOG_NAME like :f_hangmog_name								");
		sql.append(" LIMIT :f_page_number,:f_offset                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hot_code", "%" + hotCode + "%");
		query.setParameter("f_hangmog_name", "%" + hangmogName + "%");
		query.setParameter("f_page_number",pageNumber);
		query.setParameter("f_offset", offset);
		
		List<HOTCODEMASTERGetGrdListInfo> listData = new JpaResultMapper().list(query, HOTCODEMASTERGetGrdListInfo.class);
		
		return listData;
	}
	
}
