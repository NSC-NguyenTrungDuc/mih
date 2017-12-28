package nta.med.data.dao.medi.bil.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.logging.log4j.util.Strings;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bil.Bil0001RepositoryCustom;
import nta.med.data.model.ihis.bill.BIL2016U00DetailServiceInfo;
import nta.med.data.model.ihis.bill.BIL2016U00ServiceInfo;

/**
 * @author DEV-TiepNM
 */
public class Bil0001RepositoryImpl implements Bil0001RepositoryCustom {

    @PersistenceContext
    private EntityManager entityManager;
    @Override
    public List<BIL2016U00DetailServiceInfo> findByHangMogCodeAndCodeTypeAndHangMogCode(String hospCode, String codeType, String hangMogCode) {
        StringBuilder sql = new StringBuilder();
        sql.append(" SELECT A.CODE_NAME, B.PRICE, B.DISCOUNT, A.CODE ,  B.HANGMOG_CODE                               ");
        sql.append(" from (select * from BAS0102 where HOSP_CODE= :f_hosp_code ) A LEFT JOIN                            ");
        sql.append(" (select * from BIL0001 WHERE HOSP_CODE= :f_hosp_code  )  B                                         ");
        sql.append(" ON  A.CODE  = B.PATIENT_GRP where A.CODE_TYPE = :f_code_type and B.HANGMOG_CODE= :hangMogCode      ");

        Query query = entityManager.createNativeQuery(sql.toString());
        query.setParameter("f_hosp_code", hospCode);
        query.setParameter("f_code_type", codeType);
        query.setParameter("hangMogCode", hangMogCode);

        List<BIL2016U00DetailServiceInfo> listResult = new JpaResultMapper().list(query, BIL2016U00DetailServiceInfo.class);
        return listResult;

    }
	@Override
	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfoCaseVisitFee(String hospCode, String language,
			String codeName, Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT																											");	
		sql.append(" A.CODE			,																								");
		sql.append(" A.CODE_NAME	hangmogName		,																				");	
		sql.append(" B.CODE_NAME	codeName	,																					");	
		sql.append(" C.PRICE1			,																							");
		sql.append(" C.PRICE2			,																							");
		sql.append(" C.PRICE3																										");
		sql.append(" FROM BAS0102 A	INNER JOIN	OCS0132 B	ON		B.HOSP_CODE	=	A.HOSP_CODE	AND	B.LANGUAGE =	A.LANGUAGE      ");
		sql.append("                             AND	B.CODE =	'ADMISSION_FEE' AND	B.CODE_TYPE =	'ADMISSION_FEE' 	        ");
		sql.append(" 				LEFT JOIN	BIL0001 C	ON		A.HOSP_CODE 	=	C.HOSP_CODE	AND	C.HANGMOG_CODE =	A.CODE	");						
		sql.append(" WHERE A.CODE_NAME	like :code_name														                        ");
		sql.append(" 	AND	A.HOSP_CODE	=	:hosp_code										                                        ");
		sql.append(" 	AND	A.LANGUAGE = :language                                                                                  ");
		sql.append(" 	AND	A.CODE_TYPE =	'CHOJAE'																				");		
		if(pageNumber != null && offset != null){
			sql.append(" LIMIT :f_page_number,:f_offset 																		    ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
        query.setParameter("hosp_code", hospCode);
        query.setParameter("language", language);
        query.setParameter("code_name", "%" + codeName + "%");
        if(pageNumber != null && offset != null){
			query.setParameter("f_page_number",pageNumber);
			query.setParameter("f_offset", offset);
		}
        List<BIL2016U00ServiceInfo> listResult = new JpaResultMapper().list(query, BIL2016U00ServiceInfo.class);
        return listResult;
	}
	
	@Override
	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfoCaseSearchAll(String hospCode, String hangmogNameInx, String orderGubun, String codeType, String language, Integer pageNumber, Integer offset){
		StringBuilder sql = new StringBuilder();	
		sql.append(" SELECT                                                														    			");
		sql.append("			OCS.HANGMOG_CODE , 																								");
		sql.append("			OCS.HANGMOG_NAME ,														 										");
		sql.append("			C.CODE_NAME, 																									");
		sql.append("			BIL.PRICE1, 																									");
		sql.append("			BIL.PRICE2, 																									");
		sql.append("			BIL.PRICE3					   																					");
		sql.append(" FROM OCS0103 OCS LEFT JOIN OCS0132 C  ON OCS.HOSP_CODE = C.HOSP_CODE AND OCS.ORDER_GUBUN = C.CODE			                ");
		sql.append("                  LEFT JOIN BIL0001	BIL	ON	OCS.HOSP_CODE = BIL.HOSP_CODE AND OCS.HANGMOG_CODE = BIL.HANGMOG_CODE 		    ");
		sql.append(" WHERE OCS.HOSP_CODE = :f_hosp_code																						    ");
		sql.append("    AND C.LANGUAGE = :f_language														    							    ");
		sql.append("    AND C.CODE_TYPE = 'ORDER_GUBUN_BAS'				                                                                        ");
		
		
		if(!Strings.isEmpty(hangmogNameInx))
		{
			sql.append(" AND OCS.HANGMOG_NAME_INX LIKE :f_hangmog_name																			");
		}
		if(!Strings.isEmpty(orderGubun))
		{
			sql.append(" AND OCS.ORDER_GUBUN LIKE :f_order_gubun																				");
		}
//		sql.append(" ORDER BY ISNULL(BIL.PRICE1) ASC , ISNULL(BIL.PRICE2) ASC , ISNULL(BIL.PRICE3) ASC , OCS.HANGMOG_CODE ASC   				");

		sql.append(" 	UNION																										");
		
		sql.append(" SELECT																											");	
		sql.append(" A.CODE			,																								");
		sql.append(" A.CODE_NAME	hangmogName		,																				");	
		sql.append(" B.CODE_NAME	codeName	,																					");	
		sql.append(" C.PRICE1			,																							");
		sql.append(" C.PRICE2			,																							");
		sql.append(" C.PRICE3																										");
		sql.append(" FROM BAS0102 A	INNER JOIN	OCS0132 B	ON		B.HOSP_CODE	=	A.HOSP_CODE	AND	B.LANGUAGE =	A.LANGUAGE      ");
		sql.append("                             AND	B.CODE =	'ADMISSION_FEE' AND	B.CODE_TYPE =	'ADMISSION_FEE' 	        ");
		sql.append(" 				LEFT JOIN	BIL0001 C	ON		A.HOSP_CODE 	=	C.HOSP_CODE	AND	C.HANGMOG_CODE =	A.CODE	");						
		sql.append(" WHERE A.CODE_NAME	like :code_name														                        ");
		sql.append(" 	AND	A.HOSP_CODE	=	:f_hosp_code										                                    ");
		sql.append(" 	AND	A.LANGUAGE = :f_language                                                                                ");
		sql.append(" 	AND	A.CODE_TYPE =	'CHOJAE'																				");
		if(pageNumber != null && offset != null){
			sql.append(" LIMIT :f_page_number,:f_offset 																					    ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("code_name", "%" + hangmogNameInx + "%");

		if(!Strings.isEmpty(hangmogNameInx))
		{
			query.setParameter("f_hangmog_name", "%"+hangmogNameInx+"%");
		}
		if(!Strings.isEmpty(orderGubun))
		{
			query.setParameter("f_order_gubun", orderGubun);
		}
		if(pageNumber != null && offset != null){
			query.setParameter("f_page_number",pageNumber);
			query.setParameter("f_offset", offset);
		}
		List<BIL2016U00ServiceInfo> listResult = new JpaResultMapper()
				.list(query, BIL2016U00ServiceInfo.class);
		return listResult;
	}
}
