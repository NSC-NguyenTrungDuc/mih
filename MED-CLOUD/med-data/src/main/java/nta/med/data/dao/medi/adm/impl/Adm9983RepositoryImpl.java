package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm9983RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM2016U00GrdLoadDrgInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00FwkCommonInfo;

/**
 * @author dainguyen.
 */
public class Adm9983RepositoryImpl implements Adm9983RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Adm9983RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0103U00FwkCommonInfo> getOCS0103U00OCS0103U00FwkCommonInfo(String a9, String a7) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.A8  YJ_CODE                  ");
		sql.append("        , A.A1  HOT_CODE                ");
		sql.append("        , A.A7  YAK_KIJUN_CODE          ");
		sql.append("        , A.A9  SG_CODE                 ");
		sql.append("        , A.A12 SALE_NAME               ");
		sql.append("        , A.A21 CREATED_COMPANY_NAME    ");
		sql.append("        , A.A22 SALED_COMPANY_NAME      ");
		sql.append("        , A.A16                         ");
		sql.append("        , A.A18                         ");
		sql.append("     FROM ADM9983 A                     ");
		sql.append("    WHERE A.A9 = :f_a9                  ");
		sql.append("      AND A.A7 = :f_a7                  ");
		sql.append("    ORDER BY A.A8, A.A1					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_a9", a9);
		query.setParameter("f_a7", a7);
		List<OCS0103U00FwkCommonInfo> list = new JpaResultMapper().list(query, OCS0103U00FwkCommonInfo.class);
		return list;
	}

	@Override
	public List<ADM2016U00GrdLoadDrgInfo> getADM2016U00GrdLoadDrgInfo(String hospCode, String a13, String a20,
			String a9, Integer startNum, Integer offset) {

		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.A1  HOT_CODE                 				 ");
		sql.append("        , A.A2  HOSP_ACODE               				 ");
		sql.append("        , A.A3                  						 ");
		sql.append("        , A.A4                  					     ");
		sql.append("        , A.A5                  						 ");
		sql.append("        , A.A6                 							 ");
		sql.append("        , A.A7                 							 ");
		sql.append("        , A.A8                  						 ");
		sql.append("        , A.A9                  					     ");
		sql.append("        , A.A10                  						 ");
		sql.append("        , A.A11                 						 ");
		sql.append("        , A.A12                  						 ");
		sql.append("        , A.A13                  						 ");
		sql.append("        , A.A14                  						 ");
		sql.append("        , A.A15            								 ");
		sql.append("        , A.A16                   					     ");
		sql.append("        , A.A17                							 ");
		sql.append("        , A.A18     									 ");
		sql.append("        , A.A19       									 ");
		sql.append("        , A.A20                         				 ");
		sql.append("        , A.A21                         				 ");
		sql.append("        , A.A22                         				 ");
		sql.append("        , A.A23                         				 ");
		sql.append("        , A.A24                         				 ");
		sql.append("        , B.USE_YN USE_YN                         		 ");
		sql.append("     FROM ADM9983 A LEFT JOIN ADM9000 B                  ");
		sql.append("  ON  A.A1  = B.HOTCODE                                  ");
		sql.append("  AND B.HOSP_CODE = :hospital_code  WHERE 1=1            ");
		if (!StringUtils.isEmpty(a13)) {
			sql.append("    AND A.A13  like :f_a13                    		 ");
		}
		if (!StringUtils.isEmpty(a20)) {
			sql.append("    AND A.A20  like :f_a20                    		 ");
		}
		if (a9.equals(YesNo.NO.getValue())) {
			sql.append("    AND (A.A9 IS NULL OR A.A9 ='')                   ");
			//BA confirm  ADM9983.A9 No -> NULL 
			//sql.append("    AND (B.USE_YN = :f_use_yn OR B.USE_YN IS NULL OR B.USE_YN = '')      ");
		}
		if (a9.equals(YesNo.YES.getValue())) {
			sql.append("    AND A.A9 IS NOT NULL  and A.A9 <> ''             ");
			//BA confirm  ADM9983.A9 Yes -> NOT NULL
			//sql.append("    AND B.USE_YN = :f_use_yn 						 ");
		}
		sql.append(" ORDER BY A.ID ASC 							    		 ");
		sql.append(" limit :startNum, :offset 							     ");
		// sql.append(" LIMIT 10 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospital_code", hospCode);
		if (!StringUtils.isEmpty(a13)) {
			query.setParameter("f_a13", "%" + a13 + "%");
		}
		if (!StringUtils.isEmpty(a20)) {
			query.setParameter("f_a20", "%" + a20 + "%");
		}
		
		/*if (a9.equals(YesNo.NO.getValue()) || a9.equals(YesNo.YES.getValue()))
		{
			query.setParameter("f_use_yn", a9);
		}*/

		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);

		List<ADM2016U00GrdLoadDrgInfo> list = new JpaResultMapper().list(query, ADM2016U00GrdLoadDrgInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getCombo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT   \"\" A1,\"\" A2		UNION				");		
		sql.append("	(SELECT DISTINCT N.A20  A1,N.A20  A2				");
		sql.append("	FROM  ADM9983 N   ORDER BY   ID )                   ");
	
		Query query = entityManager.createNativeQuery(sql.toString());
	    
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;                
	}

}
