package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0301RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;

/**
 * @author dainguyen.
 */
public class Ocs0301RepositoryImpl implements Ocs0301RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	

	@Override
	public List<OCS0301U00MembGrdInfo> getOcs0301OCS0301U00MembGrdListItem(
			String hospCode, String memb, Double fkocs0300) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.MEMB         										");
		sql.append("	     , A.FKOCS0300_SEQ                                      ");
		sql.append("	     , A.YAKSOK_CODE                                        ");
		sql.append("	     , A.YAKSOK_NAME                                        ");
		sql.append("	     , A.SEQ                                                ");
		sql.append("	     , A.HOSP_CODE                                          ");
		sql.append("	     , A.MEMB_GUBUN   ,''                                   ");
		sql.append("	  FROM OCS0301 A                                            ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("	   AND A.MEMB = :f_memb                                     ");
		sql.append("	   AND A.FKOCS0300_SEQ = :f_fkocs0300_seq                   ");
		sql.append("	 ORDER BY A.SEQ                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_fkocs0300_seq", fkocs0300);
		
		List<OCS0301U00MembGrdInfo> list = new JpaResultMapper().list(query, OCS0301U00MembGrdInfo.class);
		return list;
	}
}

