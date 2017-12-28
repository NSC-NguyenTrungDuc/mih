package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.data.dao.medi.adm.Adm0000RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Adm0000RepositoryImpl implements Adm0000RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String callFnAdmConvertKanaFull(String hospCode,String searchWorld) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_ADM_CONVERT_KATAKANA_FULL(:f_search_word,:f_hosp_code)  "); 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_search_word", searchWorld);
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
}

