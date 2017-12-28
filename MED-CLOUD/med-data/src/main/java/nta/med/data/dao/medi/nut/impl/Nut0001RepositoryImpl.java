package nta.med.data.dao.medi.nut.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nut.Nut0001RepositoryCustom;
import nta.med.data.model.ihis.inps.INP1001U01EtcIpwongrdHistoryInfo;
import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0001ItemInfo;
import nta.med.data.model.ihis.ocsa.OCS3003Q11grdOrderDateListInfo;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Nut0001RepositoryImpl implements Nut0001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public Double getOCS0103U19GetFkOcsInfo(String hospCode, Double fkOcs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.FK_OCS					");
		sql.append("	 FROM NUT0001 A                 ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode   ");
		sql.append("	  AND A.FK_OCS    = :fkOcs      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("fkOcs", fkOcs);
		
		List<Double> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<Nut0001U00GrdNut0001ItemInfo> getNut0001U00GrdNut0001ItemInfo(
			String hospCode, Double pkocskey) {
		StringBuilder sql = new StringBuilder();
		 	
		sql.append("	SELECT  SYS_DATE,								");
		sql.append("	        USER_ID,                                ");
		sql.append("	        UPD_DATE,                               ");
		sql.append("	        HOSP_CODE,                              ");
		sql.append("	        PKNUT0001,                              ");
		sql.append("	        DATA_KUBUN,                             ");
		sql.append("	        FK_OCS,                                 ");
		sql.append("	        IO_KUBUN,                               ");
		sql.append("	        HANGMOG_CODE,                           ");
		sql.append("	        HANGMOG_NAME,                           ");
		sql.append("	        IRAI_DATE,                              ");
		sql.append("	        KANJA_NO,                               ");
		sql.append("	        SINRYOUKA,                              ");
		sql.append("	        SINDANISI,                              ");
		sql.append("	        BMI,                                    ");
		sql.append("	        SIJIJIKOU,                              ");
		sql.append("	        TARGETWEIGHT,                           ");
		sql.append("	        SPORT_YN,                               ");
		sql.append("	        DRINK_YN,                               ");
		sql.append("	        ENERGY,                                 ");
		sql.append("	        PROTEIN,                                ");
		sql.append("	        FAT,                                    ");
		sql.append("	        PS,                                     ");
		sql.append("	        SUGAR,                                  ");
		sql.append("	        SALT,                                   ");
		sql.append("	        WATER,                                  ");
		sql.append("	        BP,                                     ");
		sql.append("	        FBS,                                    ");
		sql.append("	        A1C,                                    ");
		sql.append("	        TCH,                                    ");
		sql.append("	        TG,                                     ");
		sql.append("	        HDL,                                    ");
		sql.append("	        LDL,                                    ");
		sql.append("	        HB,                                     ");
		sql.append("	        ALB,                                    ");
		sql.append("	        BUN,                                    ");
		sql.append("	        CRE,                                    ");
		sql.append("	        AST_GOT,                                ");
		sql.append("	        ALT_GPT,                                ");
		sql.append("	        GAMMAGT,                                ");
		sql.append("	        NUTRITIONIST,                           ");
		sql.append("	        NUTRITIONIST_NAME,                      ");
		sql.append("	        NUTRITION_OBJECT,                       ");
		sql.append("	        ACTING_DATE,                            ");
		sql.append("	        REMARK,                                 ");
		sql.append("	        WEIGHT,                                 ");
		sql.append("	        HEIGHT,                                 ");
		sql.append("	        SYOKAI_GUBUN,                           ");
		sql.append("	        RESER_DATE                              ");
		sql.append("	   FROM NUT0001 A                               ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code              ");
		sql.append("	    AND A.FK_OCS    = :f_pkocskey               ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocskey", pkocskey);
		
		List<Nut0001U00GrdNut0001ItemInfo> list = new JpaResultMapper().list(query, Nut0001U00GrdNut0001ItemInfo.class);
		return list;
	}

	@Override
	public List<OCS3003Q11grdOrderDateListInfo> getOCS3003Q11grdOrderDateListInfo(String hospCode, String bunho,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.IRAI_DATE IRAI_DATE										");
		sql.append("	     , A.KANJA_NO													");
		sql.append("	     , B.SUNAME														");
		sql.append("	     , A.HANGMOG_CODE		                                        ");
		sql.append("	     , A.HANGMOG_NAME		                                        ");
		sql.append("	     , A.SINRYOUKA			                                        ");
		sql.append("	     , D.USER_NM			                                        ");
		sql.append("	     , A.NUTRITIONIST_NAME	                                        ");
		sql.append("	     , A.SIJIJIKOU			                                        ");
		sql.append("	     , A.NUTRITION_OBJECT	                                        ");
		sql.append("	     , A.REMARK				                                        ");
		sql.append("	     , 'O' IO_GUBUN			                                        ");
		sql.append("	     , C.OCS_FLAG			                                        ");
		sql.append("	     , C.RESULT_DATE		                                        ");
		sql.append("	     , IF(C.SUNAB_DATE IS NULL, 'N', 'Y') SUNAB_CHECK				");
		sql.append("	     , C.NALSU		                                                ");
		sql.append("	     , C.DC_YN		                                                ");
		sql.append("	     , C.PKOCS1003	                                                ");
		sql.append("	  FROM NUT0001 A	                                                ");
		sql.append("	     , OUT0101 B	                                                ");
		sql.append("	     , OCS1003 C	                                                ");
		sql.append("	     , ADM3200 D	                                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code									");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE									");
		sql.append("	   AND B.BUNHO     = A.KANJA_NO										");
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE									");
		sql.append("	   AND C.PKOCS1003 = A.FK_OCS										");
		sql.append("	   AND IFNULL(C.DC_YN, 'N') = 'N'									");
		sql.append("	   AND C.NALSU > 0													");
		sql.append("	   AND D.HOSP_CODE = A.HOSP_CODE									");
		sql.append("	   AND D.USER_ID   = SUBSTR(A.SINDANISI, LENGTH(A.SINDANISI) - 4)	");
		sql.append("	   AND A.KANJA_NO    = :f_bunho		                                ");
		sql.append("	   AND A.DATA_KUBUN <> 'D'			                                ");
		sql.append("	 UNION ALL							                                ");
		sql.append("	SELECT A.IRAI_DATE IRAI_DATE		                                ");
		sql.append("	     , A.KANJA_NO					                                ");
		sql.append("	     , B.SUNAME						                                ");
		sql.append("	     , A.HANGMOG_CODE				                                ");
		sql.append("	     , A.HANGMOG_NAME				                                ");
		sql.append("	     , A.SINRYOUKA					                                ");
		sql.append("	     , D.USER_NM					                                ");
		sql.append("	     , A.NUTRITIONIST_NAME			                                ");
		sql.append("	     , A.SIJIJIKOU					                                ");
		sql.append("	     , A.NUTRITION_OBJECT			                                ");
		sql.append("	     , A.REMARK						                                ");
		sql.append("	     , 'I' IO_GUBUN					                                ");
		sql.append("	     , C.OCS_FLAG					                                ");
		sql.append("	     , C.RESULT_DATE				                                ");
		sql.append("	     , IF(C.SUNAB_DATE IS NULL, 'N', 'Y') SUNAB_CHECK				");
		sql.append("	     , C.NALSU			                                            ");
		sql.append("	     , C.DC_YN			                                            ");
		sql.append("	     , C.PKOCS2003    	                                            ");
		sql.append("	  FROM NUT0001 A		                                            ");
		sql.append("	     , OUT0101 B		                                            ");
		sql.append("	     , OCS2003 C		                                            ");
		sql.append("	     , ADM3200 D		                                            ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code	                                ");
		sql.append("	   AND A.KANJA_NO    = :f_bunho		                                ");
		sql.append("	   AND A.DATA_KUBUN <> 'D'			                                ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE	                                ");
		sql.append("	   AND B.BUNHO     = A.KANJA_NO		                                ");
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE	                                ");
		sql.append("	   AND C.PKOCS2003 = A.FK_OCS		                                ");
		sql.append("	   AND IFNULL(C.DC_YN, 'N') = 'N'	                                ");
		sql.append("	   AND C.NALSU > 0					                                ");
		sql.append("	   AND D.HOSP_CODE = A.HOSP_CODE	                                ");
		sql.append("	   AND D.USER_ID   = SUBSTR(A.SINDANISI, LENGTH(A.SINDANISI) - 4)	");
		sql.append("	 ORDER BY 1 DESC");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS3003Q11grdOrderDateListInfo> lstResult = new JpaResultMapper().list(query, OCS3003Q11grdOrderDateListInfo.class);
		return lstResult;
	}
	
	
}

