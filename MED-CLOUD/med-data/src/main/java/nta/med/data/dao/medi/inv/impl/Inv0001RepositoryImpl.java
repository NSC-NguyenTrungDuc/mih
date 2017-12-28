package nta.med.data.dao.medi.inv.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv0001RepositoryCustom;
import nta.med.data.model.ihis.invs.CountReserveQtyInfo;

public class Inv0001RepositoryImpl implements Inv0001RepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<CountReserveQtyInfo> countReserveQtyByFkocs1003(String hospCode, List<Double> fkocs1003s) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.RESERVE_QTY								    	");
		sql.append("	     , FKOCS1003											");
		sql.append("	  FROM INV0001 A											");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code				    		");
		sql.append("	 AND  A.FKOCS1003 IN (:fkocs1003)						    ");
		sql.append("	 AND    A.ACTIVE_FLG = 1         						    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("fkocs1003", fkocs1003s);
		
		List<CountReserveQtyInfo> listData = new JpaResultMapper().list(query, CountReserveQtyInfo.class);
		return listData;
	}

}
