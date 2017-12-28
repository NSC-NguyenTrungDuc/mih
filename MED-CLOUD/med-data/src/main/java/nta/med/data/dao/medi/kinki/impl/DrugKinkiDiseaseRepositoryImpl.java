package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugKinkiDiseaseRepositoryCustom;
import nta.med.data.model.ihis.system.DrugKinkiDiseaseInfo;

public class DrugKinkiDiseaseRepositoryImpl implements DrugKinkiDiseaseRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<DrugKinkiDiseaseInfo> getDrugKinkiDiseaseInfo() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT KINKI_ID,                   ");
		sql.append("        DISEASE_NAME,               ");
		sql.append("        INDEX_TERM,                 ");
		sql.append("        STANDARD_DISEASE_NAME,      ");
		sql.append("        DISEASE_CODE,               ");
		sql.append("        ICD10,                      ");
		sql.append("        DECISION_FLG,               ");
		sql.append("        COMMENT                     ");
		sql.append(" FROM DRUG_KINKI_DISEASE    		");
		sql.append("  WHERE ACTIVE_FLG = 1              ");
		sql.append(" ORDER BY CREATED	ASC	            ");
		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<DrugKinkiDiseaseInfo> listResult = new JpaResultMapper().list(query, DrugKinkiDiseaseInfo.class);
		return listResult;
	}

}
