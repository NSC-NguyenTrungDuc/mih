package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur7002RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1020U00layNUR7002Info;
import nta.med.data.model.ihis.nuri.NUR1020U00layWriterBAInfo;

/**
 * @author dainguyen.
 */
public class Nur7002RepositoryImpl implements Nur7002RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1020U00layNUR7002Info> getNUR1020U00layNUR7002Info(String hospCode, Date ymd, String bunho,
			Double fkinp1001) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT                                                                                                                                                   ");
		sql.append("	        IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'SYO',  HANGMOG_VALUE, '')), '') SYO                                                                             ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'AS' ,  HANGMOG_VALUE, '')), '') DUNG_SYO                                                                        ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'AX' ,  HANGMOG_VALUE, '')), '') DUNG_CNT                                                                        ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'UT' ,  HANGMOG_VALUE, '')), '') URINE_QUANTITY                                                                  ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'UX' ,  HANGMOG_VALUE, '')), '') URINE_CNT                                                                       ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'HEIGHT' ,  HANGMOG_VALUE, '')), '') HEIGHT                                                                      ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'WEIGHT' ,  HANGMOG_VALUE, '')), '') WEIGHT                                                                      ");
		sql.append("	      , IFNULL(MAX(IF(A.HANGMOG_GUBUN = 'CARE'   ,  HANGMOG_VALUE, '')), '') CARE                                                                        ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 1, HANGMOG_VALUE, ''))), '') 										WRITER_ID_1  ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 1, FN_ADM_LOAD_USER_NAME(HANGMOG_VALUE, :f_hosp_code), ''))), '') 	WRITER_NM_1  ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 2, HANGMOG_VALUE, ''))), '') 										WRITER_ID_2  ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 2, FN_ADM_LOAD_USER_NAME(HANGMOG_VALUE, :f_hosp_code), ''))), '') 	WRITER_NM_2  ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 3, HANGMOG_VALUE, ''))), '') 										WRITER_ID_3  ");
		sql.append("	      , IFNULL(MIN(IFNULL(A.HANGMOG_GUBUN = 'WRITER', IF(A.HANGMOG_SEQ = 3, FN_ADM_LOAD_USER_NAME(HANGMOG_VALUE, :f_hosp_code), ''))), '') 	WRITER_NM_3  ");
		sql.append("	FROM                                                                                                                                                     ");
		sql.append("	  (SELECT A.BUNHO                   	BUNHO                                                                                                            ");
		sql.append("	         , A.FKINP1001              	FKINP1001                                                                                                        ");
		sql.append("	         , A.YMD                    	YMD                                                                                                              ");
		sql.append("	         , A.HANGMOG_GUBUN          	HANGMOG_GUBUN                                                                                                    ");
		sql.append("	         , CAST(A.HANGMOG_SEQ AS CHAR)  HANGMOG_SEQ                                                                                                      ");
		sql.append("	         , A.HANGMOG_VALUE          	HANGMOG_VALUE                                                                                                    ");
		sql.append("	    FROM NUR7002 A                                                                                                                                       ");
		sql.append("	   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                      ");
		sql.append("	     AND A.YMD       = :f_ymd                                                                                                                            ");
		sql.append("	     AND A.BUNHO     = :f_bunho                                                                                                                          ");
		sql.append("	     AND A.FKINP1001 = :f_fkinp1001                                                                                                                      ");
		sql.append("	  UNION                                                                                                                                                  ");
		sql.append("	  SELECT B.BUNHO                	 BUNHO                                                                                                               ");
		sql.append("	         , B.FKINP1001          	 FKINP1001                                                                                                           ");
		sql.append("	         , B.YMD                	 YMD                                                                                                                 ");
		sql.append("	         , B.IO_TYPE            	 HANGMOG_GUBUN                                                                                                       ");
		sql.append("	         , '1'                  	 HANGMOG_SEQ                                                                                                         ");
		sql.append("	         , CAST(B.IO_VALUE AS CHAR)  HANGMOG_VALUE                                                                                                       ");
		sql.append("	    FROM NUR1022 B                                                                                                                                       ");
		sql.append("	   WHERE B.HOSP_CODE = :f_hosp_code                                                                                                                      ");
		sql.append("	     AND B.YMD       = :f_ymd                                                                                                                            ");
		sql.append("	     AND B.BUNHO     = :f_bunho                                                                                                                          ");
		sql.append("	     AND B.FKINP1001 = :f_fkinp1001) A                                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ymd", ymd);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR1020U00layNUR7002Info> lstResult = new JpaResultMapper().list(query, NUR1020U00layNUR7002Info.class);
		return lstResult;		
	}

	@Override
	public List<NUR1020U00layWriterBAInfo> getNUR1020U00layWriterBAInfo(String hospCode, String ymd, String bunho,
			Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKINP1001                                                                                   ");
		sql.append("	     , A.YMD                                                                                         ");
		sql.append("	     , A.HANGMOG_GUBUN                                                                               ");
		sql.append("	     , A.HANGMOG_SEQ                                                                                 ");
		sql.append("	     , A.HANGMOG_VALUE                                                                               ");
		sql.append("	  FROM NUR7002 A                                                                                     ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code                                                                      ");
		sql.append("	   AND FKINP1001 = :f_fkinp1001                                                                      ");
		sql.append("	   AND BUNHO     = :f_bunho                                                                          ");
		sql.append("	   AND HANGMOG_GUBUN = 'WRITER'                                                                      ");
		sql.append("	   AND ( YMD = DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL -1 DAY) AND HANGMOG_SEQ = 3        ");
		sql.append("	      OR YMD = DATE_ADD(STR_TO_DATE(:f_ymd, '%Y/%m/%d'), INTERVAL 1 DAY)  AND HANGMOG_SEQ = 1)       ");
		sql.append("	 ORDER BY SYS_DATE DESC                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ymd", ymd);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR1020U00layWriterBAInfo> lstResult = new JpaResultMapper().list(query, NUR1020U00layWriterBAInfo.class);
		return lstResult;
	}
}
