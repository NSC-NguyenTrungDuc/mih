package nta.med.data.dao.medi.inv.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv2003RepositoryCustom;
import nta.med.data.model.ihis.invs.INV2003U00ExportCSVInfo;
import nta.med.data.model.ihis.invs.INV2003U00GrdINV2003Info;

public class Inv2003RepositoryImpl implements Inv2003RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<INV2003U00GrdINV2003Info> getGridINV2003Info(String hospCode, Date fromDate, Date toDate, String chulgoType) {
		
			StringBuilder sql = new StringBuilder();
			sql.append("  SELECT  A.PKINV2003                                                             ");
			sql.append("        , A.CHURI_DATE                                                            ");
			sql.append("        , A.CHURI_TIME                                                            ");
			sql.append("        , A.CHURI_BUSEO                                                           ");
			sql.append("		, A.CHULGO_TYPE                                                           ");
			sql.append("		, A.EXPORT_CODE                                                           ");
			sql.append("		, A.CHURI_SEQ                                                             ");
			sql.append("		, A.JAERYO_GUBUN                                                          ");
			sql.append("		, A.REMARK                                                                ");
			sql.append("  FROM INV2003 A                                                            	  ");
			sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                                               ");
			if(!StringUtils.isEmpty(chulgoType)){
				sql.append("	 AND A.CHULGO_TYPE = :f_chulgo_type                    	                  ");
			}
			sql.append("        AND A.CHURI_DATE BETWEEN :f_from_date AND :f_to_date                      ");
			sql.append("  ORDER BY                                                                        ");
			sql.append("           A.CHURI_DATE DESC , A.CHURI_BUSEO , A.CHULGO_TYPE , A.CHURI_SEQ        ");
			 
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_from_date", fromDate);
			query.setParameter("f_to_date", toDate);
			if(!StringUtils.isEmpty(chulgoType))
				query.setParameter("f_chulgo_type", chulgoType);
			
			List<INV2003U00GrdINV2003Info> listData = new JpaResultMapper().list(query, INV2003U00GrdINV2003Info.class);
			return listData;		
		}

	@Override
	public List<INV2003U00ExportCSVInfo> getINV2003U00ExportCSVInfo(String hospCode, Date fromDate, Date toDate, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT  CAST(@rownum\\:= @rownum + 1 AS CHAR) ROW_NUM                                                 ");
		sql.append("        , A.CHURI_DATE                                                            						");
		sql.append("		, IFNULL(A.CHURI_TIME, '')																		");
		sql.append("		, B.JAERYO_CODE                                                           					   	");
		sql.append("		, C.JAERYO_NAME                                                          					  	");
		sql.append("		, B.CHULGO_QTY                                                            					  	");
		sql.append("		, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', C.SUBUL_DANUI, :f_hosp_code, :f_language) IPGO_DANUI_NAME 	");
		sql.append("        , A.CHULGO_TYPE                                                           						");
		sql.append("        , A.UPD_ID                                                                					   	");
		sql.append("		, A.EXPORT_CODE																					");
		sql.append("		, IFNULL(A.REMARK, '')																			");
		sql.append("  FROM INV2003 A, INV2004 B, INV0110 C, (SELECT @rownum\\:= 0) r                                        ");
		sql.append("  WHERE A.HOSP_CODE  = B.HOSP_CODE                                              						");
		sql.append("        AND B.HOSP_CODE =  :f_hosp_code                													");
		sql.append("        AND B.HOSP_CODE =  C.HOSP_CODE                     												");
		sql.append("        AND A.PKINV2003 =  B.FKINV2003                     												");
		sql.append("        AND B.JAERYO_CODE = C.JAERYO_CODE                      											");
		sql.append("        AND B.HOSP_CODE =  C.HOSP_CODE                     											    ");
		sql.append("        AND A.CHURI_DATE BETWEEN :f_from_date AND :f_to_date                      						");	
		sql.append("  ORDER BY                                                                        						");
		sql.append("           A.CHURI_DATE DESC , A.CHURI_BUSEO , A.CHULGO_TYPE , A.CHURI_SEQ                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_language", language);
		
		List<INV2003U00ExportCSVInfo> listData = new JpaResultMapper().list(query, INV2003U00ExportCSVInfo.class);
		return listData;
	}
}
