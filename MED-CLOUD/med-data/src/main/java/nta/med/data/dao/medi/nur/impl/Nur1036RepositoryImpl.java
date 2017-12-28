package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1036RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1035U00grdNUR1036Info;

/**
 * @author dainguyen.
 */
public class Nur1036RepositoryImpl implements Nur1036RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1035U00grdNUR1036Info> getNUR1035U00grdNUR1036Info(String hospCode, Double fknur1035, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FKNUR1035                                          ");
		sql.append("        , DATE_FORMAT(A.CHECK_DATE, '%Y/%m/%d')                ");
		sql.append("        , A.CHECK_TIME                                         ");
		sql.append("        , A.DANGER_ACT                                         ");
		sql.append("        , A.CHANGED_SKIN                                       ");
		sql.append("        , A.EDEMA                                              ");
		sql.append("        , A.NUMBNESS                                           ");
		sql.append("        , A.SCRATCH                                            ");
		sql.append("        , A.TUBE_TROUBLE                                       ");
		sql.append("        , A.PETECHIA                                           ");
		sql.append("        , A.INPUT_ID                                           ");
		sql.append("        , FN_ADM_USER_NM(:f_hosp_code, A.INPUT_ID)             ");
		sql.append("        , A.REMARK                                             ");
		sql.append("        , '' DATA_ROW_STATE                                    ");
		sql.append("     FROM NUR1036 A                                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("      AND A.FKNUR1035 = :f_fknur1035                           ");
		sql.append("    ORDER BY A.CHECK_DATE DESC, A.CHECK_TIME DESC              ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset								");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknur1035", fknur1035);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR1035U00grdNUR1036Info> listInfo = new JpaResultMapper().list(query, NUR1035U00grdNUR1036Info.class);
		return listInfo;		
	}
	
	@Override
	public String getNUR1035U00cmdText(String hospCode, Double pknur1035){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                  ");
		sql.append("     FROM DUAL                                                 ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                   ");
		sql.append("                    FROM NUR1036 A                             ");
		sql.append("                   WHERE A.HOSP_CODE = :f_hosp_code            ");
		sql.append("                     AND A.FKNUR1035 = :f_pknur1035)           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pknur1035", pknur1035);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
}

