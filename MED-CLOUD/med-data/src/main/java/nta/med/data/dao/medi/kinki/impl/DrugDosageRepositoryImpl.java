package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugDosageRepositoryCustom;
import nta.med.data.model.ihis.system.DrugDosageMasterInfo;

public class DrugDosageRepositoryImpl implements DrugDosageRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<DrugDosageMasterInfo> getDrugDosageMasterInfo() {
		StringBuilder sql = new StringBuilder();
		sql.append(" select 																								");
		sql.append(" D1.DRUG_ID																								");
		sql.append(" , D1.BRANCH_NUMBER																						");
		sql.append(" , D1.DOSAGE_BRANCH_NUMBER																				");
		sql.append(" , D1.A4																								");
		sql.append(" , D1.A5																								");
		sql.append(" , D1.ADAPTATION																						");				
		sql.append(" , D1.ADAPTATION_RELATED																				");			
		sql.append(" , D1.A8																								");
		sql.append(" , D1.AGE_CLASSIFICATION																				");		
		sql.append(" , D1.APPROPRIATE																						");		
		sql.append(" , D1.APPROPRIATE_CONDITION																				");
		sql.append(" , D1.A12																								");
		sql.append(" , D1.A13																								");
		sql.append(" , D1.ONE_DOSE																							");
		sql.append(" , D2.DAILY_DOSE																						");
		sql.append(" , D2.DAILY_DOES_CONTENT	 																			");
		sql.append(" , D2.DOSE_FORM																							");
		sql.append(" , D2.DAILY_DOSE_FORM																					");
		sql.append(" , D2.DOSAGE_FORM_UNIT																					");
		sql.append(" , D2.DAILY_NUMBER_DOSES																				");
		sql.append(" , D2.A21																								");
		sql.append(" , D2.A22																								");						
		sql.append(" , D2.A23																								");						
		sql.append(" , D2.A24																								");						
		sql.append(" , D2.A25																								");						
		sql.append(" , D2.A26																								");						
		sql.append(" , D2.A27																								");						
		sql.append(" , D2.A28																								");						
		sql.append(" , D2.A29																								");						
		sql.append(" , D2.A30																								");						
		sql.append(" , D2.A31																								");						
		sql.append(" , D2.A32																								");						
		sql.append(" , D2.A33																								");						
		sql.append(" , D2.A34																								");						
		sql.append(" , D2.A35																								");						
		sql.append(" , D2.A36																								");						
		sql.append(" , D2.A37																								");						
		sql.append(" , D2.A38																								");						
		sql.append(" , D2.A39																								");						
		sql.append(" , D2.A40																								");						
		sql.append(" , D2.A41																								");						
		sql.append(" , D2.A42																								");						
		sql.append(" , D2.A43																								");
		sql.append(" , D3.A44																								");						
		sql.append(" , D3.A45																								");
		sql.append(" , D3.A46																								");
		sql.append(" , D3.A47																								");
		sql.append(" , D3.A48																								");
		sql.append(" , D3.A49																								");
		sql.append(" , D3.A50																								");
		sql.append(" , D3.A51																								");
		sql.append(" , D3.A52																								");
		sql.append(" , D3.A53																								");
		sql.append(" , D3.A54																								");
		sql.append(" , D3.A55																								");
		sql.append(" , D3.A56																								");
		sql.append(" , D3.A57																								");
		sql.append(" , D3.A58																								");
		sql.append(" , D3.A59																								");
		sql.append(" , D3.A60																								");
		sql.append(" , D3.A61																								");
		sql.append(" , D3.A62																								");
		sql.append(" , D3.A63																								");
		sql.append(" , D3.A64																								");
		sql.append(" , D3.A65																								");
		sql.append(" , D3.A66																								");
		sql.append(" , D3.A67																								");
		sql.append(" , D3.A68																								");
		sql.append(" , D3.A69																								");
		sql.append(" , D3.A70																								");
		sql.append(" , D3.A71																								");
		sql.append(" , D3.A72																								");
		sql.append(" , D4.A73																								");
		sql.append(" , D4.A74																								");
		sql.append(" , D4.A75																								");
		sql.append(" , D4.A76																								");
		sql.append(" , D4.A77																								");
		sql.append(" , D4.A78																								");
		sql.append(" , D4.A79																								");
		sql.append(" , D4.A80																								");
		sql.append(" , D4.A81																								");
		sql.append(" , D4.A82																								");
		sql.append(" , D4.A83																								");
		sql.append(" , D4.A84																								");
		sql.append(" , D4.A85																								");
		sql.append(" , D4.A86																								");
		sql.append(" , D4.A87																								");
		sql.append(" , D4.A88																								");
		sql.append(" , D4.A89																								");
		sql.append(" , D4.A90																								");
		sql.append(" , D4.A91																								");
		sql.append(" , D4.A92																								");
		sql.append(" , D4.A93																								");
		sql.append(" , D4.A94																								");
		sql.append(" , D4.A95																								");
		sql.append(" , D4.A96																								");
		sql.append(" , D4.A97																								");
		sql.append(" , D4.A98																								");
		sql.append(" , D4.A99																								");
		sql.append(" , D4.A100																								");
		sql.append(" , D4.A101																								");
		sql.append(" from DRUG_DOSAGE D1, 																					");
		sql.append(" DRUG_DOSAGE_NORMAL D2, 																				");
		sql.append(" DRUG_DOSAGE_STANDARD D3, 																				");
		sql.append(" DRUG_DOSAGE_ADDITION D4																				");
		sql.append(" where 1 = 1 																							");
		sql.append(" AND (D1.DRUG_ID = D2.DRUG_ID																			");
		sql.append(" AND D1.BRANCH_NUMBER = D2.BRANCH_NUMBER																");
		sql.append(" AND D1.DOSAGE_BRANCH_NUMBER = D2.DOSAGE_BRANCH_NUMBER)													");
		sql.append(" AND (D2.DRUG_ID = D3.DRUG_ID																			");
		sql.append(" AND D2.BRANCH_NUMBER = D3.BRANCH_NUMBER																");
		sql.append(" AND D2.DOSAGE_BRANCH_NUMBER = D3.DOSAGE_BRANCH_NUMBER)													");
		sql.append(" AND (D3.DRUG_ID = D4.DRUG_ID																			");
		sql.append(" AND D3.BRANCH_NUMBER = D4.BRANCH_NUMBER																");
		sql.append(" AND D3.DOSAGE_BRANCH_NUMBER = D4.DOSAGE_BRANCH_NUMBER)													");
		sql.append(" AND D1.ACTIVE_FLG = 1          																		");
		sql.append(" AND D2.ACTIVE_FLG = 1          																		");
		sql.append(" AND D3.ACTIVE_FLG = 1          																		");
		sql.append(" AND D4.ACTIVE_FLG = 1          																		");

		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<DrugDosageMasterInfo> listResult = new JpaResultMapper().list(query, DrugDosageMasterInfo.class);
		return listResult;
	}

}
