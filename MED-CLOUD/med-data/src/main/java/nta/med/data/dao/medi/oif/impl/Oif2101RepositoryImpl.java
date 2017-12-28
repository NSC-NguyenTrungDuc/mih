package nta.med.data.dao.medi.oif.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.oif.Oif2101RepositoryCustom;
import nta.med.data.model.ihis.orca.ORCALibGetClaimInsuredInfo;

/**
 * @author dainguyen.
 */
public class Oif2101RepositoryImpl implements Oif2101RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORCALibGetClaimInsuredInfo> getORCALibGetClaimInsuredInfo(String hospCode, Double fkoif1101) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SYS_DATE,                                                                                           ");
		sql.append("        A.SYS_ID,                                                                                             ");
		sql.append("        DATE_FORMAT(A.UPD_DATE, '%Y/%m/%d') UPD_DATE,                                                         ");
		sql.append("        A.UPD_ID,                                                                                             ");
		sql.append("        A.HOSP_CODE,                                                                                          ");
		sql.append("        A.FKOIF1101,                                                                                          ");
		sql.append("        A.PKOIF2101,                                                                                          ");
		sql.append("        A.DOC_UID,                                                                                            ");
		sql.append("        A.CM_ID,                                                                                              ");
		sql.append("        A.DEP_ID,                                                                                             ");
		sql.append("        FN_OIF_LOAD_OIF0102_CODE_NAME(:f_hosp_code, 'GWA', A.DEP_ID) DEP_NAME,                                ");
		sql.append("        A.LICENSE,                                                                                            ");
		sql.append("        A.INSUR_CODE,                                                                                         ");
		sql.append("        A.INSUR_NAME,                                                                                         ");
		sql.append("        A.INSUR_NUM,                                                                                          ");
		sql.append("        A.CLIENT_GROUP,                                                                                       ");
		sql.append("        A.CLIENT_NUM,                                                                                         ");
		sql.append("        A.FAMILY_CODE,                                                                                        ");
		sql.append("        A.SUNAME1,                                                                                            ");
		sql.append("        A.SUNAME2,                                                                                            ");
		sql.append("        A.SUNAME3,                                                                                            ");
		sql.append("        DATE_FORMAT(A.START_DATE, '%Y/%m/%d') START_DATEA,                                                    ");
		sql.append("        DATE_FORMAT(A.END_DATE, '%Y/%m/%d') END_DATEA,                                                        ");
		sql.append("        A.INRATIO,                                                                                            ");
		sql.append("        A.OUTRATIO,                                                                                           ");
		sql.append("        A.INSURED_ID,                                                                                         ");
		sql.append("        A.INSURED_NAME,                                                                                       ");
		sql.append("        A.WORK_ID,                                                                                            ");
		sql.append("        A.WORK_NAME,                                                                                          ");
		sql.append("        B.PK_SEQ PKOIF2102,                                                                                   ");
		sql.append("        B.PRIORITY,                                                                                           ");
		sql.append("        B.PROVIDER_NAME,                                                                                      ");
		sql.append("        B.PROVIDER,                                                                                           ");
		sql.append("        B.RECIPIENT,                                                                                          ");
		sql.append("        DATE_FORMAT(B.START_DATE, '%Y/%m/%d') START_DATEB,                                                    ");
		sql.append("        DATE_FORMAT(B.END_DATE, '%Y/%m/%d') END_DATEB,                                                        ");
		sql.append("        B.RATIO_TYPE,                                                                                         ");
		sql.append("        B.RATIO,                                                                                              ");
		sql.append("        C.PK_SEQ PKOIF2103,                                                                                   ");
		sql.append("        C.DISEASES,                                                                                           ");
		sql.append("        D.PK_SEQ PKOIF2104,                                                                                   ");
		sql.append("        D.GUBUN_CODE ADDRESS,                                                                                 ");
		sql.append("        D.ADDR_CODE,                                                                                          ");
		sql.append("        D.ADDR_FULL,                                                                                          ");
		sql.append("        D.PREFECTURE,                                                                                         ");
		sql.append("        D.CITY        CITYD,                                                                                  ");
		sql.append("        D.TOWN,                                                                                               ");
		sql.append("        D.HOME_NUM,                                                                                           ");
		sql.append("        D.ZIP,                                                                                                ");
		sql.append("        D.COUNTRY   COUNTRYD,                                                                                 ");
		sql.append("        E.PK_SEQ PKOIF2105,                                                                                   ");
		sql.append("        E.GUBUN_CODE PHONE,                                                                                   ");
		sql.append("        E.TEL_CODE,                                                                                           ");
		sql.append("        E.AREA,                                                                                               ");
		sql.append("        E.CITY CITYE,                                                                                         ");
		sql.append("        E.NUM,                                                                                                ");
		sql.append("        E.EXTENSION,                                                                                          ");
		sql.append("        E.COUNTRY  COUNTRYE,                                                                                  ");
		sql.append("        E.MEMO                                                                                                ");
		sql.append(" FROM OIF2101 A LEFT JOIN OIF2102 B ON A.FKOIF1101 = B.FKOIF1101 AND A.PKOIF2101 = B.FKOIF2101                ");
		sql.append(" 				LEFT JOIN OIF2103 C ON A.FKOIF1101 = C.FKOIF1101  AND A.PKOIF2101 = C.FKOIF2101               ");
		sql.append(" 					LEFT JOIN OIF2104 D ON A.FKOIF1101 = D.FKOIF1101 AND A.PKOIF2101 = D.FKOIF2101            ");
		sql.append(" 						LEFT JOIN OIF2105 E ON A.FKOIF1101 = E.FKOIF1101 AND A.PKOIF2101 = E.FKOIF2101        ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("   AND A.FKOIF1101 = :f_fkoif1101                                                                             ");
		sql.append("   AND A.END_FLAG = 'N'                                                                                       ");
		sql.append(" ORDER BY A.PKOIF2101, B.PK_SEQ																				  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkoif1101", fkoif1101);
		List<ORCALibGetClaimInsuredInfo> list = new JpaResultMapper().list(query, ORCALibGetClaimInsuredInfo.class);
		return list;
	}
}

