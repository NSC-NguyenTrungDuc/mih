package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0101RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0101U00grdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR0101U00grdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdMasterInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Nur0101RepositoryImpl implements Nur0101RepositoryCustom {
private static final Log LOGGER = LogFactory.getLog(Nur0101RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<ComboListItemInfo> getCodeTypeCodeTypeNameListItemInfo (String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(CODE_TYPE, ' ')      CODE_TYPE,  ");       
		sql.append("	IFNULL(CODE_TYPE_NAME, ' ') CODE_TYPE_NAME     ");
		sql.append("	FROM NUR0101                                   ");
		sql.append("  WHERE LANGUAGE = :f_language                     ");
		sql.append("	          ORDER BY 1                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<ComboListItemInfo> resultList = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return resultList;
	}
	
	@Override
	public List<NUR0101U01GrdMasterInfo> getNUR0101U01GrdMasterInfo(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(CODE_TYPE, ' ')      CODE_TYPE,       ");
		sql.append("       IFNULL(CODE_TYPE_NAME, ' ') CODE_TYPE_NAME,  ");
		sql.append("       ADMIN_GUBUN              ADMIN_GUBUN         ");
		sql.append("  FROM NUR0101                                      ");
		sql.append(" WHERE CODE_TYPE LIKE :f_code_type                  ");
		sql.append("  AND LANGUAGE = :f_language                     	");
		sql.append(" ORDER BY 1                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType + "%");
		query.setParameter("f_language", language);
		List<NUR0101U01GrdMasterInfo> resultList = new JpaResultMapper().list(query, NUR0101U01GrdMasterInfo.class);
		return resultList;
	}
	
	@Override
	public List<NUR0101U00grdDetailInfo> getNUR0101U00grdDetailInfo(String hospCode, String language, String codeType, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(A.CODE_TYPE, ' ') CODE_TYPE,                                      ");
		sql.append("          IFNULL(A.CODE, ' ') CODE,                                                ");
		sql.append("          IFNULL(A.CODE_NAME, ' ') CODE_NAME,                                      ");
		sql.append("          IFNULL(A.SORT_KEY, '')  SORT_KEY ,                                       ");
		sql.append("          IFNULL(A.GROUP_KEY, '') GROUP_KEY,                                       ");
		sql.append("          IFNULL(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'),'') START_DATE,             ");
		sql.append("          IFNULL(DATE_FORMAT(A.END_DATE, '%Y/%m/%d'), '') END_DATE,                ");
		sql.append("          IFNULL(A.MENT, '') MENT,                                                 ");
		sql.append("          CONCAT(TRIM(IFNULL(A.CODE_TYPE, ' ')),TRIM(IFNULL(A.CODE, ' '))) `KEY`,  ");
		sql.append("          CAST(CASE WHEN A.END_DATE IS NULL THEN 1                                 ");
		sql.append("                  WHEN A.END_DATE < SYSDATE() THEN 1                               ");
		sql.append("                  ELSE 0 END AS CHAR) END_YN,                                      ");
		sql.append("          '' DATA_ROW_STATE					                                       ");
		sql.append("     FROM NUR0102 A                                                                ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                               ");
		sql.append("      AND A.CODE_TYPE = :f_code_type                                               ");
		sql.append("      AND A.LANGUAGE  = :f_language                                                ");
		sql.append("    ORDER BY CASE WHEN A.END_DATE IS NOT NULL AND A.END_DATE < SYSDATE() THEN 1    ");
		sql.append("                  ELSE 0 END                                                       ");
		sql.append("         , SORT_KEY, CODE, CODE_NAME                                               ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset												   ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR0101U00grdDetailInfo> resultList = new JpaResultMapper().list(query, NUR0101U00grdDetailInfo.class);
		return resultList;
		
	}
	
	@Override
	public List<NUR0101U00grdMasterInfo> getNUR0101U00grdMasterInfo(String language, String codeType, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(A.CODE_TYPE, ' ')      CODE_TYPE,        ");
		sql.append("          IFNULL(A.CODE_TYPE_NAME, ' ') CODE_TYPE_NAME,   ");
		sql.append("          '' DATA_ROW_STATE    							  ");
		sql.append("     FROM NUR0101 A                                       ");
		sql.append("    WHERE A.CODE_TYPE      LIKE :f_code_type              ");
		sql.append("      AND A.ADMIN_GUBUN    = 'USER'                       ");
		sql.append("      AND A.LANGUAGE       = :f_language                  ");
		sql.append("    ORDER BY CODE_TYPE                                    ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset						  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType + "%");
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR0101U00grdMasterInfo> resultList = new JpaResultMapper().list(query, NUR0101U00grdMasterInfo.class);
		return resultList;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR0101U00layComboItems(String language){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(A.CODE_TYPE, ' ')      CODE_TYPE,        ");
		sql.append("          IFNULL(A.CODE_TYPE_NAME, ' ') CODE_TYPE_NAME    ");
		sql.append("     FROM NUR0101 A                                       ");
		sql.append("     WHERE A.LANGUAGE  = :f_language                      ");
		sql.append("       AND A.ADMIN_GUBUN = 'USER'                         ");
		sql.append("       ORDER BY CODE_TYPE                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<ComboListItemInfo> resultList = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return resultList;
	}
	
	@Override
	public String getNUR0101U00grdMasterGridColumnChanged(String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                             ");
		sql.append("     FROM DUAL                                            ");
		sql.append("    WHERE EXISTS (SELECT 'X'                              ");
		sql.append("                    FROM NUR0101 A                        ");
		sql.append("                   WHERE A.LANGUAGE  = :f_language        ");
		sql.append("                     AND A.CODE_TYPE = :f_code_type)      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR0101U00grdDetailGridColumnChanged(String hospCode, String language, String codeType, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                             ");
		sql.append("     FROM DUAL                                            ");
		sql.append("    WHERE EXISTS (SELECT 'X'                              ");
		sql.append("                    FROM NUR0102 A                        ");
		sql.append("                   WHERE A.HOSP_CODE = :f_hosp_code       ");
		sql.append("                     AND A.LANGUAGE  = :f_language        ");
		sql.append("                     AND A.CODE_TYPE = :f_code_type       ");
		sql.append("                     AND A.CODE      = :f_code)           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
}

