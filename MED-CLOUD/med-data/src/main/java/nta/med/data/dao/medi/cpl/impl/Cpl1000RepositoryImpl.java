package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl1000RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL3010U00DsvUrineListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl1000RepositoryImpl implements Cpl1000RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL3010U00DsvUrineListItemInfo> getCPL3010U00DsvUrineListItemInfo(String hospCode, String specimenSer, String gubun, Double fkocs, String inOutGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT PKCPL1000                                 ");
		sql.append("     , URINE_RYANG                               ");
		sql.append("     , HEIGHT                                    ");
		sql.append("     , WEIGHT                                    ");
		sql.append("     , STABILITY_YN                              ");
		sql.append("     , SPECIMEN_SER                              ");
		sql.append("  FROM CPL1000                                   ");
		sql.append(" WHERE HOSP_CODE    = :f_hosp_code               ");
		sql.append("    AND SPECIMEN_SER = :f_specimen_ser           ");
		sql.append("   AND :f_gubun     = '1'                        ");
		sql.append(" UNION                                           ");
		sql.append("SELECT PKCPL1000                                 ");
		sql.append("     , URINE_RYANG                               ");
		sql.append("     , HEIGHT                                    ");
		sql.append("     , WEIGHT                                    ");
		sql.append("     , STABILITY_YN                              ");
		sql.append("     , SPECIMEN_SER                              ");
		sql.append("  FROM CPL1000                                   ");
		sql.append(" WHERE HOSP_CODE    = :f_hosp_code               ");
		sql.append("   AND FKOCS        = :f_fkocs                   ");
		sql.append("   AND IN_OUT_GUBUN = :f_in_out_gubun            ");
		sql.append("   AND :f_gubun     = '2'                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_fkocs", fkocs);
		query.setParameter("f_in_out_gubun", inOutGubun);
		
		List<CPL3010U00DsvUrineListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00DsvUrineListItemInfo.class);
		return list;
	}
}

