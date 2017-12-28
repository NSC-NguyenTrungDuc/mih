package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1122RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNUR1122Info;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1122Info;

/**
 * @author dainguyen.
 */
public class Nur1122RepositoryImpl implements Nur1122RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1020U00grdNUR1122Info> getNUR1020U00grdNUR1122Info(String hospCode, String bunho, Double fkinp1001,
			String ymd, String prevqryFlag) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.BUNHO,                                                                                                                          ");
		sql.append("	       B.FKINP1001,                                                                                                                      ");
		sql.append("	       A.YMD,                                                                                                                            ");
		sql.append("	       A.HANGMOG_CODE,                                                                                                                   ");
		sql.append("	       IF(:f_prevqryflag = 'Y', '', A.HANGMOG_VALUE1) HANGMOG_VALUE1,                                                                    ");
		sql.append("	       IF(:f_prevqryflag = 'Y', '', A.HANGMOG_VALUE2) HANGMOG_VALUE2,                                                                    ");
		sql.append("	       IF(:f_prevqryflag = 'Y', '', A.HANGMOG_VALUE3) HANGMOG_VALUE3,                                                                    ");
		sql.append("	       B.HANGMOG_NAME,                                                                                                                   ");
		sql.append("	       C.END_YN                                                                                                                          ");
		sql.append("	FROM (SELECT Y.HANGMOG_NAME, Y.HOSP_CODE, Y.FKINP1001, Y.BUNHO FROM                                                                      ");
		sql.append("		  (SELECT Z.HANGMOG_NAME,                                                                                                            ");
		sql.append("				  Z.HOSP_CODE,                                                                                                               ");
		sql.append("				  Z.FKINP1001,                                                                                                               ");
		sql.append("				  Z.BUNHO                                                                                                                    ");
		sql.append("			 FROM NUR1122 Z                                                                                                                  ");
		sql.append("			WHERE Z.HOSP_CODE = :f_hosp_code                                                                                                 ");
		sql.append("			  AND Z.BUNHO     = :f_bunho                                                                                                     ");
		sql.append("			  AND Z.FKINP1001 = :f_fkinp1001                                                                                                 ");
		sql.append("			  AND Z.YMD       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y%m%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y%m%d')         	 ");
		sql.append("			GROUP BY Z.HANGMOG_NAME, Z.HOSP_CODE, Z.FKINP1001, Z.BUNHO                                                                       ");
		sql.append("		HAVING NOT (COUNT(Z.HANGMOG_VALUE1) = 0 AND COUNT(Z.HANGMOG_VALUE2) = 0 AND COUNT(Z.HANGMOG_VALUE3) = 0)                             ");
		sql.append("			ORDER BY 1 ) Y                                                                                                                   ");
		sql.append("		) B                                                                                                                                  ");
		sql.append("		LEFT JOIN NUR1122 A ON A.HOSP_CODE		= B.HOSP_CODE                                                                                ");
		sql.append("						   AND A.FKINP1001		= B.FKINP1001                                                                                ");
		sql.append("						   AND A.YMD			= STR_TO_DATE(:f_ymd, '%Y%m%d')                                                            ");
		sql.append("						   AND A.HANGMOG_NAME	= B.HANGMOG_NAME                                                                             ");
		sql.append("	   LEFT JOIN (SELECT DISTINCT X.HOSP_CODE, X.FKINP1001, X.HANGMOG_NAME, 'Y' END_YN                                                       ");
		sql.append("		 FROM NUR1122 X                                                                                                                      ");
		sql.append("		WHERE X.HOSP_CODE = :f_hosp_code                                                                                                     ");
		sql.append("		  AND X.BUNHO     = :f_bunho                                                                                                         ");
		sql.append("		  AND X.FKINP1001 = :f_fkinp1001                                                                                                     ");
		sql.append("		  AND '//' 		  IN (X.HANGMOG_VALUE1, X.HANGMOG_VALUE2, X.HANGMOG_VALUE3)                                                          ");
		sql.append("		  AND X.YMD       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y%m%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y%m%d')             ");
		sql.append("		) C ON C.HOSP_CODE		= B.HOSP_CODE                                                                                                ");
		sql.append("		   AND C.FKINP1001		= B.FKINP1001                                                                                                ");
		sql.append("		   AND C.HANGMOG_NAME	= B.HANGMOG_NAME                                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		query.setParameter("f_prevqryflag", prevqryFlag);
		
		List<NUR1020U00grdNUR1122Info> lstResult = new JpaResultMapper().list(query,NUR1020U00grdNUR1122Info.class);
		return lstResult;
	}
	
	@Override
	public String getNUR1020U00MaxYmd(String hospCode, String bunho, String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DATE_FORMAT(IFNULL(MAX(YMD), STR_TO_DATE(:f_ymd,'%Y/%m/%d')), '%Y/%m/%d') YMD ");
		sql.append("	FROM NUR1122                                                                         ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code                                                       ");
		sql.append("	 AND BUNHO     = :f_bunho                                                            ");
		sql.append("	 AND YMD       < STR_TO_DATE(:f_ymd,'%Y/%m/%d')                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ymd", ymd);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<NUR1020Q00layNUR1122Info> getNUR1020Q00layNUR1122Info(String hospCode, String bunho, Double fkinp1001,
			String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.YMD             YMD                                                                                                        ");
		sql.append("	      , B.ROW_NUM         HANGMOG_CODE                                                                                               ");
		sql.append("	      , A.HANGMOG_VALUE1  HANGMOG_VALUE1                                                                                             ");
		sql.append("	      , A.HANGMOG_VALUE2  HANGMOG_VALUE2                                                                                             ");
		sql.append("	      , A.HANGMOG_VALUE3  HANGMOG_VALUE3                                                                                             ");
		sql.append("	  FROM  NUR1122 A                                                                                                                    ");
		sql.append("	     , (SELECT  @rownum \\:= @rownum + 1 AS ROW_NUM, Y.HANGMOG_NAME FROM                                                               ");
		sql.append("	        (SELECT Z.HANGMOG_NAME FROM NUR1122 Z                                                                                        ");
		sql.append("	         WHERE  Z.HOSP_CODE = :f_hosp_code                                                                                           ");
		sql.append("	           AND  Z.BUNHO     = :f_bunho                                                                                               ");
		sql.append("	           AND  Z.FKINP1001 = :f_fkinp1001                                                                                           ");
		sql.append("	           AND  Z.YMD       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m/%d')   ");
		sql.append("	           GROUP BY Z.HANGMOG_NAME                                                                                                   ");
		sql.append("	           HAVING NOT (COUNT(Z.HANGMOG_VALUE1) = 0 AND COUNT(Z.HANGMOG_VALUE2) = 0 AND COUNT(Z.HANGMOG_VALUE3) = 0)                  ");
		sql.append("	           ORDER BY 1 ) Y                                                                                                            ");
		sql.append("			, (SELECT @rownum \\:= 0) r) B                                                                                               ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                                                    ");
		sql.append("	   AND A.BUNHO     = :f_bunho                                                                                                        ");
		sql.append("	   AND A.FKINP1001 = :f_fkinp1001                                                                                                    ");
		sql.append("	   AND A.YMD       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m/%d')            ");
		sql.append("	   AND A.HANGMOG_NAME = B.HANGMOG_NAME                                                                                               ");
		sql.append("	ORDER BY A.HANGMOG_NAME                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020Q00layNUR1122Info> lstResult = new JpaResultMapper().list(query,NUR1020Q00layNUR1122Info.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getNUR1020Q00layNUR1122List(String hospCode, String bunho, Double fkinp1001,
			String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT HANGMOG_NAME, CAST(SORT_KEY AS CHAR)	FROM																			");
		sql.append("	(SELECT '観察項目' HANGMOG_NAME, 0 SORT_KEY FROM DUAL                                                                        ");
		sql.append("	 UNION ALL                                                                                                                  ");
		sql.append("	SELECT Y.HANGMOG_NAME, @rownum \\:= @rownum + 1 AS SORT_KEY FROM                                                            ");
		sql.append("	(SELECT Z.HANGMOG_NAME FROM NUR1122 Z                                                                                       ");
		sql.append("	 WHERE  Z.HOSP_CODE = :f_hosp_code                                                                                          ");
		sql.append("	   AND  Z.BUNHO     = :f_bunho                                                                                              ");
		sql.append("	   AND  Z.FKINP1001 = :f_fkinp1001                                                                                          ");
		sql.append("	   AND  Z.YMD       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m/%d')  ");
		sql.append("	   GROUP BY Z.HANGMOG_NAME                                                                                                  ");
		sql.append("	   HAVING NOT (COUNT(Z.HANGMOG_VALUE1) = 0 AND COUNT(Z.HANGMOG_VALUE2) = 0 AND COUNT(Z.HANGMOG_VALUE3) = 0)                 ");
		sql.append("	   ORDER BY 1 ) Y                                                                                                           ");
		sql.append("	  , (SELECT @rownum \\:= 0) r) T                                                                                         	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return lstResult;
	}
}

