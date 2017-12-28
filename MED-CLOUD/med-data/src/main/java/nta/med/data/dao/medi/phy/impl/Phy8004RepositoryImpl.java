package nta.med.data.dao.medi.phy.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.phy.Phy8004RepositoryCustom;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8004LisItemInfo;

/**
 * @author dainguyen.
 */
public class Phy8004RepositoryImpl implements Phy8004RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<Phy8002U01GrdPhy8004LisItemInfo> getPhy8002U01GrdPhy8004LisItem(
			String hospCode, Double fkOcs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SYS_DATE								");
		sql.append("	       ,A.USER_ID                               ");
		sql.append("	       ,A.UPD_DATE                              ");
		sql.append("	       ,A.HOSP_CODE                             ");
		sql.append("	       ,A.PK_PHY_SYOUGAI                        ");
		sql.append("	       ,A.DATA_KUBUN                            ");
		sql.append("	       ,A.FK_OCS_IRAI                           ");
		sql.append("	       ,A.SYOUGAI_ID                            ");
		sql.append("	       ,A.SYOUGAIMEI                            ");
		sql.append("	       ,A.KANJA_NO                              ");
		sql.append("	       ,A.FKCHT0113                             ");
		sql.append("	  FROM PHY8004 A                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code             ");
		sql.append("	   AND A.FK_OCS_IRAI = :f_fk_ocs_irai           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fk_ocs_irai", fkOcs);
		
		List<Phy8002U01GrdPhy8004LisItemInfo> list = new JpaResultMapper().list(query, Phy8002U01GrdPhy8004LisItemInfo.class);
		return list;
	}
	
}

