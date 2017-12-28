package nta.med.data.dao.medi.sch.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch3100RepositoryCustom;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3100Info;

/**
 * @author dainguyen.
 */
public class Sch3100RepositoryImpl implements Sch3100RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<SCH3001U00GrdSCH3100Info> getSCH3001U00GrdSCH3100Info(String hospCode, String jundalTable, String jundalPart, String gumsaja){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUNDAL_TABLE        JUNDAL_TABLE ");
		sql.append("     , A.JUNDAL_PART         JUNDAL_PART  ");
		sql.append("     , A.GUMSAJA             GUMSAJA      ");
		sql.append("     , A.RESER_DATE          RESER_DATE   ");
		sql.append("     , A.RESER_YN            RESER_YN     ");
		sql.append("  FROM SCH3100 A                          ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code      ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table   ");
		sql.append("   AND A.JUNDAL_PART  = :f_jundal_part    ");
		sql.append("   AND A.GUMSAJA      = :f_gumsaja        ");
		sql.append(" ORDER BY A.RESER_DATE DESC               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_gumsaja", gumsaja);

		List<SCH3001U00GrdSCH3100Info> list = new JpaResultMapper().list(query, SCH3001U00GrdSCH3100Info.class);
		return list;
	}
}

