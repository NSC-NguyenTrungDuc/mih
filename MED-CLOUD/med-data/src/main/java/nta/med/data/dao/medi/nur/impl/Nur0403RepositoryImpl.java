package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0403RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0401U01GrdNur0403Info;
import nta.med.data.model.ihis.nuri.NUR4001U00LayPlanQueryStartInfo;

/**
 * @author dainguyen.
 */
public class Nur0403RepositoryImpl implements Nur0403RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR0401U01GrdNur0403Info> getNUR0401U01GrdNur0403Info(String hospCode, String nurPlanJin,
			String nurPlanOte, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT NUR_PLAN_JIN,                                  ");
		sql.append("	       IFNULL(NUR_PLAN_PRO, ''),                      ");
		sql.append("	       IFNULL(CAST(NUR_PLAN AS CHAR), ''),			  ");
		sql.append("	       FROM_DATE,                                     ");
		sql.append("	       END_DATE,                                      ");
		sql.append("	       NUR_PLAN_NAME,                                 ");
		sql.append("	       NUR_PLAN_OTE,                                  ");
		sql.append("	       CAST(IFNULL(SORT_KEY, 99) AS CHAR) 	SORT_KEY, ");
		sql.append("	       IFNULL(VALD,'N')         			VALD      ");
		sql.append("	  FROM NUR0403                                        ");
		sql.append("	 WHERE HOSP_CODE      = :f_hosp_code                  ");
		sql.append("	   AND NUR_PLAN_JIN   = :f_nur_plan_jin               ");
		sql.append("	   AND NUR_PLAN_OTE   = :f_nur_plan_ote               ");
		sql.append("	 ORDER BY IFNULL(SORT_KEY, 99), NUR_PLAN              ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset							  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_plan_jin", nurPlanJin);
		query.setParameter("f_nur_plan_ote", nurPlanOte);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0401U01GrdNur0403Info> lstResult = new JpaResultMapper().list(query, NUR0401U01GrdNur0403Info.class);
		return lstResult;	
	}

	@Override
	public Integer deleteNUR0403InNUR0401U01(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE FROM NUR0403                                             ");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code                               ");
		sql.append("	  AND NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN                    ");
		sql.append("	                          FROM NUR0401 B                        ");
		sql.append("	                         WHERE B.HOSP_CODE       = :f_hosp_code ");
		sql.append("	                           AND B.NUR_PLAN_BUNRYU = :f_code)     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		return query.executeUpdate();
	}

	@Override
	public List<NUR4001U00LayPlanQueryStartInfo> getNUR4001U00LayPlanQueryStartInfoCase1(String hospCode,
			String nurPlanJin, Double fknur4001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(:f_fknur4001 AS CHAR)                 FKNUR4001,   				 ");
		sql.append("		   '0'                                        PKNUR4003,                 ");
		sql.append("		   A.NUR_PLAN_OTE                             NUR_PLAN_OTE,              ");
		sql.append("		   A.NUR_PLAN                                 NUR_PLAN,                  ");
		sql.append("		   IFNULL(A.NUR_PLAN_NAME, '')                NUR_PLAN_NAME,             ");
		sql.append("		   'Y'                                        NUR4003_VALD,              ");
		sql.append("		   '0'                                        PKNUR4004,                 ");
		sql.append("		   IFNULL(B.NUR_PLAN_DETAIL, 'X')             NUR_PLAN_DETAIL,           ");
		sql.append("		   IFNULL(B.NUR_PLAN_DENAME, '')              NUR_PLAN_DENAME,           ");
		sql.append("		   IFNULL(B.VALD, '')                         NUR4004_VALD,              ");
		sql.append("		   CASE A.NUR_PLAN_OTE                                                   ");
		sql.append("			WHEN 'P' THEN '1'                                                    ");
		sql.append("			WHEN 'O' THEN '2'                                                    ");
		sql.append("			WHEN 'T' THEN '3'                                                    ");
		sql.append("		   ELSE '4' END             				  NUR_SORT1,                 ");
		sql.append("		   LPAD(IFNULL(A.SORT_KEY, 99), 2, '0')  	  NUR_SORT2,                 ");
		sql.append("		   LPAD(IFNULL(B.SORT_KEY, 99), 2, '0')  	  NUR_SORT3                  ");
		sql.append("	  FROM NUR0403 A                                                             ");
		sql.append("	  LEFT JOIN NUR0404 B ON B.HOSP_CODE 	= A.HOSP_CODE                        ");
		sql.append("	          					 AND B.NUR_PLAN_JIN	= A.NUR_PLAN_JIN             ");
		sql.append("	          					 AND B.NUR_PLAN     = A.NUR_PLAN                 ");
		sql.append("	          					 AND B.VALD         = 'Y'                        ");
		sql.append("	 WHERE A.HOSP_CODE		= :f_hosp_code                                       ");
		sql.append("	   AND A.NUR_PLAN_JIN   = :f_nur_plan_jin                                    ");
		sql.append("	   AND A.FROM_DATE                                      	    <= SYSDATE() ");
		sql.append("	   AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))  	>= SYSDATE() ");
		sql.append("	   AND A.VALD          	= 'Y'                                                ");
		sql.append("	 ORDER BY NUR_SORT1, NUR_SORT2, NUR_SORT3                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_plan_jin", nurPlanJin);
		query.setParameter("f_fknur4001", fknur4001);
		
		List<NUR4001U00LayPlanQueryStartInfo> lstResult = new JpaResultMapper().list(query, NUR4001U00LayPlanQueryStartInfo.class);
		return lstResult;
	}

	@Override
	public List<NUR4001U00LayPlanQueryStartInfo> getNUR4001U00LayPlanQueryStartInfoCase2(String hospCode,
			Double fknur4001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.FKNUR4001 AS CHAR)                  FKNUR4001,        ");
		sql.append("		   CAST(A.PKNUR4003 AS CHAR)                  PKNUR4003,        ");
		sql.append("		   A.NUR_PLAN_OTE                             NUR_PLAN_OTE,     ");
		sql.append("		   A.NUR_PLAN                                 NUR_PLAN,         ");
		sql.append("		   A.NUR_PLAN_NAME                            NUR_PLAN_NAME,    ");
		sql.append("		   A.VALD                                     NUR4003_VALD,     ");
		sql.append("		   IFNULL(CAST(B.PKNUR4004 AS CHAR), '')      PKNUR4004,        ");
		sql.append("		   IFNULL(B.NUR_PLAN_DETAIL, 'X')             NUR_PLAN_DETAIL,  ");
		sql.append("		   IFNULL(B.NUR_PLAN_DENAME, '')              NUR_PLAN_DENAME,  ");
		sql.append("		   IFNULL(B.VALD, '')                         NUR4004_VALD,     ");
		sql.append("		   CASE A.NUR_PLAN_OTE                                          ");
		sql.append("			WHEN 'P' THEN '1'                                           ");
		sql.append("			WHEN 'O'                                                    ");
		sql.append("			THEN '2'                                                    ");
		sql.append("			WHEN 'T'                                                    ");
		sql.append("			THEN '3' ELSE '4' END               	  NUR_SORT1,        ");
		sql.append("		   LPAD(IFNULL(A.SORT_KEY, 99), 2, '0')  	  NUR_SORT2,        ");
		sql.append("		   LPAD(IFNULL(B.SORT_KEY, 99), 2, '0')  	  NUR_SORT3         ");
		sql.append("	  FROM NUR4003 A                                                    ");
		sql.append("	  LEFT JOIN NUR4004 B ON B.HOSP_CODE	= A.HOSP_CODE               ");
		sql.append("						 AND B.FKNUR4003	= A.PKNUR4003               ");
		sql.append("	 WHERE A.HOSP_CODE	= :f_hosp_code                                  ");
		sql.append("	   AND A.FKNUR4001  = :f_fknur4001                                  ");
		sql.append("	 ORDER BY NUR_SORT1, NUR_SORT2, NUR_SORT3                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknur4001", fknur4001);
		
		List<NUR4001U00LayPlanQueryStartInfo> lstResult = new JpaResultMapper().list(query,
				NUR4001U00LayPlanQueryStartInfo.class);
		return lstResult;
	}

}
