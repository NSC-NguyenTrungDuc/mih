package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0118RepositoryCustom;
import nta.med.data.model.ihis.system.PrOcsConvertHangmogCodeInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Ocs0118RepositoryImpl implements Ocs0118RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs0118RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public PrOcsConvertHangmogCodeInfo callPrOcsConvertHangmogCode(String hospCode,
			String convClass, String convGubun, String hangmogCode,
			String bunho, Date gijunDate, String ioHangmogCode, String ioMsgYn, String ioRemark) {
		LOGGER.info("[START] callPrOcsConvertHangmogCode  hospCode =" + hospCode + ", convClass=" + convClass + ", convGubun=" + convGubun + ","
				+ " hangmogCode=" + hangmogCode + ", bunho=" + bunho + ", gijunDate=" + gijunDate);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_CONVERT_HANGMOG_CODE");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CONV_CLASS", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CONV_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GIJUN_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_CONV_HANGMOG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG_YN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_REMARK", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_CONV_CLASS", convClass);
		query.setParameter("I_CONV_GUBUN", convGubun);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GIJUN_DATE", gijunDate); 
		query.setParameter("IO_CONV_HANGMOG", ioHangmogCode);
		query.setParameter("IO_MSG_YN", ioMsgYn);
		query.setParameter("IO_REMARK", ioRemark);
		
		query.execute();
		PrOcsConvertHangmogCodeInfo info =  new PrOcsConvertHangmogCodeInfo((String)query.getOutputParameterValue("IO_CONV_HANGMOG"),
				(String)query.getOutputParameterValue("IO_MSG_YN"), (String)query.getOutputParameterValue("IO_REMARK"));
		
		return info;
	}

	@Override
	public PrOcsConvertHangmogCodeInfo callPrOcsConvertHangmogCodeCommonYn(String hospCode, String convClass,
			String convGubun, String hangmogCode, String bunho, Date gijunDate, String ioHangmogCode, String ioMsgYn,
			String ioRemark) {
		LOGGER.info("[START] callPrOcsConvertHangmogCodeCommonYn  hospCode =" + hospCode + ", convClass=" + convClass + ", convGubun=" + convGubun + ","
				+ " hangmogCode=" + hangmogCode + ", bunho=" + bunho + ", gijunDate=" + gijunDate);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_CONVERT_HANGMOG_CODE_COMMON_ORDER");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CONV_CLASS", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CONV_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GIJUN_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_CONV_HANGMOG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG_YN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_REMARK", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_CONV_CLASS", convClass);
		query.setParameter("I_CONV_GUBUN", convGubun);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GIJUN_DATE", gijunDate); 
		query.setParameter("IO_CONV_HANGMOG", ioHangmogCode);
		query.setParameter("IO_MSG_YN", ioMsgYn);
		query.setParameter("IO_REMARK", ioRemark);
		
		query.execute();
		PrOcsConvertHangmogCodeInfo info =  new PrOcsConvertHangmogCodeInfo((String)query.getOutputParameterValue("IO_CONV_HANGMOG"),
				(String)query.getOutputParameterValue("IO_MSG_YN"), (String)query.getOutputParameterValue("IO_REMARK"));
		
		return info;
	}
}

