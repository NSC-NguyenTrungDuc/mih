package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5022RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00layNur5020Info;
import nta.med.data.model.ihis.nuri.NUR5020U00layNurCntInfo;

/**
 * @author dainguyen.
 */
public class Nur5022RepositoryImpl implements Nur5022RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR5020U00layNurCntInfo> getNUR5020U00layNurCntInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				"	SELECT  FN_NUR_LOAD_CODE_NAME('NURSE_GRADE',B.CODE,:f_hosp_code, :f_language) NURSE_GRADE_NAME ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '01' THEN 1 END)           EARLY_CNT                       ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '02' THEN 1 END)           DAY_CNT                         ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '03' THEN 1 END)           LATE_CNT                        ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '04' THEN 1 END)           NIGHT_CNT                       ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '05' THEN 1 END)           HOLY_CNT                        ");
		sql.append(
				"	      , COUNT(CASE A.WORK_TYPE WHEN '06' THEN 1 END)           VAC_CNT                         ");
		sql.append(
				"	FROM NUR0102 B                                                                                 ");
		sql.append(
				"	LEFT OUTER JOIN NUR5022 A ON A.HOSP_CODE   = B.HOSP_CODE                                       ");
		sql.append(
				"	                         AND A.NURSE_GRADE = B.CODE                                            ");
		sql.append(
				"	WHERE B.HOSP_CODE      = :f_hosp_code                                                          ");
		sql.append(
				"	  AND B.CODE_TYPE      = 'NURSE_GRADE'                                                         ");
		sql.append(
				"	GROUP BY B.CODE                                                                                ");
		sql.append(
				"	ORDER BY B.CODE                                                                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		List<NUR5020U00layNurCntInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layNurCntInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00layNur5020Info> getNUR5020U00layNur5020Info(String hospCode, String language, String hoDong,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT YESTERDAY_CNT                                                                     ");
		sql.append("	     , IPWON_CNT                                                                         ");
		sql.append("	     , TOIWON_CNT                                                                        ");
		sql.append("	     , JAEWON_CNT                                                                        ");
		sql.append("	     , MOVE_OUT_CNT                                                                      ");
		sql.append("	     , MOVE_IN_CNT                                                                       ");
		sql.append("	     , GAMYUM1_CNT                                                                       ");
		sql.append("	     , GAMYUM2_CNT                                                                       ");
		sql.append("	     , GAMYUM3_CNT                                                                       ");
		sql.append("	     , GAMYUM4_CNT                                                                       ");
		sql.append("	     , GAMYUM5_CNT                                                                       ");
		sql.append("	     , GAMYUM6_CNT                                                                       ");
		sql.append("	     , GAMYUM7_CNT                                                                       ");
		sql.append("	     , GAMYUM8_CNT                                                                       ");
		sql.append("	     , GAMYUM6_NAME                                                                      ");
		sql.append("	     , GAMYUM7_NAME                                                                      ");
		sql.append("	     , GAMYUM8_NAME                                                                      ");
		sql.append("	     , YOKCHANG_NURSE                                                                    ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(YOKCHANG_NURSE, :f_hosp_code)                               ");
		sql.append("	     , IFNULL(YOKCHANG_COMMENT, '')                                                      ");
		sql.append("	     , NUR_WRDT                                                                          ");
		sql.append("	     , IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', NUR_WRDT, :f_hosp_code, :f_language), '')");
		sql.append("	     , HO_DONG                                                                           ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_HO_DONG_NAME(HO_DONG, NUR_WRDT, :f_hosp_code, :f_language), '')");
		sql.append("	  FROM NUR5020                                                                           ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code                                                          ");
		sql.append("	   AND HO_DONG   = :f_ho_dong                                                            ");
		sql.append("	   AND NUR_WRDT  = :f_date                                                               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);

		List<NUR5020U00layNur5020Info> listInfo = new JpaResultMapper().list(query, NUR5020U00layNur5020Info.class);
		return listInfo;
	}

}
