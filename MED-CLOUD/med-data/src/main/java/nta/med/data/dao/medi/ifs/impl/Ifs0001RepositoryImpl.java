package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs0001RepositoryCustom;
import nta.med.data.model.ihis.adma.IFS0001U00GrdMasterInfo;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0001Info;

/**
 * @author dainguyen.
 */
public class Ifs0001RepositoryImpl implements Ifs0001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<IFS0001U00GrdMasterInfo> getIFS0001U00GrdMasterInfo(String hospCode, String codeType, String acctType){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE                  ");
		sql.append("      , A.CODE_TYPE_NAME             ");
		sql.append("      , A.REMARK                     ");
		sql.append("  FROM IFS0001 A                     ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("   AND A.CODE_TYPE LIKE :f_code_type ");
		sql.append("   AND A.ACCT_TYPE LIKE :acctType    ");
		sql.append(" ORDER BY A.HOSP_CODE, A.CODE_TYPE   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%"+codeType+"%");
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("acctType", "%"+acctType+"%");
		
		List<IFS0001U00GrdMasterInfo> list = new JpaResultMapper().list(query, IFS0001U00GrdMasterInfo.class);
		return list;
	}
	
	@Override
	public String checkGrdDetailColumnChanged(String masterCheck, String hospCode, String codeType, String colId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CHECK_DUP_IFS0001");
		query.registerStoredProcedureParameter("I_MASTER_CHECK", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CODE_TYPE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_COL_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_DUP_YN", String.class, ParameterMode.OUT);
		
		query.setParameter("I_MASTER_CHECK", masterCheck);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_CODE_TYPE", codeType);
		query.setParameter("I_COL_ID", colId);
		
		query.execute();
		String result = (String)query.getOutputParameterValue("O_DUP_YN");
		return result;
	}

	@Override
	public List<ComBizLoadIFS0001Info> getComBizLoadIFS0001ListItem(
			String hospCode, String codeType) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE, A.CODE_TYPE_NAME, A.REMARK  		");
		sql.append("	     , A.SYS_DATE, A.SYS_ID, A.UPD_DATE, A.UPD_ID       ");
		sql.append("	  FROM IFS0001 A                                        ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                          ");
		sql.append("	   AND A.CODE_TYPE = :codeType                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		
		List<ComBizLoadIFS0001Info> list = new JpaResultMapper().list(query, ComBizLoadIFS0001Info.class);
		return list;
	}
	
	
}

