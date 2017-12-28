package nta.med.data.dao.medi.nut.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nut.Nut2010RepositoryCustom;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.nuts.NUT9001Q01grdListInfo;

/**
 * @author dainguyen.
 */
public class Nut2010RepositoryImpl implements Nut2010RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUT9001Q01grdListInfo> getNUT9001Q01grdListInfo(String hospCode, Date nutDate, String bldGubun,
			Double magamSeq, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CASE WHEN ( A.TRANS_FLAG1 != 'N') THEN '1' ELSE '0' END IP                                                                                                                              ");
		sql.append("	     , CASE WHEN ( A.TRANS_FLAG2 != 'N') THEN '1' ELSE '0' END TI                                                                                                                              ");
		sql.append("	     , CASE WHEN ( A.TRANS_FLAG3 != 'N') THEN '1' ELSE '0' END TN                                                                                                                              ");
		sql.append("	     , CASE WHEN ( A.TRANS_FLAG4 != 'N') THEN '1' ELSE '0' END TR                                                                                                                              ");
		sql.append("	     , '0' CA                                                                                                                                                                                  ");
		sql.append("	     , A.HOSP_CODE                                  AS HOSP_CODE                                                                                                                               ");
		sql.append("	     , A.BUNHO                                      AS BUNHO                                                                                                                                   ");
		sql.append("	     , IFNULL(A0.SUNAME, '')						AS SUNAME                                                                                                                                  ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.NUT_DATE, '%Y/%m/%d'), '')	AS NUT_DATE                                                                                                                            ");
		sql.append("	     , IFNULL(A.BLD_GUBUN, '')                      AS BLD_GUBUN                                                                                                                               ");
		sql.append("	     , IFNULL(A.HO_DONG, '')                        AS TO_HO_DONG                                                                                                                              ");
		sql.append("	     , IFNULL(A.HO_CODE, '')                        AS TO_HO_CODE                                                                                                                              ");
		sql.append("	     , IFNULL(N0.NUR_SO_NAME, '')                   AS TO_DIRECT_CODE_D                                                                                                                        ");
		sql.append("	     , IFNULL(N1.NUR_SO_NAME, '')                   AS TO_DIRECT_CODE1_D                                                                                                                       ");
		sql.append("	     , IFNULL(N2.NUR_SO_NAME, '')                   AS TO_DIRECT_CODE2_D                                                                                                                       ");
		sql.append("	     , IFNULL(N3.NUR_SO_NAME, '')                   AS TO_DIRECT_CODE3_D                                                                                                                       ");
		sql.append("	     , IFNULL(N4.NUR_SO_NAME, '')                   AS TO_NOMIMONO                                                                                                                             ");
		sql.append("	     , CASE                                                                                                                                                                                    ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '1' ) THEN IFNULL(A.JO_KUMJISIK, '')                                                                                                                             ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '2' ) THEN IFNULL(A.JU_KUMJISIK, '')                                                                                                                             ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '3' ) THEN IFNULL(A.SEOK_KUMJISIK, '')                                                                                                                           ");
		sql.append("	                                    ELSE ''                                                                                                                                                    ");
		sql.append("	       END                                          AS TO_KUMJISIK                                                                                                                             ");
		sql.append("	     , IFNULL(DATE_FORMAT(B.NUT_DATE, '%Y/%m/%d'), '')	AS FROM_NUT_DATE                                                                                                                       ");
		sql.append("	     , IFNULL(B.BLD_GUBUN, '')                      AS FROM_BLD_GUBUN                                                                                                                          ");
		sql.append("	     , IFNULL(B.HO_DONG, '')                        AS FROM_HO_DONG                                                                                                                            ");
		sql.append("	     , IFNULL(B.HO_CODE, '')                        AS FROM_HO_CODE                                                                                                                            ");
		sql.append("	     , IFNULL(N02.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE_D                                                                                                                      ");
		sql.append("	     , IFNULL(N12.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE1_D                                                                                                                     ");
		sql.append("	     , IFNULL(N22.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE2_D                                                                                                                     ");
		sql.append("	     , IFNULL(N32.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE3_D                                                                                                                     ");
		sql.append("	     , IFNULL(N42.NUR_SO_NAME, '')                  AS FROM_NOMIMONO                                                                                                                           ");
		sql.append("	     , CASE                                                                                                                                                                                    ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '1' ) THEN IFNULL(B.JO_KUMJISIK, '')                                                                                                                             ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '2' ) THEN IFNULL(B.JU_KUMJISIK, '')                                                                                                                             ");
		sql.append("	         WHEN ( A.BLD_GUBUN = '3' ) THEN IFNULL(B.SEOK_KUMJISIK, '')                                                                                                                           ");
		sql.append("	                                    ELSE ''                                                                                                                                                    ");
		sql.append("	       END                                          AS FROM_KUMJISIK                                                                                                                           ");
		sql.append("	  FROM NUT2010 A                                                                                                                                                                               ");
		sql.append("	  LEFT JOIN (                                                                                                                                                                                  ");
		sql.append("	          SELECT B.*                                                                                                                                                                           ");
		sql.append("	            FROM (                                                                                                                                                                             ");
		sql.append("	                SELECT A.*                                                                                                                                                                     ");
		sql.append("	                  FROM (                                                                                                                                                                       ");
		sql.append("	                        SELECT A.*                                                                                                                                                             ");
		sql.append("	                          FROM NUT2011         A                                                                                                                                               ");
		sql.append("	                         WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                                                  ");
		sql.append("	                           AND A.MAGAM_KEY     < ( SELECT Z.MAGAM_KEY                                                                                                                          ");
		sql.append("	                                                     FROM NUT2011       Z                                                                                                                      ");
		sql.append("	                                                    WHERE Z.HOSP_CODE   = :f_hosp_code                                                                                                         ");
		sql.append("	                                                      AND Z.NUT_DATE    = :f_nut_date                                                                                                          ");
		sql.append("	                                                      AND Z.BLD_GUBUN   = :f_bld_gubun                                                                                                         ");
		sql.append("	                                                      AND Z.MAGAM_SEQ   = :f_magam_seq                                                                                                         ");
		sql.append("	                                                 )                                                                                                                                             ");
		sql.append("	                         ORDER BY A.HOSP_CODE, A.MAGAM_KEY DESC                                                                                                                                ");
		sql.append("	                       )          A                                                                                                                                                            ");
		sql.append("	                 LIMIT 1                                                                                                                                                                       ");
		sql.append("	                ) A                                                                                                                                                                            ");
		sql.append("	                , NUT2010            B                                                                                                                                                         ");
		sql.append("	                WHERE     B.HOSP_CODE       = A.HOSP_CODE                                                                                                                                      ");
		sql.append("	                      AND B.NUT_DATE        = A.NUT_DATE                                                                                                                                       ");
		sql.append("	                      AND B.BLD_GUBUN       = A.BLD_GUBUN                                                                                                                                      ");
		sql.append("	                      AND B.MAGAM_SEQ       = A.MAGAM_SEQ                                                                                                                                      ");
		sql.append("	       ) B ON B.HOSP_CODE	= A.HOSP_CODE                                                                                                                                                      ");
		sql.append("			  AND B.BUNHO       = A.BUNHO                                                                                                                                                          ");
		sql.append("			  AND B.FKINP1001   = A.FKINP1001                                                                                                                                                      ");
		sql.append("	  JOIN OUT0101 A0 ON A0.HOSP_CODE	= A.HOSP_CODE                                                                                                                                              ");
		sql.append("					 AND A0.BUNHO       = A.BUNHO                                                                                                                                                  ");
		sql.append("	  LEFT JOIN NUR0112 N0 ON N0.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("						  AND N0.NUR_GR_CODE    = A.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("				          AND N0.NUR_MD_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE WHEN '2' THEN A.JU_DIRECT_CODE WHEN '3' THEN A.SEOK_DIRECT_CODE END)                            ");
		sql.append("						  AND N0.NUR_SO_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE_D WHEN '2' THEN A.JU_DIRECT_CODE_D WHEN '3' THEN A.SEOK_DIRECT_CODE_D END)                      ");
		sql.append("	  LEFT JOIN NUR0112 N1 ON N1.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("						  AND N1.NUR_GR_CODE    = A.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						  AND N1.NUR_MD_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE1 WHEN '2' THEN A.JU_DIRECT_CODE1 WHEN '3' THEN A.SEOK_DIRECT_CODE1 END)                         ");
		sql.append("						  AND N1.NUR_SO_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE1_D WHEN '2' THEN A.JU_DIRECT_CODE1_D WHEN '3' THEN A.SEOK_DIRECT_CODE1_D END)                   ");
		sql.append("	  LEFT JOIN NUR0112 N2 ON N2.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("					      AND N2.NUR_GR_CODE    = A.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("					      AND N2.NUR_MD_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE2 WHEN '2' THEN A.JU_DIRECT_CODE2 WHEN '3' THEN A.SEOK_DIRECT_CODE2 END)                         ");
		sql.append("					      AND N2.NUR_SO_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE2_D WHEN '2' THEN A.JU_DIRECT_CODE2_D WHEN '3' THEN A.SEOK_DIRECT_CODE2_D END)                   ");
		sql.append("	  LEFT JOIN NUR0112 N3 ON N3.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("						  AND N3.NUR_GR_CODE    = A.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						  AND N3.NUR_MD_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE3 WHEN '2' THEN A.JU_DIRECT_CODE3 WHEN '3' THEN A.SEOK_DIRECT_CODE3 END)                         ");
		sql.append("						  AND N3.NUR_SO_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_DIRECT_CODE3_D WHEN '2' THEN A.JU_DIRECT_CODE3_D WHEN '3' THEN A.SEOK_DIRECT_CODE3_D END)                   ");
		sql.append("	  LEFT JOIN NUR0112 N4 ON N4.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("						  AND N4.NUR_GR_CODE    = A.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						  AND N4.NUR_MD_CODE    = '0305'                                                                                                                                           ");
		sql.append("						  AND N4.NUR_SO_CODE    = (CASE A.BLD_GUBUN WHEN '1' THEN A.JO_NOMIMONO WHEN '2' THEN A.JU_NOMIMONO WHEN '3' THEN A.SEOK_NOMIMONO END)                                     ");
		sql.append("	  LEFT JOIN NUR0112 N02 ON N02.HOSP_CODE    = B.HOSP_CODE                                                                                                                                      ");
		sql.append("						   AND N02.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						   AND N02.NUR_MD_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE WHEN '2' THEN B.JU_DIRECT_CODE WHEN '3' THEN B.SEOK_DIRECT_CODE END)                           ");
		sql.append("						   AND N02.NUR_SO_CODE  = (CASE B.BLD_GUBUN WHEN '1' THEN B.JO_DIRECT_CODE_D WHEN '2' THEN B.JU_DIRECT_CODE_D WHEN '3' THEN B.SEOK_DIRECT_CODE_D END)                      ");
		sql.append("	  LEFT JOIN NUR0112 N12 ON N12.HOSP_CODE    = B.HOSP_CODE                                                                                                                                      ");
		sql.append("						   AND N12.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						   AND N12.NUR_MD_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE1 WHEN '2' THEN B.JU_DIRECT_CODE1 WHEN '3' THEN B.SEOK_DIRECT_CODE1 END)                        ");
		sql.append("						   AND N12.NUR_SO_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE1_D WHEN '2' THEN B.JU_DIRECT_CODE1_D WHEN '3' THEN B.SEOK_DIRECT_CODE1_D END)                  ");
		sql.append("	  LEFT JOIN NUR0112 N22 ON N22.HOSP_CODE    = B.HOSP_CODE                                                                                                                                      ");
		sql.append("						   AND N22.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						   AND N22.NUR_MD_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE2 WHEN '2' THEN B.JU_DIRECT_CODE2 WHEN '3' THEN B.SEOK_DIRECT_CODE2 END)                        ");
		sql.append("						   AND N22.NUR_SO_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE2_D WHEN '2' THEN B.JU_DIRECT_CODE2_D WHEN '3' THEN B.SEOK_DIRECT_CODE2_D END)                  ");
		sql.append("	  LEFT JOIN NUR0112 N32 ON N32.HOSP_CODE    = B.HOSP_CODE                                                                                                                                      ");
		sql.append("						   AND N32.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						   AND N32.NUR_MD_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE3 WHEN '2' THEN B.JU_DIRECT_CODE3 WHEN '3' THEN B.SEOK_DIRECT_CODE3 END)                        ");
		sql.append("						   AND N32.NUR_SO_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE3_D WHEN '2' THEN B.JU_DIRECT_CODE3_D WHEN '3' THEN B.SEOK_DIRECT_CODE3_D END)                  ");
		sql.append("	  LEFT JOIN NUR0112 N42 ON N42.HOSP_CODE    = B.HOSP_CODE                                                                                                                                      ");
		sql.append("						   AND N42.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                   ");
		sql.append("						   AND N42.NUR_MD_CODE  = '0305'                                                                                                                                           ");
		sql.append("						   AND N42.NUR_SO_CODE  = (CASE :f_bld_gubun WHEN '1' THEN B.JO_NOMIMONO WHEN '2' THEN B.JU_NOMIMONO WHEN '3' THEN B.SEOK_NOMIMONO END)                                    ");
		sql.append("	 WHERE A.HOSP_CODE       = :f_hosp_code                                                                                                                                                        ");
		sql.append("	   AND A.NUT_DATE        = :f_nut_date                                                                                                                                                         ");
		sql.append("	   AND A.BLD_GUBUN       = :f_bld_gubun                                                                                                                                                        ");
		sql.append("	   AND A.MAGAM_SEQ       = :f_magam_seq                                                                                                                                                        ");
		sql.append("	   AND A.HO_DONG         LIKE :f_ho_dong                                                                                                                                                       ");
		sql.append("	                                                                                                                                                                                               ");
		sql.append("	UNION ALL                                                                                                                                                                                      ");
		sql.append("	SELECT                                                                                                                                                                                         ");
		sql.append("	       '0' IP                                                                                                                                                                                  ");
		sql.append("	     , '0' TI                                                                                                                                                                                  ");
		sql.append("	     , '0' TN                                                                                                                                                                                  ");
		sql.append("	     , '0' TR                                                                                                                                                                                  ");
		sql.append("	     , '1' CA                                                                                                                                                                                  ");
		sql.append("	     , B.HOSP_CODE                                  AS HOSP_CODE                                                                                                                               ");
		sql.append("	     , B.BUNHO                                      AS BUNHO                                                                                                                                   ");
		sql.append("	     , IFNULL(A0.SUNAME, '')						AS SUNAME                                                                                                                                  ");
		sql.append("	     , IFNULL(DATE_FORMAT(:f_nut_date, '%Y/%m/%d'), '')	AS NUT_DATE                                                                                                                            ");
		sql.append("	     , :f_bld_gubun                                 AS BLD_GUBUN                                                                                                                               ");
		sql.append("	     , ''                                    		AS TO_HO_DONG                                                                                                                              ");
		sql.append("	     , ''                                    		AS TO_HO_CODE                                                                                                                              ");
		sql.append("	     , ''                               			AS TO_DIRECT_CODE_D                                                                                                                        ");
		sql.append("	     , ''                               			AS TO_DIRECT_CODE1_D                                                                                                                       ");
		sql.append("	     , ''                               			AS TO_DIRECT_CODE2_D                                                                                                                       ");
		sql.append("	     , ''                               			AS TO_DIRECT_CODE3_D                                                                                                                       ");
		sql.append("	     , ''                               			AS TO_NOMIMONO                                                                                                                             ");
		sql.append("	     , ''                               			AS TO_KUMJISIK                                                                                                                             ");
		sql.append("	     , IFNULL(DATE_FORMAT(B.NUT_DATE, '%Y/%m/%d'), '')	AS FROM_NUT_DATE                                                                                                                       ");
		sql.append("	     , IFNULL(B.BLD_GUBUN, '')                      AS FROM_BLD_GUBUN                                                                                                                          ");
		sql.append("	     , IFNULL(B.HO_DONG, '')                        AS FROM_HO_DONG                                                                                                                            ");
		sql.append("	     , IFNULL(B.HO_CODE, '')                        AS FROM_HO_CODE                                                                                                                            ");
		sql.append("	     , IFNULL(N02.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE_D                                                                                                                      ");
		sql.append("	     , IFNULL(N12.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE1_D                                                                                                                     ");
		sql.append("	     , IFNULL(N22.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE2_D                                                                                                                     ");
		sql.append("	     , IFNULL(N32.NUR_SO_NAME, '')                  AS FROM_DIRECT_CODE3_D                                                                                                                     ");
		sql.append("	     , IFNULL(N42.NUR_SO_NAME, '')                  AS FROM_NOMIMONO                                                                                                                           ");
		sql.append("	     , CASE                                                                                                                                                                                    ");
		sql.append("	         WHEN ( :f_bld_gubun = '1' ) THEN IFNULL(B.JO_KUMJISIK, '')                                                                                                                            ");
		sql.append("	         WHEN ( :f_bld_gubun = '2' ) THEN IFNULL(B.JU_KUMJISIK, '')                                                                                                                            ");
		sql.append("	         WHEN ( :f_bld_gubun = '3' ) THEN IFNULL(B.SEOK_KUMJISIK, '')                                                                                                                          ");
		sql.append("	                                    ELSE ''                                                                                                                                                    ");
		sql.append("	       END                                          AS FROM_KUMJISIK                                                                                                                           ");
		sql.append("	  FROM                                                                                                                                                                                         ");
		sql.append("	       (                                                                                                                                                                                       ");
		sql.append("	        SELECT A.*                                                                                                                                                                             ");
		sql.append("	          FROM (                                                                                                                                                                               ");
		sql.append("	                SELECT A.*                                                                                                                                                                     ");
		sql.append("	                  FROM NUT2011         A                                                                                                                                                       ");
		sql.append("	                 WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                                                          ");
		sql.append("	                   AND A.MAGAM_KEY     < ( SELECT Z.MAGAM_KEY                                                                                                                                  ");
		sql.append("	                                             FROM NUT2011       Z                                                                                                                              ");
		sql.append("	                                            WHERE Z.HOSP_CODE   = :f_hosp_code                                                                                                                 ");
		sql.append("	                                              AND Z.NUT_DATE    = :f_nut_date                                                                                                                  ");
		sql.append("	                                              AND Z.BLD_GUBUN   = :f_bld_gubun                                                                                                                 ");
		sql.append("	                                              AND Z.MAGAM_SEQ   = :f_magam_seq                                                                                                                 ");
		sql.append("	                                         )                                                                                                                                                     ");
		sql.append("	                 ORDER BY A.HOSP_CODE, A.MAGAM_KEY DESC                                                                                                                                        ");
		sql.append("	               )          A                                                                                                                                                                    ");
		sql.append("	         LIMIT 1                                                                                                                                                                               ");
		sql.append("	       )                  C                                                                                                                                                                    ");
		sql.append("	  JOIN NUT2010            B  ON B.HOSP_CODE   = C.HOSP_CODE                                                                                                                                    ");
		sql.append("							    AND B.NUT_DATE    = C.NUT_DATE                                                                                                                                     ");
		sql.append("							    AND B.BLD_GUBUN   = C.BLD_GUBUN                                                                                                                                    ");
		sql.append("							    AND B.MAGAM_SEQ   = C.MAGAM_SEQ                                                                                                                                    ");
		sql.append("	  JOIN OUT0101            A0 ON A0.HOSP_CODE  = B.HOSP_CODE                                                                                                                                    ");
		sql.append("							    AND A0.BUNHO      = B.BUNHO                                                                                                                                        ");
		sql.append("	  LEFT JOIN NUR0112 N02 ON N02.HOSP_CODE      = B.HOSP_CODE                                                                                                                                    ");
		sql.append("						   AND N02.NUR_GR_CODE    = B.DIRECT_GUBUN                                                                                                                                 ");
		sql.append("						   AND N02.NUR_MD_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE WHEN '2' THEN B.JU_DIRECT_CODE WHEN '3' THEN B.SEOK_DIRECT_CODE END)                         ");
		sql.append("						   AND N02.NUR_SO_CODE    = (CASE B.BLD_GUBUN WHEN '1' THEN B.JO_DIRECT_CODE_D WHEN '2' THEN B.JU_DIRECT_CODE_D WHEN '3' THEN B.SEOK_DIRECT_CODE_D END)                    ");
		sql.append("	  LEFT JOIN NUR0112 N12 ON N12.HOSP_CODE      = B.HOSP_CODE                                                                                                                                    ");
		sql.append("						   AND N12.NUR_GR_CODE    = B.DIRECT_GUBUN                                                                                                                                 ");
		sql.append("						   AND N12.NUR_MD_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE1 WHEN '2' THEN B.JU_DIRECT_CODE1 WHEN '3' THEN B.SEOK_DIRECT_CODE1 END)                      ");
		sql.append("						   AND N12.NUR_SO_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE1_D WHEN '2' THEN B.JU_DIRECT_CODE1_D WHEN '3' THEN B.SEOK_DIRECT_CODE1_D END)                ");
		sql.append("	  LEFT JOIN NUR0112 N22 ON N22.HOSP_CODE      = B.HOSP_CODE                                                                                                                                    ");
		sql.append("						   AND N22.NUR_GR_CODE    = B.DIRECT_GUBUN                                                                                                                                 ");
		sql.append("						   AND N22.NUR_MD_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE2 WHEN '2' THEN B.JU_DIRECT_CODE2 WHEN '3' THEN B.SEOK_DIRECT_CODE2 END)                      ");
		sql.append("						   AND N22.NUR_SO_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE2_D WHEN '2' THEN B.JU_DIRECT_CODE2_D WHEN '3' THEN B.SEOK_DIRECT_CODE2_D END)                ");
		sql.append("	  LEFT JOIN NUR0112 N32 ON N32.HOSP_CODE      = B.HOSP_CODE                                                                                                                                    ");
		sql.append("						   AND N32.NUR_GR_CODE    = B.DIRECT_GUBUN                                                                                                                                 ");
		sql.append("						   AND N32.NUR_MD_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE3 WHEN '2' THEN B.JU_DIRECT_CODE3 WHEN '3' THEN B.SEOK_DIRECT_CODE3 END)                      ");
		sql.append("						   AND N32.NUR_SO_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_DIRECT_CODE3_D WHEN '2' THEN B.JU_DIRECT_CODE3_D WHEN '3' THEN B.SEOK_DIRECT_CODE3_D END)                ");
		sql.append("	  LEFT JOIN NUR0112 N42 ON N42.HOSP_CODE      = B.HOSP_CODE                                                                                                                                    ");
		sql.append("						   AND N42.NUR_GR_CODE    = B.DIRECT_GUBUN                                                                                                                                 ");
		sql.append("						   AND N42.NUR_MD_CODE    = '0305'                                                                                                                                         ");
		sql.append("						   AND N42.NUR_SO_CODE    = (CASE :f_bld_gubun WHEN '1' THEN B.JO_NOMIMONO WHEN '2' THEN B.JU_NOMIMONO WHEN '3' THEN B.SEOK_NOMIMONO END)                                  ");
		sql.append("	 WHERE NOT EXISTS ( SELECT NULL                                                                                                                                                                ");
		sql.append("	                             FROM NUT2010           Z                                                                                                                                          ");
		sql.append("	                            WHERE Z.HOSP_CODE       = :f_hosp_code                                                                                                                             ");
		sql.append("	                              AND Z.BUNHO           = B.BUNHO                                                                                                                                  ");
		sql.append("	                              AND Z.FKINP1001       = B.FKINP1001                                                                                                                              ");
		sql.append("	                              AND Z.NUT_DATE        = :f_nut_date                                                                                                                              ");
		sql.append("	                              AND Z.BLD_GUBUN       = :f_bld_gubun                                                                                                                             ");
		sql.append("	                              AND Z.MAGAM_SEQ       = :f_magam_seq                                                                                                                             ");
		sql.append("	                              AND Z.HO_DONG         LIKE :f_ho_dong                                                                                                                            ");
		sql.append("	                   )                                                                                                                                                                           ");
		sql.append("	 ORDER BY 2, 7, 8                                                                                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nut_date", nutDate);
		query.setParameter("f_bld_gubun", bldGubun);
		query.setParameter("f_magam_seq", magamSeq);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUT9001Q01grdListInfo> lstResult = new JpaResultMapper().list(query, NUT9001Q01grdListInfo.class);
		return lstResult;
	}

	@Override
	public CommonProcResultInfo callPrNutMagam(String hospCode, String updId, Date magamDate, String bldGubun,
			String nutMagamGubun) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUT_MAGAM");
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BLD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NUT_MAGAM_GUBUN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_FKNUT2011", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_MAGAM_SEQ", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_UPD_ID", updId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_MAGAM_DATE", magamDate);
		query.setParameter("I_BLD_GUBUN", bldGubun);
		query.setParameter("I_NUT_MAGAM_GUBUN", nutMagamGubun);
		
		query.execute();
		
		Double fknut2011 = (Double)query.getOutputParameterValue("O_FKNUT2011");
		Double magamSeq = (Double)query.getOutputParameterValue("O_MAGAM_SEQ");
		String flag = (String)query.getOutputParameterValue("O_FLAG");
		
		CommonProcResultInfo pInfo = new CommonProcResultInfo();
		pInfo.setStrResult1(fknut2011 == null ? "" : String.format("%.0f",fknut2011));
		pInfo.setStrResult2(magamSeq == null ? "" : String.format("%.0f",magamSeq));
		pInfo.setStrResult3(flag == null ? "" : flag);
		
		return pInfo;
	}

	@Override
	public CommonProcResultInfo callPrIfsNutProcMain(String hospCode, Double masterFk, String sendYn) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_NUT_PROC_MAIN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MASTER_FK", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEND_YN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_CNT", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_MASTER_FK", masterFk);
		query.setParameter("I_SEND_YN", sendYn);
		
		query.execute();
		Double cnt = (Double)query.getOutputParameterValue("O_CNT");
		String flag = (String)query.getOutputParameterValue("O_FLAG");
		String msg = (String)query.getOutputParameterValue("O_MSG");
		
		CommonProcResultInfo pInfo = new CommonProcResultInfo();
		pInfo.setStrResult1(cnt == null ? "" : String.format("%.0f",cnt));
		pInfo.setStrResult2(flag == null ? "" : flag);
		pInfo.setStrResult3(msg == null ? "" : msg);
		
		return pInfo;
	}
}
