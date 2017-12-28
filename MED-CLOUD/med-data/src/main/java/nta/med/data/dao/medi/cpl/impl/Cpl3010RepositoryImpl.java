package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl3010RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL3020U02GrdPaListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02GrdResultListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl3010RepositoryImpl implements Cpl3010RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL3020U02GrdPaListItemInfo> getCPL3020U02GrdPaListItemInfo(String hospCode, String fromDate, String toDate, String jangbiCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                               ");
		 sql.append("      SUBSTR(A.LAB_NO,7,4)                                                   LAB_NO                           ");
		 sql.append("    , C.SUNAME                                                               SUNAME                           ");
		 sql.append("    , A.SPECIMEN_SER                                                         SPECIMEN_SER                     ");
		 sql.append("    , A.LAB_NO                                                               LAB_SORT                         ");
		 sql.append("    , A.PART_JUBSU_DATE                                                      PART_JUBSU_DATE                  ");
		 sql.append("    , A.JUNDAL_GUBUN                                                         JUNDAL_GUBUN                     ");
		 sql.append("    , ''                                                                     GUBUN                            ");
		 sql.append("    , FN_CPL_SPECIMEN_SER_RESULT_YN(:f_hosp_code,A.SPECIMEN_SER, A.JUNDAL_GUBUN)         RESULT_YN            ");
		 sql.append("    , FN_CPL_SPECIMEN_SER_CONFIRM_YN(:f_hosp_code,A.SPECIMEN_SER, A.JUNDAL_GUBUN)         CONFIRM_YN          ");
		 sql.append(" FROM OUT0101 C,                                                                                              ");
		 sql.append("      CPL2010 B,                                                                                              ");
		 sql.append("      CPL3010 A                                                                                               ");
		 sql.append("WHERE A.HOSP_CODE = :f_hosp_code                                                                              ");
		 sql.append("  AND B.HOSP_CODE = A.HOSP_CODE                                                                               ");
		 sql.append("  AND C.HOSP_CODE = A.HOSP_CODE                                                                               ");
		 sql.append("  AND A.PART_JUBSU_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')   ");
		 sql.append("  AND B.JANGBI_CODE = :f_jangbi_code                                                                          ");
		 sql.append("  AND B.SPECIMEN_SER = A.SPECIMEN_SER                                                                         ");
		 sql.append("  AND C.BUNHO = B.BUNHO                                                                                       ");
		 sql.append("ORDER BY SPECIMEN_SER DESC                                                                                    ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_jangbi_code", jangbiCode);
		List<CPL3020U02GrdPaListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02GrdPaListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3020U02GrdResultListItemInfo> getCPL3020U02GrdResultListItemInfo(String hospCode, String specimenSer, String labNo, String jundalGubun){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT C.PKCPL3020                         PKCPL3020,                                                                  ");  
		 sql.append("      CONCAT(IF(C.HANGMOG_CODE = C.SOURCE_GUMSA, '', '   ') , D.GUMSA_NAME )                       GUMSA_NAME,         ");
		 sql.append("      C.STANDARD_YN                        STANDARD_YN,                                                                ");
		 sql.append("      C.CPL_RESULT                         CPL_RESULT,                                                                 ");
		 sql.append("      C.CONFIRM_YN                         CONFIRM_YN,                                                                 ");
		 sql.append("      C.BEFORE_RESULT                      BEFORE_RESULT,                                                              ");
		 sql.append("      C.PANIC_YN                           PANIC_YN,                                                                   ");
		 sql.append("      C.DELTA_YN                           DELTA_YN,                                                                   ");
		 sql.append("      E.CODE_NAME                          DANUI_NAME,                                                                 ");
		 sql.append("      IF(C.TO_STANDARD IS NULL,C.FROM_STANDARD,CONCAT(C.FROM_STANDARD , ' ~ ' , C.TO_STANDARD))    STANDARD,           ");
		 sql.append("      C.COMMENTS                           COMMENTS,                                                                   ");
		 sql.append("      IF(A.IN_OUT_GUBUN = 'I',A.FKOCS2003,A.FKOCS1003)    FKOCS,                                                       ");
		 sql.append("      C.FKCPL2010                          FKCPL2010,                                                                  ");
		 sql.append("      C.LAB_NO                             LAB_NO,                                                                     ");
		 sql.append("      C.HANGMOG_CODE                       HANGMOG_CODE,                                                               ");
		 sql.append("      C.SPECIMEN_CODE                      SPECIMEN_CODE,                                                              ");
		 sql.append("      C.EMERGENCY                          EMERGENCY,                                                                  ");
		 sql.append("      C.GUMSAJA                            GUMSAJA,                                                                    ");
		 sql.append("      A.BUNHO                              BUNHO,                                                                      ");
		 sql.append("      C.RESULT_DATE                        RESULT_DATE,                                                                ");
		 sql.append("      :f_specimen_ser                      SPECIMEN_SER,                                                               ");
		 sql.append("      C.RESULT_FORM                        RESULT_FORM,                                                                ");
		 sql.append("      C.SOURCE_GUMSA                       SOURCE_GUMSA,                                                               ");
		 sql.append("      D.GROUP_GUBUN                        GROUP_GUBUN,                                                                ");
		 sql.append("      C.SOURCE_GUMSA                       GROUP_HANGMOG,                                                              ");
		 sql.append("      IFNULL(C.DISPLAY_YN,'Y')                DISPLAY_YN,                                                              ");
		 sql.append("      CONCAT(LPAD(C.FKCPL2010,10,'0'),LPAD(C.PKCPL3020,10,'0')) AS  KEY1                                               ");
		 sql.append(" FROM CPL0109 E RIGHT OUTER JOIN CPL0101 D ON E.HOSP_CODE = D.HOSP_CODE AND E.CODE = D.DANUI AND E.CODE_TYPE = '03',   ");
		 sql.append("      CPL3020 C,                                                                                                       ");
		 sql.append("      CPL2010 A                                                                                                        ");
		 sql.append("WHERE A.HOSP_CODE        = :f_hosp_code                                                                                ");
		 sql.append("  AND C.HOSP_CODE        = A.HOSP_CODE                                                                                 ");
		 sql.append("  AND D.HOSP_CODE        = A.HOSP_CODE                                                                                 ");
		 sql.append("  AND C.LAB_NO           = :f_lab_no                                                                                   ");
		 sql.append("  AND A.SPECIMEN_SER     = :f_specimen_ser                                                                             ");
		 sql.append("  AND A.JUNDAL_GUBUN     = :f_jundal_gubun                                                                             ");
		 sql.append("  AND A.PKCPL2010        = C.FKCPL2010                                                                                 ");
		 sql.append("  AND C.HANGMOG_CODE     = D.HANGMOG_CODE                                                                              ");
		 sql.append("  AND C.SPECIMEN_CODE    = D.SPECIMEN_CODE                                                                             ");
		 sql.append("  AND C.EMERGENCY        = D.EMERGENCY                                                                                 ");
		 sql.append("  AND C.JANGBI_CODE      = D.JANGBI_CODE                                                                               ");
		 sql.append("ORDER BY C.PKCPL3020                                                                                                   ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_lab_no", labNo);
		query.setParameter("f_jundal_gubun", jundalGubun);
		List<CPL3020U02GrdResultListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02GrdResultListItemInfo.class);
		return list;
	}
}

