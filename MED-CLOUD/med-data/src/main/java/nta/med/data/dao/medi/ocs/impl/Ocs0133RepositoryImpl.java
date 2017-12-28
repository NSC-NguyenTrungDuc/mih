package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0133RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0133U00grdOCS0133ItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U00setInputControlInfo;

/**
 * @author dainguyen.
 */
public class Ocs0133RepositoryImpl implements Ocs0133RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<OCS0133U00grdOCS0133ItemInfo> getOCS0133U00grdOCS0133ItemInfo(String hospCode, String inputControl,String userInfo, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.INPUT_CONTROL         INPUT_CONTROL                          ");
		sql.append("     , A.INPUT_CONTROL_NAME    INPUT_CONTROL_NAME                      ");
		sql.append("     , A.SPECIMEN_CR_YN        SPECIMEN_CR_YN                          ");
		sql.append("     , A.SURYANG_CR_YN         SURYANG_CR_YN                           ");
		sql.append("     , A.ORD_DANUI_CR_YN       ORD_DANUI_CR_YN                         ");
		sql.append("     , A.DV_CR_YN              DV_CR_YN                                ");
		sql.append("     , A.NALSU_CR_YN           NALSU_CR_YN                             ");
		sql.append("     , A.JUSA_CR_YN            JUSA_CR_YN                              ");
		sql.append("     , A.BOGYONG_CODE_CR_YN    BOGYONG_CODE_CR_YN                      ");
		sql.append("     , A.TOIWON_DRG_CR_YN      TOIWON_DRG_CR_YN                        ");
		sql.append("     , A.PORTABLE_CR_YN        PORTABLE_CR_YN                          ");
		sql.append("     , A.AMT_CR_YN             AMT_CR_YN                               ");
		sql.append("     , A.WONYOI_ORDER_YN_CR_YN WONYOI_ORDER_YN_CR_YN                   ");
		sql.append("     , A.POWDER_YN_CR_YN       POWDER_YN_CR_YN                         ");
		sql.append("  FROM OCS0133 A                                                       ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                      ");
		sql.append("   AND A.INPUT_CONTROL LIKE :f_input_control                           ");
		if(!"ADM".equalsIgnoreCase(userInfo)){
			sql.append(" AND A.INPUT_CONTROL NOT IN('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',       ");
			sql.append(" 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z')    ");
		}
		sql.append("    AND A.LANGUAGE = :f_language                                       ");
		sql.append("    ORDER BY A.INPUT_CONTROL                                           ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_input_control", inputControl+"%");
		query.setParameter("f_language", language);
		List<OCS0133U00grdOCS0133ItemInfo> list = new JpaResultMapper().list(query, OCS0133U00grdOCS0133ItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0101U00InputControlComboListItem(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT INPUT_CONTROL, 												");
		sql.append("	 CONCAT(INPUT_CONTROL,': ',INPUT_CONTROL_NAME) INPUT_CONTROL_NAME   ");
		sql.append("	  FROM OCS0133                                                      ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                                        ");
		sql.append("       AND LANGUAGE = :f_language                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT INPUT_CONTROL, CONCAT('[', INPUT_CONTROL_NAME, ']', INPUT_CONTROL_NAME)     ");
		sql.append(" FROM OCS0133                                                                       ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code                                                    ");
		sql.append("    AND LANGUAGE = :f_language                                      				");
		sql.append("  ORDER BY 1																		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS2005U00setInputControlInfo> getOCS2005U00setInputControlInfo(String hospCode, String inputControl) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT A.SURYANG_CR_YN         SURYANG_CR_YN										");
		sql.append("      , A.ORD_DANUI_CR_YN       ORD_DANUI_CR_YN										");
		sql.append("      , A.DV_CR_YN              DV_CR_YN											");
		sql.append("      , A.NALSU_CR_YN           NALSU_CR_YN											");
		sql.append("      , A.JUSA_CR_YN            JUSA_CR_YN											");
		sql.append("      , A.BOGYONG_CODE_CR_YN    BOGYONG_CODE_CR_YN									");
		sql.append("   FROM OCS0133 A																	");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code													");
		sql.append("    AND A.INPUT_CONTROL IN ('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k')	");
		sql.append("    AND A.INPUT_CONTROL LIKE CONCAT(TRIM(:f_input_control),'%')						");
		sql.append("  ORDER BY A.INPUT_CONTROL															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_input_control", inputControl);
		List<OCS2005U00setInputControlInfo> list = new JpaResultMapper().list(query, OCS2005U00setInputControlInfo.class);
		return list;
	}
}
