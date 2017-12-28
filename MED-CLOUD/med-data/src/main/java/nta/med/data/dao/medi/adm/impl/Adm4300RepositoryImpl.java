package nta.med.data.dao.medi.adm.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm4300RepositoryCustom;
import nta.med.data.model.ihis.system.MdiFormMenuItemInfo;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Adm4300RepositoryImpl implements Adm4300RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<MdiFormMenuItemInfo> getMdiFormSystemMenu(String hospCode, String language, String userId, String sysId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.MENU_LEVEL, A.MENU_TP, A.PGM_NM, A.TR_ID, A.PGM_ID, A.PGM_SYS_ID, A.PGM_ENT_GRAD, A.PGM_UPD_GRAD,     ");
		sql.append("        A.PGM_SCRT, A.PGM_DUP_YN, A.PGM_OPEN_TP, A.SHORT_CUT, A.ASM_NAME, A.ASM_PATH, A.ASM_VER, A.MENU_PARAM           ");
		sql.append("   FROM ADM4300 A                                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                                                                                     ");
		sql.append("    AND A.LANGUAGE = :f_language                                                                                        ");
		sql.append("    AND A.USER_ID = :f_user_id                                                                                          ");
		sql.append("    AND A.SYS_ID  = :f_system_id                                                                                        ");
		sql.append("  ORDER BY A.SEQ                                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_system_id", sysId);
		
		List<MdiFormMenuItemInfo> result = new JpaResultMapper().list(query, MdiFormMenuItemInfo.class);
		return result;
	}

	@Override
	public Integer deleteByHospCodeAndLanguageAndUserIdAndSysId(String hospCode, String language, String userId, String sysId) {
		StringBuilder sql = new StringBuilder();
		sql.append("DELETE FROM ADM4300                  ");
		sql.append("WHERE HOSP_CODE = :f_hosp_code       ");
		sql.append("AND LANGUAGE  =   :f_language    	 ");
		sql.append("AND USER_ID   =   :f_user_id         ");
		sql.append("AND SYS_ID= 	  :f_system_id       ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_system_id", sysId);

		return query.executeUpdate();

	}

}

