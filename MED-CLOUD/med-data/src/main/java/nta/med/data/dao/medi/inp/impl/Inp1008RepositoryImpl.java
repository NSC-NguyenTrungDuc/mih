package nta.med.data.dao.medi.inp.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1008RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Inp1008RepositoryImpl implements Inp1008RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Integer recordCount(String hospCode, Double fkinp1002, String gonbiCode){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT COUNT(*)											");
		sql.append("       FROM INP1008 A											");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code					");
		sql.append("        AND A.FKINP1002        = :f_fkinp1002					");
		sql.append("        AND A.GONGBI_CODE      = :f_gongbi_code					");

		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_fkinp1002", fkinp1002);
	    query.setParameter("f_gongbi_code", gonbiCode);
	    List<String> result = query.getResultList();
	 	if(!result.isEmpty()){
	 		return CommonUtils.parseInteger(result.get(0));
	    }
		return 0; 
	}
	
	@Override
	public Integer updateInInp1001U01(String hospCode, Double fkinp1002, String gonbiCode){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE  INP1008											");
		sql.append("         SET UPD_ID           = :f_user_id						");
		sql.append("           , UPD_DATE         = SYSDATE()						");
		sql.append("           , BUNHO            = :f_bunho						");
		sql.append("         WHERE HOSP_CODE      = :f_hosp_code 					");
		sql.append("         AND FKINP1002        = :f_fkinp1002					");
		sql.append("         AND GONGBI_CODE      = :f_gongbi_code					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_fkinp1002", fkinp1002);
	    query.setParameter("f_gongbi_code", gonbiCode);
	    
		return query.executeUpdate(); 
	}
	
	@Override
	public Integer deleteInInp1001U01(String hospCode, Double fkinp1002, String gonbiCode){
		StringBuilder sql = new StringBuilder();
		sql.append("     DELETE FROM INP1008										");
		sql.append("         WHERE HOSP_CODE      = :f_hosp_code 					");
		sql.append("         AND FKINP1002        = :f_fkinp1002					");
		sql.append("         AND GONGBI_CODE      = :f_gongbi_code					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_fkinp1002", fkinp1002);
	    query.setParameter("f_gongbi_code", gonbiCode);
	    
		return query.executeUpdate(); 
	}
	
	
}

