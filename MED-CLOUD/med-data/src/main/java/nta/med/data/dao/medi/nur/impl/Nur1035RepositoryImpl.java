package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1035RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1035U00grdNUR1035Info;

/**
 * @author dainguyen.
 */
public class Nur1035RepositoryImpl implements Nur1035RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1035U00grdNUR1035Info> getNUR1035U00grdNUR1035Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FKINP1001                                                          ");
		sql.append("        , A.PKNUR1035                                                          ");
		sql.append("        , A.METHOD_CODE                                                        ");
		sql.append("        , DATE_FORMAT(A.START_DATE, '%Y/%m/%d')                                ");
		sql.append("        , DATE_FORMAT(A.END_DATE, '%Y/%m/%d')                                  ");
		sql.append("        , A.INPUT_ID                                                           ");
		sql.append("        , FN_ADM_USER_NM(A.HOSP_CODE, A.INPUT_ID)                              ");
		sql.append("        , IFNULL(B.YN, 'N') YN                                                 ");
		sql.append("        , '' DATA_ROW_STATE	                                                   ");
		sql.append("     FROM NUR1035 A                                                            ");
		sql.append("     LEFT JOIN                                                                 ");
		sql.append("         (SELECT X.HOSP_CODE HOSP_CODE                                         ");
		sql.append("                , X.FKNUR1035 FKNUR1035                                        ");
		sql.append("                , 'Y' YN                                                       ");
		sql.append("             FROM NUR1036 X                                                    ");
		sql.append("            WHERE X.HOSP_CODE = :f_hosp_code                                   ");
		sql.append("              AND X.CHECK_DATE = CURRENT_DATE()                                ");
		sql.append("           ) B                                                                 ");
		sql.append("       ON B.HOSP_CODE = A.HOSP_CODE                                            ");
		sql.append("      AND B.FKNUR1035 = A.PKNUR1035                                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                           ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001                                           ");
		sql.append("    ORDER BY A.END_DATE DESC, A.START_DATE DESC, A.METHOD_CODE DESC            ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset												");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<NUR1035U00grdNUR1035Info> listInfo = new JpaResultMapper().list(query, NUR1035U00grdNUR1035Info.class);
		return listInfo;
	}
}

