package nta.med.data.dao.medi.oif.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.oif.Oif4001RepositoryCustom;
import nta.med.data.model.ihis.orca.ORCALibGetClaimOrderInfo;

/**
 * @author dainguyen.
 */
public class Oif4001RepositoryImpl implements Oif4001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ORCALibGetClaimOrderInfo> getORCALibGetClaimOrderInfo(String hospCode, Double fkoif1101) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SYS_DATE,                                                                                     ");
		sql.append("        A.SYS_ID,                                                                                       ");
		sql.append("        DATE_FORMAT(A.UPD_DATE, '%Y/%m/%d') UPD_DATE,                                                   ");
		sql.append("        A.UPD_ID,                                                                                       ");
		sql.append("        A.HOSP_CODE,                                                                                    ");
		sql.append("        A.FKOIF1101,                                                                                    ");
		sql.append("        A.PKOIF4001,                                                                                    ");
		sql.append("        A.DOC_UID,                                                                                      ");
		sql.append("        A.CM_ID,                                                                                        ");
		sql.append("        A.DEP_ID,                                                                                       ");
		sql.append("        FN_OIF_LOAD_OIF0102_CODE_NAME(:f_hosp_code, 'GWA',A.DEP_ID) DEP_NAME,                           ");
		sql.append("        A.LICENSE,                                                                                      ");
		sql.append("        A.DOCTOR,                                                                                       ");
		sql.append("        A.STATUS,                                                                                       ");
		sql.append("        A.ORDER_TIME,                                                                                   ");
		sql.append("        A.APP_TIME,                                                                                     ");
		sql.append("        A.REGIST_TIME,                                                                                  ");
		sql.append("        A.PERFORM_TIME,                                                                                 ");
		sql.append("        A.UUID,                                                                                         ");
		sql.append("        A.INSUR_GUBUN,                                                                                  ");
		sql.append(" FN_BAS_LOAD_GUBUN_NAME(A.INSUR_GUBUN, DATE_FORMAT(A.ORDER_TIME,'%Y/%m/%d'), :f_hosp_code) INSUR_NAME,  ");
		sql.append("        A.WARD_ID,                                                                                      ");
		sql.append("        FN_OIF_LOAD_OIF0102_CODE_NAME(:f_hosp_code, 'GWA', A.WARD_ID) WARD_NAME,                        ");
		sql.append("        A.IO_FLAG,                                                                                      ");
		sql.append("        A.TIME_CLASS,                                                                                   ");
		sql.append("        B.PKOIF4002,                                                                                    ");
		sql.append("        B.CLASS_CODE,                                                                                   ");
		sql.append("        B.CLASS_CODE_NAME,                                                                              ");
		sql.append("        B.CLASS_CODE_TD,                                                                                ");
		sql.append("        B.ADM_CODE,                                                                                     ");
		sql.append("        B.ADM_CODE_NAME,                                                                                ");
		sql.append("        B.ADM_MEMO,                                                                                     ");
		sql.append("        B.BUND_NUM,                                                                                     ");
		sql.append("        B.MEMO,                                                                                         ");
		sql.append("        C.PK_SEQ,                                                                                       ");
		sql.append("        C.SUB_CODE,                                                                                     ");
		sql.append("        C.ACT_CODE,                                                                                     ");
		sql.append("        C.ACT_CODE_NAME,                                                                                ");
		sql.append("        C.ACT_CODE_TD,                                                                                  ");
		sql.append("        C.ALIAS_CODE,                                                                                   ");
		sql.append("        C.NUM_CODE,                                                                                     ");
		sql.append("        C.NUM_UNIT,                                                                                     ");
		sql.append("        C.NUM_SU,                                                                                       ");
		sql.append("        C.DURATION,                                                                                     ");
		sql.append("        DATE_FORMAT(C.EVENT_START, '%Y/%m/%d') EVENT_START,                                             ");
		sql.append("        DATE_FORMAT(C.EVENT_END, '%Y/%m/%d') EVENT_END,                                                 ");
		sql.append("        C.EVENT_NAME,                                                                                   ");
		sql.append("        C.ACT_MEMO                                                                                      ");
		sql.append(" FROM OIF4001 A LEFT JOIN OIF4003 C ON A.PKOIF4001 = C.FKOIF4001 AND A.FKOIF1101 = C.FKOIF1101,         ");
		sql.append("      OIF4002 B                                                                                         ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                       ");
		sql.append("   AND A.FKOIF1101 = :f_fkoif1101                                                                       ");
		sql.append("   AND A.END_FLAG = 'N'                                                                                 ");
		sql.append("   AND A.FKOIF1101 = B.FKOIF1101                                                                        ");
		sql.append("   AND A.PKOIF4001 = B.FKOIF4001                                                                        ");
		sql.append("   AND B.PKOIF4002 = C.FKOIF4002                                                                        ");
		sql.append(" ORDER BY B.PKOIF4002,  C.PK_SEQ																		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkoif1101", fkoif1101);
		
		List<ORCALibGetClaimOrderInfo> list = new JpaResultMapper().list(query, ORCALibGetClaimOrderInfo.class);
		return list;
	}
}

