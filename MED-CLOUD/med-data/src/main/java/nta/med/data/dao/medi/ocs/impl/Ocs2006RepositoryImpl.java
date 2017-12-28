package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2006RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupDAgrdOCS2006Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2006Info;

/**
 * @author dainguyen.
 */
public class Ocs2006RepositoryImpl implements Ocs2006RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public Double getNextSeqByHospCodePkOcs2005(String hospCode, Double fkocs2005) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(SEQ), 0) + 1	");
		sql.append("	FROM OCS2006					");
		sql.append("	WHERE FKOCS2005 = :f_fkocs2005	");
		sql.append("	  AND HOSP_CODE = :f_hosp_code	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2005", fkocs2005);

		List<Double> list = query.getResultList();
		return list.get(0);
	}

	@Override
	public List<OCS6010U10PopupTAgrdOCS2006Info> getOCS6010U10PopupTAgrdOCS2006Info(String hospCode, String orderDate,
			String fkocs2005, String pkSeq) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''       AS  CHK ,                                                               ");
		sql.append("	       A.FKOCS2005      ,                                                               ");
		sql.append("	       A.HANGMOG_CODE   ,                                                               ");
		sql.append("	       B.HANGMOG_NAME   ,                                                               ");
		sql.append("	       A.SURYANG        ,                                                               ");
		sql.append("	       A.ORD_DANUI      ,                                                               ");
		sql.append("	       A.DV             ,                                                               ");
		sql.append("	       A.DV_TIME        ,                                                               ");
		sql.append("	       A.NALSU          ,                                                               ");
		sql.append("	       A.BOGYONG_CODE   ,                                                               ");
		sql.append("	       A.JUSA_CODE      ,                                                               ");
		sql.append("	       A.JUSA_SPD_GUBUN ,                                                               ");
		sql.append("	       A.BUNHO          ,                                                               ");
		sql.append("	       A.FKINP1001      ,                                                               ");
		sql.append("	       A.ORDER_DATE     ,                                                               ");
		sql.append("	       A.INPUT_GUBUN    ,                                                               ");
		sql.append("	       A.PK_SEQ         ,                                                               ");
		sql.append("	       A.SEQ            ,                                                               ");
		sql.append("	       A.DIRECT_GUBUN   ,                                                               ");
		sql.append("	       A.DIRECT_CODE    ,                                                               ");
		sql.append("	       A.DIRECT_DETAIL  ,                                                               ");
		sql.append("	       A.BOM_YN         ,                                                               ");
		sql.append("	       A.BOM_SOURCE_KEY ,                                                               ");
		sql.append("	       IFNULL(B.JAERYO_YN, 'N') JAERYO_YN,												");
		sql.append("	       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, :f_order_date, :f_hosp_code) BULYONG_YN	");
		sql.append("	  FROM OCS2006 A        ,																");
		sql.append("	       OCS0103 B																		");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code													");
		sql.append("	   AND B.HOSP_CODE      = A.HOSP_CODE													");
		sql.append("	   AND B.HANGMOG_CODE   = A.HANGMOG_CODE												");
		sql.append("	   AND A.FKOCS2005      = :f_fkocs2005  												");
		sql.append("	   AND A.PK_SEQ         = :f_pk_seq														");
		sql.append("	 ORDER BY IFNULL(B.JAERYO_YN, 'N')														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_fkocs2005", CommonUtils.parseDouble(fkocs2005));
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		
		List<OCS6010U10PopupTAgrdOCS2006Info> list = new JpaResultMapper().list(query, OCS6010U10PopupTAgrdOCS2006Info.class);
		return list;
	}

	@Override
	public String getOCS6010U10frmARActingSuryang(String hospCode, String fkocs2005) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT				   							");
		sql.append("	  	A.SURYANG							   		");
		sql.append("	FROM				   							");
		sql.append("	  	OCS2006 A				   					");
		sql.append("	WHERE				   							");
		sql.append("	  	A.HOSP_CODE 		= :f_hosp_code			");
		sql.append("	  	AND A.FKOCS2005 	= :f_fkocs2005			");
		sql.append("	  	AND A.ORD_DANUI 	= '037'				   	");


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2005", fkocs2005);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS6010U10PopupDAgrdOCS2006Info> getOCS6010U10PopupDAgrdOCS2006(String hospCode, String fkocs2005, String orderDate, String pkSeq) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																							");
		sql.append("	    ''       AS  CHK,																			");
		sql.append("	    CAST(A.FKOCS2005 AS CHAR),																				");
		sql.append("	    A.HANGMOG_CODE,																				");
		sql.append("	    B.HANGMOG_NAME,																				");
		sql.append("	    CAST(A.SURYANG AS CHAR),																					");
		sql.append("	    IFNULL(A.ORD_DANUI, ''),																				");
		sql.append("	    IFNULL(A.DV, ''),																						");
		sql.append("	    IFNULL(A.DV_TIME, ''),																					");
		sql.append("	    IFNULL(A.NALSU, ''),																					");
		sql.append("	    IFNULL(A.BOGYONG_CODE, ''),																				");
		sql.append("	    IFNULL(A.JUSA_CODE, ''),																				");
		sql.append("	    IFNULL(A.JUSA_SPD_GUBUN, ''),																			");
		sql.append("	    A.BUNHO,																					");
		sql.append("	    CAST(A.FKINP1001 AS CHAR),																				");
		sql.append("	    DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d'),																				");
		sql.append("	    A.INPUT_GUBUN,																				");
		sql.append("	    CAST(A.PK_SEQ AS CHAR),																					");
		sql.append("	    CAST(A.SEQ AS CHAR),																						");
		sql.append("	    A.DIRECT_GUBUN,																				");
		sql.append("	    A.DIRECT_CODE,																				");
		sql.append("	    A.DIRECT_DETAIL,																			");
		sql.append("	    IFNULL(C.CODE_NAME, '') AS JUSA_CODE_NAME,																");
		sql.append("	    IFNULL(D.CODE_NAME, '') AS JUSA_SPD_NAME,																");
		sql.append("	    IFNULL(IFNULL(E.BOGYONG_NAME, A.BOGYONG_CODE), '') AS BOGYONG_NAME,										");
		sql.append("	    IFNULL(A.BOM_YN, ''),																					");
		sql.append("	    IFNULL(A.BOM_SOURCE_KEY, ''),																			");
		sql.append("	    FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, :f_order_date, :f_hosp_code) 		BULYONG_YN		");
		sql.append("	FROM																							");
		sql.append("	  	OCS2006 A 	JOIN 		OCS0103 B															");
		sql.append("					ON 			A.HOSP_CODE 		= B.HOSP_CODE									");
		sql.append("					AND 		A.HANGMOG_CODE 		= B.HANGMOG_CODE								");
		sql.append("					LEFT JOIN 	OCS0132 C															");
		sql.append("					ON 			A.HOSP_CODE 		= C.HOSP_CODE									");
		sql.append("					AND 		'JUSA' 				= C.CODE_TYPE									");
		sql.append("	  				AND 		A.JUSA_CODE 		= C.CODE										");
		sql.append("					LEFT JOIN 	OCS0132 D															");
		sql.append("					ON 			A.HOSP_CODE 		= D.HOSP_CODE									");
		sql.append("					AND 		'JUSA_SPD_GUBUN' 	= D.CODE_TYPE									");
		sql.append("					AND 		A.JUSA_SPD_GUBUN 	= D.CODE										");
		sql.append("					LEFT JOIN 	DRG0120 E 															");
		sql.append("					ON 			A.HOSP_CODE 		= E.HOSP_CODE									");
		sql.append("					AND 		A.BOGYONG_CODE 		= E.BOGYONG_CODE								");
		sql.append("	WHERE																							");
		sql.append("		A.HOSP_CODE      	= :f_hosp_code															");
		sql.append("	  	AND A.FKOCS2005     = :f_fkocs2005															");
		sql.append("	  	AND A.PK_SEQ        = :f_pk_seq																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2005", CommonUtils.parseDouble(fkocs2005));
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		
		List<OCS6010U10PopupDAgrdOCS2006Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupDAgrdOCS2006Info.class);
		return listInfo;
	}

}
