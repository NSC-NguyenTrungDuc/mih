package nta.med.data.dao.medi.inv.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv4001RepositoryCustom;

import nta.med.data.model.ihis.invs.INV4001U00ExportCSVInfo;

import nta.med.data.model.ihis.invs.INV4001U00ExportInfo;
import nta.med.data.model.ihis.invs.INV4001U00Grd4001Info;

public class Inv4001RepositoryImpl implements Inv4001RepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<INV4001U00Grd4001Info> getINV4001U00Grd4001Info(String hospCode, Date fromDate, Date toDate, String ipgoType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINV4001                                         ");
		sql.append("      , A.CHURI_DATE                                        ");
		sql.append("      , A.CHURI_TIME                                        ");
		sql.append("      , A.CHURI_BUSEO                                       ");
		sql.append("      , A.IPGO_TYPE                                         ");
		sql.append("      , A.IMPORT_CODE                                       ");
		sql.append("      , A.CHURI_SEQ                                         ");
		sql.append("      , A.JAERYO_GUBUN                                      ");
		sql.append("      , A.REMARK  , '' in_out_gubun, '' ipchul_type         ");
		sql.append("   FROM INV4001 A                                           ");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                         ");
		if(!StringUtils.isEmpty(ipgoType)){
			sql.append("	 AND A.IPGO_TYPE = :f_ipgo_type                    	");
		}
		sql.append("    AND A.CHURI_DATE BETWEEN :f_from_date AND :f_to_date    ");
		sql.append("  ORDER BY A.CHURI_DATE DESC                                ");
		sql.append("      , A.CHURI_BUSEO, A.IPGO_TYPE , A.CHURI_SEQ			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		if(!StringUtils.isEmpty(ipgoType)){
			query.setParameter("f_ipgo_type", ipgoType);
		}
		
		List<INV4001U00Grd4001Info> list = new JpaResultMapper().list(query, INV4001U00Grd4001Info.class);
		return list;
	}

	@Override
	public List<INV4001U00ExportCSVInfo> getINV4001U00ExportCSVInfo(String hospCode, Date fromDate, Date toDate,
			String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT  CAST(@rownum\\:= @rownum + 1 AS CHAR) AS ROW_NUM                                              ");
		sql.append("        , A.CHURI_DATE                                                            						");
		sql.append("        , A.CHURI_TIME                                                            						");
		sql.append("		, B.JAERYO_CODE                                                           					   	");
		sql.append("		, C.JAERYO_NAME                                                          					  	");
		sql.append("		, B.START_DATE                                                            					  	");
		sql.append("		, B.LOT                                                            					  			");
		sql.append("		, B.EXPIRED_DATE                                                            					");
		sql.append("		, B.IPGO_QTY                                                            						");
		sql.append("		, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', C.SUBUL_DANUI, :f_hosp_code, :f_language) IPGO_DANUI_NAME 	");
		sql.append("        , D.CODE_NAME                                                           						");
		sql.append("        , A.UPD_ID                                                                					   	");
		sql.append("		, B.IPGO_DANGA                                                            						");
		sql.append("		, (B.IPGO_QTY * B.IPGO_DANGA) AS QTY_IPGO_DANGA                                        			");
		sql.append("		, A.IMPORT_CODE                                                                             	");
		sql.append("		, A.REMARK                                                                             			");
		sql.append("  FROM INV4001 A, INV4002 B, INV0110 C, INV0102 D, (SELECT @rownum\\:= 0) r								");
		sql.append("  WHERE A.HOSP_CODE  = B.HOSP_CODE                                              						");
		sql.append("        AND B.HOSP_CODE =  :f_hosp_code                     											");
		sql.append("        AND A.PKINV4001 =  B.FKINV4001                     												");
		sql.append("        AND B.JAERYO_CODE = C.JAERYO_CODE                      											");
		sql.append("        AND B.HOSP_CODE =  C.HOSP_CODE                     											    ");
		sql.append("		AND D.HOSP_CODE = A.HOSP_CODE																	");
		sql.append("		AND A.IPGO_TYPE = D.CODE																		");
		sql.append("		AND D.CODE_TYPE = 'IPGO_TYPE'																	");
		sql.append("		AND D.LANGUAGE = :f_language																	");
		sql.append("        AND A.CHURI_DATE BETWEEN :f_from_date AND :f_to_date                      						");
		sql.append("  ORDER BY                                                                        					    ");
		sql.append("           A.CHURI_DATE DESC , A.IPGO_TYPE , A.CHURI_BUSEO , A.CHURI_SEQ                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_language", language);
		
		List<INV4001U00ExportCSVInfo> listData = new JpaResultMapper().list(query, INV4001U00ExportCSVInfo.class);
		return listData;
	}

	@Override
	public List<INV4001U00ExportInfo> getINV4001U00ExportInfo(String hospCode, String language, Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 	A.CHURI_DATE,																				");	
		sql.append(" 		A.IPGO_TYPE		,																				");
		sql.append(" 		A.UPD_ID	,																					");	
		sql.append(" 		B.JAERYO_CODE	,																				");	
		sql.append(" 		C.JAERYO_NAME	,																				");	
		sql.append(" 		B.START_DATE	,																				");	
		sql.append(" 		B.LOT			,																				");	
		sql.append(" 		B.EXPIRED_DATE	,																				");
		sql.append(" 		B.IPGO_QTY		,																				");
		sql.append(" 		FN_OCS_LOAD_CODE_NAME ('ORD_DANUI', C.SUBUL_DANUI, :hosp_code, :language) IPGO_DANUI_NAME ,		");
		sql.append(" 		B.IPGO_DANGA																					");	
		sql.append(" 	FROM INV4001	A,																					");	
		sql.append(" 		INV4002	B,																						");	
		sql.append(" 		INV0110		C																					");	
		sql.append(" 	WHERE																								");	
		sql.append(" 		A.HOSP_CODE =	B.HOSP_CODE																		");	
		sql.append(" 		AND B.HOSP_CODE =	:hosp_code																	");	
		sql.append(" 		AND A.PKINV4001		=	B.FKINV4001																");	
		sql.append(" 		AND B.JAERYO_CODE	=	C.JAERYO_CODE															");	
		sql.append(" 		AND A.CHURI_DATE	BETWEEN			:f_from_date	 AND :f_to_date								");	

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<INV4001U00ExportInfo> list = new JpaResultMapper().list(query, INV4001U00ExportInfo.class);
		return list;
	}
	
}
