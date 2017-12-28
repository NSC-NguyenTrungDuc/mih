package nta.med.data.dao.medi.sch.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch0001RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0001Info;

/**
 * @author dainguyen.
 */
public class Sch0001RepositoryImpl implements Sch0001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<SCH3001U00GrdSCH0001Info> getSCH3001U00GrdSCH0001Info(String hospCode, String jundalTable){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUNDAL_TABLE                                JUNDAL_TABLE       ");
		sql.append("     , A.JUNDAL_PART                                 JUNDAL_PART        ");
		sql.append("     , A.GUMSAJA                                     GUMSAJA            ");
		sql.append("     , FN_ADM_LOAD_USER_NAME(A.GUMSAJA,:f_hosp_code) GUMSAJA_NAME       ");
		sql.append("     , A.JUNDAL_PART_NAME                            JUNDAL_PART_NAME   ");
		sql.append("     , A.GWA_GUBUN                                   GWA_GUBUN          ");
		sql.append(" FROM SCH0001 A                                                         ");
		sql.append("WHERE A.HOSP_CODE    = :f_hosp_code                                     ");
		sql.append("  AND A.JUNDAL_TABLE = :f_jundal_table                                  ");
		sql.append("ORDER BY A.JUNDAL_TABLE, A.JUNDAL_PART, A.GUMSAJA                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", jundalTable);

		List<SCH3001U00GrdSCH0001Info> list = new JpaResultMapper().list(query, SCH3001U00GrdSCH0001Info.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getSchsSCH0201U99ComboGumsaPart (String hospCode, String language, String cboGumsaValue){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT '%' CODE , FN_ADM_MSG('221',:f_language) CODE_NAME   ");
		if(!("%").equals(cboGumsaValue)){
			sql.append(" UNION ALL ");
			sql.append(" SELECT A.JUNDAL_PART       CODE ");
			sql.append(" , A.JUNDAL_PART_NAME  CODE_NAME ");
			sql.append(" FROM SCH0001 A ");
			sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code ");
			sql.append(" AND A.JUNDAL_TABLE LIKE :f_cbo_gumsa_value ");
			sql.append(" ORDER BY CODE ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		if(!("%").equals(cboGumsaValue)){
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_cbo_gumsa_value", cboGumsaValue);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}

