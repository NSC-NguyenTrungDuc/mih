package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur8003RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR8003Q00grdNur8003Info;
import nta.med.data.model.ihis.nuri.NUR8003Q00grdWritedInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03CopyDataInfo;

/**
 * @author dainguyen.
 */
public class Nur8003RepositoryImpl implements Nur8003RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR8003Q00grdWritedInfo> getNUR8003Q00grdWritedInfo1(String hospCode, String date, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT X.BUNHO                                                                                                                      ");
		sql.append("        , X.SUNAME                                                                                                                     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  0 DAY)) AS \"01\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  1 DAY)) AS \"02\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  2 DAY)) AS \"03\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  3 DAY)) AS \"04\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  4 DAY)) AS \"05\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  5 DAY)) AS \"06\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  6 DAY)) AS \"07\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  7 DAY)) AS \"08\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  8 DAY)) AS \"09\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  9 DAY)) AS \"10\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 10 DAY)) AS \"11\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 11 DAY)) AS \"12\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 12 DAY)) AS \"13\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 13 DAY)) AS \"14\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 14 DAY)) AS \"15\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 15 DAY)) AS \"16\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 16 DAY)) AS \"17\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 17 DAY)) AS \"18\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 18 DAY)) AS \"19\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 19 DAY)) AS \"20\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 20 DAY)) AS \"21\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 21 DAY)) AS \"22\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 22 DAY)) AS \"23\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 23 DAY)) AS \"24\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 24 DAY)) AS \"25\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 25 DAY)) AS \"26\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 26 DAY)) AS \"27\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 27 DAY)) AS \"28\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 28 DAY)) AS \"29\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 29 DAY)) AS \"30\"     ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_WRITED(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 30 DAY)) AS \"31\"     ");
		sql.append("   FROM                                                                                                                                ");
		sql.append("   (SELECT A.HOSP_CODE                                                                                                                 ");
		sql.append("         , B.SUNAME                                                                                                                    ");
		sql.append("         , A.BUNHO                                                                                                                     ");
		sql.append("     FROM NUR8003 A                                                                                                                    ");
		sql.append("     JOIN OUT0101 B                                                                                                                    ");
		sql.append("       ON B.HOSP_CODE    = A.HOSP_CODE                                                                                                 ");
		sql.append("      AND B.BUNHO        = A.BUNHO                                                                                                     ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                ");
		sql.append("      AND A.WRITE_HODONG = :f_ho_dong                                                                                                  ");
		sql.append("      AND A.WRITE_DATE BETWEEN STR_TO_DATE(:f_date, '%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date, '%Y%m%d'))                         	   ");
		sql.append("    GROUP BY A.HOSP_CODE, A.BUNHO, B.SUNAME) X                                                                                         ");
		sql.append("    ORDER BY X.BUNHO                                                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date + "01");
		
		List<NUR8003Q00grdWritedInfo> listInfo = new JpaResultMapper().list(query, NUR8003Q00grdWritedInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR8003Q00grdWritedInfo> getNUR8003Q00grdWritedInfo2(String hospCode, String date, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT X.BUNHO																																	 ");
		sql.append("       , X.SUNAME                                                                                                                                    ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  0 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  0 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  0 DAY), X.WRITE_HODONG, 'C')) AS \"01\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  1 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  1 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  1 DAY), X.WRITE_HODONG, 'C')) AS \"02\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  2 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  2 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  2 DAY), X.WRITE_HODONG, 'C')) AS \"03\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  3 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  3 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  3 DAY), X.WRITE_HODONG, 'C')) AS \"04\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  4 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  4 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  4 DAY), X.WRITE_HODONG, 'C')) AS \"05\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  5 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  5 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  5 DAY), X.WRITE_HODONG, 'C')) AS \"06\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  6 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  6 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  6 DAY), X.WRITE_HODONG, 'C')) AS \"07\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  7 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  7 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  7 DAY), X.WRITE_HODONG, 'C')) AS \"08\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  8 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  8 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  8 DAY), X.WRITE_HODONG, 'C')) AS \"09\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  9 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  9 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL  9 DAY), X.WRITE_HODONG, 'C')) AS \"10\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 10 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 10 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 10 DAY), X.WRITE_HODONG, 'C')) AS \"11\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 11 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 11 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 11 DAY), X.WRITE_HODONG, 'C')) AS \"12\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 12 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 12 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 12 DAY), X.WRITE_HODONG, 'C')) AS \"13\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 13 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 13 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 13 DAY), X.WRITE_HODONG, 'C')) AS \"14\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 14 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 14 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 14 DAY), X.WRITE_HODONG, 'C')) AS \"15\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 15 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 15 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 15 DAY), X.WRITE_HODONG, 'C')) AS \"16\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 16 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 16 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 16 DAY), X.WRITE_HODONG, 'C')) AS \"17\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 17 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 17 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 17 DAY), X.WRITE_HODONG, 'C')) AS \"18\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 18 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 18 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 18 DAY), X.WRITE_HODONG, 'C')) AS \"19\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 19 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 19 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 19 DAY), X.WRITE_HODONG, 'C')) AS \"20\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 20 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 20 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 20 DAY), X.WRITE_HODONG, 'C')) AS \"21\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 21 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 21 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 21 DAY), X.WRITE_HODONG, 'C')) AS \"22\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 22 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 22 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 22 DAY), X.WRITE_HODONG, 'C')) AS \"23\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 23 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 23 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 23 DAY), X.WRITE_HODONG, 'C')) AS \"24\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 24 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 24 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 24 DAY), X.WRITE_HODONG, 'C')) AS \"25\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 25 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 25 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 25 DAY), X.WRITE_HODONG, 'C')) AS \"26\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 26 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 26 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 26 DAY), X.WRITE_HODONG, 'C')) AS \"27\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 27 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 27 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 27 DAY), X.WRITE_HODONG, 'C')) AS \"28\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 28 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 28 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 28 DAY), X.WRITE_HODONG, 'C')) AS \"29\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 29 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 29 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 29 DAY), X.WRITE_HODONG, 'C')) AS \"30\"   ");
		sql.append("       , CONCAT('''',                                                                                                                                ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 30 DAY), X.WRITE_HODONG, 'A'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 30 DAY), X.WRITE_HODONG, 'B'), '/',        ");
		sql.append("         FN_NUR_NEED_DONG_POINT(X.HOSP_CODE, X.BUNHO, DATE_ADD(STR_TO_DATE(:f_date, '%Y%m%d'), INTERVAL 30 DAY), X.WRITE_HODONG, 'C')) AS \"31\"   ");
		sql.append("  FROM                                                                                                                                               ");
		sql.append("  (SELECT A.HOSP_CODE                                                                                                                                ");
		sql.append("        , B.SUNAME                                                                                                                                   ");
		sql.append("        , A.BUNHO                                                                                                                                    ");
		sql.append("        , A.WRITE_HODONG, A.WRITE_DATE                                                                                                               ");
		sql.append("    FROM NUR8003 A                                                                                                                                   ");
		sql.append("    JOIN OUT0101 B                                                                                                                                   ");
		sql.append("      ON B.HOSP_CODE    = A.HOSP_CODE                                                                                                                ");
		sql.append("     AND B.BUNHO        = A.BUNHO                                                                                                                    ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                               ");
		sql.append("     AND A.WRITE_HODONG = :f_ho_dong                                                                                                                 ");
		sql.append("     AND A.WRITE_DATE   BETWEEN STR_TO_DATE(:f_date, '%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date, '%Y%m%d'))                                      	 ");
		sql.append("   GROUP BY A.HOSP_CODE, A.BUNHO, B.SUNAME, A.WRITE_HODONG                                                                                           ");
		sql.append("   ) X                                                                                                                                               ");
		sql.append("   ORDER BY X.BUNHO                                                                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date + "01");
		
		List<NUR8003Q00grdWritedInfo> listInfo = new JpaResultMapper().list(query, NUR8003Q00grdWritedInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR8003Q00grdNur8003Info> getNUR8003Q00grdNur8003Info(String hospCode, String queryDate, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DATE_FORMAT(Z.WRITE_DATE, '%Y/%m/%d') WRITE_DATE                                                                                     ");
		sql.append("        , CAST(SUM(CASE(Z.COUNT_YN) WHEN 'Y' THEN 1 ELSE 0 END) AS CHAR) COUNT                                                                 ");
		sql.append("        , CAST(SUM(CASE(Z.DATA_YN) WHEN 'Y' THEN 1 ELSE 0 END) AS CHAR) ALL_COUNT                                                              ");
		sql.append("        , CAST(ROUND(SUM(CASE(Z.COUNT_YN) WHEN 'Y' THEN 1 ELSE 0 END) / SUM(CASE(Z.DATA_YN) WHEN 'Y' THEN 1 ELSE 0 END) * 100) AS CHAR) PER    ");
		sql.append("        , CONCAT(CAST(SUM(CASE(Z.COUNT_YN) WHEN 'Y' THEN 1 ELSE 0 END) AS CHAR), '/', CAST(SUM(CASE(Z.DATA_YN) WHEN 'Y' THEN 1 ELSE 0 END) AS CHAR)) CAL                   ");
		sql.append("   FROM                                                                                                                                        ");
		sql.append("   (SELECT A.BUNHO                                                                                                                             ");
		sql.append("        , A.WRITE_DATE                                                                                                                         ");
		sql.append("        , 'Y' DATA_YN                                                                                                                          ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'A') A                                                                 ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'B') B                                                                 ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'C') C                                                                 ");
		sql.append("        , FN_NUR_LOAD_NUR_NEED_COUNT(A.HOSP_CODE                                                                                               ");
		sql.append("                                   , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'A')                                        ");
		sql.append("                                   , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'B')                                        ");
		sql.append("                                   , FN_NUR_LOAD_NUR_NEED_POINT(A.HOSP_CODE, A.BUNHO, A.WRITE_DATE,'C')                                        ");
		sql.append("                                   , STR_TO_DATE(:f_query_date,'%Y%m%d')                                                                       ");
		sql.append("                                   , :f_ho_dong ) COUNT_YN                                                                                     ");
		sql.append("     FROM NUR8003 A                                                                                                                            ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                        ");
		sql.append("      AND A.WRITE_DATE   BETWEEN STR_TO_DATE(DATE_FORMAT(STR_TO_DATE(:f_query_date, '%Y%m%d') ,'%Y/%m/01'),'%Y/%m/%d')                         ");
		sql.append("                             AND LAST_DAY(STR_TO_DATE(:f_query_date,'%Y%m%d'))                                                                 ");
		sql.append("      AND A.WRITE_HODONG = :f_ho_dong                                                                                                          ");
		sql.append("    GROUP BY                                                                                                                                   ");
		sql.append("          A.HOSP_CODE, A.BUNHO, WRITE_DATE                                                                                                     ");
		sql.append("    ) Z                                                                                                                                        ");
		sql.append("    GROUP BY WRITE_DATE                                                                                                                        ");
		sql.append("    ORDER BY Z.WRITE_DATE                                                                                                                      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_query_date", queryDate.replace("/", ""));
		
		List<NUR8003Q00grdNur8003Info> listInfo = new JpaResultMapper().list(query, NUR8003Q00grdNur8003Info.class);
		return listInfo;
	}

	@Override
	public List<NUR8003R02grdMasterInfo> getNUR8003R02grdMasterInfo(String hospCode, String fromDate, String toDate,
			String hoDong, String needHType, String bunho, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUBSTRING(DATE_FORMAT(A.WRITE_DATE, '%Y%m%d'), 1, 6) AS WRITE_MONTH                                      ");
		sql.append("	     , A.WRITE_HODONG                                       AS WRITE_HODONG                                     ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.WRITE_HODONG, CURRENT_DATE(), :f_hosp_code, :f_language) AS HODONG_NAME           ");
		sql.append("	     , COUNT(DISTINCT A.BUNHO)                              AS PATIENT_CNT                                      ");
		sql.append("	  FROM VW_NUR_HFILE_CODE_INFO A                                                                                 ");
		sql.append("	  ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                               ");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code                                                                            ");
		sql.append("	   AND A.WRITE_DATE   BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m') AND LAST_DAY(STR_TO_DATE(:f_to_date, '%Y/%m')) ");
		sql.append("	   AND A.WRITE_HODONG IN (SELECT B.HO_DONG                                                                      ");
		sql.append("	                              FROM NUR0801 B                                                                    ");
		sql.append("	                             WHERE B.HOSP_CODE = :f_hosp_code                                                   ");
		sql.append("	                               AND B.HO_DONG   LIKE :f_hoDong                                                   ");
		sql.append("	                               AND B.NEED_TYPE IN (SELECT X.NEED_TYPE                                           ");
		sql.append("	                                                     FROM NUR0811 X                                             ");
		sql.append("	                                                    WHERE X.HOSP_CODE   = A.HOSP_CODE                           ");
		sql.append("	                                                      AND X.NEED_H_TYPE = :f_need_h_type                        ");
		sql.append("	                                                   )                                                            ");
		sql.append("	                               AND IFNULL(B.MAKE_H_FILE_YN, 'N') = 'Y'                                          ");
		sql.append("	                            )                                                                                   ");
		sql.append("	   AND A.BUNHO          LIKE IF(:f_bunho IS NULL OR :f_bunho = '', '%', :f_bunho)                               ");
		sql.append("	   AND A.H_FILE_STRING  IS NOT NULL                                                                             ");
		sql.append("	 GROUP BY SUBSTRING(DATE_FORMAT(A.WRITE_DATE, '%Y%m%d'), 0, 6)                                                  ");
		sql.append("	        , A.WRITE_HODONG                                                                                        ");
		sql.append("	 ORDER BY WRITE_MONTH, WRITE_HODONG                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hoDong", hoDong);
		
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_need_h_type", needHType);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		
		List<NUR8003R02grdMasterInfo> listInfo = new JpaResultMapper().list(query, NUR8003R02grdMasterInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR8003U03CopyDataInfo> getNUR8003U03CopyDataInfo(String hospCode, String bunho, Date writeDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.FIRST_GUBUN                        ");
		sql.append("	  	 , B.GR_CODE                            ");
		sql.append("	  	 , B.RS_CODE                            ");
		sql.append("	  	 , B.SM_CODE                            ");
		sql.append("	  	 , B.SM_DETAIL                          ");
		sql.append("	  	 , B.NUR_POINT                          ");
		sql.append("	  	 , B.NEW_SM_CODE                        ");
		sql.append("	  	 , B.NEW_SM_DETAIL                      ");
		sql.append("	  	 , B.NEW_NUR_POINT                      ");
		sql.append("	  FROM NUR8003 A                            ");
		sql.append("		   , NUR8033 B                          ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code      ");
		sql.append("	   AND A.BUNHO          = :f_bunho          ");
		sql.append("	   AND A.WRITE_DATE     = :f_from_write_date");
		sql.append("	   AND B.HOSP_CODE      = A.HOSP_CODE       ");
		sql.append("	   AND B.BUNHO          = A.BUNHO           ");
		sql.append("	   AND B.FIRST_GUBUN    = A.FIRST_GUBUN     ");
		sql.append("	   AND B.GR_CODE        = A.GR_CODE         ");
		sql.append("	   AND B.WRITE_DATE     = A.WRITE_DATE      ");
		sql.append("	 ORDER BY A.FIRST_GUBUN                     ");
		sql.append("			, A.GR_CODE                         ");
		sql.append("			, B.RS_CODE                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_write_date", writeDate);
		
		List<NUR8003U03CopyDataInfo> listInfo = new JpaResultMapper().list(query, NUR8003U03CopyDataInfo.class);
		return listInfo;
	}
}

