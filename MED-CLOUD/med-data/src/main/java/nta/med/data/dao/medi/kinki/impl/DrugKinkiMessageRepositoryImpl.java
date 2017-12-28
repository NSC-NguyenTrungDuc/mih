package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.DrugKinkiMessageRepositoryCustom;
import nta.med.data.model.ihis.system.DrugKinkiMessageInfo;

public class DrugKinkiMessageRepositoryImpl implements DrugKinkiMessageRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<DrugKinkiMessageInfo> getDrugKinkiMessageInfo() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DRUG_ID ,                 ");
		sql.append("         BRANCH_NUMBER,           ");
		sql.append("         WARNING_LEVEL,           ");
		sql.append("         KINKI_ID,                ");
		sql.append("         MESSAGE,                 ");
		sql.append("         CATEGORY                 ");
		sql.append("  FROM DRUG_KINKI_MESSAGE         ");
		sql.append("  WHERE ACTIVE_FLG = 1            ");
		sql.append(" ORDER BY CREATED	ASC	          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<DrugKinkiMessageInfo> listResult = new JpaResultMapper().list(query, DrugKinkiMessageInfo.class);
		return listResult;
	}

}
