package nta.med.data.dao.medi.phy.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.phy.Phy8003RepositoryCustom;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8003LisItemInfo;

/**
 * @author dainguyen.
 */
public class Phy8003RepositoryImpl implements Phy8003RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<Phy8002U01GrdPhy8003LisItemInfo> getPhy8002U01GrdPhy8003LisItem(
			String hospCode, String kanjaNo, Double fkocs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT  A.SYS_DATE,																");
		sql.append("	        A.USER_ID,                                                              ");
		sql.append("	        A.UPD_DATE,                                                             ");
		sql.append("	        A.HOSP_CODE,                                                            ");
		sql.append("	        A.PK_PHY_SYOUBYOU,                                                      ");
		sql.append("	        A.DATA_KUBUN,                                                           ");
		sql.append("	        A.FK_OCS_IRAI,                                                          ");
		sql.append("	        A.IO_KUBUN,                                                             ");
		sql.append("	        A.IRAI_DATE,                                                            ");
		sql.append("	        A.KANJA_NO,                                                             ");
		sql.append("	        A.SINRYOUKA,                                                            ");
		sql.append("	        A.SYOUBYOUMEI_CODE,                                                     ");
		sql.append("	        CONCAT(A.PRE_MODIFIER_NAME,A.SYOUBYOUMEI,A.POST_MODIFIER_NAME),         ");
		sql.append("	        A.PRE_MODIFIER1,                                                        ");
		sql.append("	        A.PRE_MODIFIER2,                                                        ");
		sql.append("	        A.PRE_MODIFIER3,                                                        ");
		sql.append("	        A.PRE_MODIFIER4,                                                        ");
		sql.append("	        A.PRE_MODIFIER5,                                                        ");
		sql.append("	        A.PRE_MODIFIER6,                                                        ");
		sql.append("	        A.PRE_MODIFIER7,                                                        ");
		sql.append("	        A.PRE_MODIFIER8,                                                        ");
		sql.append("	        A.PRE_MODIFIER9,                                                        ");
		sql.append("	        A.PRE_MODIFIER10,                                                       ");
		sql.append("	        A.POST_MODIFIER1,                                                       ");
		sql.append("	        A.POST_MODIFIER2,                                                       ");
		sql.append("	        A.POST_MODIFIER3,                                                       ");
		sql.append("	        A.POST_MODIFIER4,                                                       ");
		sql.append("	        A.POST_MODIFIER5,                                                       ");
		sql.append("	        A.POST_MODIFIER6,                                                       ");
		sql.append("	        A.POST_MODIFIER7,                                                       ");
		sql.append("	        A.POST_MODIFIER8,                                                       ");
		sql.append("	        A.POST_MODIFIER9,                                                       ");
		sql.append("	        A.POST_MODIFIER10,                                                      ");
		sql.append("	        A.HASSYOUBI,                                                            ");
		sql.append("	        A.SINDANBI,                                                             ");
		sql.append("	        A.PRE_MODIFIER_NAME,                                                    ");
		sql.append("	        A.POST_MODIFIER_NAME,                                                   ");
		sql.append("	        A.SYOUBYOUMEI,                                                          ");
		sql.append("	        A.FKOUTSANG                                                             ");
		sql.append("	FROM    PHY8003 A                                                               ");
		sql.append("	WHERE   A.KANJA_NO         = :f_kanja_no                                        ");
		sql.append("	        AND A.HOSP_CODE  = :f_hosp_code                                          ");
		sql.append("	        AND A.FK_OCS_IRAI = :f_fk_ocs_irai                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_kanja_no", kanjaNo);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fk_ocs_irai", fkocs);
		
		List<Phy8002U01GrdPhy8003LisItemInfo> list = new JpaResultMapper().list(query, Phy8002U01GrdPhy8003LisItemInfo.class);
		return list;
	}
}

