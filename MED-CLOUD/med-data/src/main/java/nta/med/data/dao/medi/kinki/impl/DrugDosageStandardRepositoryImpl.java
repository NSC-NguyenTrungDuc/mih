package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugDosageStandardRepositoryCustom;
import nta.med.data.model.ihis.system.DrugDosageStandardInfo;

public class DrugDosageStandardRepositoryImpl implements DrugDosageStandardRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<DrugDosageStandardInfo> getDrugDosageStandardInfo() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                           ");
		sql.append("         DRUG_ID,                 ");
		sql.append("         BRANCH_NUMBER,           ");
		sql.append("         DOSAGE_BRANCH_NUMBER,    ");
		sql.append("         A44	,				  ");
		sql.append("         A45	,				  ");
		sql.append("         A46	,				  ");
		sql.append("         A47	,				  ");
		sql.append("         A48	,				  ");
		sql.append("         A49	,				  ");
		sql.append("         A50	,				  ");
		sql.append("         A51	,				  ");
		sql.append("         A52	,				  ");
		sql.append("         A53	,				  ");
		sql.append("         A54	,				  ");
		sql.append("         A55	,				  ");
		sql.append("         A56	,				  ");
		sql.append("         A57	,				  ");
		sql.append("         A58	,				  ");
		sql.append("         A59	,				  ");
		sql.append("         A60	,				  ");
		sql.append("         A61	,				  ");
		sql.append("         A62	,				  ");
		sql.append("         A63	,				  ");
		sql.append("         A64	,				  ");
		sql.append("         A65	,				  ");
		sql.append("         A66	,				  ");
		sql.append("         A67	,				  ");
		sql.append("         A68	,				  ");
		sql.append("         A69	,				  ");
		sql.append("         A70	,				  ");
		sql.append("         A71	,				  ");
		sql.append("         A72                      ");
		sql.append("   FROM DRUG_DOSAGE_STANDARD      ");
		sql.append("  WHERE ACTIVE_FLG = 1              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<DrugDosageStandardInfo> listResult = new JpaResultMapper().list(query, DrugDosageStandardInfo.class);
		return listResult;
	}

}
