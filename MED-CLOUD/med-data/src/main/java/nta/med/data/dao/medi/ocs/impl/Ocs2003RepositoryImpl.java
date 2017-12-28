package nta.med.data.dao.medi.ocs.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP2001U02grdOcs2003Info;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOCS2003Info;
import nta.med.data.model.ihis.inps.OCS2003Q02BatchDeleteProcessInfo;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2003Info;
import nta.med.data.model.ihis.inps.OCS2003R00layPatientInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditIGubunInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12IsUpdateCheckSelectInfo;
import nta.med.data.model.ihis.ocsi.DtMarumeKeyInfo;
import nta.med.data.model.ihis.ocsi.OCS2003P01GrdPatientListInfo;
import nta.med.data.model.ihis.ocsi.OCS2003P01LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q02grdNotActingInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q11dataLayoutMIOInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q11layQueryInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaCurInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNCURInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdDrugOrderInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOcs2017Info;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderdateInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseOcsInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdInpInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintDateInfo;

/**
 * @author dainguyen.
 */
public class Ocs2003RepositoryImpl implements Ocs2003RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ocs2003RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrOcsApplyNdayOrderOCS0103U13(String hospCode, String bunho,Date orderDate) {
		String ioBunho = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_APPLY_NDAY_ORDER ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("IO_FLAG", ioBunho);
		
		Boolean isValid = query.execute();
		ioBunho = (String) query.getOutputParameterValue("IO_FLAG");
		return ioBunho;
	}

	@Override
	public String callFnOcsInsteadModifiedCheck(String hospCode,Double pkocsKey, String inputGubun, String ioGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT FN_OCS_INSTEAD_MODIFIED_CHECK(:f_hosp_code, :f_pkocskey, :f_input_gubun, :f_io_gubun)  ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocskey", pkocsKey);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_io_gubun", ioGubun);
		List<String> listResult=query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public List<OCS0103U12IsUpdateCheckSelectInfo> getOCS0103U12IsUpdateCheckSelect(
			String hospCode, Double pkocs2003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SURYANG, A.DV, A.DV_TIME, A.NALSU ");
		sql.append("	 FROM OCS2003 A                            ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode           ");
		sql.append("	AND A.PKOCS2003 = :pkocs2003             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkocs2003", pkocs2003);
		
		List<OCS0103U12IsUpdateCheckSelectInfo> list = new JpaResultMapper().list(query, OCS0103U12IsUpdateCheckSelectInfo.class);
		return list;
	}

	@Override
	public String getOCS0103U12ProtectGroupControl(String hospCode,
			String bunho, Date orderDate, Double groupSer) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT COUNT(*)																");
		sql.append("	FROM OCS2003 B, (SELECT A.PKOCS2003                                        " );
		sql.append("					 FROM OCS2003 A                                            " );
		sql.append("					 WHERE A.BUNHO           = :bunho                        " );
		sql.append("						AND A.HOSP_CODE     = :hospCode                        " );
		sql.append("						AND A.ORDER_DATE    = :orderDate                    " );
		sql.append("						AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')     " );
		sql.append("						AND IFNULL(A.DC_YN, 'N') = 'N'                         " );
		sql.append("						AND A.NDAY_YN         = 'Y'                            " );
		sql.append("						AND A.NDAY_OCCUR_YN   = 'Y') P                         " );
		sql.append("	WHERE B.HOSP_CODE = :hospCode                                              " );
		sql.append("	AND B.SORT_FKOCSKEY = P.PKOCS2003                                          " );
		sql.append("	AND B.ACTING_DATE IS NOT NULL                                              " );
		sql.append("	AND B.GROUP_SER = :groupSer                                             " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("orderDate", orderDate);
		query.setParameter("groupSer", groupSer);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS0103U12GridColumnProtectModify(String hospCode,String bunho, Date orderDate, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COUNT(*)                                        ");
		sql.append(" FROM OCS2003 B, (SELECT A.PKOCS2003,A.HOSP_CODE        ");
		sql.append("  FROM OCS2003 A                                        ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                      ");
		sql.append("  AND A.BUNHO = :f_bunho                                ");
		sql.append("  AND A.ORDER_DATE = :f_order_date                      ");
		sql.append("  AND A.HANGMOG_CODE = :f_hangmog_code                  ");
		sql.append("  AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')    ");
		sql.append("  AND IFNULL(A.DC_YN, 'N') = 'N'                        ");
		sql.append(" AND A.NDAY_YN = 'Y'                                    ");
		sql.append("  AND A.NDAY_OCCUR_YN = 'Y') P                          ");
		sql.append(" WHERE B.HOSP_CODE = P.HOSP_CODE                        ");
		sql.append(" AND B.SORT_FKOCSKEY = P.PKOCS2003                      ");
		sql.append(" AND B.ACTING_DATE IS NOT NULL							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<String> getOCS0103U12SetSameOrderDateGroupSerListItem(
			String hospCode, Date orderDate, String inputTab, String bunho,
			String inputDoctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT(A.GROUP_SER) GROUP_SER							   ");
		sql.append("	FROM OCS2003 A                                                     "); 
		sql.append("	WHERE A.HOSP_CODE    = :hospCode                                   "); 
		sql.append("	  AND A.ORDER_DATE   = :orderDate                                  "); 
		sql.append("	  AND A.INPUT_TAB    = :inputTab                                   "); 
		sql.append("	  AND A.DC_YN       != 'Y'                                         "); 
		sql.append("	  AND A.BANNAB_YN   != 'Y'                                         "); 
		sql.append("	  AND A.BUNHO        = :bunho                                      "); 
		sql.append("	  AND A.INPUT_DOCTOR = :inputDoctor                                "); 
		sql.append("	  AND A.ACTING_DATE IS NULL                                        "); 
		sql.append("	  AND A.GROUP_SER NOT IN (SELECT DISTINCT(B.GROUP_SER)             "); 
		sql.append("	                            FROM OCS2003 B                         "); 
		sql.append("	                           WHERE B.HOSP_CODE    = :hospCode        "); 
		sql.append("	                             AND B.ORDER_DATE   = :orderDate       "); 
		sql.append("	                             AND B.INPUT_TAB    = :inputTab        "); 
		sql.append("	                             AND B.BUNHO        = :bunho           "); 
		sql.append("	                             AND B.INPUT_DOCTOR = :inputDoctor)    "); 
		sql.append("	  ORDER BY A.GROUP_SER                                             "); 


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("orderDate", orderDate);
		query.setParameter("inputTab", inputTab);
		query.setParameter("bunho", bunho);
		query.setParameter("inputDoctor", inputDoctor);
		
		List<String> listResult = query.getResultList();
		return listResult;
	}

	@Override
	public String callPrOcsDeleteNdayOrder(String hospCode, Double pkOcs2003) {
		String ioBunho = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DELETE_NDAY_ORDER ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2003", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKOCS2003", pkOcs2003);
		query.setParameter("IO_FLAG", ioBunho);
		
		query.execute();
		ioBunho = (String) query.getOutputParameterValue("IO_FLAG");
		return ioBunho;
	}

	@Override
	public Double getMaxSeqOCS0103U13SaveLayout(String hospCode, String bunho,Double inoutKey, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT MAX(SEQ)+1 SEQ                                    ");
		sql.append(" FROM OCS2003                                             ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                           ");
		sql.append(" AND BUNHO = :f_bunho                                     ");
		sql.append(" AND FKINP1001 = :f_in_out_key                            ");
		sql.append(" AND ORDER_DATE = STR_TO_DATE(:f_order_date, '%Y/%m/%d')  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_in_out_key", inoutKey);
		query.setParameter("f_order_date", orderDate);
		List<Double> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<String> getIfNullIfDataSendYnOCS2003(String hospCode,Double pkOcs2003) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.IF_DATA_SEND_YN , 'N') IF_DATA_SEND_YN             ");
		sql.append(" FROM OCS2003 A                                                     ");
		sql.append(" WHERE A.HOSP_CODE =:f_hosp_code AND A.PKOCS2003 = :f_pkocs			");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs", pkOcs2003);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public PrOcsIudBomOrderActInfo callPrOcsIudBomInpOrderAct(String hospCode, String language,
			String iudGubun, String inputId, String inputPart, Date orderDate,
			Double bomSourceKey, Double pkOcs2003, String hangmogCode,
			Double suryang, Date actingDate, String actingTime,
			String orderGubun, Double nalsu, String ordDanui) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_IUD_BOM_INP_ORDER_ACT ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_PART", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BOM_SOURCE_KEY", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_PKOCS2003", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SURYANG", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ORDER_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_NALSU", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORD_DANUI", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_PKOCS2003", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("I_INPUT_PART", inputPart);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_BOM_SOURCE_KEY", bomSourceKey);
		query.setParameter("I_PKOCS2003", pkOcs2003);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_SURYANG", suryang);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_ACTING_TIME", actingTime);
		query.setParameter("I_ORDER_GUBUN", orderGubun);
		query.setParameter("I_NALSU", nalsu);
		query.setParameter("I_ORD_DANUI", ordDanui);
		Boolean isValid = query.execute();
		
		PrOcsIudBomOrderActInfo info = new PrOcsIudBomOrderActInfo();
		info.setIoPkocs2003((Double)query.getOutputParameterValue("IO_PKOCS2003"));
		info.setIoErrMsg((String)query.getOutputParameterValue("IO_ERR_MSG"));
		info.setIoErr((String)query.getOutputParameterValue("IO_ERR"));
		return info;
	}

	@Override
	public List<XRT1002U00LayPrintDateInfo> getXRT1002U00LayPrintDateInfo(
			String hospCode, Date orderDate, String inOutGubun,
			Double fkOut1001, String printOnly, String jundalPart,
			Double pkocs, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                    ");
		sql.append("        IFNULL(IFNULL(G.RESER_DATE, G.HOPE_DATE), :f_order_date)                       PRINT_DATE                   ");
		sql.append("   FROM OCS1003 G                                                                                                   ");
		sql.append("  WHERE :f_in_out_gubun   = 'O'                                                                                     ");
		sql.append("    AND G.HOSP_CODE       = :f_hosp_code                                                                            ");
		sql.append("    AND G.FKOUT1001       = :f_fkout1001                                                                            ");
		sql.append("    AND G.DC_YN           = 'N'                                                                                     ");
		sql.append("    AND G.NALSU           > 0                                                                                       ");
		sql.append("    AND (                                                                                                           ");
		sql.append("          ( :f_print_only = 'Y'                                                                                     ");
		sql.append("            AND G.JUNDAL_PART    = :f_jundal_part                                                                   ");
		sql.append("            AND G.FKOUT1001      = :f_fkout1001 )                                                                   ");
		sql.append("          OR                                                                                                        ");
		sql.append("          ( :f_print_only  != 'Y'                                                                                   ");
		sql.append("            AND G.JUNDAL_PART = ( SELECT X.JUNDAL_PART                                                              ");
		sql.append("                                     FROM OCS1003 X                                                                 ");
		sql.append("                                    WHERE X.PKOCS1003 = :f_pkocs)                                                   ");
		sql.append("            AND G.FKOUT1001 = ( SELECT Z.FKOUT1001                                                                  ");
		sql.append("                                  FROM OCS1003 Z                                                                    ");
		sql.append("                                 WHERE Z.PKOCS1003 = :f_pkocs )                                                     ");
		sql.append("          )                                                                                                         ");
		sql.append("        )                                                                                                           ");
		sql.append(" UNION                                                                                                              ");
		sql.append(" SELECT DISTINCT                                                                                                    ");
		sql.append("        IFNULL(IFNULL(G.RESER_DATE, G.HOPE_DATE), :f_order_date)                       PRINT_DATE                   ");
		sql.append("   FROM OCS2003 G                                                                                                   ");
		sql.append("  WHERE :f_in_out_gubun   = 'I'                                                                                     ");
		sql.append("    AND G.HOSP_CODE       = :f_hosp_code                                                                            ");
		sql.append("    AND G.FKINP1001       = :f_fkinp1001                                                                            ");
		sql.append("    AND G.ORDER_DATE      = :f_order_date                                                                           ");
		sql.append("    AND G.DC_YN           = 'N'                                                                                     ");
		sql.append("    AND G.NALSU           > 0                                                                                       ");
		sql.append("    AND (                                                                                                           ");
		sql.append("          ( :f_print_only = 'Y'                                                                                     ");
		sql.append("            AND G.JUNDAL_PART    = :f_jundal_part                                                                   ");
		sql.append("            AND G.FKINP1001      = :f_fkinp1001 )                                                                   ");
		sql.append("          OR                                                                                                        ");
		sql.append("          ( :f_print_only  != 'Y'                                                                                   ");
		sql.append("            AND G.JUNDAL_PART = ( SELECT X.JUNDAL_PART                                                              ");
		sql.append("                                     FROM OCS2003 X                                                                 ");
		sql.append("                                    WHERE X.PKOCS2003 = :f_pkocs)                                                   ");
		sql.append("            AND G.FKINP1001 = ( SELECT Z.FKINP1001                                                                  ");
		sql.append("                                  FROM OCS2003 Z                                                                    ");
		sql.append("                                 WHERE Z.PKOCS2003 = :f_pkocs )                                                     ");
		sql.append("          )                                                                                                         ");
		sql.append("        )                                                                                                           ");
		sql.append("  ORDER BY 1																										");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate); 
		query.setParameter("f_in_out_gubun", inOutGubun);
		query.setParameter("f_fkout1001", fkOut1001);
		query.setParameter("f_print_only", printOnly);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_pkocs", pkocs);
		query.setParameter("f_fkinp1001", fkinp1001);
		List<XRT1002U00LayPrintDateInfo> list = new JpaResultMapper().list(query, XRT1002U00LayPrintDateInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getNut0001U00InitializeScreenOcs0203DoctorGwaInfo(
			String hospCode, Double pkocskey) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.INPUT_DOCTOR DOCTOR	      ");
		sql.append("	         , A.INPUT_GWA    GWA         ");
		sql.append("	  FROM OCS2003 A     				  ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code     ");
		sql.append("	   AND A.PKOCS2003 = :f_pkocskey      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocskey", pkocskey);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public Double getNUT0001U00GetNaewonKey(String hospCode, String ioKubun,
			Double pkocs) {
		StringBuilder sql = new StringBuilder();

         sql.append("	SELECT A.FKOUT1001						");
         sql.append("	 FROM OCS1003 A                         ");
         sql.append("	WHERE :f_io_kubun = 'O'                 ");
         sql.append("	  AND A.HOSP_CODE = :f_hosp_code        ");
         sql.append("	  AND A.PKOCS1003 = :f_pkocs            ");
         sql.append("	UNION                                   ");
         sql.append("	SELECT A.FKINP1001                      ");
         sql.append("	 FROM OCS2003 A                         ");
         sql.append("	WHERE :f_io_kubun = 'I'                 ");
         sql.append("	  AND A.HOSP_CODE = :f_hosp_code        ");
         sql.append("	  AND A.PKOCS2003 = :f_pkocs            ");

         Query query = entityManager.createNativeQuery(sql.toString());
 		 query.setParameter("f_hosp_code", hospCode);
 		 query.setParameter("f_io_kubun", ioKubun);
 		 query.setParameter("f_pkocs", pkocs);
 		 
 		 List<Double> result = query.getResultList();
 		 if(!CollectionUtils.isEmpty(result)){
 			 return result.get(0);
 		 }
 		 return null;
	}
	
	@Override
	public List<PHY2001U04GrdInpInfo> getPHY2001U04GrdInpInfo(String hospCode,Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.ORDER_DATE, '%y/%m/%d')      " );
		sql.append("  , A.BUNHO                                        " );
		sql.append("  , B.SUNAME                                       " );
		sql.append("  , B.SUNAME2                                      " );
		sql.append("  , D.DOCTOR_NAME                                  " );
		sql.append("  , A.HANGMOG_CODE                                 " );
		sql.append("  , E.HANGMOG_NAME                                 " );
		sql.append("  , C.PT_FLAG                                      " );
		sql.append("  , C.OT_FLAG                                      " );
		sql.append("  , C.ST_FLAG                                      " );
		sql.append("  , C.BU_FLAG                                      " );
		sql.append("  , A.OCS_FLAG                                     " );
		sql.append("  FROM OCS2003 A                                   " );
		sql.append("  ,OUT0101 B                                       " );
		sql.append("  ,PHY8002 C                                       " );
		sql.append("  ,BAS0270 D                                       " );
		sql.append("  ,OCS0103 E                                       " );
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                 " );
		sql.append("   AND A.ORDER_DATE = :f_order_date                " );
		sql.append("  AND A.INPUT_TAB = '10'                           " );
		sql.append("  AND A.JUNDAL_TABLE = 'HOM'                       " );
		sql.append("  AND A.JUNDAL_PART = 'HOM'                        " );
		sql.append("  AND B.HOSP_CODE = A.HOSP_CODE                    " );
		sql.append("  AND B.BUNHO = A.BUNHO                            " );
		sql.append("  AND C.HOSP_CODE = A.HOSP_CODE                    " );
		sql.append("  AND C.FK_OCS = A.PKOCS2003                       " );
		sql.append("  AND D.HOSP_CODE = A.HOSP_CODE                    " );
		sql.append("  AND D.DOCTOR = A.DOCTOR                          " );
		sql.append("  AND E.HOSP_CODE = A.HOSP_CODE                    " );
		sql.append("  AND E.HANGMOG_CODE = A.HANGMOG_CODE              " );
		sql.append("  ORDER BY A.ORDER_DATE DESC						");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_order_date", orderDate);
		 List<PHY2001U04GrdInpInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdInpInfo.class);
			return list;
	}
	

	@Override
	public BigInteger getPhy8002U01GetLayJissekiDataOcs2003Count(String hospCode,
			Double fkOcs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT COUNT(*) CNT						");
		sql.append("	FROM OCS2003 A                          ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code        ");
		sql.append("	AND A.SORT_FKOCSKEY = :f_fk_ocs         ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fk_ocs", fkOcs);
		
		List<BigInteger> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}


	@Override
	public BigInteger getNewOrderFormINP(String hospCode, Date orderDate,String timeHour, String timeMin, String timeSec) {
		StringBuilder sql = new StringBuilder();
		String time = "000 " + timeHour + ":" + timeMin + ":" + timeSec;
		sql.append(" SELECT COUNT(A.SYS_DATE)                            ");
		sql.append("   FROM OCS2003  A                                   ");
		sql.append("      , PHY8002 C                                    ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                ");
		sql.append("    AND A.ORDER_DATE   = :f_order_date               ");
		sql.append("    AND A.INPUT_TAB    = '10'                        ");
		sql.append("    AND A.JUNDAL_TABLE = 'HOM'                       ");
		sql.append("    AND A.JUNDAL_PART  = 'HOM'                       ");
		sql.append("    AND A.OCS_FLAG     = '1'                         ");
		sql.append("    AND ADDTIME(A.SYS_DATE , :f_time) > SYSDATE()   ");
		sql.append("    AND C.HOSP_CODE = A.HOSP_CODE                    ");
		sql.append("    AND C.FK_OCS    = A.PKOCS2003                    ");
		sql.append("  ORDER BY A.ORDER_DATE DESC						 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_time", time);
		List<BigInteger> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<ORDERTRANSGrdEditIGubunInfo> getORDERTRANSGrdEditInfoCaseElse(
			String hospCode, String language, Double pk1001, String sendYn,
			String bunho, Date orderDate, String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT :f_pk1001                                             pk1001                                                   ");
		sql.append("  , A.PKOCS2003                                                PKOCS                                                    ");
		sql.append("  , A.GROUP_SER                                                GROUP_SER                                                ");
		sql.append("  , IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME                                      ");
		sql.append("  , A.HANGMOG_CODE                                             HANGMOG_CODE                                             ");
		sql.append("  , B.HANGMOG_NAME                                             HANGMOG_NAME                                             ");
		sql.append("  , A.SPECIMEN_CODE                                            SPECIMEN_CODE                                            ");
		sql.append("  , D.SPECIMEN_NAME                                            SPECIMEN_NAME                                            ");
		sql.append("  , A.SURYANG                                                  SURYANG                                                  ");
		sql.append("  , A.ORD_DANUI                                                ORD_DANUI                                                ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code,:f_language)            ORD_DANUI_NAME                 ");
		sql.append("  , A.DV_TIME                                                  DV_TIME                                                  ");
		sql.append("  , A.DV                                                       DV                                                       ");
		sql.append("  , A.NALSU                                                    NALSU                                                    ");
		sql.append("  , A.JUSA                                                     JUSA                                                     ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code,:f_language)                      JUSA_NAME                      ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN, :f_hosp_code,:f_language)  JUSA_SPD_NAME                  ");
		sql.append("  , A.BOGYONG_CODE                                             BOGYONG_CODE                                             ");
		sql.append("  , FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, :f_hosp_code,:f_language)                  ");
		sql.append("  , IFNULL(A.EMERGENCY, 'N')                                      EMERGENCY                                             ");
		sql.append("  , A.JUNDAL_PART                                              JUNDAL_PART                                              ");
		sql.append("  , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN                                          ");
		sql.append("  , ''                                                         DANGIL_GUMSA_ORDER_YN                                    ");
		sql.append("  , A.OCS_FLAG                                                 OCS_FLAG                                                 ");
		sql.append("  , A.ORDER_GUBUN                                              ORDER_GUBUN                                              ");
		sql.append("  , A.BUNHO                                                    BUNHO                                                    ");
		sql.append("  , A.ORDER_DATE                                               ORDER_DATE                                               ");
		sql.append("  , A.INPUT_GWA                                                GWA                                                      ");
		sql.append("  , A.INPUT_DOCTOR                                             DOCTOR                                                   ");
		sql.append("  , A.SEQ                                                      SEQ                                                      ");
		sql.append("  , A.PKOCS2003                                                PKOCS1003                                                ");
		sql.append("  , A.SUB_SUSUL                                                SUB_SUSUL                                                ");
		sql.append("  , A.ACTING_DATE                                              ACTING_DATE                                              ");
		sql.append("  , CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN NULL                                                                       ");
		sql.append("       ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))                                                     ");
		sql.append("    END HOPE_DATE                                                                                                       ");
		sql.append("  , A.SUNAB_DATE                                               SUNAB_DATE                                               ");
		sql.append("  , 'N'                                                        HOME_CARE_YN                                             ");
		sql.append("  , IFNULL(A.REGULAR_YN, 'N')                                     REGULAR_YN                                            ");
		sql.append("  , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN                                          ");
		sql.append("  , E.BUN_CODE                                                 BUN_CODE                                                 ");
		sql.append("  , B.INPUT_CONTROL                                            INPUT_CONTROL                                            ");
		sql.append("  , B.ORDER_GUBUN                                              ORDER_GUBUN_BAS                                          ");
		sql.append("  , CASE WHEN A.JUNDAL_PART in ('HOM') THEN 'Y'                                                                         ");
		sql.append("         WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'                                                                        ");
		sql.append("         ELSE  'N'                                                                                                      ");
		sql.append("    END ACTING_YN                                                                                                       ");
		sql.append("  , :f_send_yn                                                 SELECT_YN                                                ");
		sql.append("  , A.IF_DATA_SEND_YN                                          SEND_YN                                                  ");
		sql.append(" , CONCAT(TRIM(LPAD(C.SORT_KEY, 2, '0'))                                                                                ");
		sql.append("  , TRIM(LPAD(A.GROUP_SER,10, '0'))                                                                                     ");
		sql.append("  , TRIM(LPAD(IFNULL(A.BOM_SOURCE_KEY, A.PKOCS2003),11, '0'))                                                           ");
		sql.append("  , CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9' ELSE '0' END                                                        ");
		sql.append("  , TRIM(LPAD(A.SEQ,11, '0'))                                                                                           ");
		sql.append("  , TRIM(LPAD(A.PKOCS2003,11, '0')))   ORDER_BY_KEY                                                                     ");
		sql.append("  , B.TRIAL_FLG   TRIAL_FLG						                                                                        ");
		sql.append("  , G.CODE_NAME   TRANS_YN						                                                                        ");
		sql.append("   FROM OCS0103 B LEFT JOIN BAS0310 E ON   E.HOSP_CODE = B.HOSP_CODE AND E.SG_CODE = B.SG_CODE                          ");
		sql.append("        RIGHT JOIN OCS2003 A ON B.HOSP_CODE  = A.HOSP_CODE                                                              ");
		sql.append("        AND B.HANGMOG_CODE = A.HANGMOG_CODE AND A.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')  ");
		sql.append("        LEFT JOIN OCS0132 C ON C.HOSP_CODE = A.HOSP_CODE AND C.CODE  = SUBSTR(A.ORDER_GUBUN, 2, 1)                      ");
		sql.append("        AND C.CODE_TYPE  = 'ORDER_GUBUN_BAS'                                                                            ");
		sql.append("        LEFT JOIN OCS0116 D ON D.HOSP_CODE = A.HOSP_CODE AND D.SPECIMEN_CODE = A.SPECIMEN_CODE                          ");
		sql.append("        LEFT JOIN BAS0102 G ON G.HOSP_CODE = A.HOSP_CODE AND G.CODE_TYPE = 'CLIS_FLG' AND G.CODE = 'TRANS_YN'           ");
		sql.append("   WHERE A.HOSP_CODE        = :f_hosp_code                                                                              ");
		sql.append("   AND (                                                                                                                ");
		sql.append("         (                                                                                                              ");
		sql.append("           :f_send_yn = 'Y'                                                                                             ");
		sql.append("           AND                                                                                                          ");
		sql.append("           A.FKINP3010 = :f_pk1001                                                                                      ");
		sql.append("         )                                                                                                              ");
		sql.append("         OR                                                                                                             ");
		sql.append("         (                                                                                                              ");
		sql.append("           :f_send_yn != 'Y'                                                                                            ");
		sql.append("           AND A.FKINP1001        = :f_pk1001                                                                           ");
		sql.append("           AND A.BUNHO            = :f_bunho                                                                            ");
		sql.append("           AND A.ORDER_DATE       = :f_order_date                                                                       ");
		sql.append("           AND IFNULL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn                                                             ");
		sql.append("           AND A.INPUT_GWA        = :f_gwa                                                                              ");
		sql.append("           AND A.INPUT_DOCTOR     = :f_doctor                                                                           ");
		sql.append("         )                                                                                                              ");
		sql.append("       )                                                                                                                ");
		sql.append("     AND A.NALSU            >= 0                                                                                        ");
		sql.append("     AND ( (SUBSTR(A.ORDER_GUBUN, 2, 1)   NOT IN  ('C','D')                                                             ");
		sql.append("              AND IFNULL(A.DC_YN,'N')   = 'N')                                                                          ");
		sql.append("           OR                                                                                                           ");
		sql.append("           (SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C','D')))                                                                  ");
		sql.append("     AND IFNULL(A.MUHYO,'N')   = 'N'                                                                                    ");
		sql.append("     AND IFNULL(A.NDAY_YN,'N') = 'N'                                                                                    ");
		sql.append("     AND A.ORDER_DATE BETWEEN E.SG_YMD AND IFNULL(E.BULYONG_YMD, '9998/12/31')                                          ");
		sql.append("     ORDER BY ORDER_BY_KEY 																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_pk1001", pk1001);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		List<ORDERTRANSGrdEditIGubunInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdEditIGubunInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase0ElseEqualN(
			String hospCode, String language, String ioGubun, String sendYn, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.FKINP1001                                    FKINP1001                                                                                               ");
		sql.append("  , A.BUNHO                                                   BUNHO                                                                                                     ");
		sql.append("  , C.SUNAME                                                  SUNAME                                                                                                    ");
		sql.append("  , B.IPWON_DATE                                              IPWON_DATE                                                                                                ");
		sql.append("  , B.IPWON_TIME                                              IPWON_TIME                                                                                                ");
		sql.append("  , A.INPUT_GWA                                               GWA                                                                                                       ");
		sql.append("  , A.INPUT_DOCTOR                                            DOCTOR                                                                                                    ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME ( A.INPUT_GWA, A.ORDER_DATE, :f_hosp_code,:f_language )        GWA_NAME                                                                        ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME ( A.INPUT_DOCTOR, A.ORDER_DATE , :f_hosp_code)   DOCTOR_NAME                                                                                ");
		sql.append("  , D.GUBUN                                                                                                                                                             ");
		sql.append("  , E.GUBUN_NAME                                              GUBUN_NAME                                                                                                ");
		sql.append("  , IFNULL(E.GONGBI_YN,'Y')                                      GONGBI_YN                                                                                              ");
		sql.append("  , B.CHOJAE                                                                                                                                                            ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE, :f_hosp_code,:f_language )                CHOJAE_NAME                                                                     ");
		sql.append("  , D.PKINP1002                                                                                                                                                         ");
		sql.append("  , MAX(IFNULL(A.ACTING_DATE, A.ORDER_DATE))                     ACTING_DATE                                                                                            ");
		sql.append("  , MAX(IFNULL(A.ACTING_DATE, A.ORDER_DATE))                     ORDER_DATE                                                                                             ");
		sql.append("  , D.GUBUN                                                   GUBUN_OLD                                                                                                 ");
		sql.append("  , B.CHOJAE                                                  CHOJAE_OLD                                                                                                ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 1)   GONGBI_CODE1                                                    ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 2)   GONGBI_CODE2                                                    ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 3)   GONGBI_CODE3                                                    ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 4)   GONGBI_CODE4                                                    ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 1), A.ORDER_DATE, :f_language) GONGBI_CODE1_NAME          ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 2), A.ORDER_DATE, :f_language) GONGBI_CODE2_NAME          ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 3), A.ORDER_DATE, :f_language) GONGBI_CODE3_NAME          ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 4), A.ORDER_DATE, :f_language) GONGBI_CODE4_NAME          ");
		sql.append("  , A.FKINP3010                                               PKOUT                                                                                                     ");
		sql.append("  , A.IF_DATA_SEND_DATE                                       SEND_DATE                                                                                                 ");
		sql.append("  , '1'                                                       SANJUNG_GUBUN                                                                                             ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1', :f_hosp_code,:f_language )      SANJUNG_GUBUN_NAME                                                              ");
		sql.append("  , CASE FN_OUT_LOAD_JUBSU_GUBUN_VALID(:f_hosp_code,A.BUNHO, D.GUBUN, MAX(IFNULL(A.ACTING_DATE, A.ORDER_DATE)))                                                         ");
		sql.append("    WHEN 'N' THEN '1' ELSE '0' END IF_VALID_YN                                                                                                                          ");
		sql.append("  FROM OCS2003 A                                                                                                                                                        ");
		sql.append("     , INP1001 B                                                                                                                                                        ");
		sql.append("     , OUT0101 C                                                                                                                                                        ");
		sql.append("     , INP1002 D                                                                                                                                                        ");
		sql.append("     , BAS0210 E                                                                                                                                                        ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                    ");
		sql.append("    AND A.BUNHO       = :f_bunho                                                                                                                                        ");
		sql.append("    AND IFNULL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn                                                                                                                    ");
		sql.append("    AND IFNULL(A.NDAY_YN,'N') = 'N'                                                                                                                                     ");
		sql.append("    AND A.NALSU            >= 0                                                                                                                                         ");
		sql.append("    AND IFNULL(A.DC_YN,'N')   = 'N'                                                                                                                                     ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("    AND B.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("    AND B.PKINP1001   = A.FKINP1001                                                                                                                                     ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("    AND C.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("    AND D.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("    AND D.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("    AND D.FKINP1001   = A.FKINP1001                                                                                                                                     ");
		sql.append("    AND :f_hosp_code  = D.HOSP_CODE                                                                                                                                     ");
		sql.append("    AND E.GUBUN       = D.GUBUN AND E.LANGUAGE = :f_language                                                                                                            ");
		sql.append("    AND B.IPWON_DATE BETWEEN E.START_DATE                                                                                                                               ");
		sql.append("  AND IFNULL(E.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                                                             ");
		sql.append("      GROUP BY  CASE :f_send_yn WHEN 'Y' THEN A.FKINP3010 ELSE A.FKINP1001 END                                                                                          ");
		sql.append("  , A.BUNHO                                                                                                                                                             ");
		sql.append("  , C.SUNAME                                                                                                                                                            ");
		sql.append("  , B.IPWON_DATE                                                                                                                                                        ");
		sql.append("  , B.IPWON_TIME                                                                                                                                                        ");
		sql.append("  , A.INPUT_GWA                                                                                                                                                         ");
		sql.append("  , A.INPUT_DOCTOR                                                                                                                                                      ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME ( A.INPUT_GWA, A.ORDER_DATE , :f_hosp_code,:f_language )                                                                                       ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME ( A.INPUT_DOCTOR, A.ORDER_DATE , :f_hosp_code)                                                                                              ");
		sql.append("  , D.GUBUN                                                                                                                                                             ");
		sql.append("  , FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, SYSDATE(), :f_hosp_code)                                                                                                            ");
		sql.append("  , B.CHOJAE                                                                                                                                                            ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE, :f_hosp_code,:f_language )                                                                                                ");
		sql.append("  , D.PKINP1002                                                                                                                                                         ");
		sql.append("  , A.FKINP3010                                                                                                                                                         ");
		sql.append("  , A.ORDER_DATE                                                                                                                                                        ");
		sql.append("  , A.IF_DATA_SEND_DATE                                                                                                                                                 ");
		sql.append("  , A.FKINP1001                                                                                                                                                         ");
		sql.append("  , A.ACTING_DATE                                                                                                                                                       ");
		sql.append("  , E.GUBUN_NAME                                                                                                                                                        ");
		sql.append("  , IFNULL(E.GONGBI_YN,'Y')                                                                                                                                             ");
		sql.append("   ORDER BY ACTING_DATE DESC 																																			");																								
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		
		List<ORDERTRANSGrdListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListInfo.class);
		return list;
	}

	// BEGIN MIH
	@Override
	public List<INP2001U02grdOcs2003Info> getListINP2001U02grdOcs2003Info(String hospCode, String language,
			String bunho, Double fkinp1001) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT    A.PKOCS2003 																									");
		sql.append("	        , IFNULL(C.CODE_NAME, 'Etc')                                                  ORDER_GUBUN_NAME					");
		sql.append("	        , A.HANGMOG_CODE                                                              HANGMOG_CODE 						");
		sql.append("	        , B.HANGMOG_NAME                                                              HANGMOG_NAME						");
		sql.append("	        , A.SURYANG                                                                   SURYANG   						");
		sql.append("	        , IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language), '')  ORD_DANUI_NAME		");
		sql.append("	        , A.DV_TIME                                                                   DV_TIME							");
		sql.append("	        , A.DV                                                                        DV								");
		sql.append("	        , A.NALSU                                                                     NALSU								");
		sql.append("	        , IFNULL(D.SPECIMEN_NAME, '')												  SPECIMEN_NAME						");
		sql.append("	 FROM OCS2003 A																											");
		sql.append("	 LEFT JOIN OCS0103 B ON A.HOSP_CODE = B.HOSP_CODE																		");
		sql.append("	                    AND A.HANGMOG_CODE = B.HANGMOG_CODE																	");
		sql.append("	                    AND A.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))	");
		sql.append("	 LEFT JOIN OCS0132 C ON A.HOSP_CODE = C.HOSP_CODE																		");
		sql.append("	                    AND SUBSTR(A.ORDER_GUBUN, 2, 1) = C.CODE															");
		sql.append("	                    AND C.CODE_TYPE = 'ORDER_GUBUN_BAS'																	");
		sql.append("	 LEFT JOIN OCS0116 D ON A.HOSP_CODE = D.HOSP_CODE																		");
		sql.append("	                    AND A.SPECIMEN_CODE = D.SPECIMEN_CODE																");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																						");
		sql.append("	  AND A.BUNHO     = :f_bunho																							");
		sql.append("	  AND A.FKINP1001 = :f_fkinp1001																						");
		sql.append("	  AND A.FKOCS1003 IS NOT NULL																							");
		sql.append("	ORDER BY A.SEQ																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<INP2001U02grdOcs2003Info> lstResult = new JpaResultMapper().list(query, INP2001U02grdOcs2003Info.class);
		return lstResult;
	}

	@Override
	public List<OCS2003R00layPatientInfo> getOCS2003R00layPatientInfo(String hospCode, String language, String gwa,
			String doctor, String inputGubun, String bunho, Double fkinp1001, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT DISTINCT                                                                                                                                            ");
		sql.append("          A.BUNHO                                                                 BUNHO,                                                                       ");
		sql.append("          B.SUNAME                                                                SUNAME,                                                                      ");
		sql.append("          B.SUNAME2                                                               SUNAME2,                                                                     ");
		sql.append("          FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.BIRTH ,:hosp_code, :language)       BIRTH,                                                                	   ");
		sql.append("          FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :hosp_code)                  SEX_AGE,                                                                     ");
		sql.append("          CASE  IFNULL(:gwa, C.GWA) WHEN C.GWA THEN C.DOCTOR ELSE :doctor END     DOCTOR,                                                              		   ");
		sql.append("          FN_BAS_LOAD_DOCTOR_NAME( CASE IFNULL(:gwa, C.GWA) WHEN C.GWA THEN C.DOCTOR ELSE :doctor END, A.ORDER_DATE, :hosp_code)    DOCTOR_NAME,			   ");
		sql.append("          CASE  IFNULL(:gwa, C.GWA) WHEN C.GWA THEN C.GWA ELSE :gwa END                                                             GWA,					   ");
		sql.append("          FN_BAS_LOAD_GWA_NAME( CASE IFNULL(:gwa, C.GWA) WHEN C.GWA THEN C.GWA ELSE :gwa END, A.ORDER_DATE,:hosp_code, :language)   GWA_NAME,					");
		sql.append("          FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE ,:hosp_code, :language)                                                    ORDER_DATE ,				");
		sql.append("          :input_gubun                                    INPUT_GUBUN                                                                                         	");
		sql.append("    FROM OCS2003 A                                                                                                                                   			");
		sql.append("    JOIN OUT0101 B ON A.HOSP_CODE = B.HOSP_CODE																													");
		sql.append("                  AND A.BUNHO = B.BUNHO																															");
		sql.append("    JOIN VW_OCS_INP1001_RES C ON C.HOSP_CODE = A.HOSP_CODE                                                                                                      ");
		sql.append("                             AND C.PKINP1001 = A.FKINP1001																										");
		sql.append("    , (select @kcck_hosp_code\\:=:hosp_code) TMP																												");
		sql.append("    WHERE A.HOSP_CODE         = :hosp_code                                                                                                                 		");
		sql.append("      AND A.BUNHO             = :bunho                                                                                                                     		");
		sql.append("      AND A.FKINP1001         = :fkinp1001                                                                                                                 		");
		sql.append("      AND A.ORDER_DATE        = STR_TO_DATE(:order_date,'%Y/%m/%d')                                                                                        		");
		sql.append("      AND (A.IO_GUBUN IS NULL OR A.IO_GUBUN = '')																												");
		sql.append("      AND A.NALSU             >= 0                                                                                                                         		");
		sql.append("      AND IF(A.DISPLAY_YN IS NULL OR A.DISPLAY_YN = '','Y', A.DISPLAY_YN)  = 'Y'																				");
		sql.append("      AND IF(A.DC_YN IS NULL OR A.DC_YN = '','N', A.DC_YN)       = 'N'																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("gwa", gwa);
		query.setParameter("doctor", doctor);
		query.setParameter("input_gubun", inputGubun);
		query.setParameter("bunho", bunho);
		query.setParameter("fkinp1001", fkinp1001);
		query.setParameter("order_date", orderDate);
		
		
		List<OCS2003R00layPatientInfo> lstResult = new JpaResultMapper().list(query, OCS2003R00layPatientInfo.class);
		return lstResult;
	}

	@Override
	public List<OCS2003R00layOCS2003Info> getOCS2003R00layOCS2003Info(String hospCode, String language, String bunho,
			Double fkinp1001, String orderDate, String inputGubun, String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                            ");
		sql.append(" C.CODE_NAME                                                INPUT_GUBUN_NAME        ,                                                                                   ");
		sql.append(" A.GROUP_SER                                                GROUP_SER               ,                                                                                   ");
		sql.append(" A.MIX_GROUP                                                MIX_GROUP               ,                                                                                   ");
		sql.append(" A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                   ");
		sql.append(" IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN',A.ORDER_GUBUN,:hosp_code, :language),'Etc')     ORDER_GUBUN_NAME        ,                                                   ");
		sql.append(" B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                   ");
		sql.append(" A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                   ");
		sql.append(" B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                                                   ");
		sql.append(" B.SG_CODE                                                  SG_CODE                 ,                                                                                   ");
		sql.append(" IFNULL(E.SG_NAME,B.HANGMOG_NAME)                             SG_NAME                 ,                                                                                 ");
		sql.append(" (CASE WHEN B.INPUT_CONTROL = '1' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                        ");
		sql.append(" WHEN B.INPUT_CONTROL = 'C' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                              ");
		sql.append(" WHEN B.INPUT_CONTROL = '2' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                              ");
		sql.append(" WHEN B.INPUT_CONTROL = '3' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                              ");
		sql.append(" WHEN B.INPUT_CONTROL = '6' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                              ");
		sql.append(" WHEN B.INPUT_CONTROL = '7' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                              ");
		sql.append(" ELSE '' END)                                         SURYANG                 ,                                                                                         ");
		sql.append(" A.ORD_DANUI                                                ORD_DANUI,                                                                                                  ");
		sql.append(" (CASE WHEN B.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language)                                                      ");
		sql.append(" WHEN B.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language)                                                            ");
		sql.append(" WHEN B.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language)                                                            ");
		sql.append(" WHEN B.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language)                                                            ");
		sql.append(" WHEN B.INPUT_CONTROL       = '3' AND IFNULL(E.BUN_CODE,'XX') = 'T2'              THEN 'L'                                                                              ");
		sql.append(" WHEN B.INPUT_CONTROL       = '3' THEN 'H'                                                                                                                              ");
		sql.append(" ELSE '' END)                                        ORD_DANUI_NAME          ,                                                                                          ");
		sql.append(" (CASE WHEN B.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME',A.DV_TIME, :hosp_code, :language)                                                                ");
		sql.append(" WHEN B.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME',A.DV_TIME, :hosp_code, :language)                                                                      ");
		sql.append(" ELSE '' END)                                        DV_TIME                 ,                                                                                          ");
		sql.append(" (CASE WHEN B.INPUT_CONTROL = '1' THEN TRIM(LPAD(CAST(A.DV as CHAR(3)),3,' '))                                                                                          ");
		sql.append(" WHEN B.INPUT_CONTROL = '2' THEN TRIM(LPAD(CAST(A.DV as CHAR(3)),3,' '))                                                                                                ");
		sql.append(" ELSE '' END)                                        DV                      ,                                                                                          ");
		sql.append(" (CASE WHEN B.INPUT_CONTROL = '1' THEN CONCAT(LTRIM(LPAD(CAST(A.NALSU as CHAR(5)),5,' ')),'D')                                                                          ");
		sql.append(" WHEN B.INPUT_CONTROL = '2' THEN CONCAT(LTRIM(LPAD(CAST(A.NALSU as CHAR(5)),5,' ')),'D')                                                                                ");
		sql.append(" WHEN B.INPUT_CONTROL = '3' THEN CONCAT(LTRIM(LPAD(CAST(A.NALSU as CHAR(5)),5,' ')),'M')                                                                                ");
		sql.append(" WHEN B.INPUT_CONTROL = '7' THEN CONCAT(LTRIM(LPAD(CAST(A.NALSU as CHAR(5)),5,' ')),'D')                                                                                ");
		sql.append(" WHEN B.INPUT_CONTROL = '8' THEN CONCAT(LTRIM(LPAD(CAST(A.NALSU as CHAR(5)),5,' ')),'D')                                                                                ");
		sql.append(" ELSE '' END)                                         NALSU                   ,                                                                                         ");
		sql.append(" A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                   ");
		sql.append(" A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                                   ");
		sql.append(" D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                                   ");
		sql.append(" A.JUSA                                                     JUSA                    ,                                                                                   ");
		sql.append(" FN_OCS_LOAD_CODE_NAME('JUSA',A.JUSA, :hosp_code, :language)                      JUSA_NAME               ,                                                             ");
		sql.append(" A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                                   ");
		sql.append(" FN_OCS_LOAD_BOGYONG_COL_NAME( :hosp_code, :language,B.ORDER_GUBUN,A.BOGYONG_CODE)        BOGYONG_NAME            ,                                                     ");
		sql.append(" FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.HOPE_DATE, :hosp_code, :language)            HOPE_DATE               ,                                                              ");
		sql.append(" A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                   ");
		sql.append(" A.NURSE_REMARK                                             NURSE_REMARK            ,                                                                                   ");
		sql.append(" A.EMERGENCY                                                EMERGENCY               ,                                                                                   ");
		sql.append(" A.TEL_YN                                                   TEL_YN                  ,                                                                                   ");
		sql.append(" A.PRN_YN                                                   PRN_YN                  ,                                                                                   ");
		sql.append(" CASE A.RESER_DATE WHEN NULL THEN 'N' ELSE 'Y' END                       RESER_YN                ,                                                                      ");
		sql.append(" A.SEQ                                                      SEQ                     ,                                                                                   ");
		sql.append(" A.BROUGHT_DRG_YN,                                                                                                                                                      ");
		sql.append(" A.POWDER_YN,                                                                                                                                                           ");
		sql.append(" A.DRG_PACK_YN,                                                                                                                                                         ");
		sql.append(" IFNULL(A.INSTEAD_YN,'N'),                                                                                                                                              ");
		sql.append(" IFNULL(A.APPROVE_YN,'N'),                                                                                                                                              ");
		sql.append(" IFNULL(A.POSTAPPROVE_YN,'N'),                                                                                                                                          ");
		sql.append(" CONCAT(LPAD(A.GROUP_SER,10,'0'),CASE WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS2003                                                                                    ");
		sql.append(" ELSE A.BOM_SOURCE_KEY END,A.PKOCS2003)                                          ORDER_BY_KEY                                                                           ");
		sql.append(" FROM OCS2003 A LEFT OUTER JOIN OCS0132 C ON C.HOSP_CODE = :hosp_code AND C.CODE = A.INPUT_GUBUN AND C.CODE_TYPE = 'INPUT_GUBUN'                                        ");
		sql.append("     LEFT OUTER JOIN OCS0116 D ON D.HOSP_CODE = :hosp_code AND D.SPECIMEN_CODE  = A.SPECIMEN_CODE                                                                       ");
		sql.append("     LEFT OUTER JOIN OCS0132 F ON F.HOSP_CODE = :hosp_code AND F.CODE  = A.ORDER_GUBUN AND F.CODE_TYPE          = 'ORDER_GUBUN',                                        ");
		sql.append(" OCS0103 B LEFT OUTER JOIN(SELECT A.SG_CODE,                                                                                                                            ");
		sql.append("                         A.BUN_CODE,                                                                                                                                    ");
		sql.append("                         A.SG_NAME,                                                                                                                                     ");
		sql.append("                         A.HOSP_CODE                                                                                                                                    ");
		sql.append("                            FROM BAS0310 A                                                                                                                              ");
		sql.append("                            WHERE A.HOSP_CODE = :hosp_code                                                                                                              ");
		sql.append("                            AND A.SG_YMD    =(SELECT MAX(Z.SG_YMD)                                                                                                      ");
		sql.append("                               FROM BAS0310 Z                                                                                                                           ");
		sql.append("                               WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                                                          ");
		sql.append("                               AND Z.SG_CODE   = A.SG_CODE                                                                                                              ");
		sql.append("                               AND Z.SG_YMD   <= SWF_TruncDate(CURRENT_TIMESTAMP,'DD'))) E ON E.HOSP_CODE  = B.HOSP_CODE AND E.SG_CODE = B.SG_CODE,                     ");
		sql.append(" VW_OCS_INP1001_RES G                                                                                                                                                   ");
		sql.append(" ,(select @kcck_hosp_code \\:= :hosp_code) TMP																															");
		sql.append(" WHERE A.HOSP_CODE            = :hosp_code                                                                                                                              ");
		sql.append(" AND A.BUNHO                = :bunho                                                                                                                                    ");
		sql.append(" AND A.FKINP1001            = :fkinp1001                                                                                                                                ");
		sql.append(" AND A.ORDER_DATE           = STR_TO_DATE(:order_date,'%Y/%m/%d')                                                                                                       ");
		sql.append(" AND (A.INPUT_GUBUN = :input_gubun                                                                                                                                      ");
		sql.append(" OR (:input_gubun = 'D%' AND A.INPUT_GUBUN LIKE :input_gubun))                                                                                                          ");
		sql.append(" AND CASE IFNULL(:gwa,G.GWA) WHEN G.GWA THEN G.DOCTOR ELSE A.INPUT_ID END = CASE IFNULL(:gwa,G.GWA) WHEN G.GWA THEN G.DOCTOR ELSE :doctor END                           ");
		sql.append(" AND (A.IO_GUBUN             IS NULL    OR  A.IO_GUBUN = '')                                                                                                            ");
		sql.append(" AND A.NALSU                >= 0                                                                                                                                        ");
		sql.append(" AND IFNULL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                    ");
		sql.append(" AND A.DC_YN       != 'Y'         			                                                                                                                            ");
		sql.append(" AND B.HOSP_CODE             = A.HOSP_CODE                                                                                                                              ");
		sql.append(" AND B.HANGMOG_CODE          = A.HANGMOG_CODE                                                                                                                           ");
		sql.append(" AND G.HOSP_CODE             = A.HOSP_CODE                                                                                                                              ");
		sql.append(" AND G.PKINP1001             = A.FKINP1001                                                                                                                              ");
		sql.append(" ORDER BY ORDER_BY_KEY																																					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("gwa", gwa);
		query.setParameter("doctor", doctor);
		query.setParameter("input_gubun", inputGubun);
		query.setParameter("bunho", bunho);
		query.setParameter("fkinp1001", fkinp1001);
		query.setParameter("order_date", orderDate);
		
		
		List<OCS2003R00layOCS2003Info> lstResult = new JpaResultMapper().list(query, OCS2003R00layOCS2003Info.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS2003P01XBAS0102EditGridCell(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.CODE 																								");
		sql.append(" 	,A.CODE_NAME																							");
		sql.append("	FROM BAS0102 A																							");
		sql.append(" 	WHERE CODE_TYPE = 'SANG_END_SAYU'																		");
		sql.append("	AND HOSP_CODE = :hosp_code  																			");
		sql.append("	ORDER BY A.CODE																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);	
				
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS2003P01XOCS0132EditGridCell(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.CODE");
		sql.append("	, A.CODE_NAME																							");
		sql.append("	FROM OCS0132 A																							");
		sql.append("	WHERE A.HOSP_CODE = :hosp_code  																		");
		sql.append("   	AND A.CODE_TYPE = 'JUSA_SPD_GUBUN'																		");
		sql.append("   	ORDER BY A.CODE																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS2003P01XBAS0260EditGridCell(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.GWA																								");
		sql.append("   	,A.GWA_NAME																								");
		sql.append("   	FROM BAS0260 A																							");
		sql.append("   	WHERE A.HOSP_CODE = :hosp_code  																		");
		sql.append("    AND A.LANGUAGE = :language																					");
		sql.append("    AND A.BUSEO_GUBUN = '1'																					");
		sql.append("    AND SYSDATE() > A.START_DATE 																		");
		sql.append("    AND SYSDATE() < A.END_DATE;																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);	
		query.setParameter("language", language);
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		
		return lstResult;
	}

	@Override
	public String getOCS2003Q02GetCodeNameGwaInfo(String hospCode, String language, String code, String ipwonYn, String buseoGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA_NAME                                                   								");
		sql.append("	  FROM VW_BAS_GWA A                                                         						");
		sql.append("	  WHERE GWA = :f_code     																			");
		sql.append("	    AND A.HOSP_CODE = :f_hosp_code  																");
		sql.append("	    AND A.LANGUAGE = :f_language    																");
		sql.append("	    AND A.IPWON_YN = :f_ipwonYn                                                  					");
		sql.append("	    AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))	");
		sql.append("	    AND A.BUSEO_GUBUN = :f_buseo_gubun																");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code", code);
		query.setParameter("f_ipwonYn", ipwonYn);
		query.setParameter("f_buseo_gubun", buseoGubun);
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	
	@Override
	public List<OCS2003Q11dataLayoutMIOInfo> getOCS2003Q11dataLayoutMIOInfo(String hospCode, String language, String hoDong, String session, String hoTeam, Date orderDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT '0'            SORT_GUBUN																													");
		sql.append("          , 'Z'            ORDER_GUBUN																													");
		sql.append("          , CONCAT('[', FN_ADM_MSG(3233, FN_LOAD_LANGUAGE_FROM_HOSPITAL(A.HOSP_CODE)),']') ORDER_GUBUN_NAME												");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , ''             HANGMOG_CODE																													");
		sql.append("          , IFNULL(CONCAT(TRIM(B.NUR_MD_NAME),'->',TRIM(REPLACE(REPLACE(C.DIRECT_TEXT,CHAR(13 USING ASCII),''),											");
		sql.append("          																		CHAR(10 USING ASCII),''))), '') 	HANGMOG_NAME						");
		sql.append("          , ''             INPUT_GUBUN																													");
		sql.append("          , ''             INPUT_GUBUN_NAME																												");
		sql.append("          , C.PK_SEQ       PKOCS2003																													");
		sql.append("          , ''             COMMENTS																														");
		sql.append("       FROM VW_OCS_INP1001 A 																															");
		sql.append("          JOIN NUR0111 B																																");
		sql.append("            ON B.HOSP_CODE   = A.HOSP_CODE																												");
		sql.append("           AND IFNULL(B.WORKLIST_DISP_YN,'N') = 'Y'																										");
		sql.append("          JOIN OCS2005 C																																");
		sql.append("            ON C.HOSP_CODE   = A.HOSP_CODE																												");
		sql.append("           AND C.BUNHO       = A.BUNHO																													");
		sql.append("           AND C.ORDER_DATE  = :f_order_date																											");
		sql.append("           AND C.DIRECT_CODE = B.NUR_MD_CODE																											");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT D.HO_CODE																												");
		sql.append("                           FROM BAS0250 D																												");
		sql.append("                          WHERE D.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN D.START_DATE AND D.END_DATE																		");
		sql.append("                            AND D.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND D.HO_CODE IN (SELECT F.HO_CODE																							");
		sql.append("                                                FROM NUR0104 F																							");
		sql.append("                                               WHERE F.HO_DONG      = D.HO_DONG																			");
		sql.append("                                                 AND F.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND F.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND F.HOSP_CODE    = :f_hosp_code																		");
		sql.append("                                                 AND F.JUKYONG_DATE = (SELECT MAX(G.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 G																	");
		sql.append("                                                                        WHERE G.HO_DONG      = F.HO_DONG												");
		sql.append("                                                                          AND G.HO_CODE      = F.HO_CODE												");
		sql.append("                                                                          AND G.HO_SESSION   = F.HO_SESSION												");
		sql.append("                                                                          AND G.HOSP_CODE    = F.HOSP_CODE												");
		sql.append("                                                                          AND G.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("     UNION																																				");
		sql.append("     SELECT '0'            SORT_GUBUN																													");
		sql.append("          , 'Z'            ORDER_GUBUN																													");
		sql.append("          , CONCAT('[',FN_ADM_MSG(3233, :f_language),']') ORDER_GUBUN_NAME																				");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , ''             HANGMOG_CODE																													");
		sql.append("          , IFNULL(CONCAT(TRIM(D.NUR_MD_NAME),'->',TRIM(REPLACE(REPLACE(B.DIRECT_TEXT,CHAR(13 USING ASCII),''), 										");
		sql.append("          																		CHAR(10 USING ASCII),''))), '') 	HANGMOG_NAME						");
		sql.append("          , ''             INPUT_GUBUN																													");
		sql.append("          , ''             INPUT_GUBUN_NAME																												");
		sql.append("          , B.PK_SEQ       PKOCS2003																													");
		sql.append("          , '' COMMENTS																																	");
		sql.append("       FROM VW_OCS_INP1001 A																															");
		sql.append("       JOIN OCS6015 B																																	");
		sql.append("         ON B.HOSP_CODE         = A.HOSP_CODE																											");
		sql.append("        AND B.PLAN_FROM_DATE    <= :f_order_date																										");
		sql.append("        AND IFNULL(B.PLAN_TO_DATE, STR_TO_DATE('9999/12/31', '%Y/%m/%d'))																				");
		sql.append("                                >= IF(:f_order_date > CURRENT_DATE(), :f_order_date, DATE_ADD(CURRENT_DATE(), INTERVAL 1 DAY))							");
		sql.append("       JOIN OCS6010 C																																	");
		sql.append("         ON C.HOSP_CODE         = A.HOSP_CODE																											");
		sql.append("        AND C.PKOCS6010         = B.FKOCS6010																											");
		sql.append("        AND C.FKINP1001         = A.PKINP1001																											");
		sql.append("       JOIN NUR0111 D																																	");
		sql.append("         ON D.HOSP_CODE         = A.HOSP_CODE																											");
		sql.append("        AND D.NUR_MD_CODE       = B.DIRECT_CODE																											");
		sql.append("        AND IFNULL(D.WORKLIST_DISP_YN,'N') = 'Y'																										");
		sql.append("                                																														");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE :f_order_date       > CURRENT_DATE()																										");
		sql.append("        AND A.HO_DONG1          = :f_ho_dong																											");
		sql.append("        AND A.HOSP_CODE         = :f_hosp_code																											");
		sql.append("        																																				");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                             FROM BAS0250 E																												");
		sql.append("                            WHERE E.HO_DONG     = A.HO_DONG1																							");
		sql.append("                              AND CURRENT_DATE()  BETWEEN E.START_DATE AND E.END_DATE																	");
		sql.append("                              AND E.HOSP_CODE   = A.HOSP_CODE																							");
		sql.append("                              AND E.HO_CODE IN (SELECT G.HO_CODE																						");
		sql.append("                                                  FROM NUR0104 G																						");
		sql.append("                                                 WHERE G.HO_DONG      = E.HO_DONG																		");
		sql.append("                                                   AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                   AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                   AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                   AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                           FROM NUR0104 H																");
		sql.append("                                                                          WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                            AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                            AND H.HO_SESSION   = G.HO_SESSION											");
		sql.append("                                                                            AND H.HOSP_CODE    = G.HOSP_CODE											");
		sql.append("                                                                            AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("     UNION																																				");
		sql.append("     SELECT '1'            SORT_GUBUN																													");
		sql.append("          , SUBSTR(C.ORDER_GUBUN,2,1) ORDER_GUBUN																										");
		sql.append("          , CONCAT('[', FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(C.ORDER_GUBUN,2,1), A.HOSP_CODE),												");
		sql.append("                           :f_language ,']') ORDER_GUBUN_NAME																							");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , C.HANGMOG_CODE HANGMOG_CODE																													");
		sql.append("          , D.HANGMOG_NAME HANGMOG_NAME																													");
		sql.append("          , C.INPUT_GUBUN  INPUT_GUBUN																													");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN_DISP', C.INPUT_GUBUN, A.HOSP_CODE,																		");
		sql.append("                           :f_language) INPUT_GUBUN_NAME																								");
		sql.append("          , C.PKOCS2003    PKOCS2003																													");
		sql.append("          , CASE (TRIM(C.NURSE_REMARK)) WHEN NULL THEN NULL																								");
		sql.append("                           ELSE CONCAT(FN_ADM_MSG(3123, :f_language), C.NURSE_REMARK) END COMMENTS														");
		sql.append("       FROM VW_OCS_INP1001 A 																															");
		sql.append("       JOIN OCS2003 C																																	");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODE																												");
		sql.append("        AND C.FKINP1001      = A.PKINP1001																												");
		sql.append("        AND C.BUNHO          = C.BUNHO																													");
		sql.append("        AND C.ORDER_DATE     = :f_order_date																											");
		sql.append("        AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')																							");
		sql.append("        AND SUBSTR(C.ORDER_GUBUN,2,1) IN('H','K')																										");
		sql.append("        AND IFNULL(C.DC_YN,'N') = 'N'																													");
		sql.append("        AND C.NALSU          > 0																														");
		sql.append("        AND C.NURSE_CONFIRM_DATE IS NOT NULL																											");
		sql.append("       LEFT JOIN OCS0103 D																																");
		sql.append("         ON D.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND D.HANGMOG_CODE   = C.HANGMOG_CODE																											");
		sql.append("        																																				");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                           FROM BAS0250 E																												");
		sql.append("                          WHERE E.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN E.START_DATE AND E.END_DATE																		");
		sql.append("                            AND E.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND E.HO_CODE IN (SELECT G.HO_CODE																							");
		sql.append("                                                FROM NUR0104 G																							");
		sql.append("                                               WHERE G.HO_DONG      = E.HO_DONG																			");
		sql.append("                                                 AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                 AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 H																	");
		sql.append("                                                                        WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                          AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                          AND H.HO_SESSION   = G.HO_SESSION												");
		sql.append("                                                                          AND H.HOSP_CODE    = G.HOSP_CODE												");
		sql.append("                                                                          AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("     UNION																																				");
		sql.append("     SELECT '2'            SORT_GUBUN																													");
		sql.append("          , SUBSTR(C.ORDER_GUBUN,2,1) ORDER_GUBUN																										");
		sql.append("          , CONCAT('[', FN_ADM_MSG(3131, :f_language), '-',																								");
		sql.append("             FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(C.ORDER_GUBUN,2,1), A.HOSP_CODE,															");
		sql.append("                           :f_language),']') ORDER_GUBUN_NAME																							");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , C.HANGMOG_CODE HANGMOG_CODE																													");
		sql.append("          , D.HANGMOG_NAME HANGMOG_NAME																													");
		sql.append("          , C.INPUT_GUBUN  INPUT_GUBUN																													");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN_DISP', C.INPUT_GUBUN, A.HOSP_CODE,																		");
		sql.append("                           :f_language) INPUT_GUBUN_NAME																								");
		sql.append("          , C.PKOCS2003    PKOCS2003																													");
		sql.append("          , CONCAT(CONCAT(CASE (TRIM(C.NURSE_REMARK)) WHEN NULL THEN NULL																				");
		sql.append("                           ELSE FN_ADM_MSG(3123, :f_language) END , C.NURSE_REMARK),																	");
		sql.append("            CASE(C.ACTING_DATE) WHEN NULL THEN ''																										");
		sql.append("                           ELSE CONCAT('[', FN_ADM_MSG(3132, :f_language), ']') END,																	");
		sql.append("            CASE(IFNULL(C.PORTABLE_YN,'N')) WHEN 'N' THEN ''																							");
		sql.append("                           ELSE CONCAT('[', FN_OCS_LOAD_CODE_NAME('PORTABLE_YN',C.PORTABLE_YN, A.HOSP_CODE,												");
		sql.append("                           :f_language),']') END,																										");
		sql.append("            CASE(IFNULL(C.EMERGENCY,'N')) WHEN 'N' THEN ''																								");
		sql.append("                           ELSE CONCAT('[', FN_ADM_MSG(3134, :f_language), ']') END) COMMENTS															");
		sql.append("       FROM VW_OCS_INP1001 A 																															");
		sql.append("       JOIN OCS2003 C																																	");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODe																												");
		sql.append("        AND C.FKINP1001      = A.PKINP1001																												");
		sql.append("        AND C.BUNHO          = A.BUNHO																													");
		sql.append("        AND C.ORDER_DATE     = :f_order_date																											");
		sql.append("        AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')																							");
		sql.append("        AND SUBSTR(C.ORDER_GUBUN,2,1) IN ('E', 'F', 'I')																								");
		sql.append("        AND C.RESER_DATE     IS NULL																													");
		sql.append("        AND IFNULL(C.DC_YN,'N') = 'N'																													");
		sql.append("        AND C.NALSU          > 0																														");
		sql.append("        AND C.NURSE_CONFIRM_DATE IS NOT NULL																											");
		sql.append("        																																				");
		sql.append("       LEFT JOIN OCS0103 D																																");
		sql.append("         ON D.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND D.HANGMOG_CODE   = C.HANGMOG_CODE																											");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                           FROM BAS0250 E																												");
		sql.append("                          WHERE E.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN E.START_DATE AND E.END_DATE																		");
		sql.append("                            AND E.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND E.HO_CODE IN (SELECT G.HO_CODE																							");
		sql.append("                                                FROM NUR0104 G																							");
		sql.append("                                               WHERE G.HO_DONG      = E.HO_DONG																			");
		sql.append("                                                 AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                 AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 H																	");
		sql.append("                                                                        WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                          AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                          AND H.HO_SESSION   = G.HO_SESSION												");
		sql.append("                                                                          AND H.HOSP_CODE    = G.HOSP_CODE												");
		sql.append("                                                                          AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("     UNION																																				");
		sql.append("     SELECT '3'            SORT_GUBUN																													");
		sql.append("          , SUBSTR(C.ORDER_GUBUN,2,1) ORDER_GUBUN																										");
		sql.append("          , CONCAT('[', FN_ADM_MSG(3135, :f_language),'-', 																								");
		sql.append("             FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(C.ORDER_GUBUN,2,1), A.HOSP_CODE,															");
		sql.append("                           :f_language),']') ORDER_GUBUN_NAME																							");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , C.HANGMOG_CODE HANGMOG_CODE																													");
		sql.append("          , D.HANGMOG_NAME HANGMOG_NAME																													");
		sql.append("          , C.INPUT_GUBUN  INPUT_GUBUN																													");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN_DISP', C.INPUT_GUBUN, A.HOSP_CODE, :f_language) INPUT_GUBUN_NAME											");
		sql.append("          , C.PKOCS2003    PKOCS2003																													");
		sql.append("          , CONCAT(CONCAT(CASE (TRIM(C.NURSE_REMARK)) WHEN NULL THEN NULL ELSE FN_ADM_MSG(3123, :f_language) END, C.NURSE_REMARK),						");
		sql.append("            '[', FN_ADM_MSG(3135, :f_language), '-', DATE_FORMAT(FN_SCH_LOAD_RESER_DATE('I',C.PKOCS2003, A.HOSP_CODE),'%Y%m%d%H%i'), ']',				");
		sql.append("            CASE(C.ACTING_DATE) WHEN NULL THEN '' ELSE CONCAT('[', FN_ADM_MSG(3132, :f_language),']') END, 												");
		sql.append("            CASE(IFNULL(C.PORTABLE_YN,'N')) WHEN 'N' THEN '' 																							");
		sql.append("                           ELSE CONCAT('[', FN_OCS_LOAD_CODE_NAME('PORTABLE_YN',C.PORTABLE_YN, A.HOSP_CODE, :f_language),']') END,						");
		sql.append("            CASE(IFNULL(C.EMERGENCY,'N')) WHEN 'N' THEN ''																								");
		sql.append("                           ELSE CONCAT('[', FN_ADM_MSG(3134, :f_language),']') END) COMMENTS															");
		sql.append("                           																																");
		sql.append("       FROM VW_OCS_INP1001 A 																															");
		sql.append("       JOIN OCS2003 C																																	");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODE																												");
		sql.append("        AND C.BUNHO          = A.BUNHO																													");
		sql.append("        AND C.FKINP1001      = A.PKINP1001																												");
		sql.append("        AND (C.RESER_DATE = :f_order_date  OR																											");
		sql.append("              C.RESER_DATE = DATE_ADD(:f_order_date, INTERVAL 1 DAY) OR																					");
		sql.append("              C.RESER_DATE = DATE_ADD(:f_order_date, INTERVAL 2 DAY))																					");
		sql.append("        AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')																							");
		sql.append("        AND SUBSTR(C.ORDER_GUBUN,2,1) IN ('E', 'F', 'I')																								");
		sql.append("        AND C.RESER_DATE     IS NOT NULL																												");
		sql.append("        AND IFNULL(C.DC_YN,'N') = 'N'																													");
		sql.append("        AND C.NALSU          > 0																														");
		sql.append("        AND C.NURSE_CONFIRM_DATE IS NOT NULL																											");
		sql.append("       																																					");
		sql.append("       LEFT JOIN OCS0103 D																																");
		sql.append("         ON D.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND D.HANGMOG_CODE   = C.HANGMOG_CODE																											");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.PKINP1001      = C.FKINP1001																												");
		sql.append("        AND A.BUNHO          = C.BUNHO																													");
		sql.append("        AND A.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                           FROM BAS0250 E																												");
		sql.append("                          WHERE E.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN E.START_DATE AND E.END_DATE																		");
		sql.append("                            AND E.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND E.HO_CODE IN (SELECT G.HO_CODE																							");
		sql.append("                                                FROM NUR0104 G																							");
		sql.append("                                               WHERE G.HO_DONG      = E.HO_DONG																			");
		sql.append("                                                 AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                 AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 H																	");
		sql.append("                                                                        WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                          AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                          AND H.HO_SESSION   = G.HO_SESSION												");
		sql.append("                                                                          AND H.HOSP_CODE    = G.HOSP_CODE												");
		sql.append("                                                                          AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("      UNION																																				");
		sql.append("     SELECT '4'            SORT_GUBUN																													");
		sql.append("          , 'Z'            ORDER_GUBUN																													");
		sql.append("          , CASE(IFNULL(C.ANTI_CANCER_YN,'N')) WHEN 'Y' THEN																							");
		sql.append("                           CONCAT('[', FN_ADM_MSG(3131, :f_language),']') ELSE '' END ORDER_GUBUN_NAME													");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , C.HANGMOG_CODE HANGMOG_CODE																													");
		sql.append("          , D.HANGMOG_NAME HANGMOG_NAME																													");
		sql.append("          , C.INPUT_GUBUN  INPUT_GUBUN																													");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN_DISP', C.INPUT_GUBUN, A.HOSP_CODE, :f_language) INPUT_GUBUN_NAME											");
		sql.append("          , C.PKOCS2003    PKOCS2003																													");
		sql.append("          , CASE(TRIM(C.NURSE_REMARK)) WHEN NULL THEN NULL																								");
		sql.append("                           ELSE CONCAT(FN_ADM_MSG(3123, :f_language), C.NURSE_REMARK) END COMMENTS														");
		sql.append("       FROM VW_OCS_INP1001 A																															");
		sql.append("       JOIN OCS2003 C																																	");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODE																												");
		sql.append("        AND C.BUNHO          = A.BUNHO																													");
		sql.append("        AND C.FKINP1001      = A.PKINP1001																												");
		sql.append("        AND C.ORDER_DATE     = :f_order_date																											");
		sql.append("        AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')																							");
		sql.append("        AND IFNULL(C.DC_YN,'N') = 'N'																													");
		sql.append("        AND C.NALSU          > 0																														");
		sql.append("        AND C.NURSE_CONFIRM_DATE IS NOT NULL																											");
		sql.append("       LEFT JOIN OCS0103 D																																");
		sql.append("         ON D.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND D.HANGMOG_CODE   = C.HANGMOG_CODE																											");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.PKINP1001      = C.FKINP1001																												");
		sql.append("        AND A.BUNHO          = C.BUNHO																													");
		sql.append("        AND A.HOSP_CODE      = C.HOSP_CODE																												");
		sql.append("        AND A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                           FROM BAS0250 E																												");
		sql.append("                          WHERE E.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN E.START_DATE AND E.END_DATE																		");
		sql.append("                            AND E.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND E.HO_CODE IN (SELECT G.HO_CODE																							");
		sql.append("                                                FROM NUR0104 G																							");
		sql.append("                                               WHERE G.HO_DONG      = E.HO_DONG																			");
		sql.append("                                                 AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                 AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 H																	");
		sql.append("                                                                        WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                          AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                          AND H.HO_SESSION   = G.HO_SESSION												");
		sql.append("                                                                          AND H.HOSP_CODE    = G.HOSP_CODE												");
		sql.append("                                                                          AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("      UNION																																				");
		sql.append("     SELECT '5'            SORT_GUBUN																													");
		sql.append("          , 'Z'            ORDER_GUBUN																													");
		sql.append("         , CONCAT('[', FN_ADM_MSG(3137, :f_language),']') ORDER_GUBUN_NAME																				");
		sql.append("          , A.HO_CODE1     HO_CODE1																														");
		sql.append("          , A.BUNHO        BUNHO																														");
		sql.append("          , A.SUNAME       SUNAME																														");
		sql.append("          , A.SUNAME2      SUNAME2																														");
		sql.append("          , ''             HANGMOG_CODE																													");
		sql.append("          , IFNULL(TRIM(C.POST_OP_NAME1),TRIM(C.PRE_OP_NAME1)) HANGMOG_NAME																				");
		sql.append("          , ''             INPUT_GUBUN																													");
		sql.append("          , ''             INPUT_GUBUN_NAME																												");
		sql.append("          , C.PKOPR1001    PKOCS2003																													");
		sql.append("          , CONCAT('[', FN_ADM_MSG(3137, :f_language), '-', DATE_FORMAT(C.OP_RESER_DATE,'%Y/%m/%d'),']',												");
		sql.append("            CASE(IFNULL(C.OP_END_YN, 'N')) WHEN 'N' THEN '' ELSE CONCAT('[', FN_ADM_MSG(3138, :f_language), ']') END) COMMENTS							");
		sql.append("       FROM VW_OCS_INP1001 A																															");
		sql.append("       JOIN OPR1001 C																																	");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODE																												");
		sql.append("        AND A.BUNHO          = A.BUNHO																													");
		sql.append("        AND C.OP_RESER_DATE  = :f_order_date																											");
		sql.append("		, (select @kcck_hosp_code\\:=:f_hosp_code) TMP																									");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																												");
		sql.append("        AND A.HO_DONG1       = :f_ho_dong																												");
		sql.append("        AND A.HO_CODE1 IN (SELECT E.HO_CODE																												");
		sql.append("                           FROM BAS0250 E																												");
		sql.append("                          WHERE E.HO_DONG     = A.HO_DONG1																								");
		sql.append("                            AND CURRENT_DATE() BETWEEN E.START_DATE AND E.END_DATE																		");
		sql.append("                            AND E.HOSP_CODE   = A.HOSP_CODE																								");
		sql.append("                            AND E.HO_CODE IN (SELECT G.HO_CODE																							");
		sql.append("                                                FROM NUR0104 G																							");
		sql.append("                                               WHERE G.HO_DONG      = E.HO_DONG																			");
		sql.append("                                                 AND G.HO_SESSION   = :f_session																		");
		sql.append("                                                 AND G.HO_TEAM      = :f_ho_team																		");
		sql.append("                                                 AND G.HOSP_CODE    = E.HOSP_CODE																		");
		sql.append("                                                 AND G.JUKYONG_DATE = (SELECT MAX(H.JUKYONG_DATE)														");
		sql.append("                                                                         FROM NUR0104 H																	");
		sql.append("                                                                        WHERE H.HO_DONG      = G.HO_DONG												");
		sql.append("                                                                          AND H.HO_CODE      = G.HO_CODE												");
		sql.append("                                                                          AND H.HO_SESSION   = G.HO_SESSION												");
		sql.append("                                                                          AND H.HOSP_CODE    = G.HOSP_CODE												");
		sql.append("                                                                          AND H.JUKYONG_DATE <= CURRENT_DATE()))										");
		sql.append("                        )																																");
		sql.append("     																																					");
		sql.append("      ORDER BY SORT_GUBUN, ORDER_GUBUN, HO_CODE1, BUNHO, HANGMOG_CODE, INPUT_GUBUN, PKOCS2003															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);	
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_session", session);
		query.setParameter("f_ho_team", hoTeam);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS2003Q11dataLayoutMIOInfo> lstResult = new JpaResultMapper().list(query, OCS2003Q11dataLayoutMIOInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003Q11layQueryInfo> getOCS2003Q11layQueryInfo(String hospCode,String language, String queryDate, String hoDong, String hoTeam, String a, String b, String c, String d) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT A.BUNHO             ,																														");
		sql.append("            A.SUNAME            ,																														");
		sql.append("            A.HO_CODE           ,																														");
		sql.append("            A.FKINP1001         ,																														");
		sql.append("            CAST(A.FKOCS6010  AS CHAR)        ,																											");
		sql.append("            IFNULL(A.CP_NAME, '')     ,																													");
		sql.append("            DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')        ,																								");
		sql.append("            DATE_FORMAT(A.ORDER_END_DATE, '%Y/%m/%d')    ,																								");
		sql.append("            A.INPUT_GUBUN       ,																														");
		sql.append("            A.INPUT_GUBUN_NAME  ,																														");
		sql.append("            A.ORDER_GUBUN       ,																														");
		sql.append("            A.ORDER_GUBUN_NAME  ,																														");
		sql.append("            A.HANGMOG_CODE      ,																														");
		sql.append("            A.HANGMOG_NAME      ,																														");
		sql.append("            CAST(A.SURYANG AS CHAR)           ,																											");
		sql.append("            CAST(A.NALSU AS CHAR)             ,																											");
		sql.append("            IFNULL(A.DETAIL, '')           ,																											");
		sql.append("            A.ORDER_REMARK      ,																														");
		sql.append("            A.NURSE_REMARK      ,																														");
		sql.append("            A.TEL_YN            ,																														");
		sql.append("            A.EMERGENCY         ,																														");
		sql.append("            IFNULL(A.JUSA_NAME, '')         ,																											");
		sql.append("            A.BOGYONG_NAME      ,																														");
		sql.append("            CAST(A.JAEWONIL  AS CHAR)        ,																											");
		sql.append("            A.PK                ,																														");
		sql.append("            A.GROUP_SER         ,																												");
		sql.append("            A.MIX_GROUP         ,																														");
		sql.append("            A.TABLE_ID          ,																														");
		sql.append("            A.CONFIRM_YN        ,																														");
		sql.append("            A.ACTING_YN         ,																														");
		sql.append("            A.CAN_PLAN_CHANGE_YN,																														");
		sql.append("            A.CAN_CONFIRM_YN    ,																														");
		sql.append("            A.CAN_ACTING_YN     ,																														");
		sql.append("            A.CAN_PLAN_APP_YN   ,																														");
		sql.append("            A.INPUT_NAME        ,																														");
		sql.append("            A.INPUT_SEQ         ,																													");
		sql.append("            A.CONFIRM_NAME      ,																														");
		sql.append("            A.INJ_ACT_YN        ,																														");
		sql.append("            A.BULYONG_CHECK     ,																														");
		sql.append("            IFNULL(A.CONT_KEY, '')																														");
		sql.append("       FROM (SELECT A.BUNHO                                       BUNHO             ,																	");
		sql.append("                    I.SUNAME                                      SUNAME            ,																	");
		sql.append("                    CASE (:f_language) WHEN 'JA' THEN CONCAT(I.HO_CODE1, '号室')																			");
		sql.append("                         WHEN 'VI' THEN CONCAT('Phòng ', I.HO_CODE1)																					");
		sql.append("                         ELSE CONCAT('Room ', I.HO_CODE1) END      HO_CODE           ,																	");
		sql.append("                    A.FKINP1001                                   FKINP1001         ,																	");
		sql.append("                    0                                             FKOCS6010         ,																	");
		sql.append("                    NULL                                          CP_NAME           ,																	");
		sql.append("                    (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')																				");
		sql.append("                          THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))											");
		sql.append("                          ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END )															");
		sql.append("                                                                          ORDER_DATE        ,															");
		sql.append("                    (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')																				");
		sql.append("                          THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))											");
		sql.append("                          ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END )															");
		sql.append("                                                                          ORDER_END_DATE    ,															");
		sql.append("                    A.INPUT_GUBUN                                 INPUT_GUBUN       ,																	");
		sql.append("                    E.CODE_NAME                                   INPUT_GUBUN_NAME  ,																	");
		sql.append("                    SUBSTR(A.ORDER_GUBUN, 2, 1)                   ORDER_GUBUN       ,																	");
		sql.append("                    FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1), A.HOSP_CODE, :f_language )									");
		sql.append("                                                                          ORDER_GUBUN_NAME  ,															");
		sql.append("                    A.HANGMOG_CODE                                HANGMOG_CODE,																			");
		sql.append("                    CONCAT(																																");
		sql.append("                    (CASE(A.BANNAB_YN) WHEN 'Y' THEN CONCAT('[', TRIM(FN_ADM_MSG(3142, :f_language)), ']') 												");
		sql.append("                         ELSE (CASE(SIGN(A.NALSU)) WHEN -1 THEN CONCAT('[', TRIM(FN_ADM_MSG(3154, :f_language)), ']')									");
		sql.append("                         ELSE (CASE(A.DC_GUBUN) WHEN 'Y' THEN 																							");
		sql.append("                         CONCAT('[', TRIM(FN_ADM_MSG(3239, :f_language)),']') ELSE '' END)  END) END), 													");
		sql.append("                    (CASE (A.PORTABLE_YN) WHEN '0' THEN CONCAT('[', TRIM(FN_ADM_MSG(3488, :f_language)), ']')											");
		sql.append("                          WHEN '1' THEN CONCAT('[', TRIM(FN_ADM_MSG(3489, :f_language)),']')															");
		sql.append("                          ELSE '' END ),																												");
		sql.append("                    C.HANGMOG_NAME)                                HANGMOG_NAME      ,																	");
		sql.append("                    A.SURYANG                                     SURYANG           ,																	");
		sql.append("                    A.NALSU                                       NALSU             ,																	");
		sql.append("                    CONCAT((CASE WHEN C.INPUT_CONTROL = '1' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN 						");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                          WHEN C.INPUT_CONTROL = 'C' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN 							");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                          WHEN C.INPUT_CONTROL = '2' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN 							");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                          WHEN C.INPUT_CONTROL = '3' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN 							");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                          WHEN C.INPUT_CONTROL = '6' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN				 				");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                          WHEN C.INPUT_CONTROL = '7' THEN (CASE(SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)) WHEN '.' THEN 							");
		sql.append("                                                            CONCAT('0', LTRIM(CAST(A.SURYANG AS CHAR))) ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END)		");
		sql.append("                         ELSE '' END),																													");
		sql.append("                    (CASE WHEN C.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language)				");
		sql.append("                          WHEN C.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language)				");
		sql.append("                          WHEN C.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language)				");
		sql.append("                          WHEN C.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language)				");
		sql.append("                          WHEN C.INPUT_CONTROL       = '3' AND IFNULL(D.BUN_CODE, 'XX') = 'T2'															");
		sql.append("                          THEN FN_ADM_MSG(3185, :f_language)																							");
		sql.append("                          WHEN C.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182, :f_language)															");
		sql.append("                          WHEN C.INPUT_CONTROL       = '6'																								");
		sql.append("                          THEN (CASE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language))											");
		sql.append("                               WHEN '' THEN FN_ADM_MSG(3186, :f_language)																				");
		sql.append("                               						 ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language) END)				");
		sql.append("                          WHEN C.INPUT_CONTROL       = '7'																								");
		sql.append("                          THEN (CASE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language))											");
		sql.append("                               WHEN '' THEN FN_ADM_MSG(3186, :f_language)																				");
		sql.append("                               						ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language) END)					");
		sql.append("                          ELSE '' END),																													");
		sql.append("                    (CASE WHEN C.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME, A.HOSP_CODE, :f_language)							");
		sql.append("                          WHEN C.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME, A.HOSP_CODE, :f_language)							");
		sql.append("                          ELSE '' END ),																												");
		sql.append("                    (CASE WHEN C.INPUT_CONTROL = '1' THEN TRIM(CAST(A.DV AS CHAR))																		");
		sql.append("                          WHEN C.INPUT_CONTROL = '2' THEN TRIM(CAST(A.DV AS CHAR))																		");
		sql.append("                          ELSE '' END ),																												");
		sql.append("                    (CASE WHEN C.INPUT_CONTROL = '1' THEN CONCAT('  ', 																					");
		sql.append("                                         (CASE(A.NALSU) WHEN 1 THEN '' ELSE LTRIM(CAST(A.NALSU AS CHAR)) END), FN_ADM_MSG(3184, :f_language))			");
		sql.append("                          WHEN C.INPUT_CONTROL = '2' THEN CONCAT('  ',																					");
		sql.append("                                         (CASE(A.NALSU) WHEN 1 THEN '' ELSE LTRIM(CAST(A.NALSU AS CHAR)) END), FN_ADM_MSG(3184, :f_language))			");
		sql.append("                          WHEN C.INPUT_CONTROL = '3' THEN CONCAT('  ', LTRIM(CAST(A.NALSU AS CHAR)), FN_ADM_MSG(3183, :f_language))						");
		sql.append("                          WHEN C.INPUT_CONTROL = '7' THEN CONCAT('  ',																					");
		sql.append("                                         (CASE(A.NALSU) WHEN 1 THEN '' ELSE LTRIM(CAST(A.NALSU AS CHAR)) END), FN_ADM_MSG(3184, :f_language))			");
		sql.append("                          WHEN C.INPUT_CONTROL = '8' THEN CONCAT('  ',																					");
		sql.append("                                         (CASE(A.NALSU) WHEN 1 THEN '' ELSE LTRIM(CAST(A.NALSU AS CHAR)) END), FN_ADM_MSG(3184, :f_language))			");
		sql.append("                         ELSE '' END))                           DETAIL            ,																	");
		sql.append("                    CONCAT((CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B', 'C', 'D')																");
		sql.append("                         AND A.ACTING_DATE IS NOT NULL																									");
		sql.append("                         AND A.NALSU > 0																												");
		sql.append("                         THEN ''																														");
		sql.append("                         ELSE '' END), 																													");
		sql.append("                         TRIM(A.ORDER_REMARK))                    ORDER_REMARK ,																		");
		sql.append("                    TRIM(A.NURSE_REMARK)                          NURSE_REMARK      ,																	");
		sql.append("                    A.TEL_YN                                      TEL_YN            ,																	");
		sql.append("                    A.EMERGENCY                                   EMERGENCY         ,																	");
		sql.append("                    FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, A.HOSP_CODE, :f_language)         JUSA_NAME         ,											");
		sql.append("                    (CASE WHEN IFNULL(A.SPECIMEN_CODE, '*') <> '*'																						");
		sql.append("                          THEN FN_OCS_LOAD_SPECIMEN_NAME(A.HOSP_CODE, A.SPECIMEN_CODE)																	");
		sql.append("                          ELSE FN_OCS_LOAD_BOGYONG_COL_NAME(A.HOSP_CODE, :f_language, C.ORDER_GUBUN, A.BOGYONG_CODE) END )								");
		sql.append("                                                                          BOGYONG_NAME      ,															");
		sql.append("                    0                                             JAEWONIL          ,																	");
		sql.append("                    A.PKOCS2003                                   PK                ,																	");
		sql.append("                    A.GROUP_SER                                   GROUP_SER         ,																	");
		sql.append("                    A.MIX_GROUP                                   MIX_GROUP         ,																	");
		sql.append("                    'OCS2003'                                     TABLE_ID          ,																	");
		sql.append("                    ( CASE WHEN A.NURSE_CONFIRM_DATE IS NULL																							");
		sql.append("                           THEN 'N'																														");
		sql.append("                           ELSE 'Y' END )                         CONFIRM_YN        ,																	");
		sql.append("                    (CASE(A.OCS_FLAG) WHEN '3' THEN 'Y' ELSE 'N' END)             ACTING_YN         ,													");
		sql.append("                    'N'                                           CAN_PLAN_CHANGE_YN,																	");
		sql.append("                    ( CASE WHEN SUBSTR(A.INPUT_GUBUN, 1, 1) IN ('D', 'N')																				");
		sql.append("                           AND FN_OCS_BULYONG_CHECK(A.HOSP_CODE, A.HANGMOG_CODE, A.ORDER_DATE) = 'N'													");
		sql.append("                           AND A.OCS_FLAG <> '3' AND A.OCS_FLAG <> '2'																					");
		sql.append("                           THEN 'Y'																														");
		sql.append("                           ELSE 'N' END )                         CAN_CONFIRM_YN    ,																	");
		sql.append("                    'N'                                           CAN_ACTING_YN     ,																	");
		sql.append("                    'N'                                           CAN_PLAN_APP_YN   ,																	");
		sql.append("                    FN_ADM_LOAD_USER_NM(A.HOSP_CODE, A.INPUT_ID, A.ORDER_DATE)																			");
		sql.append("                                                                  INPUT_NAME        ,																	");
		sql.append("                    IFNULL(E.SORT_KEY, 99)                        INPUT_SEQ         ,																	");
		sql.append("                    (CASE WHEN IFNULL(H.USER_GUBUN, '3') = '2' THEN  FN_ADM_LOAD_USER_NM(A.HOSP_CODE, H.USER_ID, A.ORDER_DATE)							");
		sql.append("                          ELSE '' END )                           CONFIRM_NAME      ,																	");
		sql.append("     																																					");
		sql.append("                    (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B' )																				");
		sql.append("                         THEN FN_OCS_INJECT_CHECK_INP(A.HOSP_CODE, A.PKOCS2003)																			");
		sql.append("                         ELSE 'N' END)                            INJ_ACT_YN        ,																	");
		sql.append("                    (CASE WHEN FN_OCS_BULYONG_CHECK(A.HOSP_CODE, A.HANGMOG_CODE, A.ORDER_DATE) = 'Y'													");
		sql.append("                         AND A.ACTING_DATE IS NULL																										");
		sql.append("                         THEN 'Y'																														");
		sql.append("                         ELSE 'N' END)                            BULYONG_CHECK     ,																	");
		sql.append("                    CONCAT(F.HO_SORT, I.HO_CODE1, A.BUNHO, SUBSTR(A.ORDER_GUBUN, 2, 1),																	");
		sql.append("                    TRIM(CAST(A.GROUP_SER AS CHAR)), IFNULL(A.MIX_GROUP, '  '),																			");
		sql.append("                    DATE_FORMAT(IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)), '%Y%m%d'),														");
		sql.append("                    CAST(E.SORT_KEY AS CHAR),CAST(A.SEQ AS CHAR),CAST(A.PKOCS2003 AS CHAR))																");
		sql.append("                                                                          CONT_KEY																		");
		
		sql.append("               FROM OCS2003 A																															");
		sql.append("          LEFT JOIN OCS2004 B																															");
		sql.append("                 ON B.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND B.BUNHO                = A.BUNHO																									");
		sql.append("                AND B.INPUT_GUBUN          = A.INPUT_GUBUN																								");
		sql.append("                AND B.FKINP1001            = A.FKINP1001																								");
		sql.append("                AND B.ORDER_DATE           = A.ORDER_DATE																								");
		sql.append("               JOIN OCS0103 C																															");
		sql.append("                 ON C.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND C.HANGMOG_CODE         = A.HANGMOG_CODE																								");
		sql.append("          LEFT JOIN ( SELECT A.SG_CODE																													");
		sql.append("                           , A.SG_NAME																													");
		sql.append("                           , A.BUN_CODE																													");
		sql.append("                           , A.HOSP_CODE																												");
		sql.append("                        FROM BAS0310 A																													");
		sql.append("                       WHERE A.SG_YMD = ( SELECT MAX(Z.SG_YMD)																							");
		sql.append("                                            FROM BAS0310 Z																								");
		sql.append("                                           WHERE Z.SG_CODE = A.SG_CODE																					");
		sql.append("                                             AND Z.SG_YMD <= STR_TO_DATE(:f_query_date, '%Y/%m/%d'))													");
		sql.append("                    ) D																																	");
		sql.append("                 ON D.HOSP_CODE            = C.HOSP_CODE																								");
		sql.append("                AND D.SG_CODE              = C.SG_CODE																									");
		sql.append("               JOIN OCS0132 E																															");
		sql.append("                 ON E.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND E.CODE                 = A.INPUT_GUBUN																								");
		sql.append("                AND E.CODE_TYPE            = 'INPUT_GUBUN'																								");
		sql.append("          LEFT JOIN DRG3010 G																															");
		sql.append("                 ON G.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND G.FKOCS2003            = A.PKOCS2003																								");
		sql.append("          LEFT JOIN ADM3200 H																															");
		sql.append("                 ON H.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND H.USER_ID              = A.NURSE_CONFIRM_USER																						");
		sql.append("               JOIN VW_OCS_INP1001 I																													");
		sql.append("                 ON I.HOSP_CODE            = A.HOSP_CODE																								");
		sql.append("                AND I.BUNHO                = A.BUNHO																									");
		sql.append("                AND I.PKINP1001            = A.FKINP1001																								");
		sql.append("                AND I.HO_DONG1             = :f_ho_dong																									");
		sql.append("               JOIN BAS0250 F																															");
		sql.append("                 ON F.HOSP_CODE            = I.HOSP_CODE																								");
		sql.append("                AND F.HO_DONG              = I.HO_DONG1																									");
		sql.append("                AND F.HO_CODE              = I.HO_CODE1																									");
		sql.append("                AND ((IFNULL(:f_a, 'N') = 'Y' AND F.TEAM = 'A') OR																						");
		sql.append("                     (IFNULL(:f_b, 'N') = 'Y' AND F.TEAM = 'B') OR																						");
		sql.append("                     (IFNULL(:f_c, 'N') = 'Y' AND F.TEAM = 'C') OR																						");
		sql.append("                     (IFNULL(:f_d, 'N') = 'Y' AND F.TEAM = 'D') OR        																				");
		sql.append("                     (IFNULL(:f_a, 'N') = 'N' AND 																										");
		sql.append("                      IFNULL(:f_b, 'N') = 'N' AND																										");
		sql.append("                      IFNULL(:f_c, 'N') = 'N' AND																										");
		sql.append("                      IFNULL(:f_d, 'N') = 'N' ))																										");
		sql.append("                      																																	");
		sql.append("                    , (select @kcck_hosp_code\\:=:f_hosp_code) TMP																						");
		sql.append("              WHERE A.HOSP_CODE               = :f_hosp_code																							");
		sql.append("                AND (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')																				");
		sql.append("                          THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))											");
		sql.append("                          ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END ) = STR_TO_DATE(:f_query_date, '%Y/%m/%d')					");
		sql.append("                AND IFNULL(A.DISPLAY_YN,'Y')  = 'Y'																										");
		sql.append("                AND IFNULL(A.PRN_YN,'N')      = 'N'																										");
		sql.append("                AND (IFNULL(A.INSTEAD_YN, 'N') = 'N'																									");
		sql.append("                       OR (IFNULL(A.INSTEAD_YN, 'N') = 'Y' 																								");
		sql.append("                           AND IFNULL(A.APPROVE_YN, 'N') = 'Y') 																						");
		sql.append("                    )																																	");
		sql.append("                AND (IFNULL(A.DC_YN,'N')     = 'N' OR (IFNULL(A.DC_YN,'N') = 'Y' AND A.BANNAB_YN = 'Y' ))												");
		sql.append("                AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('H', 'O', 'N', 'E', 'G')																			");
		sql.append("                ) A																																		");
		sql.append("      ORDER BY A.CONT_KEY																																");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);	
		query.setParameter("f_language", language);
		query.setParameter("f_query_date", queryDate);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_a", a);
		query.setParameter("f_b", b);
		query.setParameter("f_c", c);
		query.setParameter("f_d", d);
		
		List<OCS2003Q11layQueryInfo> lstResult = new JpaResultMapper().list(query, OCS2003Q11layQueryInfo.class);
		
		return lstResult;
	}
	
	@Override
	public List<OCS2003Q02grdNotActingInfo> getOCS2003Q02grdNotActingInfo(String hospCode, String language,
			String bunho, String hoDong, String gwa, String doctor, String timeGubun, String orderDate,
			String inputGubun, String orderGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("  	SELECT A.HO_CODE1                                       HO_CODE       ,                            				 	           ");
		sql.append("  	       A.HO_DONG1                                       HO_DONG       ,                             				           ");
		sql.append("  	       B.BUNHO                                          BUNHO         ,                             				           ");
		sql.append("  	       A.PKINP1001                                      PKINP1001     ,                             				           ");
		sql.append("  	       A.SUNAME                                         SUNAME        ,                             				           ");
		sql.append("  	       B.PKOCS2003                                      PKOCS2003     ,                             				           ");
		sql.append("  	       IFNULL(B.GROUP_SER, '')                                      GROUP_SER     ,                             	           ");
		sql.append("  	       IFNULL(B.ORDER_GUBUN, '')                                    ORDER_GUBUN   ,                             	           ");
		sql.append("  	       IFNULL(B.HANGMOG_CODE, '')                                   HANGMOG_CODE  ,                             	           ");
		sql.append("  	       IFNULL(C.HANGMOG_NAME, '')                                   HANGMOG_NAME  ,                             	           ");
		sql.append("  	       IFNULL(B.SPECIMEN_CODE, '')                                  SPECIMEN_CODE ,                             	           ");
		sql.append("  	       IFNULL(E.SPECIMEN_NAME, '')                                  SPECIMEN_NAME ,                             	           ");
		sql.append("  	       B.SURYANG                                        SURYANG       ,                             				           ");
		sql.append("  	       IFNULL(B.ORD_DANUI,'')                                      ORD_DANUI     ,                             		           ");
		sql.append("  	       IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI, :f_hosp_code, :f_language), '')  ORD_DANUI_NAME,                 ");
		sql.append("  	       B.DV_TIME                                        DV_TIME       ,                             				           ");
		sql.append("  	       B.DV                                             DV            ,                             				           ");
		sql.append("  	       B.NALSU                                          NALSU         ,                             				           ");
		sql.append("  	       B.TOIWON_DRG_YN                                  TOIWON_DRG_YN ,                             				           ");
		sql.append("  	       B.SEQ                                            SEQ           ,                             				           ");
		sql.append("  	       B.INPUT_GUBUN                                    INPUT_GUBUN   ,                             				           ");
		sql.append("  	       B.ORDER_DATE                                     ORDER_DATE    ,                             				           ");
		sql.append("  	       IFNULL(B.APPEND_YN,'N')                             APPEND_YN     ,                             				           ");
		sql.append("  	       IFNULL(B.EMERGENCY,'N')                             EMERGENCY     ,                             				           ");
		sql.append("  	       B.ACT_BUSEO                                      ACT_BUSEO     ,                             				           ");
		sql.append("  	       B.HOPE_DATE                                      RESER_DATE    ,                             				           ");
		sql.append("  	       B.HOPE_TIME                                      RESER_TIME    ,                                                        ");
		sql.append("  	       IF(B.OCS_FLAG = 2 , IF(B.JUBSU_DATE = '', '5', B.OCS_FLAG), B.OCS_FLAG) OCS_FLAG,							           ");
		sql.append("  	       A.GWA                                            GWA           ,                             				           ");
		sql.append("  	       A.DOCTOR                                         DOCTOR        ,                             				           ");
		sql.append("  	       IFNULL(C.RESER_YN_INP, 'N')                         RESER_YN_INP  ,                             				           ");
		sql.append("  	       IF(B.RESER_DATE IS NULL, 'N', 'Y')             RESER_YN      ,                             					           ");
		sql.append("  	       FN_OCS_CHECK_CAN_BANNAB(:f_hosp_code,'I', B.PKOCS2003)        BANAB_GUBUN   ,								           ");
		sql.append("  	       B.INPUT_TAB                                        INPUT_TAB     ,											           ");
		sql.append("  	       B.INPUT_GWA                                      INPUT_GWA     ,												           ");
		sql.append("  	       B.INPUT_DOCTOR                                   INPUT_DOCTOR  ,												           ");
		sql.append("  	       IFNULL(F.CODE_NAME, 'Etc')                       ORDER_GUBUN_NAME,											           ");
		sql.append("  	       B.JUBSU_DATE                                     JUBSU_DATE    ,												           ");
		sql.append("  	       B.ACTING_DATE                                    ACTING_DATE													           ");
		sql.append("  	FROM VW_OCS_INP1001_RES A																							           ");
		sql.append("  	JOIN OCS2003 B ON A.HOSP_CODE = B.HOSP_CODE																			           ");
		sql.append("  	              AND A.BUNHO     = B.BUNHO                                                          					           ");
		sql.append("  	              AND A.PKINP1001 = B.FKINP1001																			           ");
		sql.append("  	JOIN OCS0103 C ON B.HOSP_CODE     = C.HOSP_CODE																		           ");
		sql.append("  	              AND B.HANGMOG_CODE  = C.HANGMOG_CODE																	           ");
		sql.append("  	LEFT JOIN OCS0116 E ON B.HOSP_CODE      = E.HOSP_CODE																           ");
		sql.append("  	                   AND B.SPECIMEN_CODE  = E.SPECIMEN_CODE															           ");
		sql.append("  	LEFT JOIN OCS0132 F ON B.HOSP_CODE    = F.HOSP_CODE 																           ");
		sql.append("  	                   AND B.ORDER_GUBUN  = F.CODE																		           ");
		sql.append("  	                   AND F.CODE_TYPE    = 'ORDER_GUBUN'																           ");
		sql.append("  	,(SELECT @kcck_hosp_code\\:=:f_hosp_code) TMP																		           ");
		sql.append("  	WHERE A.HOSP_CODE = :f_hosp_code																					           ");
		sql.append("  	 AND A.BUNHO             LIKE :f_bunho                                                       						           ");
		sql.append("  	 AND A.HO_DONG1           LIKE :f_ho_dong   																		           ");
		sql.append("  	 AND (B.IO_GUBUN           IS NULL OR B.IO_GUBUN = '')																           ");
		sql.append("  	 AND B.INPUT_GWA          LIKE :f_gwa                                                         						           ");
		sql.append("  	 AND B.INPUT_DOCTOR       LIKE :f_doctor                                                      						           ");
		sql.append("  	 AND SUBSTR(B.ORDER_GUBUN, 1, 1) = '0'																				           ");
		sql.append("  	 AND (  																											           ");
		sql.append("  	         (    :f_time_gubun = 'PRE'  																				           ");
		sql.append("  	          AND B.ACTING_DATE IS NULL																					           ");
		sql.append("  	          AND B.JUNDAL_PART <> 'HOM'																				           ");
		sql.append("  	          AND IFNULL(B.HOPE_DATE, B.ORDER_DATE) <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')							           ");
		sql.append("  	         )																											           ");
		sql.append("  	      OR (   :f_time_gubun = 'POST'					 																           ");
		sql.append("  	          AND IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)) > STR_TO_DATE(:f_order_date,'%Y/%m/%d')		           ");
		sql.append("  	         )																											           ");
		sql.append("  	      OR (    :f_time_gubun = 'ALL' 																				           ");
		sql.append("  	          AND (  																									           ");
		sql.append("  	                  (    B.ACTING_DATE IS NULL 																		           ");
		sql.append("  	                   AND B.JUNDAL_PART <> 'HOM'																		           ");
		sql.append("  	                   AND IFNULL(B.HOPE_DATE, B.ORDER_DATE) <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')					           ");
		sql.append("  	                  )																									           ");
		sql.append("  	               OR IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)) > STR_TO_DATE(:f_order_date,'%Y/%m/%d')	           ");
		sql.append("  	              )																										           ");
		sql.append("  	         )																											           ");
		sql.append("  	     )																												           ");
		sql.append("  	 AND (   (    :f_input_gubun = 'NR' 																				           ");
		sql.append("  	          AND (   B.INPUT_GUBUN LIKE 'D%' 																			           ");
		sql.append("  	               OR B.INPUT_GUBUN = 'NR' 																				           ");
		sql.append("  	              ) 																									           ");
		sql.append("  	          AND (   B.NALSU > 0 																						           ");
		sql.append("  	               OR (    IFNULL(B.BANNAB_YN, 'N') = 'Y' 																           ");
		sql.append("  	                   AND B.NALSU < 0 																					           ");
		sql.append("  	                  ) 																								           ");
		sql.append("  	              )																										           ");
		sql.append("  	         )																											           ");
		sql.append("  	      OR (    :f_input_gubun = 'D%' 																				           ");
		sql.append("  	          AND B.INPUT_GUBUN LIKE 'D%' 																				           ");
		sql.append("  	          AND B.NALSU > 0																							           ");
		sql.append("  	         ) 																											           ");
		sql.append("  	     )																												           ");
		sql.append("  	 AND IF(B.DC_YN IS NULL OR B.DC_YN = '','N',B.DC_YN)  = 'N'                                                                    ");
		sql.append("  	 AND B.INPUT_TAB      != '10' 																						           ");
		sql.append("  	 AND B.INPUT_TAB      LIKE :f_order_gubun																			           ");
		sql.append("  	 AND SUBSTR(B.ORDER_GUBUN, 2, 1) NOT IN ('B','C','D')																           ");
		sql.append("  	 AND (   (IF(B.INSTEAD_YN IS NULL OR B.INSTEAD_YN = '', 'N', B.INSTEAD_YN) = 'N')									           ");
		sql.append("  	      OR (IF(B.INSTEAD_YN IS NULL OR B.INSTEAD_YN = '', 'N', B.INSTEAD_YN) = 'Y' AND IF(B.APPROVE_YN IS NULL OR B.APPROVE_YN = '', 'N', B.APPROVE_YN) = 'Y')	");
		sql.append("  	     )                                                                                                       					                                ");
		sql.append("  	ORDER BY A.HO_CODE1, B.BUNHO, E.SPECIMEN_NAME, B.ORDER_GUBUN, B.GROUP_SER, B.INPUT_GUBUN						 				                                ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_time_gubun", timeGubun);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_order_gubun", orderGubun);
		
		List<OCS2003Q02grdNotActingInfo> lstResult = new JpaResultMapper().list(query, OCS2003Q02grdNotActingInfo.class);
		
		return lstResult;
	}

	@Override
	public String checkOcsIsYetBannabOrder(String hospCode, String bunho, String kijunDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT FN_OCS_IS_YET_BANNAB_ORDER(:f_hosp_code, :f_bunho, :f_kijun_date) FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_kijun_date", kijunDate);		
		
		List<String> listResult = query.getResultList();
		return CollectionUtils.isEmpty(listResult) ? "" : listResult.get(0);
	}

	@Override
	public OCS2003Q02BatchDeleteProcessInfo callPrOcsiBatchDeleteOrder(String hospCode, Double pkInp1001, Date deleteDate) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_BATCH_DELETE_ORDER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DELETE_DATE", Date.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_PROCESSED_COUNT", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKINP1001", pkInp1001);
		query.setParameter("I_DELETE_DATE", deleteDate);
		
		query.execute();
		Integer processedCount = (Integer) query.getOutputParameterValue("O_PROCESSED_COUNT");
		String err = (String) query.getOutputParameterValue("O_ERR");
		
		return new OCS2003Q02BatchDeleteProcessInfo(processedCount, err);
	}

	@Override
	public String callPrOcsiProcessBannabNew(String hospCode, String workGubun, String bunho, double fkinp1001,
			double pkocs2003, Date stopDate, Date stopDate2, String inputDoctor, String userId, String gubun,
			double bannabDv, String bogyongCodeReturn, double toiwonDrgDv, String toiwonDrgBogyongCode) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_PROCESS_BANNAB_NEW");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WORK_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_DATE2", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BANNAB_DV", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BOGYONG_CODE_RETURN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DRG_DV", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DRG_BOGYONG_CODE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_WORK_GUBUN", workGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_PKOCS2003", pkocs2003);
		query.setParameter("I_STOP_DATE", stopDate);
		query.setParameter("I_STOP_DATE2", stopDate2);
		query.setParameter("I_INPUT_DOCTOR", inputDoctor);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_BANNAB_DV", bannabDv);
		query.setParameter("I_BOGYONG_CODE_RETURN", bogyongCodeReturn);
		query.setParameter("I_TOIWON_DRG_DV", toiwonDrgDv);
		query.setParameter("I_TOIWON_DRG_BOGYONG_CODE", toiwonDrgBogyongCode);
		
		query.execute();
		String err = (String) query.getOutputParameterValue("IO_ERR");
		return err == null ? "" : err;
	}

	@Override
	public List<Double> getOCS2003P01SetSameOrderDateGroupSer(String hospCode, String orderDate,
			String inputTab, String bunho, String inputDoctor) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																								");
		sql.append("		DISTINCT(A.group_ser) group_ser																	");
		sql.append("	FROM																								");
		sql.append("		OCS2003 A 																						");
		sql.append("	WHERE																								");
		sql.append("		A.hosp_code    			= :f_hosp_code															");
		sql.append("		AND A.order_date   		= STR_TO_DATE(:f_order_date, '%Y/%e/%c %r')								");
		sql.append("		AND A.input_tab    		= :f_input_tab															");
		sql.append("		AND A.dc_yn       		!= 'Y' 																	");
		sql.append("		AND A.bannab_yn   		!= 'Y'																	");
		sql.append("		AND A.bunho        		= :f_bunho																");
		sql.append("		AND A.input_doctor 		= :f_input_doctor														");
		sql.append("		AND A.acting_date 		is null																	");
		sql.append("		AND A.group_ser 		not in (																");
		sql.append("											SELECT														");
		sql.append("												DISTINCT(B.group_ser) 									");
		sql.append("											FROM														");
		sql.append("												OCS2003 B 												");
		sql.append("											WHERE														");
		sql.append("												B.hosp_code    			= A.hosp_code					");
		sql.append("												AND B.order_date   		= :f_order_date					");
		sql.append("												AND B.input_tab    		= :f_input_tab					");
		sql.append("												AND B.bunho        		= :f_bunho						");
		sql.append("												AND B.input_doctor 		= :f_input_doctor				");
		sql.append("										)																");
		sql.append("	ORDER BY																							");
		sql.append("		A.group_ser																						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_input_doctor", inputDoctor);
//		
		List<Double> listResult = query.getResultList();
		return listResult;
	}

	@Override
	public List<OCS2003P01GrdPatientListInfo> getOCS2003P01GrdPatientListInfo(String hospCode, String language, Date orderDate, String inputGubun, String approveDoctor, String bunho, String doctorYn, String doctor, String hodong){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKINP1001                                         						                  PK_KEY,																				");
		sql.append("	       A.HO_DONG1                                          						                  HO_DONG,																				");
		sql.append("	       FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG1, :f_order_date, :f_hosp_code, :f_language)	  		  HO_DONG_NAME,																			");
		sql.append("	       A.HO_CODE1                                          						                  HO_CODE,																				");
		sql.append("	       FN_BAS_LOAD_HO_CODE_NAME(:f_hosp_code,A.HO_DONG1, A.HO_CODE1, :f_order_date) 	  		  HO_CODE_NAME,																			");
		sql.append("	       A.BUNHO                                             						                  BUNHO,																				");
		sql.append("	       A.SUNAME                                            						                  SUNAME,																				");
		sql.append("	       A.SUNAME2                                           						                  SUNAME2,																				");
		sql.append("	       A.SEX                                               						                  SEX,																					");
		sql.append("	       FN_BAS_LOAD_AGE(:f_order_date, A.BIRTH,'')									              AGE,																					");
		sql.append("		   IFNULL(A.GUBUN, '')																		  GUBUN,																				");
		sql.append("	       IFNULL(FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, :f_order_date,:f_hosp_code), '')					  GUBUN_NAME,																			");
		sql.append("	       A.DOCTOR                                            						                  DOCTOR,																				");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, :f_order_date, :f_hosp_code)    						  DOCTOR_NAME,																			");
		sql.append("	       A.GWA                                               						                  GWA,																					");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA, :f_order_date, :f_hosp_code, :f_language)          			  GWA_NAME,																				");
		sql.append("	       A.IPWON_DATE                                        						                  IPWON_DATE,																			");
		sql.append("	       A.IPWON_RESER_YN                                    						                  IPWON_RESER_YN,																		");
		sql.append("	       A.IPWON_TYPE                                        						                  IPWON_TYPE,																			");
		sql.append("	       'N'                                                 						                  COUSULT_GUBUN,																		");
		sql.append("	       SUBSTR(FN_OCS_INP_ORDER_STATUS_CHECK(A.HOSP_CODE,A.BUNHO, A.PKINP1001, :f_order_date, :f_input_gubun), 1, 1) 									        JINRYO_END_YN,			");
		sql.append("	       NULL                                                                                             														CONSULT_KEY  ,			");
		sql.append("	       FN_BAS_LOAD_COMMON_DOCTOR_YN(:f_hosp_code,A.GWA, A.DOCTOR, :f_order_date)                                     														COMMON_DOCTOR_YN,		");
		sql.append("	       IFNULL(A.CYCLE_ORDER_GROUP,'')																															CYCLE_ORDER_GROUP,		");
		sql.append("	       IF(FN_OCS_GET_NOTAPPROVE_ORDERCNT(A.HOSP_CODE, 'I', 'Y', 'N', SUBSTR(:f_approve_doctor, LENGTH(:f_approve_doctor) -4), A.PKINP1001) = 0, 'N', 'Y') 	  	UNAPPROVE_YN,			");
		sql.append("	       IF(FN_OCS_GET_NOTAPPROVE_DESEASE(A.HOSP_CODE, 'I', 'Y', 'N', SUBSTR(:f_approve_doctor, LENGTH(:f_approve_doctor) -4), A.BUNHO    ) = 0, 'N', 'Y') 	  	UNAPPROVE_DESEASE_YN,	");
		sql.append("		     A.BED_NO,																																										");
		sql.append("	       CONCAT('Y', A.IPWON_RESER_YN, RPAD(IFNULL(A.HO_DONG1, '0'), 4, '0'), RPAD(A.HO_CODE1, 10, ' '), A.BED_NO, A.BUNHO, LTRIM(LPAD(A.PKINP1001, 10, '0'))) 	CONT_KEY				");
		sql.append("	  FROM VW_OCS_INP1001_RES_11 A																																							");
		sql.append("	  ,  (select @kcck_hosp_code\\:=:f_hosp_code) TMP																																			");
		sql.append("	 WHERE A.IPWON_DATE        <= :f_order_date																																				");
		sql.append("	   AND A.BUNHO             LIKE :f_bunho																																				");
		sql.append("	   AND (   :f_doctor_yn = 'Y'																																							");
		sql.append("	        OR (    :f_doctor_yn = 'N'																										 												");
		sql.append("	            AND SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR)-4) LIKE IF(:f_doctor = '%', :f_doctor, SUBSTR(:f_doctor, LENGTH(:f_doctor)-4)))														");
		sql.append("	   )																																													");
		sql.append("	   AND IFNULL(A.HO_DONG1,' ') LIKE TRIM(:f_ho_dong)																																		");
		sql.append("	   AND A.HOSP_CODE         =    :f_hosp_code																																			");
		sql.append("	   AND NOT EXISTS ( SELECT 'Y'																																							");
		sql.append("	                      FROM OCS0503 Z																																					");
		sql.append("	                     WHERE Z.FKINP1001            =  A.PKINP1001																														");
		sql.append("	                       AND Z.JINRYO_PRE_DATE             = :f_order_date																												");
		sql.append("	                       AND SUBSTR(Z.CONSULT_DOCTOR, 3)       LIKE  IF(:f_doctor = '%', :f_doctor, SUBSTR(:f_doctor, LENGTH(:f_doctor)-4))												");
		sql.append("	                       AND IFNULL(Z.ANSWER_END_YN, 'N') =  'N')																															");
		sql.append("	UNION ALL																																												");
		sql.append("	SELECT A.PKINP1001                                         						                            PK_KEY,																		");
		sql.append("	       A.HO_DONG1                                          						                            HO_DONG,																	");
		sql.append("	       FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG1, :f_order_date, :f_hosp_code, :f_language) 						HO_DONG_NAME,																");
		sql.append("	       A.HO_CODE1                                          						                            HO_CODE,																	");
		sql.append("	       FN_BAS_LOAD_HO_CODE_NAME(:f_hosp_code,A.HO_DONG1, A.HO_CODE1, :f_order_date) 			        	HO_CODE_NAME,																");
		sql.append("	       A.BUNHO                                             						                            BUNHO,																		");
		sql.append("	       A.SUNAME                                            						                            SUNAME,																		");
		sql.append("	       A.SUNAME2                                           						                            SUNAME2,																	");
		sql.append("	       A.SEX                                               						                            SEX,																		");
		sql.append("	       FN_BAS_LOAD_AGE(:f_order_date, A.BIRTH,'')									                        AGE,																		");
		sql.append("	       IFNULL(A.GUBUN, '')																					GUBUN,																		");
		sql.append("	       IFNULL(FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, :f_order_date,:f_hosp_code), '')								GUBUN_NAME,																	");
		sql.append("	       B.CONSULT_DOCTOR                                    						                            DOCTOR,																		");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(B.CONSULT_DOCTOR, :f_order_date, :f_hosp_code) 				            	DOCTOR_NAME,																");
		sql.append("	       B.CONSULT_GWA                                       						                            GWA,																		");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(B.CONSULT_GWA, :f_order_date, :f_hosp_code, :f_language)  						GWA_NAME,																	");
		sql.append("	       A.IPWON_DATE                                        						                            IPWON_DATE,																	");
		sql.append("	       'N'                                                 						                            IPWON_RESER_YN,																");
		sql.append("	       A.IPWON_TYPE                                        						                            IPWON_TYPE,																	");
		sql.append("	       'Y'                                                 						                            COUSULT_GUBUN,																");
		sql.append("	       SUBSTR(FN_OCS_INP_ORDER_STATUS_CHECK(A.HOSP_CODE,A.BUNHO, A.PKINP1001, :f_order_date, :f_input_gubun), 1, 1)								JINRYO_END_YN,							");
		sql.append("	       B.PKOCS0503                                         																						CONSULT_KEY  ,							");
		sql.append("	       FN_BAS_LOAD_COMMON_DOCTOR_YN(:f_hosp_code,B.CONSULT_GWA, B.CONSULT_DOCTOR, :f_order_date)																COMMON_DOCTOR_YN,						");
		sql.append("	       IFNULL(A.CYCLE_ORDER_GROUP, '')																											CYCLE_ORDER_GROUP,						");
		sql.append("	       IF(FN_OCS_GET_NOTAPPROVE_ORDERCNT(A.HOSP_CODE, 'I', 'Y', 'N', SUBSTR(:f_approve_doctor, LENGTH(:f_approve_doctor) -4), A.PKINP1001) = 0, 'N', 'Y') 	UNAPPROVE_YN,				");
		sql.append("	       IF(FN_OCS_GET_NOTAPPROVE_DESEASE( A.HOSP_CODE, 'I', 'Y', 'N', SUBSTR(:f_approve_doctor, LENGTH(:f_approve_doctor) -4), A.BUNHO    ) = 0, 'N', 'Y') 	UNAPPROVE_DESEASE_YN,		");
		sql.append("		   A.BED_NO,																																										");
		sql.append("	       CONCAT('N', 'N', RPAD(IFNULL(A.HO_DONG1, '0'), 4, '0'), RPAD(A.HO_CODE1, 10, ' '), A.BED_NO, A.BUNHO, LTRIM(LPAD(A.PKINP1001, 10, '0'))) 			CONT_KEY					");
		sql.append("	  FROM OCS0503            B,																																							");
		sql.append("	       VW_OCS_INP1001_11  A,																																							");
		sql.append("		   (select @kcck_hosp_code\\:=:f_hosp_code) TMP																																		");
		sql.append("	 WHERE A.BUNHO                     LIKE :f_bunho																																		");
		sql.append("	   AND A.IPWON_DATE                <= :f_order_date																																		");
		sql.append("	   AND IFNULL(A.HO_DONG1,' ')         LIKE TRIM(:f_ho_dong)																																");
		sql.append("	   AND B.JINRYO_PRE_DATE           = :f_order_date																																		");
		sql.append("	   AND B.FKINP1001                 =  A.PKINP1001																																		");
		sql.append("	   AND B.HOSP_CODE                 = A.HOSP_CODE                 																														");
		sql.append("	   AND ( FN_BAS_LOAD_COMMON_DOCTOR_YN(:f_hosp_code,B.CONSULT_GWA, B.CONSULT_DOCTOR, :f_order_date) = 'Y' OR																							");
		sql.append("	         SUBSTR(B.CONSULT_DOCTOR, (LENGTH(B.CONSULT_DOCTOR)-5)+1)          LIKE IF(:f_doctor = '%', :f_doctor, SUBSTR(:f_doctor, LENGTH(:f_doctor)-4))  )								");
		sql.append("	   AND IFNULL(B.ANSWER_END_YN, 'N')      = 'N'																																			");
		sql.append("	ORDER BY CONT_KEY																																										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_language", language);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_approve_doctor", approveDoctor);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_doctor_yn", doctorYn);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_ho_dong", hodong);
		
		List<OCS2003P01GrdPatientListInfo> lstResult = new JpaResultMapper().list(query, OCS2003P01GrdPatientListInfo.class);
		return lstResult;
	}

	@Override
	public List<OCS2003P01LayQueryLayoutInfo> getOCS2003P01LayQueryLayout(String hospCode, String language,
			String bunho, String fkinp1001, String orderDate, String queryGubun, String inputDoctor,
			String inputGubun) {
		
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.FKINP1001                                          IN_OUT_KEY	                                                         ");
		sql.append("	     , A.PKOCS2003                                          PKOCSKEY	                                                         ");
		sql.append("	     , A.BUNHO                                              BUNHO		                                                         ");
		sql.append("	     , ORDER_DATE						                  	ORDER_DATE	                                                         ");
		sql.append("	     , E.GWA                                                GWA			                                                         ");
		sql.append("	     , A.DOCTOR                                             DOCTOR		                                                         ");
		sql.append("	     , A.DOCTOR                                             RESIDENT	                                                         ");
		sql.append("	     , E.IPWON_TYPE                                         NAEWON_TYPE	                                                         ");
		sql.append("	     , ''                                                   JUBSU_NO	                                                         ");
		sql.append("	     , A.INPUT_ID                                           INPUT_ID	                                                         ");
		sql.append("	     , A.INPUT_PART                                         INPUT_PART	                                                         ");
		sql.append("	     , A.INPUT_GWA                                          INPUT_GWA	                                                         ");
		sql.append("	     , A.INPUT_DOCTOR                                       INPUT_DOCTOR                                                         ");
		sql.append("	     , A.INPUT_GUBUN                                        INPUT_GUBUN	                                                         ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, :f_hosp_code, :f_language)  	                                         ");
		sql.append("																INPUT_GUBUN_NAME			                                         ");
		sql.append("	     , IFNULL(CAST(A.GROUP_SER AS CHAR), '')				GROUP_SER					                                         ");
		sql.append("	     , A.INPUT_TAB                                          INPUT_TAB					                                         ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('INPUT_TAB', A.INPUT_TAB, :f_hosp_code, :f_language)      INPUT_TAB_NAME                            ");
		sql.append("	     , A.ORDER_GUBUN                                        ORDER_GUBUN									                         ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN, :f_hosp_code, :f_language)  ORDER_GUBUN_NAME	                         ");
		sql.append("	     , B.GROUP_YN                                           GROUP_YN									                         ");
		sql.append("	     , A.SEQ                                                SEQ											                         ");
		sql.append("	     , A.SLIP_CODE                                          SLIP_CODE	                                                         ");
		sql.append("	     , A.HANGMOG_CODE                                       HANGMOG_CODE                                                         ");
		sql.append("	     , B.HANGMOG_NAME                                       HANGMOG_NAME                                                         ");
		sql.append("	     , A.SPECIMEN_CODE                                      SPECIMEN_CODE                                                        ");
		sql.append("	     , IFNULL(C.SPECIMEN_NAME, '')                          SPECIMEN_NAME	                                                     ");
		sql.append("	     , A.SURYANG                                            SURYANG			                                                     ");
		sql.append("	     , A.SURYANG                                            SUNAB_SURYANG	                                                     ");
		sql.append("	     , A.SUBUL_SURYANG                                      SUBUL_SURYANG	                                                     ");
		sql.append("	     , A.ORD_DANUI                                          ORD_DANUI		                                                     ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language)      ORD_DANUI_NAME							 ");
		sql.append("	     , A.DV_TIME                                            DV_TIME																 ");
		sql.append("	     , A.DV                                                 DV	                                                                 ");
		sql.append("	     , A.DV_1                                               DV_1                                                                 ");
		sql.append("	     , A.DV_2                                               DV_2                                                                 ");
		sql.append("	     , A.DV_3                                               DV_3                                                                 ");
		sql.append("	     , A.DV_4                                               DV_4                                                                 ");
		sql.append("	     , IFNULL(CAST(A.NALSU AS CHAR), '')					NALSU                                                                ");
		sql.append("	     , ''                                                	SUNAB_NALSU                                                          ");
		sql.append("	     , A.JUSA                                               JUSA								                                 ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code, :f_language), '')	JUSA_NAME	                                 ");
		sql.append("	     , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN						                                 ");
		sql.append("	     , A.BOGYONG_CODE                                       BOGYONG_CODE						                                 ");
		sql.append("	     , CASE WHEN B.INPUT_CONTROL = 'A' THEN FN_CHT_LOAD_CHT0117_NAME (A.BOGYONG_CODE, :f_hosp_code, :f_language)                 ");
		sql.append("	            ELSE FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :f_hosp_code)	                                                         ");
		sql.append("	       END                                                  BOGYONG_NAME                                                         ");
		sql.append("	     , A.EMERGENCY                                          EMERGENCY	                                                         ");
		sql.append("	     , A.JAERYO_JUNDAL_YN                                   JAERYO_JUNDAL_YN                                                     ");
		sql.append("	     , A.JUNDAL_TABLE                                       JUNDAL_TABLE	                                                     ");
		sql.append("	     , A.JUNDAL_PART                                        JUNDAL_PART		                                                     ");
		sql.append("	     , A.MOVE_PART                                          MOVE_PART		                                                     ");
		sql.append("	     , A.PORTABLE_YN                                        PORTABLE_YN1	                                                     ");
		sql.append("	     , A.POWDER_YN                                          POWDER_YN		                                                     ");
		sql.append("	     , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN	                                                     ");
		sql.append("	     , A.PHARMACY                                           PHARMACY		                                                     ");
		sql.append("	     , A.DRG_PACK_YN                                        DRG_PACK_YN	                                                         ");
		sql.append("	     , A.MUHYO                                              MUHYO		                                                         ");
		sql.append("	     , ''                                                 PRN_YN		                                                         ");
		sql.append("	     , ''                                                 TOIWON_DRG_YN	                                                         ");
		sql.append("	     , ''                                                 PRN_NURSE		                                                         ");
		sql.append("	     , ''                                                 APPEND_YN		                                                         ");
		sql.append("	     , IFNULL(A.ORDER_REMARK, '')                                       ORDER_REMARK                                             ");
		sql.append("	     , IFNULL(A.NURSE_REMARK, '')                                       NURSE_REMARK                                             ");
		sql.append("	     , ''                                                 COMMENTS		                                                         ");
		sql.append("	     , A.MIX_GROUP                                          MIX_GROUP	                                                         ");
		sql.append("	     , A.AMT                                                AMT                                                                  ");
		sql.append("	     , A.PAY                                                PAY                                                                  ");
		sql.append("	     , A.WONYOI_ORDER_YN                                    WONYOI_ORDER_YN                                                      ");
		sql.append("	     , 'N'                                                  DANGIL_GUMSA_ORDER_YN                                                ");
		sql.append("	     , 'N'                                                  DANGIL_GUMSA_RESULT_YN                                               ");
		sql.append("	     , A.BOM_OCCUR_YN                                       BOM_OCCUR_YN	                                                     ");
		sql.append("	     , A.BOM_SOURCE_KEY                                     BOM_SOURCE_KEY	                                                     ");
		sql.append("	     , A.DISPLAY_YN                                         DISPLAY_YN		                                                     ");
		sql.append("	     , IF(A.SUNAB_DATE IS NULL, 'N', 'Y')                 SUNAB_YN			                                                     ");
		sql.append("	     , SUNAB_DATE						                  SUNAB_DATE                                                             ");
		sql.append("	     , ''                                                 SUNAB_TIME                                                             ");
		sql.append("	     , HOPE_DATE						                   HOPE_DATE                                                             ");
		sql.append("	     , A.HOPE_TIME                                          HOPE_TIME                                                            ");
		sql.append("	     , IFNULL(A.NURSE_CONFIRM_USER, '')                                 NURSE_CONFIRM_USER	                                     ");
		sql.append("	     , NURSE_CONFIRM_DATE							          NURSE_CONFIRM_DATE			                                     ");
		sql.append("	     , IFNULL(A.NURSE_CONFIRM_TIME, '')                                 NURSE_CONFIRM_TIME	                                     ");
		sql.append("	     , ''                                                 NURSE_PICKUP_USER                                                      ");
		sql.append("	     , ''                                                 NURSE_PICKUP_DATE                                                      ");
		sql.append("	     , ''                                                 NURSE_PICKUP_TIME                                                      ");
		sql.append("	     , ''                                                 NURSE_HOLD_USER                                                        ");
		sql.append("	     , ''                                                 NURSE_HOLD_DATE                                                        ");
		sql.append("	     , ''                                                 NURSE_HOLD_TIME                                                        ");
		sql.append("	     , HOPE_DATE                   							RESER_DATE	                                                         ");
		sql.append("	     , IFNULL(A.RESER_TIME, '')                             RESER_TIME	                                                         ");
		sql.append("	     , JUBSU_DATE					                  		JUBSU_DATE	                                                         ");
		sql.append("	     , IFNULL(A.JUBSU_TIME, '')                             JUBSU_TIME	                                                         ");
		sql.append("	     , ACTING_DATE                 							ACTING_DATE	                                                         ");
		sql.append("	     , IFNULL(A.ACTING_TIME,'')                             ACTING_TIME	                                                         ");
		sql.append("	     , A.ACTING_DAY                                         ACTING_DAY	                                                         ");
		sql.append("	     , RESULT_DATE							                RESULT_DATE	                                                         ");
		sql.append("	     , A.DC_GUBUN                                           DC_GUBUN	                                                         ");
		sql.append("	     , A.DC_YN                                              DC_YN		                                                         ");
		sql.append("	     , A.BANNAB_YN                                          BANNAB_YN	                                                         ");
		sql.append("	     , A.BANNAB_CONFIRM                                     BANNAB_CONFIRM                                                       ");
		sql.append("	     , A.SOURCE_FKOCS2003                                   SOURCE_ORD_KEY                                                       ");
		sql.append("	     , A.OCS_FLAG                                           OCS_FLAG	                                                         ");
		sql.append("	     , A.SG_CODE                                            SG_CODE	                                                             ");
		sql.append("	     , A.SG_YMD                                             SG_YMD	                                                             ");
		sql.append("	     , A.IO_GUBUN                                           IO_GUBUN                                                             ");
		sql.append("	     , 'N'                                                  AFTER_ACT_YN		                                                 ");
		sql.append("	     , A.BICHI_YN                                           BICHI_YN			                                                 ");
		sql.append("	     , IFNULL(A.DRG_BUNHO, '')                              DRG_BUNHO                                                            ");
		sql.append("	     , A.SUB_SUSUL                                          SUB_SUSUL                                                            ");
		sql.append("	     , A.PRINT_YN                                           PRINT_YN                                                             ");
		sql.append("	     , IFNULL(A.CHISIK, '')                                             CHISIK                                                   ");
		sql.append("	     , IFNULL(A.TEL_YN, '')                                             TEL_YN                                                   ");
		sql.append("	     , IFNULL(B.ORDER_GUBUN, '')                                        ORDER_GUBUN_BAS                                          ");
		sql.append("	     , IFNULL(B.INPUT_CONTROL, '')                                      INPUT_CONTROL                                            ");
		sql.append("	     , IFNULL(B.SUGA_YN, '')                                            SUGA_YN		                                             ");
		sql.append("	     , IFNULL(B.JAERYO_YN, '')                                          JAERYO_YN	                                             ");
		sql.append("	     , IF(B.WONYOI_ORDER_YN = 'Z', 'Y', 'N')             WONYOI_CHECK				                                             ");
		sql.append("	     , IF(B.EMERGENCY = 'Z', 'Y', 'N')                   EMERGENCY_CHECK			                                             ");
		sql.append("	     , IFNULL(B.SPECIMEN_YN, '')                                        SPECIMEN_CHECK                                           ");
		sql.append("	     , IFNULL(A.PORTABLE_YN, '')                                        PORTABLE_YN2	                                         ");
		sql.append("	     , CASE WHEN B.END_DATE IS NULL THEN 'N'											                                         ");
		sql.append("	            WHEN B.END_DATE = STR_TO_DATE('99981231','%Y%m%d') THEN 'N'					                                         ");
		sql.append("	            ELSE 'Y'																	                                         ");
		sql.append("	       END                                                  BULYONG_CHECK				                                         ");
		sql.append("	     , IF(A.SUNAB_DATE IS NULL, 'N', 'Y')                 SUNAB_CHECK	                                                         ");
		sql.append("	     , CASE SIGN(A.NALSU) WHEN 1 THEN 'N' WHEN 0 THEN 'N' ELSE 'Y' END	                                                         ");
		sql.append("																DC_CHECK	                                                         ");
		sql.append("	     , A.DC_GUBUN                                           DC_GUBUN_CHECK                                                       ");
		sql.append("	     , IF(A.NURSE_PICKUP_DATE IS NULL, 'N', 'Y')         	CONFIRM_CHECK	                                                     ");
		sql.append("	     , IF(A.RESER_DATE IS NULL, 'N', 'Y')                 RESER_YN_CHECK	                                                     ");
		sql.append("	     , IF(A.CHISIK IS NULL, 'N', 'Y')                     CHISIK_YN                                                              ");
		sql.append("	     , A.NDAY_YN                                            NDAY_YN                                                              ");
		sql.append("	     , FN_OCS_LOAD_JAERYO_JUNDAL_YN(:f_hosp_code, 'O', A.INPUT_PART, A.HANGMOG_CODE)                                             ");
		sql.append("																DEFAULT_JAERYO_JUNDAL_YN	                                         ");
		sql.append("	     , ( CASE WHEN A.ORDER_GUBUN NOT IN ('A', 'B', 'C', 'D') OR	                                                                 ");
		sql.append("	                    A.WONYOI_ORDER_YN = 'Z'                   OR                                                                 ");
		sql.append("	                    A.WONYOI_ORDER_YN = 'Y'		                                                                                 ");
		sql.append("	               THEN 'N'							                                                                                 ");
		sql.append("	               ELSE 'Y' END )                               DEFAULT_WONYOI_YN			                                         ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT, '')                                   SPECIFIC_COMMENT                                         ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_NAME, '')                              SPECIFIC_COMMENT_NAME                                    ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_SYS_ID, '')                            SPECIFIC_COMMENT_SYS_ID                                  ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_PGM_ID, '')                            SPECIFIC_COMMENT_PGM_ID                                  ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_NOT_NULL, '')                          SPECIFIC_COMMENT_NOT_NULL                                ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_TABLE_ID, '')                          SPECIFIC_COMMENT_TABLE_ID                                ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_COL_ID, '')                            SPECIFIC_COMMENT_COL_ID	                                 ");
		sql.append("	     , FN_DRG_LOAD_DONBOK_YN( A.BOGYONG_CODE, :f_hosp_code)             DONBOG_YN				                                 ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME( 'ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1), :f_hosp_code, :f_language)                         ");
		sql.append("	                                                            ORDER_GUBUN_BAS_NAME		                                         ");
		sql.append("	     , A.ACT_DOCTOR                                         ACT_DOCTOR					                                         ");
		sql.append("	     , A.ACT_BUSEO                                          ACT_BUSEO					                                         ");
		sql.append("	     , A.ACT_GWA                                            ACT_GWA						                                         ");
		sql.append("	     , 'N'                                                  HOME_CARE_YN				                                         ");
		sql.append("	     , A.REGULAR_YN                                         REGULAR_YN					                                         ");
		sql.append("	     , A.SORT_FKOCSKEY                                      SORT_FKOCSKEY				                                         ");
		sql.append("	     , CASE WHEN IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code, 'I',A.PKOCS2003),'3') != '3' THEN 'N'	     ");
		sql.append("	            ELSE 'Y'												                                                             ");
		sql.append("	       END                                                  CHILD_YN                                                             ");
		sql.append("	     , B.IF_INPUT_CONTROL                                   IF_INPUT_CONTROL                                                     ");
		sql.append("	     , IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code, 'I',A.PKOCS2003),'3') CHILD_GUBUN                       ");
		sql.append("	     , F.SLIP_NAME                                          SLIP_NAME		                                                     ");
		sql.append("	     , A.NDAY_OCCUR_YN                                      NDAY_OCCUR_YN	                                                     ");
		sql.append("	     , A.PKOCS2003                                          ORG_KEY			                                                     ");
		sql.append("	     , A.BOM_SOURCE_KEY                                     PARENT_KEY		                                                     ");
		sql.append("	     , G.BUN_CODE                                           BUN_CODE		                                                     ");
		sql.append("	     , B.WONNAE_DRG_YN                                      WONNAE_DRG_YN	                                                     ");
		sql.append("	     , IFNULL(H.TOIJANG_YN, 'N')                               HUBAL_CHANGE_CHECK                                                ");
		sql.append("	     , IFNULL(H.CHK3, 'N')                                     DRG_PACK_CHECK	                                                 ");
		sql.append("	     , IFNULL(H.CHK2, 'N')                                     PHARMACY_CHECK	                                                 ");
		sql.append("	     , IFNULL(H.CHK1, 'N')                                     POWDER_CHECK		                                                 ");
		sql.append("	     , B.LIMIT_NALSU                                        LIMIT_NALSU			                                                 ");
		sql.append("	     , B.LIMIT_SURYANG                                      LIMIT_SURYANG		                                                 ");
		sql.append("	     , A.DV_5                                                    DV_5			                                                 ");
		sql.append("	     , A.DV_6                                               DV_6				                                                 ");
		sql.append("	     , A.DV_7                                               DV_7                                                                 ");
		sql.append("	     , A.DV_8                                               DV_8				                                                 ");
		sql.append("	     , A.PKOCS1024                                          PKOCS1024			                                                 ");
		sql.append("	     , A.BROUGHT_DRG_YN                                     BROUGHT_DRG_YN		                                                 ");
		sql.append("	     , I.GWA_NAME                                           JUNDAL_PART_NAME	                                                 ");
		sql.append("	     , IFNULL(A.INSTEAD_YN, 'N')                                    INSTEAD_YN                                                   ");
		sql.append("	     , IFNULL(A.APPROVE_YN, 'N')                                    APPROVE_YN                                                   ");
		sql.append("	     , IFNULL(A.POSTAPPROVE_YN, 'N')                            POSTAPPROVE_YN                                                   ");
		sql.append("	     , A.START_DATE						                    START_DATE	                                                         ");
		sql.append("	     , A.START_TIME	                                                                                                             ");
		sql.append("	     , A.START_ID	                                                                                                             ");
		sql.append("	     , A.END_DATE					                    END_DATE                                                                 ");
		sql.append("	     , A.END_TIME	                                                                                                             ");
		sql.append("	     , A.END_ID		                                                                                                             ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_ORDER_SORT_KEY('I', A.PKOCS2003, :f_hosp_code), '')      ORDER_BY_KEY                                  ");
		sql.append("	  FROM OCS2003 A										                                                                         ");
		sql.append("	  JOIN OCS0103 B ON B.HOSP_CODE        = A.HOSP_CODE	                                                                         ");
		sql.append("				    AND B.HANGMOG_CODE     = A.HANGMOG_CODE	                                                                         ");
		sql.append("				    AND A.ORDER_DATE 	   BETWEEN B.START_DATE AND B.END_DATE                                                       ");
		sql.append("	  LEFT JOIN OCS0116 C ON C.HOSP_CODE		= A.HOSP_CODE		                                                                 ");
		sql.append("						 AND C.SPECIMEN_CODE    = A.SPECIMEN_CODE	                                                                 ");
		sql.append("	  LEFT JOIN OCS0170 D ON D.HOSP_CODE		= B.HOSP_CODE		                                                                 ");
		sql.append("						 AND D.SPECIFIC_COMMENT = B.SPECIFIC_COMMENT                                                                 ");
		sql.append("	  JOIN VW_OCS_INP1001_RES E ON E.HOSP_CODE  = A.HOSP_CODE                                                                        ");
		sql.append("							   AND E.PKINP1001  = A.FKINP1001                                                                        ");
		sql.append("	  JOIN OCS0102 F ON F.HOSP_CODE = A.HOSP_CODE                                                                                    ");
		sql.append("					AND F.SLIP_CODE = A.SLIP_CODE                                                                                    ");
		sql.append("	  LEFT JOIN ( SELECT A.SG_CODE				                                                                                     ");
		sql.append("	              , A.SG_NAME					                                                                                     ");
		sql.append("	              , A.BUN_CODE					                                                                                     ");
		sql.append("	              , A.HOSP_CODE					                                                                                     ");
		sql.append("	           FROM BAS0310 A					                                                                                     ");
		sql.append("	          WHERE A.HOSP_CODE = :f_hosp_code	                                                                                     ");
		sql.append("	            AND A.SG_YMD = ( SELECT MAX(Z.SG_YMD)	                                                                             ");
		sql.append("	                               FROM BAS0310 Z		                                                                             ");
		sql.append("	                              WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                    ");
		sql.append("	                                AND Z.SG_CODE = A.SG_CODE	                                                                     ");
		sql.append("	                                AND Z.SG_YMD <= CURRENT_DATE() )                                                                 ");
		sql.append("	  ) G ON G.HOSP_CODE = B.HOSP_CODE	                                                                                             ");
		sql.append("		 AND G.SG_CODE   = B.SG_CODE	                                                                                             ");
		sql.append("	  LEFT JOIN INV0110 H ON H.HOSP_CODE   = A.HOSP_CODE                                                                             ");
		sql.append("						 AND H.JAERYO_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	  JOIN BAS0260 I ON I.HOSP_CODE        = A.HOSP_CODE	                                                                         ");
		sql.append("					AND I.GWA              = A.JUNDAL_PART	                                                                         ");
		sql.append("	 ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP		                                                                         ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code	                                                                                         ");
		sql.append("	   AND A.BUNHO          = :f_bunho		                                                                                         ");
		sql.append("	   AND A.FKINP1001      = :f_fkinp1001	                                                                                         ");
		sql.append("	   AND (  							                                                                                             ");
		sql.append("	         ( A.INPUT_TAB      = '01'	                                                                                             ");
		sql.append("	           AND :f_order_date BETWEEN A.ORDER_DATE AND DATE_ADD(IFNULL(A.HOPE_DATE, A.ORDER_DATE), INTERVAL ABS(A.NALSU) -1 DAY) )");
		sql.append("	         OR							                                                                                             ");
		sql.append("	         ( A.INPUT_TAB     != '01'	                                                                                             ");
		sql.append("	           AND A.ORDER_DATE     = :f_order_date )                                                                                ");
		sql.append("	       )	                                                                                                                     ");
		sql.append("	   AND (	                                                                                                                     ");
		sql.append("	         ( :f_query_gubun = 'D'                                                                                                  ");
		sql.append("	           AND					                                                                                                 ");
		sql.append("	           A.INPUT_GUBUN LIKE 'D%'                                                                                               ");
		sql.append("	           AND																                                                     ");
		sql.append("	           SUBSTR(A.INPUT_DOCTOR, 3, 5) = SUBSTR(:f_input_doctor, 3, 5) )	                                                     ");
		sql.append("	         OR																	                                                     ");
		sql.append("	         ( :f_query_gubun != 'D'											                                                     ");
		sql.append("	           AND																                                                     ");
		sql.append("	           ( A.INPUT_GUBUN = :f_input_gubun OR A.INPUT_GUBUN LIKE 'D%') )	                                                     ");
		sql.append("	       )																	                                                     ");
		sql.append("	   AND IFNULL(A.DISPLAY_YN, 'Y') = 'Y'										                                                     ");
		sql.append("	 ORDER BY ORDER_BY_KEY														                                                     ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_query_gubun", queryGubun);
		query.setParameter("f_input_doctor", inputDoctor);
		query.setParameter("f_input_gubun", inputGubun);
		
		List<OCS2003P01LayQueryLayoutInfo> list = new JpaResultMapper().list(query, OCS2003P01LayQueryLayoutInfo.class);
		return list;
	}
	

	@Override
	public String getOCS2003U03getResDateinfo(String hospCode, String bunho, String pkocs2003, String kijunDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT DISTINCT CAST(B.ACT_RES_DATE AS CHAR)								");
		sql.append("	FROM OCS2003 A															");
		sql.append("	   , OCS2017 B															");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code										");
		sql.append("	AND A.BUNHO = :f_bunho													");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE											");
		sql.append("	AND B.FKOCS2003 = A.PKOCS2003											");
		sql.append("  AND A.PKOCS2003 = :f_pkocs2003											");
		sql.append("	AND B.ACT_RES_DATE >= :f_kijun_date										");
		sql.append("	AND B.ACT_RES_DATE = (SELECT DATE_ADD(C.ACT_RES_DATE, INTERVAL -1 DAY) 	");
		sql.append("							FROM OCS2017 C									");
		sql.append("						   WHERE C.HOSP_CODE = :f_hosp_code					");
		sql.append("							 AND C.FKOCS2003 = :f_pkocs2003					");
		sql.append("							 AND C.ACT_RES_DATE > :f_kijun_date				");
		sql.append("							 AND C.PASS_DATE IS NOT NULL					");
		sql.append("							 )												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkocs2003", CommonUtils.parseDouble(pkocs2003));
		query.setParameter("f_kijun_date", DateUtil.toDate(kijunDate, DateUtil.PATTERN_YYMMDD));
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callPrOcsUpdateDrgSunabDate(String hospCode, String fkocs2003, String userId) {
		String oFlag = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_DRG_SUNAB_DATE ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS2003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKOCS2003", CommonUtils.parseDouble(fkocs2003));
		query.setParameter("I_UPD_ID", userId);
		query.setParameter("O_FLAG", oFlag);
		
		query.execute();
		oFlag = (String) query.getOutputParameterValue("O_FLAG");
		return oFlag;
	}

	@Override
	public String callPrOcsiProcessBannabNew(String hospCode, String workGubun, String bunho, String fkinp1001,
			String pkocs2003, String stopDate, String stopDate2, String inputDoctor, String userId, String gubun,
			String bannabDv, String bogyongCodeReturn, String toiwonDrgDv, String toiwonDrgBogyongCode) {
		String ioErr = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_PROCESS_BANNAB_NEW");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WORK_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_DATE2", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BANNAB_DV", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BOGYONG_CODE_RETURN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DRG_DV", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DRG_BOGYONG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_WORK_GUBUN", workGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("I_PKOCS2003", CommonUtils.parseDouble(pkocs2003));
		query.setParameter("I_STOP_DATE", DateUtil.toDate(stopDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_STOP_DATE2", DateUtil.toDate(stopDate2, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_INPUT_DOCTOR", inputDoctor);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_BANNAB_DV", CommonUtils.parseDouble(bannabDv));
		query.setParameter("I_BOGYONG_CODE_RETURN", bogyongCodeReturn);
		query.setParameter("I_TOIWON_DRG_DV", CommonUtils.parseDouble(toiwonDrgDv));
		query.setParameter("I_TOIWON_DRG_BOGYONG_CODE", toiwonDrgBogyongCode);
		query.setParameter("IO_ERR", ioErr);
		
		query.execute();
		ioErr = (String) query.getOutputParameterValue("IO_ERR");
		return ioErr;
	}

	@Override
	public List<OCS2003U03grdOrderInfo> getOCS2003U03grdOrderInfo(String hospCode, String kijunDate, String bunho,
			String fkinp1001, String orderDate, String inputDoctor, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')																				");
		sql.append("       , B.HANGMOG_NAME																										");
		sql.append("       , DATE_FORMAT(CASE WHEN  A.INPUT_TAB IN ( '01', '03' ) THEN 															");
		sql.append("                  IFNULL(A.HOPE_DATE, A.ORDER_DATE)      																	");
		sql.append("              ELSE A.ORDER_DATE																								");
		sql.append("              END, '%Y/%m/%d') START_DATE																					");
		sql.append("       , DATE_FORMAT(CASE WHEN   A.INPUT_TAB IN ( '01', '03' ) THEN 														");
		sql.append("  				DATE_ADD(IFNULL(A.HOPE_DATE, A.ORDER_DATE), INTERVAL ( A.NALSU - 1) day)									");
		sql.append("              ELSE A.HOPE_DATE																								");
		sql.append("              END, '%Y/%m/%d')  END_DATE																					");
		sql.append("       , CAST(A.SURYANG AS CHAR)																							");
		sql.append("       , A.DV_TIME																											");
		sql.append("       , CAST(A.DV AS CHAR)																									");
		sql.append("       , CAST(A.NALSU AS CHAR)																								");
		sql.append("       , A.PKOCS2003																										");
		sql.append("       , A.HANGMOG_CODE																										");
		sql.append("       , CAST(CC.A AS CHAR)																									");
		sql.append("       , CAST(CC.B AS CHAR)																									");
		sql.append("       , CAST(CC.C AS CHAR)																									");
		sql.append("       , CAST(CC.D AS CHAR)																									");
		sql.append("       , CAST(CC.E AS CHAR)																									");
		sql.append("       , CAST(CC.F AS CHAR)																									");
		sql.append("       , CAST(CC.G AS CHAR)																									");
		sql.append("       , CAST(CC.H AS CHAR)																									");
		sql.append("       , CAST(CC.I AS CHAR)																									");
		sql.append("       , CAST(CC.J AS CHAR)																									");
		sql.append("       , CAST(CC.K AS CHAR)																									");
		sql.append("       , CAST(CC.L AS CHAR)																									");
		sql.append("       , CAST(CC.M AS CHAR)																									");
		sql.append("       , CAST(CC.N AS CHAR)																									");
		sql.append("       , A.ORDER_GUBUN																										");
		sql.append("    FROM OCS2003 A																											");
		sql.append("        JOIN OCS0103 B																										");
		sql.append("  				ON  B.HOSP_CODE    = A.HOSP_CODE																			");
		sql.append("  				AND B.HANGMOG_CODE = A.HANGMOG_CODE																			");
		sql.append("  				AND B.START_DATE   = (SELECT MAX(X.START_DATE)																");
		sql.append("  										 FROM OCS0103 X																		");
		sql.append("  										WHERE X.HOSP_CODE    = B.HOSP_CODE													");
		sql.append("  										  AND X.HANGMOG_CODE = B.HANGMOG_CODE												");
		sql.append("  										  AND X.START_DATE  <= A.ORDER_DATE)												");
		sql.append("        LEFT JOIN DRG3010 C																									");
		sql.append("  				ON  C.HOSP_CODE = A.HOSP_CODE																				");
		sql.append("  				AND C.FKOCS2003 = A.PKOCS2003            																	");
		sql.append("        LEFT JOIN (																											");
		sql.append("            SELECT BB.PKOCS2003																								");
		sql.append("                  ,BB.HANGMOG_CODE																							");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 0 day)  THEN BB.ACT_CNT ELSE 0 END) A	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 1 day)  THEN BB.ACT_CNT ELSE 0 END) B	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 2 day)  THEN BB.ACT_CNT ELSE 0 END) C	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 3 day)  THEN BB.ACT_CNT ELSE 0 END) D	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 4 day)  THEN BB.ACT_CNT ELSE 0 END) E	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 5 day)  THEN BB.ACT_CNT ELSE 0 END) F	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 6 day)  THEN BB.ACT_CNT ELSE 0 END) G	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 7 day)  THEN BB.ACT_CNT ELSE 0 END) H	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 8 day)  THEN BB.ACT_CNT ELSE 0 END) I	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 9 day)  THEN BB.ACT_CNT ELSE 0 END) J	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 10 day) THEN BB.ACT_CNT ELSE 0 END) K	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 11 day) THEN BB.ACT_CNT ELSE 0 END) L	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 12 day) THEN BB.ACT_CNT ELSE 0 END) M	");
		sql.append("                  ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 13 day) THEN BB.ACT_CNT ELSE 0 END) N	");
		sql.append("                  																											");
		sql.append("              FROM (																										");
		sql.append("                      SELECT AA.PKOCS2003 																					");
		sql.append("                           , AA.HANGMOG_CODE																				");
		sql.append("                           , AA.ACT_RES_DATE																				");
		sql.append("                           , AA.ACT_CNT - AA.DV ACT_CNT																		");
		sql.append("                        FROM (																								");
		sql.append("                                SELECT A.PKOCS2003																			");
		sql.append("                                     , A.HANGMOG_CODE																		");
		sql.append("                                     , B.ACT_RES_DATE																		");
		sql.append("                                     , SUM(IF(B.PASS_DATE IS NULL, 0, 1)) ACT_CNT											");
		sql.append("                                     , A.DV																					");
		sql.append("                                  FROM OCS2003 A																			");
		sql.append("                                     LEFT JOIN DRG0120 C																	");
		sql.append("            										        ON  C.HOSP_CODE    = A.HOSP_CODE								");
		sql.append("            												    AND C.BOGYONG_CODE = A.BOGYONG_CODE							");
		sql.append("                										 JOIN OCS2017 B 													");
		sql.append("                												ON  B.HOSP_CODE = A.HOSP_CODE								");
		sql.append("                												AND B.FKOCS2003 = A.PKOCS2003								");
		sql.append("                                     LEFT JOIN ADM3200 D																	");
		sql.append("                												ON  D.HOSP_CODE = B.HOSP_CODE								");
		sql.append("                												AND D.USER_ID   = B.PASS_USER								");
		sql.append("                                  WHERE A.HOSP_CODE = :f_hosp_code															");
		sql.append("                                  GROUP BY A.PKOCS2003, A.HANGMOG_CODE, B.ACT_RES_DATE, A.DV								");
		sql.append("                                  ORDER BY A.PKOCS2003, A.HANGMOG_CODE, B.ACT_RES_DATE, A.DV								");
		sql.append("                              ) AA																							");
		sql.append("                    ) BB																									");
		sql.append("              GROUP BY BB.PKOCS2003, BB.HANGMOG_CODE																		");
		sql.append("              ) CC																											");
		sql.append("  	ON  CC.PKOCS2003 = A.PKOCS2003  																						");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code																						");
		sql.append("     AND A.JUNDAL_PART  != 'HOM'																							");
		sql.append("     AND A.INPUT_GUBUN LIKE 'D%'																							");
		sql.append("     AND A.NALSU        > 0																									");
		sql.append("     AND A.DC_YN        != 'Y'																								");
		sql.append("     																														");
		sql.append("     AND  ( 																												");
		sql.append("           ( ( A.INPUT_TAB IN ( '01','03')    	 																			");
		sql.append("               AND FN_OCS_CAN_ORDER_END(:f_hosp_code, A.PKOCS2003) != '1' 													");
		sql.append("               AND A.NDAY_YN = 'N' AND A.NALSU > 0 AND A.DC_YN = 'N'														");
		sql.append("               )																											");
		sql.append("             OR																												");
		sql.append("              (A.INPUT_TAB NOT IN ( '01', '03' )    																		");
		sql.append("               AND FN_OCS_CAN_ORDER_END(:f_hosp_code, A.PKOCS2003) != '1' 													");
		sql.append("               AND A.ACTING_DATE IS  NULL AND A.NALSU > 0 AND A.DC_YN = 'N' 												");
		sql.append("              )																												");
		sql.append("           )                      																							");
		sql.append("           OR																												");
		sql.append("           ( 																												");
		sql.append("            ( A.INPUT_TAB IN ( '01','03')    																				");
		sql.append("              AND A.NDAY_YN = 'N' AND A.NALSU > 0 AND A.DC_YN = 'Y' 	 													");
		sql.append("            )																												");
		sql.append("            OR																												");
		sql.append("            (A.INPUT_TAB NOT IN ( '01', '03' )    																			");
		sql.append("             AND A.ACTING_DATE IS  NULL AND A.NALSU > 0 AND A.DC_YN = 'Y'													");
		sql.append("             )																												");
		sql.append("           )																												");
		sql.append("         )  																												");
		sql.append("       AND A.INPUT_TAB    != '10'    																						");
		sql.append("   AND  (('N' = 'Y')																										");
		sql.append("          OR ('N' = 'N' AND SUBSTR(A.ORDER_GUBUN, 2, 1) NOT IN ('D')))														");
		sql.append("   AND A.BUNHO        = :f_bunho																							");
		sql.append("   AND A.FKINP1001    = :f_fkinp1001																						");
		sql.append("   AND A.ORDER_DATE   = STR_TO_DATE(:f_order_date ,'%Y/%m/%d')																");
		sql.append("   AND A.INPUT_DOCTOR = :f_input_doctor																						");
		sql.append("  ORDER BY START_DATE, END_DATE																								");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_kijun_date", kijunDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_doctor", inputDoctor);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2003U03grdOrderInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03grdOrderInfo.class);
		return lstResult;
	}

	@Override
	public List<OCS2003U03grdOcs2017Info> getOCS2003U03grdOcs2017Info(String hospCode, String language, String pkocs2003,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT B.ACT_RES_DATE ACT_RES_DATE										");
		sql.append("       , B.SEQ																");
		sql.append("       , IFNULL(FN_BAS_LOAD_CODE_NAME('DV_PATTERN_GUBUN', IF(B.SEQ = '0', '0', LENGTH(SUBSTRING_INDEX(SUBSTR(C.PATTERN,2), '1', B.SEQ)) + 1), :f_hosp_code, :f_language), B.SEQ) AS PATTERN_GUBUN");
		sql.append("       , IF(B.PASS_DATE IS NULL, '●', '×') ACT_YN							");
		sql.append("       , B.PASS_USER														");
		sql.append("       , D.USER_NM 															");
		sql.append("    FROM OCS2003 A															");
		sql.append("       JOIN OCS2017 B														");
		sql.append("  		ON  B.HOSP_CODE = A.HOSP_CODE										");
		sql.append("  		AND B.FKOCS2003 = A.PKOCS2003										");
		sql.append("       LEFT JOIN DRG0120 C													");
		sql.append("  		ON  C.HOSP_CODE    = A.HOSP_CODE									");
		sql.append("  		AND C.BOGYONG_CODE = A.BOGYONG_CODE									");
		sql.append("       LEFT JOIN ADM3200 D													");
		sql.append("  		ON  D.HOSP_CODE = B.HOSP_CODE										");
		sql.append("  		AND D.USER_ID   = B.PASS_USER										");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code											");
		sql.append("     AND A.PKOCS2003 = :f_pkocs2003											");
		sql.append("  ORDER BY B.ACT_RES_DATE, B.SEQ											");		
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", CommonUtils.parseDouble(pkocs2003));
		query.setParameter("f_language", language);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2003U03grdOcs2017Info> lstResult = new JpaResultMapper().list(query, OCS2003U03grdOcs2017Info.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03grdOrderdateInfo> getOCS2003U03grdOrderdateInfo(String hospCode, String fkinp1001, String bunho, 
			String orderDate, String inputGubun, String gaiyouYn, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();

		sql.append("     SELECT DISTINCT																																		");
		sql.append("            DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d') ORDER_DATE,																								");
		sql.append("            DATE_FORMAT(A.ORDER_DATE,'%m/%d')              ORDER_DATE_MD,																					");
		sql.append("            A.BUNHO,																																		");
		sql.append("            A.FKINP1001,																																	");
		sql.append("            A.INPUT_DOCTOR                                         INPUT_DOCTOR,																			");
		sql.append("            IFNULL(FN_BAS_LOAD_DOCTOR_NAME (A.INPUT_DOCTOR, A.ORDER_DATE, A.HOSP_CODE), '') DOCTOR_NAME,													");
		sql.append("            :f_input_gubun                                                           INPUT_GUBUN,															");
		sql.append("     																																						");
		sql.append("            IFNULL(MAX(CASE (SUBSTR(A.ORDER_GUBUN, 2, 1)) WHEN 'C' THEN 																					");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_01_C,																		");
		sql.append("            IFNULL(MAX(CASE (SUBSTR(A.ORDER_GUBUN, 2, 1)) WHEN 'D' THEN 																					");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_01_D,																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '03' THEN																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_03, 																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '04' THEN 																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_04,																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '05' THEN 																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_05, 																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '07' THEN 																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_07, 																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '08' THEN																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR))	");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_08, 																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '09' THEN 																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR)) ");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_09, 																		");
		sql.append("            IFNULL(MAX(CASE (A.INPUT_TAB) WHEN '11' THEN																									");
		sql.append(" (CASE (FN_OCS_IS_MUST_BANNAB_ORDER(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.ORDER_GUBUN, A.FKINP1001, A.INPUT_DOCTOR)) ");
		sql.append("                   WHEN 'Y' THEN '×' ELSE '●' END) ELSE NULL END), '') INPUT_TAB_11, 																		");
		sql.append("            FN_OCS_IS_BANNAB_ABLE_ORDER(A.HOSP_CODE, A.BUNHO, A.FKINP1001, A.INPUT_DOCTOR, A.ORDER_DATE, :f_gaiyou_yn) DC_ABLE_GUBUN						");
		sql.append("       FROM OCS2003 A																																		");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code																													");
		sql.append("        AND A.BUNHO       = :f_bunho																														");
		sql.append("        AND A.FKINP1001   = :f_fkinp1001																													");
		sql.append("        AND A.JUNDAL_PART <> 'HOM'																															");
		sql.append("        AND ( IFNULL(A.DC_GUBUN,'N') = 'Y' OR A.INPUT_GUBUN   LIKE 'D%' ) 																					");
		sql.append("        AND ((																																				");
		sql.append("              A.INPUT_TAB IN ( '01', '03' )																													");
		sql.append("              AND FN_OCS_CAN_ORDER_END(A.HOSP_CODE, A.PKOCS2003) != '1'																						");
		sql.append("             )																																				");
		sql.append("             OR																																				");
		sql.append("             ( 																																				");
		sql.append("              A.INPUT_TAB NOT IN ( '01', '03' ) AND A.ACTING_DATE IS NULL 																					");
		sql.append("             )																																				");
		sql.append("            )																																				");
		sql.append("        AND A.NALSU              >= 0 																														");
		sql.append("        AND IFNULL(A.NDAY_YN,'N') = 'N' 																													");
		sql.append("        AND (   (:f_gaiyou_yn = 'Y')																														");
		sql.append("             OR (:f_gaiyou_yn = 'N' AND SUBSTR(A.ORDER_GUBUN, 2, 1) NOT IN ('D'))																			");
		sql.append("            )																																				");
		sql.append("        AND (   (IFNULL(A.INSTEAD_YN, 'N') = 'N')																											");
		sql.append("             OR (IFNULL(A.INSTEAD_YN, 'N') = 'Y' AND IFNULL(A.APPROVE_YN, 'N') = 'Y')																		");
		sql.append("            )																																				");
		sql.append("      GROUP BY A.ORDER_DATE,																																");
		sql.append("               A.BUNHO,																																		");
		sql.append("               A.FKINP1001,																																	");
		sql.append("               A.INPUT_DOCTOR, 																																");
		sql.append("               FN_BAS_LOAD_DOCTOR_NAME (A.INPUT_DOCTOR, A.ORDER_DATE, A.HOSP_CODE),																			");
		sql.append("               FN_OCS_IS_BANNAB_ABLE_ORDER(A.HOSP_CODE, A.BUNHO, A.FKINP1001, A.INPUT_DOCTOR, A.ORDER_DATE, :f_gaiyou_yn)									");
		sql.append("      ORDER BY A.ORDER_DATE DESC																															");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_start_num, :f_offset																															");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_gaiyou_yn", gaiyouYn);
		if(startNum != null && offset !=null){
			query.setParameter("f_start_num", startNum);
			query.setParameter("f_offset", offset);
		}
		List<OCS2003U03grdOrderdateInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03grdOrderdateInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03grdDrugOrderInfo> getOCS2003U03grdDrugOrderInfo(String hospCode, String language, String bunho, Double fkinp1001, String gwa, String doctor,
			String inputTab, String queryDate, String queryGubun, String gaiyouYn, String kijunDate, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();

		sql.append("     SELECT Z.BUNHO																																						");
		sql.append("          , Z.FKINP1001																																					");
		sql.append("          , Z.PKOCS2003																																					");
		sql.append("          , DATE_FORMAT(Z.START_DATE, '%Y/%m/%d') START_DATE																											");
		sql.append("          , DATE_FORMAT(IFNULL(Z.END_DATE, Z.START_DATE), '%Y/%m/%d') END_DATE																							");
		sql.append("          , DATE_FORMAT(Z.STOP_DATE, '%Y/%m/%d')																														");
		sql.append("          , DATE_FORMAT(Z.STOP_END_DATE, '%Y/%m/%d')																													");
		sql.append("          , DATE_FORMAT(Z.ACTING_DATE, '%Y/%m/%d')																														");
		sql.append("          , CAST(Z.GROUP_SER AS CHAR)																																					");
		sql.append("          , Z.INPUT_GUBUN																																				");
		sql.append("          , IFNULL(Z.INPUT_GUBUN_NAME, '')																																");
		sql.append("          , Z.HANGMOG_CODE																																				");
		sql.append("          , IFNULL(Z.HANGMOG_NAME, '')																																	");
		sql.append("          , CAST(Z.SURYANG AS CHAR)																																		");
		sql.append("          , IFNULL(Z.DANUI, '')																																			");
		sql.append("          , Z.DV_TIME																																					");
		sql.append("          , CAST(Z.DV AS CHAR)																																			");
		sql.append("          , CAST(Z.NALSU AS CHAR)																																		");
		sql.append("          , Z.BOGYONG_CODE																																				");
		sql.append("          , Z.BOGYONG_NAME																																				");
		sql.append("          , Z.ORDER_REMARK																																				");
		sql.append("          , Z.SELECT_YN																																					");
		sql.append("          , Z.MIX_GROUP																																					");
		sql.append("          , IFNULL(Z.DRG_BUNHO, '')																																		");
		sql.append("          , IFNULL(DATE_FORMAT(Z.JUBSU_DATE, '%Y/%m/%d'), '')																											");
		sql.append("          , Z.ORDER_GUBUN																																				");
		sql.append("          , Z.INPUT_TAB																																					");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('INPUT_TAB', Z.INPUT_TAB, Z.HOSP_CODE, :f_language)    INPUT_TAB_NAME																	");
		sql.append("          , Z.SPECIMEN_NAME																																				");
		sql.append("          , Z.DC_YN																																						");
		sql.append("          , Z.INPUT_DOCTOR																																				");
		sql.append("          , Z.IF_DATA_SEND_YN																																			");
		sql.append("          , IFNULL(DATE_FORMAT(Z.OCS_ACTING_DATE, '%Y/%m/%d'), '')																										");
		sql.append("          , IFNULL(Z.OCS_FLAG, '')																																		");
		sql.append("          , DATE_FORMAT(Z.ORDER_DATE, '%Y/%m/%d')																														");
		sql.append("          , IFNULL(DATE_FORMAT(Z.PERFECT_ACT_DATE, '%Y/%m/%d'), '')																										");
		sql.append("          , CAST(Z.A AS CHAR)																																							");
		sql.append("          , CAST(Z.B AS CHAR)																																							");
		sql.append("          , CAST(Z.C AS CHAR)																																							");
		sql.append("          , CAST(Z.D AS CHAR)																																							");
		sql.append("          , CAST(Z.E AS CHAR)																																							");
		sql.append("          , CAST(Z.F AS CHAR)																																							");
		sql.append("          , CAST(Z.G AS CHAR)																																							");
		sql.append("          , CAST(Z.H AS CHAR)																																							");
		sql.append("          , CAST(Z.I AS CHAR)																																							");
		sql.append("          , CAST(Z.J AS CHAR)																																							");
		sql.append("          , CAST(Z.K AS CHAR)																																							");
		sql.append("          , CAST(Z.L AS CHAR)																																							");
		sql.append("          , CAST(Z.M AS CHAR)																																							");
		sql.append("          , CAST(Z.N AS CHAR)																																							");
		sql.append("     FROM (																																								");
		sql.append("           SELECT A.BUNHO                                        BUNHO																									");
		sql.append("                 , A.HOSP_CODE                                   HOSP_CODE																								");
		sql.append("                 , A.FKINP1001                                   FKINP1001																								");
		sql.append("                 , A.PKOCS2003                                   PKOCS2003																								");
		sql.append("                 , CASE WHEN  A.INPUT_TAB IN ( '01', '03' ) THEN 																										");
		sql.append("                              IFNULL(A.HOPE_DATE, A.ORDER_DATE)      																									");
		sql.append("                        ELSE A.ORDER_DATE																																");
		sql.append("                        END START_DATE																																	");
		sql.append("                 , CASE WHEN   A.INPUT_TAB IN ( '01', '03' ) THEN 																										");
		sql.append("                              DATE_ADD(IFNULL(A.HOPE_DATE, A.ORDER_DATE), INTERVAL ( A.NALSU - 1) DAY)																	");
		sql.append("                        ELSE A.HOPE_DATE																																");
		sql.append("                        END  END_DATE																																	");
		sql.append("                 , CASE(A.DC_YN) WHEN 'N' THEN NULL ELSE DATE_FORMAT(FN_OCSI_LOAD_BANNAB_FROM_DATE(A. HOSP_CODE, A.PKOCS2003),'%Y/%m/%d') END  STOP_DATE 				");
		sql.append("                 , CASE(A.DC_YN) WHEN 'N' THEN NULL ELSE DATE_FORMAT(FN_OCSI_LOAD_BANNAB_TO_DATE(A.HOSP_CODE, A.PKOCS2003),'%Y/%m/%d') END  STOP_END_DATE 				");
		sql.append("                 , A.GROUP_SER                                            GROUP_SER																						");
		sql.append("                 , A.INPUT_GUBUN                                          INPUT_GUBUN																					");
		sql.append("                 , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, A.HOSP_CODE, :f_language)    INPUT_GUBUN_NAME													");
		sql.append("                 , A.HANGMOG_CODE                                         HANGMOG_CODE																					");
		sql.append("                 , B.HANGMOG_NAME                                         HANGMOG_NAME																					");
		sql.append("                 , A.SURYANG                                              SURYANG																						");
		sql.append("                 , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, A.HOSP_CODE, :f_language)        DANUI																");
		sql.append("                 , A.DV_TIME                                              DV_TIME																						");
		sql.append("                 , A.DV                                                   DV																							");
		sql.append("                 , A.NALSU                                                NALSU																							");
		sql.append("                 , A.BOGYONG_CODE                                         BOGYONG_CODE																					");
		sql.append("                 , CASE WHEN A.ORDER_GUBUN IN ('0B') THEN 																												");
		sql.append("                             CONCAT(FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, A.HOSP_CODE, :f_language), '   ',																");
		sql.append("                             FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, A.HOSP_CODE, :f_language))										");
		sql.append("                   ELSE FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, A.HOSP_CODE, :f_language)												");
		sql.append("                   END BOGYONG_NAME																																		");
		sql.append("                  , A.ORDER_REMARK                                         ORDER_REMARK																					");
		sql.append("                  ,'N'                                                     SELECT_YN																					");
		sql.append("                  , A.INPUT_TAB                                            INPUT_TAB																					");
		sql.append("                  , A.SEQ                                                  SEQ																							");
		sql.append("                  , A.MIX_GROUP                                              MIX_GROUP																					");
		sql.append("                  , C.DRG_BUNHO                                              DRG_BUNHO																					");
		sql.append("                  , C.JUBSU_DATE                                              JUBSU_DATE																				");
		sql.append("                  , A.ORDER_GUBUN                                          ORDER_GUBUN																					");
		sql.append("                  , A.ORDER_DATE                                           ORDER_DATE																					");
		sql.append("                  , FN_CHT_LOAD_SPECIMEN_NAME(A.HOSP_CODE, A.SPECIMEN_CODE)             SPECIMEN_NAME 																	");
		sql.append("                  , A.DC_YN                                  DC_YN																										");
		sql.append("                  , FN_OCSI_LOAD_MAX_ACTING_DATE(A.HOSP_CODE, A.PKOCS2003)              ACTING_DATE																		");
		sql.append("                  , A.INPUT_DOCTOR                                         INPUT_DOCTOR																					");
		sql.append("                  , A.IF_DATA_SEND_YN                                      IF_DATA_SEND_YN																				");
		sql.append("                  , A.ACTING_DATE                                          OCS_ACTING_DATE																				");
		sql.append("                  , CASE(A.OCS_FLAG) WHEN 2  THEN (CASE(A.JUBSU_DATE) WHEN '' THEN '5' ELSE A.OCS_FLAG END) ELSE A.OCS_FLAG END OCS_FLAG								");
		sql.append("                  , FN_OCSI_LOAD_PERFECT_ACT_DATE(A.PKOCS2003, A.HOSP_CODE)             PERFECT_ACT_DATE																");
		sql.append("                  , CC.A																																				");
		sql.append("                  , CC.B																																				");
		sql.append("                  , CC.C																																				");
		sql.append("                  , CC.D																																				");
		sql.append("                  , CC.E																																				");
		sql.append("                  , CC.F																																				");
		sql.append("                  , CC.G																																				");
		sql.append("                  , CC.H																																				");
		sql.append("                  , CC.I																																				");
		sql.append("                  , CC.J																																				");
		sql.append("                  , CC.K																																				");
		sql.append("                  , CC.L																																				");
		sql.append("                  , CC.M																																				");
		sql.append("                  , CC.N																																				");
		sql.append("                 FROM OCS2003 A																																			");
		sql.append("                 JOIN OCS0103 B																																			");
		sql.append("                   ON B.HOSP_CODE    = A.HOSP_CODE																														");
		sql.append("                  AND B.HANGMOG_CODE = A.HANGMOG_CODE																													");
		sql.append("                  AND B.START_DATE   = (SELECT MAX(X.START_DATE)																										");
		sql.append("                                          FROM OCS0103 X																												");
		sql.append("                                         WHERE X.HOSP_CODE    = B.HOSP_CODE																								");
		sql.append("                                           AND X.HANGMOG_CODE = B.HANGMOG_CODE																							");
		sql.append("                                           AND X.START_DATE  <= A.ORDER_DATE)																							");
		sql.append("                  AND  ((:f_gaiyou_yn = 'Y')																															");
		sql.append("                         OR (:f_gaiyou_yn = 'N' AND B.ORDER_GUBUN NOT IN ('D')))																						");
		sql.append("             LEFT JOIN DRG3010 C																																		");
		sql.append("                    ON C.HOSP_CODE = A.HOSP_CODE																														");
		sql.append("                   AND C.FKOCS2003 = A.PKOCS2003																														");
		sql.append("             LEFT JOIN (																																				");
		sql.append("                     SELECT BB.PKOCS2003																																");
		sql.append("                           ,BB.HANGMOG_CODE																																");
		sql.append("                           ,BB.START_DATE																																");
		sql.append("                           ,BB.END_DATE																																	");
		sql.append(" 					 	   ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 0 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"A\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 1 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"B\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 2 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"C\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 3 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"D\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 4 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"E\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 5 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"F\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 6 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"G\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 7 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"H\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 8 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"I\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 9 DAY)  THEN BB.ACT_CNT ELSE 0 END) \"J\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 10 DAY) THEN BB.ACT_CNT ELSE 0 END) \"K\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 11 DAY) THEN BB.ACT_CNT ELSE 0 END) \"L\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 12 DAY) THEN BB.ACT_CNT ELSE 0 END) \"M\"			");
		sql.append("                           ,SUM( CASE STR_TO_DATE(DATE_FORMAT(BB.ACT_RES_DATE, '%Y/%m/%d'), '%Y/%m/%d') WHEN DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'), INTERVAL 13 DAY) THEN BB.ACT_CNT ELSE 0 END) \"N\"			");
		sql.append("                           																																				");
		sql.append("                       FROM (																																			");
		sql.append("                               SELECT AA.PKOCS2003 																														");
		sql.append("                                    , AA.HANGMOG_CODE																													");
		sql.append("                                    , AA.ACT_RES_DATE																													");
		sql.append("                                    , AA.ACT_CNT - AA.DV ACT_CNT																										");
		sql.append("                                    , AA.START_DATE																														");
		sql.append("                                    , AA.END_DATE																														");
		sql.append("                                 FROM (																																	");
		sql.append("                                         SELECT AB.PKOCS2003																											");
		sql.append("                                              , AB.HANGMOG_CODE																											");
		sql.append("                                              , B.ACT_RES_DATE																											");
		sql.append("                                              , SUM(CASE WHEN(B.PASS_DATE IS NOT NULL) THEN 1 ELSE 0 END) ACT_CNT														");
		sql.append("                                              , AB.DV																													");
		sql.append("                                              																															");
		sql.append("                                              , CASE WHEN  AB.INPUT_TAB IN ( '01', '03' ) THEN 																			");
		sql.append("                                                         IFNULL(AB.HOPE_DATE, AB.ORDER_DATE)      																		");
		sql.append("                                                     ELSE AB.ORDER_DATE																									");
		sql.append("                                                     END START_DATE																										");
		sql.append("                                              , CASE WHEN   AB.INPUT_TAB IN ( '01', '03' ) THEN 																		");
		sql.append("                                                         DATE_ADD(IFNULL(AB.HOPE_DATE, AB.ORDER_DATE), INTERVAL ( AB.NALSU - 1) DAY)									");
		sql.append("                                                     ELSE AB.HOPE_DATE																									");
		sql.append("                                                     END  END_DATE																										");
		sql.append("                                                     																													");
		sql.append("                                           FROM OCS2003 AB																												");
		sql.append("                                           JOIN OCS2017 B																												");
		sql.append("                                             ON B.HOSP_CODE = AB.HOSP_CODE																								");
		sql.append("                                            AND B.FKOCS2003 = AB.PKOCS2003																								");
		sql.append("                                      LEFT JOIN DRG0120 C																												");
		sql.append("                                             ON C.HOSP_CODE = AB.HOSP_CODE																								");
		sql.append("                                            AND C.BOGYONG_CODE = AB.BOGYONG_CODE																						");
		sql.append("                                      LEFT JOIN ADM3200 D																												");
		sql.append("                                             ON D.HOSP_CODE = B.HOSP_CODE																								");
		sql.append("                                            AND D.USER_ID   = B.PASS_USER																								");
		sql.append("                                          WHERE AB.HOSP_CODE = :f_hosp_code																								");
		sql.append("     																																									");
		sql.append("                                         GROUP BY AB.PKOCS2003, AB.HANGMOG_CODE, B.ACT_RES_DATE, AB.DV																	");
		sql.append("                                              , CASE WHEN  AB.INPUT_TAB IN ( '01', '03' ) THEN 																			");
		sql.append("                                                         IFNULL(AB.HOPE_DATE, AB.ORDER_DATE)      																		");
		sql.append("                                                     ELSE AB.ORDER_DATE																									");
		sql.append("                                                     END																												");
		sql.append("                                              , CASE WHEN   AB.INPUT_TAB IN ( '01', '03' ) THEN 																		");
		sql.append("                                                         DATE_ADD(IFNULL(AB.HOPE_DATE, AB.ORDER_DATE), INTERVAL ( AB.NALSU - 1)	DAY)									");
		sql.append("                                                     ELSE AB.HOPE_DATE																									");
		sql.append("                                                     END																												");
		sql.append("                                         ORDER BY AB.PKOCS2003, AB.HANGMOG_CODE, B.ACT_RES_DATE, AB.DV																	");
		sql.append("                                       ) AA																																");
		sql.append("                             ) BB																																		");
		sql.append("                       GROUP BY BB.PKOCS2003, BB.HANGMOG_CODE, BB.START_DATE,BB.END_DATE																				");
		sql.append("                       ) CC																																				");
		sql.append("                   ON CC.PKOCS2003   = A.PKOCS2003																														");
		sql.append("                WHERE A.HOSP_CODE    = :f_hosp_code																														");
		sql.append("                  AND A.BUNHO        = :f_bunho																															");
		sql.append("                  AND A.FKINP1001    = :f_fkinp1001																														");
		sql.append("                  AND A.JUNDAL_PART  != 'HOM'																															");
		sql.append("                  AND A.INPUT_DOCTOR = :f_doctor																														");
		sql.append("                  AND A.INPUT_GUBUN LIKE 'D%'																															");
		sql.append("                  AND A.NALSU        > 0																																");
		sql.append("     																																									");
		sql.append("                  AND (   (IFNULL(A.INSTEAD_YN, 'N') = 'N')																												");
		sql.append("                       OR (IFNULL(A.INSTEAD_YN, 'N') = 'Y' AND IFNULL(A.APPROVE_YN, 'N') = 'Y')																			");
		sql.append("                      )																																					");
		sql.append("     																																									");
		sql.append("                  AND  ( 																																				");
		sql.append("                        ( ( A.INPUT_TAB IN ( '01','03') 																												");
		sql.append("                            AND FN_OCS_CAN_ORDER_END(A.HOSP_CODE, A.PKOCS2003) != '1'																					");
		sql.append("                            AND A.NDAY_YN = 'N' AND A.NALSU > 0 AND A.DC_YN != 'Y'																						");
		sql.append("                            )																																			");
		sql.append("                          OR																																			");
		sql.append("                           (A.INPUT_TAB NOT IN ( '01', '03' ) 																											");
		sql.append("                            AND FN_OCS_CAN_ORDER_END(A.HOSP_CODE, A.PKOCS2003) != '1'																					");
		sql.append("                            AND A.ACTING_DATE IS  NULL AND A.NALSU > 0 AND A.DC_YN != 'Y' 																				");
		sql.append("                           )																																			");
		sql.append("                        )                      																															");
		sql.append("                        OR																																				");
		sql.append("                        ( 																																				");
		sql.append("                         ( A.INPUT_TAB IN ( '01','03')	 																												");
		sql.append("                           AND A.NDAY_YN = 'N' AND A.NALSU > 0 AND A.DC_YN = 'Y'  																						");
		sql.append("                         )																																				");
		sql.append("                         OR																																				");
		sql.append("                         (A.INPUT_TAB NOT IN ( '01', '03' ) 																											");
		sql.append("                          AND A.ACTING_DATE IS  NULL AND A.NALSU > 0 AND A.DC_YN = 'Y'																					");
		sql.append("                          )																																				");
		sql.append("                        )																																				");
		sql.append("                      )  																																				");
		sql.append("                    AND A.INPUT_TAB    != '10'																															");
		sql.append("                 ) Z																																					");
		sql.append("      WHERE Z.ORDER_DATE = :f_query_date																																");
		sql.append("      ORDER BY Z.INPUT_TAB, Z.INPUT_GUBUN, Z.START_DATE, Z.GROUP_SER, Z.SEQ																								");

		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_start_num, :f_offset																																		");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_kijun_date", kijunDate);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gaiyou_yn", gaiyouYn);
		query.setParameter("f_query_date", queryDate);
		if(startNum != null && offset !=null){
			query.setParameter("f_start_num", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<OCS2003U03grdDrugOrderInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03grdDrugOrderInfo.class);
		return lstResult;
	}
	
	@Override
	public List<DataStringListItemInfo> getOCS2003U03getPkocskey(Double pkocskey, String workGubun, String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("        SELECT DISTINCT CAST(A.PKOCS2003 AS CHAR) PKOCS2003					");
		sql.append("          FROM OCS2003 A													");
		sql.append("         WHERE A.HOSP_CODE          = :f_hosp_code							");
		if(!workGubun.equals("C"))
			sql.append("           AND A.SOURCE_FKOCS2003   = :f_pkocs2003						");
		else
			sql.append("           AND A.PKOCS2003   = :f_pkocs2003								");
	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocskey);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public String getCountOCS2003U03(String hospCode, Double pkocs2003, String actResDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT  COUNT(*) CNT																	");
		sql.append("        FROM OCS2003 A																		");
		sql.append("        JOIN OCS2017 B																		");
		sql.append("          ON B.HOSP_CODE               = A.HOSP_CODE										");
		sql.append("         AND B.FKOCS2003               = A.PKOCS2003										");
		sql.append("         AND B.ACT_RES_DATE            = STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')			");
		sql.append("         AND IFNULL(B.BANNAB_YN, 'N')  != 'Y'												");
		sql.append("         AND B.PASS_DATE               IS NOT NULL											");
		sql.append("       WHERE A.HOSP_CODE = :f_hosp_code														");
		sql.append("         AND A.PKOCS2003 = :f_pkocs2003														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocs2003);
		query.setParameter("f_act_res_date", actResDate);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return "0";
	}
	
	@Override
	public String getOCS2003U03StopStartDate(String hospCode, Double pkocs2003){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT DATE_FORMAT(MIN(A.ACT_RES_DATE), '%Y/%m/%d')						");
		sql.append("       FROM OCS2017 A															");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code											");
		sql.append("        AND A.FKOCS2003 = :f_pkocs2003											");
		sql.append("        AND A.PASS_DATE IS NULL													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocs2003);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public String getOCS2003U03StopEndDate(String hospCode, Double pkocs2003, String stopStartDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT DATE_FORMAT(DATE_ADD(MIN(AA.ACT_RES_DATE), INTERVAL -1 DAY), '%Y/%m/%d') ACT_RES_DATE				");
		sql.append("       FROM (																									");
		sql.append("             SELECT A.DV																						");
		sql.append("                  , B.ACT_RES_DATE																				");
		sql.append("                  , COUNT(*) ACT_CNT																			");
		sql.append("               FROM OCS2003 A																					");
		sql.append("               JOIN OCS2017 B																					");
		sql.append("                 ON B.HOSP_CODE = A.HOSP_CODE																	");
		sql.append("                AND B.FKOCS2003 = A.PKOCS2003																	");
		sql.append("                AND B.PASS_DATE IS NOT NULL																		");
		sql.append("                AND B.ACT_RES_DATE > STR_TO_DATE(:f_stop_start_date, '%Y/%m/%d')								");
		sql.append("              WHERE A.HOSP_CODE = :f_hosp_code																	");
		sql.append("                AND A.PKOCS2003 = :f_pkocs2003																	");
		sql.append("              GROUP BY A.DV, B.ACT_RES_DATE																		");
		sql.append("              ) AA																								");
		sql.append("      ORDER BY AA.ACT_RES_DATE																					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocs2003);
		query.setParameter("f_stop_start_date", stopStartDate);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public String getOCS2003U03ActResDate (String hospCode, Double pkocs2003, String bunho, String kijunDate, String stopDate,
			String stopEndDate, String controlId){
		StringBuilder sql = new StringBuilder();
		if(controlId.equals("end")){
			sql.append("     SELECT DISTINCT DATE_FORMAT(B.ACT_RES_DATE, '%Y/%m/%d')										");
			sql.append("     FROM OCS2003 A																					");
			sql.append("     JOIN OCS2017 B																					");
			sql.append("       ON B.HOSP_CODE    = A.HOSP_CODE																");
			sql.append("      AND B.FKOCS2003    = A.PKOCS2003																");
			sql.append("      AND B.ACT_RES_DATE >= :f_kijun_date															");
			sql.append("      AND B.ACT_RES_DATE = (SELECT DATE_ADD(MIN(C.ACT_RES_DATE), INTERVAL -1 DAY)					");
			sql.append("                              FROM OCS2017 C														");
			sql.append("                             WHERE C.HOSP_CODE    = B.HOSP_CODE										");
			sql.append("                               AND C.FKOCS2003    = B.FKOCS2003										");
			sql.append("                               AND C.ACT_RES_DATE > STR_TO_DATE(:f_kijun_date, '%Y/%m/%d')			");
			sql.append("                               AND C.PASS_DATE    IS NOT NULL)										");
			sql.append("     WHERE A.HOSP_CODE = :f_hosp_code																");
			sql.append("       AND A.BUNHO     = :f_bunho																	");
			sql.append("       AND A.PKOCS2003 = :f_pkocs2003																");
			sql.append("      ORDER BY AA.ACT_RES_DATE																		");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_pkocs2003", pkocs2003);
			query.setParameter("f_kijun_date", kijunDate);
			query.setParameter("bunho", bunho);
			
			List<Object> result = query.getResultList();
			if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
				return result.get(0).toString();
			}
			return null;
		}else{
			sql.append("     SELECT DISTINCT DATE_FORMAT(B.ACT_RES_DATE, '%Y/%m/%d')										");
			sql.append("     FROM OCS2003 A																					");
			sql.append("     JOIN OCS2017 B																					");
			sql.append("       ON B.HOSP_CODE = A.HOSP_CODE																	");
			sql.append("      AND B.FKOCS2003 = A.PKOCS2003																	");
			sql.append("      AND B.ACT_RES_DATE BETWEEN STR_TO_DATE(:f_stop_date, '%Y/%m/%d')								");
			sql.append("                             AND STR_TO_DATE(:f_stop_end_date, '%Y/%m/%d')							");
			sql.append("      AND B.PASS_DATE IS NOT NULL																	");
			sql.append("     WHERE A.HOSP_CODE = :f_hosp_code																");
			sql.append("       AND A.BUNHO     = :f_bunho																	");
			sql.append("       AND A.PKOCS2003 = :f_pkocs2003																");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_pkocs2003", pkocs2003);
			query.setParameter("f_stop_date", stopDate);
			query.setParameter("f_stop_end_date", stopEndDate);
			query.setParameter("bunho", bunho);
			
			List<Object> result = query.getResultList();
			if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
				return result.get(0).toString();
			}
			return null;
		}
	}
	
	@Override
	public String getOCS2003U03DV(String hospCode, Double pkocs2003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(A.DV AS CHAR)								");
		sql.append("       FROM OCS2003 A										");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("        AND A.PKOCS2003 = :f_pkocs2003						");
		sql.append("        AND IFNULL(A.BANNAB_YN, 'N')  != 'Y'				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocs2003);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return "";
	}
	
	@Override
	public String getOCS2003U03BogyongCode(String hospCode, String bogyongCode, String dvOriginal, String dvChanged, String gubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT FN_OCS_BANNAB_BOGYONG_CODE( :f_hosp_code, :f_bogyong_code, :f_dv_original, :f_dv_changed, :f_gubun)		 	");
		sql.append("       FROM DUAL																										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_dv_original", dvOriginal);
		query.setParameter("f_dv_changed", dvChanged);
		query.setParameter("f_gubun", gubun);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return "";

	}
	
	@Override
	public List<OCS2003U03getPRNCURInfo> getOCS2003U03getPRNCURInfo(String hospCode, String language, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																													");
		sql.append("            A.BUNHO                                             BUNHO																	");
		sql.append("           ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                    DRG_BUNHO																");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language )    ORDER_DATE_TEXT								");
		sql.append("           ,IFNULL(DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d'), '')                             JUBSU_DATE									");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                        ORDER_DATE										");
		sql.append("           ,CONCAT('Rp.',E.SERIAL_V, CASE(A.MIX_GROUP) WHEN NULL THEN '' ELSE ' M' END) SERIAL_V										");
		sql.append("           ,E.SERIAL_V                                          SERIAL_TEXT																");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, A.HOSP_CODE, :f_language)           GWA_NAME										");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE),'')   DOCTOR_NAME										");
		sql.append("           ,D.SUNAME                                            SUNAME																	");
		sql.append("           ,D.SUNAME2                                           SUNAME2																	");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, A.HOSP_CODE, :f_language)          BIRTH											");
		sql.append("           ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)          SEX_AGE													");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')      HO_CODE				");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')      HO_DONG       		");
		sql.append("           ,CASE(A.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE A.MAGAM_GUBUN END                   MAGAM_GUBUN								");
		sql.append("           ,CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d'), CAST(A.DRG_BUNHO AS CHAR), CAST(E.SERIAL_V AS CHAR))   RP_BARCODE				");
		sql.append("       FROM DRG3010 A																													");
		sql.append("       JOIN INV0110 B																													");
		sql.append("         ON B.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND B.JAERYO_CODE        = A.JAERYO_CODE																						");
		sql.append("     LEFT JOIN DRG0120 C																												");
		sql.append("         ON C.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND C.BOGYONG_CODE       = A.BOGYONG_CODE																						");
		sql.append("       JOIN OUT0101 D																													");
		sql.append("         ON D.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND D.BUNHO              = A.BUNHO																								");
		sql.append("       JOIN DRG2035 E																													");
		sql.append("         ON E.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND E.JUBSU_DATE         = A.JUBSU_DATE																							");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO																							");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003																							");
		sql.append("       JOIN INP1001 F																													");
		sql.append("         ON F.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND F.PKINP1001          = A.FKINP1001																							");
		sql.append("      WHERE A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																");
		sql.append("        AND A.HOSP_CODE          = :f_hosp_code																							");
		sql.append("        AND A.DRG_BUNHO          = :f_drg_bunho																							");
		sql.append("        AND A.BUNRYU1            <> '4'																									");
		sql.append("      ORDER BY E.SERIAL_V																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<OCS2003U03getPRNCURInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03getPRNCURInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoSerial(String hospCode, String language, String jubsuDate, String drgBunho, String serialText){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																		");
		sql.append("            A.BUNHO                                                                                 BUNHO													");
		sql.append("           ,A.DRG_BUNHO                                                                             DRG_BUNHO												");
		sql.append("           ,A.GROUP_SER                                                                             GROUP_SER												");
		sql.append("           ,IFNULL(DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d'), '')                                        JUBSU_DATE												");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    ORDER_DATE												");
		sql.append("           ,A.JAERYO_CODE                                                                           JAERYO_CODE												");
		sql.append("           ,CAST(A.NALSU * (CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END) 									");
		sql.append("                                                                                 AS CHAR)                                      NALSU						");
		sql.append("           ,CAST(A.DIVIDE AS CHAR)                                                                                             DIVIDE						");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)                                                                                        ORD_SURYANG					");
		sql.append("           ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)                                 ORDER_SURYANG				");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language), '')                              ORDER_DANUI					");
		sql.append("           ,CAST(A.SUBUL_DANUI AS CHAR)                                                                                        SUBUL_DANUI					");
		sql.append("           ,A.BOGYONG_CODE                                                                                                     BOGYONG_CODE					");
		sql.append("           ,IFNULL(CONCAT(TRIM(B.BOGYONG_NAME),FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, A.HOSP_CODE),								");
		sql.append("             (CASE(IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0))											");
		sql.append("            WHEN 0 THEN NULL ELSE CONCAT('(',LTRIM(CAST(IFNULL(G.DV_1,0) AS CHAR)), '-',LTRIM(CAST(IFNULL(G.DV_2,0) AS CHAR)) ,  '-' ,						");
		sql.append("             LTRIM(CAST(IFNULL(G.DV_3,0) AS CHAR)) , '-' ,LTRIM(CAST(IFNULL(G.DV_4,0) AS CHAR)) ,  '-' ,													");
		sql.append("             LTRIM(CAST(IFNULL(G.DV_5,0) AS CHAR)), ')' ) END)),'')                                                            BOGYONG_NAME					");
		sql.append("           ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', NULL, A.HOSP_CODE, :f_language ) ,1,80)      CAUTION_NAME				");
		sql.append("           ,IFNULL(A.MIX_YN,'')                                                                     MIX_YN													");
		sql.append("           ,A.ATC_YN                                                                                ATC_YN													");
		sql.append("           ,CAST(D.DV AS CHAR)                                                                      DV														");
		sql.append("           ,CAST(A.DV_TIME AS CHAR)                                                                 DV_TIME													");
		sql.append("           ,D.DC_YN                                                                                 DC_YN													");
		sql.append("           ,D.BANNAB_YN                                                                             BANNAB_YN												");
		sql.append("           ,CAST(D.SOURCE_FKOCS2003 AS CHAR)                                                        SOURCE_FKOCS2003										");
		sql.append("           ,A.FKOCS2003                                                                             FKOCS2003												");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       SUNAB_DATE												");
		sql.append("           ,B.PATTERN                                                                               PATTERN													");
		sql.append("           ,F.HANGMOG_NAME                                                                          JAERYO_NAME												");
		sql.append("           ,'0'                                                                                     SUNAB_NALSU												");
		sql.append("           ,IFNULL(D.WONYOI_ORDER_YN,'N')                                                           WONYOI_YN												");
		sql.append("           ,IFNULL(CONCAT(F.HANGMOG_NAME, ' : ' , TRIM(D.ORDER_REMARK)),'')                         ORDER_REMARK											");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       ACT_DATE												");
		sql.append("           ,IFNULL(C.MIX_YN_INP,'N')                                                                UI_JUSA_YN												");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG											");
		sql.append("           ,CONCAT('Rp.',LTRIM(CAST(E.SERIAL_V AS CHAR)), CASE(G.MIX_GROUP) WHEN NULL THEN '' ELSE' M' END)                   SERIAL_V						");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, A.HOSP_CODE, :f_language)                                               GWA_NAME						");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, A.HOSP_CODE),'')                 DOCTOR_NAME												");
		sql.append("           ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA												");
		sql.append("           ,IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language),'')     HOPE_DATE												");
		sql.append("           ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I', A.HOSP_CODE)                           POWDER_YN												");
		sql.append("           ,CAST(IFNULL(E.SERIAL_V, 1) AS CHAR)                                                     LINE													");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language),'')  ORD_DANUI2												");
		sql.append("           ,CAST(SUBSTR(TRIM(A.BUNRYU1),1,1) AS CHAR)                                               BUNRYU1													");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')     HO_DONG									");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')     HO_CODE         							");
		sql.append("           ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK													");
		sql.append("           ,''                                                                                      TUSUK													");
		sql.append("           ,CASE(G.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE G.MAGAM_GUBUN END                         MAGAM_GUBUN												");
		sql.append("           ,IFNULL(C.TEXT_COLOR,'')                                                                 TEXT_COLOR												");
		sql.append("           ,IFNULL(C.CHANGGO1,'')                                                                   CHANGGO													");
		sql.append("           ,CONCAT('( ' ,DATE_FORMAT(IFNULL(D.HOPE_DATE, D.ORDER_DATE),'%m/%d'))                    FROM_ORDER_DATE											");
		sql.append("           ,CONCAT(DATE_FORMAT(DATE_ADD(IFNULL(D.HOPE_DATE, D.ORDER_DATE), INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')           TO_ORDER_DATE				");
		sql.append("           ,'A'                                                                                     DATA_GUBUN												");
		sql.append("           ,IFNULL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                HODONG_ORD_NAME											");
		sql.append("           ,(SELECT MAX(IFNULL(X.BANNAB_YN,'N'))																											");
		sql.append("               FROM DRG3010 X																																");
		sql.append("                  , DRG2035 Y																																");
		sql.append("              WHERE Y.JUBSU_DATE = E.JUBSU_DATE																												");
		sql.append("                AND Y.HOSP_CODE  = :f_hosp_code																												");
		sql.append("                AND Y.DRG_BUNHO  = E.DRG_BUNHO																												");
		sql.append("                AND Y.SERIAL_V   = E.SERIAL_V																												");
		sql.append("                AND Y.FKOCS2003  = X.FKOCS2003																												");
		sql.append("                AND X.FKOCS2003  = E.FKOCS2003																												");
		sql.append("                AND X.HOSP_CODE  = Y.HOSP_CODE																												");
		sql.append("                )                                                                                   MAX_BANNAB_YN											");
		sql.append("       FROM DRG3011 A																																		");
		sql.append("     LEFT JOIN DRG0120 B																																	");
		sql.append("         ON B.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND B.BOGYONG_CODE     = A.BOGYONG_CODE																												");
		sql.append("       JOIN INV0110 C																																		");
		sql.append("         ON C.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND C.JAERYO_CODE      = A.JAERYO_CODE																												");
		sql.append("       JOIN OCS2003 D																																		");
		sql.append("         ON D.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND D.PKOCS2003        = A.FKOCS2003																												");
		sql.append("       JOIN DRG2035 E																																		");
		sql.append("         ON E.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND E.JUBSU_DATE       = A.JUBSU_DATE																												");
		sql.append("        AND E.DRG_BUNHO        = A.DRG_BUNHO																												");
		sql.append("        AND E.FKOCS2003        = A.FKOCS2003																												");
		sql.append("        AND E.SERIAL_V         = :f_serial_text																												");
		sql.append("       JOIN OCS0103 F																																		");
		sql.append("         ON F.HOSP_CODE        = D.HOSP_CODE																												");
		sql.append("        AND F.HANGMOG_CODE     = D.HANGMOG_CODE																												");
		sql.append("       JOIN DRG3010 G																																		");
		sql.append("         ON G.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND G.FKOCS2003        = A.FKOCS2003																												");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code																												");
		sql.append("        AND A.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																						");
		sql.append("        AND A.DRG_BUNHO        = :f_drg_bunho																												");
		sql.append("      ORDER BY A.DRG_BUNHO, CONCAT('Rp.',LTRIM(CAST(E.SERIAL_V AS CHAR)), CASE(G.MIX_GROUP) WHEN NULL THEN '' ELSE' M' END), A.FKOCS2003					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<OCS2003U03getPRNInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03getPRNInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoSerial2003(String hospCode, String language, Double fkocs2003, String serialText){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																		");
		sql.append("            A.BUNHO                                                                                 BUNHO													");
		sql.append("           ,A.DRG_BUNHO                                                                             DRG_BUNHO												");
		sql.append("           ,A.GROUP_SER                                                                             GROUP_SER												");
		sql.append("           ,IFNULL(DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d'), '')                                        JUBSU_DATE												");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    ORDER_DATE												");
		sql.append("           ,A.JAERYO_CODE                                                                           JAERYO_CODE												");
		sql.append("           ,CAST(A.NALSU * (CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END) 									");
		sql.append("                                                                                 AS CHAR)                                      NALSU						");
		sql.append("           ,CAST(A.DIVIDE AS CHAR)                                                                                             DIVIDE						");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) 								");
		sql.append("                                                       ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)															");
		sql.append("                                ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) 								");
		sql.append("                                                       ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)															");
		sql.append("                                END                                                                                            ORD_SURYANG					");
		sql.append("           ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)                                 ORDER_SURYANG				");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language), '')                              ORDER_DANUI					");
		sql.append("           ,CAST(A.SUBUL_DANUI AS CHAR)                                                                                        SUBUL_DANUI					");
		sql.append("           ,A.BOGYONG_CODE                                                                                                     BOGYONG_CODE					");
		sql.append("           ,IFNULL(CONCAT(TRIM(B.BOGYONG_NAME),FN_DRG_LOAD_RP_TEXT('I', A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, A.HOSP_CODE),								");
		sql.append("             (CASE(IFNULL(A.DV_1,0) + IFNULL(A.DV_2,0) + IFNULL(A.DV_3,0) + IFNULL(A.DV_4,0) + IFNULL(A.DV_5,0))											");
		sql.append("            WHEN 0 THEN NULL ELSE CONCAT('(',LTRIM(CAST(IFNULL(A.DV_1,0) AS CHAR)), '-',LTRIM(CAST(IFNULL(A.DV_2,0) AS CHAR)) ,  '-' ,						");
		sql.append("             LTRIM(CAST(IFNULL(A.DV_3,0) AS CHAR)) , '-' ,LTRIM(CAST(IFNULL(A.DV_4,0) AS CHAR)) ,  '-' ,													");
		sql.append("             LTRIM(CAST(IFNULL(A.DV_5,0) AS CHAR)), ')' ) END)),'')                                                                BOGYONG_NAME				");
		sql.append("           ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, 'O', NULL, A.HOSP_CODE, :f_language ) ,1,80) CAUTION_NAME					");
		sql.append("           ,IFNULL(A.MIX_YN,'')                                                                     MIX_YN													");
		sql.append("           ,A.ATC_YN                                                                                ATC_YN													");
		sql.append("           ,CAST(D.DV AS CHAR)                                                                      DV														");
		sql.append("           ,CAST(A.DV_TIME AS CHAR)                                                                 DV_TIME													");
		sql.append("           ,D.DC_YN                                                                                 DC_YN													");
		sql.append("           ,D.BANNAB_YN                                                                             BANNAB_YN												");
		sql.append("           ,CAST(D.SOURCE_FKOCS2003 AS CHAR)                                                        SOURCE_FKOCS2003										");
		sql.append("           ,A.FKOCS2003                                                                             FKOCS2003												");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       SUNAB_DATE												");
		sql.append("           ,B.PATTERN                                                                               PATTERN													");
		sql.append("           ,F.HANGMOG_NAME                                                                          JAERYO_NAME												");
		sql.append("           ,'0'                                                                                     SUNAB_NALSU												");
		sql.append("           ,IFNULL(D.WONYOI_ORDER_YN,'N')                                                           WONYOI_YN												");
		sql.append("           ,IFNULL(CONCAT(F.HANGMOG_NAME, ' : ' , TRIM(D.ORDER_REMARK)),'')                         ORDER_REMARK											");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       ACT_DATE												");
		sql.append("           ,IFNULL(C.MIX_YN_INP,'N')                                                                UI_JUSA_YN												");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG											");
		sql.append("           ,CONCAT('Rp.',LTRIM(CAST(:f_serial_v AS CHAR)), CASE(A.MIX_GROUP) WHEN NULL THEN '' ELSE' M' END)                   SERIAL_V						");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, A.HOSP_CODE, :f_language)                                                GWA_NAME						");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, A.HOSP_CODE),'')                 DOCTOR_NAME												");
		sql.append("           ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA												");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language)                HOPE_DATE												");
		sql.append("           ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I', A.HOSP_CODE)                           POWDER_YN												");
		sql.append("           ,IFNULL(:f_serial_v, 1)                                                                  LINE													");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)             ORD_DANUI2												");
		sql.append("           ,CAST(SUBSTR(TRIM(A.BUNRYU1),1,1) AS CHAR)                                               BUNRYU1													");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')              HO_DONG							");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')              HO_CODE              			");
		sql.append("           ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK													");
		sql.append("           ,''                                                                                      TUSUK													");
		sql.append("           ,CASE(A.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE A.MAGAM_GUBUN END                         MAGAM_GUBUN												");
		sql.append("           ,IFNULL(C.TEXT_COLOR,'')                                                                 TEXT_COLOR												");
		sql.append("           ,IFNULL(C.CHANGGO1,'')                                                                   CHANGGO													");
		sql.append("           ,CONCAT('( ' ,DATE_FORMAT(IFNULL(D.HOPE_DATE, D.ORDER_DATE),'%m/%d'))                    FROM_ORDER_DATE											");
		sql.append("              ,CONCAT(DATE_FORMAT(DATE_ADD(IFNULL(D.HOPE_DATE, D.ORDER_DATE), INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )', ' [ ',								");
		sql.append("                     (CASE(:f_language) WHEN 'JA' THEN '処番:' WHEN 'VI' THEN 'Mã xử lý:' ELSE 'Process code:' END), A.DRG_BUNHO, '  ',						");
		sql.append("                     (CASE(D.INPUT_GUBUN) 																													");
		sql.append("                            WHEN 'D0' THEN (CASE(:f_language) WHEN 'JA' THEN '定期' WHEN 'VI' THEN 'Định kì' ELSE 'Regularly' END)							");
		sql.append("                            WHEN 'D4' THEN (CASE(:f_language) WHEN 'JA' THEN '臨時' WHEN 'VI' THEN 'Tạm thời' ELSE 'Temporary' END)							");
		sql.append("                            WHEN 'D7' THEN (CASE(:f_language) WHEN 'JA' THEN '退院' WHEN 'VI' THEN 'Thuốc ra viện' ELSE 'Discharge' END)						");
		sql.append("                            ELSE (CASE(:f_language) WHEN 'JA' THEN '定期' WHEN 'VI' THEN 'Định kì' ELSE 'Regularly' END) END), ' ]')   						");
		sql.append("                                                                                                       TO_ORDER_DATE										");
		sql.append("           ,'A'                                                                                     DATA_GUBUN												");
		sql.append("           ,IFNULL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                HODONG_ORD_NAME											");
		sql.append("           ,IFNULL(A.BANNAB_YN,'N')                                                                 MAX_BANNAB_YN											");
		sql.append("       FROM DRG3010 A																																		");
		sql.append("     LEFT JOIN DRG0120 B																																	");
		sql.append("         ON B.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND B.BOGYONG_CODE     = A.BOGYONG_CODE																												");
		sql.append("       JOIN INV0110 C																																		");
		sql.append("         ON C.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND C.JAERYO_CODE      = A.JAERYO_CODE																												");
		sql.append("       JOIN OCS2003 D																																		");
		sql.append("         ON D.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND D.PKOCS2003        = A.FKOCS2003																												");
		sql.append("       JOIN OCS0103 F																																		");
		sql.append("         ON F.HOSP_CODE        = D.HOSP_CODE																												");
		sql.append("        AND F.HANGMOG_CODE     = D.HANGMOG_CODE																												");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code																												");
		sql.append("        AND A.SOURCE_FKOCS2003 = :f_fkocs2003																												");
		sql.append("      ORDER BY A.FKOCS2003																																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkocs2003", fkocs2003);
		query.setParameter("f_serial_v", serialText);
		
		List<OCS2003U03getPRNInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03getPRNInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoElse(String hospCode, String language, String jubsuDate, String drgBunho, String serialText){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																		");
		sql.append("            A.BUNHO                                                                                 BUNHO													");
		sql.append("           ,A.DRG_BUNHO                                                                             DRG_BUNHO												");
		sql.append("           ,A.GROUP_SER                                                                             GROUP_SER												");
		sql.append("           ,IFNULL(DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d'), '')                                        JUBSU_DATE												");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    ORDER_DATE												");
		sql.append("           ,A.JAERYO_CODE                                                                           JAERYO_CODE												");
		sql.append("           ,CAST(A.NALSU * (CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END) 									");
		sql.append("                                                                                 AS CHAR)                                      NALSU						");
		sql.append("           ,CAST(A.DIVIDE AS CHAR)                                                                                             DIVIDE						");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)                                                                                        ORD_SURYANG					");
		sql.append("           ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)                                 ORDER_SURYANG				");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language), '')                              ORDER_DANUI					");
		sql.append("           ,CAST(A.SUBUL_DANUI AS CHAR)                                                                                        SUBUL_DANUI					");
		sql.append("           ,A.BOGYONG_CODE                                                                                                     BOGYONG_CODE					");
		sql.append("           ,IFNULL(CONCAT(TRIM(B.BOGYONG_NAME),																												");
		sql.append("             (CASE(IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0))											");
		sql.append("            WHEN 0 THEN NULL ELSE CONCAT('(',LTRIM(CAST(IFNULL(G.DV_1,0) AS CHAR)), '-',LTRIM(CAST(IFNULL(G.DV_2,0) AS CHAR)) ,  '-' ,						");
		sql.append("             LTRIM(CAST(IFNULL(G.DV_3,0) AS CHAR)) , '-' ,LTRIM(CAST(IFNULL(G.DV_4,0) AS CHAR)) ,  '-' ,													");
		sql.append("             LTRIM(CAST(IFNULL(G.DV_5,0) AS CHAR)), ')' ) END)) ,'')                                                           BOGYONG_NAME					");
		sql.append("           ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', NULL, A.HOSP_CODE, :f_language ) ,1,80)      CAUTION_NAME				");
		sql.append("           ,IFNULL(A.MIX_YN,'')                                                                     MIX_YN													");
		sql.append("           ,A.ATC_YN                                                                                ATC_YN													");
		sql.append("           ,D.DV                                                                                    DV														");
		sql.append("           ,CAST(A.DV_TIME AS CHAR)                                                                 DV_TIME													");
		sql.append("           ,D.DC_YN                                                                                 DC_YN													");
		sql.append("           ,D.BANNAB_YN                                                                             BANNAB_YN												");
		sql.append("           ,CAST(D.SOURCE_FKOCS2003 AS CHAR)                                                        SOURCE_FKOCS2003										");
		sql.append("           ,A.FKOCS2003                                                                             FKOCS2003												");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       SUNAB_DATE												");
		sql.append("           ,B.PATTERN                                                                               PATTERN													");
		sql.append("           ,F.HANGMOG_NAME                                                                          JAERYO_NAME												");
		sql.append("           ,'0'                                                                                     SUNAB_NALSU												");
		sql.append("           ,IFNULL(D.WONYOI_ORDER_YN,'N')                                                           WONYOI_YN												");
		sql.append("           ,CONCAT(F.HANGMOG_NAME, ' : ' , TRIM(D.ORDER_REMARK))                                    ORDER_REMARK											");
		sql.append("           ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                       ACT_DATE												");
		sql.append("           ,IFNULL(C.MIX_YN_INP,'N')                                                                UI_JUSA_YN												");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG											");
		sql.append("           ,CONCAT('Rp.',LTRIM(CAST(E.SERIAL_V AS CHAR)), CASE(G.MIX_GROUP) WHEN NULL THEN '' ELSE' M' END)                   SERIAL_V						");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, A.HOSP_CODE, :f_language)                                               GWA_NAME						");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, A.HOSP_CODE),'')                                         DOCTOR_NAME						");
		sql.append("           ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA												");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language)                HOPE_DATE												");
		sql.append("           ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I', A.HOSP_CODE)                           POWDER_YN												");
		sql.append("           ,CAST(IFNULL(E.SERIAL_V, 1) AS CHAR)                                                     LINE													");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)             ORD_DANUI2												");
		sql.append("           ,CAST(SUBSTR(TRIM(A.BUNRYU1),1,1) AS CHAR)                                               BUNRYU1													");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20), '')              HO_CODE    					");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')              HO_DONG							");
		sql.append("           ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK													");
		sql.append("           ,''                                                                                      TUSUK													");
		sql.append("           ,CASE(G.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE G.MAGAM_GUBUN END                         MAGAM_GUBUN												");
		sql.append("           ,IFNULL(C.TEXT_COLOR ,'')                                                                TEXT_COLOR												");
		sql.append("           ,IFNULL(C.CHANGGO1 ,'')                                                                  CHANGGO													");
		sql.append("           ,CONCAT('( ' ,DATE_FORMAT(IFNULL(D.HOPE_DATE, D.ORDER_DATE),'%m/%d'))                    FROM_ORDER_DATE											");
		sql.append("           ,CONCAT(DATE_FORMAT(DATE_ADD(IFNULL(D.HOPE_DATE, D.ORDER_DATE), INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')           TO_ORDER_DATE				");
		sql.append("           ,'B'                                                                                     DATA_GUBUN												");
		sql.append("           ,IFNULL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                HODONG_ORD_NAME											");
		sql.append("           ,(SELECT MAX(IFNULL(X.BANNAB_YN,'N'))																											");
		sql.append("               FROM DRG3010 X																																");
		sql.append("                  , DRG2035 Y																																");
		sql.append("              WHERE Y.JUBSU_DATE = E.JUBSU_DATE																												");
		sql.append("                AND Y.HOSP_CODE  = :f_hosp_code																												");
		sql.append("                AND Y.DRG_BUNHO  = E.DRG_BUNHO																												");
		sql.append("                AND Y.SERIAL_V   = E.SERIAL_V																												");
		sql.append("                AND Y.FKOCS2003  = X.FKOCS2003																												");
		sql.append("                AND X.FKOCS2003  = E.FKOCS2003																												");
		sql.append("                AND X.HOSP_CODE  = Y.HOSP_CODE																												");
		sql.append("                )                                                                                   MAX_BANNAB_YN											");
		sql.append("       FROM DRG3011 A																																		");
		sql.append("     LEFT JOIN DRG0120 B																																	");
		sql.append("         ON B.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND B.BOGYONG_CODE     = A.BOGYONG_CODE																												");
		sql.append("       JOIN INV0110 C																																		");
		sql.append("         ON C.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND C.JAERYO_CODE      = A.JAERYO_CODE																												");
		sql.append("       JOIN OCS2003 D																																		");
		sql.append("         ON D.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND D.PKOCS2003        = A.FKOCS2003																												");
		sql.append("        AND TRIM(D.ORDER_REMARK) IS NOT NULL																												");
		sql.append("       JOIN DRG2035 E																																		");
		sql.append("         ON E.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND E.JUBSU_DATE       = A.JUBSU_DATE																												");
		sql.append("        AND E.DRG_BUNHO        = A.DRG_BUNHO																												");
		sql.append("        AND E.FKOCS2003        = A.FKOCS2003																												");
		sql.append("        AND E.SERIAL_V         = :f_serial_text																												");
		sql.append("       JOIN OCS0103 F																																		");
		sql.append("         ON F.HOSP_CODE        = D.HOSP_CODE																												");
		sql.append("        AND F.HANGMOG_CODE     = D.HANGMOG_CODE																												");
		sql.append("       JOIN DRG3010 G																																		");
		sql.append("         ON G.HOSP_CODE        = A.HOSP_CODE																												");
		sql.append("        AND G.FKOCS2003        = A.FKOCS2003																												");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code																												");
		sql.append("        AND A.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																						");
		sql.append("        AND A.DRG_BUNHO        = :f_drg_bunho																												");
		sql.append("      ORDER BY A.DRG_BUNHO, CONCAT('Rp.',LTRIM(CAST(E.SERIAL_V AS CHAR)), CASE(G.MIX_GROUP) WHEN NULL THEN '' ELSE' M' END), A.FKOCS2003					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<OCS2003U03getPRNInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03getPRNInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS2003U03getJusaCurInfo> getOCS2003U03getJusaCurInfo(String hospCode, String language, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																");
		sql.append("            A.BUNHO                                             BUNHO																				");
		sql.append("           ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                         DRG_BUNHO																		");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language )    ORDER_DATE_TEXT											");
		sql.append("           ,IFNULL(DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d'), '')                  JUBSU_DATE															");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                  ORDER_DATE																		");
		sql.append("           ,DATE_FORMAT(IFNULL(A.HOPE_DATE, A.ORDER_DATE),'%Y/%m/%d') HOPE_DATE																		");
		sql.append("           ,CONCAT('Rp.',E.SERIAL_V, CASE(A.MIX_GROUP) WHEN NULL THEN '' ELSE ' M' END) SERIAL_V													");
		sql.append("           ,E.SERIAL_V                                          SERIAL_TEXT																			");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, A.HOSP_CODE, :f_language)           GWA_NAME													");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE), '')   DOCTOR_NAME												");
		sql.append("           ,D.SUNAME                                            SUNAME																				");
		sql.append("           ,D.SUNAME2                                           SUNAME2																				");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, A.HOSP_CODE, :f_language)          BIRTH														");
		sql.append("           ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)          SEX_AGE																");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20), '')          HO_CODE    				");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')           HO_DONG					");
		sql.append("           ,A.MAGAM_GUBUN                                       MAGAM_GUBUN																			");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d') , CAST(A.DRG_BUNHO AS CHAR), CAST(E.SERIAL_V AS CHAR), '*')   RP_BARCODE					");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),  CAST(A.DRG_BUNHO AS CHAR),'*')                             BARCODE						");
		sql.append("           ,CONCAT(LTRIM(LPAD(E.SERIAL_V, 4, 0)), LTRIM(LPAD(A.GROUP_SER, 4, 0)), IFNULL(A.MIX_GROUP, ' ')) KEYCODE									");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       JOIN INV0110 B																																");
		sql.append("         ON B.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("        AND B.JAERYO_CODE        = A.JAERYO_CODE																									");
		sql.append("     LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("        AND C.BOGYONG_CODE       = A.BOGYONG_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("        AND D.BUNHO              = A.BUNHO																											");
		sql.append("       JOIN DRG2035 E																																");
		sql.append("         ON E.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("        AND E.JUBSU_DATE         = A.JUBSU_DATE																										");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO																										");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003																										");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code																										");
		sql.append("        AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("        AND A.DRG_BUNHO          = :f_drg_bunho																										");
		sql.append("        AND A.BUNRYU1            IN ('4')																											");
		sql.append("      ORDER BY CONCAT(LTRIM(LPAD(E.SERIAL_V, 4, 0)), LTRIM(LPAD(A.GROUP_SER, 4, 0)), IFNULL(A.MIX_GROUP, ' '))										");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<OCS2003U03getJusaCurInfo> lstResult = new JpaResultMapper().list(query, OCS2003U03getJusaCurInfo.class);
		return lstResult;
	}
	
	@Override
	public List<OCS6010U10OrderInfoCaseOcsInfo> getOCS6010U10OrderInfoCaseOcsInfo(String hospCode, String pkocs2003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT CONCAT(A.NURSE_PICKUP_USER, ' ', B.USER_NM) PICKUP_USER											");
		sql.append("     , A.NURSE_PICKUP_DATE NURSE_PICKUP_DATE															");
		sql.append("     , CONCAT(SUBSTR(A.NURSE_PICKUP_TIME, 1, 2), ':', SUBSTR(A.NURSE_PICKUP_TIME, 3, 2)) PICKUP_TIME	");
		sql.append("     , A.NURSE_CONFIRM_DATE																				");
		sql.append("     , A.NURSE_CONFIRM_TIME																				");
		sql.append("     , DATE_FORMAT(A.ACTING_DATE, '%m/%d') ACTING_DATE													");
		sql.append("     , A.ACTING_TIME																					");
		sql.append("  FROM ADM3200 B																						");
		sql.append("     , OCS2003 A																						");
		sql.append(" WHERE B.HOSP_CODE = A.HOSP_CODE																		");
		sql.append("   AND B.USER_ID   = A.NURSE_PICKUP_USER																");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code																		");
		sql.append("   AND A.PKOCS2003 = :f_pkocs2003																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", CommonUtils.parseDouble(pkocs2003));
		
		List<OCS6010U10OrderInfoCaseOcsInfo> list = new JpaResultMapper().list(query, OCS6010U10OrderInfoCaseOcsInfo.class);
		return list;
	}

	@Override
	public String getOCS2003U99layChkCommonRequest(String hospCode, String bunho, String pkinp1001, String inputGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT IF(SIGN(COUNT(HANGMOG_CODE)) = 1, 'Y', 'N') CHK ");
		sql.append("   FROM OCS2003 										");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code						");
		sql.append("    AND BUNHO       = :f_bunho							");
		sql.append("    AND FKINP1001   = :f_pkinp1001						");
		sql.append("    AND INPUT_GUBUN = :f_input_gubun  					");
		sql.append("    AND NURSE_CONFIRM_DATE IS NULL						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkinp1001", CommonUtils.parseDouble(pkinp1001));
		query.setParameter("f_input_gubun", inputGubun);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public Boolean callPrDrgAutoOcsBannab(String hospCode, String language, String actingDate, String userId,
			String fkinp1001) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_AUTO_OCS_BANNAB");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		
//		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		if(actingDate == ""){
			query.setParameter("I_ACTING_DATE", null);
		}else{
			query.setParameter("I_ACTING_DATE", DateUtil.toDate(actingDate, DateUtil.PATTERN_YYMMDD));
		}		
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		
//		query.execute();
//		String err = (String) query.getOutputParameterValue("IO_ERR");
//		return err == null ? "" : err;
		return query.execute();
	}

	@Override
	public String callPrOcsTransInputGubunD6(String hospCode, String bunho, String fkinp1001, String toiwonGoji,
			String userId) {
		String ioFlag = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_TRANS_INPUT_GUBUN_D6");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_GOJI", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("I_TOIWON_GOJI", toiwonGoji);
		query.setParameter("I_USER_ID", userId);
		
		query.execute();
		ioFlag = (String) query.getOutputParameterValue("IO_FLAG");
		return ioFlag;
	}

	@Override
	public String callPrOcsDeleteInpOrderToiwon(String hospCode, String inputId, String bunho, String fkinp1001,
			String toiwonDate, String sigiMagamDate, String kiGubun) {
		String ioErr = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DELETE_INP_ORDER_TOIWON");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIGI_MAGAM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KI_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("I_TOIWON_DATE", DateUtil.toDate(toiwonDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_SIGI_MAGAM_DATE", DateUtil.toDate(sigiMagamDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_KI_GUBUN", kiGubun);
		
		query.execute();
		ioErr = (String) query.getOutputParameterValue("IO_ERR");
		return ioErr;
	}

	@Override
	public int updateOcs2003InOCS6010U10(String hospCode, String bunho, String userId, Double fkInp1001,
			Date fromDate, Date toDate, Double pkocs6013) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003																									          ");
		sql.append("	SET NURSE_CONFIRM_USER = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', :f_user_id   , NURSE_CONFIRM_USER), 			          ");
		sql.append("		  NURSE_CONFIRM_DATE = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', CURRENT_DATE , NURSE_CONFIRM_DATE),		          ");
		sql.append("		  NURSE_CONFIRM_TIME = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', DATE_FORMAT(SYSDATE(), '%H%m'), NURSE_CONFIRM_TIME), ");
		sql.append("		  NURSE_PICKUP_USER  = :f_user_id             ,                                                                       ");
		sql.append("		  NURSE_PICKUP_DATE  = CURRENT_DATE()         ,                                                                       ");
		sql.append("		  NURSE_PICKUP_TIME  = DATE_FORMAT(SYSDATE(), '%H%m')                                                                 ");
		sql.append("	WHERE HOSP_CODE            = :f_hosp_code                                                                                 ");
		sql.append("	  AND BUNHO                = :f_bunho	                                                                                  ");
		sql.append("	  AND FKINP1001            = :f_fkinp1001                                                                                 ");
		sql.append("	  AND IFNULL(RESER_DATE, IFNULL(HOPE_DATE, ORDER_DATE)) >= :f_from_date                                                   ");
		sql.append("	  AND ORDER_DATE                                        <= :f_to_date													  ");
		sql.append("	  AND IFNULL(PRN_YN,'N')                                = 'N'			                                                  ");
		sql.append("	  AND FN_OCS_BULYONG_CHECK(:f_hosp_code,HANGMOG_CODE, ORDER_DATE) = 'N'	                                                  ");
		sql.append("	  AND ( ( :f_pkocs6013 = 0 )											                                                  ");
		sql.append("	     OR																	                                                  ");
		sql.append("	  	( :f_pkocs6013 = 1 AND SUBSTRING(ORDER_GUBUN, 2, 1) IN ('C', 'D') )	                                                  ");
		sql.append("	     OR																	                                                  ");
		sql.append("	  	( :f_pkocs6013 = 2 AND SUBSTRING(ORDER_GUBUN, 2, 1) IN ('A', 'B') ) )                                                 ");
		sql.append("	  AND NURSE_PICKUP_DATE IS NULL																							  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkInp1001);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_pkocs6013", pkocs6013);
		query.setParameter("f_user_id", userId);
		
		return query.executeUpdate();
	}

	@Override
	public int updateOcs2003InOCS6010U10SaveLayoutCase01(String hospCode, double pkocs2003, String userId,
			String nurseActUser, Date nurseActDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003								   ");
		sql.append("	SET UPD_ID             = :f_user_id         ,  ");
		sql.append("	    UPD_DATE           = SYSDATE()          ,  ");
		sql.append("	    NURSE_ACT_USER     = :f_nurse_act_user  ,  ");
		sql.append("	    NURSE_ACT_DATE     = :f_nurse_act_date     ");
		sql.append("	WHERE HOSP_CODE        = :f_hosp_code		   ");
		sql.append("	  AND PKOCS2003        = :f_pk				   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_nurse_act_user", nurseActUser);
		query.setParameter("f_nurse_act_date", nurseActDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pk", pkocs2003);
		
		return query.executeUpdate();
	}

	@Override
	public int updateOcs2003InOCS6010U10SaveLayoutCase02(String hospCode, double pkocs2003, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003							       ");
		sql.append("	SET UPD_ID             = :f_user_id      ,     ");
		sql.append("	    UPD_DATE           = SYSDATE()       ,     ");
		sql.append("	    NURSE_ACT_USER     = NULL            ,     ");
		sql.append("	    NURSE_ACT_DATE     = NULL     		       ");
		sql.append("	WHERE HOSP_CODE          = :f_hosp_code	       ");
		sql.append("	  AND PKOCS2003          = :f_pk		       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pk", pkocs2003);
		
		return query.executeUpdate();
	}

	@Override
	public int updateOcs2003InOCS6010U10SaveLayoutCase03(String hospCode, double pkocs2003, String userId,
			String pickupUser) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003							                                                                                 ");
		sql.append("	SET UPD_ID             = :f_user_id      ,                                                                               ");
		sql.append("	    UPD_DATE           = SYSDATE()       ,                                                                               ");
		sql.append("	    NURSE_CONFIRM_USER = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', :f_pickup_user                 , NURSE_CONFIRM_USER), ");
		sql.append("	    NURSE_CONFIRM_DATE = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', CURRENT_DATE()                 , NURSE_CONFIRM_DATE), ");
		sql.append("	    NURSE_CONFIRM_TIME = IF(IFNULL(NURSE_CONFIRM_USER, 'N') = 'N', DATE_FORMAT(SYSDATE(), '%H%i') , NURSE_CONFIRM_TIME), ");
		sql.append("	    NURSE_PICKUP_USER  = :f_pickup_user                 ,                                                                ");
		sql.append("	    NURSE_PICKUP_DATE  = CURRENT_DATE()                 ,                                                                ");
		sql.append("	    NURSE_PICKUP_TIME  = DATE_FORMAT(SYSDATE(), '%H%i') ,                                                                ");
		sql.append("	    NURSE_HOLD_USER    = NULL,	                                                                                         ");
		sql.append("	    NURSE_HOLD_DATE    = NULL,	                                                                                         ");
		sql.append("	    NURSE_HOLD_TIME    = NULL	                                                                                         ");
		sql.append("	WHERE HOSP_CODE        = :f_hosp_code                                                                                    ");
		sql.append("	  AND PKOCS2003        = :f_pk		                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pk", pkocs2003);
		query.setParameter("f_pickup_user", pickupUser);
		
		return query.executeUpdate();
	}

	@Override
	public int updateOcs2003InOCS6010U10SaveLayoutCase04(String hospCode, double pkocs2003, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003						                   ");
		sql.append("	SET UPD_ID             = :f_user_id,                   ");
		sql.append("	    UPD_DATE           = SYSDATE() ,                   ");
		sql.append("	    NURSE_PICKUP_USER  = NULL      ,                   ");
		sql.append("	    NURSE_PICKUP_DATE  = NULL      ,                   ");
		sql.append("	    NURSE_PICKUP_TIME  = NULL      ,                   ");
		sql.append("	    NURSE_ACT_USER     = NULL      ,                   ");
		sql.append("	    NURSE_ACT_DATE     = NULL      					   ");
		sql.append("	WHERE HOSP_CODE          = :f_hosp_code	               ");
		sql.append("	  AND PKOCS2003          = :f_pk		               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pk", pkocs2003);
		
		return query.executeUpdate();
	}

	@Override
	public String getNUR2017Q00grdNUR2017QueryEndInfo(String hospCode, String pkocs2003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT IF(A.ACTING_DATE IS NULL, 'N', 'Y') DRUG_BANNAB_YN	");
		sql.append("   FROM OCS2003 A											");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code							");
		sql.append("    AND A.PKOCS2003 = :f_bannab_fkocs2003					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bannab_fkocs2003", CommonUtils.parseDouble(pkocs2003));
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public Integer deleteOCS2003ByHospCodePkocs2015(String hospCode, double pkocs2015) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE 															        ");
		sql.append("	FROM OCS2003													        ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code									        ");
		sql.append("	AND PKOCS2003 IN ( SELECT C.FKOCS2003 							        ");
		sql.append("	          			   FROM OCS2015 B							        ");
		sql.append("	          				 JOIN OCS2016 C ON C.HOSP_CODE = B.HOSP_CODE	");
		sql.append("	          				               AND C.FKOCS2015 = B.PKOCS2015	");
		sql.append("	          			   WHERE B.HOSP_CODE = :f_hosp_code					");
		sql.append("	          				   AND B.PKOCS2015 = :f_pkocs2015)				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2015", pkocs2015);
		
		return query.executeUpdate();
	}

	@Override
	public Integer updateOcs2003InOCS6010U10PopupDAbtnList(String hospCode, double pkocs2003, Date actingDate,
			String ocsFlag, String actBuseo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2003 A										");
		sql.append("	SET A.ACTING_DATE = :f_acting_date						");
		sql.append("	  , A.ACTING_TIME = DATE_FORMAT(SYSDATE(), '%H%i')		");
		sql.append("	  , A.ACTING_DAY  = A.NALSU								");
		sql.append("	  , A.OCS_FLAG    = :f_ocs_flag							");
		sql.append("	  , A.ACT_BUSEO   = :f_act_buseo						");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("	  AND A.PKOCS2003 = :f_pkocs2003						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2003", pkocs2003);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_ocs_flag", ocsFlag);
		query.setParameter("f_act_buseo", actBuseo);
		
		return query.executeUpdate();
	}

	@Override
	public List<DtMarumeKeyInfo> getDtMarumeKeyInfo(String hospCode, String bunho, double fkinp1001, String inputGubun,
			Date orderDate, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKOCS2003, C.FKOCS2005				");
		sql.append("	FROM OCS2003 A                              ");
		sql.append("	   , OCS2016 B                              ");
		sql.append("	   , OCS2015 C                              ");
		sql.append("	   , OCS2003 D                              ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code	        ");
		sql.append("	 AND A.BUNHO        = :f_bunho		        ");
		sql.append("	 AND A.FKINP1001    = :f_fkinp1001	        ");
		sql.append("	 AND A.INPUT_GUBUN  = :f_input_gubun        ");
		sql.append("	 AND A.ORDER_DATE   = :f_order_date	        ");
		sql.append("	 AND A.HANGMOG_CODE = :f_hangmog_code       ");
		sql.append("	 AND SUBSTRING(A.ORDER_GUBUN, 1, 1) = '1'   ");
		sql.append("	 AND D.HOSP_CODE    = A.HOSP_CODE		    ");
		sql.append("	 AND D.SOURCE_FKOCS2003 = A.PKOCS2003	    ");
		sql.append("	 AND B.HOSP_CODE    = D.HOSP_CODE           ");
		sql.append("	 AND B.FKOCS2003    = D.PKOCS2003           ");
		sql.append("	 AND C.HOSP_CODE    = B.HOSP_CODE           ");
		sql.append("	 AND C.PKOCS2015    = B.FKOCS2015           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<DtMarumeKeyInfo> lstResult = new JpaResultMapper().list(query, DtMarumeKeyInfo.class);
		return lstResult;
	}

	@Override
	public Integer deleteOCS6010U10PopupIASaveLayout(String hospCode, String pkocs2016) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE 															");
		sql.append("	FROM													        ");
		sql.append("		OCS2003 A												    ");
		sql.append("	WHERE									        				");
		sql.append("		A.HOSP_CODE = :f_hosp_code									");
		sql.append("		AND A.PKOCS2003 IN (	SELECT C.FKOCS2003 					");
		sql.append("	          					FROM OCS2016 C						");
		sql.append("	          					WHERE								");
		sql.append("	          					C.HOSP_CODE = :f_hosp_code			");
		sql.append("	          					AND C.PKOCS2016 = :f_pkocs2016)		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2016", CommonUtils.parseDouble(pkocs2016));
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer deleteOCS6010U10PopupIASaveLayoutWhenError(String hospCode, String bunho, String pkocs2016) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE                  					");
		sql.append("		NUR1020 A                  				");
		sql.append("	WHERE 										");
		sql.append("		A.HOSP_CODE 	= :f_hosp_code 			");
		sql.append("	  	AND A.BUNHO     = :f_bunho     			");
		sql.append("	  	AND A.FKOCS2016 = :f_pkocs2016 			");
		sql.append("	  	AND A.PR_GUBUN  = 'BS';        			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkocs2016", CommonUtils.parseDouble(pkocs2016));
		
		query.executeUpdate();
		
		sql = new StringBuilder();
		sql.append("	DELETE										");
		sql.append("		OCS2016 A								");
		sql.append("	WHERE										");
		sql.append("		A.HOSP_CODE 	= :f_hosp_code			");
		sql.append("		AND A.PKOCS2016 = :f_pkocs2016			");
		
		query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2016", CommonUtils.parseDouble(pkocs2016));
		
		return query.executeUpdate();
	}

	@Override
	public List<INPORDERTRANSGrdOCS2003Info> getINPORDERTRANSGrdOCS2003Info(String hospCode, String language,
			String sendYn, Double pkinp3010, Date actingDate, String bunho) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 																																				                               ");
		sql.append("			CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' AND BB.SLIP_CODE NOT LIKE 'Z%' THEN ZZ.FKINP3010	                               ");
		sql.append("			   ELSE A.FKINP3010																															                               ");
		sql.append("			END                                                        		PKINP3010	                                                                                               ");
		sql.append("			, A.PKOCS2003                                                	PKOCS 		                                                                                               ");
		sql.append("			, A.GROUP_SER                                                	GROUP_SER	                                                                                               ");
		sql.append("			, CONCAT(A.GROUP_SER,A.FKINP1001)								GROUP_INP1001                                                                                              ");
		sql.append("			, IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME                                                                                           ");
		sql.append("			, A.HANGMOG_CODE                                             	HANGMOG_CODE                                                                                               ");
		sql.append("			, BB.HANGMOG_NAME                                             	HANGMOG_NAME                                                                                               ");
		sql.append("			, IFNULL(D.SPECIMEN_CODE, '')                                   SPECIMEN_CODE                                                                                              ");
		sql.append("			, IFNULL(D.SPECIMEN_NAME, '')                                   SPECIMEN_NAME                                                                                              ");
		sql.append("			, A.SURYANG                                                  	SURYANG	                                                                                                   ");
		sql.append("			, A.ORD_DANUI                                                	ORD_DANUI                                                                                                  ");
		sql.append("			, IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language), '')            	                                                                   ");
		sql.append("																			ORD_DANUI_NAME	                                                                                           ");
		sql.append("			, A.DV_TIME                                                  	DV_TIME 		                                                                                           ");
		sql.append("			, A.DV                                                       	DV				                                                                                           ");
		sql.append("			, CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' AND BB.SLIP_CODE NOT LIKE 'Z%' THEN '1'                                       ");
		sql.append("			   ELSE IFNULL(CAST(A.NALSU AS CHAR), '')								                                                                                                   ");
		sql.append("			  END                                                        	NALSU	                                                                                                   ");
		sql.append("			, A.JUSA                                                     	JUSA	                                                                                                   ");
		sql.append("			, IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code, :f_language), '')                                                                                             ");
		sql.append("																			JUSA_NAME		                                                                                           ");
		sql.append("			, IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN, :f_hosp_code, :f_language), '')                                                                         ");
		sql.append("																			JUSA_SPD_NAME	                                                                                           ");
		sql.append("			, A.BOGYONG_CODE                                             	BOGYONG_CODE	                                                                                           ");
		sql.append("			, IFNULL(FN_OCS_BOGYONG_COL_NAME(BB.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, :f_hosp_code, :f_language), '')                                                         ");
		sql.append("																			BOGYONG_NAME							                                                                   ");
		sql.append("			, IFNULL(A.EMERGENCY, 'N')                                      EMERGENCY                                                                                                  ");
		sql.append("			, A.JUNDAL_PART                                              	JUNDAL_PART 	                                                                                           ");
		sql.append("			, A.WONYOI_ORDER_YN                                          	WONYOI_ORDER_YN	                                                                                           ");
		sql.append("			, ''                                                         	DANGIL_GUMSA_ORDER_YN                                                                                      ");
		sql.append("			, A.OCS_FLAG                                                 	OCS_FLAG		                                                                                           ");
		sql.append("			, BB.ORDER_GUBUN                                             	ORDER_GUBUN		                                                                                           ");
		sql.append("			, A.BUNHO                                                    	BUNHO			                                                                                           ");
		sql.append("			, A.ORDER_DATE                                               	ORDER_DATE		                                                                                           ");
		sql.append("			, AA.GWA                                                     	GWA				                                                                                           ");
		sql.append("			, SUBSTR(INPUT_DOCTOR, 3)                                    	DOCTOR			                                                                                           ");
		sql.append("			, A.SEQ                                                      	SEQ				                                                                                           ");
		sql.append("			, A.FKOCS1003                                                	FKOCS1003                                                                                                  ");
		sql.append("			, A.SUB_SUSUL                                                	SUB_SUSUL                                                                                                  ");
		sql.append("			, CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' AND BB.SLIP_CODE NOT LIKE 'Z%' THEN ZZ.ACT_RES_DATE	                       ");
		sql.append("			   ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    			                                                                                               ");
		sql.append("						 ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))	                                                                                               ");
		sql.append("						 END															                                                                                               ");
		sql.append("			  END                                                        	ACTING_DATE	                                                                                               ");
		sql.append("			, CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' AND BB.SLIP_CODE NOT LIKE 'Z%' THEN ZZ.ACT_RES_DATE                           ");
		sql.append("			   ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    			                                                                                               ");
		sql.append("						 ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))	                                                                                               ");
		sql.append("						 END															                                                                                               ");
		sql.append("			  END                                                        	HOPE_DATE	                                                                                               ");
		sql.append("			, A.SUNAB_DATE                                               	SUNAB_DATE	                                                                                               ");
		sql.append("			, 'N'                                                        	HOME_CARE_YN                                                                                               ");
		sql.append("			, IFNULL(A.REGULAR_YN, 'N')                                     REGULAR_YN 	                                                                                               ");
		sql.append("			, A.HUBAL_CHANGE_YN                                          	HUBAL_CHANGE_YN                                                                                            ");
		sql.append("			, BC.BUN_CODE                                                	BUN_CODE		                                                                                           ");
		sql.append("			, BB.INPUT_CONTROL                                           	INPUT_CONTROL  	                                                                                           ");
		sql.append("			, A.ORDER_GUBUN                                              	ORDER_GUBUN_BAS	                                                                                           ");
		sql.append("			, CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') 							                                                                                           ");
		sql.append("					  AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N'									                                                                                           ");
		sql.append("					  AND BB.SLIP_CODE NOT LIKE 'Z%'										                                                                                           ");
		sql.append("					  AND A.JUNDAL_PART NOT IN ('HOM') THEN IF(ZZ.CNT = A.DV, 'Y', 'N')		                                                                                           ");
		sql.append("				 ELSE FN_OCS_IS_ACTING_YN(A.HOSP_CODE, A.BOM_SOURCE_KEY, 'I', A.ACTING_DATE, A.JUNDAL_PART)                                                                            ");
		sql.append("			END                                                        		ACTING_YN	                                                                                               ");
		sql.append("			, :f_send_yn                                                 	SELECT_YN                                                                                                  ");
		sql.append("			, CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' AND BB.SLIP_CODE NOT LIKE 'Z%' THEN ZZ.SEND_YN                                ");
		sql.append("			   ELSE A.IF_DATA_SEND_YN  												                                                                                                   ");
		sql.append("			END                                                        		SEND_YN	                                                                                                   ");
		sql.append("			, (SELECT IFNULL(MAX(Z.IF_FLAG), '')									                                                                                                   ");
		sql.append("			   FROM IFS4011 Z					                                                                                                                                       ");
		sql.append("			  WHERE Z.HOSP_CODE = :f_hosp_code	                                                                                                                                       ");
		sql.append("				AND Z.FKINP3010 = :f_pkinp3010	                                                                                                                                       ");
		sql.append("				AND Z.FKOCS2003 = FN_OCS_GET_SOURCE_KEY(:f_hosp_code, 'I', A.PKOCS2003))	IF_FLAG                                                                                    ");
		sql.append("										                                                                                                                                               ");
		sql.append("			, (SELECT MAX(Z.FKIFS3014)	                                                                                                                                               ");
		sql.append("			   FROM IFS4011 Z			                                                                                                                                               ");
		sql.append("			  WHERE Z.HOSP_CODE = :f_hosp_code                                                                                                                                         ");
		sql.append("				AND Z.FKINP3010 = :f_pkinp3010                                                                                                                                         ");
		sql.append("				AND Z.FKOCS2003 = FN_OCS_GET_SOURCE_KEY(:f_hosp_code, 'I', A.PKOCS2003)) 	FKIFS3014                                                                                  ");
		sql.append("			, CONCAT(LPAD(C.SORT_KEY, 2, '0')	                                                                                                                                       ");
		sql.append("					, LPAD(A.GROUP_SER, 10, '0')                                                                                                                                       ");
		sql.append("					, LPAD(IFNULL(A.BOM_SOURCE_KEY, A.PKOCS2003), 11, '0')                                                                                                             ");
		sql.append("					, CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9' ELSE '0' END                                                                                                     ");
		sql.append("					, LPAD(A.SEQ, 11, '0')																	                                                                           ");
		sql.append("					, LPAD(A.PKOCS2003, 11, '0'))                							ORDER_BY_KEY 	                                                                           ");
		sql.append("	FROM VW_OCS_INP1001_01     AA						                                                                                                                               ");
		sql.append("	JOIN INP1002	AB ON AB.HOSP_CODE	= AA.HOSP_CODE	                                                                                                                               ");
		sql.append("					  AND AB.BUNHO      = AA.BUNHO		                                                                                                                               ");
		sql.append("					  AND AB.FKINP1001  = AA.PKINP1001	                                                                                                                               ");
		sql.append("	JOIN OCS2003	A ON A.HOSP_CODE		= AA.HOSP_CODE                                                                                                                             ");
		sql.append("					 AND A.FKINP1001    	= AA.PKINP1001                                                                                                                             ");
		sql.append("					 AND A.NALSU        	>= 0								                                                                                                       ");
		sql.append("					 AND IF(A.DC_YN IS NULL OR A.DC_YN = '','N',A.DC_YN)   = 'N'                                                                                                       ");
		sql.append("					 AND IF(A.MUHYO IS NULL OR A.MUHYO = '','N',A.MUHYO)   = 'N'                                                                                                       ");
		sql.append("	JOIN OCS0103	BB ON BB.HOSP_CODE		= A.HOSP_CODE	                                                                                                                           ");
		sql.append("					  AND BB.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                                           ");
		sql.append("					  AND BB.START_DATE     = (SELECT MAX(Z.START_DATE)                                                                                                                ");
		sql.append("											   FROM OCS0103 Z							                                                                                               ");
		sql.append("											   WHERE Z.HOSP_CODE       = BB.HOSP_CODE	                                                                                               ");
		sql.append("												 AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE                                                                                               ");
		sql.append("												 AND Z.START_DATE      <= IFNULL(A.ACTING_DATE, A.ORDER_DATE)                                                                          ");
		sql.append("												 AND (   Z.END_DATE    IS NULL									                                                                       ");
		sql.append("													  OR Z.END_DATE    >= IFNULL(A.ACTING_DATE, A.ORDER_DATE)	                                                                       ");
		sql.append("													 )															                                                                       ");
		sql.append("											  )																	                                                                       ");
		sql.append("				      AND (BB.END_DATE IS NULL OR BB.END_DATE >= IFNULL(A.ACTING_DATE, A.ORDER_DATE))			                                                                       ");
		sql.append("	JOIN BAS0310	BC ON BC.HOSP_CODE		= A.HOSP_CODE	                                                                                                                           ");
		sql.append("					  AND BC.SG_CODE        = A.SG_CODE		                                                                                                                           ");
		sql.append("					  AND BC.SG_YMD         = (SELECT MAX(Z.SG_YMD)                                                                                                                    ");
		sql.append("											   FROM BAS0310 Z							                                                                                               ");
		sql.append("											   WHERE Z.HOSP_CODE       = BC.HOSP_CODE	                                                                                               ");
		sql.append("												 AND Z.SG_CODE         = BC.SG_CODE		                                                                                               ");
		sql.append("												 AND Z.SG_YMD          <= IFNULL(A.ACTING_DATE, A.ORDER_DATE)                                                                          ");
		sql.append("												 AND (Z.BULYONG_YMD IS NULL OR Z.BULYONG_YMD >= IFNULL(A.ACTING_DATE, A.ORDER_DATE))                                                   ");
		sql.append("											  )																                                                                           ");
		sql.append("					  AND (BC.BULYONG_YMD IS NULL OR BC.BULYONG_YMD >= IFNULL(A.ACTING_DATE, A.ORDER_DATE))	                                                                           ");
		sql.append("	LEFT JOIN (SELECT  B.HOSP_CODE                               HOSP_CODE	                                                                                                           ");
		sql.append("					 , A.ORDER_GUBUN                             ORDER_GUBUN                                                                                                           ");
		sql.append("					 , B.ORDER_DATE                              ORDER_DATE	                                                                                                           ");
		sql.append("					 , B.ACT_RES_DATE                            ACT_RES_DATE                                                                                                          ");
		sql.append("					 , B.FKOCS2003                               FKOCS2003		                                                                                                       ");
		sql.append("					 , IFNULL(B.IF_DATA_SEND_YN, 'N')            SEND_YN		                                                                                                       ");
		sql.append("					 , MAX(B.ACTING_DATE)                        ACTING_DATE	                                                                                                       ");
		sql.append("					 , (SELECT COUNT(1)	                                                                                                                                               ");
		sql.append("						  FROM OCS2017 Y                                                                                                                                               ");
		sql.append("						 WHERE Y.HOSP_CODE    = B.HOSP_CODE                                                                                                                            ");
		sql.append("						   AND Y.FKOCS2003    = B.FKOCS2003                                                                                                                            ");
		sql.append("						   AND Y.ACT_RES_DATE = :f_acting_date                                                                                                                         ");
		sql.append("						   AND IFNULL(Y.BANNAB_YN, 'N') = 'N'		                                                                                                                   ");
		sql.append("						   AND Y.PASS_DATE    IS NOT NULL)       CNT                                                                                                                   ");
		sql.append("					 , B.FKINP3010									                                                                                                                   ");
		sql.append("				  FROM OCS2017 B                                                                                                                                                       ");
		sql.append("					 , OCS2003 A                                                                                                                                                       ");
		sql.append("				 WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                                            ");
		sql.append("				   AND A.BUNHO               = :f_bunho                                                                                                                                ");
		sql.append("				   AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                                             ");
		sql.append("				   AND B.FKOCS2003           = A.PKOCS2003                                                                                                                             ");
		sql.append("				   AND B.ACT_RES_DATE        = :f_acting_date                                                                                                                          ");
		sql.append("				   AND IFNULL(B.BANNAB_YN, 'N') = 'N'		                                                                                                                           ");
		sql.append("				   AND (										                                                                                                                       ");
		sql.append("						   (    :f_send_yn             = 'Y' 	                                                                                                                       ");
		sql.append("							AND IFNULL(B.IF_DATA_SEND_YN, 'N') = 'Y'                                                                                                                   ");
		sql.append("						   )	                                                                                                                                                       ");
		sql.append("							OR	                                                                                                                                                       ");
		sql.append("						   (	                                                                                                                                                       ");
		sql.append("								:f_send_yn            <> 'Y'                                                                                                                           ");
		sql.append("							AND IFNULL(B.IF_DATA_SEND_YN, 'N') = 'N'                                                                                                                   ");
		sql.append("						   )	                                                                                                                                                       ");
		sql.append("					   )		                                                                                                                                                       ");
		sql.append("				 GROUP BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003, B.IF_DATA_SEND_YN, B.FKINP3010                                                        ");
		sql.append("				 ORDER BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003	                                                                                       ");
		sql.append("	) ZZ ON ZZ.HOSP_CODE	= A.HOSP_CODE                                                                                                                                              ");
		sql.append("		AND ZZ.FKOCS2003    = A.PKOCS2003                                                                                                                                              ");
		sql.append("	LEFT JOIN OCS0132	C ON C.HOSP_CODE		= A.HOSP_CODE                                                                                                                          ");
		sql.append("						 AND C.CODE_TYPE    	= 'ORDER_GUBUN_BAS'                                                                                                                    ");
		sql.append("						 AND C.CODE         	= SUBSTR(A.ORDER_GUBUN, 2, 1)                                                                                                          ");
		sql.append("	LEFT JOIN OCS0116	D ON D.HOSP_CODE    	= A.HOSP_CODE		                                                                                                                   ");
		sql.append("						 AND D.SPECIMEN_CODE	= A.SPECIMEN_CODE	                                                                                                                   ");
		sql.append("																	                                                                                                                   ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP					                                                                                                                   ");
		sql.append("	WHERE AA.HOSP_CODE                  = :f_hosp_code	                                                                                                                               ");
		sql.append("	AND AA.BUNHO                        = :f_bunho		                                                                                                                               ");
		sql.append("	AND AA.JAEWON_FLAG                  = 'Y'			                                                                                                                               ");
		sql.append("	AND													                                                                                                                               ");
		sql.append("	(													                                                                                                                               ");
		sql.append("		(   :f_send_yn                           = 'Y'	                                                                                                                               ");
		sql.append("			AND 										                                                                                                                               ");
		sql.append("			(											                                                                                                                               ");
		sql.append("				( 																							                                                                           ");
		sql.append("					SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C')       AND IFNULL(A.TOIWON_DRG_YN, 'N')   = 'N'                                                                          ");
		sql.append("					AND 						                                                                                                                                       ");
		sql.append("					(							                                                                                                                                       ");
		sql.append("						( A.JUNDAL_PART     NOT IN ('HOM')     AND ZZ.FKOCS2003         = A.PKOCS2003)                                                                                 ");
		sql.append("					   OR 																				                                                                               ");
		sql.append("					   ( A.JUNDAL_PART     IN ('HOM')         AND A.FKINP3010          = :f_pkinp3010)	                                                                               ");
		sql.append("					)																					                                                                               ");
		sql.append("				) 																						                                                                               ");
		sql.append("				OR  (SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C', 'D')  AND IFNULL(A.TOIWON_DRG_YN, 'N')   <> 'N'   AND A.FKINP3010           = :f_pkinp3010)                            ");
		sql.append("				OR  (SUBSTR(A.ORDER_GUBUN, 2, 1)  NOT IN ('B', 'C')   AND IFNULL(A.TOIWON_DRG_YN, 'N')   = 'N'    AND A.FKINP3010           = :f_pkinp3010)							   ");
		sql.append("			)	                                                                                                                                                                       ");
		sql.append("		) 		                                                                                                                                                                       ");
		sql.append("		OR 		                                                                                                                                                                       ");
		sql.append("		(   :f_send_yn                           <> 'Y'                                                                                                                                ");
		sql.append("			AND 	                                                                                                                                                                   ");
		sql.append("			(		                                                                                                                                                                   ");
		sql.append("				(                                                                                                                                                                      ");
		sql.append("					SUBSTR(A.ORDER_GUBUN, 2, 1)   IN ('B', 'C')      AND IFNULL(A.TOIWON_DRG_YN, 'N')   = 'N'                                                                          ");
		sql.append("					AND 	                                                                                                                                                           ");
		sql.append("					(		                                                                                                                                                           ");
		sql.append("						(A.JUNDAL_PART     NOT IN ('HOM')     AND ZZ.FKOCS2003         = A.PKOCS2003)                                                                                  ");
		sql.append("						OR 																																				               ");
		sql.append("						(A.JUNDAL_PART     IN ('HOM')         AND IFNULL(A.HOPE_DATE, A.ORDER_DATE)      = :f_acting_date  AND IFNULL(A.IF_DATA_SEND_YN, 'N' )  = 'N')	               ");
		sql.append("					)																																					               ");
		sql.append("				) 	                                                                                                                                                                   ");
		sql.append("				OR 	                                                                                                                                                                   ");
		sql.append("				(   SUBSTR(A.ORDER_GUBUN, 2, 1)   NOT IN ('B', 'C')  AND IFNULL(A.TOIWON_DRG_YN, 'N')     = 'N'    AND IFNULL(A.IF_DATA_SEND_YN, 'N' )  = 'N'			               ");
		sql.append("					AND 	                                                                                                                                                           ");
		sql.append("					(  		                                                                                                                                                           ");
		sql.append("						(A.JUNDAL_PART     NOT IN ('HOM')  AND IFNULL(A.ACTING_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))      = :f_acting_date )                                        ");
		sql.append("						OR																									                                                           ");
		sql.append("						(A.JUNDAL_PART     IN ('HOM')      AND IFNULL(A.HOPE_DATE, A.ORDER_DATE)       = :f_acting_date )	                                                           ");
		sql.append("					)	                                                                                                                                                               ");
		sql.append("				) 		                                                                                                                                                               ");
		sql.append("				OR 		                                                                                                                                                               ");
		sql.append("				(   SUBSTR(A.ORDER_GUBUN, 2, 1)   IN ('B', 'C', 'D') AND IFNULL(A.TOIWON_DRG_YN, 'N')     <> 'N'   AND IFNULL(A.IF_DATA_SEND_YN, 'N' )  = 'N'						   ");
		sql.append("					AND 	                                                                                                                                                           ");
		sql.append("					(		                                                                                                                                                           ");
		sql.append("						(A.JUNDAL_PART     NOT IN ('HOM')  AND IFNULL(A.ACTING_DATE, A.ORDER_DATE)    = :f_acting_date)                                                                ");
		sql.append("						OR  																								                                                           ");
		sql.append("						(A.JUNDAL_PART     IN ('HOM')      AND IFNULL(A.HOPE_DATE, A.ORDER_DATE)      = :f_acting_date)		                                                           ");
		sql.append("					)	                                                                                                                                                               ");
		sql.append("				)		                                                                                                                                                               ");
		sql.append("			) 			                                                                                                                                                               ");
		sql.append("		) 				                                                                                                                                                               ");
		sql.append("	) 					                                                                                                                                                               ");
		sql.append("	AND AB.GUBUN_IPWON_DATE		<= IFNULL(A.ACTING_DATE, A.ORDER_DATE)									                                                                               ");
		sql.append("	AND (AB.GUBUN_TOIWON_DATE 	IS NULL OR AB.GUBUN_TOIWON_DATE >= IFNULL(A.ACTING_DATE, A.ORDER_DATE))	                                                                               ");
		sql.append("	AND AB.PKINP1002            = (  SELECT MAX(Z.PKINP1002)											                                                                               ");
		sql.append("									 FROM INP1002                  Z 									                                                                               ");
		sql.append("									WHERE Z.HOSP_CODE              = AB.HOSP_CODE                                                                                                      ");
		sql.append("									  AND Z.FKINP1001              = AB.FKINP1001                                                                                                      ");
		sql.append("									  AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE                                                                                               ");
		sql.append("									  AND (   Z.GUBUN_TOIWON_DATE  IS NULL								                                                                               ");
		sql.append("										   OR Z.GUBUN_TOIWON_DATE  >= IFNULL(A.ACTING_DATE, A.ORDER_DATE)																			   ");
		sql.append("										  )	                                                                                                                                           ");
		sql.append("									)		                                                                                                                                           ");
		sql.append("	ORDER BY  A.HOSP_CODE					                                                                                                                                           ");
		sql.append("			, A.BUNHO			                                                                                                                                                       ");
		sql.append("			, A.ORDER_DATE	DESC                                                                                                                                                       ");
		sql.append("			, ORDER_BY_KEY																																							   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_pkinp3010", pkinp3010);
		query.setParameter("f_acting_date", actingDate);
		
		List<INPORDERTRANSGrdOCS2003Info> lstResult = new JpaResultMapper().list(query, INPORDERTRANSGrdOCS2003Info.class);
		return lstResult;
	}
	
	@Override
	public String getDRG3010P99ToiwonGojiYn(String hospCode, Double fkocs2003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CASE(B.TOIWON_GOJI_YN) WHEN '' THEN '' ELSE IFNULL(B.TOIWON_GOJI_YN,'N') END TOIWON_GOJI_YN     ");
		sql.append("       FROM OCS2003 A                                                                                       ");
		sql.append("       JOIN INP1001 B                                                                                       ");
		sql.append("         ON B.HOSP_CODE = A.HOSP_CODE                                                                       ");
		sql.append("        AND B.PKINP1001 = A.FKINP1001                                                                       ");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code                                                                      ");
		sql.append("        AND A.PKOCS2003 = :f_fkocs2003                                                                      ");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR1014U00CheckOrder(String hospCode, Double fkinp1001, String bunho, String outDate, String inDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                        ");
		sql.append("     FROM DUAL                                                                       ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                         ");
		sql.append("                    FROM OCS2003 A                                                   ");
		sql.append("                   WHERE HOSP_CODE   = :f_hosp_code                                  ");
		sql.append("                     AND A.BUNHO     = :f_bunho                                      ");
		sql.append("                     AND A.FKINP1001 = :f_fkinp1001                                  ");
		sql.append("                     AND A.ORDER_DATE BETWEEN STR_TO_DATE(:f_out_date, '%Y/%m/%d')   ");
		sql.append("                                          AND STR_TO_DATE(:f_in_date, '%Y/%m/%d')    ");
		sql.append("                     AND IFNULL(NURSE_CONFIRM_DATE,'') <> '')                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_out_date", outDate);
		query.setParameter("f_in_date", inDate);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
}

