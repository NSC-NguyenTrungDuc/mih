package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs1004RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANOrderTransInfo;

/**
 * @author dainguyen.
 */
public class Ifs1004RepositoryImpl implements Ifs1004RepositoryCustom { 
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANOrderTransInfo> getORDERTRANOrderTransInfo (String hospCode, String fkout1003, String transGubun){
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT PKIFS1004 FROM IFS1004 		                                                                        ");															
		sql.append("       	WHERE 1 = 1													                                        ");
		sql.append("   		AND HOSP_CODE = :f_hosp_code                                                                        ");
		sql.append("   		AND FKOUT1003 = :f_fkout_1003                                                                       ");
		if("R".equals(transGubun)){
			sql.append("   		AND IF_FLAG   = '10'		                                                                    ");
		}
		if("N".equals(transGubun)){
			sql.append("   		AND IF_FLAG   = '20'		                                                                    ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkout_1003", fkout1003);
		
		List<ORDERTRANOrderTransInfo> listORDERTRANOrderTransInfo = new JpaResultMapper().list(query,ORDERTRANOrderTransInfo.class);
		return listORDERTRANOrderTransInfo;
	}           
	
	@Override
	public String callPrIfsOrderProcMain(String hospCode, String ioGubun, Integer masterFk, String sendYn){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_ORDER_PROC_MAIN");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MASTER_FK", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEND_YN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_CNT", Integer.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_MASTER_FK", masterFk);
		query.setParameter("I_SEND_YN", sendYn);
		
		query.execute();
		String flag = (String)query.getOutputParameterValue("O_FLAG");
		return flag;
	}
}

