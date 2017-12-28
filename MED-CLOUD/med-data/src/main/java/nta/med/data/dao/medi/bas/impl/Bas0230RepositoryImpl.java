package nta.med.data.dao.medi.bas.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0230RepositoryCustom;
import nta.med.data.model.ihis.adma.BAS0230U00GrdBAS0230Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Bas0230RepositoryImpl implements Bas0230RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Bas0230RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BAS0230U00GrdBAS0230Info> getBAS0230U00GrdBAS0230(String hospCode, String language, String startYmd){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUN_CODE,                                                                  ");
		sql.append("       A.BUN_NAME,                                                                  ");
		sql.append("       A.BUN_YMD								                                    ");
		sql.append("  FROM BAS0230 A                                                                    ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code AND A.LANGUAGE = :language                        ");
		sql.append("   AND A.BUN_YMD   = (SELECT MAX(Z.BUN_YMD)                                         ");
		sql.append("                        FROM BAS0230 Z                                              ");
		sql.append("                       WHERE Z.HOSP_CODE = A.HOSP_CODE AND Z.LANGUAGE = A.LANGUAGE  ");
		sql.append("                         AND Z.BUN_CODE  = A.BUN_CODE                               ");
		sql.append("                         AND Z.BUN_YMD  <= STR_TO_DATE(:f_start_ymd, '%Y/%m/%d'))   ");
		sql.append("ORDER BY A.BUN_CODE                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_start_ymd", startYmd);
		query.setParameter("language", language);
		List<BAS0230U00GrdBAS0230Info> listResult = new JpaResultMapper().list(query, BAS0230U00GrdBAS0230Info.class);
		return listResult;
	}
	
	public List<ComboListItemInfo> getBunCodeBunNameListItemInfo(String hospCode, String language, String find1, String bunYmd, boolean bun, boolean isAll){
		StringBuilder sql = new StringBuilder();
		
		if(isAll){
			sql.append(" SELECT '%', 'All'			 UNION ALL	                                  ");
		}
		sql.append("	SELECT A.BUN_CODE							                               ");
		sql.append("	, A.BUN_NAME                                                               ");
		sql.append("	FROM BAS0230 A                                                             ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code  AND A.LANGUAGE = :language               ");
		sql.append("	AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD)                                     ");
		sql.append("					 FROM BAS0230 B                                            ");
		sql.append("					WHERE B.HOSP_CODE = A.HOSP_CODE  AND B.LANGUAGE = A.LANGUAGE   ");
		sql.append("					AND B.BUN_CODE = A.BUN_CODE                                    ");
		if(bun){
			sql.append("					AND B.BUN_YMD <= STR_TO_DATE(:f_bun_ymd, '%Y/%m/%d')       ");
		}
		sql.append("					)              							                   ");
		sql.append("	AND ( A.BUN_CODE LIKE :f_find1		 		                               ");
		sql.append("		  OR A.BUN_NAME LIKE :f_find1)				                           ");
		sql.append("	ORDER BY 1                                                                 ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		if(bun){
			query.setParameter("f_bun_ymd", bunYmd);	
			query.setParameter("f_find1", "%"+find1+"%");	
		}else{
			query.setParameter("f_find1", find1+"%");
		}
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;		
	}
	
	public String getBunNameItemInfo (String hospCode, String language, String bunCode, String bunYmd, boolean bun){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUN_NAME 					                                          ");
		sql.append("	FROM BAS0230 A                                                                ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code  AND A.LANGUAGE = :language                  ");
		sql.append("	AND A.BUN_CODE = :f_bun_code                                                  ");
		sql.append("	AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD)                                        ");
		sql.append("					 FROM BAS0230 B                                               ");
		sql.append("					 WHERE B.HOSP_CODE = A.HOSP_CODE AND B.LANGUAGE = A.LANGUAGE  ");
		sql.append("					 AND B.BUN_CODE = A.BUN_CODE                                  ");
		if(bun){
			sql.append("					 AND B.BUN_YMD <= STR_TO_DATE(:f_bun_ymd, '%Y/%m/%d')          ");	
		}
		sql.append("					 )                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bun_code", bunCode);
		if(bun){
			query.setParameter("f_bun_ymd", bunYmd);	
		}
		query.setParameter("language", language);
		@SuppressWarnings("unchecked")
		List<String> result= query.getResultList();
		
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getComboNuGroup(String hospCode, String language, boolean isAll){
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append(" SELECT '%', FN_ADM_MSG('221',:language)   ");
			sql.append(" UNION ALL                                 ");
		}
		sql.append(" SELECT BUN_CODE, BUN_NAME                 ");
		sql.append("   FROM BAS0230                            ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code           ");
		sql.append(" AND LANGUAGE = :language                  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;		
	}

	@Override
	public String getBAS0203U00LayBunCode(String hospCode, String language, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_BAS0230(:f_hosp_code , :language, :f_code) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("language", language);
		List<String> result= query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
}

