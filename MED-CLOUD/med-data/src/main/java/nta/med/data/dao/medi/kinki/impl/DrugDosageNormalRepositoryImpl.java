package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugDosageNormalRepositoryCustom;
import nta.med.data.model.ihis.system.DrugDosageNormalInfo;

public class DrugDosageNormalRepositoryImpl implements DrugDosageNormalRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DrugDosageNormalInfo> getDrugDosageNormalInfo(Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DRUG_ID,                  ");
		sql.append("        BRANCH_NUMBER,            ");
		sql.append("        DOSAGE_BRANCH_NUMBER,     ");
		sql.append("        DAILY_DOSE,               ");
		sql.append("        DAILY_DOES_CONTENT,       ");
		sql.append("        DOSE_FORM,                ");
		sql.append("        DAILY_DOSE_FORM,          ");
		sql.append("        DOSAGE_FORM_UNIT,         ");
		sql.append("        DAILY_NUMBER_DOSES,       ");
		sql.append("         A21	,	              ");
		sql.append("         A22	,	              ");
		sql.append("         A23	,	              ");
		sql.append("         A24	,	              ");
		sql.append("         A25	,	              ");
		sql.append("         A26	,	              ");
		sql.append("         A27	,	              ");
		sql.append("         A28	,	              ");
		sql.append("         A29	,	              ");
		sql.append("         A30	,	              ");
		sql.append("         A31	,	              ");
		sql.append("         A32	,	              ");
		sql.append("         A33	,	              ");
		sql.append("         A34	,	              ");
		sql.append("         A35	,	              ");
		sql.append("         A36	,	              ");
		sql.append("         A37	,	              ");
		sql.append("         A38	,	              ");
		sql.append("         A39	,	              ");
		sql.append("         A40	,	              ");
		sql.append("         A41	,	              ");
		sql.append("         A42	,	              ");
		sql.append("         A43	                  ");
		sql.append("     FROM DRUG_DOSAGE_NORMAL      ");
		sql.append("  WHERE ACTIVE_FLG = 1            ");
		sql.append(" ORDER BY CREATED	ASC	          ");
		sql.append("  LIMIT :f_page_number,:f_offset  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_page_number", pageNumber);
		query.setParameter("f_offset", offset);
		
		List<DrugDosageNormalInfo> listResult = new JpaResultMapper().list(query, DrugDosageNormalInfo.class);
		return listResult;
	}

}
