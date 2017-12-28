package nta.med.data.dao.medi.cpl.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.cpl.Cpl9000RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Cpl9000RepositoryImpl implements Cpl9000RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String callCPL3010U01PrCplInsertCpl9000(String hospCode,String language, String createUser, Date createDate,
			String createTime, String iraiKey, String bunho,Date partJubsuDate, String partJubsuTime, String gubun,String centerCode) {
		String ioFlg="";
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_CPL_INSERT_CPL9000");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CREATE_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CREATE_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CREATE_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IRAI_KEY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PART_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PART_JUBSU_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CENTER_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PK", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_CREATE_USER", createUser);
		query.setParameter("I_CREATE_DATE", createDate);
		query.setParameter("I_CREATE_TIME", createTime);
		query.setParameter("I_IRAI_KEY", iraiKey);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_PART_JUBSU_DATE", partJubsuDate);
		query.setParameter("I_PART_JUBSU_TIME", partJubsuTime);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_CENTER_CODE", centerCode);
		
		Boolean isValid=query.execute();
		ioFlg=(String) query.getOutputParameterValue("O_PK");
		return ioFlg;
	}
}

