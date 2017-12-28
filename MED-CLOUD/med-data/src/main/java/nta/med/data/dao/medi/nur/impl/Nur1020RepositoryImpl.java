package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1020RepositoryCustom;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layGraphInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNUR7002Info;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNutInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1020Info;
import nta.med.data.model.ihis.nuri.NUR8003U03QueryFormGrdBPInfo;

/**
 * @author dainguyen.
 */
public class Nur1020RepositoryImpl implements Nur1020RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getDataFromNur1020(String hospCode, Double fkinp1001, String ymd, String timeGubun, String prGubun) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT         									");             
		sql.append("		'Y'         								");
		sql.append("	FROM                                            ");
		sql.append("		NUR1020                                     ");
		sql.append("	WHERE       									");
		sql.append("	    HOSP_CODE = :f_hosp_code  	                ");
		sql.append("	    AND FKINP1001 = :f_fkinp1001  	            ");
		sql.append("	    AND YMD   	  = str_to_date(:f_ymd, '%Y/%m/%d')	");
		sql.append("	    AND TIME_GUBUN = :f_time_gubun  	        ");
		sql.append("	    AND PR_GUBUN   = :f_pr_gubun	            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		query.setParameter("f_time_gubun", timeGubun);
		query.setParameter("f_pr_gubun", prGubun);

		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<NUR1020U00grdNUR1020Info> getNUR1020U00grdNUR1020Info(String hospCode, String bunho, Double fkInp1001,
			String fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.BUNHO, :f_bunho)                                    BUNHO               ");
		sql.append("	     , MAX(IFNULL(A.FKINP1001, :f_fkinp1001))                       FKINP1001           ");
		sql.append("	     , MAX(IFNULL(A.YMD, STR_TO_DATE(:f_date, '%Y%m%d')))         YMD                 ");
		sql.append("	     , IFNULL(B.VSPATN_GUBUN, '')                                   VSPATN_GUBUN        ");
		sql.append("	     , A.TIME_GUBUN                                                 VSPATN_TIME         ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'P', PR_VALUE, 0))                         PR_GUBUN1           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'BPL', PR_VALUE, 0))                       PR_GUBUN2           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'BPH', PR_VALUE, 0))                       PR_GUBUN3           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'T', PR_VALUE, 0))                         PR_GUBUN4           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'SPO2', PR_VALUE, 0))                      PR_GUBUN5           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'R', PR_VALUE, 0))                         PR_GUBUN6           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'BS', PR_VALUE, 0))                        PR_GUBUN7           ");
		sql.append("	     , SUM(IF(PR_GUBUN = 'O2', PR_VALUE, 0))                        PR_GUBUN8           ");
		sql.append("	  FROM NUR1020 A                                                                        ");
		sql.append("	  LEFT JOIN ( SELECT Z.VSPATN_GUBUN                                                     ");
		sql.append("	                  , Z.FKINP1001                                                         ");
		sql.append("	              FROM NUR1023 Z                                                            ");
		sql.append("	             WHERE Z.HOSP_CODE = :f_hosp_code                                           ");
		sql.append("	               AND Z.FKINP1001 = :f_fkinp1001                                           ");
		sql.append("	               AND Z.BUNHO     = :f_bunho                                               ");
		sql.append("	               AND Z.ORDER_DATE = STR_TO_DATE(:f_date, '%Y%m%d')                      ");
		sql.append("	        ) B                                                                             ");
		sql.append("	  ON B.FKINP1001 = A.FKINP1001                                                          ");
		sql.append("	 WHERE A.HOSP_CODE         = :f_hosp_code                                               ");
		sql.append("	   AND A.BUNHO             = :f_bunho                                                   ");
		sql.append("	   AND A.FKINP1001         = :f_fkinp1001                                               ");
		sql.append("	   AND A.YMD               = STR_TO_DATE(:f_date, '%Y%m%d')                           ");
		sql.append("	GROUP BY IFNULL(A.BUNHO, :f_bunho)                                                      ");
		sql.append("	       , B.VSPATN_GUBUN                                                                 ");
		sql.append("	       , A.TIME_GUBUN                                                                   ");
		sql.append("	ORDER BY A.TIME_GUBUN desc                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkInp1001);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_date", fDate);
		
		List<NUR1020U00grdNUR1020Info> listData = new JpaResultMapper().list(query, NUR1020U00grdNUR1020Info.class);
		return listData;
	}

	@Override
	public String getNUR1020U00MaxYmd(String hospCode, String bunho, String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DATE_FORMAT(IFNULL(MAX(YMD), STR_TO_DATE(:f_ymd,'%Y/%m/%d')), '%Y/%m/%d') YMD ");
		sql.append("	FROM NUR1020                                                                         ");
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
	public void callPrNurInputVitalValue(String userId, String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String gubun1, String gubun2, String gubun3, String value) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_INPUT_VITAL_VALUE");
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_GUBUN2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_GUBUN3", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_VALUE", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_GUBUN1", gubun1);
		query.setParameter("I_GUBUN2", gubun2);
		query.setParameter("I_GUBUN3", gubun3);
		query.setParameter("I_VALUE", value);
		
		query.execute();
	}

	@Override
	public CommonProcResultInfo callPrCplInsertUrine(String hospCode, Date orderDate, String bunho, Double pkinp1001) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_INSERT_URINE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_PKINP1001", pkinp1001);
		
		query.execute();
		
		String errMsg = (String)query.getOutputParameterValue("IO_ERR_MSG"); 
		String err = (String)query.getOutputParameterValue("IO_ERR");
		
		CommonProcResultInfo info = new CommonProcResultInfo();
		info.setStrResult1(err);
		info.setStrResult2(errMsg);
		return info;
	}

	@Override
	public List<NUR1020Q00layGraphInfo> getNUR1020Q00layGraphInfo(String hospCode, String bunho, Double fkinp1001,
			String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  DATE_FORMAT(A.YMD, '%m/%d') YMD1,                                                                               ");
		sql.append("	        A.TIME_GUBUN                TIME_GUBUN,                                                                         ");
		sql.append("	        A.PR_GUBUN                  PR_GUBUN,                                                                           ");
		sql.append("	        IFNULL(A.PR_VALUE,0)        PR_VALUE,                                                                           ");
		sql.append("	        A.YMD                       YMD                                                                                 ");
		sql.append("	FROM NUR1020 A                                                                                                          ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                                        ");
		sql.append("	 AND A.FKINP1001  = :f_fkinp1001                                                                                        ");
		sql.append("	 AND A.BUNHO      = :f_bunho                                                                                            ");
		sql.append("	 AND A.YMD        BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd,'%Y/%m/%d') ");
		sql.append("	ORDER BY A.YMD, A.TIME_GUBUN                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020Q00layGraphInfo> listData = new JpaResultMapper().list(query, NUR1020Q00layGraphInfo.class);
		return listData;
	}

	@Override
	public List<NUR1020Q00layNutInfo> getNUR1020Q00layNutInfo(String hospCode, String bunho, Double pkinp1001,
			String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUT_DATE                                                       YMD,                                                                           ");
		sql.append("	       CASE                                                                                                                                            ");
		sql.append("	        WHEN A.BLD_GUBUN = 1 THEN 'T1'                                                                                                                 ");
		sql.append("	        WHEN A.BLD_GUBUN = 2 THEN 'T2'                                                                                                                 ");
		sql.append("	        WHEN A.BLD_GUBUN = 3 THEN 'T3'                                                                                                                 ");
		sql.append("	        ELSE ''                                                                                                                                        ");
		sql.append("	       END                                                              NUT_GUBUN,                                                                     ");
		sql.append("	       IF(B.NUT_VALUE = 99, '少量', B.NUT_VALUE)                        NUT_VALUE,                                                                       ");
		sql.append("	       IF(B.NUT_VALUE2 = 99, '少量', B.NUT_VALUE2)                      NUT_VALUE2,                                                                      ");
		sql.append("	       ''                                                               SIKSA_GUBUN,                                                                   ");
		sql.append("	       IFNULL(A.SIK_JONG_NAME_S, A.SIK_JONG_NAME)                       SIKSA_JONG_NAME,                                                               ");
		sql.append("	       IFNULL(A.SIK_JUSIK_NAME_S, A.SIK_JUSIK_NAME)                     SIKSA_JUSIK_NAME,                                                              ");
		sql.append("	       IFNULL(A.SIK_BUSIK_NAME_S, A.SIK_BUSIK_NAME)                     SIKSA_BUSIK_NAME                                                               ");
		sql.append("	  FROM (                                                                                                                                               ");
		sql.append("		SELECT  B.HOSP_CODE,                                                                                                                               ");
		sql.append("	    		B.PKOCS2005,                                                                                                                               ");
		sql.append("	    		B.BUNHO,                                                                                                                                   ");
		sql.append("	    		B.FKINP1001,                                                                                                                               ");
		sql.append("	    		A.IPWON_DATE,                                                                                                                              ");
		sql.append("	    		A.TOIWON_DATE,                                                                                                                             ");
		sql.append("	    		B.ORDER_DATE,                                                                                                                              ");
		sql.append("	    		B.INPUT_GUBUN,                                                                                                                             ");
		sql.append("	    		B.INPUT_ID,                                                                                                                                ");
		sql.append("	    		B.PK_SEQ,                                                                                                                                  ");
		sql.append("	    		B.DIRECT_GUBUN,                                                                                                                            ");
		sql.append("	    		B.DRT_FROM_DATE,                                                                                                                           ");
		sql.append("	    		B.DRT_TO_DATE,                                                                                                                             ");
		sql.append("	    		IFNULL(                                                                                                                                    ");
		sql.append("	    		   B.DRT_TO_DATE,                                                                                                                          ");
		sql.append("	    		   (SELECT (DATE_ADD(MIN(Z.DRT_FROM_DATE), INTERVAL -1 DAY))                                                                               ");
		sql.append("	    			  FROM OCS2005 Z                                                                                                                       ");
		sql.append("	    			  WHERE Z.HOSP_CODE = B.HOSP_CODE                                                                                                      ");
		sql.append("	    				  AND Z.DIRECT_CODE = B.DIRECT_CODE                                                                                                ");
		sql.append("	    				  AND Z.BUNHO = B.BUNHO                                                                                                            ");
		sql.append("	    				  AND Z.BLD_GUBUN = B.BLD_GUBUN                                                                                                    ");
		sql.append("	    				  AND Z.DRT_FROM_DATE > B.DRT_FROM_DATE))                                                                                          ");
		sql.append("	    		   AS DRT_TO_DATE2,                                                                                                                        ");
		sql.append("	    		B.CONTINUE_YN,                                                                                                                             ");
		sql.append("	    		DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)  AS NUT_DATE,                                                                               ");
		sql.append("	    		B.BLD_GUBUN,                                                                                                                               ");
		sql.append("	    		(AA.ADD_DAY + 1)                                AS JAEWON_DAY,                                                                             ");
		sql.append("	    		B.DIRECT_CODE,                                                                                                                             ");
		sql.append("	    		B.DIRECT_CODE_D,                                                                                                                           ");
		sql.append("	    		N0.NUR_SO_NAME                                  AS SIK_GUBUN_NAME,                                                                         ");
		sql.append("	  		  N0.MENT                                         AS SIK_GUBUN_NAME_S,                                                                         ");
		sql.append("	    		B.DIRECT_CONT1,                                                                                                                            ");
		sql.append("	    		B.DIRECT_CONT1_D,                                                                                                                          ");
		sql.append("	    		N1.NUR_SO_NAME                                  AS SIK_JONG_NAME,                                                                          ");
		sql.append("	    		N1.MENT                                         AS SIK_JONG_NAME_S,                                                                        ");
		sql.append("	    		B.DIRECT_CONT2,                                                                                                                            ");
		sql.append("	    		B.DIRECT_CONT2_D,                                                                                                                          ");
		sql.append("	    		N2.NUR_SO_NAME                                  AS SIK_JUSIK_NAME,                                                                         ");
		sql.append("	    		N2.MENT                                         AS SIK_JUSIK_NAME_S,                                                                       ");
		sql.append("	    		B.DIRECT_CONT3,                                                                                                                            ");
		sql.append("	    		B.DIRECT_CONT3_D,                                                                                                                          ");
		sql.append("	    		N3.NUR_SO_NAME                                  AS SIK_BUSIK_NAME,                                                                         ");
		sql.append("	    		N3.MENT                                         AS SIK_BUSIK_NAME_S,                                                                       ");
		sql.append("	    		B.NOMIMONO,                                                                                                                                ");
		sql.append("	    		N4.NUR_SO_NAME                                  AS SIK_NOMIMONO_NAME,                                                                      ");
		sql.append("	    		N4.MENT                                         AS SIK_NOMIMONO_NAME_S,                                                                    ");
		sql.append("	    		B.KUMJISIK,                                                                                                                                ");
		sql.append("	    		B.INPUT_GWA,                                                                                                                               ");
		sql.append("	    		B.INPUT_DOCTOR,                                                                                                                            ");
		sql.append("	    		IFNULL(C.TO_HO_DONG1, A.HO_DONG1)               AS HO_DONG,                                                                                ");
		sql.append("	    		IFNULL(C.TO_HO_CODE1, A.HO_CODE1)               AS HO_CODE,                                                                                ");
		sql.append("	    		A.TOIWON_RES_DATE,                                                                                                                         ");
		sql.append("	    		A.TOIWON_RES_TIME,                                                                                                                         ");
		sql.append("	    		A.CANCEL_YN                                                                                                                                ");
		sql.append("		FROM INP1001 A                                                                                                                                     ");
		sql.append("		JOIN OCS2005 B ON B.HOSP_CODE     = A.HOSP_CODE                                                                                                    ");
		sql.append("						AND B.BUNHO         = A.BUNHO                                                                                                      ");
		sql.append("						AND B.FKINP1001     = A.PKINP1001                                                                                                  ");
		sql.append("						AND B.DIRECT_GUBUN  = '03'                                                                                                         ");
		sql.append("					  AND B.DRT_FROM_DATE >= A.IPWON_DATE                                                                                                  ");
		sql.append("		JOIN INP2004 C ON C.HOSP_CODE     = A.HOSP_CODE                                                                                                    ");
		sql.append("						AND C.BUNHO         = A.BUNHO                                                                                                      ");
		sql.append("						AND C.FKINP1001     = A.PKINP1001                                                                                                  ");
		sql.append("		LEFT JOIN NUR0112 N0 ON N0.HOSP_CODE    = B.HOSP_CODE                                                                                              ");
		sql.append("								AND N0.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                       ");
		sql.append("								AND N0.NUR_MD_CODE  = B.DIRECT_CODE                                                                                        ");
		sql.append("								AND N0.NUR_SO_CODE  = B.DIRECT_CODE_D                                                                                      ");
		sql.append("		LEFT JOIN NUR0112 N1 ON N1.HOSP_CODE    = B.HOSP_CODE                                                                                              ");
		sql.append("								AND N1.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                       ");
		sql.append("								AND N1.NUR_MD_CODE  = B.DIRECT_CONT1                                                                                       ");
		sql.append("								AND N1.NUR_SO_CODE  = B.DIRECT_CONT1_D                                                                                     ");
		sql.append("		LEFT JOIN NUR0112 N2 ON N2.HOSP_CODE    = B.HOSP_CODE                                                                                              ");
		sql.append("								AND N2.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                       ");
		sql.append("								AND N2.NUR_MD_CODE  = B.DIRECT_CONT2                                                                                       ");
		sql.append("								AND N2.NUR_SO_CODE  = B.DIRECT_CONT2_D                                                                                     ");
		sql.append("		LEFT JOIN NUR0112 N3 ON N3.HOSP_CODE    = B.HOSP_CODE                                                                                              ");
		sql.append("								AND N3.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                       ");
		sql.append("								AND N3.NUR_MD_CODE  = B.DIRECT_CONT3                                                                                       ");
		sql.append("								AND N3.NUR_SO_CODE  = B.DIRECT_CONT3_D                                                                                     ");
		sql.append("		LEFT JOIN NUR0112 N4 ON N4.HOSP_CODE    = B.HOSP_CODE                                                                                              ");
		sql.append("								AND N4.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                       ");
		sql.append("								AND N4.NUR_MD_CODE  = '0305'                                                                                               ");
		sql.append("								AND N4.NUR_SO_CODE  = B.NOMIMONO                                                                                           ");
		sql.append("		,(                                                                                                                                                 ");
		sql.append("		  SELECT @rownr\\:=@rownr+1 AS ADD_DAY                                                                                                               ");
		sql.append("			FROM INP1001, (SELECT @rownr\\:=-1) TMP                                                                                                          ");
		sql.append("		) AA                                                                                                                                               ");
		sql.append("		WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                 ");
		sql.append("		  AND A.BUNHO       = :f_bunho                                                                                                                     ");
		sql.append("		  AND A.PKINP1001   = :f_pkinp1001                                                                                                                 ");
		sql.append("			AND B.DRT_FROM_DATE =                                                                                                                          ");
		sql.append("				   IFNULL(                                                                                                                                 ");
		sql.append("					  (SELECT MAX(Z.DRT_FROM_DATE)                                                                                                         ");
		sql.append("						 FROM OCS2005 Z                                                                                                                    ");
		sql.append("						 WHERE Z.HOSP_CODE      = B.HOSP_CODE                                                                                              ");
		sql.append("							 AND Z.FKINP1001      = B.FKINP1001                                                                                            ");
		sql.append("							 AND Z.DIRECT_CODE    = B.DIRECT_CODE                                                                                          ");
		sql.append("							 AND Z.BUNHO          = B.BUNHO                                                                                                ");
		sql.append("							 AND Z.BLD_GUBUN      = B.BLD_GUBUN                                                                                            ");
		sql.append("							 AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)                                                        ");
		sql.append("							 AND (Z.DRT_TO_DATE IS NULL                                                                                                    ");
		sql.append("								   OR Z.DRT_TO_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))),                                                  ");
		sql.append("					  (SELECT MAX(Z.DRT_FROM_DATE)                                                                                                         ");
		sql.append("						 FROM OCS2005 Z                                                                                                                    ");
		sql.append("						 WHERE Z.HOSP_CODE      = B.HOSP_CODE                                                                                              ");
		sql.append("							 AND Z.FKINP1001      = B.FKINP1001                                                                                            ");
		sql.append("							 AND Z.DIRECT_CODE    = B.DIRECT_CODE                                                                                          ");
		sql.append("							 AND Z.BUNHO          = B.BUNHO                                                                                                ");
		sql.append("							 AND Z.BLD_GUBUN      = B.BLD_GUBUN                                                                                            ");
		sql.append("							 AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)                                                        ");
		sql.append("							 AND Z.DRT_TO_DATE =                                                                                                           ");
		sql.append("									 (SELECT MAX(X.DRT_TO_DATE)                                                                                            ");
		sql.append("										FROM OCS2005 X                                                                                                     ");
		sql.append("									   WHERE X.HOSP_CODE      = Z.HOSP_CODE                                                                                ");
		sql.append("											 AND X.DIRECT_CODE    = Z.DIRECT_CODE                                                                          ");
		sql.append("											 AND X.BUNHO          = Z.BUNHO                                                                                ");
		sql.append("											 AND X.BLD_GUBUN      = Z.BLD_GUBUN                                                                            ");
		sql.append("											 AND X.DRT_FROM_DATE  <=DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))))                                     ");
		sql.append("			AND C.START_DATE =                                                                                                                             ");
		sql.append("				   (SELECT MAX(Z.START_DATE)                                                                                                               ");
		sql.append("					  FROM INP2004 Z                                                                                                                       ");
		sql.append("					  WHERE Z.HOSP_CODE   = C.HOSP_CODE                                                                                                    ");
		sql.append("						  AND Z.BUNHO       = C.BUNHO                                                                                                      ");
		sql.append("						  AND Z.FKINP1001   = C.FKINP1001                                                                                                  ");
		sql.append("						  AND Z.START_DATE  <= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))                                                            ");
		sql.append("			AND C.TRANS_CNT =                                                                                                                              ");
		sql.append("				   (SELECT MAX(Z.TRANS_CNT)                                                                                                                ");
		sql.append("					  FROM INP2004 Z                                                                                                                       ");
		sql.append("					  WHERE Z.HOSP_CODE   = C.HOSP_CODE                                                                                                    ");
		sql.append("						  AND Z.BUNHO       = C.BUNHO                                                                                                      ");
		sql.append("						  AND Z.FKINP1001   = C.FKINP1001                                                                                                  ");
		sql.append("						  AND Z.START_DATE  = C.START_DATE)                                                                                                ");
		sql.append("			AND AA.ADD_DAY <= (DATEDIFF(IFNULL(A.TOIWON_DATE, CURRENT_DATE), A.IPWON_DATE) + IF(A.TOIWON_DATE IS NULL, 31, 0))                             ");
		sql.append("		ORDER BY 1, BLD_GUBUN, ADD_DAY                                                                                                                     ");
		sql.append("	  )/*VW_OCS_OCS2005_NUT*/ A                                                                                                                            ");
		sql.append("	  LEFT JOIN NUR1021 B ON B.HOSP_CODE  = A.HOSP_CODE                                                                                                    ");
		sql.append("	                     AND B.YMD        = A.NUT_DATE                                                                                                     ");
		sql.append("	                     AND B.BUNHO      = A.BUNHO                                                                                                        ");
		sql.append("	                     AND B.FKINP1001  = A.FKINP1001                                                                                                    ");
		sql.append("	                     AND SUBSTRING(B.NUT_GUBN, 2, 1)   = A.BLD_GUBUN                                                                                   ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                 ");
		sql.append("	   AND A.BUNHO          = :f_bunho                                                                                                                     ");
		sql.append("	   AND A.FKINP1001      = :f_pkinp1001                                                                                                                 ");
		sql.append("	   AND A.NUT_DATE       BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd,'%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd,'%Y/%m/%d')                           ");
		sql.append("	 ORDER BY A.NUT_DATE, A.BLD_GUBUN                                                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020Q00layNutInfo> listData = new JpaResultMapper().list(query, NUR1020Q00layNutInfo.class);
		return listData;
	}

	@Override
	public List<NUR1020Q00layNUR7002Info> getNUR1020Q00layNUR7002Info(String hospCode, Double fkinp1001, String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKINP1001 												FKINP1001                                            ");
		sql.append("	       , DATEDIFF(A.YMD, STR_TO_DATE(:f_ymd, '%Y/%m/%d')) + 6 	DIFF                                                 ");
		sql.append("	       , A.HANGMOG_GUBUN 										HANGMOG_GUBUN                                        ");
		sql.append("	       , CAST(A.HANGMOG_SEQ AS CHAR) 							HANGMOG_SEQ                                          ");
		sql.append("	       , CASE A.HANGMOG_GUBUN                                                                                        ");
		sql.append("	              WHEN 'WRITER'                                                                                          ");
		sql.append("	              THEN IFNULL(FN_ADM_LOAD_USER_NAME_SHORT (:f_hosp_code, A.HANGMOG_VALUE), IFNULL(A.HANGMOG_VALUE, ''))  ");
		sql.append("	              ELSE IFNULL(A.HANGMOG_VALUE, '')                                                                       ");
		sql.append("	       END          											HANGMOG_VALUE                                        ");
		sql.append("	  FROM NUR7002 A                                                                                                     ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("	   AND A.YMD BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m/%d')    ");
		sql.append("	   AND A.FKINP1001 = :f_fkinp1001                                                                                    ");
		sql.append("	UNION ALL                                                                                                            ");
		sql.append("	                                                                                                                     ");
		sql.append("	SELECT B.FKINP1001 FKINP1001                                                                                         ");
		sql.append("	       , DATEDIFF(B.YMD, STR_TO_DATE(:f_ymd, '%Y/%m/%d')) + 6 	DIFF                                                 ");
		sql.append("	       , B.IO_TYPE 												HANGMOG_GUBUN                                        ");
		sql.append("	       , '1' 													HANGMOG_SEQ                                          ");
		sql.append("	       , CASE WHEN B.IO_TYPE = 'AS' THEN FN_NUR_LOAD_VSPATN_AS(:f_hosp_code, B.IO_VALUE)                             ");
		sql.append("	             WHEN B.IO_TYPE = 'UX' AND B.IO_VALUE = 99 THEN '+α'                                                     ");
		sql.append("	             ELSE CAST(B.IO_VALUE AS CHAR)                                                                           ");
		sql.append("	             END          										HANGMOG_VALUE                                        ");
		sql.append("	  FROM NUR1022 B                                                                                                     ");
		sql.append("	 WHERE B.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("	   AND B.YMD BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m/%d')    ");
		sql.append("	   AND B.FKINP1001 = :f_fkinp1001                                                                                    ");
		sql.append("	                                                                                                                     ");
//		sql.append("	/*UNION ALL                                                                                                          ");
//		sql.append("	SELECT C.FKINP1001 FKINP1001                                                                                         ");
//		sql.append("	       , DATEDIFF(C.YMD, STR_TO_DATE(:f_ymd, '%Y/%m/%d')) + 6 DIFF                                                    ");
//		sql.append("	       , C.PR_GUBUN HANGMOG_GUBUN                                                                                    ");
//		sql.append("	       , C.HANGMOG_SEQ                                                                                               ");
//		sql.append("	       , CASE WHEN C.PR_VALUE = 1 AND C.PR_GUBUN = 'BS' THEN 'Lo'                                                    ");
//		sql.append("	              WHEN C.PR_VALUE = 999 AND C.PR_GUBUN = 'BS' THEN 'Hi'                                                  ");
//		sql.append("	              WHEN C.PR_VALUE = 1 AND C.PR_GUBUN = 'SPO2' THEN '-'                                                   ");
//		sql.append("	              WHEN C.PR_VALUE < 1 THEN '0' || CAST(IFNULL(C.PR_VALUE, 0) AS CHAR)                                    ");
//		sql.append("	              ELSE CAST(IFNULL(C.PR_VALUE, 0) AS CHAR)                                                               ");
//		sql.append("	          END                                                                                                        ");
//		sql.append("	  FROM VW_NUR_NUR1020_LASTPART_3 C                                                                                   ");
//		sql.append("	 WHERE C.HOSP_CODE = :f_hosp_code                                                                                    ");
//		sql.append("	   AND C.YMD BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd, '%Y/%m%d')    ");
//		sql.append("	   AND C.FKINP1001 = :f_fkinp1001                                                                                    ");
//		sql.append("	   AND PR_GUBUN IN ('SPO2', 'O2', 'BS')*/                                                                            ");
		sql.append("	 ORDER BY 2, 3, 4                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020Q00layNUR7002Info> listData = new JpaResultMapper().list(query, NUR1020Q00layNUR7002Info.class);
		return listData;
	}

	@Override
	public List<NUR8003U03QueryFormGrdBPInfo> getNUR8003U03QueryFormGrdBPInfo(String hospCode, String bunho,
			Double fkinp1001, Date writeDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.YMD, A.TIME_GUBUN, A.PR_VALUE BPH, B.PR_VALUE BPL                                                                       ");
		sql.append("	FROM NUR1020 A                                                                                                                   ");
		sql.append("	   , NUR1020 B                                                                                                                   ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                                                 ");
		sql.append("	AND A.BUNHO = :f_bunho                                                                                                           ");
		sql.append("	AND A.FKINP1001 = :f_fkinp1001                                                                                                   ");
		sql.append("	AND A.PR_GUBUN = 'BPH'                                                                                                           ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                                                                                    ");
		sql.append("	AND B.BUNHO = A.BUNHO                                                                                                            ");
		sql.append("	AND B.FKINP1001 = A.FKINP1001                                                                                                    ");
		sql.append("	AND B.YMD = A.YMD                                                                                                                ");
		sql.append("	AND B.TIME_GUBUN = A.TIME_GUBUN                                                                                                  ");
		sql.append("	AND B.PR_GUBUN = 'BPL'                                                                                                           ");
		sql.append("	AND STR_TO_DATE(CONCAT(DATE_FORMAT(A.YMD,'%Y/%m/%d'),A.TIME_GUBUN),'%Y/%m/%d%H%i')                                               ");
		sql.append("	BETWEEN STR_TO_DATE(CONCAT(DATE_FORMAT(TIMESTAMPADD(day,-1,CAST(:f_write_date AS DATETIME)),'%Y/%m/%d'),'1400'),'%Y/%m/%d%H%i')  ");
		sql.append("	AND STR_TO_DATE(CONCAT(DATE_FORMAT(CAST(:f_write_date AS DATETIME),'%Y/%m/%d'),'1400'),'%Y/%m/%d%H%i')                           ");
		sql.append("	AND TRIM(A.PR_VALUE) IS NOT NULL                                                                                                 ");
		sql.append("	ORDER BY A.YMD,A.TIME_GUBUN                                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_write_date", writeDate);
		
		List<NUR8003U03QueryFormGrdBPInfo> listData = new JpaResultMapper().list(query, NUR8003U03QueryFormGrdBPInfo.class);
		return listData;
	}
}


