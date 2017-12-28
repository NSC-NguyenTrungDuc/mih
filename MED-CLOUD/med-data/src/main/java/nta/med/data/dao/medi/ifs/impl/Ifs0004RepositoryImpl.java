package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs0004RepositoryCustom;
import nta.med.data.model.ihis.bass.IFS0004U01grdMasterListItemInfo;

/**
 * @author dainguyen.
 */
public class Ifs0004RepositoryImpl implements Ifs0004RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<IFS0004U01grdMasterListItemInfo> getIfs0004U01grdMasterListItem(
			String hospCode, String nuGubun, String nuYmd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT   A.NU_GUBUN																							");
		sql.append("	       , A.NU_CODE                                                                                          ");
		sql.append("	       , A.NU_YMD                                                                                           ");
		sql.append("	       , A.NU_CODE_NAME                                                                                     ");
		sql.append("	  FROM IFS0004 A                                                                                            ");
		sql.append("	 WHERE A.HOSP_CODE                = :f_hosp_code                                                            ");
		sql.append("	   AND A.NU_GUBUN               = :f_nu_gubun                                                               ");
		sql.append("	   AND A.NU_YMD                 = (SELECT MAX(Z.NU_YMD)                                                     ");
		sql.append("	                                     FROM IFS0004     Z                                                     ");
		sql.append("	                                    WHERE Z.HOSP_CODE       = A.HOSP_CODE                                   ");
		sql.append("	                                      AND Z.NU_GUBUN        = A.NU_GUBUN                                    ");
		sql.append("	                                      AND Z.NU_CODE         = A.NU_CODE                                     ");
		sql.append("	                                      AND Z.NU_YMD          <= STR_TO_DATE(:f_nu_ymd, '%Y/%m/%d')           ");
		sql.append("	                                  )                                                                         ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.NU_GUBUN, A.NU_CODE                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nu_gubun", nuGubun);
		query.setParameter("f_nu_ymd", nuYmd);
		
		List<IFS0004U01grdMasterListItemInfo> list = new JpaResultMapper().list(query, IFS0004U01grdMasterListItemInfo.class);
		return list;
	}
}

