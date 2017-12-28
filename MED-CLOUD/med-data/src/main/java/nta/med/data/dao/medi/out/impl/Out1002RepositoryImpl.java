package nta.med.data.dao.medi.out.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out1002RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayGongbiCodeInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Out1002RepositoryImpl implements Out1002RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Out1002RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public boolean deletePatientInsuranceInfo(String hospitalCode, String pkout1001) {
		LOG.info("updatePatientInfo: hospitalCode=" + hospitalCode + ", pkout1001=" + pkout1001);
		try {
			StringBuilder sql = new StringBuilder();
			sql.append("DELETE FROM OUT1002                 ");     
			sql.append("WHERE HOSP_CODE = :hospitalCode     ");
			sql.append("        AND FKOUT1001 = :pkout1001  ");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("hospitalCode", hospitalCode);
			query.setParameter("pkout1001", pkout1001);
			query.executeUpdate();
			return true;
		} catch (Exception ex) {
			LOG.error(ex.getMessage(),ex);
			return false;
		}
	}
	
	@Override
	public List<NuroOUT1001U01LayGongbiCodeInfo> getNuroOUT1001U01LayGongbiCode(String hospCode, Double pkout1001){
			StringBuilder sql = new StringBuilder();
			sql.append("SELECT A.GONGBI_CODE1, A.GONGBI_CODE2, A.GONGBI_CODE3, A.GONGBI_CODE4                               ");
			sql.append("  FROM (SELECT  FLOOR((B.ROWNUM + 3)/4)                                                             ");
			sql.append("              , MAX(IF(MOD(ROWNUM, 4) = 1, GONGBI_CODE, '')) GONGBI_CODE1                           ");
			sql.append("              , MAX(IF(MOD(ROWNUM, 4) = 2, GONGBI_CODE, '')) GONGBI_CODE2                           ");
			sql.append("              , MAX(IF(MOD(ROWNUM, 4) = 3, GONGBI_CODE, '')) GONGBI_CODE3                           ");
			sql.append("              , MAX(IF(MOD(ROWNUM, 4) = 0, GONGBI_CODE, '')) GONGBI_CODE4                           ");
			sql.append("          FROM (select @rownum\\:=@rownum+1 'ROWNUM', OUT1002.* from OUT1002 , (SELECT @rownum\\:=0) r  ");
			sql.append("         WHERE HOSP_CODE    = :hospCode                                                             ");
			sql.append("           AND FKOUT1001    =  :pkout1001) B                                                        ");
			sql.append("         GROUP BY FLOOR((B.ROWNUM + 3)/4) )A                                                        ");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("hospCode", hospCode);
			query.setParameter("pkout1001", pkout1001);
			
			List<NuroOUT1001U01LayGongbiCodeInfo> list = new JpaResultMapper().list(query, NuroOUT1001U01LayGongbiCodeInfo.class);
			return list;
	}
}

