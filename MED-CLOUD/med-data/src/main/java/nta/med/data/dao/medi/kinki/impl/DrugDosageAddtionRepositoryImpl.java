package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugDosageAddtionRepositoryCustom;
import nta.med.data.model.ihis.system.DrugDosageAddtionInfo;

public class DrugDosageAddtionRepositoryImpl implements DrugDosageAddtionRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<DrugDosageAddtionInfo> getDrugDosageAddtionInfo(Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   DRUG_ID,                  ");
		sql.append("         BRANCH_NUMBER,             ");
		sql.append("         DOSAGE_BRANCH_NUMBER,      ");
		sql.append("         A73	,					");
		sql.append("         A74	,					");
		sql.append("         A75	,					");
		sql.append("         A76	,					");
		sql.append("         A77	,					");
		sql.append("         A78	,					");
		sql.append("         A79	,					");
		sql.append("         A80	,					");
		sql.append("         A81	,					");
		sql.append("         A82	,					");
		sql.append("         A83	,					");
		sql.append("         A84	,					");
		sql.append("         A85	,					");
		sql.append("         A86	,					");
		sql.append("         A87	,					");
		sql.append("         A88	,					");
		sql.append("         A89	,					");
		sql.append("         A90	,					");
		sql.append("         A91	,					");
		sql.append("         A92	,					");
		sql.append("         A93	,					");
		sql.append("         A94	,					");
		sql.append("         A95	,					");
		sql.append("         A96	,					");
		sql.append("         A97	,					");
		sql.append("         A98	,					");
		sql.append("         A99	,					");
		sql.append("         A100 ,						");
		sql.append("         A101 		                ");
		sql.append("   FROM DRUG_DOSAGE_ADDITION		");				      
		sql.append("  WHERE ACTIVE_FLG = 1              ");
		sql.append(" ORDER BY CREATED	ASC	            ");
		sql.append("  LIMIT :f_page_number,:f_offset    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_page_number", pageNumber);
		query.setParameter("f_offset", offset);
		
		List<DrugDosageAddtionInfo> listResult = new JpaResultMapper().list(query, DrugDosageAddtionInfo.class);
		return listResult;
	}

}
