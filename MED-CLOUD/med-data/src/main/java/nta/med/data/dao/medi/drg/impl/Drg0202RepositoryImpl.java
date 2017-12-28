package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.drg.Drg0202RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Drg0202RepositoryImpl implements Drg0202RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Drg0202RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String getOBCheckSpecialDrugForPatient(String hospCode,String hangmog, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'FROM DRG0202 A                                        " );    
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                              " );
		sql.append("   AND A.HANGMOG_CODE   = :f_aHangmog_code                         " );
		sql.append("   AND NOT EXISTS ( SELECT NULL                                    " );
		sql.append("                      FROM DRG0202 B                               " );
		sql.append("                     WHERE B.HOSP_CODE      = A.HOSP_CODE          " );
		sql.append("                       AND B.HANGMOG_CODE   = A.HANGMOG_CODE       " );
		sql.append("                       AND B.BUNHO          = :f_aBunho            " );
		sql.append("                  )                                                " );
		sql.append("    LIMIT  1      													");         
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aHangmog_code", hangmog);
		query.setParameter("f_aBunho", bunho);
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
}

