package nta.med.data.dao.medi.inp.impl;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1003RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0250Q00layReserBedInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP1003Q00grdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtReserInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserInfo;
import nta.med.data.model.ihis.inps.INP1003U01grdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U01layDeleteInfo;
import nta.med.data.model.ihis.inps.INP1003U01layIpWonInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonReserInfo;

/**
 * @author dainguyen.
 */
public class Inp1003RepositoryImpl implements Inp1003RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public PrOcsLoadIpwonReserInfo getPrOcsLoadIpwonReserInfo(String hospCode, String language, Date reserDate, Double naewonKey){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_LOAD_IPWON_RESER_INFO");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_FKINP1001", Double.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_RESER_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GWA", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PARENT_GWA", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DOCTOR", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_RESER_DATE", reserDate);
		query.setParameter("I_RESER_FKINP1001", naewonKey);
		
		query.execute();
		PrOcsLoadIpwonReserInfo result = new PrOcsLoadIpwonReserInfo((Date)query.getOutputParameterValue("IO_RESER_DATE")
				, (String)query.getOutputParameterValue("IO_GWA")
				, (String)query.getOutputParameterValue("IO_PARENT_GWA")
				, (String)query.getOutputParameterValue("IO_DOCTOR")
				, (String)query.getOutputParameterValue("IO_FLAG"));
		
		return result;
	}
	
	@Override
	public String getAbleInsteadOrder(String hospCode, String bunho, Date naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCSO_IS_ABLE_INSTEAD_ORDER(:f_hosp_code,:f_bunho,:f_naewon_date) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	public String getYInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y' 					    ");
		sql.append("	 FROM DUAL                      ");
		sql.append("	WHERE EXISTS ( SELECT 'X'       ");
		sql.append("	FROM INP1003                    ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("	  AND BUNHO = :f_bunho          ");
		sql.append("	  AND RESER_END_TYPE = '0' )    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	public String getYInfoWhereReserDate(String hospCode, String bunho, Date reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'												   ");
		sql.append("	FROM DUAL                                                  ");
		sql.append("	WHERE EXISTS ( SELECT 'X'                                  ");
		sql.append("	 FROM INP1003 A                                            ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("	AND A.BUNHO     = :f_bunho                                 ");
		sql.append("	  AND A.RESER_DATE = DATE_FORMAT(:f_reser_date,'%Y/%m/%d') ");
		sql.append("	  AND A.RESER_END_TYPE = '0' )                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	public String getYWherePkinp1003 (String hospCode, String bunho, Date reserDate, double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'													     ");
		sql.append("	 FROM DUAL                                                       ");
		sql.append("	WHERE EXISTS ( SELECT 'X'                                        ");
		sql.append("	       FROM INP1003 A                                            ");
		sql.append("	      WHERE A.HOSP_CODE  = :f_hosp_code                          ");
		sql.append("	AND A.BUNHO      = :f_bunho                                      ");
		sql.append("	        AND A.RESER_DATE = DATE_FORMAT(:f_reser_date,'%Y/%m/%d') ");
		sql.append("	        AND A.RESER_END_TYPE = '0'                               ");
		sql.append("	        AND A.PKINP1003 != :f_pkinp1003 )                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String checkExistOrderInp1003ByHospCodeBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'																				");
		sql.append("	FROM DUAL																				");
		sql.append("	WHERE EXISTS (SELECT 'X'																");
		sql.append("	      			  FROM INP1003 A														");
		sql.append("	      			 WHERE A.HOSP_CODE      = :f_hosp_code 									");
		sql.append("	      			   AND A.BUNHO          = :f_bunho										");
		sql.append("	      			   AND A.RESER_END_TYPE = '0'											");
		sql.append("	      			   AND A.RESER_DATE     >=  DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)	");
		sql.append("	      			   AND A.RESER_FKINP1001 IS NOT NULL)									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> listResult = query.getResultList();
		return CollectionUtils.isEmpty(listResult) ? "" : listResult.get(0);
	}
	
	public List<INP1003U01grdINP1003Info> getINP1003U01grdINP1003Info(String hospCode, String bunho, String language, Integer offset, Integer startNum){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT IFNULL(DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'),'')													");
		sql.append("          , A.BUNHO																								");
		sql.append("          , B.SUNAME																							");
		sql.append("          , A.GWA																								");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE, A.HOSP_CODE, :f_language)         GWA_NAME				");
		sql.append("          , A.DOCTOR																							");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.RESER_DATE, A.HOSP_CODE), '')    DOCTOR_NAME				");
		sql.append("          , A.TEL1																								");
		sql.append("          , A.TEL2																								");
		sql.append("          , A.RESER_FKINP1001																					");
		sql.append("          , A.PKINP1003																							");
		sql.append("          , IFNULL(A.REMARK, '')																				");
		sql.append("          , IFNULL(A.IPWON_MOKJUK, '')																			");
		sql.append("          , A.IPWONSI_ORDER_YN																					");
		sql.append("          , IFNULL(A.SANG_BIGO, '')																				");
		sql.append("          , A.JISI_DOCTOR																						");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.JISI_DOCTOR, A.RESER_DATE, A.HOSP_CODE), '') JISI_DOCTOR_NAME		");
		sql.append("          , B.SEX																								");
		sql.append("          , IFNULL(A.HO_DONG, '')																				");
		sql.append("          , IFNULL(FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG, A.RESER_DATE, A.HOSP_CODE, :f_language), '') HO_DONG_NAME");
		sql.append("          , IFNULL(A.HO_CODE, '')																				");
		sql.append("          , IFNULL(A.BED_NO, '')																				");
		sql.append("          , 'Y'                                                  RESER_YN										");
		sql.append("          , IFNULL((SELECT 'Y' FROM DUAL 																		");
		sql.append("              WHERE EXISTS( SELECT 'X' FROM DOC1001 Z 															");
		sql.append("                             WHERE Z.HOSP_CODE = A.HOSP_CODE 													");
		sql.append("                               AND Z.FKINP1001 = A.RESER_FKINP1001												");
		sql.append("                               AND Z.CERT_JNCD = '010')), '')    DOC_YN											");
		sql.append("          , A.EMERGENCY_GUBUN																					");
		sql.append("          , IFNULL(A.EMERGENCY_DETAIL, '')																		");
		sql.append("          , '' DATA_ROWSTATE																					");
		sql.append("       FROM OUT0101 B																							");
		sql.append("          , INP1003 A																							");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																		");
		sql.append("        AND A.BUNHO          = :f_bunho																			");
		sql.append("        AND A.RESER_END_TYPE = '0'  																			");
		sql.append("        AND B.HOSP_CODE      = A.HOSP_CODE																		");
		sql.append("        AND B.BUNHO          = A.BUNHO																			");
		sql.append("      ORDER BY A.RESER_DATE DESC																				");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1003U01grdINP1003Info> list = new JpaResultMapper().list(query, INP1003U01grdINP1003Info.class);
		return list;
	}
	
	public Integer updateINP1003U01CancelReser(String hospCode, Double pkinp1003, String ipwonsiOrderYn){
		StringBuilder sql = new StringBuilder();
		
		if(ipwonsiOrderYn.equals("Y")){
			sql.append("     UPDATE INP1003 A									");
			sql.append("        SET A.RESER_END_TYPE = '5'						");
			sql.append("          , A.RESER_END_DATE = SYSDATE()				");
			sql.append("      WHERE A.HOSP_CODE = :f_hosp_code					");
			sql.append("        AND A.PKINP1003 = :f_pkinp1003					");
		}else{
			sql.append("     UPDATE INP1003 A									");
			sql.append("        SET A.RESER_FKINP1001 = NULL					");
			sql.append("      WHERE A.HOSP_CODE = :f_hosp_code					");
			sql.append("        AND A.PKINP1003 = :f_pkinp1003					");
		}
				
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		return query.executeUpdate();
	}
	
	@Override
	public String getExsitINP1003U01SaveLayout(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT 'Y'																");
		sql.append("       FROM DUAL															");
		sql.append("      WHERE EXISTS ( SELECT 'X'												");
		sql.append("                       FROM INP1003 A										");
		sql.append("                      WHERE A.HOSP_CODE      = :f_hosp_code					");
		sql.append("                        AND A.BUNHO          = :f_bunho						");
		sql.append("                        AND A.RESER_END_TYPE = '0' )						");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public void prOcsInitCreateSiksa(String hospCode, Double pkinp1001, String bunho, String inpwonDate, String gubun, String language){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_INIT_CREATE_SIKSA");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKINP1001", pkinp1001);
		query.setParameter("I_BUNHO", CommonUtils.parseInteger(bunho));
		query.setParameter("I_IPWON_DATE", DateUtil.toDate(inpwonDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_IUD_GUBUN", gubun);
		query.setParameter("I_LANGUAGE", language);
		
		query.execute();		
		
	}
	
	@Override
	public String checkExistReser(String hospCode, Double pkinp1003, Date reserDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT CONCAT(RESER_FKINP1001, '@',														");
		sql.append("            CASE WHEN A.RESER_DATE = :f_reser_date THEN 'Y'	   	    							");
		sql.append("                                                   ELSE 'N' 									");
		sql.append("            END) RESULT       																	");
		sql.append("       FROM INP1003 A																			");
		sql.append("       WHERE A.HOSP_CODE       = :f_hosp_code													");
		sql.append("         AND A.PKINP1003       = :f_pkinp1003													");
		sql.append("         AND A.RESER_END_TYPE  = '0' /* 予約中、예약중 */											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1003", pkinp1003);
		query.setParameter("f_reser_date", reserDate);
		
		List<String> list = query.getResultList();
		if(CollectionUtils.isEmpty(list) || list.size() == 0){
			return "2";
		}else{
			String str[] = list.get(0).split("@");
			if(str[0] == ""){
				if(str[1].equals("Y"))
					return "1";
				else
					return "2";
			}else{
				if(str[1].equals("Y"))
					return "3";
				else
					return "4";
			}
		}		
	}
	
	@Override
	public Integer Inp1003U01UpdateInp1003(String userId, Double reserFkinp1001, String remark, String sangBigo, String emerGugun
			, String emerDetail, String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE INP1003													");
		sql.append("        SET UPD_DATE          = SYSDATE()							");
		sql.append("          , UPD_ID            = :f_user_id							");
		sql.append("          , IPWON_MOKJUK      = '17'								");
		sql.append("          , RESER_FKINP1001   = :f_reser_fkinp1001					");
		sql.append("          , REMARK            = :f_remark							");
		sql.append("          , SANG_BIGO         = :f_sang_bigo						");
		sql.append("          , IPWONSI_ORDER_YN  = 'Y'									");
		sql.append("          , EMERGENCY_GUBUN   = :f_emergency_gubun					");
		sql.append("          , EMERGENCY_DETAIL  = :f_emergency_detail					");
		sql.append("       WHERE HOSP_CODE        = :f_hosp_code						");
		sql.append("       AND PKINP1003          = :f_pkinp1003						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_reser_fkinp1001", reserFkinp1001);
		query.setParameter("f_remark", remark);
		query.setParameter("f_sang_bigo", sangBigo);
		query.setParameter("f_emergency_gubun", emerGugun);
		query.setParameter("f_emergency_detail", emerDetail);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer Inp1003UpdateInp1003(String userId, String doctor, String remark, String jisiDoctor, String sangBigo,
			String hoDong, String hoCode, String bedNo, String emerGubun, String emerDetail, String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE INP1003														");
		sql.append("        SET UPD_DATE           = SYSDATE()								");
		sql.append("          , UPD_ID             = :f_user_id								");
		sql.append("          , DOCTOR             = :f_doctor								");
		sql.append("          , REMARK             = :f_remark								");
		sql.append("          , JISI_DOCTOR        = :f_jisi_doctor							");
		sql.append("          , SANG_BIGO          = :f_sang_bigo							");
		sql.append("          , HO_DONG            = :f_ho_dong								");
		sql.append("          , HO_CODE            = :f_ho_code								");
		sql.append("          , BED_NO             = :f_bed_no								");
		sql.append("          , EMERGENCY_GUBUN    = :f_emergency_gubun						");
		sql.append("          , EMERGENCY_DETAIL   = :f_emergency_detail					");
		sql.append("      WHERE HOSP_CODE          = :f_hosp_code							");
		sql.append("        AND PKINP1003          = :f_pkinp1003							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_remark", remark);
		query.setParameter("f_jisi_doctor", jisiDoctor);
		query.setParameter("f_sang_bigo", sangBigo);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_emergency_gubun", emerGubun);
		query.setParameter("f_emergency_detail", emerDetail);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer Inp1003U01UpdateReserEndDate(String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE INP1003 A														");
		sql.append("        SET A.RESER_END_TYPE = '5'   /* 予約取り消し、예약 취소 */					");
		sql.append("          , A.RESER_END_DATE = SYSDATE()									");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code									");
		sql.append("        AND A.PKINP1003      = :f_pkinp1003									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1003", pkinp1003);
		return query.executeUpdate();
	}
	
	@Override
	public ComboListItemInfo prcOcsAlterReserInpwonDate(String hospCode, String bunho, Double fkinp1001, Date reserDateOld, Date reserDate, String userId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_ALTER_RESER_INPWON_DATE");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_OLD_PLAN_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NEW_PLAN_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_BUNHO", CommonUtils.parseInteger(bunho));
		query.setParameter("I_OLD_PLAN_DATE", reserDateOld);
		query.setParameter("I_NEW_PLAN_DATE", reserDate);
		query.setParameter("I_USER_ID", userId);
		
		query.execute();
		ComboListItemInfo result = new ComboListItemInfo((String)query.getOutputParameterValue("IO_MSG"),
				(String)query.getOutputParameterValue("IO_FLAG"));
		return result;
	}
	
	@Override
	public Integer Inp1003UpdateInp1003(String userId, String doctor, String gwa, Date reserDate, String remark, String jisiDoctor, String sangBigo,
			String hoDong, String hoCode, String bedNo, String emerGubun, String emerDetail, String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE INP1003 A												");
		sql.append("        SET A.UPD_ID         = :f_user_id							");
		sql.append("          , A.UPD_DATE       = SYSDATE()							");
		sql.append("          , A.GWA            = :f_gwa								");
		sql.append("          , A.DOCTOR         = :f_doctor							");
		sql.append("          , A.RESER_DATE     = :f_reser_date						");
		sql.append("          , A.REMARK         = :f_remark							");
		sql.append("          , A.JISI_DOCTOR    = :f_jisi_doctor						");
		sql.append("          , A.SANG_BIGO      = :f_sang_bigo							");
		sql.append("          , HO_DONG          = :f_ho_dong							");
		sql.append("          , HO_CODE          = :f_ho_code							");
		sql.append("          , BED_NO           = :f_bed_no							");
		sql.append("          , EMERGENCY_GUBUN  = :f_emergency_gubun					");
		sql.append("          , EMERGENCY_DETAIL = :f_emergency_detail					");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code							");
		sql.append("        AND A.PKINP1003      = :f_pkinp1003							");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_remark", remark);
		query.setParameter("f_jisi_doctor", jisiDoctor);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_emergency_gubun", emerGubun);
		query.setParameter("f_emergency_detail", emerDetail);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		return query.executeUpdate();
	}
	
	@Override
	public List<INP1003U01layDeleteInfo> getINP1003U01layDeleteInfo(String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.BUNHO											");
		sql.append("          , A.RESER_FKINP1001								");
		sql.append("          , DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d')			");
		sql.append("       FROM INP1003 A										");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("        AND A.PKINP1003 = :f_pkinp1003						");
		sql.append("        AND A.RESER_END_TYPE = '0'							");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		List<INP1003U01layDeleteInfo> list = new JpaResultMapper().list(query, INP1003U01layDeleteInfo.class);
		return list;
	}
	
	@Override
	public List<INP1003U01layIpWonInfo> getINP1003U01layIpWonInfo(String hospCode, Double pkinp1003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.IPWON_MOKJUK									");
		sql.append("          , A.IPWONSI_ORDER_YN								");
		sql.append("       FROM INP1003 A										");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("        AND A.PKINP1003 = :f_pkinp1003						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		List<INP1003U01layIpWonInfo> list = new JpaResultMapper().list(query, INP1003U01layIpWonInfo.class);
		return list;
	}
	
	@Override
	public List<DataStringListItemInfo> prcINP1003U01Procedure(String hospCode, String bunho, String fkinp1001, Date ipwonDate, String gubun,
			String userId, String ipwonType, String nameControl){
		List<DataStringListItemInfo> result = new ArrayList<DataStringListItemInfo>() ;
//		if (nameControl.equals("CancelReserVation")){
//			StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DELETE_INP_ORDER_RES");
//			
//			query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
//			query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
//			query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
//			query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
//			query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
//			query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
//			
//			query.setParameter("I_INPUT_ID", userId);
//			query.setParameter("I_BUNHO", bunho);
//			query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
//			query.setParameter("I_HOSP_CODE", hospCode);
//			
//			query.execute();
//			result.add(new DataStringListItemInfo((String)query.getOutputParameterValue("IO_ERR_MSG")));
//			result.add(new DataStringListItemInfo((String)query.getOutputParameterValue("IO_ERR")));
//			
//			return result;
//		}else{
			StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_LOAD_JAEWON_PKINP1001");
			
			query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
			query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
			query.registerStoredProcedureParameter("I_IPWON_DATE", Date.class, ParameterMode.IN);
			query.registerStoredProcedureParameter("I_IPWON_TYPE", String.class, ParameterMode.IN);
			query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
			query.registerStoredProcedureParameter("IO_PKINP1001", Integer.class, ParameterMode.INOUT);
			query.registerStoredProcedureParameter("IO_JAEWON_FLAG", String.class, ParameterMode.INOUT);
			query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
			
			query.setParameter("I_GUBUN", gubun);
			query.setParameter("I_BUNHO", bunho);
			query.setParameter("I_IPWON_DATE", ipwonDate);
			query.setParameter("I_IPWON_TYPE", ipwonType);
			query.setParameter("I_HOSP_CODE", hospCode);
			
			query.execute();
			if((Integer)query.getOutputParameterValue("IO_PKINP1001") == null){
				result.add(new DataStringListItemInfo("-1"));
			}else{
				result.add(new DataStringListItemInfo(CommonUtils.parseString((Integer)query.getOutputParameterValue("IO_PKINP1001"))));
			}
			result.add(new DataStringListItemInfo((String)query.getOutputParameterValue("IO_JAEWON_FLAG")));
			result.add(new DataStringListItemInfo((String)query.getOutputParameterValue("IO_FLAG")));
			
			return result;
//		}
	}
	
	@Override
	public ComboListItemInfo prcINP1003U01ProcedureDelete(String hospCode, String bunho, String fkinp1001, Date ipwonDate, String gubun,
			String userId, String ipwonType, String nameControl){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DELETE_INP_ORDER_RES");
		
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_INPUT_ID", userId);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("I_HOSP_CODE", hospCode);
		
		query.execute();
		ComboListItemInfo result = new ComboListItemInfo((String)query.getOutputParameterValue("IO_ERR_MSG"),
				(String)query.getOutputParameterValue("IO_ERR"));
		return result;
	}
	
	@Override
	public List<INP1003U00grdInpReserInfo> getINP1003U00grdInpReser(String hospCode, String language, String reserDate, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                   																					");
		sql.append("     	DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'),																	");
		sql.append("       	A.BUNHO,                   																				");
		sql.append("       	IFNULL(B.SUNAME, ''),																					");
		sql.append("       	A.GWA,                   																				");
		sql.append("       	FN_BAS_LOAD_GWA_NAME (A.GWA, A.RESER_DATE, :f_hosp_code, :f_language) 	GWA_NAME,      					");
		sql.append("       	IFNULL(A.HO_CODE, ''),                   																");
		sql.append("       	A.DOCTOR,                   																			");
		sql.append("        IFNULL(FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.RESER_DATE, :f_hosp_code), '')   		DOCTOR_NAME,		");
		sql.append("        A.IPWON_RTN2,                   																		");
		sql.append("        C.CODE_NAME                                      						PWON_RTN2_NAME,         		");
		sql.append("        A.TEL1,                   																				");
		sql.append("        A.TEL2,                   																				");
		sql.append("        A.RESER_END_TYPE,                   																	");
		sql.append("        A.SUSUL_RESER_YN,                                                                                 	  	");
		sql.append("        IFNULL(A.REMARK, ''),                   																");
		sql.append("        CAST(A.PKINP1003 AS CHAR),                   															");
		sql.append("        DATE_FORMAT(A.JUNPYO_DATE, '%Y/%m/%d'),                   												");
		sql.append("        IFNULL(A.HO_DONG, ''),                   																");
		sql.append("        IFNULL(A.BED_NO, ''),                                                                    				");
		sql.append("        IFNULL(A.IPWON_MOKJUK, ''),                   															");
		sql.append("        CAST(A.RESER_FKINP1001 AS CHAR),                   														");
		sql.append("        A.IPWONSI_ORDER_YN,                    																	");
		sql.append("        A.JISI_DOCTOR,                                                                                     	 	");
		sql.append("        IFNULL(FN_BAS_LOAD_DOCTOR_NAME (A.JISI_DOCTOR, A.RESER_DATE, :f_hosp_code), '') 	JISI_DOCTOR_NAME,   ");
		sql.append("        IFNULL(A.SANG_BIGO, ''),                                                                                ");
		sql.append("        IFNULL(A.SOGYE_YN, 0),                                                                              	");
		sql.append("        IFNULL(A.HOPE_ROOM, ' '),                                                                          		");
		sql.append("        FN_ADM_USER_NM (:f_hosp_code, A.SYS_ID)                   												");
		sql.append("     FROM                   																					");
		sql.append("     	INP1003 A 	LEFT JOIN OUT0101 	B                   													");
		sql.append("     				ON					A.HOSP_CODE 	= B.HOSP_CODE                   						");
		sql.append("     				AND					A.BUNHO 		= B.BUNHO                   							");
		sql.append("     				LEFT JOIN BAS0102 	C                   													");
		sql.append("     				ON					A.HOSP_CODE 	= C.HOSP_CODE                   						");
		sql.append("     				AND					A.IPWON_RTN2 	= C.CODE                   								");
		sql.append("                          																						");
		sql.append("     WHERE                   																					");
		sql.append("     	A.HOSP_CODE       					= :f_hosp_code                   									");
		sql.append("       	AND A.RESER_DATE     				>= STR_TO_DATE(:f_reser_date, '%Y/%m/%d')                   		");
		sql.append("       	AND A.RESER_END_TYPE 				!= '5'                   											");
		sql.append("       	AND C.CODE_TYPE    					= 'IPWON_RTN2'                   									");
		sql.append("       	AND IFNULL(A.HO_DONG, '%') 			LIKE :f_ho_dong                   									");
		sql.append("     ORDER BY                   																				");
		sql.append("     	RESER_DATE                   																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language",  language);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_ho_dong", hoDong + "%");
		
		List<INP1003U00grdInpReserInfo> listInfo = new JpaResultMapper().list(query, INP1003U00grdInpReserInfo.class);
		return listInfo;
	}

	@Override
	public List<INP1003U00grdInpReserGridColumnChangeddtReserInfo> getINP1003U00grdInpReserGridColumnChangeddtReserInfo(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT                    								");
		sql.append("    	'Y'                     							");
		sql.append("    FROM DUAL                    							");
		sql.append("    WHERE                    								");
		sql.append("    	EXISTS (                    						");
		sql.append("    		SELECT                    						");
		sql.append("    			'X'                    						");
		sql.append("    		FROM                    						");
		sql.append("    			INP1003                    					");
		sql.append("    		WHERE                    						");
		sql.append("    			HOSP_CODE 			= :f_hosp_code          ");
		sql.append("    			AND BUNHO 			= :f_bunho              ");
		sql.append("    			AND RESER_END_TYPE 	= '0' )                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho",  bunho);
		
		List<INP1003U00grdInpReserGridColumnChangeddtReserInfo> listInfo = new JpaResultMapper().list(query, INP1003U00grdInpReserGridColumnChangeddtReserInfo.class);
		return listInfo;
	}
	
	public List<INP1003Q00grdINP1003Info> getINP1003Q00grdINP1003Info(String hospCode, String language, String reserEndType, String reserDate
			, String hoDong, Integer offset, Integer startNum){
		StringBuilder sql = new StringBuilder();
		sql.append("      SELECT  A.BUNHO																					");
		sql.append("           , IFNULL(B.SUNAME, '')																		");
		sql.append("           , A.RESER_DATE																				");
		sql.append("           , A.TEL2																						");
		sql.append("           , A.GWA																						");
		sql.append("           , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE, A.HOSP_CODE, :f_language) GWA_NAME				");
		sql.append("           , A.DOCTOR																					");
		sql.append("           , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.RESER_DATE, A.HOSP_CODE), '') DOCTOR_NAME		");
		sql.append("           , A.RESER_END_TYPE																			");
		sql.append("           , A.RESER_FKINP1001																			");
		sql.append("           , IFNULL(A.SANG_BIGO, '')																	");
		sql.append("           , IFNULL(CONCAT(FN_BAS_LOAD_GWA_NAME (A.HO_DONG, A.RESER_DATE, A.HOSP_CODE, :f_language ), 	");
		sql.append("                ' ', (CASE A.HO_CODE WHEN '' THEN ''  ELSE FN_ADM_MSG('4293', :f_language) END)			");
		sql.append("                 , ' ', A.BED_NO), '') AS BED_NO														");
		sql.append("           , TRIM(FN_BAS_LOAD_AGE (SYSDATE(), B.BIRTH, 'XXXX')) AGE										");
		sql.append("           , IFNULL(A.IPWON_MOKJUK, '')																	");
		sql.append("           , A.IPWON_RTN2																				");
		sql.append("           , IFNULL(A.SOGYE_YN, '')																		");
		sql.append("           , IFNULL(A.HOPE_ROOM, '')																	");
		sql.append("           , IFNULL(A.REMARK, '')																		");
		sql.append("           , FN_ADM_USER_NM (A.HOSP_CODE, A.UPD_ID )													");
		sql.append("       FROM INP1003 A																					");
		sql.append("       LEFT JOIN OUT0101 B																				");
		sql.append("              ON B.HOSP_CODE       = A.HOSP_CODE														");
		sql.append("             AND B.BUNHO           = A.BUNHO															");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code														");
		sql.append("        AND A.RESER_END_TYPE       LIKE :f_reser_end_type												");
		sql.append("        AND A.RESER_DATE           = :f_reser_date 														");
		sql.append("        AND (CASE (IFNULL(A.HO_DONG, '%')) WHEN '%' THEN '%'											");
		sql.append("             ELSE A.HO_DONG END)   LIKE :f_ho_dong														");
		sql.append("      ORDER BY A.RESER_DATE																				");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																			");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_reser_date", DateUtil.toDate(reserDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_reser_end_type", reserEndType);
		query.setParameter("f_ho_dong", hoDong);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1003Q00grdINP1003Info> list = new JpaResultMapper().list(query, INP1003Q00grdINP1003Info.class);
		return list;
	}

	@Override
	public String getINP1003U00YByReserDate(String hospCode, String bunho, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT  																				");
		sql.append("    	'Y'  																				");
		sql.append("    FROM  																					");
		sql.append("    	DUAL  																				");
		sql.append("    WHERE  																					");
		sql.append("    	EXISTS (  																			");
		sql.append("    		SELECT  																		");
		sql.append("    			'X'  																		");
		sql.append("    		FROM  																			");
		sql.append("    			INP1003 A  																	");
		sql.append("    		WHERE  																			");
		sql.append("    			A.HOSP_CODE 			= :f_hosp_code  									");
		sql.append("    			AND A.BUNHO     		= :f_bunho  										");
		sql.append("    			AND A.RESER_DATE 		= STR_TO_DATE(:f_reser_date, '%Y/%m/%d')  			");
		sql.append("    			AND A.RESER_END_TYPE 	= '0')  											");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		
		return "";
	}

	@Override
	public String getINP1003U00YByReserEndType(String hospCode, String bunho, String reserDate, Double pkinp1003) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT																					");
		sql.append("    	'Y'																					");
		sql.append("    FROM																					");
		sql.append("    	DUAL																				");
		sql.append("    WHERE																					");
		sql.append("    	EXISTS (																			");
		sql.append("    		SELECT 'X'																		");
		sql.append("    		FROM																			");
		sql.append("    			INP1003 A																	");
		sql.append("    		WHERE																			");
		sql.append("    			A.HOSP_CODE  			= :f_hosp_code										");
		sql.append("    			AND A.BUNHO      		= :f_bunho											");
		sql.append("    			AND A.RESER_DATE 		= STR_TO_DATE(:f_reser_date, '%Y/%m/%d')			");
		sql.append("    			AND A.RESER_END_TYPE 	= '0'												");
		sql.append("    			AND A.PKINP1003 		<> :f_pkinp1003)									");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_pkinp1003", pkinp1003);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		
		return "";
	}
	
	@Override
	public String inp1001U01CheckIsExist(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'														");
		sql.append("       FROM DUAL													");
		sql.append("      WHERE EXISTS ( SELECT 'X										");
		sql.append("               FROM INP1003 A										");
		sql.append("              WHERE A.HOSP_CODE        = :f_hosp_code				");
		sql.append("                AND A.BUNHO            = :f_bunho					");
		sql.append("                AND A.RESER_END_TYPE   = '0'						");
		sql.append("                AND A.RESER_FKINP1001  IS NOT NULL)					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<BAS0250Q00layReserBedInfo> getBAS0250Q00layReserBedInfoList(String hospCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.HO_DONG            HO_DONG                               										    ");
		sql.append("     , A.HO_CODE            HO_CODE                               										    ");
		sql.append("     , A.BED_NO     		 BED_NO                                 										");
		sql.append("     , B.SUNAME              SUNAME   						        										");
		sql.append("     , IF(A.RESER_DATE IS NULL, '', DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'))       RESER_DATE                 ");
		sql.append(" FROM OUT0101 B , INP1003 A																				    ");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code 																			");
		sql.append("  AND B.HOSP_CODE  = A.HOSP_CODE																			");
		sql.append("  AND A.HO_DONG = :f_ho_dong																			        ");
		sql.append("  AND A.RESER_END_TYPE = '0'																			    ");
		sql.append("  AND A.BUNHO = B.BUNHO																			            ");
		sql.append("  ORDER BY A.HO_CODE, A.BED_NO																			    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<BAS0250Q00layReserBedInfo> lstResult = new JpaResultMapper().list(query, BAS0250Q00layReserBedInfo.class);
		return lstResult;
	}
	
	@Override
	public List<DataStringListItemInfo> OCS2005U02getReserFkInp1001(String hospCode, String bunho, String reserEndType){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(RESER_FKINP1001 AS CHAR)							");
		sql.append("       FROM INP1003													");
		sql.append("      WHERE BUNHO          = :f_bunho								");
		sql.append("        AND RESER_END_TYPE = :f_reser_end_type						");
		sql.append("        AND HOSP_CODE      = :f_hosp_code							");
		sql.append("      ORDER BY RESER_FKINP1001 DESC									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_end_type", reserEndType);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public List<DataStringListItemInfo> OCS2005U02getReserDate(String hospCode, String bunho, String reserEndType){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(RESER_DATE, '%Y/%m/%d')						");
		sql.append("       FROM INP1003													");
		sql.append("      WHERE BUNHO          = :f_bunho								");
		sql.append("        AND RESER_END_TYPE = :f_reser_end_type						");
		sql.append("        AND HOSP_CODE      = :f_hosp_code							");
		sql.append("      ORDER BY RESER_FKINP1001 DESC									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_end_type", reserEndType);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1001U00LayReserInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(A.RESER_FKINP1001 AS CHAR)             ");
		sql.append("        , DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d')       ");
		sql.append("     FROM INP1003 A                                   ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                  ");
		sql.append("      AND A.BUNHO     = :f_bunho                      ");
		sql.append("      AND A.RESER_END_TYPE = '0'                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}
}

