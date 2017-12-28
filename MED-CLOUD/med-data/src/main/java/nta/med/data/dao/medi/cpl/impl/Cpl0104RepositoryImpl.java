package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0104RepositoryCustom;
import nta.med.data.model.ihis.cpls.CplCPL0104U00GrdDetailCPL0104ListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl0104RepositoryImpl implements Cpl0104RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<CplCPL0104U00GrdDetailCPL0104ListItemInfo> getCplCPL0104U00GrdDetailCPL0104(String hospCode, String hangmogCode, 
			String specimenCode,String emergency, Integer startNum, Integer endNum) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.HANGMOG_CODE                     ");
		sql.append(" , A.SPECIMEN_CODE                         ");
		sql.append(" , A.EMERGENCY                             ");
		sql.append(" , A.SEX                                   ");
		sql.append(" , A.NAI_FROM                              ");
		sql.append(" , A.NAI_TO                                ");
		sql.append(" , A.FROM_AGE                              ");
		sql.append(" , A.TO_AGE                                ");
		sql.append(" , A.FROM_STANDARD                         ");
		sql.append(" , A.TO_STANDARD                           ");
		sql.append(" FROM CPL0104 A                            ");
		sql.append(" WHERE A.HOSP_CODE      = :f_hosp_code     ");
		sql.append(" AND A.HANGMOG_CODE   = :f_hangmog_code    ");
		sql.append(" AND A.SPECIMEN_CODE  = :f_specimen_code   ");
		sql.append(" AND A.EMERGENCY      = :f_emergency       ");	
		sql.append(" ORDER BY LPAD(A.SEX, 1, '0')              ");
		if(endNum != 0){
			sql.append(" LIMIT :startNum, :endNum              ");	
		}
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_emergency", emergency);
		if(endNum != 0){
			query.setParameter("startNum", startNum);	
			query.setParameter("endNum", endNum);	
		}
		List<CplCPL0104U00GrdDetailCPL0104ListItemInfo> result= new JpaResultMapper().list(query, CplCPL0104U00GrdDetailCPL0104ListItemInfo.class);
		return result;
	}
}

