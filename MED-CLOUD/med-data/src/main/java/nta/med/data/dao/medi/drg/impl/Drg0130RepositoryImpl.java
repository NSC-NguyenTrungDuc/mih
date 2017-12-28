package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg0130RepositoryCustom;
import nta.med.data.model.ihis.drgs.DrgsDRG0130U00GrdDrg0130ListItemInfo;
import nta.med.data.model.ihis.drug.DrugComboListItemInfo;


/**
 * @author dainguyen.
 */
public class Drg0130RepositoryImpl implements Drg0130RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Drg0130RepositoryImpl.class);
	
	@PersistenceContext
	EntityManager entityManager;

	@Override
	public List<DrgsDRG0130U00GrdDrg0130ListItemInfo> getDrgsDRG0130U00GrdDrg0130ListItemInfo(String hospCode, String language, String cautionCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAUTION_CODE ,											");
		sql.append("	CAUTION_NAME ,                                                 " );
		sql.append("	CAUTION_NAME2  ,                                               " );
		sql.append("	JOB_TYPE                                                       " );
		sql.append("	FROM DRG0130                                                   " );
		sql.append("	WHERE CAUTION_CODE LIKE CONCAT(:cautionCode, '%'   )           " );
		sql.append("	AND HOSP_CODE = :hospCode  AND LANGUAGE = :language            " );
		sql.append("	ORDER BY CAUTION_CODE;                                         " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode",hospCode);
		query.setParameter("language",language);
		query.setParameter("cautionCode",cautionCode);
		
		List<DrgsDRG0130U00GrdDrg0130ListItemInfo> listResult = new JpaResultMapper().list(query, DrgsDRG0130U00GrdDrg0130ListItemInfo.class);
		return listResult;
	}

	@Override
	public String getDrgsDRG0130U00CautionCode(String hospCode, String language, String cautionCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CAUTION_CODE						     ");
		sql.append("	 FROM DRG0130                                ");
		sql.append("	WHERE CAUTION_CODE  = :cautionCode           ");
		sql.append("	  AND HOSP_CODE     = :hospCode              ");
		sql.append("      AND LANGUAGE      = :language              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode",hospCode);
		query.setParameter("language",language);
		query.setParameter("cautionCode",cautionCode);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<DrugComboListItemInfo> getDRGOCSCHKGetCautionList(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CAUTION_CODE              ");
		sql.append("     , CAUTION_NAME               ");
		sql.append("  FROM DRG0130                    ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code   ");
		sql.append("   AND LANGUAGE  = :language      ");
		sql.append(" ORDER BY 1                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code",hospCode);
		query.setParameter("language",language);
		
		List<DrugComboListItemInfo> listResult = new JpaResultMapper().list(query, DrugComboListItemInfo.class);
		return listResult;
	}
}

