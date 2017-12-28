package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0250Q00layJaewonListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint2Info;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.INP1001D00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001D01grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001R04grdIpToiListInfo;
import nta.med.data.model.ihis.inps.INP1001U01DoubleGrdINP1002Info;
import nta.med.data.model.ihis.inps.INP1001U01DoubleGrdINP1008Info;
import nta.med.data.model.ihis.inps.INP1001U01DoubleLoadDataInfo;
import nta.med.data.model.ihis.inps.INP1001U01EtcIpwongrdHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1001Info;
import nta.med.data.model.ihis.inps.INP1001U01GrdOut0103Info;
import nta.med.data.model.ihis.inps.INP1001U01GrdOut0106Info;
import nta.med.data.model.ihis.inps.INP1001U01IpwonSelectFormgrdIpwonHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01LayInp1002Info;
import nta.med.data.model.ihis.inps.INP1001U01LoadIpwonTypeListInfo;
import nta.med.data.model.ihis.inps.INP1001U01ReserSelectgrdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtnresultInfo;
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001PastInfo;
import nta.med.data.model.ihis.inps.INP3003U00layLoadToiwonResDateInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0AfterTransInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0BeforeTransInfo;
import nta.med.data.model.ihis.inps.PrIfsMakeIpwonHistoryResultInfo;
import nta.med.data.model.ihis.inps.PrInpMakePkinp1002;
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp1001Info;
import nta.med.data.model.ihis.nuri.NUR1001R09grdINP1001Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdINP1001Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00ChangeHosilSelect1Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00MoveHosilSelect1Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00SelectDokboInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00grdGwaCountInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layIpwonInfoInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1035U00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdBedSoreInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGuhoGubunInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGwaInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdIpToiInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdSusulInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdTransInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layGamyumCntInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layPatientInfoInInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layPatientInfoInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layStairCntInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layTotalCntInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdPayloadDataInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03GrdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050AllInfo;
import nta.med.data.model.ihis.nuri.NUR9001U00grdPalistInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U99grdInp1001Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadIpwonLstInfo;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonInfo;

/**
 * @author dainguyen.
 */
public class Inp1001RepositoryImpl implements Inp1001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Integer getFnInpLoadJaewonIlsu(String hospCode, Double naewonKey, Date orderDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INP_LOAD_JAEWON_ILSU(:f_hosp_code, :f_naewon_key, :f_order_date) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_naewon_key", naewonKey);
		query.setParameter("f_order_date", orderDate);
		
		List<Integer> list = query.getResultList();
		if(list != null && list.size() > 0 ){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public PrOcsLoadIpwonInfo callPrOcsLoadIpwonInfo(String hospCode, Date naewonDate, Integer fkinp1001, String jaewinFlag){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_LOAD_IPWON_INFO");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JAEWON_FLAG", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_CHISIK_YN", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_WEIGHT_INPUT_YN", String.class, ParameterMode.INOUT);      
	    query.registerStoredProcedureParameter("IO_WONYOI_ORDER_YN", String.class, ParameterMode.INOUT);      
	    query.registerStoredProcedureParameter("IO_WONNAE_SAYU_CODE", String.class, ParameterMode.INOUT);     
	    query.registerStoredProcedureParameter("IO_WONNAE_SAYU_NAME", String.class, ParameterMode.INOUT);     
	    query.registerStoredProcedureParameter("IO_CHT_IPWON_DATE", Date.class, ParameterMode.INOUT);         
	    query.registerStoredProcedureParameter("IO_DOUBLE_IPWON_TYPE", String.class, ParameterMode.INOUT);    
	    query.registerStoredProcedureParameter("IO_IPWON_GWA", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_PARENT_GWA", String.class, ParameterMode.INOUT);          	
	    query.registerStoredProcedureParameter("IO_RESIDENT", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_RESIDENT_NAME", String.class, ParameterMode.INOUT);        
	    query.registerStoredProcedureParameter("IO_DRG_YN", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_DRG_NO", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_INP_DOUBLE_IPWON_TYPE", String.class, ParameterMode.INOUT);
	    query.registerStoredProcedureParameter("IO_TOIWON_GOJI_YN", String.class, ParameterMode.INOUT);       
	    query.registerStoredProcedureParameter("IO_TOIWON_DATE", Date.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_INCU_YN", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_JINRYO_RESULT", String.class, ParameterMode.INOUT);        
	    query.registerStoredProcedureParameter("IO_GA_TOIWON_DATE", Date.class, ParameterMode.INOUT);         
	    query.registerStoredProcedureParameter("IO_SIMSA_MAGAM_YN", String.class, ParameterMode.INOUT);       
	    query.registerStoredProcedureParameter("IO_TOIWON_RES_DATE", Date.class, ParameterMode.INOUT);        
	    query.registerStoredProcedureParameter("IO_DUMMY2", String.class, ParameterMode.INOUT);          		
	    query.registerStoredProcedureParameter("IO_DUMMY3", String.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);      
	    
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_NAEWON_DATE", naewonDate);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_JAEWON_FLAG", jaewinFlag);
		query.execute();
		PrOcsLoadIpwonInfo result = new PrOcsLoadIpwonInfo( (String)query.getOutputParameterValue("IO_CHISIK_YN")                                                 
		          ,(String)query.getOutputParameterValue("IO_WEIGHT_INPUT_YN")                                           
		          ,(String)query.getOutputParameterValue("IO_WONYOI_ORDER_YN")                                           
		          ,(String)query.getOutputParameterValue("IO_WONNAE_SAYU_CODE")                                          
		          ,(String)query.getOutputParameterValue("IO_WONNAE_SAYU_NAME")                                          
		          ,(Date)query.getOutputParameterValue("IO_CHT_IPWON_DATE")                                            
		          ,(String)query.getOutputParameterValue("IO_DOUBLE_IPWON_TYPE")                                         
		          ,(String)query.getOutputParameterValue("IO_IPWON_GWA")                                                 
		          ,(String)query.getOutputParameterValue("IO_PARENT_GWA")                                                
		          ,(String)query.getOutputParameterValue("IO_RESIDENT")                                                  
		          ,(String)query.getOutputParameterValue("IO_RESIDENT_NAME")                                             
		          ,(String)query.getOutputParameterValue("IO_DRG_YN")                                                    
		          ,(String)query.getOutputParameterValue("IO_DRG_NO")                                                    
		          ,(String)query.getOutputParameterValue("IO_INP_DOUBLE_IPWON_TYPE")                                     
		          ,(String)query.getOutputParameterValue("IO_TOIWON_GOJI_YN")                                            
		          ,(Date)query.getOutputParameterValue("IO_TOIWON_DATE")                                               
		          ,(String)query.getOutputParameterValue("IO_INCU_YN")                                                   
		          ,(String)query.getOutputParameterValue("IO_JINRYO_RESULT")                                             
		          ,(Date)query.getOutputParameterValue("IO_GA_TOIWON_DATE")                                            
		          ,(String)query.getOutputParameterValue("IO_SIMSA_MAGAM_YN")                                            
		          ,(Date)query.getOutputParameterValue("IO_TOIWON_RES_DATE")
		          ,(String)query.getOutputParameterValue("IO_FLAG")  );
		return result;
	}

	@Override
	public String callFnOcsDupInpOrderCheck(String hospCode, String language,
			String bunho, Integer fkInp1001, String orderDate,String hangmogCode, String hopeDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_DUP_INP_ORDER_CHECK(:f_hosp_code,:f_language,:f_bunho , :f_Fkinp1001 ,               ");
		sql.append(" STR_TO_DATE(:f_orderDate , '%Y/%m/%d'), :f_hangmog_Code , STR_TO_DATE(:f_hopeDate , '%Y/%m/%d') )  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_Fkinp1001", fkInp1001);
		query.setParameter("f_orderDate", orderDate);
		query.setParameter("f_hangmog_Code", hangmogCode);
		query.setParameter("f_hopeDate", hopeDate);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? null : list.get(0);
	}
	
	public List<ComboListItemInfo> getPkinp1001JaewonFlag (String hospCode, String bunho, Date ipwonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.PKINP1001 AS CHAR)                 								  ");
		sql.append("	      , A.JAEWON_FLAG                                                             ");
		sql.append("	   FROM INP1001 A                                                                 ");
		sql.append("	  WHERE A.HOSP_CODE   = :f_hosp_code                                              ");
		sql.append("	AND A.BUNHO       = :f_bunho                                                      ");
		sql.append("	    AND A.JAEWON_FLAG = 'Y'                                                       ");
		sql.append("	    AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                            ");
		sql.append("	    AND A.IPWON_DATE <= IFNULL(:f_ipwon_date , DATE_FORMAT(SYSDATE(),'%Y/%m/%d')) ");
		sql.append("	  ORDER BY A.IPWON_DATE                                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String callFnInpLoadJaewonHoDong(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT FN_INP_LOAD_JAEWON_HO_DONG(:hospCode, :bunho)	  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? null : list.get(0);
	}

	@Override
	public String callFnInpLoadLastIpwonDate(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT FN_INP_LOAD_LAST_IPWON_DATE(:hospCode, :bunho)	  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? null : list.get(0);
	}

	@Override
	public List<INP1001Q00grdINP1001Info> getINP1001Q00grdINP1001Info(String hospCode, String bunho, Date fromDate,
			Date toDate,String language, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKINP1001               												  							");
		sql.append("	     , IFNULL(DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d'), '')                                AS IPWON_DATE       ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'), '')                               AS TOIWON_DATE      ");
		sql.append("	     , A.GWA                                          														");
		sql.append("	     ,  IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(),A.HOSP_CODE,:f_language), '')      AS GWA_NAME         ");
		sql.append("	     , A.DOCTOR                                                    											");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(),A.HOSP_CODE), '')             AS DOCTOR_NAME      ");
		sql.append("	     , A.HO_DONG1 																							");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, SYSDATE(),A.HOSP_CODE,:f_language), '')  AS HO_DONG_NAME 	");
		sql.append("	     , A.HO_CODE1 																							");
		sql.append("	     , A.BED_NO 																							");
		sql.append("	     , CAST(DATEDIFF(A.TOIWON_DATE, A.IPWON_DATE) + 1 AS CHAR)							AS JAEWON_DAYS 		");
		sql.append("	     , A.JAEWON_FLAG 																						");
		sql.append("	 FROM INP1001 A 																							");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code 																			");
		sql.append("	  AND A.BUNHO = :f_bunho																					");
		sql.append("	  AND ((A.IPWON_DATE BETWEEN :f_from_date AND :f_to_date)													");
		sql.append("	        OR (A.TOIWON_DATE BETWEEN :f_from_date AND :f_to_date)												");
		sql.append("	        OR A.TOIWON_DATE IS NULL)																			");
		sql.append("	ORDER BY A.IPWON_DATE DESC																					");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001Q00grdINP1001Info> lstResult = new JpaResultMapper().list(query, INP1001Q00grdINP1001Info.class);
		return lstResult;		
	}

	@Override
	public List<INP1001D01grdINP1001Info> getINP1001D01grdINP1001Info(String hospCode, String language, Date queryDate,
			String hoDong, String suname) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINP1001																																");
		sql.append("      , A.BUNHO																																	");
		sql.append("      , B.SUNAME																																");
		sql.append("      , A.GWA																																	");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :f_language)																		");
		sql.append("      , A.DOCTOR																																");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, SYSDATE(), :f_hosp_code)																				");
		sql.append("      , A.HO_DONG1																																");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, SYSDATE(), :f_hosp_code, :f_language)																	");
		sql.append("      , A.HO_CODE1																																");
		sql.append("      , A.BED_NO																																");
		sql.append("      , DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')																									");
		sql.append("      , DATE_FORMAT(IFNULL(A.TOIWON_DATE, A.TOIWON_RES_DATE), '%Y/%m/%d')																		");
		sql.append("      , CASE IFNULL((CASE(A.TOIWON_GOJI_YN) WHEN 'Y' THEN 'Y' ELSE 'N' END),'N') WHEN 'Y' THEN 1 WHEN 'N' 										");
		sql.append("       			THEN(CASE A.IPWON_RESER_YN WHEN 'Y' THEN 2 WHEN 'N' THEN 3 END) END TOI_RES	 													");
		sql.append("   FROM VW_OCS_INP1001_RES_01 A																													");
		sql.append("       JOIN OUT0101 B	ON  B.BUNHO = A.BUNHO																									");
		sql.append("                        AND  A.HOSP_CODE = B.HOSP_CODE																							");
		sql.append("    					AND B.HOSP_CODE = :f_hosp_code																							");
		sql.append("    					AND B.SUNAME2 LIKE  :f_suname2 																							");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP																								");
		sql.append("  WHERE :f_query_date BETWEEN A.IPWON_DATE																										");
		sql.append("        AND IFNULL(CASE(A.TOIWON_DATE) WHEN '' THEN STR_TO_DATE('99981231', '%Y%m%d') ELSE A.TOIWON_DATE END, STR_TO_DATE('99981231', '%Y%m%d'))");
		sql.append("    AND IFNULL(CASE(A.HO_DONG1) WHEN '' THEN '%' ELSE A.HO_DONG1 END, '%') LIKE :f_ho_dong1														");
		sql.append("    AND IFNULL(CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE A.CANCEL_YN END, 'N') = 'N'																");
		sql.append("  ORDER BY TOI_RES, A.HO_DONG1, A.HO_CODE1, A.BED_NO, A.PKINP1001																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_query_date", queryDate);
		query.setParameter("f_ho_dong1", "%" + hoDong + "%");
		query.setParameter("f_suname2", "%" + suname + "%");
		
		List<INP1001D01grdINP1001Info> lstResult = new JpaResultMapper().list(query, INP1001D01grdINP1001Info.class);
		return lstResult;
	}
	
	@Override
	public List<INP1001R04grdIpToiListInfo> getINP1001R04grdIpToiListInfo(String hospCode, String language,
			String hoDong, Date fromDate, Date toDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(:from_date,SWF_TruncDate(CURRENT_TIMESTAMP,'DD')), :hosp_code, :language)               ");
		sql.append(" , '1'                                                   IP_TOI_GUBUN                                                                   ");
		sql.append(" , FN_ADM_MSG('3171',:language)                                    IP_TOI_GUBUN_NAME                                                    ");
		sql.append(" , A.BUNHO                                               BUNHO                                                                          ");
		sql.append(" , C.SUNAME                                              SUNAME                                                                         ");
		sql.append(" , FN_BAS_LOAD_GUBUN_NAME(B.GUBUN,:from_date,:hosp_code)        GUBUN_NAME                                                              ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.IPWON_DATE,:hosp_code, :language)       IPWON_DATE                                                ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE),:hosp_code, :language) TOIWON_DATE                           ");
		sql.append(" , A.HO_DONG1                                            HO_DONG                                                                        ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1,:from_date,:hosp_code, :language)       HO_DONG_NAME                                                 ");
		sql.append(" , A.HO_CODE1                                            HO_CODE                                                                        ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('SEX_GUBUN',C.SEX,:hosp_code, :language)             SEX                                                       ");
		sql.append(" , C.TEL                                                 TEL                                                                            ");
		sql.append(" , C.ADDRESS1                                            ADDRESS                                                                        ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.SIGI_MAGAM_DATE,:hosp_code, :language)  SIGI_MAGAM_DATE                                           ");
		sql.append(" , ' '                                                                                                                                  ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('RESULT',A.RESULT,:hosp_code, :language)             RESULT                                                    ");
		sql.append(" , CONCAT('1',A.IPWON_DATE,A.HO_DONG1,A.HO_CODE1,LPAD(A.PKINP1001,10,'0'))  CONT_KEY                                                    ");
		sql.append(" FROM OUT0101 C, INP1002 B, INP1001 A                                                                                                   ");
		sql.append(" WHERE A.HOSP_CODE                = :hosp_code                                                                                          ");
		sql.append(" AND IFNULL(A.CANCEL_YN,'N')      = 'N'                                                                                                 ");
		sql.append(" AND A.IPWON_DATE          BETWEEN :from_date AND :to_date                                                                              ");
		sql.append(" AND CASE :ho_dong WHEN '%' THEN '%' ELSE A.HO_DONG1 END = :ho_dong                                                                     ");
		sql.append(" AND A.HO_DONG1 <> 'T'                                                                                                                  ");
		sql.append(" AND A.BUNHO NOT LIKE '5%'                                                                                                              ");
		sql.append(" AND B.HOSP_CODE                = A.HOSP_CODE                                                                                           ");
		sql.append(" AND IFNULL(B.GUBUN_TRANS_YN,'N') = 'N'                                                                                                 ");
		sql.append(" AND B.FKINP1001                = A.PKINP1001                                                                                           ");
		sql.append(" AND B.SEQ                      =(SELECT MAX(Z.SEQ)                                                                                     ");
		sql.append("                                    FROM INP1002 Z                                                                                      ");
		sql.append("                                    WHERE Z.HOSP_CODE = :hosp_code                                                                      ");
		sql.append("                                    AND Z.FKINP1001 = B.FKINP1001                                                                       ");
		sql.append("                                    AND IFNULL(Z.GUBUN_TRANS_YN,'N') = 'N')                                                             ");
		sql.append(" AND C.HOSP_CODE                = A.HOSP_CODE                                                                                           ");
		sql.append(" AND C.BUNHO                    = A.BUNHO                                                                                               ");
		sql.append(" UNION ALL                                                                                                                              ");
		sql.append(" SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(:from_date,SWF_TruncDate(CURRENT_TIMESTAMP,'DD')),:hosp_code, :language)                ");
		sql.append(" , '2'                                                   IP_TOI_GUBUN                                                                   ");
		sql.append(" , FN_ADM_MSG('3172',:language)                                    IP_TOI_GUBUN_NAME                                                    ");
		sql.append(" , A.BUNHO                                               BUNHO                                                                          ");
		sql.append(" , C.SUNAME                                              SUNAME                                                                         ");
		sql.append(" , FN_BAS_LOAD_GUBUN_NAME(B.GUBUN,:from_date,:hosp_code)        GUBUN_NAME                                                              ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.IPWON_DATE,:hosp_code, :language)       IPWON_DATE                                                ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE),:hosp_code, :language)                                       ");
		sql.append(" TOIWON_DATE                                                                                                                            ");
		sql.append(" , A.HO_DONG1                                            HO_DONG                                                                        ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1,:from_date,:hosp_code, :language)       HO_DONG_NAME                                                 ");
		sql.append(" , A.HO_CODE1                                            HO_CODE                                                                        ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('SEX_GUBUN',C.SEX,:hosp_code, :language)             SEX                                                       ");
		sql.append(" , C.TEL                                                 TEL                                                                            ");
		sql.append(" , C.ADDRESS1                                            ADDRESS                                                                        ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.SIGI_MAGAM_DATE,:hosp_code, :language)  SIGI_MAGAM_DATE                                           ");
		sql.append(" , ' '                                                                                                                                  ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('RESULT',A.RESULT,:hosp_code, :language)             RESULT                                                    ");
		sql.append(" , CONCAT('2',IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE),A.HO_DONG1,A.HO_CODE1,LPAD(A.PKINP1001,10,'0'))  CONT_KEY                          ");
		sql.append(" FROM OUT0101 C, INP1002 B, INP1001 A                                                                                                   ");
		sql.append(" WHERE A.HOSP_CODE           = :hosp_code                                                                                               ");
		sql.append(" AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                      ");
		sql.append(" AND A.TOIWON_DATE          BETWEEN :from_date AND :to_date                                                                             ");
		sql.append(" AND CASE :ho_dong WHEN '%' THEN '%' ELSE A.HO_DONG1 END = :ho_dong                                                                     ");
		sql.append(" AND A.HO_DONG1 <> 'T'                                                                                                                  ");
		sql.append(" AND A.BUNHO NOT LIKE '5%'                                                                                                              ");
		sql.append(" AND A.GA_TOIWON_DATE IS NULL                                                                                                           ");
		sql.append(" AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                ");
		sql.append(" AND B.FKINP1001           = A.PKINP1001                                                                                                ");
		sql.append(" AND B.SEQ                 =(SELECT MAX(Z.SEQ)                                                                                          ");
		sql.append("                                FROM INP1002 Z                                                                                          ");
		sql.append("                                WHERE Z.HOSP_CODE = :hosp_code                                                                          ");
		sql.append("                                AND Z.FKINP1001 = B.FKINP1001                                                                           ");
		sql.append("                                AND IFNULL(Z.GUBUN_TRANS_YN,'N') = 'N')                                                                 ");
		sql.append(" AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                ");
		sql.append(" AND C.BUNHO               = A.BUNHO                                                                                                    ");
		sql.append(" UNION ALL                                                                                                                              ");
		sql.append(" SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(:from_date,SWF_TruncDate(CURRENT_TIMESTAMP,'DD')),:hosp_code, :language)                ");
		sql.append(" , '3'                                                   IP_TOI_GUBUN                                                                   ");
		sql.append(" , FN_ADM_MSG('3173',:language)                                    IP_TOI_GUBUN_NAME                                                    ");
		sql.append(" , A.BUNHO                                               BUNHO                                                                          ");
		sql.append(" , C.SUNAME                                              SUNAME                                                                         ");
		sql.append(" , FN_BAS_LOAD_GUBUN_NAME(B.GUBUN,:from_date,:hosp_code)        GUBUN_NAME                                                              ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.IPWON_DATE,:hosp_code, :language)       IPWON_DATE                                                ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE),:hosp_code, :language) TOIWON_DATE                           ");
		sql.append(" , A.HO_DONG1                                            HO_DONG                                                                        ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1,:from_date,:hosp_code, :language)       HO_DONG_NAME                                                 ");
		sql.append(" , A.HO_CODE1                                            HO_CODE                                                                        ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('SEX_GUBUN',C.SEX,:hosp_code, :language)             SEX                                                       ");
		sql.append(" , C.TEL                                                 TEL                                                                            ");
		sql.append(" , C.ADDRESS1                                            ADDRESS                                                                        ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',A.SIGI_MAGAM_DATE,:hosp_code, :language)  SIGI_MAGAM_DATE                                           ");
		sql.append(" , ' '                                                                                                                                  ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('RESULT',A.RESULT,:hosp_code, :language)             RESULT                                                    ");
		sql.append(" , CONCAT('3',IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE),A.HO_DONG1,A.HO_CODE1,LPAD(A.PKINP1001,10,'0'))  CONT_KEY                          ");
		sql.append(" FROM OUT0101 C, INP1002 B, INP1001 A                                                                                                   ");
		sql.append(" WHERE A.HOSP_CODE           = :hosp_code                                                                                               ");
		sql.append(" AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                      ");
		sql.append(" AND A.BUNHO NOT LIKE '5%'                                                                                                              ");
		sql.append(" AND A.GA_TOIWON_DATE          BETWEEN :from_date AND :to_date                                                                          ");
		sql.append(" AND CASE :ho_dong WHEN '%' THEN '%' ELSE A.HO_DONG1 END = :ho_dong                                                                     ");
		sql.append(" AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                ");
		sql.append(" AND B.FKINP1001           = A.PKINP1001                                                                                                ");
		sql.append(" AND B.SEQ                 =(SELECT MAX(Z.SEQ)                                                                                          ");
		sql.append("                                FROM INP1002 Z                                                                                          ");
		sql.append("                                WHERE Z.HOSP_CODE = :hosp_code                                                                          ");
		sql.append("                                AND Z.FKINP1001 = B.FKINP1001                                                                           ");
		sql.append("                                AND IFNULL(Z.GUBUN_TRANS_YN,'N') = 'N')                                                                 ");
		sql.append(" AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                ");
		sql.append(" AND A.BUNHO               = C.BUNHO                                                                                                    ");
		sql.append(" ORDER BY CONT_KEY																														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("ho_dong", hoDong);
		query.setParameter("from_date", fromDate);
		query.setParameter("to_date", toDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001R04grdIpToiListInfo> lstResult = new JpaResultMapper().list(query, INP1001R04grdIpToiListInfo.class);
		return lstResult;		
	}

	@Override
	public String getINP1001simsaMagam(String hospCode, String pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.SIMSA_MAGAM_GUBUN, '1') 	");
		sql.append("		FROM INP1001 A 							");
		sql.append("	    WHERE A.HOSP_CODE = :f_hosp_code  		");
		sql.append("	    AND A.PKINP1001 = :f_pkinp1001 			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", CommonUtils.parseDouble(pkinp1001));
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<INP1001U01GrdInp1001Info> getINP1001U01GrdInp1001Info(String hospCode, String language,
			Double pkinp1001, Integer startNum, Integer offset) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.PKINP1001 AS CHAR)																PKINP1001					");
		sql.append("	     , A.BUNHO                                                                                  BUNHO						");
		sql.append("	     , IF(A.IPWON_DATE IS NULL, '', DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d'))                      IPWON_DATE					");
		sql.append("	     , A.IPWON_TYPE                                                                             IPWON_TYPE					");
		sql.append("	     , A.IPWON_TIME                                                                             IPWON_TIME					");
		sql.append("	     , IFNULL(D.SUNAME, '')                                                                     SUNAME						");
		sql.append("	     , IF(D.BIRTH IS NULL, '', DATE_FORMAT(D.BIRTH, '%Y/%m/%d'))                                BIRTH						");
		sql.append("	     , IFNULL(D.SEX, '')                                                                        SEX							");
		sql.append("	     , IFNULL(A.IPWON_GWA, '')                                                                  IPWON_GWA					");
		sql.append("	     , IFNULL(A.GWA, '')                                                                        GWA							");
		sql.append("	     , IFNULL(A.DOCTOR, '')                                                                     DOCTOR						");
		sql.append("	     , IFNULL(A.RESIDENT, '')                                                                   RESIDENT					");
		sql.append("	     , IFNULL(A.HO_CODE1, '')                                                                   HO_CODE1					");
		sql.append("	     , IFNULL(A.HO_DONG1, '')                                                                   HO_DONG1					");
		sql.append("	     , IFNULL(A.HO_CODE2, '')                                                                   HO_CODE2					");
		sql.append("	     , IFNULL(A.HO_DONG2, '')                                                                   HO_DONG2					");
		sql.append("	     , IFNULL(A.IPWON_RTN2,'')                                                                  IPWON_RTN2					");
		sql.append("	     , IFNULL(A.IPWON_RTN2_REMARK, '')                                                          IPWON_RTN2_REMARK			");
		sql.append("	     , IFNULL(A.CHOJAE, '')                                                                     CHOJAE						");
		sql.append("	     , IFNULL(A.BABY_STATUS, '')                                                                BABY_STATUS					");
		sql.append("	     , IFNULL(A.INP_TRANS_YN, '')                                                               INP_TRANS_YN				");
		sql.append("	     , IFNULL(A.FKOUT1001, '')                                                                  FKOUT1001					");
		sql.append("	     , IFNULL(A.JAEWON_FLAG, '')                                                                JAEWON_FLAG					");
		sql.append("	     , IFNULL(A.TOIWON_GOJI_YN, '')                                                             TOIWON_GOJI_YN				");
		sql.append("	     , IF(A.TOIWON_RES_DATE IS NULL, '', DATE_FORMAT(A.TOIWON_RES_DATE, '%Y/%m/%d'))            TOIWON_RES_DATE				");
		sql.append("	     , IF(A.GA_TOIWON_DATE IS NULL, '', DATE_FORMAT(A.GA_TOIWON_DATE, '%Y/%m/%d'))              GA_TOIWON_DATE				");
		sql.append("	     , IF(A.TOIWON_DATE IS NULL, '', DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'))                    TOIWON_DATE					");
		sql.append("	     , IFNULL(A.TOIWON_TIME, '')                                                                TOIWON_TIME					");
		sql.append("	     , IFNULL(A.RESULT, '')                                                                     RESULT						");
		sql.append("	     , IFNULL(A.SIGI_MAGAM_YN, '')                                                              SIGI_MAGAM_YN				");
		sql.append("	     , IFNULL(A.SIMSA_MAGAM_GUBUN, '')                                                          SIMSA_MAGAM_YN				");
		sql.append("	     , IF(A.CANCEL_DATE IS NULL, '', DATE_FORMAT(A.CANCEL_DATE, '%Y/%m/%d'))                    CANCEL_DATE					");
		sql.append("	     , IFNULL(A.CANCEL_USER, '')                                                                CANCEL_USER					");
		sql.append("	     , IFNULL(A.CANCEL_YN, '')                                                                  CANCEL_YN					");
		sql.append("	     , IFNULL(A.FKINP1003, '')																	FKINP1003					");
		sql.append("	     , IFNULL(A.TEAM, '')                                                                       TEAM						");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.IPWON_GWA, A.IPWON_DATE, :f_hosp_code, :f_language), '')   IPWON_GWA_NAME				");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :f_language), '')         GWA_NAME					");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE, :f_hosp_code), '')                DOCTOR_NAME					");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.IPWON_DATE, :f_hosp_code), '')              RESIDENT_NAME				");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, A.IPWON_DATE, :f_hosp_code, :f_language), '')    HODONG_NAME					");
		sql.append("	     , ' '                                                                                      DOCTOR_SPECIAL_YN			");
		sql.append("	     , IFNULL(A.GISAN_IPWON_DATE, '')                                                           GISAN_IPWON_DATE			");
		sql.append("	     , IFNULL(A.BED_NO, '')                                                                     BED_NO						");
		sql.append("	     , IFNULL(A.GISAN_JAEWON_ILSU, '')                                                          GISAN_JAEWON_ILSU			");
		sql.append("	     , IFNULL(A.JISI_DOCTOR, '')                                                                JISI_DOCTOR					");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.JISI_DOCTOR, A.IPWON_DATE, :f_hosp_code), '')           JISI_DOCTOR_NAME			");
		sql.append("	     , IFNULL(FN_BAS_LOAD_CODE_NAME  ('IPWON_TYPE', A.IPWON_TYPE, :f_hosp_code, :f_language), '')   IPWON_TYPE_NAME			");
		sql.append("	     , ''                                                                                           EMPTY_VALUE1			");
		sql.append("	     , ''                                                                                           EMPTY_VALUE2			");
		sql.append("	     , 'Y'                                                                                          RETRIEVE_YN				");
		sql.append("	     , ''                                                                                           GUBUN					");
		sql.append("	     , IFNULL(A.HO_GRADE1, '')                                                                      HO_GRADE1				");
		sql.append("	     , IFNULL(A.EMERGENCY_GUBUN, '')                                                                EMERGENCY_GUBUN			");
		sql.append("	     , IFNULL(A.EMERGENCY_DETAIL, '')                                                               EMERGENCY_DETAIL		");
		sql.append("	     , IFNULL(A.KAIKEI_HODONG, '')                                                                  KAIKEI_HODONG			");
		sql.append("	     , IFNULL(A.KAIKEI_HOCODE, '')                                                                  KAIKEI_HOCODE			");
		sql.append("	FROM INP1001 A																												");
		sql.append("	LEFT JOIN OUT0101 D ON A.HOSP_CODE = D.HOSP_CODE																			");
		sql.append("	                   AND A.BUNHO = D.BUNHO																					");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																							");
		sql.append("	  AND A.PKINP1001 = :f_pkinp1001																							");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01GrdInp1001Info> lstResult = new JpaResultMapper().list(query, INP1001U01GrdInp1001Info.class);
		return lstResult;
	}
	
	@Override
	public List<INP3003U00layLoadToiwonResDateInfo> getINP3003U00layLoadToiwonResDateInfo(String hospCode, Double pkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT( SYSDATE(), '%Y/%m/%d')  TOIWON_RES_DATE    ");
		sql.append("      , DATE_FORMAT(SYSDATE(),'%H%i')   TOIWON_RES_TIME         ");
		sql.append("      , A.SIGI_MAGAM_DATE                                       ");
		sql.append("      , DATE_FORMAT(SYSDATE(), '%Y/%m/%d')                      ");
		sql.append("      , DATE_FORMAT(SYSDATE(), '%k%i')                          ");
		sql.append("   FROM INP1001 A                                               ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                              ");
		sql.append("    AND A.PKINP1001 = :f_pkinp1001								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		List<INP3003U00layLoadToiwonResDateInfo> lstResult = new JpaResultMapper().list(query, INP3003U00layLoadToiwonResDateInfo.class);
		return lstResult;
	}

	@Override
	public List<INP3003U00grdINP1001Info> getINP3003U00grdINP1001Info(String hospCode, String language,
			Double pkinp1001, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINP1001                                                                                                         ");
		sql.append("      , A.BUNHO                                                                                                             ");
		sql.append("      , A.IPWON_DATE                                                                                                        ");
		sql.append("      , A.IPWON_TIME                                                                                                        ");
		sql.append("      , A.IPWON_TYPE                                                                                                        ");
		sql.append("      , A.IPWON_GWA                                                                                                         ");
		sql.append("      , A.GWA                                                                                                               ");
		sql.append("      , A.HO_DONG1                                                                                                          ");
		sql.append("      , A.HO_CODE1                                                                                                          ");
		sql.append("      , A.BED_NO                                                                                                            ");
		sql.append("      , A.SIMSA_MAGAM_DATE                                                                                                  ");
		sql.append("      , A.SIMSA_MAGAM_TIME                                                                                                  ");
		sql.append("      , A.SIMSA_MAGAMJA                                                                                                     ");
		sql.append("      , FN_ADM_LOAD_USER_NAME(A.SIMSA_MAGAMJA, :f_hosp_code)                             SIMSAJA_NAME                       ");
		sql.append("      , A.GA_TOIWON_DATE                                                                                                    ");
		sql.append("      , A.TOIWON_DATE                                                                                                       ");
		sql.append("      , A.TOIWON_TIME                                                                                                       ");
		sql.append("      , A.SIMSA_MAGAM_GUBUN                                                                                                 ");
		sql.append("      , ''                                                                  DRUG_YN                                         ");
		sql.append("      , ''                                                                  DRUG_NO                                         ");
		sql.append("      , A.IPWON_DATE                                                       DATE_FROM                                        ");
		sql.append("      , IFNULL(A.GA_TOIWON_DATE,IFNULL(A.TOIWON_DATE,SYSDATE()))            DATE_TO                                         ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :language)   GWA_NAME                                       ");
		sql.append("      , FN_INP_LOAD_GISAN_JAEWON_ILSU(A.PKINP1001, B.GUBUN, SYSDATE(), :f_hosp_code)                                        ");
		sql.append("      , A.JAEWON_FLAG                                                                                                       ");
		sql.append("      , A.SIMSA_MAGAM_GUBUN                                                OLD_SIMSA_MAGAM_YN                               ");
		sql.append("      , A.SIMSA_MAGAM_DATE                                                 OLD_SIMSA_MAGAM_DATE                             ");
		sql.append("      , A.SIMSA_MAGAM_TIME                                                 OLD_SIMSA_MAGAM_TIME                             ");
		sql.append("      , A.GA_TOIWON_DATE                                                   OLD_GA_TOIWON_DATE                               ");
		sql.append("      , A.TOIWON_DATE                                                      OLD_TOIWON_DATE                                  ");
		sql.append("      , A.TOIWON_TIME                                                      OLD_TOIWON_TIME                                  ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME (A.HO_DONG1, B.GUBUN_IPWON_DATE,:f_hosp_code, :language)              HO_DONG1_NAME            ");
		sql.append("      , A.HO_GRADE1                                                                                                         ");
		sql.append("      , A.DOCTOR                                                                                                            ");
		sql.append("      , A.TOIWON_RES_DATE                                                                                                   ");
		sql.append("      , A.TOIWON_RES_TIME                                                                                                   ");
		sql.append("      , A.RESULT_AFTER_DIS                                                                                                  ");
		sql.append("      , A.RESULT_AFTER_DIS_REMARK                                                                                           ");
		sql.append("      , ''                                                                                         DATA_ROW_STATE  			");
		sql.append("   FROM INP1002 B RIGHT JOIN  INP1001 A ON B.HOSP_CODE = A.HOSP_CODE AND B.FKINP1001 = A.PKINP1001                          ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                          ");
		sql.append("    AND A.PKINP1001 = :f_pkinp1001																							");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		query.setParameter("language", language);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<INP3003U00grdINP1001Info> lstResult = new JpaResultMapper().list(query, INP3003U00grdINP1001Info.class);
		return lstResult;

	}

	@Override
	public List<INP3003U00grdINP1001PastInfo> getINP3003U00grdINP1001PastInfo(String hospCode, String language,
			String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINP1001                                                                                         ");
		sql.append(" , A.IPWON_DATE                                                                                             ");
		sql.append(" , A.IPWON_TYPE                                                                                             ");
		sql.append(" , B.CODE_NAME                                                                                              ");
		sql.append(" , A.GWA                                                                                                    ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.GWA,IFNULL(A.TOIWON_DATE, SYSDATE()), :hosp_code, :language) GWA_NAME             ");
		sql.append(" , A.DOCTOR                                                                                                 ");
		sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,IFNULL(A.TOIWON_DATE,SYSDATE()), :hosp_code) DOCTOR_NAME                ");
		sql.append(" , FN_INP_LOAD_GISAN_JAEWON_ILSU(A.PKINP1001,C.GUBUN,SYSDATE(), :hosp_code) JAEWON_ILSU                     ");
		sql.append(" , A.RESULT                                      TOIWON_CODE                                                ");
		sql.append(" , FN_BAS_LOAD_CODE_NAME('RESULT',A.RESULT, :hosp_code, :language)    TOIWON_RESULT                         ");
		sql.append(" , IFNULL(A.TOIWON_DATE,A.GA_TOIWON_DATE)          TOIWON_DATE                                              ");
		sql.append(" , A.SIGI_MAGAM_DATE                                                                                        ");
		sql.append(" FROM INP1001 A LEFT OUTER JOIN BAS0102 B ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE      = A.IPWON_TYPE       ");
		sql.append("   LEFT OUTER JOIN INP1002 C ON C.HOSP_CODE = A.HOSP_CODE AND C.FKINP1001 = A.PKINP1001                     ");
		sql.append(" WHERE A.HOSP_CODE    = :hosp_code                                                                          ");
		sql.append(" AND A.BUNHO        = :bunho                                                                                ");
		sql.append(" AND IFNULL(A.CANCEL_YN,'N') <> 'Y'                                                                         ");
		sql.append(" AND A.IPWON_TYPE   <> '5'                                                                                  ");
		sql.append(" AND B.CODE_TYPE    = 'IPWON_TYPE'                                                                          ");
		sql.append(" ORDER BY A.IPWON_DATE DESC,A.PKINP1001 DESC																");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("language", language);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<INP3003U00grdINP1001PastInfo> lstResult = new JpaResultMapper().list(query, INP3003U00grdINP1001PastInfo.class);
		return lstResult;
	}
	
	@Override
	public List<INP1001U01EtcIpwongrdHistoryInfo> getINP1001U01EtcIpwongrdHistoryInfo(String hospCode, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKINP1001               												  							");
		sql.append("	     , IFNULL(DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d'), '')                                AS IPWON_DATE       ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'), '')                               AS TOIWON_DATE      ");
		sql.append("	     , IFNULL(A.GWA, '')                                        											");
		sql.append("	     , IFNULL(A.DOCTOR, '')                                                    								");
		sql.append("	     , IFNULL(A.IPWON_TYPE, '') 																			");
		sql.append("	 FROM INP1001 A 																							");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code 																			");
		sql.append("	  AND A.BUNHO = :f_bunho																					");
		sql.append("	  AND IFNULL(A.CANCEL_YN, 'N') = 'N'																		");
		sql.append("	ORDER BY A.IPWON_DATE DESC, A.PKINP1001 DESC																");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01EtcIpwongrdHistoryInfo> lstResult = new JpaResultMapper().list(query, INP1001U01EtcIpwongrdHistoryInfo.class);
		return lstResult;		
	}
	 
	@Override
	public String getINP3003U00ToiwonCancelGrdMasterItem(String hospCode, Double pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.PKINP1001 AS CHAR) 	        						");
		sql.append("		FROM INP1001 A 													");
		sql.append("	    WHERE A.HOSP_CODE = :f_hosp_code  								");
		sql.append("	    AND A.FK_INP_KEY = ( SELECT Z.FK_INP_KEY 						");
		sql.append("	    						FROM INP1001 Z							");
		sql.append("	    						WHERE Z.HOSP_CODE = A.HOSP_CODE			");
		sql.append("	    							AND Z.PKINP1001 = :f_pkinp1001	    ");
		sql.append("	    							AND Z.JAEWON_FLAG = 'Y'	    		");
		sql.append("	    							AND IFNULL(Z.CANCEL_YN, 'N') = 'N' )");
		sql.append("	    			AND A.JAEWON_FLAG = 'N'	    						");
		sql.append("	    			AND IFNULL(A.CANCEL_YN, 'N') = 'N'	    			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		@SuppressWarnings("unchecked")
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<INP1001U01GrdOut0103Info> getINP1001U01GrdOut0103Info(String hospCode, String language, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :f_language), '')                             GWA_NAME,		");
		sql.append("	       IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE, :f_hosp_code), '')                                    DOCTOR,			");
		sql.append("	       IF(A.IPWON_TYPE = '7', '他院履歴', IFNULL(FN_BAS_LOAD_GUBUN_NAME(B.GUBUN, A.IPWON_DATE, A.HOSP_CODE), ''))   GUBUN_NAME,		");
		sql.append("	       IFNULL(DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d'), '')                                                            NAEWON_DATE,	");
		sql.append("	       IFNULL(DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'), '')                                                           TOIWON_DATE		");
		sql.append("	FROM INP1001 A																														");
		sql.append("	LEFT JOIN (SELECT Z.FKINP1001   FKINP1001																							");
		sql.append("	           , Z.SEQ              SEQ																									");
		sql.append("	           , Z.GUBUN									 																			");
		sql.append("	        FROM INP1002 Z																												");
		sql.append("	       WHERE Z.HOSP_CODE = :f_hosp_code																								");
		sql.append("	         AND Z.BUNHO     = :f_bunho         																						");
		sql.append("	         AND IFNULL(Z.GUBUN_TRANS_YN, 'N') = 'N' 																					");
		sql.append("	         AND Z.SEQ       = (SELECT MAX(X.SEQ) 																						");
		sql.append("	                              FROM INP1002 X 																						");
		sql.append("	                             WHERE X.HOSP_CODE = Z.HOSP_CODE																		");
		sql.append("	                               AND X.FKINP1001 = Z.FKINP1001																		");
		sql.append("	                               AND IFNULL(X.GUBUN_TRANS_YN, 'N') = IFNULL(Z.GUBUN_TRANS_YN, 'N'))									");
		sql.append("	  ) B ON A.PKINP1001 = B.FKINP1001																									");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																									");
		sql.append("	 AND A.BUNHO      = :f_bunho																										");
		sql.append("	 AND IFNULL(A.CANCEL_YN, 'N') = 'N'																									");
		sql.append("	 ORDER BY A.IPWON_DATE DESC, A.PKINP1001 DESC																						");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                		");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01GrdOut0103Info> lstResult = new JpaResultMapper().list(query, INP1001U01GrdOut0103Info.class);
		return lstResult;
	}

	@Override
	public List<INP1001U01GrdOut0106Info> getINP1001U01GrdOut0106Info(String hospCode, String language, String bunho,
			String ipwonDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.SER AS CHAR)		SER,																											");
		sql.append("	       IFNULL(A.COMMENTS, '')   COMMENTS,																										");
		sql.append("	       A.BUNHO                  BUNHO       																									");
		sql.append("	  FROM OUT0106 A																																");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code																												");
		sql.append("	   AND A.BUNHO     = :f_bunho																													");
		sql.append("	 UNION ALL																																		");
		sql.append("	SELECT '0'																																		");
		sql.append("	     , CONCAT(IFNULL(B.PATIENT_INFO_NAME, ''), ' ', IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.START_DATE, :f_hosp_code, :f_language), ''))		");
		sql.append("	     , A.BUNHO																																	");
		sql.append("	FROM OUT0112 B																																	");
		sql.append("	JOIN OUT0113 A ON A.PATIENT_INFO = B.PATIENT_INFO																								");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																												");
		sql.append("	 AND A.BUNHO      = :f_bunho																													");
		sql.append("	 AND A.START_DATE >= STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d')																						");
		sql.append("	 AND SYSDATE() BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('9999/12/31', '%Y/%m/%d'))												");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                		");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01GrdOut0106Info> lstResult = new JpaResultMapper().list(query, INP1001U01GrdOut0106Info.class);
		return lstResult;
	}

	@Override
	public List<INP1001U01LayInp1002Info> getINP1001U01LayInp1002Info(String hospCode, Double fkInp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GUBUN																			");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.GUBUN_IPWON_DATE, A.HOSP_CODE), '')		");
		sql.append("	     , A.PKINP1002																		");
		sql.append("	     , IFNULL(DATE_FORMAT(A.GUBUN_IPWON_DATE, '%Y/%m/%d'), '')							");
		sql.append("	  FROM INP1002 A																		");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code														");
		sql.append("	   AND A.FKINP1001 = :f_fkinp1001														");
		sql.append("	   AND A.SEQ       = (SELECT MAX(Z.SEQ)													");
		sql.append("	                         FROM INP1002 Z 												");
		sql.append("	                        WHERE Z.HOSP_CODE = A.HOSP_CODE									");
		sql.append("	                          AND Z.FKINP1001 = A.FKINP1001)								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkInp1001);
		
		List<INP1001U01LayInp1002Info> lstResult = new JpaResultMapper().list(query, INP1001U01LayInp1002Info.class);
		return lstResult;
	}

	@Override
	public List<INP1001U01LoadIpwonTypeListInfo> getINP1001U01LoadIpwonTypeListInfo(String hospCode, String language,
			String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.PKINP1001																				");
		sql.append("	      , IFNULL(A.IPWON_TYPE, '')																");
		sql.append("	      , IFNULL(FN_BAS_LOAD_CODE_NAME('IPWON_TYPE', A.IPWON_TYPE, A.HOSP_CODE, :f_language), '')	");
		sql.append("	      , IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.IPWON_DATE, A.HOSP_CODE, :f_language), '')	");
		sql.append("	      , CONCAT(A.IPWON_TYPE, LPAD(A.PKINP1001, 10, '0')) CONT_KEY								");
		sql.append("	FROM INP1001 A																					");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code																");
		sql.append("	  AND A.BUNHO       = :f_bunho																	");
		sql.append("	  AND A.JAEWON_FLAG = 'Y'																		");
		sql.append("	  AND IFNULL(A.CANCEL_YN, 'N') = 'N'															");
		sql.append("	ORDER BY CONT_KEY																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		List<INP1001U01LoadIpwonTypeListInfo> lstResult = new JpaResultMapper().list(query, INP1001U01LoadIpwonTypeListInfo.class);
		return lstResult;
	}

	@Override
	public String checkExistsInpOrder(String hospCode, String bunho, double pkInp1001) {
		String sql = " SELECT FN_OCS_EXISTS_INP_ORDER(:f_hosp_code, :f_bunho, :f_pkinp1001) FROM DUAL ";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkinp1001", pkInp1001);
		
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}

	@Override
	public String getAgeByBirth(String birth) {
		String sql = " SELECT CAST(FN_BAS_LOAD_AGE(SYSDATE(), STR_TO_DATE(:f_birth, '%Y/%m/%d'), '') AS CHAR) ";
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_birth", birth);
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}
	
	@Override
	public List<ComboListItemInfo> getComboChangeGubunInp1001U01(String hospCode, String language, String bunho, String gubun, Date naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GUBUN																																				");
		sql.append("	     , IFNULL(CONCAT(B.GUBUN_NAME, '(', IF(IFNULL(B.GONGBI_YN, 'N')= 'N', '公費不可',''), ' 最終確認：', DATE_FORMAT(A.LAST_CHECK_DATE, '%Y/%m/%d'), ')'), '')	");
		sql.append("	FROM OUT0102 A																																				");
		sql.append("	JOIN BAS0210 B ON B.GUBUN = A.GUBUN																															");
		sql.append("	              AND B.LANGUAGE = :f_language																													");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																															");
		sql.append("	 AND A.BUNHO      = :f_bunho																																");
		sql.append("	 AND IFNULL(:f_naewon_date, CURRENT_DATE()) BETWEEN A.START_DATE AND A.END_DATE  																			");
		sql.append("	 AND B.GUBUN      != :f_gubun																																");
		sql.append("	 AND IFNULL(:f_naewon_date, CURRENT_DATE()) BETWEEN B.START_DATE AND B.END_DATE 																			");
		sql.append("	ORDER BY A.GUBUN DESC																																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_naewon_date", naewonDate);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getInfoToCheckPatientInHospital(String hospCode, String bunho, Date ipwonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  CAST(A.PKINP1001 AS CHAR)								");
		sql.append("	      , IFNULL(A.JAEWON_FLAG , '')								");
		sql.append("	FROM INP1001 A													");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code								");
		sql.append("	  AND A.BUNHO       = :f_bunho									");
		sql.append("	  AND A.JAEWON_FLAG = 'Y'										");
		sql.append("	  AND IFNULL(A.CANCEL_YN, 'N') = 'N'							");
		sql.append("	  AND A.IPWON_DATE  <= IFNULL(:f_ipwon_date , CURRENT_DATE())	");
		sql.append("	ORDER BY A.IPWON_DATE;");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public Integer checkJubsuCnt(String hospCode, String bunho, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OUT_CHECK_JUBSU_CNT(:f_hosp_code, :f_bunho, :f_naewonDate) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewonDate", naewonDate);
		
		List<Integer> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? null : list.get(0);
	}
	

	@Override
	public String callFnInpJaewonHistoryCheck(String bunho, Date queryDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INP_JAEWON_HISTORY_CHECK(:f_bunho, :f_query_date) JAEWON_YN ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_query_date", queryDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public PrInpMakePkinp1002 callPrInpMakePkinp1002(String fkinp1001, String gubun, String hospCode) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_MAKE_PKINP1002");
		
		query.registerStoredProcedureParameter("I_FKINP1001", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_PKINP1002", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_SEQ", Integer.class, ParameterMode.INOUT);      
	    query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);       
	    
		query.setParameter("I_FKINP1001", CommonUtils.parseInteger(fkinp1001));
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.execute();
		PrInpMakePkinp1002 result = new PrInpMakePkinp1002( (String)query.getOutputParameterValue("IO_PKINP1002")                                                 
		          ,(Integer)query.getOutputParameterValue("IO_SEQ")                                           
		          ,(String)query.getOutputParameterValue("IO_ERR")       );
		return result;
	}

	@Override
	public PrIfsMakeIpwonHistoryResultInfo callPrIfsMakeIpwonHistory(String hospCode, String procGubun, String bunho,
			Date dataDate, String hoDong, String hoCode, String bedNo, String ipwonGwa, String doctor,
			Double fkinp1001, String userId, String dataGubun, String toiwonGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_MAKE_IPWON_HISTORY");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HO_DONG", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HO_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BED_NO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_GUBUN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_PKIFS3011", Integer.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PROC_GUBUN", procGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_DATA_DATE", dataDate);
		query.setParameter("I_HO_DONG", hoDong);
		query.setParameter("I_HO_CODE", hoCode);
		query.setParameter("I_BED_NO", bedNo);
		query.setParameter("I_IPWON_GWA", ipwonGwa);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_DATA_GUBUN", dataGubun);
		query.setParameter("I_TOIWON_GUBUN", toiwonGubun);
		
		query.execute();
	    
		Integer pkifs3011 = (Integer)query.getOutputParameterValue("IO_PKIFS3011");
		String err = (String)query.getOutputParameterValue("IO_ERR");
		
		return new PrIfsMakeIpwonHistoryResultInfo(pkifs3011, err);
	}
	
	@Override
	public String callPrInpToiwonCancel(String hospCode, Integer pkinp1001, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_TOIWON_CANCEL");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);         		
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKINP1001", pkinp1001);
		query.setParameter("I_USER_ID", userId);
		
		query.execute();
		String ipFlag = (String)query.getOutputParameterValue("IO_FLAG");
		
		return ipFlag;
	}
	
	@Override
	public CommonProcResultInfo callPrInpProcessToiwon(String hospCode, String userId, Double pkinp1001,
			String simsaMagamDate, String simsaMagamTime, String simsaMagamYn, String toiwonDate, String toiwonTime, String gaToiwonDate) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_PROCESS_TOIWON");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIMSA_MAGAM_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIMSA_MAGAM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIMSA_MAGAM_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GA_TOIWON_DATE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);    
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PKINP1001", pkinp1001);
		query.setParameter("I_SIMSA_MAGAM_DATE", simsaMagamDate);
		query.setParameter("I_SIMSA_MAGAM_TIME", simsaMagamTime);
		query.setParameter("I_SIMSA_MAGAM_YN", simsaMagamYn);
		query.setParameter("I_TOIWON_DATE", toiwonDate);
		query.setParameter("I_TOIWON_TIME", toiwonTime);		
		query.setParameter("I_GA_TOIWON_DATE", gaToiwonDate);
			
		query.execute();
		String err = (String)query.getOutputParameterValue("IO_ERR");
		String msg = (String)query.getOutputParameterValue("IO_MSG");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(err);
		rs.setStrResult2(msg);
		return rs;
	}
	
	@Override
	public List<Double> getListPkinp1001(String hospCode, Double pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKINP1001														");
		sql.append("	FROM INP1001 A															");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                       	");
		sql.append("	 AND A.FK_INP_KEY = ( SELECT Z.FK_INP_KEY								");
		sql.append("	                        FROM INP1001 Z									");
		sql.append("	                       WHERE Z.HOSP_CODE = A.HOSP_CODE					");
		sql.append("	                         AND Z.PKINP1001 = :f_pkinp1001  				");
		sql.append("	                         AND Z.JAEWON_FLAG = 'N' 						");
		sql.append("	                         AND IFNULL(Z.CANCEL_YN, 'N') = 'N' ) 			");
		sql.append("	 AND A.JAEWON_FLAG = 'Y'												");
		sql.append("	 AND IFNULL(A.CANCEL_YN, 'N') = 'N'										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		List<Double> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<INP1001U01IpwonSelectFormgrdIpwonHistoryInfo> getINP1001U01IpwonSelectFormgrdIpwonHistoryInfo(
			String hospCode, String language, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINP1001																				");
		sql.append("      , A.BUNHO																					");
		sql.append("      , B.SUNAME																				");
		sql.append("      , A.IPWON_DATE																			");
		sql.append("      , A.IPWON_TIME																			");
		sql.append("      , A.GISAN_IPWON_DATE																		");
		sql.append("      , A.IPWON_TYPE																			");
		sql.append("      , A.IPWON_RTN2																			");
		sql.append("      , A.GWA																					");
		sql.append("      , FN_BAS_LOAD_GWA_NAME      ( A.GWA      , A.IPWON_DATE , :f_hosp_code, :f_language)		");
		sql.append("      , A.DOCTOR																				");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME   ( A.DOCTOR   , A.IPWON_DATE , :f_hosp_code)					");
		sql.append("      , A.HO_DONG1																				");
		sql.append("      , FN_BAS_LOAD_GWA_NAME      ( A.HO_DONG1 , A.IPWON_DATE , :f_hosp_code, :f_language)		");
		sql.append("      , A.HO_CODE1 																				");
		sql.append("      , A.BED_NO																				");
		sql.append("      , A.HO_GRADE1																				");
		sql.append("      , FN_BAS_LOAD_HO_GRADE_NAME ( A.HO_GRADE1, A.IPWON_DATE )									");
		sql.append("      , A.KAIKEI_HODONG																			");
		sql.append("      , A.KAIKEI_HOCODE																			");
		sql.append("   FROM OUT0101 B																				");
		sql.append("      , INP1001 A																				");
		sql.append("  WHERE A.HOSP_CODE           = :f_hosp_code													");
		sql.append("    AND A.BUNHO               = :f_bunho														");
		sql.append("    AND IFNULL(A.CANCEL_YN, 'N') = 'N'															");
		sql.append("    AND B.HOSP_CODE           = A.HOSP_CODE														");
		sql.append("    AND B.BUNHO               = A.BUNHO															");
//		sql.append("  ORDER BY CONCAT(DATE_FORMAT(A.IPWON_DATE,'%Y%m%d'),TRIM(STR(A.PKINP1001,'0000000000'))) DESC	");
		sql.append("  ORDER BY A.PKINP1001 DESC																		");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<INP1001U01IpwonSelectFormgrdIpwonHistoryInfo> lstResult = new JpaResultMapper().list(query, INP1001U01IpwonSelectFormgrdIpwonHistoryInfo.class);
		return lstResult;
	}

	@Override
	public String getCallFnInpJaewonCheck(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INP_JAEWON_CHECK(:hosp_code, :bunho) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) ){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<INP1003U00grdInpReserGridColumnChangedrtnresultInfo> getINP1003U00grdInpReserGridColumnChangedrtnresultInfo(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT														");
		sql.append("		'Y'														");
		sql.append("	FROM														");
		sql.append("		DUAL													");
		sql.append("	WHERE														");
		sql.append("		EXISTS(													");
		sql.append("			SELECT												");
		sql.append("				'X'												");
		sql.append("	    	FROM												");
		sql.append("	    		INP1001											");
		sql.append("	    	WHERE												");
		sql.append("	    		HOSP_CODE 		= :f_hosp_code					");
		sql.append("	    		AND BUNHO       = :f_bunho						");
		sql.append("	    		AND JAEWON_FLAG = 'Y'							");
		sql.append("	    		AND CANCEL_YN   = 'N')							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<INP1003U00grdInpReserGridColumnChangedrtnresultInfo> listInfo = new JpaResultMapper().list(query, INP1003U00grdInpReserGridColumnChangedrtnresultInfo.class);
		return listInfo;
	}

	@Override
	public List<INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo> getINP1003U00grdInpReserGridColumnChangedrtndoctornameInfo(
			String hospCode, String jisiDoctor, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																");
		sql.append("		IFNULL(FN_BAS_LOAD_DOCTOR_NAME(:f_jisi_doctor, STR_TO_DATE(:f_reser_date, '%Y/%m/%d'), :f_hosp_code), '') JISI_DOCTOR_NAME		");
		sql.append("	FROM																																");
		sql.append("		DUAL																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jisi_doctor", jisiDoctor);
		query.setParameter("f_reser_date", reserDate);
		
		List<INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo> listInfo = new JpaResultMapper().list(query, INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo.class);
		return listInfo;
	}

	@Override
	public CommonProcResultInfo callPrInpUpdateIpwonDate(String hospCode, String userId, Double pkinp1001,
			Date fromIpwonDate, Date toIpwonDate, String fromIpwonTime, String toIpwonTime, String fromIpwonGasan,
			String toIpwonGasan) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_UPDATE_IPWON_DATE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_IPWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_IPWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_IPWON_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_IPWON_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_IPWON_GASAN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_IPWON_GASAN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);    
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PKINP1001", pkinp1001);
		query.setParameter("I_FROM_IPWON_DATE", fromIpwonDate);
		query.setParameter("I_TO_IPWON_DATE", toIpwonDate);
		query.setParameter("I_FROM_IPWON_TIME", fromIpwonTime);
		query.setParameter("I_TO_IPWON_TIME", toIpwonTime);
		query.setParameter("I_FROM_IPWON_GASAN", fromIpwonGasan);
		query.setParameter("I_TO_IPWON_GASAN", toIpwonGasan);
		
		query.execute();
		String err = (String)query.getOutputParameterValue("IO_ERR");
		String msg = (String)query.getOutputParameterValue("IO_MSG");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(err);
		rs.setStrResult2(msg);
		return rs;
	}

	@Override
	public CommonProcResultInfo callPrInpCheckIpwonTrans(String hospCode, String bunho, Date ipWonDate) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_CHECK_IPWON_TRANS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_DATE", Date.class, ParameterMode.IN);
				
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);    
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_IPWON_DATE", ipWonDate);
		
		query.execute();
		String ioFlag = (String)query.getOutputParameterValue("IO_FLAG");
		String ioErr = (String)query.getOutputParameterValue("IO_ERR");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(ioFlag);
		rs.setStrResult2(ioErr);
		return rs;
	}

	@Override
	public CommonProcResultInfo callPrInpIpwonCancel(String hospCode, String userId, Double pkinp1001,
			Date junpyoDate) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_IPWON_CANCEL");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNPYO_DATE", Date.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PKINP1001", pkinp1001);
		query.setParameter("I_JUNPYO_DATE", junpyoDate);
		
		query.execute();
		String ioErr = (String)query.getOutputParameterValue("IO_ERR");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(ioErr);
		return rs;
	}

	@Override
	public CommonProcResultInfo callPrInpUpdateOut0103(String hospCode, String user, Date naewondate, String bunho,
			String gwa, String gubun, String doctor, String inOut, String jubsuGwa, Integer tuyakIlsu, String specialYn,
			Date toiwonDate) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_UPDATE_OUT0103");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TUYAK_ILSU", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIAL_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DATE", Date.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER", user);
		query.setParameter("I_NAEWON_DATE", naewondate);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_IN_OUT", inOut);
		query.setParameter("I_JUBSU_GWA", jubsuGwa);
		query.setParameter("I_TUYAK_ILSU", tuyakIlsu);
		query.setParameter("I_SPECIAL_YN", specialYn);
		query.setParameter("I_TOIWON_DATE", toiwonDate);
		
		query.execute();
		String ioErr = (String)query.getOutputParameterValue("IO_FLAG");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(ioErr);
		return rs;
	}

	@Override
	public boolean callPrOcsInitCreateSiksa(String hospCode, Double pkInp1001, String bunho, Date ipwonDate,
			String iudGubun, String language) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_INIT_CREATE_SIKSA");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKINP1001", pkInp1001);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_IPWON_DATE", ipwonDate);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_LANGUAGE", language);
		
		boolean exeStt = query.execute();
		return exeStt;
	}

	@Override
	public CommonProcResultInfo callPrInpMakePkinp1002(Integer fkInp1001, String gubun, String hospCode) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_MAKE_PKINP1002");
		query.registerStoredProcedureParameter("I_FKINP1001", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_PKINP1002", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SEQ", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_FKINP1001", fkInp1001);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_HOSP_CODE", hospCode);
		
		query.execute();
		String pkInp1002 = (String)query.getOutputParameterValue("IO_PKINP1002");
		Integer ioSeq = (Integer)query.getOutputParameterValue("IO_SEQ");
		String ioErr = (String)query.getOutputParameterValue("IO_ERR");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(pkInp1002);
		rs.setStrResult2(String.valueOf(ioSeq));
		rs.setStrResult3(ioErr);
		return rs;
	}

	@Override
	public CommonProcResultInfo callPrOcsUpdateInpOrderRes(String hospCode, String inputId, String bunho,
			Integer fkinp1001) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_INP_ORDER_RES");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Integer.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", fkinp1001);
		
		query.execute();
		
		String erMsg = (String)query.getOutputParameterValue("IO_ERR_MSG");
		String err = (String)query.getOutputParameterValue("IO_ERR");
		
		CommonProcResultInfo rs = new CommonProcResultInfo();
		rs.setStrResult1(erMsg);
		rs.setStrResult2(err);
		return rs;
	}

	@Override
	public List<INP1001U01DoubleLoadDataInfo> getINP1001U01DoubleLoadDataInfo(String hospCode, String bunho,
			String ipwonType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT 'Y'  EXIST_DOUBLE_TYPE						");
		sql.append("	         , A.PKINP1001  PKINP1001 					");
		sql.append("	      FROM INP1001 A								");
		sql.append("	     WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("	       AND A.JAEWON_FLAG = 'Y'						");
		sql.append("	       AND IFNULL(A.CANCEL_YN, 'N') = 'N'			");
		sql.append("	       AND A.IPWON_TYPE = :f_ipwon_type				");
		sql.append("	       AND A.BUNHO     = :f_bunho					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ipwon_type", ipwonType);
		query.setParameter("f_bunho", bunho);
		
		List<INP1001U01DoubleLoadDataInfo> lstResult = new JpaResultMapper().list(query, INP1001U01DoubleLoadDataInfo.class);
		return lstResult;
	}

	@Override
	public List<INP1001Q00grdINP1001Info> getINP1001U00Pkinp1001JaewonFlagInfo(String hospCode, String bunho,
			String ipwonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																						");
		sql.append("		A.PKINP1001,																			");
		sql.append("		A.JAEWON_FLAG 																			");
		sql.append("	FROM																						");
		sql.append("		INP1001 A																				");
		sql.append("	WHERE																						");
		sql.append("		A.HOSP_CODE   						= :f_hosp_code										");
		sql.append("		AND A.BUNHO       					= :f_bunho											");
		sql.append("		AND A.JAEWON_FLAG 					= 'Y'												");
		sql.append("		AND IFNULL(A.CANCEL_YN, 'N')		= 'N'												");
		sql.append("		AND A.IPWON_DATE 					<= IFNULL(:f_ipwon_date , CURRENT_DATE())			");
		sql.append("	ORDER BY																					");
		sql.append("		A.IPWON_DATE																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<INP1001Q00grdINP1001Info> listInfo = new JpaResultMapper().list(query, INP1001Q00grdINP1001Info.class);
		return listInfo;
	}
	@Override
	public List<INP1001U01ReserSelectgrdINP1003Info> getINP1001U01ReserSelectgrdINP1003Info(String hospCode, String language, String bunho,
			Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'                  	                                      EXIST_YN																														");
		sql.append("	     , A.GWA                	                                      GWA																															");
		sql.append("	     , A.DOCTOR             	                                      DOCTOR																														");
		sql.append("	     , IFNULL(A.HO_DONG,'')                                           HO_DONG																														");
		sql.append("	     , IFNULL(A.HO_CODE,'')                                           HO_CODE																														");
		sql.append("	     , A.IPWON_RTN2         	                                      IPWON_RTN2																													");
		sql.append("	     , A.RESER_DATE         	                                      RESER_DATE																													");
		sql.append("	     , A.PKINP1003          	                                      PKINP1003																														");
		sql.append("	     , IFNULL(A.BED_NO,'')                                            BED_NO																														");
		sql.append("		   , IFNULL(FN_INP_LOAD_HO_GRADE (A.HOSP_CODE,A.HO_DONG, A.HO_CODE, A.RESER_DATE),'')                                                           HO_GRADE										");
		sql.append("	     , IFNULL(FN_BAS_LOAD_CODE_NAME('HO_STATUS', FN_BAS_LOAD_HO_STATUS(A.HOSP_CODE,A.HO_DONG, A.HO_CODE, A.RESER_DATE),A.HOSP_CODE,:f_lang ),'')    HO_STATUS										");
		sql.append("	     , A.RESER_FKINP1001                                                                                                                            RESER_FKINP1001									");
		sql.append("	     , IFNULL(A.REMARK ,'')                                                                                                                         REMARK											");
		sql.append("	     , IFNULL(A.IPWON_MOKJUK,'')                                                                                                                    IPWON_MOKJUK									");
		sql.append("	     , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.RESER_DATE,A.HOSP_CODE,:f_lang)																															");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE,A.HOSP_CODE,:f_lang),'')																														");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR , A.RESER_DATE,A.HOSP_CODE),'')																														");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.HO_DONG, A.RESER_DATE,A.HOSP_CODE,:f_lang)																															");
		sql.append("	     , A.JISI_DOCTOR																																												");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.JISI_DOCTOR, A.RESER_DATE,A.HOSP_CODE),'')																													");
		sql.append("	     , EMERGENCY_GUBUN                                                                                                                              EMERGENCY_GUBUN									");
		sql.append("	     , IFNULL(EMERGENCY_DETAIL,'')                                                                                                                  EMERGENCY_DETAIL								");
		sql.append("	     , 'N'                                                                                                                                          SELECT_YN										");
		sql.append("	     , FN_BAS_LOAD_EMERGENCY_TEXT(A.HOSP_CODE,A.PKINP1003)                                                                                          EMERGENCY_TEXT									");
		sql.append("	     , A.FKOUT1001																																													");
		sql.append("	 FROM INP1003 A																																														");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code																																								");
		sql.append("	  AND A.BUNHO          = :f_bunho																																									");
		sql.append("	  AND A.RESER_DATE     >= DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)																																	");
		sql.append("	  AND A.RESER_END_TYPE = '0'																																										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_lang", language);
		query.setParameter("f_bunho", bunho);

		List<INP1001U01ReserSelectgrdINP1003Info> lstResult = new JpaResultMapper().list(query, INP1001U01ReserSelectgrdINP1003Info.class);
		return lstResult;
	}

	@Override
	public List<INP1001U01DoubleGrdINP1008Info> getINP1001U01DoubleGrdINP1008Info(String hospCode, Double pkinp1002,
			String language, String bunho, String dataGubun, Date gubunIpwonDate, Date ipwonDate, Integer page_number,
			String offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'N'																	");
		sql.append(" 	, A.GONGBI_CODE															");
		sql.append(" 	, B.GONGBI_NAME															");
		sql.append("	, cast(:f_fkinp1002 as char)											");
		sql.append(" 	, :f_bunho																");
		sql.append(" 	, :f_gubun																");
		sql.append("	, FN_BAS_LOAD_GUBUN_NAME(:f_gubun, :f_gubun_ipwon_date,A.HOSP_CODE)		");
		sql.append("	, ''																	");
		sql.append("	FROM BAS0212 B JOIN OUT0105 A ON B.GONGBI_CODE = A.GONGBI_CODE			");
		sql.append("    		                      AND B.START_DATE < A.START_DATE			");
		sql.append("                           		  AND B.END_DATE >A.START_DATE     			");
		sql.append(" 	WHERE A.HOSP_CODE     = :f_hosp_code									");
		sql.append("  	AND A.BUNHO         = :f_bunho											");
		sql.append(" 	AND DATE(IFNULL (:f_gubun_ipwon_date , :f_ipwon_date)) > A.START_DATE  	");
		sql.append(" 	AND DATE(IFNULL  (:f_gubun_ipwon_date , :f_ipwon_date)) < A.END_DATE	");
		sql.append("	AND B.LANGUAGE     = :f_language  										");
		sql.append("	ORDER BY A.GONGBI_CODE													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gubun_ipwon_date", gubunIpwonDate);
		query.setParameter("f_ipwon_date", ipwonDate);
		query.setParameter("f_fkinp1002", pkinp1002);
		query.setParameter("f_gubun", dataGubun);

		List<INP1001U01DoubleGrdINP1008Info> lstResult = new JpaResultMapper().list(query,
				INP1001U01DoubleGrdINP1008Info.class);
		return lstResult;

	}

	@Override
	public List<INP1001U01DoubleGrdINP1002Info> getINP1001U01DoubleGrdINP1002Info(String hospCode, Double pkinp1002, String language, String bunho, String exitType, Date ipwonDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT NULL                                                                 PKINP1002						");
		sql.append("	     , NULL                                                                 FKINP1001						");
		sql.append("	     , B.BUNHO                                                              BUNHO							");
		sql.append("	     , B.GUBUN                                                              GUBUN							");
		sql.append("	     , NULL                                                                 SEQ								");
		sql.append("	     , ''                                                                   GUBUN_TRANS_DATE				");
		sql.append("	     , IFNULL(DATE_FORMAT(D.IPWON_DATE, '%Y/%m/%d'), '')                    GUBUN_IPWON_DATE				");
		sql.append("	     , NULL                                                                 GUBUN_TRANS_CNT					");
		sql.append("	     , NULL                                                                 GUBUN_TRANS_YN					");
		sql.append("	     , D.GWA                                                                GWA								");
		sql.append("	     , D.DOCTOR                                                             DOCTOR							");
		sql.append("	     , '2'                                                                  IPWON_TYPE						");
		sql.append("	     , IFNULL(B.JOHAP, '')                                                  JOHAP							");
		sql.append("	     , IFNULL(B.GAEIN, '')                                                  GAEIN							");
		sql.append("	     , IFNULL(B.BON_GA_GUBUN, '')                                           BONIN_GUBUN						");
		sql.append("	     , IFNULL(B.PINAME, '')                                                 PINAME							");
		sql.append("	     , IFNULL(DATE_FORMAT(B.START_DATE, '%Y/%m/%d'), '')                    FROM_JY_DATE					");
		sql.append("	     , IFNULL(DATE_FORMAT(B.END_DATE, '%Y/%m/%d'), '')                      TO_JY_DATE						");
		sql.append("	     , ''                                                                   SIMSA_MAGAM_YN					");
		sql.append("	     , IFNULL(C.JOHAP_GUBUN, '')                                            JOHAP_GUBUN						");
		sql.append("	     , IFNULL(B.GAEIN_NO, '')                                               GAEIN_NO						");
		sql.append("	     , IFNULL(DATE_FORMAT(B.LAST_CHECK_DATE, '%Y/%m/%d'), '')               LAST_CHECK_DATE 				");
		sql.append("	     , IFNULL(FN_BAS_LOAD_JOHAP_NAME(B.GUBUN, B.JOHAP, B.START_DATE, :f_language), '')  JOHAP_NAME			");
		sql.append("	     , IFNULL(C.GUBUN_NAME, '')                                                         GUBUN_NAME 			");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(D.GWA, D.IPWON_DATE, D.HOSP_CODE, :f_language), '')  GWA_NAME			");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(D.DOCTOR, D.IPWON_DATE, D.HOSP_CODE), '')         DOCTOR_NAME			");
		sql.append("	     , IFNULL(FN_BAS_LOAD_CODE_NAME('IPWON_TYPE', '2', D.HOSP_CODE, :f_language), '')   IPWON_TYPE_NAME		");
		sql.append("	     , IFNULL(DATE_FORMAT(D.IPWON_DATE, '%Y/%m/%d'), '')                                IPWON_DATE			");
		sql.append("	     , 'O'                                                                              DATA_GUBUN 			");
		sql.append("	     , IFNULL(D.HO_DONG1, '')                                                           HO_DONG1			");
		sql.append("	     , IFNULL(D.HO_CODE1, '')                                                           HO_CODE1			");
		sql.append("	     , IFNULL(D.HO_GRADE1, '')                                                          HO_GRADE1			");
		sql.append("	     , IFNULL(D.BED_NO, '')                                                             BED_NO     			");
		sql.append("	FROM BAS0210 C																								");
		sql.append("	JOIN OUT0102 B ON C.LANGUAGE = :f_language																	");
		sql.append("	              AND C.GUBUN     = B.GUBUN																		");
		sql.append("	JOIN INP1001 D ON B.HOSP_CODE    = D.HOSP_CODE																");
		sql.append("	              AND B.BUNHO        = D.BUNHO																	");
		sql.append("	WHERE IFNULL(:t_exist_double_type, 'N')  != 'Y'																");
		sql.append("	 AND D.HOSP_CODE = :f_hosp_code																				");
		sql.append("	 AND D.BUNHO        = :f_bunho																				");
		sql.append("	 AND D.JAEWON_FLAG  = 'Y'																					");
		sql.append("	 AND D.IPWON_TYPE   = '0'																					");
		sql.append("	 AND IFNULL(D.CANCEL_YN, 'N') = 'N'																			");
		sql.append("	 AND :f_gubun_ipwon_date BETWEEN B.START_DATE AND B.END_DATE   												");
		sql.append("	 AND :f_gubun_ipwon_date BETWEEN C.START_DATE AND C.END_DATE												");
		sql.append("	 																											");
		sql.append("	UNION ALL																									");
		sql.append("	SELECT A.PKINP1002                                                                  PKINP1002       		");
		sql.append("	     , A.FKINP1001                                                                  FKINP1001       		");
		sql.append("	     , A.BUNHO                                                                      BUNHO           		");
		sql.append("	     , A.GUBUN                                                                      GUBUN           		");
		sql.append("	     , A.SEQ                                                                        SEQ             		");
		sql.append("	     , IFNULL(DATE_FORMAT(A.GUBUN_TRANS_DATE, '%Y/%m/%d'), '')                      GUBUN_TRANS_DATE		");
		sql.append("	     , IFNULL(DATE_FORMAT(A.GUBUN_IPWON_DATE, '%Y/%m/%d'), '')                      GUBUN_IPWON_DATE		");
		sql.append("	     , A.GUBUN_TRANS_CNT                                                            GUBUN_TRANS_CNT 		");
		sql.append("	     , A.GUBUN_TRANS_YN                                                             GUBUN_TRANS_YN  		");
		sql.append("	     , C.GWA                                                                        GWA						");
		sql.append("	     , C.DOCTOR                                                                     DOCTOR					");
		sql.append("	     , C.IPWON_TYPE                                                                 IPWON_TYPE     			");
		sql.append("	     , IFNULL(D.JOHAP, '')                                                          JOHAP           		");
		sql.append("	     , IFNULL(D.GAEIN, '')                                                          GAEIN           		");
		sql.append("	     , IFNULL(D.BON_GA_GUBUN, '')                                                   BONIN_GUBUN     		");
		sql.append("	     , IFNULL(D.PINAME, '')                                                         PINAME          		");
		sql.append("	     , IFNULL(DATE_FORMAT(D.START_DATE, '%Y/%m/%d'), '')                            FROM_JY_DATE    		");
		sql.append("	     , IFNULL(DATE_FORMAT(D.END_DATE, '%Y/%m/%d'), '')                              TO_JY_DATE  			");
		sql.append("	     , IFNULL(A.SIMSA_MAGAM_YN, '')                                                 SIMSA_MAGAM_YN   		");
		sql.append("	     , IFNULL(B.JOHAP_GUBUN, '')                                                    JOHAP_GUBUN     		");
		sql.append("	     , IFNULL(D.GAEIN_NO, '')                                                       GAEIN_NO        		");
		sql.append("	     , IFNULL(DATE_FORMAT(D.LAST_CHECK_DATE, '%Y/%m/%d'), '')                       LAST_CHECK_DATE    		");
		sql.append("	     , ''                                                                           JOHAP_NAME				");
		sql.append("	     , IFNULL(B.GUBUN_NAME, '')                                                                 GUBUN_NAME	");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(C.GWA, C.IPWON_DATE, C.HOSP_CODE, :f_language), '')          GWA_NAME	");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.IPWON_DATE, C.HOSP_CODE), '')                 DOCTOR_NAME	");
		sql.append("	     , IFNULL(FN_BAS_LOAD_CODE_NAME('IPWON_TYPE' , C.IPWON_TYPE, C.HOSP_CODE, :f_language), '') IPWON_TYPE_NAME	");
		sql.append("	     , IFNULL(DATE_FORMAT(C.IPWON_DATE, '%Y/%m/%d'), '')                                        IPWON_DATE		");
		sql.append("	     , 'I'                                                                                      DATA_GUBUN		");
		sql.append("	     , IFNULL(C.HO_DONG1, '')                                                                   HO_DONG1		");
		sql.append("	     , IFNULL(C.HO_CODE1, '')                                                                   HO_CODE1		");
		sql.append("	     , IFNULL(C.HO_GRADE1, '')                                                                  HO_GRADE1		");
		sql.append("	     , IFNULL(C.BED_NO, '')                                                                     BED_NO  		");
		sql.append("	FROM BAS0210 B																									");
		sql.append("	JOIN INP1002 A ON B.LANGUAGE  = :f_language																		");
		sql.append("	              AND B.GUBUN     = A.GUBUN   																		");
		sql.append("	              AND A.GUBUN_IPWON_DATE BETWEEN B.START_DATE AND B.END_DATE   										");
		sql.append("	JOIN INP1001 C ON A.HOSP_CODE = C.HOSP_CODE																		");
		sql.append("	              AND A.BUNHO     = C.BUNHO																			");
		sql.append("	JOIN OUT0102 D ON D.HOSP_CODE = A.HOSP_CODE																		");
		sql.append("	              AND D.BUNHO     = A.BUNHO																			");
		sql.append("	              AND D.GUBUN     = A.GUBUN																			");
		sql.append("	              AND A.GUBUN_IPWON_DATE BETWEEN D.START_DATE AND D.END_DATE 										");
		sql.append("	WHERE IF(:t_exist_double_type IS NULL OR :t_exist_double_type = '', 'N', :t_exist_double_type) = 'Y'			");
		sql.append("	 AND C.HOSP_CODE = :f_hosp_code																					");
		sql.append("	 AND C.BUNHO     = :f_bunho																						");
		sql.append("	 AND C.PKINP1001 = :t_double_pkinp1001																			");
		sql.append("	 AND A.FKINP1001 = C.PKINP1001 																					");
		sql.append("	 AND A.SEQ       = ( SELECT MAX(Z.SEQ)																			");
		sql.append("	                       FROM INP1002 Z																			");
		sql.append("	                      WHERE Z.FKINP1001      = A.FKINP1001														");
		sql.append("	                        AND Z.HOSP_CODE      = :f_hosp_code														");
		sql.append("	                        AND Z.GUBUN_TRANS_YN = 'N')																");
		sql.append("	ORDER BY DOCTOR_NAME																							");
		
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_language", language);
		 query.setParameter("f_bunho", bunho);
		 query.setParameter("t_double_pkinp1001", pkinp1002);
		 query.setParameter("t_exist_double_type", exitType);
		 query.setParameter("f_gubun_ipwon_date", ipwonDate);
		 
		List<INP1001U01DoubleGrdINP1002Info> lstResult = new JpaResultMapper().list(query,INP1001U01DoubleGrdINP1002Info.class);
		return lstResult;
	}
	
	@Override
	public String inpIsValidGisanDate(String hospCode, Date gisanIpwonDate, Date ipwonDate, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																");
		sql.append("		SELECT FN_INP_IS_VALID_GISAN_DATE (:f_gisan_ipwon_date, :f_ipwon_date, :f_bunho, :f_hosp_code)									");
		sql.append("	FROM																																");
		sql.append("		DUAL																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gisan_ipwon_date", gisanIpwonDate);
		query.setParameter("f_ipwon_date", ipwonDate);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public String inp1001U01checkIsExist(String hospCode, String hoDong, String hoCode, String bedNo){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'															");
		sql.append("       FROM DUAL														");
		sql.append("      WHERE EXISTS ( SELECT 'X'											");
		sql.append("               FROM INP1001												");
		sql.append("              WHERE HOSP_CODE   = :f_hosp_code							");
		sql.append("                AND JAEWON_FLAG = 'Y'									");
		sql.append("                AND HO_DONG1    = :f_ho_dong1							");
		sql.append("                AND HO_CODE1    = :f_ho_code1							");
		sql.append("                AND BED_NO      = :f_bed_no)							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_ho_code1", hoCode);
		query.setParameter("f_bed_no", bedNo);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public Double getListPkinp1001(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(A.PKINP1001 AS CHAR)							");
		sql.append("       FROM INP1001 A											");
		sql.append("      WHERE A.HOSP_CODE              = :f_hosp_code				");
		sql.append("        AND A.BUNHO                  = :f_bunho					");
		sql.append("        AND A.JAEWON_FLAG            = 'Y'						");
		sql.append("        AND IFNULL(A.CANCEL_YN, 'N') = 'N'						");
		sql.append("        AND A.IPWON_TYPE             = '0'						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return CommonUtils.parseDouble(list.get(0));
		}
		return null;
	}
	
	@Override
	public Integer updateInp1001U01DoubleSaveLayout(String hospCode, String userId, String ipwonTime, String ipwonGwa, String gwa, String doctor, String resident,
			String hoCode1, String hoDong1, String hoGrade1, String hoCode2, String hoDong2, String ipwonRtn2, String chojea, String babyStatus,
			String inpTransYn, Double fkout1001, String jaewonFlag, String toiwonGojiYn, String toiwonResDate, String gaToiwonDate, String toiwonDate,
			String toiwonTime, String result, String sigiMagamYn, String cancelDate, String cancelUser, String cancelYn, Double fkinp1003,
			String team, String ipwonDate, String bedNo, String gisanJaewonIlsu, String jisiDoctor, Double pkinp1001){
		
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE  INP1001																				");
		sql.append("         SET UPD_ID                = :f_user_id														");
		sql.append("           , UPD_DATE              = SYSDATE()														");
		sql.append("           , IPWON_TIME            = :f_ipwon_time													");
		sql.append("           , IPWON_GWA             = :f_ipwon_gwa													");
		sql.append("           , GWA                   = :f_gwa															");
		sql.append("           , DOCTOR                = :f_doctor														");
		sql.append("           , RESIDENT              = :f_resident													");
		sql.append("           , HO_CODE1              = :f_ho_code1													");
		sql.append("           , HO_DONG1              = :f_ho_dong1													");
		sql.append("           , HO_GRADE1             = :f_ho_grade1													");
		sql.append("           , HO_CODE2              = :f_ho_code2													");
		sql.append("           , HO_DONG2              = :f_ho_dong2													");
		sql.append("           , IPWON_RTN2            = :f_ipwon_rtn2													");
		sql.append("           , CHOJAE                = :f_chojae														");
		sql.append("           , BABY_STATUS           = :f_baby_status													");
		sql.append("           , INP_TRANS_YN          = :f_inp_trans_yn												");
		sql.append("           , FKOUT1001             = :f_fkout1001													");
		sql.append("           , JAEWON_FLAG           = :f_jaewon_flag													");
		sql.append("           , TOIWON_GOJI_YN        = :f_toiwon_goji_yn												");
		sql.append("           , TOIWON_RES_DATE       = :f_toiwon_res_date												");
		sql.append("           , TOIWON_RES_TIME       = NULL															");
		sql.append("           , GA_TOIWON_DATE        = :f_ga_toiwon_date												");
		sql.append("           , TOIWON_DATE           = :f_toiwon_date													");
		sql.append("           , TOIWON_TIME           = :f_toiwon_time													");
		sql.append("           , RESULT                = :f_result														");
		sql.append("           , SIGI_MAGAM_YN         = :f_sigi_magam_yn												");
		sql.append("           , CANCEL_DATE           = :f_cancel_date													");
		sql.append("           , CANCEL_USER           = :f_cancel_user													");
		sql.append("           , CANCEL_YN             = :f_cancel_yn													");
		sql.append("           , FKINP1003             = :f_fkinp1003													");
		sql.append("           , TEAM                  = :f_team														");
		sql.append("           , SIMSA_MAGAMJA         = NULL															");
		sql.append("           , SIMSA_MAGAM_DATE      = NULL															");
		sql.append("           , SIMSA_MAGAM_TIME      = NULL															");
		sql.append("           , GISAN_IPWON_DATE      = :f_ipwon_date --:f_gisan_ipwon_date							");
		sql.append("           , BED_NO                = :f_bed_no														");
		sql.append("           , GISAN_JAEWON_ILSU     = :f_gisan_jaewon_ilsu											");
		sql.append("           , JISI_DOCTOR           = :f_jisi_doctor													");
		sql.append("       WHERE HOSP_CODE = :f_hosp_code																");
		sql.append("         AND PKINP1001 = :f_pkinp1001																");

		Date dToiwonResDate = null;		
		if(!toiwonResDate.isEmpty() && DateUtil.toDate(toiwonResDate, DateUtil.PATTERN_YYMMDD) != null){
			dToiwonResDate = (DateUtil.toDate(toiwonResDate, DateUtil.PATTERN_YYMMDD));
		}
		Date dGaToiwonDate = null;
		if(!gaToiwonDate.isEmpty() && DateUtil.toDate(gaToiwonDate, DateUtil.PATTERN_YYMMDD) != null){
			dGaToiwonDate = (DateUtil.toDate(gaToiwonDate, DateUtil.PATTERN_YYMMDD));
		}
		Date dToiwonDate = null;
		if(!toiwonDate.isEmpty() && DateUtil.toDate(toiwonDate, DateUtil.PATTERN_YYMMDD) != null){
			dToiwonDate = (DateUtil.toDate(toiwonDate, DateUtil.PATTERN_YYMMDD));
		}
		Date dCancelDate = null;
		if(!cancelDate.isEmpty() && DateUtil.toDate(cancelDate, DateUtil.PATTERN_YYMMDD) != null){
			dCancelDate = (DateUtil.toDate(cancelDate, DateUtil.PATTERN_YYMMDD));
		}
		Date dIpwonDate = null;
		if(!ipwonDate.isEmpty() && DateUtil.toDate(ipwonDate, DateUtil.PATTERN_YYMMDD) != null){
			dIpwonDate = (DateUtil.toDate(ipwonDate, DateUtil.PATTERN_YYMMDD));
		}		
		if(ipwonTime != "" && ipwonTime.indexOf(':') > -1 )
			ipwonTime = (ipwonTime.substring(0, 2) + ipwonTime.substring(3, 5));
			
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_ipwon_time", ipwonTime);
		query.setParameter("f_ipwon_gwa", ipwonGwa);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_resident", resident);
		query.setParameter("f_ho_code1", hoCode1);
		query.setParameter("f_ho_dong1", hoDong1);
		query.setParameter("f_ho_grade1", hoGrade1);
		query.setParameter("f_ho_code2", hoCode2);
		query.setParameter("f_ho_dong2", hoDong2);
		query.setParameter("f_ipwon_rtn2", ipwonRtn2);
		query.setParameter("f_chojae", chojea);
		query.setParameter("f_baby_status", babyStatus);
		query.setParameter("f_inp_trans_yn", inpTransYn);
		query.setParameter("f_fkout1001", fkout1001);
		query.setParameter("f_jaewon_flag", jaewonFlag);
		query.setParameter("f_toiwon_goji_yn", toiwonGojiYn);
		query.setParameter("f_toiwon_res_date", dToiwonResDate);
		query.setParameter("f_ga_toiwon_date", dGaToiwonDate);
		query.setParameter("f_toiwon_date", dToiwonDate);
		query.setParameter("f_toiwon_time", toiwonTime);
		query.setParameter("f_result", result);
		query.setParameter("f_sigi_magam_yn", sigiMagamYn);
		query.setParameter("f_cancel_date", dCancelDate);
		query.setParameter("f_cancel_user", cancelUser);
		query.setParameter("f_cancel_yn", cancelYn);
		query.setParameter("f_fkinp1003", fkinp1003);
		query.setParameter("f_team", team);
		query.setParameter("f_ipwon_date", dIpwonDate);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_gisan_jaewon_ilsu", CommonUtils.parseDouble(gisanJaewonIlsu));
		query.setParameter("f_jisi_doctor", jisiDoctor);
		
		return query.executeUpdate();
	}

	@Override
	public String callFnAdmIsSameNameYnInpT(String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_ADM_IS_SAME_NAME_YN_INP_T(:f_bunho,:f_hospCode)");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public String callPrOcsSetCycleOrderGroup(String hospCode, String bunho, String color) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_SET_CYCLE_ORDER_GROUP");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_COLOR", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);         		
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_COLOR", color);
		
		query.execute();
		String oFlag = (String)query.getOutputParameterValue("O_FLAG");
		
		return oFlag;
	}

	@Override
	public List<OCS6010U10LoadIpwonLstInfo> getOCS6010U10LoadIpwonLstInfo(String hospCode, String language,
			String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PKINP1001                     PKINP1001,    							 	");
		sql.append("		 A.BUNHO                           BUNHO,         							");
		sql.append("		 A.IPWON_DATE                      IPWON_DATE,    							");
		sql.append("		 A.GWA                             GWA,           							");
		sql.append("		 FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :f_language)		");
		sql.append("                                       GWA_NAME,      								");
		sql.append("		 A.DOCTOR                          DOCTOR,        							");
		sql.append("		 FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE, :f_hosp_code)  			");
		sql.append("										                   DOCTOR_NAME,             ");
		sql.append("		 B.GUBUN                           GUBUN,         							");
		sql.append("		 FN_BAS_LOAD_GUBUN_NAME(B.GUBUN, A.IPWON_DATE, :f_hosp_code)    			");
		sql.append("										   GUBUN_NAME     							");
		sql.append("	FROM INP1002 B       ,                                							");
		sql.append("		   INP1001 A                                        						");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code               									");
		sql.append("	 AND A.BUNHO     = :f_bunho                   									");
		sql.append("	 AND IFNULL(A.CANCEL_YN,'N') != 'Y'                      						");
		sql.append("	 AND A.PKINP1001 = B.FKINP1001                        							");
		sql.append("	 AND A.HOSP_CODE = B.HOSP_CODE                        							");
		sql.append("	 AND B.SEQ       = (SELECT MAX(C.SEQ)                 							");
		sql.append("						  FROM INP1002 C                  							");
		sql.append("		 WHERE C.HOSP_CODE = A.HOSP_CODE  											");
		sql.append("		   AND C.FKINP1001 = A.PKINP1001)											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		List<OCS6010U10LoadIpwonLstInfo> lstResult = new JpaResultMapper().list(query, OCS6010U10LoadIpwonLstInfo.class);
		return lstResult;
	}

	@Override
	public List<OCS2003U99grdInp1001Info> getOCS2003U99grdInp1001Info(String hospCode, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PKINP1001           FKINP1001                              ");
		sql.append("     , A.TOIWON_RES_DATE     TOIWON_RES_DATE                        ");
		sql.append("     , A.TOIWON_RES_TIME     TOIWON_RES_TIME                        ");
		sql.append("     , A.TOIWON_GOJI_YN      TOIWON_GOJI_YN   						");
		sql.append("     , A.TOIWON_GOJI_YN      OLD_TOIWON_GOJI_YN                     ");
		sql.append("     , A.SIGI_MAGAM_DATE     SIGI_MAGAM_DATE                        ");
		sql.append("     , A.KI_GUBUN            KI_GUBUN                               ");
		sql.append("     , A.RESULT              RESULT                                 ");
		sql.append("     , A.IPWON_DATE          IPWON_DATE                             ");
		sql.append("     , A.BUNHO               BUNHO                                  ");
		sql.append("     , B.SUNAME              SUNAME                                 ");
		sql.append("     , B.SUNAME2             SUNAME2                                ");
		sql.append("     , IF(A.TOIWON_RES_DATE IS NULL,'N','Y') TOIWON_RES_YN 			");
		sql.append("     , A.HO_DONG1													");
		sql.append("     , A.HO_CODE1  													");
		sql.append("     , ''  															");
		sql.append(" FROM INP1001 A														");
		sql.append("    LEFT JOIN OUT0101 B                                             ");
		sql.append("      ON  A.HOSP_CODE = B.HOSP_CODE     							");
		sql.append("      AND A.BUNHO     = B.BUNHO                                     ");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code 									");
		sql.append("  AND A.PKINP1001 = :f_fkinp1001									");
		sql.append("ORDER BY A.PKINP1001												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		
		List<OCS2003U99grdInp1001Info> lstResult = new JpaResultMapper().list(query, OCS2003U99grdInp1001Info.class);
		return lstResult;
	}

	@Override
	public String getOCS2003U99layCheckDupRequest(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'													");
		sql.append("  FROM DUAL													");
		sql.append(" WHERE EXISTS (SELECT 'X'									");
		sql.append("                 FROM INP1001								");
		sql.append("                WHERE HOSP_CODE           = :f_hosp_code 	");
		sql.append("                  AND BUNHO               = :f_bunho		");
		sql.append("                  AND JAEWON_FLAG         = 'Y'				");
		sql.append("                  AND IFNULL(CANCEL_YN, 'N') = 'N'			");
		sql.append("                GROUP BY BUNHO								");
		sql.append("               HAVING COUNT(BUNHO) > 1)						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		@SuppressWarnings("unchecked")
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public String getIudGubun(String hospCode, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT PKINP1001, IF(:f_toiwon_res_date = '', IF(TOIWON_RES_DATE IS NULL,'00','09'), IF(TOIWON_RES_DATE IS NULL,'01','02')) IUD_GUBUN				");
		sql.append("       FROM INP1001 																																	");
		sql.append("      WHERE HOSP_CODE = :f_hosp_code 																													");
		sql.append("       AND PKINP1001 = :f_fkinp1001																														");
		sql.append("       LIMIT 1																																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public String getOCS2003U99DoctorRequest(String hospCode, String pkinp1001) {
		String sql = " SELECT SUBSTR(DOCTOR, 3, 5) FROM INP1001 WHERE HOSP_CODE = :f_hosp_code AND PKINP1001 = :f_pkinp1001 ";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", CommonUtils.parseDouble(pkinp1001));
		
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}
	
	@Override
	public List<BAS0250Q00layJaewonListInfo> getBAS0250Q00layJaewonListInfoList(String hospCode, String hoDong, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.HO_DONG1            HO_DONG1                               										");
		sql.append("     , A.HO_CODE1            HO_CODE1                               										");
		sql.append("     , A.BED_NO     		 BED_NO                                 										");
		sql.append("     , B.SUNAME              SUNAME   						        										");
		sql.append("     , IF(A.IPWON_DATE IS NULL, '', DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d'))            IPWON_DATE            ");
		sql.append("     , IF(A.TOIWON_RES_DATE IS NULL, '', DATE_FORMAT(A.TOIWON_RES_DATE, '%Y/%m/%d'))   TOIWON_RES_DATE	    ");
		sql.append("     , CASE A.TOIWON_RES_DATE WHEN NULL THEN 'N' ELSE 'Y' END   TOIWON_RES_YN                               ");
		sql.append("     , B.SEX                 SEX                                 										    ");
		sql.append("     , A.IPWON_TYPE          IPWON_TYPE                             										");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('IPWON_TYPE',A.IPWON_TYPE, A.HOSP_CODE, :f_language)                           ");
		sql.append(" FROM OUT0101 B, INP1001 A																					");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code 																			");
		sql.append("  AND A.HO_DONG1 = :f_ho_dong																			    ");
		sql.append("  AND A.JAEWON_FLAG = 'Y'																			        ");
		sql.append("  AND IFNULL(A.CANCEL_YN,'N') <> 'Y'																		");
		sql.append("  AND A.BUNHO = B.BUNHO																			            ");
		sql.append("  ORDER BY A.HO_CODE1																			            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_language", language);
		
		List<BAS0250Q00layJaewonListInfo> lstResult = new JpaResultMapper().list(query, BAS0250Q00layJaewonListInfo.class);
		return lstResult;
	}
	
	@Override
	public List<DataStringListItemInfo> getPkInp1001Ocs2005U02(String hospCode, String bunho, String jaewonYn){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(PKINP1001 AS CHAR)										");
		sql.append("       FROM INP1001 A													");
		sql.append("      WHERE HOSP_CODE   = :f_hosp_code									");
		sql.append("        AND JAEWON_FLAG = :f_jaewon_flag								");
		sql.append("        AND BUNHO       = :f_bunho										");
		sql.append("      ORDER BY A.PKINP1001 DESC											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaewon_flag", jaewonYn);
		query.setParameter("f_bunho", bunho);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public List<DataStringListItemInfo> getInpwonDateOcs2005U02(String hospCode, String bunho, String jaewonYn){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')						");
		sql.append("       FROM INP1001 A													");
		sql.append("      WHERE HOSP_CODE   = :f_hosp_code									");
		sql.append("        AND JAEWON_FLAG = :f_jaewon_flag								");
		sql.append("        AND BUNHO       = :f_bunho										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaewon_flag", jaewonYn);
		query.setParameter("f_bunho", bunho);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public String OCS2005U02GetToiwonDate(String hospCode, Double pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d')						");
		sql.append("       FROM INP1001 A													");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code									");
		sql.append("        AND A.PKINP1001 = :f_pkinp1001									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}

	@Override
	public String getIsJaewonPatientInfo(String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'										");
		sql.append("	FROM VW_OCS_INP1001_RES_11 A					");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("	  AND A.BUNHO = :f_bunho						");
		sql.append("	LIMIT 1											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}

	@Override
	public List<INPORDERTRANSSelectListSQL0BeforeTransInfo> getINPORDERTRANSSelectListSQL0BeforeTransInfo(
			String hospCode, String language, String bunho, Date orderFromDate, Date orderToDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT AA.PKINP1001                                                           AS PKINP1001	                                                ");
		sql.append("	     , AA.BUNHO                                                               AS BUNHO		                                                ");
		sql.append("	     , F.SUNAME                                                               AS SUNAME		                                                ");
		sql.append("	     , AA.IPWON_DATE                                                          AS IPWON_DATE	                                                ");
		sql.append("	     , AA.IPWON_TIME                                                          AS IPWON_TIME	                                                ");
		sql.append("	     , AA.GWA                                                                 AS GWA		                                                ");
		sql.append("	     , SUBSTR(AA.DOCTOR, -5, 5)                                               AS DOCTOR		                                                ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(AA.GWA, IFNULL(B.ACTING_DATE, B.ORDER_DATE), :f_hosp_code, :f_language)                                         ");
		sql.append("																				                                        AS GWA_NAME             ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, IFNULL(B.ACTING_DATE, B.ORDER_DATE), :f_hosp_code)   												");
		sql.append("																				                                        AS DOCTOR_NAME			");
		sql.append("	     , AA.HO_DONG1                                                            AS HO_DONG                                                    ");
		sql.append("	     , AA.HO_CODE1                                                            AS HO_CODE                                                    ");
		sql.append("	     , IFNULL(AB.GUBUN, '##')                                                 AS GUBUN		                                                ");
		sql.append("	     , MAX(B.ORDER_DATE)                                                      AS ORDER_DATE                                                 ");
		sql.append("	     , IFNULL(ZZ.ACT_RES_DATE, IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)))  											        ");
		sql.append("																				                                        AS ACTING_DATE	        ");
		sql.append("	     , ''                                                                     AS PKINP3010   										        ");
		sql.append("	     , ''                                                                     AS SEND_DATE                                                  ");
		sql.append("	     , IF(AA.TOIWON_DATE IS NULL, 'N', 'Y')                                   AS TOIWON_YN                                                  ");
		sql.append("	  FROM VW_OCS_INP1001_01     AA                                                                                                             ");
		sql.append("	     , INP1002               AB                                                                                                             ");
		sql.append("	     , OUT0101               F                                                                                                              ");
		sql.append("	     , OCS2003               B                                                                                                              ");
		sql.append("	  LEFT JOIN (SELECT A.*	                                                                                                                    ");
		sql.append("	          FROM OCS2017 A                                                                                                                    ");
		sql.append("	         WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                ");
		sql.append("	           AND A.ACT_RES_DATE BETWEEN :f_order_from_date                                                                                    ");
		sql.append("	                                  AND :f_order_to_date	                                                                                    ");
		sql.append("	           AND EXISTS (SELECT 'Y'	                                                                                                        ");
		sql.append("	                  FROM OCS2003 X	                                                                                                        ");
		sql.append("	                 WHERE X.HOSP_CODE   = :f_hosp_code                                                                                         ");
		sql.append("	                   AND X.PKOCS2003   = A.FKOCS2003	                                                                                        ");
		sql.append("	                   AND X.ORDER_GUBUN NOT LIKE '%D')	                                                                                        ");
		sql.append("	       ) ZZ ON ZZ.HOSP_CODE 	= B.HOSP_CODE		                                                                                        ");
		sql.append("			   AND ZZ.FKOCS2003  	= B.PKOCS2003		                                                                                        ");
		sql.append("	     , OCS0103               BB						                                                                                        ");
		sql.append("	     , BAS0310               BC						                                                                                        ");
		sql.append("	 ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP	                                                                                        ");
		sql.append("	 WHERE AA.HOSP_CODE                    = :f_hosp_code	                                                                                    ");
		sql.append("	   AND AA.BUNHO                        LIKE :f_bunho	                                                                                    ");
		sql.append("	   AND AA.JAEWON_FLAG                  = 'Y'			                                                                                    ");
		sql.append("	   AND B.HOSP_CODE                     = AA.HOSP_CODE	                                                                                    ");
		sql.append("	   AND B.BUNHO                         = AA.BUNHO		                                                                                    ");
		sql.append("	   AND B.FKINP1001                     = AA.PKINP1001 	                                                                                    ");
		sql.append("	AND(	                                                                                                                                    ");
		sql.append("		( 	                                                                                                                                    ");
		sql.append("			SUBSTR(B.ORDER_GUBUN, 2, 1)        IN ('B', 'C')                                                                                    ");
		sql.append("			AND IFNULL(B.TOIWON_DRG_YN, 'N')        = 'N'	                                                                                    ");
		sql.append("			AND(											                                                                                    ");
		sql.append("				(   B.JUNDAL_PART          NOT IN ('HOM')	                                                                                    ");
		sql.append("						AND IFNULL(ZZ.IF_DATA_SEND_YN, 'N')     = 'N'                                                                           ");
		sql.append("				) 									                                                                                            ");
		sql.append("				OR(B.JUNDAL_PART          IN ('HOM')                                                                                            ");
		sql.append("						AND IFNULL(B.IF_DATA_SEND_YN, 'N')      = 'N'                                                                           ");
		sql.append("				)	                                                                                                                            ");
		sql.append("			)		                                                                                                                            ");
		sql.append("		)			                                                                                                                            ");
		sql.append("		OR 			                                                                                                                            ");
		sql.append("		( 			                                                                                                                            ");
		sql.append("			SUBSTR(B.ORDER_GUBUN, 2, 1)       IN ('B', 'C', 'D')                                                                                ");
		sql.append("			AND IFNULL(B.TOIWON_DRG_YN, 'N')        <> 'N'	                                                                                    ");
		sql.append("			AND IFNULL(B.IF_DATA_SEND_YN, 'N')      = 'N'	                                                                                    ");
		sql.append("		) 	                                                                                                                                    ");
		sql.append("		OR(	                                                                                                                                    ");
		sql.append("			SUBSTR(B.ORDER_GUBUN, 2, 1)       NOT IN ('B', 'C')                                                                                 ");
		sql.append("			AND IFNULL(B.TOIWON_DRG_YN, 'N')         = 'N'                                                                                      ");
		sql.append("			AND IFNULL(B.IF_DATA_SEND_YN, 'N')       = 'N'                                                                                      ");
		sql.append("		)													                                                                                    ");
		sql.append("	)	                                                                                                                                        ");
		sql.append("	AND(                                                                                                                                        ");
		sql.append("		(                                                                                                                                       ");
		sql.append("			SUBSTR(B.ORDER_GUBUN, 2, 1)       IN ('B', 'C')                                                                                     ");
		sql.append("			AND IFNULL(B.TOIWON_DRG_YN, 'N')         = 'N'                                                                                      ");
		sql.append("			AND(											                                                                                    ");
		sql.append("				( B.JUNDAL_PART       NOT IN ('HOM')		                                                                                    ");
		sql.append("					AND ZZ.ACT_RES_DATE BETWEEN :f_order_from_date AND :f_order_to_date                                                         ");
		sql.append("				)								                                                                                                ");
		sql.append("				OR( B.JUNDAL_PART     IN ('HOM')                                                                                                ");
		sql.append("					AND IFNULL(B.HOPE_DATE, B.ORDER_DATE) BETWEEN :f_order_from_date AND :f_order_to_date                                       ");
		sql.append("				)	                                                                                                                            ");
		sql.append("			)		                                                                                                                            ");
		sql.append("		)			                                                                                                                            ");
		sql.append("		OR  		                                                                                                                            ");
		sql.append("		(			                                                                                                                            ");
		sql.append("			SUBSTR(B.ORDER_GUBUN, 2, 1)   NOT IN ('B', 'C')                                                                                     ");
		sql.append("			AND IFNULL(B.TOIWON_DRG_YN, 'N')     = 'N'	                                                                                        ");
		sql.append("			AND   										                                                                                        ");
		sql.append("			(  											                                                                                        ");
		sql.append("				( B.JUNDAL_PART     NOT IN ('HOM')		                                                                                        ");
		sql.append("					AND IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)) BETWEEN :f_order_from_date AND :f_order_to_date                ");
		sql.append("				)                                                                                                                               ");
		sql.append("				OR                                                                                                                              ");
		sql.append("				( B.JUNDAL_PART     IN ('HOM')                                                                                                  ");
		sql.append("					AND IFNULL(B.HOPE_DATE, B.ORDER_DATE) BETWEEN :f_order_from_date AND :f_order_to_date                                       ");
		sql.append("				)	                                                                                                                            ");
		sql.append("			)		                                                                                                                            ");
		sql.append("		)			                                                                                                                            ");
		sql.append("		OR  		                                                                                                                            ");
		sql.append("		(			                                                                                                                            ");
		sql.append("			(		                                                                                                                            ");
		sql.append("				SUBSTR(B.ORDER_GUBUN, 2, 1)   IN ('B', 'C', 'D')	                                                                            ");
		sql.append("				AND IFNULL(B.TOIWON_DRG_YN, 'N')     <> 'N'			                                                                            ");
		sql.append("				AND 												                                                                            ");
		sql.append("				( B.JUNDAL_PART     NOT IN ('HOM')					                                                                            ");
		sql.append("					AND IFNULL(B.ORDER_DATE, B.ACTING_DATE)     BETWEEN :f_order_from_date AND :f_order_to_date	                                ");
		sql.append("				)                                                                                                                               ");
		sql.append("				OR                                                                                                                              ");
		sql.append("				( B.JUNDAL_PART     IN ('HOM')                                                                                                  ");
		sql.append("					AND IFNULL(B.HOPE_DATE, B.ORDER_DATE)       BETWEEN :f_order_from_date AND :f_order_to_date                                 ");
		sql.append("				)	                                                                                                                            ");
		sql.append("			)	                                                                                                                                ");
		sql.append("		) 	                                                                                                                                    ");
		sql.append("	) 		                                                                                                                                    ");
		sql.append("	   AND B.NALSU                          >= 0                                                                                                ");
		sql.append("	   AND IFNULL(B.DC_YN,'N')              = 'N'                                                                                               ");
		sql.append("	   AND IFNULL(B.MUHYO,'N')              = 'N'                                                                                               ");
		sql.append("	   AND BB.HOSP_CODE                    = B.HOSP_CODE                                                                                        ");
		sql.append("	   AND BB.HANGMOG_CODE                 = B.HANGMOG_CODE                                                                                     ");
		sql.append("	   AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)                                                                          ");
		sql.append("	                                            FROM OCS0103 Z							                                                        ");
		sql.append("	                                           WHERE Z.HOSP_CODE       = BB.HOSP_CODE	                                                        ");
		sql.append("	                                             AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE                                                        ");
		sql.append("	                                             AND Z.START_DATE      <= IFNULL(B.ACTING_DATE, B.ORDER_DATE)                                   ");
		sql.append("	                                             AND (   Z.END_DATE    IS NULL									                                ");
		sql.append("	                                                  OR Z.END_DATE    >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                ");
		sql.append("	                                                 )	                                                                                        ");
		sql.append("	                                         )			                                                                                        ");
		sql.append("	   AND (   BB.END_DATE                 IS NULL									                                                            ");
		sql.append("	        OR BB.END_DATE                 >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                                            ");
		sql.append("	       )												                                                                                    ");
		sql.append("	   AND BC.HOSP_CODE                    = B.HOSP_CODE	                                                                                    ");
		sql.append("	   AND BC.SG_CODE                      = B.SG_CODE		                                                                                    ");
		sql.append("	   AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)                                                                              ");
		sql.append("	                                           FROM BAS0310 Z						                                                            ");
		sql.append("	                                          WHERE Z.HOSP_CODE       = BC.HOSP_CODE                                                            ");
		sql.append("	                                            AND Z.SG_CODE         = BC.SG_CODE	                                                            ");
		sql.append("	                                            AND Z.SG_YMD          <= IFNULL(B.ACTING_DATE, B.ORDER_DATE)                                    ");
		sql.append("	                                            AND (   Z.BULYONG_YMD IS NULL																	");
		sql.append("	                                                 OR Z.BULYONG_YMD >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                ");
		sql.append("	                                                )	                                                                                        ");
		sql.append("	                                         )			                                                                                        ");
		sql.append("	   AND (   BC.BULYONG_YMD             IS NULL									                                                            ");
		sql.append("	        OR BC.BULYONG_YMD             >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                                            ");
		sql.append("	       )												                                                                                    ");
		sql.append("	   AND AB.HOSP_CODE                     = AA.HOSP_CODE	                                                                                    ");
		sql.append("	   AND AB.BUNHO                         = AA.BUNHO		                                                                                    ");
		sql.append("	   AND AB.FKINP1001                     = AA.PKINP1001 	                                                                                    ");
		sql.append("	   AND AB.GUBUN_IPWON_DATE              <= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                                            ");
		sql.append("	   AND (   AB.GUBUN_TOIWON_DATE         IS NULL									                                                            ");
		sql.append("	        OR AB.GUBUN_TOIWON_DATE         >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                                                            ");
		sql.append("	       )																		                                                            ");
		sql.append("	   AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)				                                                            ");
		sql.append("	                                             FROM INP1002                  Z 	                                                            ");
		sql.append("	                                            WHERE Z.HOSP_CODE              = AB.HOSP_CODE                                                   ");
		sql.append("	                                              AND Z.FKINP1001              = AB.FKINP1001                                                   ");
		sql.append("	                                              AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE                                            ");
		sql.append("	                                              AND (   Z.GUBUN_TOIWON_DATE  IS NULL									                        ");
		sql.append("	                                                   OR Z.GUBUN_TOIWON_DATE  >= IFNULL(B.ACTING_DATE, B.ORDER_DATE)	                        ");
		sql.append("	                                                  )	                                                                                        ");
		sql.append("	                                         )  		                                                                                        ");
		sql.append("	   AND F.HOSP_CODE                    = AA.HOSP_CODE                                                                                        ");
		sql.append("	   AND F.BUNHO                        = AA.BUNHO							                                                                ");
		sql.append("	 GROUP BY																	                                                                ");
		sql.append("	       AA.PKINP1001                                                                                                                         ");
		sql.append("	     , AA.BUNHO                                                                                                                             ");
		sql.append("	     , F.SUNAME                                                                                                                             ");
		sql.append("	     , AA.IPWON_DATE                                                                                                                        ");
		sql.append("	     , AA.IPWON_TIME                                                                                                                        ");
		sql.append("	     , AA.GWA                                                                                                                               ");
		sql.append("	     , SUBSTR(AA.DOCTOR, -5, 5)                                                                                                             ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(AA.GWA, IFNULL(B.ACTING_DATE, B.ORDER_DATE), :f_hosp_code, :f_language)	                                        ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, IFNULL(B.ACTING_DATE, B.ORDER_DATE), :f_hosp_code)   		                                        ");
		sql.append("	     , AA.HO_DONG1                                                                                                                          ");
		sql.append("	     , AA.HO_CODE1                                                                                                                          ");
		sql.append("	     , IFNULL(AB.GUBUN, '##')                                                                                                               ");
		sql.append("	     , IFNULL(ZZ.ACT_RES_DATE, IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)))                                                    ");
		sql.append("	     , IF(AA.TOIWON_DATE IS NULL, 'N', 'Y')                                 				                                                ");
		sql.append("	 ORDER BY IFNULL(ZZ.ACT_RES_DATE, IFNULL(B.ACTING_DATE, IFNULL(B.HOPE_DATE, B.ORDER_DATE)))	                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_from_date", orderFromDate);
		query.setParameter("f_order_to_date", orderToDate);
		
		List<INPORDERTRANSSelectListSQL0BeforeTransInfo> lstResult = new JpaResultMapper().list(query, INPORDERTRANSSelectListSQL0BeforeTransInfo.class);
		return lstResult;
	}

	@Override
	public List<INPORDERTRANSSelectListSQL0AfterTransInfo> getINPORDERTRANSSelectListSQL0AfterTransInfo(String hospCode,
			String language, String bunho, Date orderFromDate, Date orderToDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT A.FKINP1001                                                                        PKINP1001			");
		sql.append(" 	      , A.BUNHO                                                                           BUNHO 			");
		sql.append(" 	      , C.SUNAME                                                                          SUNAME			");
		sql.append(" 	      , B.IPWON_DATE                                                                      IPWON_DATE		");
		sql.append(" 	      , B.IPWON_TIME                                                                      IPWON_TIME		");
		sql.append(" 	      , A.GWA                                                                             GWA				");
		sql.append(" 	      , A.DOCTOR                                                                          DOCTOR			");
		sql.append(" 	      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ACTING_DATE, :f_hosp_code, :f_language)             GWA_NAME 			");
		sql.append(" 	      , FN_BAS_LOAD_DOCTOR_NAME(CONCAT(A.GWA, A.DOCTOR), A.ACTING_DATE, :f_hosp_code)     DOCTOR_NAME		");
		sql.append(" 	      , FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, CURRENT_DATE(), :f_hosp_code, :f_language)    HO_DONG	        ");
		sql.append(" 	      , D.TO_HO_CODE1                                                                     HO_CODE	        ");
		sql.append(" 	      , A.GUBUN                                                                           GUBUN		        ");
		sql.append(" 	      , IFNULL(							                                                                    ");
		sql.append(" 	            (SELECT MAX(X.ORDER_DATE)	                                                                    ");
		sql.append(" 	               FROM OCS2017 X			                                                                    ");
		sql.append(" 	              WHERE X.HOSP_CODE = A.HOSP_CODE                                                               ");
		sql.append(" 	                AND X.FKINP3010 = A.PKINP3010)                                                              ");
		sql.append(" 	           , (SELECT MAX(Y.ORDER_DATE)	                                                                    ");
		sql.append(" 	                FROM OCS2003 Y			                                                                    ");
		sql.append(" 	               WHERE Y.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append(" 	                 AND Y.FKINP3010 = A.PKINP3010)                                                             ");
		sql.append(" 	           )                                                                              ORDER_DATE        ");
		sql.append(" 	      , A.ACTING_DATE                                                                     ACTING_DATE       ");
		sql.append(" 	      , A.PKINP3010                                                                       PKINP3010         ");
		sql.append(" 	      , CURRENT_DATE()                                                                    SEND_DATE         ");
		sql.append(" 	      , 'N'                                                                               TOIWON_YN         ");
		sql.append(" 	 FROM INP3010 A											                                                    ");
		sql.append(" 	 JOIN /*VW_OCS_INP2004*/ (	                                                                                ");
		sql.append("       SELECT 		A.HOSP_CODE,                                                                                ");
		sql.append("                 A.BUNHO,		                                                                                ");
		sql.append("                 A.PKINP1001,	                                                                                ");
		sql.append("                 DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)	AS JAEWON_DATE,                             ");
		sql.append("                 B.TO_HO_DONG1,	                                                                                ");
		sql.append("                 B.TO_HO_CODE1	                                                                                ");
		sql.append("       FROM 	VW_OCS_INP1001_01 A,                                                                            ");
		sql.append("       		INP2004 B,	                                                                                        ");
		sql.append("       		INP2004 BN,	                                                                                        ");
		sql.append("       		(			                                                                                        ");
		sql.append("       		  SELECT @rownr\\:=@rownr+1 AS ADD_DAY                                                              ");
		sql.append("       			FROM INP1001, (SELECT @rownr\\:=-1) TMP                                                         ");
		sql.append("       		) AA											                                                    ");
		sql.append("       , (select @kcck_hosp_code \\:= :f_hosp_code) TMP    	                                                    ");
		sql.append("       WHERE A.HOSP_CODE = :f_hosp_code						                                                    ");
		sql.append("       AND   A.BUNHO 	  = :f_bunho						                                                    ");
		sql.append("       AND AA.ADD_DAY <= DATEDIFF(IFNULL(A.TOIWON_DATE, CURRENT_DATE()), A.IPWON_DATE) + 31                     ");
		sql.append("       AND B.HOSP_CODE = A.HOSP_CODE                                                                            ");
		sql.append("       AND B.FKINP1001 = A.PKINP1001                                                                            ");
		sql.append("       AND IFNULL(B.CANCEL_YN,'N') = 'N'                                                                        ");
		sql.append(" 														                                                        ");
		sql.append("       AND B.START_DATE =(SELECT MAX(Z.START_DATE)		                                                        ");
		sql.append("          FROM INP2004 Z								                                                        ");
		sql.append("          WHERE     Z.HOSP_CODE = B.HOSP_CODE			                                                        ");
		sql.append("          AND Z.FKINP1001 = B.FKINP1001					                                                        ");
		sql.append("          AND IFNULL(Z.CANCEL_YN,'N') = 'N'				                                                        ");
		sql.append("          AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL		                                                        ");
		sql.append("          AND Z.START_DATE <=DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)	                                ");
		sql.append("          AND (Z.END_DATE IS NULL												                                ");
		sql.append("          OR Z.END_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)))	                                ");
		sql.append("          																		                                ");
		sql.append("       AND B.TRANS_CNT =(SELECT MAX(Z.TRANS_CNT)								                                ");
		sql.append("          FROM INP2004 Z														                                ");
		sql.append("          WHERE     Z.HOSP_CODE = B.HOSP_CODE									                                ");
		sql.append("          AND Z.BUNHO = B.BUNHO													                                ");
		sql.append("          AND Z.FKINP1001 = B.FKINP1001											                                ");
		sql.append("          AND IFNULL(Z.CANCEL_YN,'N') = 'N'										                                ");
		sql.append("          AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL								                                ");
		sql.append("          AND Z.START_DATE = B.START_DATE)										                                ");
		sql.append("       AND BN.HOSP_CODE = A.HOSP_CODE											                                ");
		sql.append("       AND BN.FKINP1001 = A.PKINP1001											                                ");
		sql.append("       AND IFNULL(BN.CANCEL_YN,'N') = 'N'	                                                                    ");
		sql.append(" 											                                                                    ");
		sql.append("       AND BN.START_DATE =(SELECT MAX(Z.START_DATE)                                                             ");
		sql.append("          FROM INP2004 Z						                                                                ");
		sql.append("          WHERE     Z.HOSP_CODE = BN.HOSP_CODE	                                                                ");
		sql.append("          AND Z.FKINP1001 = BN.FKINP1001		                                                                ");
		sql.append("          AND IFNULL(Z.CANCEL_YN,'N') = 'N'		                                                                ");
		sql.append("          AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL                                                               ");
		sql.append("          AND Z.START_DATE <= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)                                   ");
		sql.append("          AND (Z.END_DATE IS NULL											                                    ");
		sql.append("          OR Z.END_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)))                                    ");
		sql.append("          																	                                    ");
		sql.append("       AND BN.TRANS_CNT =(SELECT MIN(Z.TRANS_CNT)							                                    ");
		sql.append("          FROM INP2004 Z													                                    ");
		sql.append("          WHERE     Z.HOSP_CODE = BN.HOSP_CODE								                                    ");
		sql.append("          AND Z.BUNHO = BN.BUNHO											                                    ");
		sql.append("          AND Z.FKINP1001 = BN.FKINP1001									                                    ");
		sql.append("          AND IFNULL(Z.CANCEL_YN,'N') = 'N'									                                    ");
		sql.append("          AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL							                                    ");
		sql.append("          AND Z.START_DATE = BN.START_DATE)									                                    ");
		sql.append("    )D ON D.HOSP_CODE      = A.HOSP_CODE                                                                        ");
		sql.append(" 	                      AND D.BUNHO          = A.BUNHO	                                                    ");
		sql.append(" 	                      AND D.JAEWON_DATE    = CURRENT_DATE()                                                 ");
		sql.append(" 	 LEFT JOIN INP1001 B ON B.HOSP_CODE   = D.HOSP_CODE	                                                        ");
		sql.append(" 	                    AND B.BUNHO       = D.BUNHO                                                             ");
		sql.append(" 	                    AND B.PKINP1001   = D.PKINP1001	                                                        ");
		sql.append(" 	 JOIN OUT0101 C ON C.HOSP_CODE      = A.HOSP_CODE	                                                        ");
		sql.append(" 	               AND C.BUNHO          = A.BUNHO		    													");
		sql.append(" 	WHERE A.HOSP_CODE      = :f_hosp_code	                                                                    ");
		sql.append(" 	  AND A.BUNHO          = :f_bunho		                                                                    ");
		sql.append(" 	  AND A.ACTING_DATE BETWEEN :f_order_from_date AND :f_order_to_date                                         ");
		sql.append(" 	  AND EXISTS (SELECT 'Y' 			                                                                        ");
		sql.append(" 	                FROM OCS2003 Z 		                                                                        ");
		sql.append(" 	               WHERE Z.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append(" 	                 AND Z.BUNHO     = A.BUNHO																	");
		sql.append(" 	                 AND Z.IF_DATA_SEND_YN = 'Y'	                                                            ");
		sql.append(" 	              UNION								                                                            ");
		sql.append(" 	              SELECT 'Y' 						                                                            ");
		sql.append(" 	                FROM OCS2017 Q	                                                                            ");
		sql.append(" 	                   , OCS2003 Z 	                                                                            ");
		sql.append(" 	               WHERE Z.HOSP_CODE = A.HOSP_CODE	                                                            ");
		sql.append(" 	                 AND Z.BUNHO     = A.BUNHO		                                                            ");
		sql.append(" 	                 AND Q.HOSP_CODE = Z.HOSP_CODE	                                                            ");
		sql.append(" 	                 AND Q.FKOCS2003 = Z.PKOCS2003	                                                            ");
		sql.append(" 	                 AND IFNULL(Q.IF_DATA_SEND_YN, 'N') = 'Y')													");
		sql.append(" 	ORDER BY A.ACTING_DATE DESC																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_from_date", orderFromDate);
		query.setParameter("f_order_to_date", orderToDate);
		
		List<INPORDERTRANSSelectListSQL0AfterTransInfo> lstResult = new JpaResultMapper().list(query, INPORDERTRANSSelectListSQL0AfterTransInfo.class);
		return lstResult;
	}

	@Override
	public String getHoDongByHospCodeAndBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_DRG_GET_HO_DONG(:f_hosp_code, :f_bunho) FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public String getToiwonGojiYnFromOcs2003Inp1001(String hospCode, Double fkocs2003) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN	");
		sql.append("	FROM OCS2003 A										");
		sql.append("	JOIN INP1001 B ON A.HOSP_CODE = B.HOSP_CODE			");
		sql.append("	              AND A.FKINP1001 = B.PKINP1001			");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code					");
		sql.append("	 AND A.PKOCS2003 = :f_fkocs2003						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public String callPrDrgInpDrgBunhoCancel(String hospCode, Date jubsuDate, Double drgBunho, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_INP_DRG_BUNHO_CANCEL");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT); 
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_DRG_BUNHO", drgBunho);
		query.setParameter("I_USER_ID", userId);
		query.execute();
		
		String err = (String)query.getOutputParameterValue("O_ERR");
		return err;
	}

	@Override
	public List<DRG3010P10DsvOrderPrint1Info> getDRG3010P10DsvOrderPrint1Info(String hospCode, String language,
			Date jubsuDate, Double drgBunho) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT                                                                                                  ");
		sql.append("	       A.BUNHO                                             BUNHO                                                 ");
		sql.append("	      ,IFNULL(CAST(A.DRG_BUNHO AS CHAR), '')               DRG_BUNHO                                             ");
		sql.append("	      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language)                                ");
		sql.append("	                                                           ORDER_DATE_TEXT                                       ");
		sql.append("	      ,A.JUBSU_DATE                                        JUBSU_DATE                                            ");
		sql.append("	      ,A.HOPE_DATE                                         HOPE_DATE                                             ");
		sql.append("	      ,A.ORDER_DATE                                        ORDER_DATE                                            ");
		sql.append("	      ,CONCAT('Rp.',E.SERIAL_V,IF(A.MIX_GROUP IS NULL,'',' M'))                                                  ");
		sql.append("	                                                           SERIAL_V                                              ");
		sql.append("	      ,E.SERIAL_V                                          SERIAL_TEXT                                           ");
		sql.append("	      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                                      ");
		sql.append("	                                                           GWA_NAME                                              ");
		sql.append("	      ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code), '')                               ");
		sql.append("	                                                           DOCTOR_NAME                                           ");
		sql.append("	      ,D.SUNAME                                            SUNAME                                                ");
		sql.append("	      ,IFNULL(D.SUNAME2, '')                               SUNAME2                                               ");
		sql.append("	      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, :f_hosp_code, :f_language)                                     ");
		sql.append("															   BIRTH                                                 ");
		sql.append("	      ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code)                                                  ");
		sql.append("															   SEX_AGE                                               ");
		sql.append("	      ,IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20), '')   ");
		sql.append("															   HO_CODE                                               ");
		sql.append("	      ,IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20), '')   ");
		sql.append("															   HO_DONG                                               ");
		sql.append("	      ,IF(A.TOIWON_DRG_YN = '1', 'OT', A.MAGAM_GUBUN)      MAGAM_GUBUN                                           ");
		sql.append("	      ,CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR), CAST(E.SERIAL_V AS CHAR))           ");
		sql.append("															   RP_BARCODE                                            ");
		sql.append("	  FROM DRG3010 A                                                                                                 ");
		sql.append("	  LEFT JOIN INV0110 B ON B.HOSP_CODE       = A.HOSP_CODE                                                         ");
		sql.append("	                     AND B.JAERYO_CODE     = A.JAERYO_CODE                                                       ");
		sql.append("	  LEFT JOIN DRG0120 C ON C.HOSP_CODE       = A.HOSP_CODE                                                         ");
		sql.append("	                     AND C.BOGYONG_CODE    = A.BOGYONG_CODE                                                      ");
		sql.append("	  JOIN OUT0101 D ON D.HOSP_CODE          = A.HOSP_CODE                                                           ");
		sql.append("	                AND D.BUNHO              = A.BUNHO                                                               ");
		sql.append("	  JOIN DRG2035 E ON E.HOSP_CODE          = A.HOSP_CODE                                                           ");
		sql.append("	                AND E.JUBSU_DATE         = A.JUBSU_DATE                                                          ");
		sql.append("	                AND E.DRG_BUNHO          = A.DRG_BUNHO                                                           ");
		sql.append("	                AND E.FKOCS2003          = A.FKOCS2003                                                           ");
		sql.append("	  JOIN INP1001 F ON F.HOSP_CODE          = A.HOSP_CODE                                                           ");
		sql.append("	                AND F.PKINP1001          = A.FKINP1001                                                           ");
		sql.append("	 WHERE A.HOSP_CODE          = :f_hosp_code                                                                       ");
		sql.append("	   AND A.JUBSU_DATE         = :f_jubsu_date                                                                      ");
		sql.append("	   AND A.DRG_BUNHO          = :f_drg_bunho                                                                       ");
		sql.append("	   AND A.BUNRYU1            <> '4'                                                                               ");
		sql.append("	 ORDER BY E.SERIAL_V                                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P10DsvOrderPrint1Info> lstResult = new JpaResultMapper().list(query, DRG3010P10DsvOrderPrint1Info.class);
		return lstResult;
	}

	@Override
	public List<DRG3010P10DsvOrderPrint2Info> getDRG3010P10DsvOrderPrint2Info(String hospCode, String language,
			String serialText, String jubsudate, Double drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT                                                                                                                          ");
		sql.append("		   A.BUNHO                                                                                 	BUNHO                                    ");
		sql.append("		  ,A.DRG_BUNHO                                                                             	DRG_BUNHO                                ");
		sql.append("		  ,A.GROUP_SER                                                                             	GROUP_SER                                ");
		sql.append("		  ,A.JUBSU_DATE                                                      						JUBSU_DATE                               ");
		sql.append("		  ,G.HOPE_DATE                                                      						HOPE_DATE                                ");
		sql.append("		  ,A.ORDER_DATE                                                      						ORDER_DATE                               ");
		sql.append("		  ,A.JAERYO_CODE                                                                           	JAERYO_CODE                              ");
		sql.append("		  ,A.NALSU * IF(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code) = 'Y', A.DIVIDE, 1)     NALSU                                    ");
		sql.append("		  ,A.DIVIDE                                                                                	DIVIDE                                   ");
		sql.append("		  ,A.ORD_SURYANG                                                                           	ORD_SURYANG                              ");
		sql.append("		  ,IF(A.BUNRYU1 = '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                 	ORDER_SURYANG                            ");
		sql.append("		  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, :f_hosp_code, :f_language)               ORDER_DANUI                              ");
		sql.append("		  ,A.SUBUL_DANUI                                                                           	SUBUL_DANUI                              ");
		sql.append("		  ,A.BOGYONG_CODE                                                                          	BOGYONG_CODE                             ");
		sql.append("		  ,CONCAT(                                                                                                                           ");
		sql.append("			  TRIM(B.BOGYONG_NAME)                                                                                                           ");
		sql.append("			, FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, :f_hosp_code)                                                  ");
		sql.append("			, IF(                                                                                                                            ");
		sql.append("					(IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0)) = 0                       ");
		sql.append("					, ''                                                                                                                     ");
		sql.append("					, CONCAT('('                                                                                                             ");
		sql.append("						, IFNULL(G.DV_1,0)                                                                                                   ");
		sql.append("						, '-'                                                                                                                ");
		sql.append("						, IFNULL(G.DV_2,0)                                                                                                   ");
		sql.append("						, '-'                                                                                                                ");
		sql.append("						, IFNULL(G.DV_3,0)                                                                                                   ");
		sql.append("						, '-'                                                                                                                ");
		sql.append("						, IFNULL(G.DV_4,0)                                                                                                   ");
		sql.append("						, '-'                                                                                                                ");
		sql.append("						, IFNULL(G.DV_5,0)|| ')'                                                                                             ");
		sql.append("					)                                                                                                                        ");
		sql.append("			)                                                                                                                                ");
		sql.append("		 )                                                                                                                                   ");
		sql.append("																									BOGYONG_NAME                             ");
		sql.append("		  ,SUBSTRING(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', NULL, :f_hosp_code, :f_language) ,1,80)      	     ");
		sql.append("																									CAUTION_NAME                             ");
		sql.append("		  ,IFNULL(A.MIX_YN,'')                                                                                	MIX_YN                       ");
		sql.append("		  ,IFNULL(A.ATC_YN,'')                                                                                	ATC_YN                       ");
		sql.append("		  ,D.DV                                                                                    	DV                                       ");
		sql.append("		  ,A.DV_TIME                                                                               	DV_TIME                                  ");
		sql.append("		  ,IFNULL(D.DC_YN,'')                                                                                  DC_YN                         ");
		sql.append("		  ,IFNULL(D.BANNAB_YN,'')                                                                              BANNAB_YN                     ");
		sql.append("		  ,D.SOURCE_FKOCS2003                                                                       SOURCE_FKOCS2003                         ");
		sql.append("		  ,A.FKOCS2003                                                                              FKOCS2003                                ");
		sql.append("		  ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                        SUNAB_DATE                               ");
		sql.append("		  ,B.PATTERN                                                                                PATTERN                                  ");
		sql.append("		  ,F.HANGMOG_NAME                                                                           JAERYO_NAME                              ");
		sql.append("		  ,0                                                                                        SUNAB_NALSU                              ");
		sql.append("		  ,IFNULL(D.WONYOI_ORDER_YN,'N')                                                            WONYOI_YN                                ");
		sql.append("		  ,CONCAT(F.HANGMOG_NAME, ' : ',  TRIM(D.ORDER_REMARK))                                     ORDER_REMARK                             ");
		sql.append("		  ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                    	ACT_DATE                                 ");
		sql.append("		  ,IFNULL(C.MIX_YN_INP,'N')                                                                 UI_JUSA_YN                               ");
		sql.append("		  ,A.SUBUL_SURYANG                                                                         	SUBUL_SURYANG                            ");
		sql.append("		  ,CONCAT('Rp.', LPAD(E.SERIAL_V, 2, '0'), IF(G.MIX_GROUP IS NULL,'',' M'))     			SERIAL_V                                 ");
		sql.append("		  ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                     GWA_NAME                                 ");
		sql.append("		  ,FN_BAS_LOAD_DOCTOR_NAME(G.RESIDENT, G.ORDER_DATE, :f_hosp_code)                          DOCTOR_NAME                              ");
		sql.append("		  ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, :f_hosp_code)                OTHER_GWA                                ");
		sql.append("		  ,G.POWDER_YN                                        										POWDER_YN                                ");
		sql.append("		  ,IFNULL(E.SERIAL_V, 1)                                                                    LINE                                     ");
		sql.append("		  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)             ORD_DANUI2                               ");
		sql.append("		  ,SUBSTRING(TRIM(A.BUNRYU1),1,1)                                                           BUNRYU1                                  ");
		sql.append("		  ,SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20)	HO_DONG                              ");
		sql.append("		  ,SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20)  HO_CODE                              ");
		sql.append("		  ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code)                                          DONBOK                               ");
		sql.append("		  ,''                                                                                       	TUSUK                                ");
		sql.append("		  ,IF(G.TOIWON_DRG_YN = '1', 'OT', G.MAGAM_GUBUN)                                       		MAGAM_GUBUN                          ");
		sql.append("		  ,IFNULL(C.TEXT_COLOR,'')                                                                      TEXT_COLOR                           ");
		sql.append("		  ,IFNULL(C.CHANGGO1,'')                                                                        CHANGGO                              ");
		sql.append("		  ,CONCAT('( ', DATE_FORMAT(G.HOPE_DATE,'%m/%d'))                                               FROM_ORDER_DATE                      ");
		sql.append("		  ,CONCAT(DATE_FORMAT(DATE_ADD(G.HOPE_DATE, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')          TO_ORDER_DATE                        ");
		sql.append("		  ,'A'                                                                                     		DATA_GUBUN                           ");
		sql.append("		  ,IFNULL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   	HODONG_ORD_NAME                      ");
		sql.append("		  ,(SELECT MAX(IFNULL(X.BANNAB_YN,'N'))                                                                                              ");
		sql.append("			  FROM DRG3010 X                                                                                                                 ");
		sql.append("				 , DRG2035 Y                                                                                                                 ");
		sql.append("			 WHERE Y.HOSP_CODE  = :f_hosp_code                                                                                               ");
		sql.append("			   AND Y.JUBSU_DATE = E.JUBSU_DATE                                                                                               ");
		sql.append("			   AND Y.DRG_BUNHO  = E.DRG_BUNHO                                                                                                ");
		sql.append("			   AND Y.SERIAL_V   = E.SERIAL_V                                                                                                 ");
		sql.append("			   AND X.HOSP_CODE  = Y.HOSP_CODE                                                                                                ");
		sql.append("			   AND Y.FKOCS2003  = X.FKOCS2003                                                                                                ");
		sql.append("			   AND Y.FKOCS2003  = E.FKOCS2003)                                                     		MAX_BANNAB_YN                        ");
		sql.append("	FROM DRG3011 A                                                                                                                           ");
		sql.append("	LEFT JOIN DRG0120 B ON B.HOSP_CODE     = A.HOSP_CODE                                                                                     ");
		sql.append("					   AND B.BOGYONG_CODE  = A.BOGYONG_CODE                                                                                  ");
		sql.append("	LEFT JOIN INV0110 C ON C.HOSP_CODE     = A.HOSP_CODE                                                                                     ");
		sql.append("					   AND C.JAERYO_CODE   = A.JAERYO_CODE                                                                                   ");
		sql.append("	JOIN OCS2003 D ON D.HOSP_CODE        = A.HOSP_CODE                                                                                       ");
		sql.append("				  AND D.PKOCS2003        = A.FKOCS2003                                                                                       ");
		sql.append("	JOIN DRG2035 E ON E.HOSP_CODE        = A.HOSP_CODE                                                                                       ");
		sql.append("				  AND E.JUBSU_DATE       = A.JUBSU_DATE                                                                                      ");
		sql.append("				  AND E.DRG_BUNHO        = A.DRG_BUNHO                                                                                       ");
		sql.append("				  AND E.FKOCS2003        = A.FKOCS2003                                                                                       ");
		sql.append("				  AND E.SERIAL_V         = :f_serial_text                                                                                    ");
		sql.append("	JOIN OCS0103 F ON F.HOSP_CODE        = D.HOSP_CODE                                                                                       ");
		sql.append("				  AND F.HANGMOG_CODE     = D.HANGMOG_CODE                                                                                    ");
		sql.append("				  AND D.ORDER_DATE       BETWEEN   F.START_DATE AND IFNULL(F.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                ");
		sql.append("	JOIN DRG3010 G ON G.HOSP_CODE        = A.HOSP_CODE                                                                                       ");
		sql.append("				  AND G.FKOCS2003        = A.FKOCS2003                                                                                       ");
		sql.append("	WHERE A.HOSP_CODE        = :f_hosp_code                                                                                                  ");
		sql.append("	  AND A.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                        ");
		sql.append("	  AND A.DRG_BUNHO        = :f_drg_bunho                                                                                                  ");
		sql.append("	ORDER BY CONCAT(A.DRG_BUNHO, 'Rp.', LPAD(E.SERIAL_V,2,'0'), IF(G.MIX_GROUP IS NULL,'',' M'))                                             ");
		sql.append("		   , A.FKOCS2003                                                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsudate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3010P10DsvOrderPrint2Info> lstResult = new JpaResultMapper().list(query, DRG3010P10DsvOrderPrint2Info.class);
		return lstResult;
	}
	
	@Override
	public List<INP1001D00grdINP1001Info> getINP1001D00grdINP1001Info(String hospCode, String language, String hoDong1, String sendYn, String queryDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.PKINP1001                                                                                                         ");
		sql.append("        , A.BUNHO                                                                                                             ");
		sql.append("        , B.SUNAME                                                                                                            ");
		sql.append("        , A.GWA                                                                                                               ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :f_language)                                                   ");
		sql.append("        , A.DOCTOR                                                                                                            ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, SYSDATE(), :f_hosp_code)                                                         ");
		sql.append("        , A.HO_DONG1                                                                                                          ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, SYSDATE(), :f_hosp_code, :f_language)                                              ");
		sql.append("        , A.HO_CODE1                                                                                                          ");
		sql.append("        , A.BED_NO                                                                                                            ");
		sql.append("        , A.IPWON_TYPE                                                                                                        ");
		sql.append("        , A.TOIWON_GOJI_YN                                                                                                    ");
		sql.append("        , FN_ADM_IS_SAME_NAME_ALL_YN_INP(A.HOSP_CODE, A.BUNHO) SAME_NAME_YN                                                   ");
		sql.append("        , FN_OCSI_ORDER_STATUS_CHECK (A.HOSP_CODE, A.BUNHO, A.PKINP1001, CASE                                                 ");
		sql.append("                            WHEN DATE_FORMAT(SYSDATE(), '%H%i') > '1800'                                                      ");
		sql.append("                            THEN DATE_ADD(CURRENT_DATE(), INTERVAL 1 DAY)                                                     ");
		sql.append("                            ELSE CURRENT_DATE()                                                                               ");
		sql.append("                    END )                                             ORDER_STATUS                                            ");
		sql.append("        , :f_send_yn                                                                                                          ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                                                                 ");
		sql.append("     JOIN OUT0101 B                                                                                                           ");
		sql.append("       ON A.HOSP_CODE = B.HOSP_CODE                                                                                           ");
		sql.append("      AND B.BUNHO     = A.BUNHO                                                                                               ");
		sql.append("     JOIN BAS0250 C                                                                                                           ");
		sql.append("       ON C.HOSP_CODE = A.HOSP_CODE                                                                                           ");
		sql.append("      AND C.HO_DONG   = A.HO_DONG1                                                                                            ");
		sql.append("      AND C.HO_CODE   = A.HO_CODE1                                                                                            ");
		sql.append("    ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP	                                                                          ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                                          ");
		sql.append("      AND A.HO_DONG1 LIKE :f_ho_dong1                                                                                         ");
		sql.append("      AND (                                                                                                                   ");
		sql.append("            ( :f_send_yn = '%' )                                                                                              ");
		sql.append("            OR                                                                                                                ");
		sql.append("            ( :f_send_yn = 'Y'                                                                                                ");
		sql.append("              AND FN_INP_LOAD_EXIST_MISUNAB_YN (:f_hosp_code, A.PKINP1001, STR_TO_DATE(:f_query_date, '%Y/%m/%d')) = 'N' )    ");
		sql.append("            OR                                                                                                                ");
		sql.append("            ( :f_send_yn = 'N'                                                                                                ");
		sql.append("              AND FN_INP_LOAD_EXIST_MISUNAB_YN (:f_hosp_code, A.PKINP1001, STR_TO_DATE(:f_query_date, '%Y/%m/%d')) = 'Y' )    ");
		sql.append("          )                                                                                                                   ");
		sql.append("      AND (CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END) = 'N'                                        ");
		sql.append("    ORDER BY C.HO_DONG, C.HO_SORT, A.BED_NO                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong1", hoDong1);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_query_date", queryDate);
		
		List<INP1001D00grdINP1001Info> lstResult = new JpaResultMapper().list(query, INP1001D00grdINP1001Info.class);
		return lstResult;
	}
	
	@Override
	public String getNUR2004U01GetSubConfirmData1(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                ");
		sql.append("    FROM DUAL                                                                ");
		sql.append("   WHERE EXISTS (SELECT 'X'                                                  ");
		sql.append("                   FROM VW_OCS_INP1001_01 A                                  ");
		sql.append("                   ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP           ");
		sql.append("                  WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("                    AND A.PKINP1001 = :f_fkinp1001                           ");
		sql.append("                    AND A.TOIWON_GOJI_YN = 'Y')                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public String getNUR2004U01GetSubConfirmData3(String hospCode, String toHoDong1, String toHoCode1, String toBedNo, String bunho, String changeGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                ");
		sql.append("     FROM DUAL                                                               ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                 ");
		sql.append("                    FROM VW_OCS_INP1001_01 B                                 ");
		sql.append("                    ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP          ");
		sql.append("                   WHERE B.HOSP_CODE     = :f_hosp_code                      ");
		sql.append("                     AND B.HO_DONG1      = :f_to_ho_dong1                    ");
		sql.append("                     AND B.HO_CODE1      = :f_to_ho_code1                    ");
		sql.append("                     AND B.BED_NO        = :f_to_bed_no                      ");
		sql.append("                     AND B.BUNHO         <> :f_bunho                         ");
		sql.append("                     AND :f_change_gubun = 'N')                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong1", toHoDong1);
		query.setParameter("f_to_ho_code1", toHoCode1);
		query.setParameter("f_to_bed_no", toBedNo);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_change_gubun", changeGubun);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<ComboListItemInfo> getNUR6011U01IsJaewon(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(A.PKINP1001 AS CHAR)              PKINP1001                               ");
		sql.append("        , DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')  IPWON_DATE                              ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                            ");
		sql.append("     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                     ");
		sql.append("    WHERE A.HOSP_CODE   = :f_hosp_code                                                   ");
		sql.append("      AND A.BUNHO       = :f_bunho                                                       ");
		sql.append("      AND A.JAEWON_FLAG = 'Y'                                                            ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END = 'N'     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<NUR1020U00grdPalistInfo> getNUR1020U00grdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_CODE1                                                              				                HO_CODE           ");
		sql.append("	     , A.BUNHO                                                                 				                BUNHO             ");
		sql.append("	     , A.SUNAME                                                                				                SUNAME            ");
		sql.append("	     , A.PKINP1001                                                             				                PKINP1001         ");
		sql.append("	     , CONCAT(FN_BAS_LOAD_AGE(STR_TO_DATE(:f_date, '%Y/%m/%d'),A.BIRTH,''), '/', A.SEX)               		AGE_SEX           ");
		sql.append("	     , A.IPWON_DATE                                                            				                IPWON_DATE        ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), :f_hosp_code), '') 		DOCTOR_NAME       ");
		sql.append("	     , IFNULL(A.CYCLE_ORDER_GROUP, '')                                                                		CYCLE_ORDER_GROUP ");
		sql.append("	  FROM VW_OCS_INP1001_01 A                                                                                                    ");
		sql.append("	     , BAS0250           B                                                                                                    ");
		sql.append("	     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                          ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code                                                                                         ");
		sql.append("	   AND A.HO_DONG1      = :f_ho_dong                                                                                           ");
		sql.append("	   AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                                                     ");
		sql.append("	   AND A.JAEWON_FLAG   = 'Y'                                                                                                  ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                                              ");
		sql.append("	   AND B.HO_DONG = A.HO_DONG1                                                                                                 ");
		sql.append("	   AND B.HO_CODE = A.HO_CODE1                                                                                                 ");
		sql.append("	   AND ((IFNULL(:f_a, 'N') = 'Y' AND B.TEAM = 'A') OR                                                                         ");
		sql.append("	        (IFNULL(:f_b, 'N') = 'Y' AND B.TEAM = 'B') OR                                                                         ");
		sql.append("	        (IFNULL(:f_c, 'N') = 'Y' AND B.TEAM = 'C') OR                                                                         ");
		sql.append("	        (IFNULL(:f_d, 'N') = 'Y' AND B.TEAM = 'D') OR                                                                         ");
		sql.append("	        (IFNULL(:f_a, 'N') = 'N' AND                                                                                          ");
		sql.append("	         IFNULL(:f_b, 'N') = 'N' AND                                                                                          ");
		sql.append("	         IFNULL(:f_c, 'N') = 'N' AND                                                                                          ");
		sql.append("	         IFNULL(:f_d, 'N') = 'N' )                                                                                            ");
		sql.append("	       )                                                                                                                      ");
		sql.append("	 ORDER BY B.HO_SORT, A.BED_NO                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		query.setParameter("f_a", fa);
		query.setParameter("f_b", fb);
		query.setParameter("f_c", fc);
		query.setParameter("f_d", fd);
		
		List<NUR1020U00grdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR1020U00grdPalistInfo.class);
		return listInfo;
	}
	@Override
	public String getNUR6011U01GetNurseInfoIpwonDate(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')                                 ");
		sql.append("     FROM INP1001 A                                                             ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                            ");
		sql.append("      AND A.PKINP1001 = :f_fkinp1001                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR6011U01fwkAssessorHoDong1(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT HO_DONG1 A                                                            ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                   ");
		sql.append("    ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                             ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                         ");
		sql.append("      AND A.BUNHO        = :f_bunho                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}

	@Override
	public String getNUR1020U00Pkinp1001(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(PKINP1001 AS CHAR)                                              ");
		sql.append("	FROM VW_OCS_INP1001_01                                                      ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                             ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code                                              ");
		sql.append("	 AND BUNHO      = :f_bunho                                                  ");
		sql.append("	 AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN)        = 'N'   ");
		sql.append("	 AND IF(JAEWON_FLAG IS NULL OR JAEWON_FLAG = '', 'N', JAEWON_FLAG)  = 'Y'   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public String getVwOcsInp1001BedNo2ByHospCodePkinp1001(String hospCode, Double pkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT BED_NO2                                                               ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                   ");
		sql.append("    ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                             ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                         ");
		sql.append("      AND A.PKINP1001    = :f_pkinp1001											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		List<String> listData = query.getResultList();
		return CollectionUtils.isEmpty(listData) ? "" : listData.get(0);
	}
	
	@Override
	public String getNUR2004U00CheckPreInsert4(String hospCode, String hoDong1, String hoCode1, String bedNo, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                              ");
		sql.append("   FROM DUAL                                                                               ");
		sql.append("   WHERE EXISTS (SELECT 'X'                                                                ");
		sql.append("                  FROM VW_OCS_INP1001_01                                                   ");
		sql.append("                   ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP           			   ");
		sql.append("                 WHERE HOSP_CODE             = :f_hosp_code                                ");
		sql.append("                   AND HO_DONG1              = :f_to_ho_dong1                              ");
		sql.append("                   AND HO_CODE1              = :f_to_ho_code1                              ");
		sql.append("                   AND BED_NO                = :f_to_bed_no                                ");
		sql.append("                   AND IF(JAEWON_FLAG IS NULL OR JAEWON_FLAG = '', 'N', JAEWON_FLAG) = 'Y' ");
		sql.append("                   AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN)       = 'N' ");
		sql.append("                   AND BUNHO                <> :f_bunho  )                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong1", hoDong1);
		query.setParameter("f_to_ho_code1", hoCode1);
		query.setParameter("f_to_bed_no", bedNo);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public String callFnInpLoadSimaYn(String hospCode, Double pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INP_LOAD_SIMSA_YN(:hospCode, :pkinp1001) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkinp1001", pkinp1001);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public List<NUR1010Q00grdGwaCountInfo> getNUR1010Q00grdGwaCountInfo(String hospCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.GWA                                                 ");
		sql.append("        , B.GWA_NAME                                            ");
		sql.append("        , CAST(COUNT(*) AS CHAR) CNT                            ");
		sql.append("        , B.GWA_COLOR                                           ");
		sql.append("     FROM BAS0260 B                                             ");
		sql.append("        , VW_OCS_INP1001_01 A                                   ");
		sql.append("        ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP         ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                            ");
		sql.append("      AND A.HO_DONG1 = :f_ho_dong                               ");
		sql.append("      AND B.HOSP_CODE = A.HOSP_CODE                             ");
		sql.append("      AND B.GWA = A.GWA                                         ");
		sql.append("    GROUP BY A.GWA, B.GWA_NAME, B.GWA_COLOR                     ");
		sql.append("    ORDER BY A.GWA                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00grdGwaCountInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00grdGwaCountInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR1010Q00SelectDokboInfo> getNUR1010Q00SelectDokboInfo(String hospCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(IFNULL(SUM(CASE(IFNULL(B.DIRECT_CONT1, '3')) WHEN '3' THEN 1 ELSE 0 END), 0) AS CHAR) DOKBO,   ");
		sql.append("          CAST(IFNULL(SUM(CASE(B.DIRECT_CONT1) WHEN '2' THEN 1 ELSE 0 END), 0) AS CHAR) HOSONG,               ");
		sql.append("          CAST(IFNULL(SUM(CASE(B.DIRECT_CONT1) WHEN '1' THEN 1 ELSE 0 END), 0) AS CHAR) DANSONG               ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                                                 ");
		sql.append("     LEFT JOIN (SELECT A.HOSP_CODE, A.FKINP1001, A.DIRECT_CONT1                                               ");
		sql.append("             FROM OCS2005 A                                                                                   ");
		sql.append("             JOIN (SELECT MAX(Z.PKOCS2005) PKOCS2005                                                          ");
		sql.append("                        , Z.HOSP_CODE                                                                         ");
		sql.append("                        , Z.FKINP1001                                                                         ");
		sql.append("                        , Z.DIRECT_GUBUN                                                                      ");
		sql.append("                        , Z.DIRECT_CODE                                                                       ");
		sql.append("                     FROM OCS2005 Z                                                                           ");
		sql.append("                    WHERE Z.ORDER_DATE <= SYSDATE()                                                           ");
		sql.append("                      AND Z.DIRECT_CODE = '0021'                                                              ");
		sql.append("                    GROUP BY Z.HOSP_CODE, Z.FKINP1001, Z.DIRECT_GUBUN, Z.DIRECT_CODE) B                       ");
		sql.append("               ON B.HOSP_CODE    = A.HOSP_CODE                                                                ");
		sql.append("              AND B.FKINP1001    = A.FKINP1001                                                                ");
		sql.append("              AND B.DIRECT_GUBUN = A.DIRECT_GUBUN                                                             ");
		sql.append("              AND B.DIRECT_CODE  = A.DIRECT_CODE                                                              ");
		sql.append("              AND B.PKOCS2005    = A.PKOCS2005                                                                ");
		sql.append("            ) B                                                                                               ");
		sql.append("       ON B.HOSP_CODE    = A.HOSP_CODE                                                                        ");
		sql.append("      AND B.FKINP1001    = A.PKINP1001                                                                        ");
		sql.append("      ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                         ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                                                       ");
		sql.append("      AND A.HO_DONG1     = :f_ho_dong                                                                         ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END = 'N'                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00SelectDokboInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00SelectDokboInfo.class);
		return listInfo;
	}
	
	@Override
	public String checkNUR1010Q00ChangeMoveHosilCheck2(String hospCode, String bedNo, String fromHoCode, String fromHoDong, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                   ");
		sql.append("     FROM DUAL                                                  ");
		sql.append("    WHERE EXISTS ( SELECT 'X'                                   ");
		sql.append("                     FROM VW_OCS_INP1001_01 A                   ");
		sql.append("     			,(select @kcck_hosp_code \\:= :f_hosp_code) TMP ");
		sql.append("                    WHERE A.HOSP_CODE = :f_hosp_code            ");
		sql.append("                      AND A.PKINP1001 = :f_fkinp1001            ");
		sql.append("                      AND A.HO_DONG1  = :f_from_ho_dong         ");
		sql.append("                      AND A.HO_CODE1  = :f_from_ho_code         ");
		sql.append("                      AND A.BED_NO    = :f_from_bed_no )        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_from_ho_dong", fromHoDong);
		query.setParameter("f_from_ho_code", fromHoCode);
		query.setParameter("f_from_bed_no", bedNo);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public String checkNUR1010Q00MoveHosilCheck3(String hospCode, String toBedNo, String toHoCode, String toHoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                                           ");
		sql.append("     FROM DUAL                                                                                          ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                                            ");
		sql.append("                    FROM VW_OCS_INP1001_01 A                                                            ");
		sql.append("     				,(select @kcck_hosp_code \\:= :f_hosp_code) TMP 									");
		sql.append("                   WHERE A.HOSP_CODE           = :f_hosp_code                                           ");
		sql.append("                     AND A.HO_DONG1            = :f_to_ho_dong                                          ");
		sql.append("                     AND A.HO_CODE1            = :f_to_ho_code                                          ");
		sql.append("                     AND A.BED_NO              = :f_to_bed_no                                           ");
		sql.append("                     AND A.JAEWON_FLAG         = 'Y'                                                    ");
		sql.append("                     AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END = 'N')    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong", toHoDong);
		query.setParameter("f_to_ho_code", toHoCode);
		query.setParameter("f_to_bed_no", toBedNo);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public List<NUR1010Q00MoveHosilSelect1Info> getNUR1010Q00MoveHosilSelect1Info(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.GWA                                            ");
		sql.append("         ,A.DOCTOR                                         ");
		sql.append("         ,A.RESIDENT                                       ");
		sql.append("         ,A.HO_CODE1                                       ");
		sql.append("         ,A.HO_DONG1                                       ");
		sql.append("         ,A.HO_GRADE1                                      ");
		sql.append("         ,A.HO_CODE2                                       ");
		sql.append("         ,A.HO_DONG2                                       ");
		sql.append("         ,A.HO_GRADE2                                      ");
		sql.append("         ,A.BED_NO                                         ");
		sql.append("     FROM VW_OCS_INP1001_01 A                              ");
		sql.append("     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP       ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                       ");
		sql.append("      AND A.PKINP1001 = :f_fkinp1001                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR1010Q00MoveHosilSelect1Info> listInfo = new JpaResultMapper().list(query, NUR1010Q00MoveHosilSelect1Info.class);
		return listInfo;
	}
	
	@Override
	public List<NUR1010Q00ChangeHosilSelect1Info> getNUR1010Q00ChangeHosilSelect1Info(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.GWA                                              ");
		sql.append("         ,A.DOCTOR                                           ");
		sql.append("         ,A.RESIDENT                                         ");
		sql.append("         ,A.HO_CODE1                                         ");
		sql.append("         ,A.HO_DONG1                                         ");
		sql.append("         ,A.HO_CODE2                                         ");
		sql.append("         ,A.HO_DONG2                                         ");
		sql.append("         ,A.BED_NO                                           ");
		sql.append("         ,A.BED_NO2                                          ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                ");
		sql.append("     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP         ");
		sql.append("    WHERE A.HOSP_CODE = :i_hosp_code                         ");
		sql.append("      AND A.PKINP1001 = :i_from_fkinp1001                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("i_from_fkinp1001", fkinp1001);
		
		List<NUR1010Q00ChangeHosilSelect1Info> listInfo = new JpaResultMapper().list(query, NUR1010Q00ChangeHosilSelect1Info.class);
		return listInfo;
	}
	
	@Override
	public List<NUR1001R09grdINP1001Info> getNUR1001R09grdINP1001Info(String hospCode, String language, String hoDong, String gwa, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.GWA                                              GWA                                     ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), A.HOSP_CODE, :f_language) GWA_NAME                  ");
		sql.append("        , A.BUNHO                                            BUNHO                                   ");
		sql.append("        , B.SUNAME                                           SUNAME                                  ");
		sql.append("        , B.SUNAME2                                          SUNAME2                                 ");
		sql.append("        , B.SEX                                              SEX                                     ");
		sql.append("        , CAST(FN_BAS_LOAD_AGE(SYSDATE(),B.BIRTH,'') AS CHAR) AGE                                    ");
		sql.append("        , FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.BIRTH, A.HOSP_CODE, :f_language)         BIRTH         ");
		sql.append("        , CONCAT(B.ADDRESS1,B.ADDRESS2)                             ADDRESS                          ");
		sql.append("        , A.DOCTOR                                           DOCTOR                                  ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(), A.HOSP_CODE)  DOCTOR_NAME                     ");
		sql.append("        , 'N'                                                                                        ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                                        ");
		sql.append("     JOIN OUT0101 B                                                                                  ");
		sql.append("       ON B.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("      AND B.BUNHO            = A.BUNHO                                                               ");
		sql.append("     JOIN (SELECT C.HO_CODE HO_CODE                                                                  ");
		sql.append("                , C.HOSP_CODE HOSP_CODE                                                              ");
		sql.append("             FROM BAS0250 C                                                                          ");
		sql.append("            WHERE C.HOSP_CODE   = :f_hosp_code                                                       ");
		sql.append("              AND C.HO_DONG     = :f_ho_dong                                                         ");
		sql.append("              AND SYSDATE() BETWEEN C.START_DATE AND C.END_DATE) G                                   ");
		sql.append("       ON G.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("      AND G.HO_CODE          = A.HO_CODE1                                                            ");
		sql.append("      ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                 ");
		sql.append("      AND A.HO_DONG1         = :f_ho_dong                                                            ");
		sql.append("      AND A.GWA              LIKE :f_gwa                                                             ");
		sql.append("    ORDER BY CONCAT(B.SUNAME2, LPAD(A.PKINP1001, 15,'0'))                                            ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_gwa", gwa);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001R09grdINP1001Info> listInfo = new JpaResultMapper().list(query, NUR1001R09grdINP1001Info.class);
		return listInfo;
	}
	
	@Override
	public List<NUR1001R07grdInp1001Info> getNUR1001R07grdInp1001Info(String hospCode, String language, String bunho,Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT    A.PKINP1001                                                PKINP1001                      ");
		sql.append("           , DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')                     IPWON_DATE                     ");
		sql.append("           , IFNULL(DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'),'')         TOIWON_DATE                    ");
		sql.append("           , FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG1, A.IPWON_DATE, A.HOSP_CODE, :f_language) HO_DONG1    ");
		sql.append("           , A.HO_CODE1                                                HO_CODE1                       ");
		sql.append("        FROM VW_OCS_INP1001_02 A                                                                      ");
		sql.append("        ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                               ");
		sql.append("       WHERE A.HOSP_CODE           = :f_hosp_code                                                     ");
		sql.append("         AND A.BUNHO               = :f_bunho                                                         ");
		sql.append("         AND A.IPWON_TYPE          IN ('0', '1')                                                      ");
		sql.append("         AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END = 'N'                ");
		sql.append("       ORDER BY IPWON_DATE DESC                                                                       ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001R07grdInp1001Info> listInfo = new JpaResultMapper().list(query, NUR1001R07grdInp1001Info.class);
		return listInfo;
	}
	
	@Override
	public List<NUR1035U00grdPalistInfo> getNUR1035U00grdPalistInfo(String hospCode, String hoDong, String date, String a, String b, String c, String d, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT A.HO_CODE1                                                              HO_CODE                           ");
		sql.append("        , A.BUNHO                                                                 BUNHO                              ");
		sql.append("        , A.SUNAME                                                                SUNAME                             ");
		sql.append("        , A.PKINP1001                                                             PKINP1001                          ");
		sql.append("        , CONCAT(FN_BAS_LOAD_AGE(STR_TO_DATE(:f_date,'%Y/%m/%d'),A.BIRTH,''),'/',A.SEX)                   AGE_SEX    ");
		sql.append("        , DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')                                                IPWON_DATE			 ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), A.HOSP_CODE) DOCTOR_NAME               ");
		sql.append("        , A.CYCLE_ORDER_GROUP                                                                                        ");
		sql.append("        , C.YN                                                                                                       ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                                                        ");
		sql.append("     JOIN BAS0250           B                                                                                        ");
		sql.append("       ON B.HOSP_CODE  = A.HOSP_CODE                                                                                 ");
		sql.append("      AND B.HO_DONG    = A.HO_DONG1                                                                                  ");
		sql.append("      AND B.HO_CODE    = A.HO_CODE1                                                                                  ");
		sql.append("     LEFT JOIN                                                                                                       ");
		sql.append("          (SELECT Z.HOSP_CODE                                                                                        ");
		sql.append("                , Z.FKINP1001                                                                                        ");
		sql.append("                , MIN(IFNULL(Y.YN, 'N')) YN                                                                          ");
		sql.append("             FROM NUR1035 Z                                                                                          ");
		sql.append("             LEFT JOIN                                                                                               ");
		sql.append("                  (SELECT X.HOSP_CODE                                                                                ");
		sql.append("                        , X.FKNUR1035 FKNUR1035                                                                      ");
		sql.append("                        , 'Y' YN                                                                                     ");
		sql.append("                     FROM NUR1036 X                                                                                  ");
		sql.append("                    WHERE X.HOSP_CODE = :f_hosp_code                                                                 ");
		sql.append("                      AND X.CHECK_DATE = CURRENT_DATE()                                                              ");
		sql.append("                   )Y                                                                                                ");
		sql.append("               ON Y.FKNUR1035 = Z.PKNUR1035                                                                          ");
		sql.append("            WHERE Z.HOSP_CODE = :f_hosp_code                                                                         ");
		sql.append("              AND SYSDATE() BETWEEN Z.START_DATE AND IFNULL(Z.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))        ");
		sql.append("              GROUP BY Z.HOSP_CODE, Z.FKINP1001) C                                                                   ");
		sql.append("       ON C.HOSP_CODE     = A.HOSP_CODE                                                                              ");
		sql.append("      AND C.FKINP1001     = A.PKINP1001                                                                              ");
		sql.append("      ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                                                             ");
		sql.append("      AND A.HO_DONG1      = :f_ho_dong                                                                               ");
		sql.append("      AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                                         ");
		sql.append("      AND A.JAEWON_FLAG   = 'Y'                                                                                      ");
		sql.append("      AND ((:f_a = 'Y' and B.TEAM = 'A') OR                                                                          ");
		sql.append("           (:f_b = 'Y' and B.TEAM = 'B') OR                                                                          ");
		sql.append("           (:f_c = 'Y' and B.TEAM = 'C') OR                                                                          ");
		sql.append("           (:f_d = 'Y' and B.TEAM = 'D') OR                                                                          ");
		sql.append("           (:f_a = 'N' AND                                                                                           ");
		sql.append("            :f_b = 'N' AND                                                                                           ");
		sql.append("            :f_c = 'N' AND                                                                                           ");
		sql.append("            :f_d = 'N' )                                                                                             ");
		sql.append("          )                                                                                                          ");
		sql.append("    ORDER BY B.HO_SORT, A.BED_NO                                                                                     ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 				");
		}
		
		if(StringUtils.isEmpty(a)){
			a = "N";
		}
		if(StringUtils.isEmpty(b)){
			b = "N";
		}
		if(StringUtils.isEmpty(c)){
			c = "N";
		}
		if(StringUtils.isEmpty(d)){
			d = "N";
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);
		query.setParameter("f_a", a);
		query.setParameter("f_b", b);
		query.setParameter("f_c", c);
		query.setParameter("f_d", d);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1035U00grdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR1035U00grdPalistInfo.class);
		return listInfo;
	}

	@Override
	public Double getPkinp1001ByHospCodeBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT PKINP1001                                ");
		sql.append("	FROM VW_OCS_INP1001_01 A                        ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                ");
		sql.append("	  AND A.BUNHO     = :f_bunho                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<Double> pks = query.getResultList();
		return CollectionUtils.isEmpty(pks) ? null : pks.get(0);
	}

	@Override
	public Double getPkinp1001ByHospCodeBunhoJaewonFlagCancelYn(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT PKINP1001                                             ");
		sql.append("	FROM VW_OCS_INP1001_01 A                                     ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP              ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                             ");
		sql.append("	  AND A.BUNHO     = :f_bunho                                 ");
		sql.append("	  AND IF(JAEWON_FLAG IS NULL OR JAEWON_FLAG = '', 'N') = 'Y' ");
		sql.append("	  AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N')   = 'N'   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<Double> pks = query.getResultList();
		return CollectionUtils.isEmpty(pks) ? null : pks.get(0);
	}

	@Override
	public List<NUR1020Q00grdPalistInfo> getNUR1020Q00grdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_CODE1                                                                         HO_CODE     ");
		sql.append("	     , A.BUNHO                                                                            BUNHO       ");
		sql.append("	     , A.SUNAME                                                                           SUNAME      ");
		sql.append("	     , A.PKINP1001                                                                        PKINP1001   ");
		sql.append("	     , CONCAT(FN_BAS_LOAD_AGE(:f_date,A.BIRTH,''), '/', A.SEX)                            AGE_SEX     ");
		sql.append("	     , A.IPWON_DATE                                                                       IPWON_DATE  ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), :f_hosp_code)  DOCTOR_NAME ");
		//sql.append("	     , IFNULL(B.TEAM, '')                                                                             ");
		sql.append("	  FROM VW_OCS_INP1001_01 A                                                                            ");
		sql.append("	     , BAS0250           B                                                                            ");
		sql.append("	     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                  ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code                                                                 ");
		sql.append("	   AND A.HO_DONG1      = :f_ho_dong                                                                   ");
		sql.append("	   AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                             ");
		sql.append("	   AND A.JAEWON_FLAG   = 'Y'                                                                          ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append("	   AND B.HO_DONG = A.HO_DONG1                                                                         ");
		sql.append("	   AND B.HO_CODE = A.HO_CODE1                                                                         ");
		sql.append("	   AND ((IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'Y' AND B.TEAM = 'A') OR                          ");
		sql.append("	        (IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'Y' AND B.TEAM = 'B') OR                          ");
		sql.append("	        (IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'Y' AND B.TEAM = 'C') OR                          ");
		sql.append("	        (IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'Y' AND B.TEAM = 'D') OR                          ");
		sql.append("	        (IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'N' AND                                           ");
		sql.append("	         IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'N' AND                                           ");
		sql.append("	         IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'N' AND                                           ");
		sql.append("	         IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'N' )                                             ");
		sql.append("	       )                                                                                              ");
		sql.append("	 ORDER BY B.HO_SORT, A.BED_NO                                                                         ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 	  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		query.setParameter("f_a", fa);
		query.setParameter("f_b", fb);
		query.setParameter("f_c", fc);
		query.setParameter("f_d", fd);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1020Q00grdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR1020Q00grdPalistInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR1020Q00layIpwonInfoInfo> getNUR1020Q00layIpwonInfoInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(PKINP1001 AS CHAR)                                              ");
		sql.append("	    , IPWON_DATE                                                            ");
		sql.append("	    , DATEDIFF(CURRENT_DATE(), IPWON_DATE) + 1 JAEWON_ILSU                  ");
		sql.append("	    , HO_DONG1                                                              ");
		sql.append("	 FROM VW_OCS_INP1001_02                                                     ");
		sql.append("     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                            ");
		sql.append("	WHERE HOSP_CODE            = :f_hosp_code                                   ");
		sql.append("	  AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN)        = 'N'  ");
		sql.append("	  AND IF(JAEWON_FLAG IS NULL OR JAEWON_FLAG = '', 'N', JAEWON_FLAG)  = 'Y'  ");
		sql.append("	  AND IPWON_TYPE           = '0'                                            ");
		sql.append("	  AND BUNHO                = :f_bunho                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<NUR1020Q00layIpwonInfoInfo> listInfo = new JpaResultMapper().list(query, NUR1020Q00layIpwonInfoInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR9001U00grdPalistInfo> getNUR9001U00grdPalistInfo(String hospCode, String hoDong, String date, String a, String b, String c, String d, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.HO_CODE1                                                              HO_CODE                 ");
		sql.append("        , A.BUNHO                                                                 BUNHO                   ");
		sql.append("        , A.SUNAME                                                                SUNAME                  ");
		sql.append("        , A.PKINP1001                                                             PKINP1001               ");
		sql.append("        , CONCAT(FN_BAS_LOAD_AGE(:f_date,A.BIRTH,''),'/',A.SEX)                   AGE_SEX                 ");
		sql.append("        , DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')                                    IPWON_DATE             ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), :f_hosp_code) DOCTOR_NAME   ");
		sql.append("        , A.CYCLE_ORDER_GROUP                                                                             ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                                             ");
		sql.append("     JOIN BAS0250           B                                                                             ");
		sql.append("       ON B.HOSP_CODE      = A.HOSP_CODE                                                                  ");
		sql.append("      AND B.HO_DONG        = A.HO_DONG1                                                                   ");
		sql.append("      AND B.HO_CODE        = A.HO_CODE1                                                                   ");
		sql.append("        ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                   ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                                                  ");
		sql.append("      AND A.HO_DONG1      = :f_ho_dong                                                                    ");
		sql.append("      AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                              ");
		sql.append("      AND A.JAEWON_FLAG   = 'Y'                                                                           ");
		sql.append("      AND ((:f_a = 'Y' and B.TEAM = 'A') OR                                                               ");
		sql.append("           (:f_b = 'Y' and B.TEAM = 'B') OR                                                               ");
		sql.append("           (:f_c = 'Y' and B.TEAM = 'C') OR                                                               ");
		sql.append("           (:f_d = 'Y' and B.TEAM = 'D') OR                                                               ");
		sql.append("           (:f_a = 'N' AND                                                                                ");
		sql.append("            :f_b = 'N' AND                                                                                ");
		sql.append("            :f_c = 'N' AND                                                                                ");
		sql.append("            :f_d = 'N' )                                                                                  ");
		sql.append("          )                                                                                               ");
		sql.append("    ORDER BY B.HO_SORT, A.BED_NO                                                                          ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 	  ");
		}
		
		if(StringUtils.isEmpty(a)){
			a = "N";
		}
		if(StringUtils.isEmpty(b)){
			b = "N";
		}
		if(StringUtils.isEmpty(c)){
			c = "N";
		}
		if(StringUtils.isEmpty(d)){
			d = "N";
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);
		query.setParameter("f_a", a);
		query.setParameter("f_b", b);
		query.setParameter("f_c", c);
		query.setParameter("f_d", d);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR9001U00grdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR9001U00grdPalistInfo.class);
		return listInfo;
	}
	
	@Override
	public String getNUR9001U00fkInp1001(String hospCode, String bunho, String toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.PKINP1001                                                                            ");
		sql.append("     FROM INP1001 A                                                                              ");
		sql.append("    WHERE A.HOSP_CODE            = :f_hosp_code                                                  ");
		sql.append("      AND A.BUNHO                = :f_bunho                                                      ");
		sql.append("      AND CASE IFNULL(:f_todate, '') WHEN '' THEN SYSDATE() ELSE :f_todate END                   ");
		sql.append("          BETWEEN A.IPWON_DATE AND IFNULL(A.TOIWON_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))   ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN ,'N') END   = 'N'           ");
		sql.append("      AND IFNULL(A.JAEWON_FLAG,'N') = 'Y'                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_todate", toDate);
		
		List<Double> pks = query.getResultList();
		
		if(!CollectionUtils.isEmpty(pks) && pks.size() > 0){
			return CommonUtils.parseString(pks.get(0));
		}
		return "";
	}
	
	@Override
	public List<NUR1001U00GrdINP1001Info> getNUR1001U00GrdINP1001Info(String hospCode, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                                       BUNHO,                        ");
		sql.append("          DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')         IPWON_DATE,                   ");
		sql.append("          DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d')        TOIWON_DATE,                  ");
		sql.append("          A.JAEWON_FLAG                                 JAEWON_FLAG,                  ");
		sql.append("          A.PKINP1001                                   PKINP1001,                    ");
		sql.append("          A.HO_DONG1                                    HO_DONG,                      ");
		sql.append("          ''                                            DATE_ROW_STATE                ");
		sql.append("     FROM INP1001 A                                                                   ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                  ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                      ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END = 'N'   ");
		sql.append("      AND A.IPWON_TYPE = '0'                                                          ");
		sql.append("    ORDER BY IPWON_DATE DESC                                                          ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																	 	  ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001U00GrdINP1001Info> listInfo = new JpaResultMapper().list(query, NUR1001U00GrdINP1001Info.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1001U00LayFkinp1001Info(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(A.PKINP1001 AS CHAR)                                                   ");
		sql.append("        , CAST(B.FKINP1001 AS CHAR)                                                   ");
		sql.append("     FROM VW_OCS_INP1001_01 A                                                         ");
		sql.append("     JOIN NUR1001 B                                                                   ");
		sql.append("       ON B.HOSP_CODE            = A.HOSP_CODE                                        ");
		sql.append("      AND B.FKINP1001            = A.PKINP1001                                        ");
		sql.append("     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                  ");
		sql.append("    WHERE A.HOSP_CODE            = :f_hosp_code                                       ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END = 'N'   ");
		sql.append("      AND IFNULL(A.JAEWON_FLAG,'N') = 'Y'                                             ");
		sql.append("      AND A.BUNHO                = :f_bunho                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR8003R02grdPayloadDataInfo> getNUR8003R02grdPayloadDataInfo(String hospCode, String language,
			String needHType, String fromDate, String toDate, String hoDong, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKINP1001                                                                                                                                                             ");
		sql.append("	     , (SELECT S.YOYANG_GIHO                                                                                                                                                   ");
		sql.append("	          FROM BAS0001 S                                                                                                                                                       ");
		sql.append("	         WHERE S.HOSP_CODE  = A.HOSP_CODE                                                                                                                                      ");
		sql.append("	           AND A.WRITE_DATE BETWEEN START_DATE   AND END_DATE                                                                                                                  ");
		sql.append("			   LIMIT 1)								                   AS SISETSU_CODE                                                                                             ");
		sql.append("	     , A.WRITE_HODONG                            AS WRITE_HODONG                                                                                                               ");
		sql.append("	     , LPAD(A.BUNHO, FN_NUR_LOAD_CODE_NAME('HFILE_CONSTANT', 'P_BUNHO_LENGTH', :f_hosp_code, :f_language), '0')                                                                ");
		sql.append("	                                                 AS BUNHO                                                                                                                      ");
		sql.append("	     , IFNULL(DATE_FORMAT(MAX(C.TOIWON_DATE), '%Y%m%d'), '00000000')                                                                                                           ");
		sql.append("	                                                 AS TOIWON_DATE                                                                                                                ");
		sql.append("	     , DATE_FORMAT(MAX(C.IPWON_DATE), '%Y%m%d')  AS IPWON_DATE                                                                                                                 ");
		sql.append("	     , SUBSTR(DATE_FORMAT(A.WRITE_DATE, '%Y%m%d'), 0, 6)                                                                                                                       ");
		sql.append("	                                                 AS WRITE_MONTH                                                                                                                ");
		sql.append("	     , DATE_FORMAT(A.WRITE_DATE, '%Y%m%d')       AS WRITE_DATE                                                                                                                 ");
		sql.append("	     , CASE WHEN A.FIRST_GUBUN = 'A' THEN FN_NUR_LOAD_CODE_NAME('HFILE_CONSTANT', 'PAYLOAD_CODE_A', :f_hosp_code, :f_language)                                                 ");
		sql.append("	            WHEN A.FIRST_GUBUN = 'B' THEN FN_NUR_LOAD_CODE_NAME('HFILE_CONSTANT', 'PAYLOAD_CODE_B', :f_hosp_code, :f_language)                                                 ");
		sql.append("	            WHEN A.FIRST_GUBUN = 'C' THEN FN_NUR_LOAD_CODE_NAME('HFILE_CONSTANT', 'PAYLOAD_CODE_C', :f_hosp_code, :f_language)                                                 ");
		sql.append("	            ELSE ''                                                                                                                                                            ");
		sql.append("		   END 										AS PAYLOAD_CODE                                                                                                                ");
		sql.append("	     , FN_NUR_LOAD_CODE_NAME('HFILE_CONSTANT', 'PAYLOAD_VERSION', :f_hosp_code, :f_language)                                                                                   ");
		sql.append("	                                                 AS PAYLOAD_VERSION                                                                                                            ");
		sql.append("	     , '0'                                       AS SEQ                                                                                                                        ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '1'))             ");
		sql.append("	                                                 AS PAYLOAD_1                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '2'))             ");
		sql.append("	                                                 AS PAYLOAD_2                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '3'))             ");
		sql.append("	                                                 AS PAYLOAD_3                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '4'))             ");
		sql.append("	                                                 AS PAYLOAD_4                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '5'))             ");
		sql.append("	                                                 AS PAYLOAD_5                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '6'))             ");
		sql.append("	                                                 AS PAYLOAD_6                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '7'))             ");
		sql.append("	                                                 AS PAYLOAD_7                                                                                                                  ");
		sql.append("	     , FN_NUR_GET_PAYLOAD_VALUE(A.HOSP_CODE, A.FKINP1001, A.WRITE_DATE, A.FIRST_GUBUN, FN_NUR_GET_NEED_ASMT_CODE(A.HOSP_CODE, :f_need_h_type, A.FIRST_GUBUN, '8'))             ");
		sql.append("	                                                 AS PAYLOAD_8                                                                                                                  ");
		sql.append("	  FROM INP1001          C                                                                                                                                                      ");
		sql.append("	     , VW_NUR_HFILE_CODE_INFO          A                                                                                                                                       ");
		sql.append("	     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                                                                           ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                                         ");
		sql.append("	   AND A.WRITE_DATE     BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m') AND LAST_DAY(STR_TO_DATE(:f_to_date, '%Y/%m'))                                                              ");
		sql.append("	   AND A.WRITE_HODONG   IN (SELECT B.HO_DONG                                                                                                                                   ");
		sql.append("	                              FROM NUR0801 B                                                                                                                                   ");
		sql.append("	                             WHERE B.HOSP_CODE = :f_hosp_code                                                                                                                  ");
		sql.append("	                               AND B.HO_DONG   LIKE :f_hoDong                                                                                                                  ");
		sql.append("	                               AND B.NEED_TYPE IN (SELECT X.NEED_TYPE                                                                                                          ");
		sql.append("	                                                     FROM NUR0811       X                                                                                                      ");
		sql.append("	                                                    WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                          ");
		sql.append("	                                                      AND X.NEED_H_TYPE = :f_need_h_type                                                                                       ");
		sql.append("	                                                   )                                                                                                                           ");
		sql.append("	                               AND IFNULL(B.MAKE_H_FILE_YN, 'N') = 'Y'                                                                                                         ");
		sql.append("	                            )                                                                                                                                                  ");
		sql.append("	   AND A.BUNHO          LIKE IF(:f_bunho IS NULL OR :f_bunho = '', '%', :f_bunho)                                                                                              ");
		sql.append("	   AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                                          ");
		sql.append("	   AND C.PKINP1001      = A.FKINP1001                                                                                                                                          ");
		sql.append("	 GROUP BY                                                                                                                                                                      ");
		sql.append("	       A.HOSP_CODE, A.FKINP1001, A.BUNHO, A.WRITE_HODONG, A.WRITE_DATE, A.FIRST_GUBUN                                                                                          ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.BUNHO, A.WRITE_HODONG, A.WRITE_DATE, A.FIRST_GUBUN                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_need_h_type", needHType);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_hoDong", hoDong);
		query.setParameter("f_bunho", bunho);
		
		List<NUR8003R02grdPayloadDataInfo> listInfo = new JpaResultMapper().list(query, NUR8003R02grdPayloadDataInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR1094U00GrdPalistInfo> getNUR1094U00GrdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_CODE1                                                             			HO_CODE                           ");
		sql.append("	    , A.BUNHO                                                                 			BUNHO                             ");
		sql.append("	    , A.SUNAME                                                                			SUNAME                            ");
		sql.append("	    , A.PKINP1001                                                             			PKINP1001                         ");
		sql.append("	    , CONCAT(FN_BAS_LOAD_AGE(:f_date,A.BIRTH,''), '/', A.SEX)                 			AGE_SEX                           ");
		sql.append("	    , A.IPWON_DATE                                                            			IPWON_DATE                        ");
		sql.append("	    , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), :f_hosp_code) DOCTOR_NAME                      ");
		sql.append("	    , A.CYCLE_ORDER_GROUP                                                                                                ");
		sql.append("	    , C.YN                                                                                                               ");
		sql.append("	 FROM VW_OCS_INP1001_01 A                                                                                                ");
		sql.append("	 JOIN BAS0250           B ON B.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("						  AND B.HO_DONG = A.HO_DONG1                                                                      ");
		sql.append("						  AND B.HO_CODE = A.HO_CODE1                                                                      ");
		sql.append("	 LEFT JOIN (SELECT Z.HOSP_CODE                                                                                           ");
		sql.append("	            , Z.FKINP1001                                                                                                ");
		sql.append("	            , MIN(IFNULL(Y.YN, 'N')) YN                                                                                  ");
		sql.append("	         FROM NUR1035 Z                                                                                                  ");
		sql.append("	         LEFT JOIN (SELECT X.HOSP_CODE                                                                                   ");
		sql.append("	                    , X.FKNUR1035 FKNUR1035                                                                              ");
		sql.append("	                    , 'Y' YN                                                                                             ");
		sql.append("	                 FROM NUR1036 X                                                                                          ");
		sql.append("	                WHERE X.HOSP_CODE = :f_hosp_code                                                                         ");
		sql.append("	                  AND X.CHECK_DATE = CURRENT_DATE()                                                                      ");
		sql.append("			)Y ON Y.FKNUR1035 = Z.PKNUR1035                                                                               ");
		sql.append("	        WHERE Z.HOSP_CODE = :f_hosp_code                                                                                 ");
		sql.append("	          AND CURRENT_DATE() BETWEEN Z.START_DATE AND IFNULL(Z.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))          ");
		sql.append("	          GROUP BY Z.HOSP_CODE, Z.FKINP1001                                                                              ");
		sql.append("	) C ON C.HOSP_CODE = A.HOSP_CODE                                                                                      ");
		sql.append("	   AND C.FKINP1001 = A.PKINP1001                                                                                      ");
		sql.append("	     ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                    ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code                                                                                     ");
		sql.append("	  AND A.HO_DONG1      = :f_ho_dong                                                                                       ");
		sql.append("	  AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                                                 ");
		sql.append("	  AND A.JAEWON_FLAG   = 'Y'                                                                                              ");
		sql.append("	  AND ((IFNULL(:f_a, 'N') = 'Y' and B.TEAM = 'A') OR                                                                     ");
		sql.append("	       (IFNULL(:f_b, 'N') = 'Y' and B.TEAM = 'B') OR                                                                     ");
		sql.append("	       (IFNULL(:f_c, 'N') = 'Y' and B.TEAM = 'C') OR                                                                     ");
		sql.append("	       (IFNULL(:f_d, 'N') = 'Y' and B.TEAM = 'D') OR                                                                     ");
		sql.append("	       (IFNULL(:f_a, 'N') = 'N' AND                                                                                      ");
		sql.append("	        IFNULL(:f_b, 'N') = 'N' AND                                                                                      ");
		sql.append("	        IFNULL(:f_c, 'N') = 'N' AND                                                                                      ");
		sql.append("	        IFNULL(:f_d, 'N') = 'N' )                                                                                        ");
		sql.append("	      )                                                                                                                  ");
		sql.append("	ORDER BY B.HO_SORT, A.BED_NO                                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		query.setParameter("f_a", fa);
		query.setParameter("f_b", fb);
		query.setParameter("f_c", fc);
		query.setParameter("f_d", fd);
		
		List<NUR1094U00GrdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR1094U00GrdPalistInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR8003U03GrdPalistInfo> getNUR8003U03GrdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_CODE1                                                                   		HO_CODE       ");
		sql.append("	     , A.BUNHO                                                                        		BUNHO         ");
		sql.append("	     , C.SUNAME                                                                        	    SUNAME        ");
		sql.append("	     , A.PKINP1001                                                                   	    PKINP1001     ");
		sql.append("	     , CONCAT(FN_BAS_LOAD_AGE(:f_date,C.BIRTH,''), '/', C.SEX)                              AGE_SEX       ");
		sql.append("	     , A.IPWON_DATE                                                                 	    IPWON_DATE    ");
		sql.append("	     , A.TOIWON_DATE                                                                	    TOIWON_DATE   ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_date, '%Y/%m/%d'), :f_hosp_code)    DOCTOR_NAME   ");
		sql.append("	     , A.KAIKEI_HODONG                                                                		KAIKEI_HODONG ");
		sql.append("	  FROM INP1001        A                                                                                   ");
		sql.append("	     , BAS0250        B                                                                                   ");
		sql.append("	     , OUT0101        C                                                                                   ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code                                                                     ");
		sql.append("	   AND A.HO_DONG1      = :f_ho_dong                                                                       ");
		sql.append("	   AND A.IPWON_DATE   <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                                 ");
		sql.append("	   AND IFNULL(A.TOIWON_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))  >= STR_TO_DATE(:f_date, '%Y/%m/%d')  ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE                                                                      ");
		sql.append("	   AND B.HO_DONG       = A.HO_DONG1                                                                       ");
		sql.append("	   AND B.HO_CODE       = A.HO_CODE1                                                                       ");
		sql.append("	   AND C.HOSP_CODE     = A.HOSP_CODE                                                                      ");
		sql.append("	   AND C.BUNHO         = A.BUNHO                                                                          ");
		sql.append("	   AND ((IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'Y' AND B.TEAM = 'A') OR                              ");
		sql.append("	        (IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'Y' AND B.TEAM = 'B') OR                              ");
		sql.append("	        (IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'Y' AND B.TEAM = 'C') OR                              ");
		sql.append("	        (IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'Y' AND B.TEAM = 'D') OR                              ");
		sql.append("	        (IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'N' AND                                               ");
		sql.append("	         IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'N' AND                                               ");
		sql.append("	         IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'N' AND                                               ");
		sql.append("	         IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'N' )                                                 ");
		sql.append("	       )                                                                                                  ");
		sql.append("	 ORDER BY B.HO_SORT, A.BED_NO                                                                             ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		query.setParameter("f_a", fa);
		query.setParameter("f_b", fb);
		query.setParameter("f_c", fc);
		query.setParameter("f_d", fd);
		
		List<NUR8003U03GrdPalistInfo> listInfo = new JpaResultMapper().list(query, NUR8003U03GrdPalistInfo.class);
		return listInfo;
	}

	@Override
	public String callFnInpLoadKaikeiHodongHis(String hospCode, Double pkinp1001, Date jukyongDate) {
		String sql = "SELECT FN_INP_LOAD_KAIKEI_HODONG_HIS(:f_hosp_code, :f_pkinp1001, :f_date) FROM DUAL";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		query.setParameter("f_date", jukyongDate);
		
		List<String> rs = query.getResultList();
		return CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
	}

	@Override
	public List<NUR8050U00grdNur8050AllInfo> getNUR8050U00grdNur8050AllInfo(String hospCode, Date fdate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT CONCAT(A.HO_CODE, '-', A.BED_NO) HO_BED                                                         ");
		sql.append("	      , A.BUNHO                                                                                         ");
		sql.append("	      , FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code) AS SUNAME                                             ");
		sql.append("	      , A.FKINP1001                                                                                     ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '01') AS GUBUN1           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '01') AS GUBUN1_DATE ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '02') AS GUBUN2           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '02') AS GUBUN2_DATE ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '03') AS GUBUN3           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '03') AS GUBUN3_DATE ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '04') AS GUBUN4           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '04') AS GUBUN4_DATE ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '05') AS GUBUN5           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '05') AS GUBUN5_DATE ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '06') AS GUBUN6           ");
		sql.append("	      , FN_NUR_GET_NUR8050_RECENT_DATE(A.HOSP_CODE, A.BUNHO, A.FKINP1001, :f_date, '06') AS GUBUN6_DATE ");
		sql.append("	 FROM                                                                                                   ");
		sql.append("	(SELECT A.HOSP_CODE                                                                                     ");
		sql.append("	     , A.BUNHO                                                                                          ");
		sql.append("	     , A.FKINP1001                                                                                      ");
		sql.append("	     , B.HO_CODE1 HO_CODE                                                                               ");
		sql.append("	     , B.BED_NO BED_NO                                                                                  ");
		sql.append("	  FROM NUR8050 A                                                                                        ");
		sql.append("	     , VW_OCS_INP1001_01 B                                                                              ");
		sql.append("		 , (select @kcck_hosp_code \\:= :f_hosp_code) TMP													");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                       ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                        ");
		sql.append("	   AND B.PKINP1001 = A.FKINP1001                                                                        ");
		sql.append("	   AND B.KAIKEI_HODONG = 'C3'                                                                           ");
		sql.append("	 GROUP BY A.HOSP_CODE, A.BUNHO, A.FKINP1001, B.HO_CODE1, B.BED_NO) A                                    ");
		sql.append("	ORDER BY A.HO_CODE, A.BED_NO                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", fdate);
		
		List<NUR8050U00grdNur8050AllInfo> listInfo = new JpaResultMapper().list(query, NUR8050U00grdNur8050AllInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR5020U00grdGuhoGubunInfo> getNUR5020U00grdGuhoGubunInfoMode1(String hospCode, String hoDong, String date, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT '' STAIR,                                                                                       ");
		sql.append("          '' STAIR_NAME,                                                                                  ");
		sql.append("          '' STAIR_TOTAL_CNT,                                                                             ");
		sql.append("          :f_date NUR_WRDT,                                                                               ");
		sql.append("          :f_ho_dong HO_DONG,                                                                             ");
		sql.append("          IFNULL(SUM(CASE(Z.DIRECT_CONT1) WHEN '1' THEN 1 ELSE 0 END), 0) DANSONG_CNT,                    ");
		sql.append("          IFNULL(SUM(CASE(Z.DIRECT_CONT1) WHEN '2' THEN 1 ELSE 0 END), 0) HOSONG_CNT,                     ");
		sql.append("          IFNULL(SUM(CASE(IFNULL(Z.DIRECT_CONT1, '3')) WHEN '3' THEN 1 ELSE 0 END), 0) DOKBO_CNT          ");
		sql.append("         FROM VW_OCS_INP1001_01 B                                                                         ");
		sql.append("         LEFT JOIN ( SELECT A.FKINP1001     FKINP1001                                                     ");
		sql.append("                     , A.ORDER_DATE    ORDER_DATE                                                         ");
		sql.append("                     , A.DIRECT_CONT1  DIRECT_CONT1                                                       ");
		sql.append("                  FROM OCS2005 A                                                                          ");
		sql.append("                 WHERE A.HOSP_CODE = :f_hosp_code                                                         ");
		sql.append("                   AND A.DIRECT_CODE = '0021'                                                             ");
		sql.append("                   AND A.ORDER_DATE = ( SELECT MAX(Z.ORDER_DATE)                                          ");
		sql.append("                                 FROM OCS2005 Z                                                           ");
		sql.append("                                WHERE Z.HOSP_CODE    = A.HOSP_CODE                                        ");
		sql.append("                                  AND Z.FKINP1001    = A.FKINP1001                                        ");
		sql.append("                                  AND Z.DIRECT_GUBUN = A.DIRECT_GUBUN                                     ");
		sql.append("                                  AND Z.DIRECT_CODE  = A.DIRECT_CODE                                      ");
		sql.append("                                  AND Z.ORDER_DATE  <= STR_TO_DATE(:f_date,'%Y/%m/%d') )) Z               ");
		sql.append("          ON  Z.FKINP1001    = B.PKINP1001                                                                ");
		sql.append("         ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                  ");
		sql.append("        WHERE B.HOSP_CODE        = :f_hosp_code                                                           ");
		sql.append("          AND B.KAIKEI_HODONG    = :f_ho_dong                                                             ");
		sql.append("          AND B.JAEWON_FLAG      = 'Y'                                                                    ");
		sql.append("          AND CASE(B.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(B.CANCEL_YN,'N') END = 'N'                   ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																		  ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR5020U00grdGuhoGubunInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdGuhoGubunInfo.class);
		return listInfo;
		
	}
	
	@Override
	public List<NUR5020U00layTotalCntInfo> getNUR5020U00layTotalCntInfo(String hospCode, String hoDong, String fdate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.YESTERDAY_CNT                                                                                                                          ");
		sql.append("	   , CAST(B.IPWON_CNT  AS CHAR)                                                                                                                 ");
		sql.append("	   , CAST(C.TOIWON_CNT AS CHAR)                                                                                                                 ");
		sql.append("	   , CAST(D.JAEWON_CNT AS CHAR)                                                                                                                 ");
		sql.append("	   , CAST(E.JUNCHUL    AS CHAR)                                                                                                                 ");
		sql.append("	   , CAST(F.JUNIP 	 AS CHAR)                                                                                                                 ");
		sql.append("	FROM                                                                                                                                            ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(BUNHO) YESTERDAY_CNT                                                                                                         ");
		sql.append("	        FROM INP1001                                                                                                                            ");
		sql.append("	       WHERE HOSP_CODE   = :f_hosp_code                                                                                                         ");
		sql.append("	         AND KAIKEI_HODONG    = :f_ho_dong                                                                                                      ");
		sql.append("	         AND BUNHO       NOT LIKE '5%'                                                                                                          ");
		sql.append("	         AND JAEWON_FLAG = 'Y'                                                                                                                  ");
		sql.append("	         AND IPWON_TYPE  = '0'                                                                                                                  ");
		sql.append("	         AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                                                      ");
		sql.append("	         AND IF(TOIWON_CANCEL_YN IS NULL OR TOIWON_CANCEL_YN = '', 'N', TOIWON_CANCEL_YN) = 'N'                                                 ");
		sql.append("	         AND IPWON_DATE <= DATE_ADD(STR_TO_DATE(:f_date, '%Y/%m/%d'), INTERVAL -1 DAY)                                                          ");
		sql.append("	         AND IFNULL(TOIWON_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) >  DATE_ADD(STR_TO_DATE(:f_date, '%Y/%m/%d'), INTERVAL -1 DAY)  ) A,     ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(BUNHO) IPWON_CNT                                                                                                             ");
		sql.append("	        FROM INP1001                                                                                                                            ");
		sql.append("	       WHERE HOSP_CODE = :f_hosp_code                                                                                                           ");
		sql.append("	         AND KAIKEI_HODONG  = :f_ho_dong                                                                                                        ");
		sql.append("	         AND BUNHO NOT LIKE '5%'                                                                                                                ");
		sql.append("	         AND IPWON_TYPE  = '0'                                                                                                                  ");
		sql.append("	         AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                                                      ");
		sql.append("	         AND IF(TOIWON_CANCEL_YN IS NULL OR TOIWON_CANCEL_YN = '', 'N', TOIWON_CANCEL_YN) = 'N'                                                 ");
		sql.append("	         AND IPWON_DATE = STR_TO_DATE(:f_date, '%Y/%m/%d')  ) B,                                                                                ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(BUNHO) TOIWON_CNT                                                                                                            ");
		sql.append("	        FROM INP1001                                                                                                                            ");
		sql.append("	       WHERE HOSP_CODE = :f_hosp_code                                                                                                           ");
		sql.append("	         AND KAIKEI_HODONG  = :f_ho_dong                                                                                                        ");
		sql.append("	         AND BUNHO NOT LIKE '5%'                                                                                                                ");
		sql.append("	         AND IPWON_TYPE  = '0'                                                                                                                  ");
		sql.append("	         AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                                                      ");
		sql.append("	         AND IF(TOIWON_CANCEL_YN IS NULL OR TOIWON_CANCEL_YN = '', 'N', TOIWON_CANCEL_YN) = 'N'                                                 ");
		sql.append("	         AND TOIWON_DATE = STR_TO_DATE(:f_date, '%Y/%m/%d')  )C,                                                                                ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(BUNHO) JAEWON_CNT                                                                                                            ");
		sql.append("	        FROM INP1001                                                                                                                            ");
		sql.append("	       WHERE HOSP_CODE = :f_hosp_code                                                                                                           ");
		sql.append("	         AND KAIKEI_HODONG  = :f_ho_dong                                                                                                        ");
		sql.append("	         AND BUNHO NOT LIKE '5%'                                                                                                                ");
		sql.append("	         AND JAEWON_FLAG = 'Y'                                                                                                                  ");
		sql.append("	         AND IPWON_TYPE  = '0'                                                                                                                  ");
		sql.append("	         AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                                                      ");
		sql.append("	         AND IF(TOIWON_CANCEL_YN IS NULL OR TOIWON_CANCEL_YN = '', 'N', TOIWON_CANCEL_YN) = 'N'                                                 ");
		sql.append("	         AND IPWON_DATE <= STR_TO_DATE(:f_date, '%Y/%m/%d')                                                                                     ");
		sql.append("	         AND IFNULL(TOIWON_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) >  STR_TO_DATE(:f_date, '%Y/%m/%d') ) D,                                 ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(*) JUNCHUL                                                                                                                   ");
		sql.append("	        FROM INP2004 A                                                                                                                          ");
		sql.append("	       WHERE A.HOSP_CODE = :f_hosp_code                                                                                                         ");
		sql.append("	         AND A.START_DATE  = :f_date                                                                                                            ");
		sql.append("	         AND A.FROM_KAIKEI_HODONG != A.TO_KAIKEI_HODONG                                                                                         ");
		sql.append("	         AND A.FROM_KAIKEI_HODONG = :f_ho_dong                                                                                                  ");
		sql.append("	       ORDER BY A.SYS_DATE DESC) E,                                                                                                             ");
		sql.append("	                                                                                                                                                ");
		sql.append("	     (                                                                                                                                          ");
		sql.append("	      SELECT COUNT(*) JUNIP                                                                                                                     ");
		sql.append("	        FROM INP2004 A                                                                                                                          ");
		sql.append("	       WHERE A.HOSP_CODE = :f_hosp_code                                                                                                         ");
		sql.append("	         AND A.START_DATE  = :f_date                                                                                                            ");
		sql.append("	         AND A.FROM_KAIKEI_HODONG != A.TO_KAIKEI_HODONG                                                                                         ");
		sql.append("	         AND A.TO_KAIKEI_HODONG = :f_ho_dong                                                                                                    ");
		sql.append("	       ORDER BY A.SYS_DATE DESC)F                                                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fdate);
		
		List<NUR5020U00layTotalCntInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layTotalCntInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00layStairCntInfo> getNUR5020U00layStairCntInfo(String hospCode, String hoDong, Date fdate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(IFNULL(SUM(CASE Z.DIRECT_CONT1 WHEN '1' THEN 1 ELSE 0 END), 0)              AS CHAR)  DANSONG, ");
		sql.append("	       CAST(IFNULL(SUM(CASE Z.DIRECT_CONT1 WHEN '2' THEN 1 ELSE 0 END), 0)              AS CHAR)  HOSONG,  ");
		sql.append("	       CAST(IFNULL(SUM(CASE IFNULL(Z.DIRECT_CONT1, '3') WHEN '3' THEN 1 ELSE 0 END), 0) AS CHAR)  DOKBO,   ");
		sql.append("	       CAST(IFNULL(SUM(1), 0)                                                           AS CHAR)  TOT_CNT  ");
		sql.append("	  FROM VW_OCS_INP1001_01 B                                                                                 ");
		sql.append("	       LEFT OUTER JOIN                                                                                     ");
		sql.append("	       (SELECT A.FKINP1001 FKINP1001,                                                                      ");
		sql.append("	               A.ORDER_DATE ORDER_DATE,                                                                    ");
		sql.append("	               A.DIRECT_CONT1 DIRECT_CONT1                                                                 ");
		sql.append("	          FROM OCS2005 A                                                                                   ");
		sql.append("	         WHERE     A.HOSP_CODE = :f_hosp_code                                                              ");
		sql.append("	               AND A.DIRECT_CODE = '0021'                                                                  ");
		sql.append("	               AND A.ORDER_DATE =                                                                          ");
		sql.append("	                      (SELECT MAX(Z.ORDER_DATE)                                                            ");
		sql.append("	                         FROM OCS2005 Z                                                                    ");
		sql.append("	                        WHERE     Z.HOSP_CODE = A.HOSP_CODE                                                ");
		sql.append("	                              AND Z.FKINP1001 = A.FKINP1001                                                ");
		sql.append("	                              AND Z.DIRECT_GUBUN = A.DIRECT_GUBUN                                          ");
		sql.append("	                              AND Z.DIRECT_CODE = A.DIRECT_CODE                                            ");
		sql.append("	                              AND Z.ORDER_DATE <= :f_date)) Z                                              ");
		sql.append("	          ON Z.FKINP1001 = B.PKINP1001                                                                     ");
		sql.append("	 WHERE     B.HOSP_CODE = :f_hosp_code                                                                      ");
		sql.append("	       AND B.KAIKEI_HODONG = :f_ho_dong                                                                    ");
		sql.append("	       AND B.JAEWON_FLAG = 'Y'                                                                             ");
		sql.append("	       AND B.BUNHO NOT LIKE '5%'                                                                           ");
		sql.append("	       AND IFNULL(B.CANCEL_YN, 'N') = 'N'                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fdate);
		
		List<NUR5020U00layStairCntInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layStairCntInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdIpToiInfo> getNUR5020U00grdIpToiInfoCase1(String hospCode, String language, Date fDate,
			String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')                                                IPWON_DATE     ");
		sql.append("	     , IFNULL(A.KAIKEI_HODONG, '')												            HO_DONG        ");
		sql.append("	     , '01'                                                                                 GUBUN          ");
		sql.append("	     , IFNULL(FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', '01', :f_hosp_code, :f_language), '')   GUBUN_NAME     ");
		sql.append("	     , IFNULL(A.GWA                                                                 , '')   GWA            ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :f_language)  , '')   GWA_NAME       ");
		sql.append("	     , IFNULL(A.KAIKEI_HOCODE                                                       , '')   HO_CODE        ");
		sql.append("	     , IFNULL(A.BUNHO                                                               , '')   BUNHO          ");
		sql.append("	     , IFNULL(FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                             , '')   SUNAME         ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, '')                               , '')   AGE            ");
		sql.append("	     , IFNULL(B.SEX                                                                 , '')   SEX            ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, A.BUNHO, A.PKINP1001)             , '')   SANG           ");
		sql.append("	     , '1'                                                                       	        BIGO           ");
		sql.append("	  FROM INP1001 A                                                                                           ");
		sql.append("	     , OUT0101 B                                                                                           ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                         ");
		sql.append("	   AND B.HOSP_CODE  = A.HOSP_CODE                                                                          ");
		sql.append("	   AND A.BUNHO      = B.BUNHO                                                                              ");
		sql.append("	   AND A.IPWON_DATE = :f_date                                                                              ");
		sql.append("	   AND A.KAIKEI_HODONG   = :f_ho_dong                                                                      ");
		sql.append("	   AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                       ");
		sql.append("	   AND A.IPWON_TYPE IN ('0', '1')                                                                          ");
		sql.append("	   AND A.BUNHO NOT LIKE '5%'                                                                               ");
		sql.append("	 UNION                                                                                                     ");
		sql.append("	SELECT DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d')									               IPWON_DATE  ");
		sql.append("	     , IFNULL(A.KAIKEI_HODONG, '')												               HO_DONG     ");
		sql.append("	     , '02'                                                                                    GUBUN       ");
		sql.append("	     , IFNULL(FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', '02', :f_hosp_code, :f_language)	, '')  GUBUN_NAME  ");
		sql.append("	     , IFNULL(A.GWA                                                                     , '')  GWA         ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.TOIWON_DATE, :f_hosp_code, :f_language)     , '')  GWA_NAME    ");
		sql.append("	     , IFNULL(A.KAIKEI_HOCODE                                                           , '')  HO_CODE     ");
		sql.append("	     , IFNULL(A.BUNHO                                                                   , '')  BUNHO       ");
		sql.append("	     , IFNULL(FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                                 , '')  SUNAME      ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, '')                                   , '')  AGE         ");
		sql.append("	     , IFNULL(B.SEX                                                                     , '')  SEX         ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, A.BUNHO, A.PKINP1001)                 , '')  SANG        ");
		sql.append("	     , '2'                                                                       			   BIGO        ");
		sql.append("	  FROM INP1001 A                                                                                           ");
		sql.append("	     , OUT0101 B                                                                                           ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                                        ");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE                                                                         ");
		sql.append("	   AND A.BUNHO       = B.BUNHO                                                                             ");
		sql.append("	   AND A.TOIWON_DATE = :f_date                                                                             ");
		sql.append("	   AND A.KAIKEI_HODONG    = :f_ho_dong                                                                     ");
		sql.append("	   AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'                                       ");
		sql.append("	   AND A.IPWON_TYPE IN ('0', '1')                                                                          ");
		sql.append("	   AND A.BUNHO NOT LIKE '5%'                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdIpToiInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdIpToiInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR5020U00grdIpToiInfo> getNUR5020U00grdIpToiInfoCase2(String hospCode, String language, Date fDate,
			String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(PKNUR5023 AS CHAR)                                                                       ");
		sql.append("		 , IFNULL(DATE_FORMAT(A.NUR_WRDT, '%Y/%m/%d')                                              , '') ");
		sql.append("		 , IFNULL(A.HO_DONG                                                                        , '') ");
		sql.append("		 , IFNULL(A.DETAIL_GUBUN                                                                   , '') ");
		sql.append("		 , IFNULL(FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', A.DETAIL_GUBUN, :f_hosp_code, :f_language) , '') ");
		sql.append("		 , IFNULL(A.GWA                                                                            , '') ");
		sql.append("		 , IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.NUR_WRDT, :f_hosp_code, :f_language)               , '') ");
		sql.append("		 , IFNULL(A.HO_CODE                                                                        , '') ");
		sql.append("		 , IFNULL(A.BUNHO                                                                          , '') ");
		sql.append("		 , IFNULL(FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                                        , '') ");
		sql.append("		 , IFNULL(FN_OCS_LOAD_AGE(:f_hosp_code, A.BUNHO, SYSDATE())                                , '') ");
		sql.append("		 , IFNULL(B.SEX                                                                            , '') ");
		sql.append("		 , IFNULL(A.SANG                                                                           , '') ");
		sql.append("		 , IFNULL(A.BIGO                                                                           , '') ");
		sql.append("	  FROM NUR5023 A                                                                                     ");
		sql.append("		 , OUT0101 B                                                                                     ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                    ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                     ");
		sql.append("	   AND B.BUNHO     = A.BUNHO                                                                         ");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong                                                                      ");
		sql.append("	   AND A.NUR_WRDT  = :f_date                                                                         ");
		sql.append("	   AND A.GUBUN     = '2'                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdIpToiInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdIpToiInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00layPatientInfoInInfo> getNUR5020U00layPatientInfoInInfo(String hospCode, String bunho,
			Date nurWrdt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.HO_DONG1, '')  HO_DONG                                                          ");
		sql.append("	     , IFNULL(A.HO_CODE1, '')  HO_CODE                                                          ");
		sql.append("	     , IFNULL(B.SUNAME, '')    SUNAME                                                           ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_AGE(:f_nur_wrdt, B.BIRTH,''), '') AGE                                 ");
		sql.append("	     , IFNULL(B.SEX, '')       SEX                                                              ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, A.BUNHO, A.PKINP1001), '') SANG_NAME          ");
		sql.append("	     , IFNULL(A.GWA, '')                                                                        ");
		sql.append("	  FROM INP1001 A                                                                                ");
		sql.append("	     , OUT0101 B                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                             ");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE                                                              ");
		sql.append("	   AND A.BUNHO       = :f_bunho                                                                 ");
		sql.append("	   AND B.BUNHO       = A.BUNHO                                                                  ");
		sql.append("	   AND IF(A.CANCEL_YN IS NULL OR A.CANCEL_YN = '', 'N', A.CANCEL_YN) = 'N'                      ");
		sql.append("	   AND A.IPWON_TYPE = '0'                                                                       ");
		sql.append("	   AND IF(A.TOIWON_CANCEL_YN IS NULL OR A.TOIWON_CANCEL_YN = '', 'N', A.TOIWON_CANCEL_YN) = 'N' ");
		sql.append("	   AND A.PKINP1001 = (SELECT MAX(PKINP1001)                                                     ");
		sql.append("	                        FROM INP1001 X                                                          ");
		sql.append("	                       WHERE X.HOSP_CODE = A.HOSP_CODE                                          ");
		sql.append("	                         AND X.BUNHO = A.BUNHO)                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_nur_wrdt", nurWrdt);
		
		List<NUR5020U00layPatientInfoInInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layPatientInfoInInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR5020U00layPatientInfoInInfo> getNUR5020U00layPatientInfoInInfoCase2(String hospCode, String bunho,
			Date nurWrdt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_DONG1  HO_DONG                                                              ");
		sql.append("	     , A.HO_CODE1  HO_CODE                                                              ");
		sql.append("	     , B.SUNAME    SUNAME                                                               ");
		sql.append("	     , FN_BAS_LOAD_AGE(:f_nur_wrdt, B.BIRTH,'') AGE                                     ");
		sql.append("	     , B.SEX       SEX                                                                  ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, A.BUNHO, A.PKINP1001), '') SANG_NAME  ");
		sql.append("	     , A.GWA                                                                            ");
		sql.append("	  FROM INP1001 A                                                                        ");
		sql.append("	     , OUT0101 B                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                     ");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE                                                      ");
		sql.append("	   AND A.BUNHO       = :f_bunho                                                         ");
		sql.append("	   AND B.BUNHO       = A.BUNHO                                                          ");
		sql.append("	   AND A.JAEWON_FLAG = 'Y'                                                              ");
		sql.append("	   AND IF(A.CANCEL_YN IS NULL OR A.CANCEL_YN = '', 'N', A.CANCEL_YN) = 'N'              ");
		sql.append("	   AND A.IPWON_TYPE = '0'                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_nur_wrdt", nurWrdt);
		
		List<NUR5020U00layPatientInfoInInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layPatientInfoInInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00layPatientInfoInfo> getNUR5020U00layPatientInfoInfo(String hospCode, String bunho,
			Date nurWrdt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''                                       HO_CODE   ");
		sql.append("	     , B.SUNAME                                 SUNAME    ");
		sql.append("	     , FN_BAS_LOAD_AGE(:f_nur_wrdt, B.BIRTH,'') AGE       ");
		sql.append("	     , B.SEX                                    SEX       ");
		sql.append("	     , ''                                       SANG_NAME ");
		sql.append("	     , ''                                       GWA       ");
		sql.append("	  FROM OUT0101 B                                          ");
		sql.append("	 WHERE B.HOSP_CODE   = :f_hosp_code                       ");
		sql.append("	   AND B.BUNHO       = :f_bunho                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_nur_wrdt", nurWrdt);
		
		List<NUR5020U00layPatientInfoInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layPatientInfoInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00layGamyumCntInfo> getNUR5020U00layGamyumCntInfo(String hospCode, String hoDong, Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUM(CNT1), SUM(CNT2), SUM(CNT3), SUM(CNT4), SUM(CNT5)                                      ");
		sql.append("	FROM(                                                                                             ");
		sql.append("		SELECT COUNT(CASE A.INFE_CODE WHEN '01' THEN 1 ELSE 0 END)    CNT1                            ");
		sql.append("		 , COUNT(CASE A.INFE_CODE WHEN '02' THEN 1 ELSE 0 END)    CNT2                                ");
		sql.append("		 , COUNT(CASE A.INFE_CODE WHEN '03' THEN 1 ELSE 0 END)    CNT3                                ");
		sql.append("		 , COUNT(CASE A.INFE_CODE WHEN '04' THEN 1 ELSE 0 END)    CNT4                                ");
		sql.append("		 , COUNT(CASE A.INFE_CODE WHEN '05' THEN 1 ELSE 0 END)    CNT5                                ");
		sql.append("		 , INFE_CODE                                                                                  ");
		sql.append("		FROM NUR1017 A, INP1001 B                                                                     ");
		sql.append("		WHERE A.HOSP_CODE  = :f_hosp_code                                                             ");
		sql.append("		AND B.HOSP_CODE  = A.HOSP_CODE                                                                ");
		sql.append("		AND B.KAIKEI_HODONG   = :f_ho_dong                                                            ");
		sql.append("		AND IFNULL(B.CANCEL_YN,'N') = 'N'                                                             ");
		sql.append("		AND IFNULL(B.TOIWON_CANCEL_YN,'N') = 'N'                                                      ");
		sql.append("		AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                             ");
		sql.append("		AND B.BUNHO NOT LIKE '5%'                                                                     ");
		sql.append("		AND B.IPWON_TYPE IN('0','1')                                                                  ");
		sql.append("		AND B.JAEWON_FLAG = 'Y'                                                                       ");
		sql.append("		AND A.BUNHO       = B.BUNHO                                                                   ");
		sql.append("		AND :f_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE,STR_TO_DATE('9998/12/31','%Y/%m/%d'))  ");
		sql.append("	) T                                                                                               ");
		sql.append("	GROUP BY INFE_CODE                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00layGamyumCntInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00layGamyumCntInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdBedSoreInfo> getNUR5020U00grdBedSoreInfoCase1(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.HO_CODE1       HO_CODE                                                                                                                          ");
		sql.append("	    , B.BUNHO          BUNHO                                                                                                                             ");
		sql.append("	    , C.SUNAME         SUNAME                                                                                                                            ");
		sql.append("	    , A.FROM_DATE      FROM_DATE                                                                                                                         ");
		sql.append("	    , IFNULL(CONCAT(F1.CODE_NAME, ', ', F2.CODE_NAME, ', ', F3.CODE_NAME, ', ', F4.CODE_NAME, ', ', F5.CODE_NAME, ', ', F6.CODE_NAME), '')     BUWI      ");
		sql.append("	 FROM NUR6001 A                                                                                                                                          ");
		sql.append("	    , VW_OCS_INP1001_01 B                                                                                                                                ");
		sql.append("	    , OUT0101 C                                                                                                                                          ");
		sql.append("	    , NUR0102 F1                                                                                                                                         ");
		sql.append("	    , NUR0102 F2                                                                                                                                         ");
		sql.append("	    , NUR0102 F3                                                                                                                                         ");
		sql.append("	    , NUR0102 F4                                                                                                                                         ");
		sql.append("	    , NUR0102 F5                                                                                                                                         ");
		sql.append("	    , NUR0102 F6                                                                                                                                         ");
		sql.append("	    , (select @kcck_hosp_code \\:= :f_hosp_code) TMP																									 ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                         ");
		sql.append("	  AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                          ");
		sql.append("	  AND B.PKINP1001 = A.FKINP1001                                                                                                                          ");
		sql.append("	  AND SYSDATE() BETWEEN A.FROM_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                                                        ");
		sql.append("	  AND B.KAIKEI_HODONG = 'A'                                                                                                                              ");
		sql.append("	  AND C.HOSP_CODE = A.HOSP_CODE                                                                                                                          ");
		sql.append("	  AND C.BUNHO = A.BUNHO                                                                                                                                  ");
		sql.append("	  AND F1.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F1.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F1.CODE = A.BEDSORE_BUWI1                                                                                                                          ");
		sql.append("	                                                                                                                                                         ");
		sql.append("	  AND F2.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F2.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F2.CODE = A.BEDSORE_BUWI2                                                                                                                          ");
		sql.append("	                                                                                                                                                         ");
		sql.append("	  AND F3.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F3.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F3.CODE = A.BEDSORE_BUWI3                                                                                                                          ");
		sql.append("	                                                                                                                                                         ");
		sql.append("	  AND F4.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F4.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F4.CODE = A.BEDSORE_BUWI4                                                                                                                          ");
		sql.append("	                                                                                                                                                         ");
		sql.append("	  AND F5.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F5.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F5.CODE = A.BEDSORE_BUWI5                                                                                                                          ");
		sql.append("	                                                                                                                                                         ");
		sql.append("	  AND F6.HOSP_CODE = A.HOSP_CODE                                                                                                                         ");
		sql.append("	  AND F6.CODE_TYPE = 'BEDSORE_BUWI'                                                                                                                      ");
		sql.append("	  AND F6.CODE = A.BEDSORE_BUWI6                                                                                                                          ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<NUR5020U00grdBedSoreInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdBedSoreInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdBedSoreInfo> getNUR5020U00grdBedSoreInfoCase2(String hospCode, String hoDong, Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_DONG                 ");
		sql.append("	    , A.NUR_WRDT                 ");
		sql.append("	    , A.HO_CODE                  ");
		sql.append("	    , A.BUNHO                    ");
		sql.append("	    , B.SUNAME                   ");
		sql.append("	    , A.FROM_DATE                ");
		sql.append("	    , A.BUWI                     ");
		sql.append("	 FROM NUR5028 A                  ");
		sql.append("	    , OUT0101 B                  ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code ");
		sql.append("	  AND A.HO_DONG   = :f_ho_dong   ");
		sql.append("	  AND A.NUR_WRDT  = :f_date      ");
		sql.append("	  AND B.HOSP_CODE = A.HOSP_CODE  ");
		sql.append("	  AND B.BUNHO     = A.BUNHO      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdBedSoreInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdBedSoreInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdGwaInfo> getNUR5020U00grdGwaInfoCase1(String hospCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GWA, B.GWA_NAME, CAST(COUNT(*) AS CHAR), B.GWA_COLOR ");
		sql.append("	  FROM BAS0260 B                                              ");
		sql.append("	     , VW_OCS_INP1001_01 A                                    ");
		sql.append("	     , (select @kcck_hosp_code \\:= :f_hosp_code) TMP		  ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code                            ");
		sql.append("	   AND A.KAIKEI_HODONG = :f_ho_dong                           ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                              ");
		sql.append("	   AND B.GWA = A.GWA                                          ");
		sql.append("	  GROUP BY A.GWA, B.GWA_NAME, B.GWA_COLOR                     ");
		sql.append("	  ORDER BY A.GWA                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR5020U00grdGwaInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdGwaInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdGwaInfo> getNUR5020U00grdGwaInfoCase2(String hospCode, String hoDong, Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_WRDT                  ");
		sql.append("	     , A.HO_DONG                   ");
		sql.append("	     , A.GWA                       ");
		sql.append("	     , A.GWA_NAME                  ");
		sql.append("	     , CAST(A.PA_CNT AS CHAR), ''  ");
		sql.append("	  FROM NUR5026 A                   ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code  ");
		sql.append("	   AND A.NUR_WRDT  = :f_date       ");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdGwaInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdGwaInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdSusulInfo> getNUR5020U00grdSusulInfoCase1(String hospCode, String language, String hoDong,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.RESER_DATE                                                        ");
		sql.append("	   , '01'                                                                  ");
		sql.append("	   , A.GWA                                                                 ");
		sql.append("	   , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE, :f_hosp_code, :f_language)  ");
		sql.append("	   , B.KAIKEI_HODONG                                                       ");
		sql.append("	   , B.KAIKEI_HOCODE                                                       ");
		sql.append("	   , B.BUNHO                                                               ");
		sql.append("	   , C.SUNAME                                                              ");
		sql.append("	   , FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, '')                               ");
		sql.append("	   , C.SEX                                                                 ");
		sql.append("	   , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, B.BUNHO, B.PKINP1001), '') ");
		sql.append("	   , D.HANGMOG_NAME                                                        ");
		sql.append("	FROM SCH0201 A                                                             ");
		sql.append("	   , INP1001 B                                                             ");
		sql.append("	   , OUT0101 C                                                             ");
		sql.append("	   , OCS0103 D                                                             ");
		sql.append("	WHERE A.HOSP_CODE          = :f_hosp_code                                  ");
		sql.append("	 AND B.HOSP_CODE           = A.HOSP_CODE                                   ");
		sql.append("	 AND C.HOSP_CODE           = A.HOSP_CODE                                   ");
		sql.append("	 AND D.HOSP_CODE           = A.HOSP_CODE                                   ");
		sql.append("	 AND A.JUNDAL_TABLE        = 'OP'                                          ");
		sql.append("	 AND A.RESER_DATE          = :f_date                                       ");
		sql.append("	 AND A.BUNHO               = B.BUNHO                                       ");
		sql.append("	 AND B.KAIKEI_HODONG       = :f_ho_dong                                    ");
		sql.append("	 AND B.JAEWON_FLAG         = 'Y'                                           ");
		sql.append("	 AND IF(B.CANCEL_YN IS NULL OR B.CANCEL_YN = '', 'N', B.CANCEL_YN) = 'N'   ");
		sql.append("	 AND B.IPWON_TYPE IN ('0', '1')                                            ");
		sql.append("	 AND C.BUNHO               = B.BUNHO                                       ");
		sql.append("	 AND D.HANGMOG_CODE        = A.HANGMOG_CODE                                ");
		sql.append("	 AND A.RESER_DATE BETWEEN D.START_DATE AND D.END_DATE                      ");
		sql.append("	ORDER BY B.KAIKEI_HOCODE, B.BUNHO                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdSusulInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdSusulInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdSusulInfo> getNUR5020U00grdSusulInfoCase2(String hospCode, String language, String hoDong,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_WRDT                                                        ");
		sql.append("	     , A.DETAIL_GUBUN                                                    ");
		sql.append("	     , A.GWA                                                             ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NUR_WRDT, :f_hosp_code, :f_language)");
		sql.append("	     , A.HO_DONG                                                         ");
		sql.append("	     , A.HO_CODE                                                         ");
		sql.append("	     , A.BUNHO                                                           ");
		sql.append("	     , FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                         ");
		sql.append("	     , FN_OCS_LOAD_AGE(:f_hosp_code, A.BUNHO, SYSDATE())                 ");
		sql.append("	     , B.SEX                                                             ");
		sql.append("	     , A.SANG                                                            ");
		sql.append("	     , A.SULSIK                                                          ");
		sql.append("	     , IFNULL(A.COMMENT1, '')                                            ");
		sql.append("	     , IFNULL(A.COMMENT2, '')                                            ");
		sql.append("	     , IFNULL(A.COMMENT3, '')                                            ");
		sql.append("	  FROM NUR5024 A                                                         ");
		sql.append("	     , OUT0101 B                                                         ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                        ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                         ");
		sql.append("	   AND B.BUNHO     = A.BUNHO                                             ");
		sql.append("	   AND A.GUBUN     = '1'                                                 ");
		sql.append("	   AND A.NUR_WRDT  = :f_date                                             ");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong                                          ");
		sql.append("	 ORDER BY A.HO_CODE, A.BUNHO                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdSusulInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdSusulInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR5020U00grdTransInfo> getNUR5020U00grdTransInfoCase1(String hospCode, String language, String hoDong,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.START_DATE                                                                              ");
		sql.append("		 , CASE WHEN A.FROM_KAIKEI_HODONG = :f_ho_dong THEN                                          ");
		sql.append("					 A.FROM_KAIKEI_HODONG                                                            ");
		sql.append("		   ELSE A.TO_KAIKEI_HODONG        END       HO_DONG                                          ");
		sql.append("		 , '01'                                                                                      ");
		sql.append("		 , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', '01', :f_hosp_code, :f_language)                   ");
		sql.append("		 , A.BUNHO                                                                                   ");
		sql.append("		 , C.SUNAME                                                                                  ");
		sql.append("		 , A.FROM_GWA                                                                                ");
		sql.append("		 , A.TO_GWA                                                                                  ");
		sql.append("		 , A.FROM_KAIKEI_HOCODE                                                                      ");
		sql.append("		 , A.TO_KAIKEI_HOCODE                                                                        ");
		sql.append("		 , FN_BAS_LOAD_GWA_NAME(A.FROM_GWA, A.START_DATE, :f_hosp_code, :f_language)                 ");
		sql.append("		 , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.START_DATE, :f_hosp_code, :f_language)                   ");
		sql.append("	  FROM OUT0101 C                                                                                 ");
		sql.append("		 , INP1001 B                                                                                 ");
		sql.append("		 , INP2004 A                                                                                 ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                 ");
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE                                                                 ");
		sql.append("	   AND A.FKINP1001 = B.PKINP1001                                                                 ");
		sql.append("	   AND A.BUNHO NOT LIKE '5%'                                                                     ");
		sql.append("	   AND A.BUNHO     = C.BUNHO                                                                     ");
		sql.append("	   AND A.BUNHO     = B.BUNHO                                                                     ");
		sql.append("	   AND A.FROM_GWA <> A.TO_GWA                                                                    ");
		sql.append("	   AND A.START_DATE = :f_date                                                                    ");
		sql.append("	   AND (  A.FROM_KAIKEI_HODONG = :f_ho_dong                                                      ");
		sql.append("		   OR A.TO_KAIKEI_HODONG   = :f_ho_dong)                                                     ");
		sql.append("	UNION                                                                                            ");
		sql.append("	SELECT A.START_DATE                                                                              ");
		sql.append("		 , CASE WHEN A.FROM_KAIKEI_HODONG = :f_ho_dong THEN                                          ");
		sql.append("					 A.FROM_KAIKEI_HODONG                                                            ");
		sql.append("		   ELSE A.TO_KAIKEI_HODONG        END       HO_DONG                                          ");
		sql.append("		 , '02'                                                                                      ");
		sql.append("		 , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', '02', :f_hosp_code, :f_language)                   ");
		sql.append("		 , A.BUNHO                                                                                   ");
		sql.append("		 , C.SUNAME                                                                                  ");
		sql.append("		 , A.FROM_GWA                                                                                ");
		sql.append("		 , A.TO_GWA                                                                                  ");
		sql.append("		 , A.FROM_KAIKEI_HOCODE                                                                      ");
		sql.append("		 , A.TO_KAIKEI_HOCODE                                                                        ");
		sql.append("		 , ''                                                                                        ");
		sql.append("		 , ''                                                                                        ");
		sql.append("	  FROM OUT0101 C                                                                                 ");
		sql.append("		 , INP1001 B                                                                                 ");
		sql.append("		 , INP2004 A                                                                                 ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                 ");
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE                                                                 ");
		sql.append("	   AND A.FKINP1001 = B.PKINP1001                                                                 ");
		sql.append("	   AND A.BUNHO NOT LIKE '5%'                                                                     ");
		sql.append("	   AND A.BUNHO     = C.BUNHO                                                                     ");
		sql.append("	   AND A.BUNHO     = B.BUNHO                                                                     ");
		sql.append("	   AND A.FROM_KAIKEI_HOCODE <> A.TO_KAIKEI_HOCODE                                                ");
		sql.append("	   AND A.START_DATE = :f_date                                                                    ");
		sql.append("	   AND (  A.FROM_KAIKEI_HODONG = :f_ho_dong                                                      ");
		sql.append("		   OR A.TO_KAIKEI_HODONG   = :f_ho_dong)                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdTransInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdTransInfo.class);
		return listInfo;
	}
	
	@Override
	public List<NUR5020U00grdTransInfo> getNUR5020U00grdTransInfoCase2(String hospCode, String language, String hoDong,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  PKNUR5023                                                                        ");
		sql.append("	     , A.NUR_WRDT                                                                        ");
		sql.append("	     , A.HO_DONG                                                                         ");
		sql.append("	     , A.DETAIL_GUBUN                                                                    ");
		sql.append("	     , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', A.DETAIL_GUBUN, :f_hosp_code, :f_language) ");
		sql.append("	     , A.BUNHO                                                                           ");
		sql.append("	     , FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                                         ");
		sql.append("	     , A.FROM_GWA                                                                        ");
		sql.append("	     , A.TO_GWA                                                                          ");
		sql.append("	     , A.FROM_HO_CODE                                                                    ");
		sql.append("	     , A.TO_HO_CODE                                                                      ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.FROM_GWA, A.NUR_WRDT, :f_hosp_code, :f_language)           ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.NUR_WRDT, :f_hosp_code, :f_language)             ");
		sql.append("	     , FN_OCS_LOAD_AGE(:f_hosp_code, A.BUNHO, A.NUR_WRDT)                                ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_SEX(A.BUNHO), '')                                              ");
		sql.append("	  FROM NUR5023 A                                                                         ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                        ");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong                                                          ");
		sql.append("	   AND A.NUR_WRDT  = :f_date                                                             ");
		sql.append("	   AND A.GUBUN     = '3'                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", fDate);
		
		List<NUR5020U00grdTransInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdTransInfo.class);
		return listInfo;
	}
}

