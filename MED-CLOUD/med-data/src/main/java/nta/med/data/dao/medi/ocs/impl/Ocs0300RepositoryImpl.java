package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0300RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0103U14LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0301Info;
import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00GrdOCS0301Info;
import nta.med.data.model.ihis.system.OFMakeTreeViewInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ocs0300RepositoryImpl implements Ocs0300RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs0300RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<OCS0103U14LaySlipCodeTreeInfo> getOCS0103U14LaySlipCodeTreeInfo(String hospCode, String language, String user) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                ");
		sql.append("        A.SLIP_GUBUN       ,A.SLIP_GUBUN_NAME  , B.SLIP_CODE        ,           ");
		sql.append("        B.SLIP_NAME        , 'Y' PFE_CODE_YN    , 0                             ");
		sql.append("   FROM OCS0101 A , OCS0102 B                                                   ");
		sql.append("      , (SELECT CC.HOSP_CODE                                                    ");
		sql.append("              , CC.SLIP_CODE                                                    ");
		sql.append("           FROM OCS0103 CC                                                      ");
		sql.append("          WHERE CC.HOSP_CODE = :f_hosp_code                                     ");
		sql.append("            AND SYSDATE() BETWEEN CC.START_DATE                                 ");
		sql.append("           AND IFNULL(CC.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))           ");
		sql.append("        ) C                                                                     ");
		sql.append("  WHERE B.HOSP_CODE  = :f_hosp_code                                             ");
		sql.append("    AND A.SLIP_GUBUN = 'E' AND A.LANGUAGE = :language                           ");
		sql.append("    AND B.LANGUAGE = A.LANGUAGE                                             	");
		sql.append("    AND B.SLIP_GUBUN = A.SLIP_GUBUN                                             ");
		sql.append("    AND C.HOSP_CODE = B.HOSP_CODE                                               ");
		sql.append("    AND C.SLIP_CODE = B.SLIP_CODE                                               ");
		sql.append("  UNION ALL                                                                     ");
		sql.append(" SELECT DISTINCT                                                                ");
		sql.append("        D.SLIP_GUBUN, D.SLIP_GUBUN_NAME , C.SLIP_CODE                           ");
		sql.append("      , C.SLIP_NAME, 'Y' PFE_CODE_YN , 0                                        ");
		sql.append("   FROM OCS0142 A, (SELECT DISTINCT HOSP_CODE,ORDER_GUBUN,SLIP_CODE             ");
		sql.append("                     FROM OCS0103 WHERE HOSP_CODE = :f_hosp_code) B             ");
		sql.append("                 , OCS0102 C , OCS0101 D                                        ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                            ");
		sql.append("    AND A.INPUT_TAB   = '05'                                                    ");
		sql.append("    AND A.MAIN_YN     = 'N'                                                     ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                             ");
		sql.append("    AND B.ORDER_GUBUN = A.ORDER_GUBUN                                           ");
		sql.append("    AND C.HOSP_CODE   = B.HOSP_CODE                                             ");
		sql.append("    AND C.SLIP_CODE   = B.SLIP_CODE                                             ");
		sql.append("    AND C.LANGUAGE   = D.LANGUAGE                                             	");
		sql.append("    AND D.SLIP_GUBUN  = C.SLIP_GUBUN AND D.LANGUAGE = :language                 ");
		sql.append("  UNION ALL                                                                     ");
		sql.append(" SELECT 'AAAA'    ,'セット検査'  ,B.YAKSOK_CODE                                   ");
		sql.append("       ,B.YAKSOK_NAME ,'U'   PFE_CODE_YN ,B.SEQ                                 ");
		sql.append("   FROM OCS0300 A ,OCS0301 B                                                    ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                          ");
		sql.append("    AND A.MEMB          = 'ADMIN'                                               ");
		sql.append("    AND A.INPUT_TAB     = '05'                                                  ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                           ");
		sql.append("    AND B.FKOCS0300_SEQ = A.PK_SEQ                                              ");
		sql.append("    AND B.MEMB          = A.MEMB                                                ");
		sql.append("  UNION ALL                                                                     ");
		sql.append(" SELECT 'AAAB'  ,'セット検査(個人)' ,B.YAKSOK_CODE                                 ");
		sql.append("       ,B.YAKSOK_NAME,'K'   PFE_CODE_YN ,B.SEQ                                  ");
		sql.append("   FROM OCS0300 A  ,OCS0301 B                                                   ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                          ");
		sql.append("    AND A.MEMB          = :f_user                                               ");
		sql.append("    AND A.INPUT_TAB     = '05'                                                  ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                           ");
		sql.append("    AND B.FKOCS0300_SEQ = A.PK_SEQ                                              ");
		sql.append("    AND B.MEMB          = A.MEMB                                                ");
		sql.append("  UNION ALL                                                                     ");
		sql.append(" SELECT 'MTLA'  ,'セット材料'   ,B.YAKSOK_CODE                                    ");
		sql.append("       ,B.YAKSOK_NAME ,'M'  PFE_CODE_YN,B.SEQ                                   ");
		sql.append("   FROM OCS0300 A,OCS0301 B                                                     ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                          ");
		sql.append("    AND A.MEMB          = 'ADMIN'                                               ");
		sql.append("    AND A.INPUT_TAB     = '00'                                                  ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                           ");
		sql.append("    AND B.FKOCS0300_SEQ = A.PK_SEQ                                              ");
		sql.append("    AND B.MEMB          = A.MEMB                                                ");
		sql.append("  UNION ALL                                                                     ");
		sql.append(" SELECT 'MTLB'    ,'セット材料(個人)' ,B.YAKSOK_CODE                               ");
		sql.append("       ,B.YAKSOK_NAME ,'N'     PFE_CODE_YN ,B.SEQ                               ");
		sql.append("   FROM OCS0300 A,OCS0301 B                                                     ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                          ");
		sql.append("    AND A.MEMB          = :f_user                                               ");
		sql.append("    AND A.INPUT_TAB     = '00'                                                  ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                           ");
		sql.append("    AND B.FKOCS0300_SEQ = A.PK_SEQ                                              ");
		sql.append("    AND B.MEMB          = A.MEMB                                                ");
		sql.append(" ORDER BY 1, 2, 6, 3															");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user", user);
		query.setParameter("language", language);
		
		List<OCS0103U14LaySlipCodeTreeInfo> listResult = new JpaResultMapper().list(query, OCS0103U14LaySlipCodeTreeInfo.class);
		return listResult;
	}
	@Override
	public List<OCS0301Q09GrdOCS0301Info> getOCS0301Q09GrdOCS0301(String hospCode, String language, String memb, String yaksokCode,String inputTab) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT B.MEMB              ,                                                                                        ");
		sql.append("        B.PK_SEQ            ,                                                                                         ");
		sql.append("        B.YAKSOK_GUBUN      ,                                                                                         ");
		sql.append("        B.YAKSOK_GUBUN_NAME ,                                                                                         ");
		sql.append("        A.YAKSOK_CODE       ,                                                                                         ");
		sql.append("        A.YAKSOK_NAME       ,                                                                                         ");
		sql.append("        B.INPUT_TAB       ,                                                                                           ");
		sql.append("        CONCAT(IFNULL(A.MEMB,''),IFNULL(A.YAKSOK_CODE,''))                      PK_YAKSOK,                            ");
		sql.append("        IFNULL(FN_OCS_LOAD_CODE_NAME('INPUT_TAB', B.INPUT_TAB,:f_hosp_code,:f_language), '複合') INPUT_TAB_NAME       ");
		sql.append("   FROM OCS0301 A, OCS0300 B                                                                                          ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                                  ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                                   ");
		sql.append("    AND A.MEMB        = :f_memb                                                                                       ");
		sql.append("    AND A.YAKSOK_CODE LIKE :f_yaksok_code                                                                             ");
		sql.append("    AND B.MEMB        = A.MEMB                                                                                        ");
		sql.append("    AND B.PK_SEQ      = A.FKOCS0300_SEQ                                                                               ");
		sql.append("    AND B.INPUT_TAB   LIKE :f_input_tab                                                                               ");
		sql.append("   ORDER BY B.INPUT_TAB, B.PK_SEQ, A.SEQ																			  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_memb", memb);
		query.setParameter("f_yaksok_code", "%"+yaksokCode+"%");
		query.setParameter("f_input_tab", inputTab);
		List<OCS0301Q09GrdOCS0301Info> listResult = new JpaResultMapper().list(query, OCS0301Q09GrdOCS0301Info.class);
		return listResult;
	}
	@Override
	public String getOCS0301Q09RbtMembCheckedChangedTableOCS0300And0301(
			String hospCode, String id, Double m0300, String m0301) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.YAKSOK_NAME                        ");
		sql.append("  FROM OCS0300 A,OCS0301 B                   ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code            ");
		sql.append("   AND A.MEMB      = :f_id                   ");
		sql.append("   AND A.PK_SEQ    = :f_m0300                ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE         ");
		sql.append("   AND B.FKOCS0300_SEQ = A.PK_SEQ            ");
		sql.append("   AND B.YAKSOK_CODE = :f_m0301				 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_id", id);
		query.setParameter("f_m0300", m0300);
		query.setParameter("f_m0301", m0301); 
		 List<String> listResult= query.getResultList();
		 if(!CollectionUtils.isEmpty(listResult)){
			 return listResult.get(0);
		 }
		return null;
	}
	@Override
	public List<OFMakeTreeViewInfo> getOFMakeTreeView(String hospCode,String memb, String inputTab) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.MEMB,                         ");
		sql.append("        A.PK_SEQ,                       ");
		sql.append("        A.YAKSOK_GUBUN,                 ");
		sql.append("        A.YAKSOK_GUBUN_NAME,            ");
		sql.append("        A.SEQ,                          ");
		sql.append("        A.MEMB_GUBUN,                   ");
		sql.append("        A.INPUT_TAB,                    ");
		sql.append("        'Y'    EXIST_DATA               ");
		sql.append("   FROM OCS0300 A                       ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code      ");
		sql.append("    AND A.MEMB      = :f_memb           ");
		sql.append("    AND A.INPUT_TAB = :f_input_tab      ");
		sql.append("  ORDER BY SEQ							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_input_tab", inputTab);
		List<OFMakeTreeViewInfo> listResult = new JpaResultMapper().list(query, OFMakeTreeViewInfo.class);
		return listResult;
	}
	
	@Override
	public List<OCS0301U00MembGrdInfo> getOcs0300OCS0301U00MembGrdListItem(
			String hospCode, String memb, String inputTab) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT MEMB									");
		sql.append("	     , PK_SEQ                              " );
		sql.append("	     , YAKSOK_GUBUN                        " );
		sql.append("	     , YAKSOK_GUBUN_NAME                   " );
		sql.append("	     , SEQ                                 " );
		sql.append("	     , HOSP_CODE                           " );
		sql.append("	     , MEMB_GUBUN                          " );
		sql.append("	     , INPUT_TAB                           " );
		sql.append("	  FROM OCS0300                             " );
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code            " );
		sql.append("	   AND MEMB = :f_memb                      " );
		sql.append("	   AND INPUT_TAB = :f_input_tab            " );
		sql.append("	 ORDER BY SEQ                              " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_input_tab", inputTab);
		
		List<OCS0301U00MembGrdInfo> list = new JpaResultMapper().list(query, OCS0301U00MembGrdInfo.class);
		return list;
	}
	@Override
	public List<OUTSANGU00GrdOCS0301Info> getOUTSANGU00GrdOCS0301Info(String hospCode, String language, String userId, String sangCode, String yaksokCode, String inputTab) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.MEMB              ,                                                                                   ");  
		sql.append("        B.PK_SEQ            ,                                                                                   ");  
		sql.append("        B.YAKSOK_GUBUN      ,                                                                                   ");  
		sql.append("        B.YAKSOK_GUBUN_NAME ,                                                                                   ");  
		sql.append("        A.YAKSOK_CODE       ,                                                                                   ");  
		sql.append("        A.YAKSOK_NAME       ,                                                                                   ");  
		sql.append("        B.INPUT_TAB       ,                                                                                     ");  
		sql.append("        CONCAT(IFNULL(A.MEMB,''),IFNULL(A.YAKSOK_CODE,''))                      PK_YAKSOK,                      ");  
		sql.append("        IFNULL(FN_OCS_LOAD_CODE_NAME('INPUT_TAB', B.INPUT_TAB,:f_hosp_code,:f_language), '複合') INPUT_TAB_NAME  ");  
		sql.append("   FROM OCS0301 A, OCS0300 B                                                                                    ");  
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                            ");  
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                             ");  
		sql.append("    AND A.MEMB        = :f_memb                                                                                 ");  
		sql.append("    AND A.YAKSOK_CODE LIKE :f_yaksok_code                                                                       ");  
		sql.append("    AND B.MEMB        = A.MEMB                                                                                  ");  
		sql.append("    AND B.PK_SEQ      = A.FKOCS0300_SEQ                                                                         ");  
		sql.append("    AND B.INPUT_TAB   LIKE :f_input_tab                                                                         ");
		sql.append("    AND A.YAKSOK_CODE	IN 		(SELECT  YAKSOK_CODE FROM OCS0307												");
		sql.append("									              WHERE	HOSP_CODE 		= :f_hosp_code                          ");
		sql.append("                                AND MEMB		    = :f_memb                                                   ");
		sql.append("                                AND SANG_CODE	    = :sang_code AND ACTIVE_FLG = 1)                            ");
		sql.append("   ORDER BY B.INPUT_TAB, B.PK_SEQ, A.SEQ																		");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_memb", userId);
		query.setParameter("f_yaksok_code", "%"+yaksokCode+"%");
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("sang_code", sangCode);
		List<OUTSANGU00GrdOCS0301Info> list = new JpaResultMapper().list(query, OUTSANGU00GrdOCS0301Info.class);
		return list; 
	}
}

