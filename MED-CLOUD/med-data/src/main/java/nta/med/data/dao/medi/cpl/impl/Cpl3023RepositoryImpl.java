package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl3023RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect2ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect1ListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl3023RepositoryImpl implements Cpl3023RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL0000Q00ResultListQuerySelect1ListItemInfo> getCPL0000Q00ResultListQuerySelect1Request(String hospCode, String specimenSer,
			String srlCode, String jundalGubun){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SERIAL                          SERIAL        ");
		sql.append("      , IFNULL(A.RESULT_TEXT,A.KYUN_TEXT) KYUN_RESULT   ");
		sql.append("      , A.KYUN_CODE                       KYUN_CODE     ");
		sql.append("      , A.KYUN_TEXT                       MIC_NAME      ");
		sql.append("      , A.RESULT_TEXT                     MIC_RESULT    ");
		sql.append("   FROM CPL3023 A                                       ");
		sql.append("  WHERE A.HOSP_CODE         = :f_hosp_code              ");
		sql.append("    AND A.LAB_NO            = :f_specimen_ser           ");
		sql.append("    AND A.RESULT_GB         = :f_srl_code               ");
		sql.append("    AND :f_jundal_gubun     = '10'                      ");
		sql.append("  ORDER BY 1,2                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_srl_code", srlCode);
		query.setParameter("f_jundal_gubun", jundalGubun);
		
		List<CPL0000Q00ResultListQuerySelect1ListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00ResultListQuerySelect1ListItemInfo.class);
		return list;
	}
}

