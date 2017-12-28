package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0128RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ocs0128RepositoryImpl implements Ocs0128RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs0128RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getOCS0103U00GrdOCS0115ColChangedJundalPartOut(String hospCode, String language, String gwa,boolean isInpJundalPart,String iOGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA_NAME                                        ");
		sql.append("   FROM BAS0260 A, OCS0128 B                              ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                        ");
		sql.append("  AND A.LANGUAGE = :f_langauge                            ");
		sql.append("    AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE     ");
		sql.append("    AND A.GWA = :f_gwa                                    ");
		if(isInpJundalPart){
			sql.append("    AND A.INP_JUNDAL_PART_YN = 'Y'                    ");
		}else{
			sql.append("    AND A.OUT_JUNDAL_PART_YN = 'Y'                    ");
		}
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                         ");
		sql.append("    AND B.IO_GUBUN = :f_io_gubun                          ");
		sql.append("   AND B.JUNDAL_PART = A.GWA                              ");
		sql.append("  ORDER BY A.GWA                                          ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		query.setParameter("f_gwa", gwa);      
		query.setParameter("f_io_gubun", iOGubun); 
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String getOCS0103U00GetJundalTable(String hospCode,String jundalPart, String startDate, String ioGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JUNDAL_TABLE                                                               ");
		sql.append("    FROM OCS0128 A                                                                   ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                  ");
		sql.append("     AND A.JUNDAL_PART = :f_jundal_part                                              ");
		sql.append("     AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE  ");
		sql.append("     AND A.IO_GUBUN = :f_iO_gubun													 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_iO_gubun", ioGubun);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language, String ioGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA                                                           ");
		sql.append("      , A.GWA_NAME                                                      ");
		sql.append("   FROM BAS0260 A,OCS0128 B                                             ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code AND A.LANGUAGE = :f_langauge         ");
		sql.append("    AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                   ");
		sql.append("    AND A.GWA IS NOT NULL                                               ");
		sql.append("    AND A.USE_YN = 'Y'                                                  "); 
		sql.append("    AND A.OUT_JUNDAL_PART_YN = 'Y'                                      ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                       ");
		sql.append("    AND B.IO_GUBUN = :f_io_gubun                                        ");
		sql.append("    AND B.JUNDAL_PART = A.GWA                                           ");
		sql.append("  ORDER BY A.GWA 														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		query.setParameter("f_io_gubun", ioGubun);
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}
}

