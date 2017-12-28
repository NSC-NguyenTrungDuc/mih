package nta.med.data.dao.medi.oif.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.oif.Oif1101RepositoryCustom;
import nta.med.data.model.ihis.orca.ORCALibAcquisitionInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimPatientInfo;

/**
 * @author dainguyen.
 */
public class Oif1101RepositoryImpl implements Oif1101RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORCALibGetClaimPatientInfo> getORCALibGetClaimPatientInfo(String hospCode, Double fkoif1101) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.UPD_DATE,'%Y/%m/%d') UPD_DATE,                    ");
		sql.append("        A.UPD_ID,                                                       ");
		sql.append("        A.HOSP_CODE,                                                    ");
		sql.append("        A.PKOIF1101,                                                    ");
		sql.append("        A.DOC_UID,                                                      ");
		sql.append("        A.CM_ID,                                                        ");
		sql.append("        A.LICENSE,                                                      ");
		sql.append("        A.BUNHO,                                                        ");
		sql.append("        A.SUNAME1,                                                      ");
		sql.append("        A.SUNAME2,                                                      ");
		sql.append("        A.SUNAME3,                                                      ");
		sql.append("        A.DEGREE,                                                       ");
		sql.append("        A.SEX,                                                          ");
		sql.append("        DATE_FORMAT(A.BIRTH,'%Y/%m/%d') BIRTH,                          ");
		sql.append("        A.NATIONALITY,                                                  ");
		sql.append("        A.MARITAL,                                                      ");
		sql.append("        A.ACCNT_NUM,                                                    ");
		sql.append("        A.SOCIALID,                                                     ");
		sql.append("        A.EMAIL,                                                        ");
		sql.append("        A.DEATH,                                                        ");
		sql.append("        A.DEATH_DATE,                                                   ");
		sql.append("        A.END_FLAG,                                                     ");
		sql.append("        B.PK_SEQ PKOIF1102,                                             ");
		sql.append("        B.ADDR_CODE,                                                    ");
		sql.append("        B.ADDR_FULL,                                                    ");
		sql.append("        B.PREFECTURE,                                                   ");
		sql.append("        B.CITY  CITYB,                                                  ");
		sql.append("        B.TOWN,                                                         ");
		sql.append("        B.HOME_NUM,                                                     ");
		sql.append("        B.ZIP,                                                          ");
		sql.append("        B.COUNTRY           COUNTRYB,                                   ");
		sql.append("        C.PK_SEQ PKOIF1103,                                             ");
		sql.append("        C.TEL_CODE,                                                     ");
		sql.append("        C.AREA,                                                         ");
		sql.append("        C.CITY  CITYC,                                                  ");
		sql.append("        C.NUM,                                                          ");
		sql.append("        C.EXTENSION,                                                    ");
		sql.append("        C.COUNTRY           COUNTRYC,                                   ");
		sql.append("        C.MEMO                                                          ");
		sql.append(" FROM OIF1101 A LEFT JOIN OIF1102 B  ON A.PKOIF1101 = B.FKOIF1101       ");
		sql.append("                LEFT JOIN OIF1103 C  ON A.PKOIF1101 = C.FKOIF1101       ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                       ");
		sql.append("   AND A.PKOIF1101 = :f_fkoif1101                                       ");
		sql.append("   AND A.END_FLAG = 'N'													");
		
		Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkoif1101", fkoif1101);
		List<ORCALibGetClaimPatientInfo> list = new JpaResultMapper().list(query, ORCALibGetClaimPatientInfo.class);
		return list;
	}

	@Override
	public List<ORCALibAcquisitionInfo> getORCALibAcquisitionInfo(String hospCode, Double fkoif1101) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.UPD_DATE,'%Y/%m/%d') UPD_DATE,               ");
		sql.append("        A.UPD_ID,                                                  ");
		sql.append("        A.HOSP_CODE,                                               ");
		sql.append("        A.PKOIF1101,                                               ");
		sql.append("        A.DOC_UID,                                                 ");
		sql.append("        A.CM_ID,                                                   ");
		sql.append("        A.LICENSE,                                                 ");
		sql.append("        A.BUNHO,                                                   ");
		sql.append("        A.SUNAME1,                                                 ");
		sql.append("        A.SUNAME2,                                                 ");
		sql.append("        A.SUNAME3,                                                 ");
		sql.append("        A.DEGREE,                                                  ");
		sql.append("        A.SEX,                                                     ");
		sql.append("        DATE_FORMAT(A.BIRTH, '%Y/%m/%d') BIRTH,                    ");
		sql.append("        A.NATIONALITY,                                             ");
		sql.append("        A.MARITAL,                                                 ");
		sql.append("        A.ACCNT_NUM,                                               ");
		sql.append("        A.SOCIALID,                                                ");
		sql.append("        A.EMAIL,                                                   ");
		sql.append("        A.DEATH,                                                   ");
		sql.append("        A.DEATH_DATE,                                              ");
		sql.append("        A.END_FLAG,                                                ");
		sql.append("        B.PK_SEQ PKOIF1102,                                        ");
		sql.append("        B.ADDR_CODE,                                               ");
		sql.append("        B.ADDR_FULL,                                               ");
		sql.append("        B.PREFECTURE,                                              ");
		sql.append("        B.CITY           CITYB,                                    ");
		sql.append("        B.TOWN,                                                    ");
		sql.append("        B.HOME_NUM,                                                ");
		sql.append("        B.ZIP,                                                     ");
		sql.append("        B.COUNTRY         COUNTRYB,                                ");
		sql.append("        C.PK_SEQ PKOIF1103,                                        ");
		sql.append("        C.TEL_CODE,                                                ");
		sql.append("        C.AREA,                                                    ");
		sql.append("        C.CITY                  CITYC,                             ");
		sql.append("        C.NUM,                                                     ");
		sql.append("        C.EXTENSION,                                               ");
		sql.append("        C.COUNTRY                  COUNTRYC,                       ");
		sql.append("        C.MEMO,                                                    ");
		sql.append("        D.PK_SEQ PKOIF1104,                                        ");
		sql.append("        D.RD_CODE,                                                 ");
		sql.append("        D.RD_NAME,                                                 ");
		sql.append("        D.CATEGORY1,                                               ");
		sql.append("        D.CATEGORY2,                                               ");
		sql.append("        D.CATEGORY3,                                               ");
		sql.append("        D.CATEGORY4,                                               ");
		sql.append("        D.OUTCOME,                                                 ");
		sql.append("        D.UUID,                                                    ");
		sql.append("        DATE_FORMAT(D.FIRSTDATE, '%Y/%m/%d') FIRSTDATE,            ");
		sql.append("        DATE_FORMAT(D.STARTDATE, '%Y/%m/%d') STARTDATE,            ");
		sql.append("        DATE_FORMAT(D.ENDDATE, '%Y/%m/%d') ENDDATE                 ");
		sql.append(" FROM OIF1101 A LEFT JOIN OIF1102 B ON A.PKOIF1101 = B.FKOIF1101   ");
		sql.append(" 			LEFT JOIN OIF1103 C ON  A.PKOIF1101 = C.FKOIF1101      ");
		sql.append(" 				LEFT JOIN OIF1104 D ON A.PKOIF1101 = D.FKOIF1101   ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                  ");
		sql.append("   AND A.PKOIF1101 = :f_fkoif1101                                  ");
		sql.append("   AND A.END_FLAG = 'N'											   ");		

		Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkoif1101", fkoif1101);
		List<ORCALibAcquisitionInfo> list = new JpaResultMapper().list(query, ORCALibAcquisitionInfo.class);
		return list;
	}
}

