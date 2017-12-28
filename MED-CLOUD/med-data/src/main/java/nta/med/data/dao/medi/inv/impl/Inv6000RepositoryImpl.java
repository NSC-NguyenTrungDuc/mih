package nta.med.data.dao.medi.inv.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.lang.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv6000RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.invs.INV6000U00GrdINV6001Info;
import nta.med.data.model.ihis.invs.INV6000U00LayINV6000Info;
import nta.med.data.model.ihis.invs.INV6000U00LaySummaryDetailInfo;

public class Inv6000RepositoryImpl implements Inv6000RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<INV6000U00GrdINV6001Info> getINV6000U00GrdINV6001Info(String hospCode, String language, Double fkinv6000, String jaeryoCode, String startNum, String endNum, String difference) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JAERYO_CODE                                                                                                           ");
		sql.append(" , B.JAERYO_NAME                                                                                                                ");
		sql.append(" , A.PRE_M_JAEGO_QTY                                                                                                            ");
		sql.append(" , A.IPGO_QTY                                                                                                                   ");
		sql.append(" , A.CHULGO_QTY                                                                                                                 ");
		sql.append(" , A.JAEGO_QTY                                                                                                                  ");
		sql.append(" , D.EXIST_COUNT AS EXIST_CNT                                                                                                   ");
		sql.append(" , D.EXIST_COUNT - A.JAEGO_QTY AS DELTA_QTY                                                               						");
		sql.append(" , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.SUBUL_DANUI, :hosp_code, :language) AS SUBUL_DANUI_NAME                                  ");
		sql.append(" , FORMAT(B.SUBUL_DANGA,'0') AS DANGA                                                                                           ");
		sql.append(" , FORMAT(A.ADJ_AMT,'0') AS ADJ_AMT                                                                                             ");
		sql.append(" FROM(SELECT X.HOSP_CODE                                                                                                        ");
		sql.append(" , X.PKINV6000                                                                                                                  ");
		sql.append(" , X.MAGAM_MONTH                                                                                                                ");
		sql.append(" , Y.JAERYO_CODE                                                                                                                ");
		sql.append(" , Y.PRE_M_JAEGO_QTY                                                                                                            ");
		sql.append(" , Y.IPGO_QTY                                                                                                                   ");
		sql.append(" , Y.CHULGO_QTY                                                                                                                 ");
		sql.append(" , Y.JAEGO_QTY                                                                                                                  ");
		sql.append(" , FORMAT(Y.ADJ_AMT,'0') AS ADJ_AMT                                                                                             ");
		sql.append("    FROM INV6000 X, INV6001 Y                                                                                                   ");
		sql.append("    WHERE X.HOSP_CODE = :hosp_code                                                                                              ");
		sql.append("    AND X.PKINV6000 = :f_fkinv6000                                                                                              ");
		sql.append("    AND Y.HOSP_CODE = X.HOSP_CODE                                                                                               ");
		sql.append("    AND Y.FKINV6000 = X.PKINV6000) A LEFT OUTER JOIN INV6002 D ON D.HOSP_CODE = A.HOSP_CODE                                     ");
		sql.append(" AND D.JAERYO_CODE = A.JAERYO_CODE AND D.MAGAM_MONTH = A.MAGAM_MONTH,                                                           ");
		sql.append(" INV6000 C, INV0110 B                                                                                                           ");
		sql.append(" WHERE B.HOSP_CODE = A.HOSP_CODE AND B.JAERYO_CODE = A.JAERYO_CODE AND C.HOSP_CODE = A.HOSP_CODE AND C.PKINV6000 = A.PKINV6000  ");
		if(!StringUtils.isEmpty(jaeryoCode)){
			sql.append(" AND A.JAERYO_CODE LIKE :f_jaeryo_code                                                                                      ");
		}
		if(!"%".equalsIgnoreCase(difference)){
			int result = Integer.parseInt(difference);
			if(result < 0)
				sql.append(" AND D.EXIST_COUNT - A.JAEGO_QTY < 0                                                              ");
			else if (result == 0)
				sql.append(" AND D.EXIST_COUNT - A.JAEGO_QTY = 0                                                              ");
			else 
				sql.append(" AND D.EXIST_COUNT - A.JAEGO_QTY > 0                                                              ");
		}
		sql.append(" ORDER BY A.JAERYO_CODE																											");
		if (!StringUtils.isEmpty(startNum)) {
			sql.append(" LIMIT :startNum, :endNum 	 																							    ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(jaeryoCode)){
			query.setParameter("f_jaeryo_code", "%" + jaeryoCode + "%");                                                                                            
		}
		query.setParameter("f_fkinv6000", fkinv6000);
		if (!StringUtils.isEmpty(startNum)) {
			query.setParameter("startNum", CommonUtils.getStartNumberPaging(startNum, endNum));
			query.setParameter("endNum", Integer.parseInt(endNum));
		}
		
		List<INV6000U00GrdINV6001Info> list = new JpaResultMapper().list(query, INV6000U00GrdINV6001Info.class);
		return list;
	}

	@Override
	public List<INV6000U00LaySummaryDetailInfo> getINV6000U00LaySummaryDetailInfo(String hospCode, String language, String magamMonth) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.SLIP_CODE                                                                                 ");
		sql.append(" , A.JAERYO_CODE                                                                                    ");
		sql.append(" , A.JAERYO_NAME                                                                                    ");
		sql.append(" , FORMAT(IFNULL(A.SUBUL_DANGA,0),'0') AS SUBUL_DANGA                                               ");
		sql.append(" , C.CODE_NAME DANUI                                                                                ");
		sql.append(" , FORMAT(IFNULL(D.JAEGO_QTY,0),'0') AS JAEGO_QTY                                                   ");
		sql.append(" , FORMAT(ROUND(IFNULL(A.SUBUL_DANGA,0)*IFNULL(D.JAEGO_QTY,0)),'0') SOUGAKU                         ");
		sql.append(" FROM INV0110 A LEFT OUTER JOIN OCS0132 C ON C.HOSP_CODE   = A.HOSP_CODE AND C.CODE = A.SUBUL_DANUI ");
		sql.append("   AND C.CODE_TYPE  = 'ORD_DANUI' AND C.LANGUAGE = :language,                                       ");
		sql.append(" OCS0103 B, (SELECT X.HOSP_CODE                                                                     ");
		sql.append(" , Y.JAERYO_CODE                                                                                    ");
		sql.append(" , Y.JAEGO_QTY                                                                                      ");
		sql.append("    FROM INV6000 X, INV6001 Y                                                                       ");
		sql.append("    WHERE X.HOSP_CODE = :hosp_code                                                                  ");
		sql.append("    AND X.MAGAM_MONTH = :magam_month                                                                ");
		sql.append("    AND Y.HOSP_CODE = X.HOSP_CODE                                                                   ");
		sql.append("    AND Y.FKINV6000 = X.PKINV6000) D                                                                ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code                                                                     ");
		sql.append("  AND IFNULL(A.STOCK_YN,'N')    = 'Y'                                                               ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE AND B.HANGMOG_CODE  = A.JAERYO_CODE                                  ");
		sql.append(" AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                  ");
		sql.append(" AND D.HOSP_CODE  = A.HOSP_CODE AND D.JAERYO_CODE  = A.JAERYO_CODE                                  ");
		sql.append(" ORDER BY A.JAERYO_NAME																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("magam_month", magamMonth);
		
		List<INV6000U00LaySummaryDetailInfo> list = new JpaResultMapper().list(query, INV6000U00LaySummaryDetailInfo.class);
		return list;
	}

	@Override
	public List<INV6000U00LayINV6000Info> getINV6000U00LayINV6000Info(String hospCode, String month) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINV6000  AS PKINV6001                                                                                           ");
		sql.append("      , CONCAT(IFNULL(SUBSTR(A.MAGAM_MONTH, 1,4),'') , '年' , IFNULL(SUBSTR(A.MAGAM_MONTH, 5,2),'') , '月') AS MAGAM_MONTH  ");
		sql.append("      , DATE_FORMAT(A.INPUT_DATE, '%Y/%m/%d') AS INPUT_DATE                                                                 ");
		sql.append("      , FN_ADM_LOAD_USER_NAME(A.INPUT_USER, :hosp_code) AS USER_NAME                                                        ");
		sql.append("      , A.REMARK AS REMARK                                                                                                  ");
		sql.append("      , A.INPUT_TIME AS PROCESS_TIME                                                                    					");
		sql.append("   FROM INV6000 A                                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE   = :hosp_code                                                                                          ");
		sql.append("    AND A.MAGAM_MONTH = :month																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("month", month);
		
		List<INV6000U00LayINV6000Info> list = new JpaResultMapper().list(query, INV6000U00LayINV6000Info.class);
		return list;
	}

	@Override
	public ComboListItemInfo callPrInvMakeStockCounts(String hospCode, String proc, String month, String userId,
			String inputUser, Date inputDate, String remark) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_INV_MAKE_STOCK_COUNTS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MONTH", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_USER", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_DATE", Date.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_REMARK", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class,ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_MSG", String.class,ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PROC", proc);
		query.setParameter("I_MONTH", month);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_INPUT_USER", inputUser);
		query.setParameter("I_INPUT_DATE", inputDate);
		query.setParameter("I_REMARK", remark);
		
		Boolean isValid = query.execute();
		ComboListItemInfo result = new ComboListItemInfo((String)query.getOutputParameterValue("O_FLAG"), (String)query.getOutputParameterValue("O_MSG"));
		return result;
	}
}
