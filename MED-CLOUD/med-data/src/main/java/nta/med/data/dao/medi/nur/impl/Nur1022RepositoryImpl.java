package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1022RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1020Q00layIOInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layInOutTotalInfo;

/**
 * @author dainguyen.
 */
public class Nur1022RepositoryImpl implements Nur1022RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1020Q00layInOutTotalInfo> getNUR1020Q00layInOutTotalInfo(String hospCode, String bunho,
			Double fkinp1001, String fromOpDate, String toOpDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT YMD                                                                                   ");
		sql.append("	     ,SUM(IF(IO_GUBN = 'I', IFNULL(IO_VALUE, 0), 0)) IN_TOTAL                                ");
		sql.append("	     ,SUM(IF(IO_GUBN = 'O', IFNULL(IO_VALUE, 0), 0)) OUT_TOTAL                               ");
		sql.append("	     ,SUM(IF(IO_GUBN = 'I', IFNULL(IO_VALUE, 0), 0))                                         ");
		sql.append("	     ,SUM(IF(IO_GUBN = 'O', IFNULL(IO_VALUE, 0), 0)) INOUT_MINUS                             ");
		sql.append("	 FROM NUR1022                                                                                ");
		sql.append("	WHERE HOSP_CODE  = :f_hosp_code                                                              ");
		sql.append("	  AND BUNHO      = :f_bunho                                                                  ");
		sql.append("	  AND FKINP1001  = :f_fkinp1001                                                              ");
		sql.append("	  AND YMD   	  BETWEEN DATE_ADD(STR_TO_DATE(:f_from_op_date,'%Y/%m/%d'), INTERVAL 1 DAY)  ");
		sql.append("					AND STR_TO_DATE(:f_to_op_date, '%Y/%m/%d')                                	 ");
		sql.append("	  AND ((IO_GUBN = 'O' AND IO_TYPE NOT LIKE '%X')                                             ");
		sql.append("	   OR (IO_GUBN='I' AND IO_TYPE NOT LIKE '%X'))                                               ");
		sql.append("	GROUP BY YMD                                                                                 ");
		sql.append("	ORDER BY YMD                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_from_op_date", fromOpDate);
		query.setParameter("f_to_op_date", toOpDate);
		
		List<NUR1020Q00layInOutTotalInfo> lstResult = new JpaResultMapper().list(query, NUR1020Q00layInOutTotalInfo.class);
		return lstResult;
	}

	@Override
	public List<NUR1020Q00layIOInfo> getNUR1020Q00layIOInfo(String hospCode, String language, String bunho,
			Double fkinp1001, String ymd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.YMD      YMD,                                                                                                   ");
		sql.append("	       A.IO_TYPE  IO_TYPE,                                                                                               ");
		sql.append("	       A.IO_GUBN  IO_GUBUN,                                                                                              ");
		sql.append("	       A.IO_VALUE IO_VALUE                                                                                               ");
		sql.append("	 FROM NUR1022 A                                                                                                          ");
		sql.append("	 JOIN NUR0102 B ON B.HOSP_CODE = A.HOSP_CODE                                                                             ");
		sql.append("	               AND B.CODE      = A.IO_TYPE                                                                               ");
		sql.append("	               AND B.CODE_TYPE = (CASE WHEN A.IO_GUBN = 'I' THEN 'VSPATN_IN' WHEN A.IO_GUBN = 'O' THEN 'VSPATN_OUT' END) ");
		sql.append("	               AND B.LANGUAGE  = :f_language                                                                             ");
		sql.append("	WHERE A.HOSP_CODE  = :f_hosp_code                                                                                        ");
		sql.append("	  AND A.BUNHO      = :f_bunho                                                                                            ");
		sql.append("	  AND A.FKINP1001  = :f_fkinp1001                                                                                        ");
		sql.append("	  AND A.YMD        BETWEEN DATE_ADD(STR_TO_DATE(:f_ymd,'%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_ymd,'%Y/%m/%d')  ");
		sql.append("	ORDER BY A.YMD, A.IO_TYPE, A.IO_GUBN                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020Q00layIOInfo> lstResult = new JpaResultMapper().list(query, NUR1020Q00layIOInfo.class);
		return lstResult;
	}

}
