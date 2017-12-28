package nta.med.data.dao.medi.ifs.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.lang3.StringUtils;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs7301RepositoryCustom;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public class Ifs7301RepositoryImpl implements Ifs7301RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrDrgIfsProc(String hospCode, String ioGubun, Double fkdrg, String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_JIH_DRG_IFS_PROC");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKDRG", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT); 
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_FKDRG", fkdrg);
		query.setParameter("I_USER_ID", userId);
		query.execute();
		
		String err = (String)query.getOutputParameterValue("O_ERR");
		return err;
	}
	
	@Override
	public String callPrDrgMasterInsert(String hospCode, String jubsuDate, String drgBunho, String dataGubun, String inOutGubun, String bunho, String fk){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_DRG_MASTER_INSERT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_DUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FK", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PK", Double.class, ParameterMode.OUT); 
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_DRG_BUNHO", CommonUtils.parseDouble(drgBunho));
		query.setParameter("I_DATA_DUBUN", dataGubun);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FK", CommonUtils.parseDouble(fk));
		query.execute();
		
		String pk = CommonUtils.parseString((Double)query.getOutputParameterValue("O_PK"));
		return pk;
	}
	
	@Override
	public TripleListItemInfo callPrIfsDrgProcMain(String hospCode, String ioGubun, String masterFk, String sendYn){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_DRG_PROC_MAIN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MASTER_FK", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEND_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_CNT", Double.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.OUT); 
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_MASTER_FK", CommonUtils.parseDouble(masterFk));
		query.setParameter("I_SEND_YN", sendYn);
		query.execute();
		String msg = (String)query.getOutputParameterValue("O_MSG");
		if (StringUtils.isEmpty(msg)) msg = "";
		
		TripleListItemInfo result = new TripleListItemInfo(CommonUtils.parseString((Double)query.getOutputParameterValue("O_CNT")),
				(String)query.getOutputParameterValue("O_FLAG"),
				msg);
		return result;
	}
}

