package nta.med.data.dao.medi.sch.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch3101RepositoryCustom;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3101Info;

/**
 * @author dainguyen.
 */
public class Sch3101RepositoryImpl implements Sch3101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<SCH3001U00GrdSCH3101Info> getSCH3001U00GrdSCH3101Info(String hospCode, String jundalTable, String jundalPart, String gumsaja,
			String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUNDAL_TABLE        JUNDAL_TABLE                       ");                 
		sql.append("     , A.JUNDAL_PART         JUNDAL_PART                        ");
		sql.append("     , A.GUMSAJA             GUMSAJA                            ");
		sql.append("     , A.RESER_DATE          RESER_DATE                         ");
		sql.append("     , A.START_TIME          START_TIME                         ");
		sql.append("     , A.END_TIME            END_TIME                           ");
		sql.append("     , A.INWON               INWON                              ");
		sql.append("     , A.ADD_INWON           ADD_INWON                          ");
		sql.append("  FROM SCH3101 A                                                ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                            ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table                         ");
		sql.append("   AND A.JUNDAL_PART  = :f_jundal_part                          ");
		sql.append("   AND A.GUMSAJA      = :f_gumsaja                              ");
		sql.append("   AND A.RESER_DATE   = STR_TO_DATE(:f_reser_date,'%Y/%m/%d')   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_gumsaja", gumsaja);
		query.setParameter("f_reser_date", reserDate);

		List<SCH3001U00GrdSCH3101Info> list = new JpaResultMapper().list(query, SCH3001U00GrdSCH3101Info.class);
		return list;
	}
}

