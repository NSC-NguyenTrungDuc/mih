package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur9001RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR9001U00grdNur9001Info;

/**
 * @author dainguyen.
 */
public class Nur9001RepositoryImpl implements Nur9001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR9001U00grdNur9001Info> getNUR9001U00grdNur9001Info(String hospCode, String fromDate, String toDate, String bunho, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
//		sql.append("   SELECT IFNULL(A.CODE_TYPE, ' ') CODE_TYPE,                                   ");
//		sql.append("          IFNULL(A.CODE, ' ') CODE,                                             ");
//		sql.append("          IFNULL(A.CODE_NAME, ' ') CODE_NAME,                                   ");
//		sql.append("          IFNULL(A.SORT_KEY, '')  SORT_KEY ,                                    ");
//		sql.append("          IFNULL(A.GROUP_KEY, '') GROUP_KEY,                                    ");

		sql.append("   SELECT A.PKNUR9001                                     PKNUR9001       ,                                  ");
		sql.append("          A.FKINP1001                                     FKINP1001       ,                                  ");
		sql.append("          A.BUNHO                                         BUNHO           ,                                  ");
		sql.append("          DATE_FORMAT(A.RECORD_DATE, '%Y/%m/%d')          RECORD_DATE     ,                                  ");
		sql.append("          A.RECORD_TIME                                   RECORD_TIME     ,                                  ");
		sql.append("          A.SOAP_GUBUN                                    SOAP_GUBUN      ,                                  ");
		sql.append("          A.RECORD_CONTENTS                               RECORD_CONTENTS ,                                  ");
		sql.append("          A.NUR_PLAN_JIN                                  NUR_PLAN_JIN    ,                                  ");
		sql.append("          A.RECORD_USER                                   RECORD_USER     ,                                  ");
		sql.append("          FN_ADM_LOAD_USER_NM(A.HOSP_CODE, A.RECORD_USER, A.RECORD_DATE) RECORD_USER_NAME,                   ");
		sql.append("          IFNULL(A.VALD, 'N')                             VALD            ,                                  ");
		sql.append("          IFNULL(A.DC_YN, 'N')                            DC_YN           ,                                  ");
		sql.append("          A.DC_USER                                       DC_USER         ,                                  ");
		sql.append("          A.MAYAK_USE_YN                                  MAYAK_USE_YN    ,                                  ");
		sql.append("          A.RECORD_CONTENTS                               RECORD_CONTENTS2 ,                                 ");
		sql.append("          A.FKNUR4001                                     FKNUR4001       ,                                  ");
		sql.append("          CASE WHEN SYSDATE() >= DATE_ADD(STR_TO_DATE(CONCAT(DATE_FORMAT(A.RECORD_DATE, '%Y%m%d'),           ");
		sql.append("                    A.RECORD_TIME), '%Y%m%d%H%i%s'), INTERVAL 1 DAY) THEN                                    ");
		sql.append("                    'Y'                                                                                      ");
		sql.append("               ELSE 'N' END                               OVER24		  ,                                  ");
		sql.append("          ''                             			      DATA_ROW_STATE                                     ");
		sql.append("     FROM NUR9001 A                                                                                          ");
		sql.append("     LEFT JOIN NUR4001 B                                                                                     ");
		sql.append("       ON B.HOSP_CODE   = A.HOSP_CODE                                                                        ");
		sql.append("      AND B.BUNHO       = A.BUNHO                                                                            ");
		sql.append("      AND B.PKNUR4001   = A.FKNUR4001                                                                        ");
		sql.append("    WHERE A.HOSP_CODE   = :f_hosp_code                                                                       ");
		sql.append("      AND A.BUNHO       = :f_bunho                                                                           ");
		sql.append("      AND A.FKINP1001   = :f_fkinp1001                                                                       ");
		sql.append("      AND A.RECORD_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')  ");
		sql.append("      AND CASE(A.VALD) WHEN '' THEN 'Y' ELSE IFNULL(A.VALD, 'Y') END = 'Y'                                   ");
		sql.append("    ORDER BY A.RECORD_DATE                                                                                   ");
		sql.append("           , A.RECORD_TIME                                                                                   ");
		sql.append("           , B.SORT_KEY                                                                                      ");
		sql.append("           , B.NUR_PLAN_JIN                                                                                  ");
		sql.append("           , CASE(A.SOAP_GUBUN) WHEN 'S' THEN '1' WHEN 'O' THEN '2'                                          ");
		sql.append("                                WHEN 'A' THEN '3' WHEN 'P' THEN '4' ELSE '5' END                             ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																			  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR9001U00grdNur9001Info> listInfo = new JpaResultMapper().list(query, NUR9001U00grdNur9001Info.class);
		return listInfo;
		
	}
	
	@Override
	public String getNUR9001U00Nur9001dataCheck(String hospCode, Double pknur9001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y' FROM NUR9001 A WHERE A.HOSP_CODE = :f_hosp_code AND A.PKNUR9001 = :f_pknur9001     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pknur9001", pknur9001);
		
		List<String> result = query.getResultList();
		
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
}

