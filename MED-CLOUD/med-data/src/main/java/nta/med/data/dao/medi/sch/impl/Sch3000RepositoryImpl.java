package nta.med.data.dao.medi.sch.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch3000RepositoryCustom;
import nta.med.data.model.ihis.schs.SCH3001U00GrdJukyongDateInfo;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3000Info;

/**
 * @author dainguyen.
 */
public class Sch3000RepositoryImpl implements Sch3000RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<SCH3001U00GrdJukyongDateInfo> getSCH3001U00GrdJukyongDateInfo(String hospCode, String jundalTable, String jundalPart, String gumsaja){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                      ");
		sql.append("       A.JUKYONG_DATE                                     JUKYONG_DATE                                               ");
		sql.append("     , A.JUNDAL_TABLE                                     JUNDAL_TABLE                                               ");
		sql.append("     , A.JUNDAL_PART                                      JUNDAL_PART                                                ");
		sql.append("     , A.GUMSAJA                                          GUMSAJA                                                    ");
		sql.append("     , A.JUKYONG_DATE                                     OLD_JUKYONG_DATE                                           ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'2',:f_hosp_code)    MON_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'3',:f_hosp_code)    TUE_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'4',:f_hosp_code)    WED_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'5',:f_hosp_code)    THU_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'6',:f_hosp_code)    FRI_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'7',:f_hosp_code)    STA_DAY   ");
		sql.append("     , FN_SCH_LOAD_SCH3000_YOIL(A.JUKYONG_DATE,A.JUNDAL_TABLE,A.JUNDAL_PART,A.GUMSAJA,'1',:f_hosp_code)    SUN_DAY   ");
		sql.append("  FROM SCH3000 A                                                                                                     ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                 ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table                                                                              ");
		sql.append("   AND A.JUNDAL_PART  = :f_jundal_part                                                                               ");
		sql.append("   AND A.GUMSAJA      = :f_gumsaja                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_gumsaja", gumsaja);

		List<SCH3001U00GrdJukyongDateInfo> list = new JpaResultMapper().list(query, SCH3001U00GrdJukyongDateInfo.class);
		return list;
	}
	
	@Override
	public List<SCH3001U00GrdSCH3000Info> getSCH3001U00GrdSCH3000Info(String hospCode, String jundalTable, String jundalPart, String gumsaja,
			String jukyongDate, String yoilGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUKYONG_DATE        JUKYONG_DATE                        ");
		sql.append("     , A.JUNDAL_TABLE        JUNDAL_TABLE                        ");
		sql.append("     , A.JUNDAL_PART         JUNDAL_PART                         ");
		sql.append("     , A.GUMSAJA             GUMSAJA                             ");
		sql.append("     , A.YOIL_GUBUN          YOIL_GUBUN                          ");
		sql.append("     , A.START_TIME          START_TIME                          ");
		sql.append("     , A.END_TIME            END_TIME                            ");
		sql.append("     , A.INWON               INWON                               ");
		sql.append("     , A.ADD_INWON           ADD_INWON                           ");
		sql.append("     , A.OUT_HOSP_SLOT       OUT_HOSP_SLOT                       ");
		sql.append("  FROM SCH3000 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                             ");
		sql.append("   AND A.JUKYONG_DATE = STR_TO_DATE(:f_jukyong_date,'%Y/%m/%d')  ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table                          ");
		sql.append("   AND A.JUNDAL_PART  = :f_jundal_part                           ");
		sql.append("   AND A.GUMSAJA      = :f_gumsaja                               ");
		sql.append("   AND A.YOIL_GUBUN   = :f_yoil_gubun                            ");
		sql.append(" ORDER BY A.JUNDAL_TABLE, A.JUNDAL_PART                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_gumsaja", gumsaja);
		query.setParameter("f_jukyong_date", jukyongDate);
		query.setParameter("f_yoil_gubun", yoilGubun);

		List<SCH3001U00GrdSCH3000Info> list = new JpaResultMapper().list(query, SCH3001U00GrdSCH3000Info.class);
		return list;
	}
}

