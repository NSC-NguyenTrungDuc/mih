package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1024RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS1024U00grdOCS1024Info;

/**
 * @author dainguyen.
 */
public class Ocs1024RepositoryImpl implements Ocs1024RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callFnOcsIsBroughtDrgYn(String hospCode, String bunho,
			Integer pkinp1001, String inputTab) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_OCS_IS_BROUGHT_DRG_YN(:hospCode, :bunho, :pkinp1001, :inputTab)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("pkinp1001", CommonUtils.parseDouble(CommonUtils.parseString(pkinp1001)));
		query.setParameter("inputTab", inputTab);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callFnOcsInsertBgtdrgYn(String hospCode, String bunho,
			Double pkocs1024, String suryang, String dv, String dvTime,
			String nalsu) {
StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_OCS_INSERT_BGTDRG_YN(:hospCode, :bunho, :pkocs1024, :suryang, :dv, :dvTime, :nalsu)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("pkocs1024", pkocs1024);
		query.setParameter("suryang", suryang);
		query.setParameter("dv", dv);
		query.setParameter("dvTime", dvTime);
		query.setParameter("nalsu", nalsu);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOCS1024U00btnListGrdOCS1024(String hospCode, String hangmogCode, Double fkInp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.TOTAL_SURYANG, B.CURRENT_SURYANG  ");
		sql.append("    FROM OCS2003 A                          ");
		sql.append("        ,OCS1024 B                          ");
		sql.append("   WHERE A.HOSP_CODE      = :f_hosp_code    ");
		sql.append("     AND A.HANGMOG_CODE   = :f_hangmog_code ");
		sql.append("     AND A.FKINP1001      = :f_fkinp1001    ");
		sql.append("     AND A.BROUGHT_DRG_YN = 'Y'             ");
		sql.append("     AND B.HOSP_CODE = A.HOSP_CODE          ");
		sql.append("     AND B.PKOCS1024 = A.PKOCS1024			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_fkinp1001", fkInp1001);
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<OCS1024U00grdOCS1024Info> getOCS1024U00grdOCS1024(String hospCode, String language, String genericYn,
			String bunho, String inputTab, Double fkinp1001,Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                     	BUNHO,        													                                    ");
		sql.append(" A.GWA                                                       			GWA,                                              													");
		sql.append(" A.PKOCS1024                                                 			PKOCS1024,                                  													    ");
		sql.append(" ''                                                        				GROUP_SER,                                                     										");
		sql.append(" A.SEQ                                                       			SEQ,                                                           										");
		sql.append(" A.HANGMOG_CODE                                              			HANGMOG_CODE,                                                                 						");
		sql.append(" CASE :generic_yn WHEN 'N' THEN B.HANGMOG_NAME ELSE CASE A.GENERAL_DISP_YN WHEN 'Y' THEN I.GENERIC_NAME ELSE B.HANGMOG_NAME END END 		HANGMOG_NAME,  					");
		sql.append(" ''                                             						SPECIMEN_CODE,                                                                    					");
		sql.append(" CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                              					");
		sql.append(" SURYANG,                                                                                                                                   								");
		sql.append(" A.ORD_DANUI                                                 			ORD_DANUI,                                                            								");
		sql.append(" FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language) 	ORD_DANUI_NAME,                                                       								");
		sql.append(" A.DV_TIME                                                   			DV_TIME,                                                              								");
		sql.append(" IFNULL(A.DV,0)                                              			DV,                                                                   								");
		sql.append(" ''                                              						DV_1,                                                                 								");
		sql.append(" ''                                              						DV_2,                                                                 								");
		sql.append(" ''                                              						DV_3,                                                                 								");
		sql.append(" ''                                              						DV_4,                                                                 								");
		sql.append(" A.NALSU                                                                NALSU,                                                                 								");
		sql.append(" ''                                                                     JUSA,                                                       										");
		sql.append(" A.BOGYONG_CODE                                                         BOGYONG_CODE,                                               										");
		sql.append(" ''                                                                     EMERGENCY,                                              											");
		sql.append(" ''                                                                     PAY,                                                    											");
		sql.append(" ''                                                                     FLUID_YN,                                               											");
		sql.append(" ''                                                                     TPN_YN,                                                 											");
		sql.append(" ''                                                                     ANTI_CANCER_YN,                                         											");
		sql.append(" ''                                                                     PORTABLE_YN,                                            											");
		sql.append(" ''                                                                     POWDER_YN,                                              											");
		sql.append(" ''                                                                     SPECIAL_YN,                                             											");
		sql.append(" ''                                                                     ACT_DOCTOR,                                             											");
		sql.append(" 'N'                                                                    MUHYO,                                                  											");
		sql.append(" ''                                                                     SYMYA,                                                  											");
		sql.append(" ''                                                                     SPECIAL_RATE,                                           											");
		sql.append(" ''                                                                     ACT_DOCTOR_NAME,                                        											");
		sql.append(" ''                                                                     PRN_YN,                                              												");
		sql.append(" ''                                                                     PREPARE_YN,                                          												");
		sql.append(" A.ORDER_GUBUN                                                          ORDER_GUBUN,                                         												");
		sql.append(" B.ORDER_GUBUN                                                          ORDER_GUBUN_BAS,                                     												");
		sql.append(" IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN',A.ORDER_GUBUN, :hosp_code, :language),'Etc')                                     												");
		sql.append(" ORDER_GUBUN_NAME,                                                                                                           												");
		sql.append(" ''                                                                     ORDER_REMARK,                                        												");
		sql.append(" ''                                                                     NURSE_REMARK,                                        												");
		sql.append(" ''                                                                     MIX_GROUP,                                           												");
		sql.append(" ''                                                                     WONYOI_ORDER_YN,                                     												");
		sql.append(" ''                                                                     WONNAE_SAYU_CODE,                                    												");
		sql.append(" B.INPUT_CONTROL                                                        INPUT_CONTROL,                                       												");
		sql.append(" B.SUGA_YN                                                              SUGA_YN,                                             												");
		sql.append(" B.JAERYO_YN                                                            JAERYO_YN,                                           												");
		sql.append(" ''                                                                     SPECIAL_CHECK,                                       												");
		sql.append(" ''                                                                     PRIS_NAME,                                           												");
		sql.append(" B.SLIP_CODE                                                            SLIP_CODE,                                           												");
		sql.append(" CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END EMERGENCY_CHECK   ,                           												");
		sql.append(" B.SPECIMEN_YN                                                          SPECIMEN_YN,                                         												");
		sql.append(" 'N'                                                                    MULTI_GUMSA_YN,                                      												");
		sql.append(" C.SPECIMEN_CR_YN                                                       SPECIMEN_CR_YN,                                      												");
		sql.append(" C.SURYANG_CR_YN                                                        SURYANG_CR_YN,                                       												");
		sql.append(" C.ORD_DANUI_CR_YN                                                      ORD_DANUI_CR_YN,                                     												");
		sql.append(" 'N'                                                                    DV_TIME_CR_YN,                                       												");
		sql.append(" C.DV_CR_YN                                                             DV_CR_YN,                                            												");
		sql.append(" C.NALSU_CR_YN                                                          NALSU_CR_YN,                                         												");
		sql.append(" C.JUSA_CR_YN                                                           JUSA_CR_YN,                                          												");
		sql.append(" C.BOGYONG_CODE_CR_YN                                                   BOGYONG_CODE_CR_YN,                                  												");
		sql.append(" C.TOIWON_DRG_CR_YN                                                     TOIWON_DRG_CR_YN,                                    												");
		sql.append(" 'N'                                                                    TPN_CR_YN,                                           												");
		sql.append(" 'N'                                                                    ANTI_CANCER_CR_YN,                                   												");
		sql.append(" 'N'                                                                    FLUID_CR_YN,                                         												");
		sql.append(" 'N'                                                                    PORTABLE_CR_YN,                                               										");
		sql.append(" 'N'                                                                    DONER_CR_YN,                                                  										");
		sql.append(" C.AMT_CR_YN                                                            AMT_CR_YN,                                                    										");
		sql.append(" ''                  									                SPECIMEN_NAME,                                                										");
		sql.append(" ''                       								                JUSA_NAME,                                                    										");
		sql.append(" ''                                                                     PAY_NAME,                                                     										");
		sql.append(" FN_OCS_LOAD_BOGYONG_COL_NAME(:hosp_code, :language,B.ORDER_GUBUN,A.BOGYONG_CODE) 				BOGYONG_NAME,                         										");
		sql.append(" D.BUN_CODE                                                             BUN_CODE,                                                     										");
		sql.append(" B.LIMIT_SURYANG                                                        LIMIT_SURYANG,                                                										");
		sql.append(" B.LIMIT_NALSU                                                          LIMIT_NALSU,                                                  										");
		sql.append(" FN_OCS_BULYONG_CHECK_OUT(A.HANGMOG_CODE,CURRENT_TIMESTAMP, :hosp_code)           				BULYONG_CHECK,                        										");
		sql.append(" A.INPUT_TAB                                                            INPUT_TAB,                                                    										");
		sql.append(" ''                                                                     DV_5,                                                         										");
		sql.append(" ''                                                                     DV_6,                                                         										");
		sql.append(" ''                                                                     DV_7,                                                         										");
		sql.append(" ''                                                                     DV_8,                                                         										");
		sql.append(" IFNULL(A.GENERAL_DISP_YN,'N')                                          GENERAL_DISP_YN,                                              										");
		sql.append(" IFNULL(I.GENERIC_NAME, ''),                                                                                                          										");
		sql.append(" A.FKINP1001,                                                                                                                         										");
		sql.append(" A.ORDER_DATE,                                                                                                                        										");
		sql.append(" A.DRG_COMMENT,                                                                                                                       										");
		sql.append(" A.TOTAL_SURYANG,                                                                                                                     										");
		sql.append(" A.CURRENT_SURYANG,                                                                                                                   										");
		sql.append(" IFNULL(A.USEDUP_YN,'N'),                                                                                                             										");
		sql.append(" A.INPUT_USER_ID,                                                                                                                     										");
		sql.append(" A.JUSA_SPD_GUBUN                                                                                                                     										");
		sql.append(" FROM OCS0103 B LEFT OUTER JOIN(SELECT A.SG_CODE                                                                                      										");
		sql.append(" , A.SG_NAME                                                                                                                          										");
		sql.append(" , A.BUN_CODE                                                                                                                         										");
		sql.append(" , A.HOSP_CODE                                                                                                                        										");
		sql.append("    FROM BAS0310 A                                                                                                                    										");
		sql.append("    WHERE A.HOSP_CODE = :hosp_code                                                                                                    										");
		sql.append("    AND A.SG_YMD =(SELECT MAX(B.SG_YMD)                                                                                               										");
		sql.append("       FROM BAS0310 B                                                                                                                 										");
		sql.append("       WHERE B.HOSP_CODE = A.HOSP_CODE                                                                                                										");
		sql.append("       AND B.SG_CODE   = A.SG_CODE                                                                                                    										");
		sql.append("       AND B.SG_YMD   <= SWF_TruncDate(CURRENT_TIMESTAMP,'DD'))) D ON D.HOSP_CODE  = B.HOSP_CODE AND D.SG_CODE    = B.SG_CODE         										");
		sql.append("       LEFT OUTER JOIN OCS0109 I ON I.HOSP_CODE    = B.HOSP_CODE AND I.GENERIC_CODE = SUBSTRING(B.YAK_KIJUN_CODE,1,9),                										");
		sql.append(" OCS1024 A, OCS0133 C, OCS0132 E                                                                                                      										");
		sql.append(" WHERE A.HOSP_CODE     = :hosp_code AND A.BUNHO  = :bunho                                                                             										");
		sql.append(" AND A.INPUT_TAB  LIKE :input_tab AND A.FKINP1001  = :fkinp1001                                                                       										");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                               										");
		sql.append(" AND SWF_TruncDate(CURRENT_TIMESTAMP,'DD') BETWEEN B.START_DATE AND B.END_DATE                                                        										");
		sql.append(" AND C.HOSP_CODE     = B.HOSP_CODE AND C.INPUT_CONTROL = B.INPUT_CONTROL AND C.LANGUAGE = :language                                   										");
		sql.append(" AND E.HOSP_CODE     = A.HOSP_CODE AND E.CODE          = A.ORDER_GUBUN                                                                										");
		sql.append(" AND E.CODE_TYPE     = 'ORDER_GUBUN'    AND E.LANGUAGE = :language                                                                    										");
		sql.append(" ORDER BY A.BOGYONG_CODE,A.SEQ																																				");
		if(startNum != null && offset !=null){                                                                                                            										
			sql.append(" LIMIT :startNum, :offset																					                      										");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("generic_yn", genericYn);
		query.setParameter("bunho", bunho);
		query.setParameter("input_tab", inputTab);
		query.setParameter("fkinp1001", fkinp1001);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<OCS1024U00grdOCS1024Info> lstResult = new JpaResultMapper().list(query, OCS1024U00grdOCS1024Info.class);
		return lstResult;
	}

	@Override
	public List<OCS1024U00grdOCS1024Info> getOCS1024U00grdOCS1024Jusa(String hospCode, String language,
			String genericYn, String bunho, String inputTab, Double fkinp1001,Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                     BUNHO             ,                                                             ");
		sql.append(" A.GWA                                                       GWA               ,                                                                    ");
		sql.append(" A.PKOCS1024                                                 PKOCS1024         ,                                                                    ");
		sql.append(" ''                                                        GROUP_SER         ,                                                     ");
		sql.append(" A.SEQ                                                       SEQ               ,                                                                    ");
		sql.append(" A.HANGMOG_CODE                                              HANGMOG_CODE      ,                                                                    ");
		sql.append(" CASE :generic_yn WHEN 'N' THEN B.HANGMOG_NAME ELSE CASE A.GENERAL_DISP_YN WHEN 'Y' THEN I.GENERIC_NAME ELSE B.HANGMOG_NAME END END HANGMOG_NAME,   ");
		sql.append(" ''                                             SPECIMEN_CODE     ,                                                                ");
		sql.append(" CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END SURYANG           ,                      ");
		sql.append(" A.ORD_DANUI                                                 ORD_DANUI         ,                                                                    ");
		sql.append(" FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI, :hosp_code, :language) ORD_DANUI_NAME    ,                                                          ");
		sql.append(" A.DV_TIME                                                   DV_TIME           ,                                                                    ");
		sql.append(" IFNULL(A.DV,0)                                              DV                ,                                                                    ");
		sql.append(" ''                                              DV_1              ,                                                               ");
		sql.append(" ''                                              DV_2              ,                                                               ");
		sql.append(" ''                                              DV_3              ,                                                               ");
		sql.append(" ''                                              DV_4              ,                                                               ");
		sql.append(" A.NALSU                                                     NALSU             ,                                                                    ");
		sql.append(" A.JUSA                                                      JUSA              ,                                                                    ");
		sql.append(" A.BOGYONG_CODE                                              BOGYONG_CODE      ,                                                                    ");
		sql.append(" ''                                                        EMERGENCY         ,                                                     ");
		sql.append(" ''                                                        PAY               ,                                                     ");
		sql.append(" ''                                                        FLUID_YN          ,                                                     ");
		sql.append(" ''                                                        TPN_YN            ,                                                     ");
		sql.append(" ''                                                        ANTI_CANCER_YN    ,                                                     ");
		sql.append(" ''                                                        PORTABLE_YN       ,                                                     ");
		sql.append(" ''                                                        POWDER_YN         ,                                                     ");
		sql.append(" ''                                                        SPECIAL_YN        ,                                                     ");
		sql.append(" ''                                                        ACT_DOCTOR        ,                                                     ");
		sql.append(" 'N'                                                         MUHYO             ,                                                                    ");
		sql.append(" ''                                                        SYMYA             ,                                                     ");
		sql.append(" ''                                                        SPECIAL_RATE      ,                                                     ");
		sql.append(" ''                                                        ACT_DOCTOR_NAME   ,                                                     ");
		sql.append(" ''                                                        PRN_YN            ,                                                     ");
		sql.append(" ''                                                        PREPARE_YN        ,                                                     ");
		sql.append(" A.ORDER_GUBUN                                               ORDER_GUBUN       ,                                                                    ");
		sql.append(" B.ORDER_GUBUN                                               ORDER_GUBUN_BAS   ,                                                                    ");
		sql.append(" IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN',A.ORDER_GUBUN,:hosp_code, :language),'Etc') ORDER_GUBUN_NAME  ,                                         ");
		sql.append(" ''                                                        ORDER_REMARK      ,                                                     ");
		sql.append(" ''                                                        NURSE_REMARK      ,                                                     ");
		sql.append(" ''                                                        MIX_GROUP         ,                                                     ");
		sql.append(" ''                                                        WONYOI_ORDER_YN   ,                                                     ");
		sql.append(" ''                                                        WONNAE_SAYU_CODE  ,                                                     ");
		sql.append(" B.INPUT_CONTROL                                             INPUT_CONTROL     ,                                                                    ");
		sql.append(" B.SUGA_YN                                                   SUGA_YN           ,                                                                    ");
		sql.append(" B.JAERYO_YN                                                 JAERYO_YN         ,                                                                    ");
		sql.append(" ''                                                        SPECIAL_CHECK     ,                                                     ");
		sql.append(" ''                                                        PRIS_NAME         ,                                                     ");
		sql.append(" B.SLIP_CODE                                                 SLIP_CODE         ,                                                                    ");
		sql.append(" CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END EMERGENCY_CHECK   ,                                                  ");
		sql.append(" B.SPECIMEN_YN                                               SPECIMEN_YN       ,                                                                    ");
		sql.append(" 'N'                                                         MULTI_GUMSA_YN    ,                                                                    ");
		sql.append(" C.SPECIMEN_CR_YN                                            SPECIMEN_CR_YN    ,                                                                    ");
		sql.append(" C.SURYANG_CR_YN                                             SURYANG_CR_YN     ,                                                                    ");
		sql.append(" C.ORD_DANUI_CR_YN                                           ORD_DANUI_CR_YN   ,                                                                    ");
		sql.append(" 'N'                                                         DV_TIME_CR_YN     ,                                                                    ");
		sql.append(" C.DV_CR_YN                                                  DV_CR_YN          ,                                                                    ");
		sql.append(" C.NALSU_CR_YN                                               NALSU_CR_YN       ,                                                                    ");
		sql.append(" C.JUSA_CR_YN                                                JUSA_CR_YN        ,                                                                    ");
		sql.append(" C.BOGYONG_CODE_CR_YN                                        BOGYONG_CODE_CR_YN,                                                                    ");
		sql.append(" C.TOIWON_DRG_CR_YN                                          TOIWON_DRG_CR_YN  ,                                                                    ");
		sql.append(" 'N'                                                         TPN_CR_YN         ,                                                                    ");
		sql.append(" 'N'                                                         ANTI_CANCER_CR_YN ,                                                                    ");
		sql.append(" 'N'                                                         FLUID_CR_YN       ,                                                                    ");
		sql.append(" 'N'                                                         PORTABLE_CR_YN    ,                                                                    ");
		sql.append(" 'N'                                                         DONER_CR_YN       ,                                                                    ");
		sql.append(" C.AMT_CR_YN                                                 AMT_CR_YN         ,                                                                    ");
		sql.append("''                                                        SPECIMEN_NAME     ,                                                      ");
		sql.append(" FN_OCS_LOAD_CODE_NAME('JUSA',A.JUSA,:hosp_code, :language)                       JUSA_NAME         ,                                               ");
		sql.append(" ''                                                        PAY_NAME          ,                                                     ");
		sql.append(" FN_DRG_LOAD_BOGYONG_JUSA_NAME(B.ORDER_GUBUN,A.BOGYONG_CODE,:hosp_code, :language) BOGYONG_NAME      ,                                              ");
		sql.append(" D.BUN_CODE                                                  BUN_CODE          ,                                                                    ");
		sql.append(" B.LIMIT_SURYANG                                             LIMIT_SURYANG     ,                                                                    ");
		sql.append(" B.LIMIT_NALSU                                               LIMIT_NALSU       ,                                                                    ");
		sql.append(" FN_OCS_BULYONG_CHECK_OUT(A.HANGMOG_CODE,CURRENT_TIMESTAMP,:hosp_code)           BULYONG_CHECK     ,                                                ");
		sql.append(" A.INPUT_TAB                                                 INPUT_TAB         ,                                                                    ");
		sql.append(" ''                                              DV_5              ,                                                               ");
		sql.append(" ''                                              DV_6              ,                                                               ");
		sql.append(" ''                                              DV_7              ,                                                               ");
		sql.append(" ''                                              DV_8              ,                                                               ");
		sql.append(" IFNULL(A.GENERAL_DISP_YN,'N')                                 GENERAL_DISP_YN   ,                                                                  ");
		sql.append(" I.GENERIC_NAME,                                                                                                                                    ");
		sql.append(" A.FKINP1001,                                                                                                                                       ");
		sql.append(" A.ORDER_DATE,                                                                                                                                      ");
		sql.append(" A.DRG_COMMENT,                                                                                                                                     ");
		sql.append(" A.TOTAL_SURYANG,                                                                                                                                   ");
		sql.append(" A.CURRENT_SURYANG,                                                                                                                                 ");
		sql.append(" IFNULL(A.USEDUP_YN,'N'),                                                                                                                           ");
		sql.append(" A.INPUT_USER_ID,                                                                                                                                   ");
		sql.append(" A.JUSA_SPD_GUBUN                                                                                                                                   ");
		sql.append(" FROM OCS0103 B LEFT OUTER JOIN(SELECT A.SG_CODE                                                                                                    ");
		sql.append(" , A.SG_NAME                                                                                                                                        ");
		sql.append(" , A.BUN_CODE                                                                                                                                       ");
		sql.append(" , A.HOSP_CODE                                                                                                                                      ");
		sql.append("    FROM BAS0310 A                                                                                                                                  ");
		sql.append("    WHERE A.HOSP_CODE = :hosp_code                                                                                                                  ");
		sql.append("    AND A.SG_YMD =(SELECT MAX(B.SG_YMD)                                                                                                             ");
		sql.append("       FROM BAS0310 B                                                                                                                               ");
		sql.append("       WHERE B.HOSP_CODE = A.HOSP_CODE                                                                                                              ");
		sql.append("       AND B.SG_CODE   = A.SG_CODE                                                                                                                  ");
		sql.append("       AND B.SG_YMD   <= SWF_TruncDate(CURRENT_TIMESTAMP,'DD'))) D ON D.HOSP_CODE  = B.HOSP_CODE AND D.SG_CODE    = B.SG_CODE                       ");
		sql.append("       LEFT OUTER JOIN OCS0109 I ON I.HOSP_CODE    = B.HOSP_CODE AND I.GENERIC_CODE = SUBSTRING(B.YAK_KIJUN_CODE,1,9),                              ");
		sql.append(" OCS1024 A, OCS0133 C, OCS0132 E                                                                                                                    ");
		sql.append(" WHERE A.HOSP_CODE     = :hosp_code AND A.BUNHO  = :bunho                                                                                           ");
		sql.append(" AND A.INPUT_TAB  LIKE :input_tab AND A.FKINP1001     = :fkinp1001                                                                                  ");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                             ");
		sql.append(" AND SWF_TruncDate(CURRENT_TIMESTAMP,'DD') BETWEEN B.START_DATE AND B.END_DATE                                                                      ");
		sql.append(" AND C.HOSP_CODE     = B.HOSP_CODE AND C.LANGUAGE = :language                                                                                       ");
		sql.append(" AND C.INPUT_CONTROL = B.INPUT_CONTROL                                                                                                              ");
		sql.append(" AND E.HOSP_CODE     = A.HOSP_CODE AND E.CODE          = A.ORDER_GUBUN                                                                              ");
		sql.append(" AND E.CODE_TYPE     = 'ORDER_GUBUN' AND E.LANGUAGE = :language                                                                                     ");
		sql.append(" ORDER BY A.BOGYONG_CODE,A.SEQ																														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("generic_yn", genericYn);
		query.setParameter("bunho", bunho);
		query.setParameter("input_tab", inputTab);
		query.setParameter("fkinp1001", fkinp1001);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<OCS1024U00grdOCS1024Info> lstResult = new JpaResultMapper().list(query, OCS1024U00grdOCS1024Info.class);
		return lstResult;
	}

	@Override
	public Double getMaxSeqByBunhoAnhGwa(String hospCode, String bunho, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(MAX(SEQ), 0) + 1          ");
		sql.append("    FROM OCS1024                        ");
		sql.append("   WHERE HOSP_CODE = :hosp_code       ");
		sql.append("     AND BUNHO     = :bunho           ");
		sql.append("     AND GWA       = :gwa				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("gwa", gwa);
		List<Double> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
}

