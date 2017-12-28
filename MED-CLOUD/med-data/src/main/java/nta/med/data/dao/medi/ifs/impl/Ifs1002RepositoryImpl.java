package nta.med.data.dao.medi.ifs.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.data.dao.medi.ifs.Ifs1002RepositoryCustom;
import nta.med.data.dao.medi.out.impl.Out1001RepositoryImpl;
import nta.med.data.model.ihis.nuro.RES1001U00PrIFSMakeYoyakuInfo;

/**
 * @author dainguyen.
 */
public class Ifs1002RepositoryImpl implements Ifs1002RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ifs1002RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public RES1001U00PrIFSMakeYoyakuInfo callRES1001U00PrIFSMakeYoyaku(
			String hospCode, Double pkout1001, String proGubun,
			String yoyakiGubun, String ioGubun, String userId, String bunho,
			String gwa, String doctor, String naewonDate, String jubsuTime) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_IFS_MAKE_YOYAKU");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOUT1001", Double.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_YOYAKU_GUBUN", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PKIFS1002", Double.class,ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_ERR", String.class,ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKOUT1001", pkout1001);
		query.setParameter("I_PROC_GUBUN", proGubun);
		query.setParameter("I_YOYAKU_GUBUN", yoyakiGubun);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_NAEWON_DATE", naewonDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		RES1001U00PrIFSMakeYoyakuInfo ifsInfo = new RES1001U00PrIFSMakeYoyakuInfo(
				(Double) query.getOutputParameterValue("O_PKIFS1002"),
				(String) query.getOutputParameterValue("O_ERR"));
		return ifsInfo;
	}
}

