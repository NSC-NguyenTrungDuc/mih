package nta.med.data.dao.medi.xrt.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.XRT0201U00GrdRadioListItemInfo;
import nta.med.data.dao.medi.xrt.Xrt0202RepositoryCustom;
import nta.med.data.model.ihis.xrts.XRT7001Q01LayRadioHistoryListItemInfo;

/**
 * @author dainguyen.
 */
public class Xrt0202RepositoryImpl implements Xrt0202RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<XRT7001Q01LayRadioHistoryListItemInfo> getXRT7001Q01LayRadioHistoryListItemInfo(String hospCode, String language, String bunho, String partCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                                " );
		sql.append("     , FN_OUT_LOAD_SUNAME(A.BUNHO,:f_hosp_code) SUNAME                                                                                         " );
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language) GWA                                                                  " );
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code) DOCTOR                                                                     " );
		sql.append("     , A.ORDER_DATE                                                                                                                            " );
		sql.append("     , (SELECT X.CODE_NAME                                                                                                                     " );
		sql.append("          FROM OCS0132 X                                                                                                                       " );
		sql.append("         WHERE X.HOSP_CODE = A.HOSP_CODE                                                                                                       " );
		sql.append("           AND X.CODE_TYPE = 'OCS_ACT_PART_01'                                                                                                 " );
		sql.append("           AND X.CODE      = A.JUNDAL_PART AND X.LANGUAGE = :f_language)    JUNDAL_PART                                                        " );
		sql.append("     , A.XRAY_CODE                                                                                                                             " );
		sql.append("     , (SELECT C.XRAY_NAME                                                                                                                     " );
		sql.append("          FROM XRT0001 C                                                                                                                       " );
		sql.append("         WHERE C.HOSP_CODE = A.HOSP_CODE                                                                                                       " );
		sql.append("           AND C.XRAY_CODE = A.XRAY_CODE) XRAY_NAME                                                                                            " );
		sql.append("     , B.XRAY_CODE_IDX                                                                                                                         " );
		sql.append("     , B.XRAY_CODE_IDX_NM                                                                                                                      " );
		sql.append("     , B.TUBE_VOL                                                                                                                              " );
		sql.append("     , B.TUBE_CUR                                                                                                                              " );
		sql.append("     , B.XRAY_TIME                                                                                                                             " );
		sql.append("     , B.TUBE_CUR_TIME                                                                                                                         " );
		sql.append("     , B.IRRADIATION_TIME                                                                                                                      " );
		sql.append("     , B.XRAY_DISTANCE                                                                                                                         " );
		sql.append("  FROM XRT0202 B                                                                                                                               " );
		sql.append("     , XRT0201 A                                                                                                                               " );
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                            " );
		sql.append("   AND A.BUNHO       = :f_bunho                                                                                                                " );
		sql.append("   AND A.JUNDAL_PART LIKE :f_part_code                                                                                                         " );
		sql.append("   AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                             " );
		sql.append("   AND B.FKXRT0201   = A.PKXRT0201                                                                                                             " );
		sql.append("   AND case A.IN_OUT_GUBUN when 'O' then  (SELECT 'X' FROM OCS1003 AA WHERE AA.HOSP_CODE = A.HOSP_CODE AND AA.PKOCS1003 = A.FKOCS1003)         " );
		sql.append("       when 'I' then (SELECT 'X' FROM OCS2003 AA WHERE AA.HOSP_CODE = A.HOSP_CODE AND AA.PKOCS2003 = A.FKOCS2003) end IS NOT NULL              " );
		sql.append(" ORDER BY A.ORDER_DATE, A.XRAY_GUBUN, A.XRAY_CODE, B.XRAY_CODE_IDX																				");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_part_code", partCode);
		List<XRT7001Q01LayRadioHistoryListItemInfo> listLayRadio= new JpaResultMapper().list(query, XRT7001Q01LayRadioHistoryListItemInfo.class);
		return listLayRadio;
	}
	@Override
	public List<XRT0201U00GrdRadioListItemInfo> getXRT0201U00GrdRadioListItemInfo(
			String hospCode, Date orderDate, String bunho, String inOutGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                 ");
		sql.append("      , A.ORDER_DATE                                            ");
		sql.append("      , B.FKXRT0201                                             ");
		sql.append("      , A.XRAY_CODE                                             ");
		sql.append("      , (SELECT C.XRAY_NAME                                     ");
		sql.append("           FROM XRT0001 C                                       ");
		sql.append("          WHERE C.HOSP_CODE = :f_hosp_code                      ");
		sql.append("            AND C.XRAY_CODE = A.XRAY_CODE) XRAY_NAME            ");
		sql.append("      , A.XRAY_GUBUN                                            ");
		sql.append("      , B.XRAY_CODE_IDX                                         ");
		sql.append("      , B.XRAY_CODE_IDX_NM                                      ");
		sql.append("      , B.TUBE_VOL                                              ");
		sql.append("      , B.TUBE_CUR                                              ");
		sql.append("      , B.XRAY_TIME                                             ");
		sql.append("      , B.TUBE_CUR_TIME                                         ");
		sql.append("      , B.IRRADIATION_TIME                                      ");
		sql.append("      , B.XRAY_DISTANCE                                         ");
		sql.append("   FROM XRT0202 B, XRT0201 A                                    ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                              ");
		sql.append("    AND A.ORDER_DATE = :f_order_date                            ");
		sql.append("    AND A.BUNHO = :f_bunho                                      ");
		sql.append("    AND A.IN_OUT_GUBUN = :f_in_out_gubun                        ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                               ");
		sql.append("    AND B.FKXRT0201 = A.PKXRT0201                               ");
		sql.append("  ORDER BY A.XRAY_GUBUN, A.XRAY_CODE, B.XRAY_CODE_IDX			");
		 
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_in_out_gubun", inOutGubun);
		List<XRT0201U00GrdRadioListItemInfo> list= new JpaResultMapper().list(query, XRT0201U00GrdRadioListItemInfo.class);
		return list;
	}
	@Override
	public void callPRXrtManagementXrt0202(String hospCode, String dataGubun,Double fkOcs, String userId, String inOutGubun) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_XRT_MANAGEMENT_XRT0202 ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_DATA_GUBUN", dataGubun);
		query.setParameter("I_FKOCS", fkOcs);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		
		Boolean isValid = query.execute();
		
	}
}

