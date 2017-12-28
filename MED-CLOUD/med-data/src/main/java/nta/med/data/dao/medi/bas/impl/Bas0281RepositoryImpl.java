package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.data.dao.medi.bas.Bas0281RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Bas0281RepositoryImpl implements Bas0281RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Bas0281RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getDisGubunName(String date, String gubun) {
		StringBuilder sql = new StringBuilder("SELECT FN_BAS_LOAD_DIS_GUBUN_NAME(:gubun, STR_TO_DATE(:date, '%Y/%m/%d'))");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gubun", gubun);
		query.setParameter("date", date);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			 String val = result.get(0);
			 return val;
		}
		return null;
	}
}

