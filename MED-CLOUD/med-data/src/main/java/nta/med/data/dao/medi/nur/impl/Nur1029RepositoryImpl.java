package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1029RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1029Info;

/**
 * @author dainguyen.
 */
public class Nur1029RepositoryImpl implements Nur1029RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1001U00GrdNUR1029Info> getNUR1001U00GrdNUR1029Info(String hospCode, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.PKNUR1029                               ");
		sql.append("        , DATE_FORMAT(A.START_DATE, '%Y/%m/%d')     ");
		sql.append("        , A.BUWI                                    ");
		sql.append("        , A.BUWI_COMMENT                            ");
		sql.append("        , '' DATA_ROW_STATE                         ");
		sql.append("     FROM NUR1029 A                                 ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                ");
		sql.append("      AND A.BUNHO     = :f_bunho                    ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR1001U00GrdNUR1029Info> listInfo = new JpaResultMapper().list(query, NUR1001U00GrdNUR1029Info.class);
		return listInfo;
	}
}

