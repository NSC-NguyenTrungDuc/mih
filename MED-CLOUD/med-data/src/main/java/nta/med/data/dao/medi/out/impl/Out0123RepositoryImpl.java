package nta.med.data.dao.medi.out.impl;

import nta.med.data.dao.medi.out.Out0123RepositoryCustom;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Out0123RepositoryImpl implements Out0123RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Out0123RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<String> getNuroRES1001U00CheckingPatientExistence(String hospitalCode, String bunho, Double pkout1001){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                         ");
		sql.append("FROM DUAL                               		   ");
		sql.append("WHERE EXISTS ( SELECT BUNHO                        ");
		sql.append("        FROM OUT0123                               ");
		sql.append("        WHERE HOSP_CODE    = :hospitalCode         ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("                AND BUNHO        = :patientCode    ");
		}
		if (!StringUtils.isEmpty(pkout1001)) {
			sql.append("                AND FKOUT1001    = :pkout1001      ");
		}
		sql.append("                AND COMMENT_TYPE = '1' )           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("patientCode", bunho);
		}
		if (!StringUtils.isEmpty(pkout1001)) {
			query.setParameter("pkout1001", pkout1001);
		}

		List<String> list = query.getResultList();
		return list;
	}
}

