package nta.med.data.dao.medi.clis.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.clis.ClisSmoRepositoryCustom;
import nta.med.data.model.ihis.clis.Clis2015U09ItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public class ClisSmoRepositoryImpl implements ClisSmoRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<Clis2015U09ItemInfo> getClis2015U09ItemInfo(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.CLIS_SMO_ID                      ");
		sql.append("	, A.SMO_CODE                               ");                         
		sql.append("	, A.START_DATE                             ");                           
		sql.append("	, A.END_DATE                               ");                         
		sql.append("	, A.SMO_NAME                               ");                         
		sql.append("	, A.SMO_NAME1                              ");                          
		sql.append("	, A.ZIP_CODE1                              ");                                                                                  
		sql.append("	, A.ZIP_CODE2                              ");                                                                                                                                  
		sql.append("	, A.ADDRESS                                ");                        
		sql.append("	, A.ADDRESS1                               ");                         
		sql.append("	, A.TEL                                    ");                    
		sql.append("	, A.TEL1                                   ");                     
		sql.append("	, A.FAX                                    ");                    
		sql.append("	, A.DODOBUHYEUN_NO                         ");                                                                               
		sql.append("	, B.CODE_NAME                              ");                          
		sql.append("	, A.HOMEPAGE                               ");                         
		sql.append("	, A.EMAIL                                  ");
		sql.append("	FROM CLIS_SMO A,BAS0102  B                 ");             
		sql.append("	WHERE A.HOSP_CODE = :hospCode              ");
		sql.append("	AND A.ACTIVE_FLG = 1                       ");
		sql.append("	AND B.CODE = A.DODOBUHYEUN_NO              ");
		sql.append("	AND B.CODE_TYPE = :codeType                ");
		sql.append("	AND B.LANGUAGE = :language                 ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<Clis2015U09ItemInfo> list = new JpaResultMapper().list(query, Clis2015U09ItemInfo.class);
		return list;                                               
	}
	
	@Override
	public String getClis2015U09CheckSmoCodeInfo(String hospCode, String smoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CAST(COUNT(*) AS CHAR) FROM CLIS_SMO WHERE SMO_CODE = :smoCode AND HOSP_CODE = :hospCode ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("smoCode", smoCode);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getADM104UClisComboInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CAST(CLIS_SMO_ID AS CHAR), SMO_NAME	");
		sql.append("	FROM CLIS_SMO                               ");
		sql.append("	WHERE HOSP_CODE = :hospCode                 ");
		sql.append("	AND ACTIVE_FLG = 1                          ");
		sql.append("	ORDER BY SMO_CODE                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;                
	}
	

}
