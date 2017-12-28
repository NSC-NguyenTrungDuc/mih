package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1003RepositoryCustom;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR02ListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Nur1003RepositoryImpl implements Nur1003RepositoryCustom {

private static final Log LOG = LogFactory.getLog(Nur1003RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<OCS1003R02LayR02ListItemInfo> getOCS1003R02LayOutListItemInfo(
			String hospCode, String gwaOut, String gwaNameOut, String bunhoOut,
			String sunameOut, String balheangDateOut, String birthOut,
			String naewonDateOut, String bunho1Out,
			String dangilGumsaResultYnOut, String jaedanName, String hospName,
			String tel, String homePage, Double fkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT :f_gwa_out                    GWA,                      ");
		sql.append("    :f_gwa_name_out               GWA_NAME,                     ");
		sql.append("    :f_bunho_out                  BUNHO,                        ");
		sql.append("    :f_suname_out                 SUNAME,                       ");
		sql.append("    :f_balheang_date_out          BALHEANG_DATE,                ");
		sql.append("    :f_birth_out                  BIRTH,                        ");
		sql.append("    :f_naewon_date_out            NAEWON_DATE,                  ");
		sql.append("    A.COMMENTS,                                                 ");
		sql.append("    :f_bunho_1_out                BUNHO_1,                      ");
		sql.append("    :f_dangil_gumsa_result_yn_out DANGIL_GUMSA_RESULT_YN,       ");
		sql.append("         A.FKOUT1001                   FKOUT1001,               ");
		sql.append("         A.ACTING_CHECK_YN             ACTING_CHECK_YN,         ");
		sql.append("         :f_jaedan_name                JAEDAN_NAME,             ");
		sql.append("         :f_hosp_name                  HOSP_NAME,               ");
		sql.append("         :f_tel                        TEL,                     ");
		sql.append("         :f_homepage                   HOMEPAGE                 ");
		sql.append("   FROM NUR1003 A                                               ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                             ");
		sql.append("     AND A.FKOUT1001 = :f_fkout1001 ORDER BY DATA_SORT			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa_out", gwaOut);
		query.setParameter("f_gwa_name_out", gwaNameOut);
		query.setParameter("f_bunho_out", bunhoOut);
		query.setParameter("f_suname_out", sunameOut);
		query.setParameter("f_balheang_date_out", balheangDateOut);
		query.setParameter("f_birth_out", birthOut);
		query.setParameter("f_naewon_date_out", naewonDateOut);
		query.setParameter("f_bunho_1_out", bunho1Out);
		query.setParameter("f_dangil_gumsa_result_yn_out", dangilGumsaResultYnOut);
		query.setParameter("f_jaedan_name", jaedanName);
		query.setParameter("f_hosp_name", hospName);
		query.setParameter("f_tel", tel);
		query.setParameter("f_homepage", homePage);
		query.setParameter("f_fkout1001", fkout1001);
		
		List<OCS1003R02LayR02ListItemInfo> list = new JpaResultMapper().list(query, OCS1003R02LayR02ListItemInfo.class);
		return list;
	}
	@Override
	public String callPrNurMakePatienInfo(String hospCode, String language, String bunho, Double fkout1001, String userId) {
		String ioFlg = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_MAKE_PATIENTINFO");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOUT1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKOUT1001", fkout1001);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("IO_FLAG", "");
		
		query.execute();
		ioFlg = (String)query.getOutputParameterValue("IO_FLAG");
		return ioFlg;
	}
}

