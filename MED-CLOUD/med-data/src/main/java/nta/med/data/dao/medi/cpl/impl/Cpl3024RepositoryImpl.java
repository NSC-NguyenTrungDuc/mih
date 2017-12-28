package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl3024RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect1ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect2ListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl3024RepositoryImpl implements Cpl3024RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL0000Q00ResultListQuerySelect2ListItemInfo> getCPL0000Q00ResultListQuerySelect2(String hospCode, String specimenSer,
			String kyunCode, Double serial){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SEQ              ANTI_SEQ                  ");
		sql.append("      , A.ANTI_NAME        ANTI_NAME                 ");
		sql.append("      , A.ANTI_NAME        MIC_NAME                  ");
		sql.append("      , A.RESULT_TEXT      MIC_RESULT                ");
		sql.append("   FROM CPL3024 A                                    ");
		sql.append("  WHERE A.HOSP_CODE         = :f_hosp_code           ");
		sql.append("    AND A.LAB_NO            = TRIM(:o_specimen_ser)  ");
		sql.append("    AND A.KYUN_CODE         = TRIM(:o_kyun_code)     ");
		sql.append("    AND A.SERIAL            = :o_serial              ");
		sql.append("  ORDER BY 1,2                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("o_specimen_ser", specimenSer);
		query.setParameter("o_kyun_code", kyunCode);
		query.setParameter("o_serial", serial);
		
		List<CPL0000Q00ResultListQuerySelect2ListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00ResultListQuerySelect2ListItemInfo.class);
		return list;
	}
}

