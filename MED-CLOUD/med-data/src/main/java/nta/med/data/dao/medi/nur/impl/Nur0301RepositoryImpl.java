package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0301RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Nur0301RepositoryImpl implements Nur0301RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getNuroRES0102U00CboGwaRoom(String hospCode, String departmentCode, String date){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA_ROOM,                                               ");        
		sql.append("       A.GWA_ROOM_NAME                                           ");
		sql.append("FROM NUR0301 A                                                   ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                    ");
		sql.append("   AND A.GWA      = :departmentCode                              ");
		sql.append("   AND DATE_FORMAT(:date, '%Y/%m/%d') BETWEEN A.START_DATE       ");
		sql.append("   AND IFNULL(A.END_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d')) ");
		sql.append("ORDER BY A.GWA_ROOM                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("date", date);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
}

