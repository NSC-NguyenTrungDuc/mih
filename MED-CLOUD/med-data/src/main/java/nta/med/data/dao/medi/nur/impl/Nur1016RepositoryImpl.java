package nta.med.data.dao.medi.nur.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1016RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1016Info;
import nta.med.data.model.ihis.nuri.NUR1016U00GrdNUR1016ListItemInfo;
import nta.med.data.model.ihis.nuri.NuriManageAllergyListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Nur1016RepositoryImpl implements Nur1016RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Nur1016RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuriManageAllergyListItemInfo> getNuriManageAllergyListItemInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT PKNUR1016          PKNUR1016         ");
		sql.append("      ,BUNHO              BUNHO             ");
		sql.append("      ,ALLERGY_GUBUN      ALLERGY_GUBUN     ");
		sql.append("      ,ALLERGY_INFO       ALLERGY_INFO      ");
		sql.append("      ,START_DATE         START_DATE        ");
		sql.append("      ,END_DATE           END_DATE          ");
		sql.append("      ,END_SAYU           END_SAYU          ");
		sql.append("      ,INPUT_TEXT         INPUT_TEXT        ");
		sql.append("      ,'Y'                                  ");
		sql.append("  FROM NUR1016                              ");
		sql.append(" WHERE HOSP_CODE           = :hospCode   ");
		sql.append("   AND BUNHO               = :bunho       ");
		sql.append("   AND IFNULL(CANCEL_YN, 'N') = 'N'         ");
		sql.append(" ORDER BY START_DATE DESC                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);

		List<NuriManageAllergyListItemInfo> list = new JpaResultMapper().list(query, NuriManageAllergyListItemInfo.class);
		return list;
	}
	
	@Override
	public String callNuriNUR1016U00NurAlegyMapping(String hospCode, String bunho, String tableId, String userId){
		LOG.info("[START] callNuriNUR1016U00NurAlegyMapping hospCode=" + hospCode + ", bunho=" + bunho + ", tableId=" + tableId + ", userId=" + userId);
		String ioFlg = "";
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_ALERGY_MAPPING");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TABLE_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_TABLE_ID", tableId);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("O_FLAG", "");
		
		query.execute();
		ioFlg = (String)query.getOutputParameterValue("O_FLAG");
		return ioFlg;
	}

	@Override
	public List<NUR1016U00GrdNUR1016ListItemInfo> NUR1016U00GrdNUR1016ListItem(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT PKNUR1016          PKNUR1016         ");
		sql.append("       ,BUNHO              BUNHO             ");
		sql.append("       ,ALLERGY_GUBUN      ALLERGY_GUBUN     ");
		sql.append("       ,ALLERGY_INFO       ALLERGY_INFO      ");
		sql.append("       ,DATE_FORMAT(START_DATE, '%Y/%m/%d')         START_DATE        ");
		sql.append("       ,DATE_FORMAT(END_DATE, '%Y/%m/%d')            END_DATE          ");
		sql.append("       ,END_SAYU           END_SAYU          ");
		sql.append("       ,INPUT_TEXT         INPUT_TEXT        ");
		sql.append("       ,'Y'                                  ");
		sql.append("       ,''                                   ");
		sql.append("   FROM NUR1016                              ");
		sql.append("  WHERE HOSP_CODE           = :hospCode      ");
		sql.append("    AND BUNHO               = :bunho         ");
		sql.append("    AND IFNULL(CANCEL_YN, 'N') = 'N'         ");
		sql.append("  ORDER BY START_DATE DESC                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);

//		List<Object> result = query.getResultList();
		
		List<NUR1016U00GrdNUR1016ListItemInfo> list = new JpaResultMapper().list(query, NUR1016U00GrdNUR1016ListItemInfo.class);
		return list;
	}
	
	@Override
	public String getOpenAllergyInfo(String hospCode, String bunho, Date appDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_NUR_ALLERGY_YN_LOAD(:f_hosp_code, :f_bunho, :f_app_date) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_app_date", appDate);
		
		List<String> list = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		
		return null;
	}
	
	@Override
	public List<NUR1001U00GrdNUR1016Info> getNUR1001U00GrdNUR1016Info(String hospCode, String bunho, String language, String sysDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT DATE_FORMAT(A.START_DATE, '%Y/%m/%d')                                          ");
		sql.append("        , B.CODE_NAME                                                                    ");
		sql.append("        , A.ALLERGY_INFO                                                                 ");
		sql.append("        , '' DATA_ROW_STATE                                                              ");
		sql.append("     FROM NUR1016 A                                                                      ");
		sql.append("     JOIN NUR0102 B                                                                      ");
		sql.append("       ON B.HOSP_CODE = A.HOSP_CODE                                                      ");
		sql.append("      AND B.CODE      = A.ALLERGY_GUBUN                                                  ");
		sql.append("      AND B.LANGUAGE  = :f_language                                                      ");
		sql.append("      AND B.CODE_TYPE = 'ALLERGY_GUBUN'                                                  ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                     ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                         ");
		sql.append("      AND STR_TO_DATE(:f_sys_date, '%Y/%m/%d') BETWEEN A.START_DATE                      ");
		sql.append("                      AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))       ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END = 'N'     ");
		sql.append("    ORDER BY A.START_DATE DESC                                                           ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset														 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_sys_date", sysDate);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001U00GrdNUR1016Info> list = new JpaResultMapper().list(query, NUR1001U00GrdNUR1016Info.class);
		return list;
	}
}

