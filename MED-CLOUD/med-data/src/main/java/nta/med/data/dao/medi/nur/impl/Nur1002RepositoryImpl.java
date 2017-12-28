package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1002RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1002Info;

/**
 * @author dainguyen.
 */
public class Nur1002RepositoryImpl implements Nur1002RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1001U00GrdNUR1002Info> getNUR1001U00GrdNUR1002Info(String hospCode, String bunho, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();		
		sql.append("   SELECT A.FKINP1001                    FKINP1001                 ");
		sql.append("        , A.BUNHO                        BUNHO                     ");
		sql.append("        , DATE_FORMAT(A.INSERT_DATE, '%Y/%m/%d') INSERT_DATE       ");
		sql.append("        , CAST(A.SER AS CHAR)            SER                       ");
		sql.append("        , A.DRUG_COMMENT                 DRUG_COMMENT              ");
		sql.append("        , '' DATA_ROW_STATE              			               ");
		sql.append("     FROM NUR1002 A                                                ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                               ");
		sql.append("      AND A.BUNHO     = :f_bunho                                   ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001                               ");
		sql.append("    ORDER BY A.FKINP1001, A.BUNHO, A.INSERT_DATE, A.SER            ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset									");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001U00GrdNUR1002Info> listInfo = new JpaResultMapper().list(query, NUR1001U00GrdNUR1002Info.class);
		return listInfo;
	}
}

