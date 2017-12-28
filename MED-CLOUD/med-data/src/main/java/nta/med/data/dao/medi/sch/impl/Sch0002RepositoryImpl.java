package nta.med.data.dao.medi.sch.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch0002RepositoryCustom;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0002Info;

/**
 * @author dainguyen.
 */
public class Sch0002RepositoryImpl implements Sch0002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String getjundalTable(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT JUNDAL_TABLE  FROM SCH0002 WHERE HOSP_CODE = :f_hosp_code AND HANGMOG_CODE = :f_hangmog_code LIMIT 1 ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<String> result = query.getResultList();
		if(!result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<SCH3001U00GrdSCH0002Info> getSCH3001U00GrdSCH0002Info(String hospCode, String jundalTable, String jundalPart){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUNDAL_TABLE   JUNDAL_TABLE     ");
		sql.append("     , A.JUNDAL_PART    JUNDAL_PART      ");
		sql.append("     , A.GUMSAJA        GUMSAJA          ");
		sql.append("     , A.HANGMOG_CODE   HANGMOG_CODE     ");
		sql.append("     , A.HANGMOG_NAME   HANGMOG_NAME     ");
		sql.append("     , A.GUMSA_TIME     GUMSA_TIME       ");
		sql.append("  FROM SCH0002 A                         ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code     ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table  ");
		sql.append("   AND A.JUNDAL_PART  = :f_jundal_part   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);

		List<SCH3001U00GrdSCH0002Info> list = new JpaResultMapper().list(query, SCH3001U00GrdSCH0002Info.class);
		return list;
	}
}

