package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg1000RepositoryCustom;
import nta.med.data.model.ihis.drgs.DRG3010P10LayAntiDataInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01AntiDataListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LayAntiDataListItemInfo;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Drg1000RepositoryImpl implements Drg1000RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Drg1000RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DrgsDRG5100P01AntiDataListItemInfo> getDrgsDRG5100P01OrderListItemInfo(String hospitalCode, String fkocs){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  A.FKOCS               FKOCS            ");
		sql.append("      , A.IN_OUT_GUBUN        IN_OUT_GUBUN     ");
		sql.append("      , A.ORDER_DATE          ORDER_DATE       ");
		sql.append("      , A.BUNHO               BUNHO            ");
		sql.append("      , A.GWA                 GWA              ");
		sql.append("      , A.DOCTOR              DOCTOR           ");
		sql.append("      , A.HO_DONG             HO_DONG          ");
		sql.append("      , A.IPWON_DATE          IPWON_DATE       ");
		sql.append("      , A.JUBSU_DATE          JUBSU_DATE       ");
		sql.append("      , A.V1                  V1               ");
		sql.append("      , A.V2                  V2               ");
		sql.append("      , A.V3                  V3               ");
		sql.append("      , A.V4                  V4               ");
		sql.append("      , A.V5                  V5               ");
		sql.append("      , A.V6                  V6               ");
		sql.append("      , A.V7                  V7               ");
		sql.append("      , A.V8                  V8               ");
		sql.append("      , A.V9                  V9               ");
		sql.append("      , A.CHECK01             CHECK01          ");
		sql.append("      , A.CHECK02             CHECK02          ");
		sql.append("      , A.CHECK03             CHECK03          ");
		sql.append("      , A.CHECK04             CHECK04          ");
		sql.append("      , A.CHECK05             CHECK05          ");
		sql.append("      , A.CHECK06             CHECK06          ");
		sql.append("      , A.CHECK07             CHECK07          ");
		sql.append("      , A.CHECK08             CHECK08          ");
		sql.append("      , A.CHECK09             CHECK09          ");
		sql.append("      , A.CHECK10             CHECK10          ");
		sql.append("      , A.CHECK11             CHECK11          ");
		sql.append("      , A.CHECK12             CHECK12          ");
		sql.append("      , A.CHECK13             CHECK13          ");
		sql.append("      , A.CHECK14             CHECK14          ");
		sql.append("      , A.CHECK15             CHECK15          ");
		sql.append("      , A.CHECK16             CHECK16          ");
		sql.append("      , A.CHECK17             CHECK17          ");
		sql.append("      , A.CHECK18             CHECK18          ");
		sql.append("      , A.CHECK19             CHECK19          ");
		sql.append("      , A.CHECK20             CHECK20          ");
		sql.append("      , A.CHECK21             CHECK21          ");
		sql.append("      , A.CHECK22             CHECK22          ");
		sql.append("      , A.CHECK23             CHECK23          ");
		sql.append("      , A.CHECK24             CHECK24          ");
		sql.append("      , A.CHECK25             CHECK25          ");
		sql.append("      , A.CHECK26             CHECK26          ");
		sql.append("      , A.CHECK27             CHECK27          ");
		sql.append("      , A.CHECK28             CHECK28          ");
		sql.append("      , A.CHECK29             CHECK29          ");
		sql.append("      , A.CHECK30             CHECK30          ");
		sql.append("      , A.CHECK31             CHECK31          ");
		sql.append("      , A.CHECK32             CHECK32          ");
		sql.append("      , A.CHECK33             CHECK33          ");
		sql.append("      , A.CHECK34             CHECK34          ");
		sql.append("      , A.CHECK35             CHECK35          ");
		sql.append("      , A.CHECK36             CHECK36          ");
		sql.append("      , A.CHECK37             CHECK37          ");
		sql.append("      , A.CHECK38             CHECK38          ");
		sql.append("      , A.CHECK39             CHECK39          ");
		sql.append("      , A.CHECK40             CHECK40          ");
		sql.append("      , A.CHECK41             CHECK41          ");
		sql.append("      , A.CHECK42             CHECK42          ");
		sql.append("      , A.CHECK43             CHECK43          ");
		sql.append("      , A.CHECK44             CHECK44          ");
		sql.append("      , A.CHECK45             CHECK45          ");
		sql.append("      , A.CHECK46             CHECK46          ");
		sql.append("      , A.CHECK47             CHECK47          ");
		sql.append("      , A.CHECK48             CHECK48          ");
		sql.append("      , A.CHECK49             CHECK49          ");
		sql.append("      , A.CHECK50             CHECK50          ");
		sql.append("      , B.SUNAME              SUNAME           ");
		sql.append("      , B.SUNAME2             SUNAME2          ");
		sql.append("   FROM OUT0101 B,                             ");
		sql.append("        DRG1000 A                              ");
		sql.append("  WHERE A.HOSP_CODE   = :hospitalCode          ");
		if(!StringUtils.isEmpty(fkocs)) {
			sql.append("    AND A.FKOCS       = :fkocs    	       ");
		}
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE            ");
		sql.append("    AND B.BUNHO       = A.BUNHO                ");
		sql.append("  ORDER BY 3 DESC                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(!StringUtils.isEmpty(fkocs)) {
			query.setParameter("fkocs", fkocs);
		}
		List<DrgsDRG5100P01AntiDataListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01AntiDataListItemInfo.class);
		return list;
	}

	@Override
	public List<String> getDrgsDRG5100P01FkocList(String hospCode, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.FKOCS                         						");
		sql.append("   FROM DRG1000 B                       						");
		sql.append("       ,DRG2010 A                       						");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code     						");
		sql.append("    AND A.JUBSU_DATE = DATE_FORMAT(:f_jubsu_date,'%Y/%m/%d')    ");
		sql.append("    AND A.DRG_BUNHO  = :f_drg_bunho                             ");
		sql.append("    AND B.HOSP_CODE  = A.HOSP_CODE                              ");
		sql.append("    AND B.FKOCS      = A.FKOCS1003                              ");
		sql.append(" UNION                                                          ");
		sql.append(" SELECT B.FKOCS                                                 ");
		sql.append("   FROM DRG1000 B                                               ");
		sql.append("       ,DRG3010 A                                               ");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                             ");
		sql.append("    AND A.JUBSU_DATE = DATE_FORMAT(:f_jubsu_date,'%Y/%m/%d')    ");
		sql.append("    AND A.DRG_BUNHO  = :f_drg_bunho                             ");
		sql.append("    AND B.HOSP_CODE  = A.HOSP_CODE                              ");
		sql.append("    AND B.FKOCS      = A.FKOCS2003                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01LayAntiDataListItemInfo> getDrgsDRG5100P01LayAntiDataListItemInfo(String hospCode, String language,
			String fkocs){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE,:f_hosp_code, :f_language)       GWA_NAME          ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE,:f_hosp_code) DOCTOR_NAME                  ");
		sql.append("    FROM OCS1003 B                                                                                 ");
		sql.append("       , DRG1000 A                                                                                 ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                             ");
		sql.append("     AND A.FKOCS        = :f_fkocs                                                                 ");
		sql.append("     AND A.IN_OUT_GUBUN = 'O'                                                                      ");
		sql.append("     AND B.HOSP_CODE    = A.HOSP_CODE                                                              ");
		sql.append("     AND B.PKOCS1003    = A.FKOCS                                                                  ");
		sql.append("  UNION                                                                                            ");
		sql.append("  SELECT FN_BAS_LOAD_GWA_NAME(B.INPUT_GWA, B.ORDER_DATE,:f_hosp_code,:f_language)       GWA_NAME   ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(B.INPUT_DOCTOR, B.ORDER_DATE,:f_hosp_code) DOCTOR_NAME            ");
		sql.append("    FROM OCS2003 B                                                                                 ");
		sql.append("       , DRG1000 A                                                                                 ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                             ");
		sql.append("     AND A.FKOCS        = :f_fkocs                                                                 ");
		sql.append("     AND A.IN_OUT_GUBUN = 'I'                                                                      ");
		sql.append("     AND B.HOSP_CODE    = A.HOSP_CODE                                                              ");
		sql.append("     AND B.PKOCS2003    = A.FKOCS                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkocs", fkocs);
		List<DrgsDRG5100P01LayAntiDataListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01LayAntiDataListItemInfo.class);
		return list;
	}

	@Override
	public List<DRG3010P10LayAntiDataInfo> getDRG3010P10LayAntiDataInfo(String hospCode, String fkocs) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 														");
		sql.append("	  A.FKOCS               FKOCS,								");
		sql.append("	  A.IN_OUT_GUBUN        IN_OUT_GUBUN,						");
		sql.append("	  A.ORDER_DATE          ORDER_DATE,							");
		sql.append("	  A.BUNHO               BUNHO,								");
		sql.append("	  IFNULL(A.GWA, '')                 GWA,					");
		sql.append("	  IFNULL(A.DOCTOR, '')              DOCTOR,					");
		sql.append("	  IFNULL(A.HO_DONG, '')             HO_DONG,				");
		sql.append("	  IFNULL(A.IPWON_DATE, '')          IPWON_DATE,				");
		sql.append("	  IFNULL(A.JUBSU_DATE, '')          JUBSU_DATE,				");
		sql.append("	  IFNULL(A.V1, '')                  V1,						");
		sql.append("	  IFNULL(A.V2, '')                  V2,						");
		sql.append("	  IFNULL(A.V3, '')                  V3,						");
		sql.append("	  IFNULL(A.V4, '')                  V4,						");
		sql.append("	  IFNULL(A.V5, '')                  V5,						");
		sql.append("	  IFNULL(A.V6, '')                  V6,						");
		sql.append("	  IFNULL(A.V7, '')                  V7,						");
		sql.append("	  IFNULL(A.V8, '')                  V8,						");
		sql.append("	  IFNULL(A.V9, '')                  V9,						");
		sql.append("	  IFNULL(A.CHECK01, '')             CHECK01,				");
		sql.append("	  IFNULL(A.CHECK02, '')             CHECK02,				");
		sql.append("	  IFNULL(A.CHECK03, '')             CHECK03,				");
		sql.append("	  IFNULL(A.CHECK04, '')             CHECK04,				");
		sql.append("	  IFNULL(A.CHECK05, '')             CHECK05,				");
		sql.append("	  IFNULL(A.CHECK06, '')             CHECK06,				");
		sql.append("	  IFNULL(A.CHECK07, '')             CHECK07,				");
		sql.append("	  IFNULL(A.CHECK08, '')             CHECK08,				");
		sql.append("	  IFNULL(A.CHECK09, '')             CHECK09,				");
		sql.append("	  IFNULL(A.CHECK10, '')             CHECK10,				");
		sql.append("	  IFNULL(A.CHECK11, '')             CHECK11,				");
		sql.append("	  IFNULL(A.CHECK12, '')             CHECK12,				");
		sql.append("	  IFNULL(A.CHECK13, '')             CHECK13,				");
		sql.append("	  IFNULL(A.CHECK14, '')             CHECK14,				");
		sql.append("	  IFNULL(A.CHECK15, '')             CHECK15,				");
		sql.append("	  IFNULL(A.CHECK16, '')             CHECK16,				");
		sql.append("	  IFNULL(A.CHECK17, '')             CHECK17,				");
		sql.append("	  IFNULL(A.CHECK18, '')             CHECK18,				");
		sql.append("	  IFNULL(A.CHECK19, '')             CHECK19,				");
		sql.append("	  IFNULL(A.CHECK20, '')             CHECK20,				");
		sql.append("	  IFNULL(A.CHECK21, '')             CHECK21,				");
		sql.append("	  IFNULL(A.CHECK22, '')             CHECK22,				");
		sql.append("	  IFNULL(A.CHECK23, '')             CHECK23,				");
		sql.append("	  IFNULL(A.CHECK24, '')             CHECK24,				");
		sql.append("	  IFNULL(A.CHECK25, '')             CHECK25,				");
		sql.append("	  IFNULL(A.CHECK26, '')             CHECK26,				");
		sql.append("	  IFNULL(A.CHECK27, '')             CHECK27,				");
		sql.append("	  IFNULL(A.CHECK28, '')             CHECK28,				");
		sql.append("	  IFNULL(A.CHECK29, '')             CHECK29,				");
		sql.append("	  IFNULL(A.CHECK30, '')             CHECK30,				");
		sql.append("	  IFNULL(A.CHECK31, '')             CHECK31,				");
		sql.append("	  IFNULL(A.CHECK32, '')             CHECK32,				");
		sql.append("	  IFNULL(A.CHECK33, '')             CHECK33,				");
		sql.append("	  IFNULL(A.CHECK34, '')             CHECK34,				");
		sql.append("	  IFNULL(A.CHECK35, '')             CHECK35,				");
		sql.append("	  IFNULL(A.CHECK36, '')             CHECK36,				");
		sql.append("	  IFNULL(A.CHECK37, '')             CHECK37,				");
		sql.append("	  IFNULL(A.CHECK38, '')             CHECK38,				");
		sql.append("	  IFNULL(A.CHECK39, '')             CHECK39,				");
		sql.append("	  IFNULL(A.CHECK40, '')             CHECK40,				");
		sql.append("	  IFNULL(A.CHECK41, '')             CHECK41,				");
		sql.append("	  IFNULL(A.CHECK42, '')             CHECK42,				");
		sql.append("	  IFNULL(A.CHECK43, '')             CHECK43,				");
		sql.append("	  IFNULL(A.CHECK44, '')             CHECK44,				");
		sql.append("	  IFNULL(A.CHECK45, '')             CHECK45,				");
		sql.append("	  IFNULL(A.CHECK46, '')             CHECK46,				");
		sql.append("	  IFNULL(A.CHECK47, '')             CHECK47,				");
		sql.append("	  IFNULL(A.CHECK48, '')             CHECK48,				");
		sql.append("	  IFNULL(A.CHECK49, '')             CHECK49,				");
		sql.append("	  IFNULL(A.CHECK50, '')             CHECK50,				");
		sql.append("	  B.SUNAME              SUNAME,					            ");
		sql.append("	  B.SUNAME2             SUNAME2					            ");
		sql.append("	FROM											            ");
		sql.append("	   DRG1000 A JOIN OUT0101 B 					            ");
		sql.append("	    	ON B.HOSP_CODE   = A.HOSP_CODE			            ");
		sql.append("	    	AND B.BUNHO       = A.BUNHO				            ");
		sql.append("	WHERE											            ");
		sql.append("	   	A.HOSP_CODE   = :f_hosp_code				            ");
		sql.append("	    AND A.FKOCS       = :f_fkocs				            ");
		sql.append("	ORDER BY										            ");
		sql.append("	   ORDER_DATE DESC								            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs", fkocs);
		List<DRG3010P10LayAntiDataInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10LayAntiDataInfo.class);
		return listInfo;
	}
}

