package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1001RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1001U00LayNUR1001Info;
import nta.med.data.model.ihis.nuri.NUR9999R11layPaInfoInfo;

public class Nur1001RepositoryImpl implements Nur1001RepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1001U00LayNUR1001Info> getNUR1001U00LayNUR1001Info(String hospCode, String bunho, String ipwonDate, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT   B.HOSP_CODE,                                                                                                               ");
		sql.append("            B.BUNHO,                                                                                                                   ");
		sql.append("            CAST(B.FKINP1001 AS CHAR),                                                                                                 ");
		sql.append("            A.BLOOD_TYPE_ABO,                                                                                                          ");
		sql.append("            A.BLOOD_TYPE_RH,                                                                                                           ");
		sql.append("            A.PURPOSE,                                                                                                                 ");
		sql.append("            A.INFORMANT,                                                                                                               ");
		sql.append("            A.KEY_NAME1,                                                                                                               ");
		sql.append("            A.KEY_RELATION1,                                                                                                           ");
		sql.append("            A.KEY_HOME1,                                                                                                               ");
		sql.append("            A.WRITER,                                                                                                                  ");
		sql.append("            FN_ADM_LOAD_USER_NM(:f_hosp_code, A.WRITER, STR_TO_DATE(:f_ipwon_date,'%Y/%m/%d')) WRITER_NAME,                            ");
		sql.append("            A.DIAGNOSIS_NAME,                                                                                                          ");
		sql.append("            A.DIAGNOSIS_GUBUN,                                                                                                         ");
		sql.append("            A.INPATIENT_COURSE,                                                                                                        ");
		sql.append("            A.ASSESSMENT_0,                                                                                                            ");
		sql.append("            A.PAST_HIS,                                                                                                                ");
		sql.append("            A.BRING_DRUG_YN,                                                                                                           ");
		sql.append("            A.BRING_DRUG_COMMENT,                                                                                                      ");
		sql.append("            A.HEALTHCARE_YN,                                                                                                           ");
		sql.append("            A.HEALTHCARE_COMMENT,                                                                                                      ");
		sql.append("            CAST(A.SMOKING_DAY AS CHAR) SMOKING_DAY,                                                                                   ");
		sql.append("            A.DRINKING,                                                                                                                ");
		sql.append("            A.EXPLAIN_DOCTOR,                                                                                                          ");
		sql.append("            A.EXPLAIN_PATIENT,                                                                                                         ");
		sql.append("            A.EXPLAIN_FAMILY,                                                                                                          ");
		sql.append("            A.ASSESSMENT_1,                                                                                                            ");
		sql.append("            A.MAIN_FOOD,                                                                                                               ");
		sql.append("            A.SUB_FOOD,                                                                                                                ");
		sql.append("            A.FOOD_DISLIKE_YN,                                                                                                         ");
		sql.append("            A.FOOD_DISLIKE_COMMENT,                                                                                                    ");
		sql.append("            A.APPETITE_YN,                                                                                                             ");
		sql.append("            A.APPETITE_COMMENT,                                                                                                        ");
		sql.append("            A.DYSPHAGIA_YN,                                                                                                            ");
		sql.append("            A.DYSPHAGIA_COMMENT,                                                                                                       ");
		sql.append("            A.INTAKE_WAY,                                                                                                              ");
		sql.append("            A.INTAKE_COMMENT,                                                                                                          ");
		sql.append("            A.FOOD_LIMIT,                                                                                                              ");
		sql.append("            A.MOUTH_POLLUTION_YN,                                                                                                      ");
		sql.append("            A.MOUTH_POLLUTION_COMMENT,                                                                                                 ");
		sql.append("            A.FALSE_TEETH_YN,                                                                                                          ");
		sql.append("            A.FALSE_TEETH_COMMENT,                                                                                                     ");
		sql.append("            A.WEIGHT_UPDOWN_START,                                                                                                     ");
		sql.append("            A.WEIGHT_UPDOWN_HOW,                                                                                                       ");
		sql.append("            A.HEIGHT,                                                                                                                  ");
		sql.append("            A.WEIGHT,                                                                                                                  ");
		sql.append("            CAST(ROUND((A.WEIGHT / CASE(A.HEIGHT * A.HEIGHT) WHEN 0 THEN 1 ELSE (A.HEIGHT * A.HEIGHT) END )*10000, 2) AS CHAR) BMI,    ");
		sql.append("            CAST(A.DUNG_COUNT AS CHAR) DUNG_COUNT,                                                                                     ");
		sql.append("            A.DUNG_DAY,                                                                                                                ");
		sql.append("            A.DUNG_STATE,                                                                                                              ");
		sql.append("            A.DUNG_LAST,                                                                                                               ");
		sql.append("            A.DUNG_WILL_YN,                                                                                                            ");
		sql.append("            A.DIAPERS_YN,                                                                                                              ");
		sql.append("            A.ORTHOTICS_YN,                                                                                                            ");
		sql.append("            A.ENEMA_YN,                                                                                                                ");
		sql.append("            A.LAXATIVE_YN,                                                                                                             ");
		sql.append("            A.SUPPOSITORY_YN,                                                                                                          ");
		sql.append("            A.ANTIDIARRHEAL_YN,                                                                                                        ");
		sql.append("            A.LAXATION_COMMENT,                                                                                                        ");
		sql.append("            A.URIN_COUNT,                                                                                                              ");
		sql.append("            A.URIN_DAY,                                                                                                                ");
		sql.append("            A.URIN_NIGHT_COUNT,                                                                                                        ");
		sql.append("            A.URIN_WILL_YN,                                                                                                            ");
		sql.append("            A.INTERMITTENT_YN,                                                                                                         ");
		sql.append("            A.INTERMITTENT_COMMENT,                                                                                                    ");
		sql.append("            A.CATHETER_YN,                                                                                                             ");
		sql.append("            DATE_FORMAT(A.CATHETER_START_DATE, '%Y/%m/%d'),                                                                            ");
		sql.append("            A.ABDOMINAL_INFLATION_YN,                                                                                                  ");
		sql.append("            A.ABDOMINAL_INFLATION_VERY_YN,                                                                                             ");
		sql.append("            A.ENTEROKINESIA_YN,                                                                                                        ");
		sql.append("            A.ASSESSMENT_2,                                                                                                            ");
		sql.append("            A.ADL_FOOD_STATE,                                                                                                          ");
		sql.append("            A.ADL_FOOD_COMMENT,                                                                                                        ");
		sql.append("            A.ADL_BATH_STATE,                                                                                                          ");
		sql.append("            A.ADL_BATH_COMMENT,                                                                                                        ");
		sql.append("            A.ADL_CLOTH_STATE,                                                                                                         ");
		sql.append("            A.ADL_CLOTH_COMMENT,                                                                                                       ");
		sql.append("            A.ADL_WASH_STATE,                                                                                                          ");
		sql.append("            A.ADL_WASH_COMMENT,                                                                                                        ");
		sql.append("            A.ADL_EXCRETION_STATE,                                                                                                     ");
		sql.append("            A.ADL_EXCRETION_COMMENT,                                                                                                   ");
		sql.append("            A.ADL_STRUGGLE_STATE,                                                                                                      ");
		sql.append("            A.ADL_STRUGGLE_COMMENT,                                                                                                    ");
		sql.append("            A.ADL_BOARD_STATE,                                                                                                         ");
		sql.append("            A.ADL_BOARD_COMMENT,                                                                                                       ");
		sql.append("            A.ADL_WHEELCHAIR_STATE,                                                                                                    ");
		sql.append("            A.ADL_WHEELCHAIR_COMMENT,                                                                                                  ");
		sql.append("            A.ADL_WALK_STATE,                                                                                                          ");
		sql.append("            A.ADL_WALK_COMMENT,                                                                                                        ");
		sql.append("            A.NEED_CARE,                                                                                                               ");
		sql.append("            A.NEED_SUPPORT,                                                                                                            ");
		sql.append("            A.SERVICE_COMMENT,                                                                                                         ");
		sql.append("            A.CARE_OFFICE_COMMENT,                                                                                                     ");
		sql.append("            A.SLEEP_TIME,                                                                                                              ");
		sql.append("            A.SLEEP_START_TIME,                                                                                                        ");
		sql.append("            A.SLEEP_END_TIME,                                                                                                          ");
		sql.append("            A.SLEEP_ENOUGH_YN,                                                                                                         ");
		sql.append("            A.SLEEP_ENOUGH_COMMENT,                                                                                                    ");
		sql.append("            A.SLEEPLESS_COMMENT,                                                                                                       ");
		sql.append("            A.SNORING_YN,                                                                                                              ");
		sql.append("            A.SLEEP_TALK_YN,                                                                                                           ");
		sql.append("            A.TEETH_GRINDING_YN,                                                                                                       ");
		sql.append("            A.SLEEP_ETC_YN,                                                                                                            ");
		sql.append("            A.SLEEP_ETC_COMMENT,                                                                                                       ");
		sql.append("            A.ASSESSMENT_4,                                                                                                            ");
		sql.append("            A.SENSE_LEVEL,                                                                                                             ");
		sql.append("            A.OBSTACLE_SPEECH_YN,                                                                                                      ");
		sql.append("            A.OBSTACLE_SENSE_YN,                                                                                                       ");
		sql.append("            A.OBSTACLE_YN,                                                                                                             ");
		sql.append("            A.OBSTACLE_COMMENT,                                                                                                        ");
		sql.append("            A.RECOGNITION_YN,                                                                                                          ");
		sql.append("            A.RECOGNITION_COMMENT,                                                                                                     ");
		sql.append("            A.SENSOR_YN,                                                                                                               ");
		sql.append("            A.EYE_RIGHT_YN,                                                                                                            ");
		sql.append("            A.EYE_RIGHT_COMMENT,                                                                                                       ");
		sql.append("            A.EYE_LEFT_YN,                                                                                                             ");
		sql.append("            A.EYE_LEFT_COMMENT,                                                                                                        ");
		sql.append("            A.EYE_GLASSES_YN,                                                                                                          ");
		sql.append("            A.EYE_LENS_YN,                                                                                                             ");
		sql.append("            A.EAR_RIGHT_YN,                                                                                                            ");
		sql.append("            A.EAR_RIGHT_COMMENT,                                                                                                       ");
		sql.append("            A.EAR_LEFT_YN,                                                                                                             ");
		sql.append("            A.EAR_LEFT_COMMENT,                                                                                                        ");
		sql.append("            A.EAR_AID_YN,                                                                                                              ");
		sql.append("            A.NOSE_COMMENT,                                                                                                            ");
		sql.append("            A.MOUTH_COMMENT,                                                                                                           ");
		sql.append("            A.DIZZY_YN,                                                                                                                ");
		sql.append("            A.DIZZY_COMMENT,                                                                                                           ");
		sql.append("            A.STAGGER_YN,                                                                                                              ");
		sql.append("            A.STAGGER_COMMENT,                                                                                                         ");
		sql.append("            A.PAIN_YN,                                                                                                                 ");
		sql.append("            A.PAIN_COMMENT,                                                                                                            ");
		sql.append("            A.PERCEPTION_YN,                                                                                                           ");
		sql.append("            A.PERCEPTION_COMMENT,                                                                                                      ");
		sql.append("            A.MOVEMENT_YN,                                                                                                             ");
		sql.append("            A.PARALYSIS_YN,                                                                                                            ");
		sql.append("            A.PARALYSIS_COMMENT,                                                                                                       ");
		sql.append("            A.CONTRACTURE_YN,                                                                                                          ");
		sql.append("            A.CONTRACTURE_COMMENT,                                                                                                     ");
		sql.append("            A.LOSS_PART_YN,                                                                                                            ");
		sql.append("            A.LOSS_PART_COMMENT,                                                                                                       ");
		sql.append("            A.WORRY_YN,                                                                                                                ");
		sql.append("            A.WORRY_COMMENT,                                                                                                           ");
		sql.append("            A.FEAR_YN,                                                                                                                 ");
		sql.append("            A.FEAR_COMMENT,                                                                                                            ");
		sql.append("            A.ASSESSMENT_5,                                                                                                            ");
		sql.append("            A.FAMILY_YN,                                                                                                               ");
		sql.append("            A.FAMILY_COMMENT,                                                                                                          ");
		sql.append("            A.JOB,                                                                                                                     ");
		sql.append("            A.JOB_MATE,                                                                                                                ");
		sql.append("            A.HOUSE_KIND,                                                                                                              ");
		sql.append("            A.BARRIER_FREE_YN,                                                                                                         ");
		sql.append("            A.MENSES,                                                                                                                  ");
		sql.append("            A.MENSES_AGE,                                                                                                              ");
		sql.append("            A.MENSES_PROBLEM_YN,                                                                                                       ");
		sql.append("            A.MENSES_PROBLEM_COMMENT,                                                                                                  ");
		sql.append("            A.PREGNANCY_YN,                                                                                                            ");
		sql.append("            A.HOBBY_YN,                                                                                                                ");
		sql.append("            A.HOBBY_COMMENT,                                                                                                           ");
		sql.append("            A.STRESS_YN,                                                                                                               ");
		sql.append("            A.STRESS_COMMENT,                                                                                                          ");
		sql.append("            A.STRESS_MANAGE,                                                                                                           ");
		sql.append("            A.RELIGION_YN,                                                                                                             ");
		sql.append("            A.RELIGION_COMMENT,                                                                                                        ");
		sql.append("            A.ASSESSMENT_7,                                                                                                            ");
		sql.append("            A.KEY_CELL1,                                                                                                               ");
		sql.append("            A.KEY_OFFICE1,                                                                                                             ");
		sql.append("            A.KEY_NAME2,                                                                                                               ");
		sql.append("            A.KEY_RELATION2,                                                                                                           ");
		sql.append("            A.KEY_HOME2,                                                                                                               ");
		sql.append("            A.KEY_CELL2,                                                                                                               ");
		sql.append("            A.KEY_OFFICE2,                                                                                                             ");
		sql.append("            A.KEY_COMMENT,                                                                                                             ");
		sql.append("            CAST(A.KEY_HOME1_PRI AS CHAR) KEY_HOME1_PRI,                                                                               ");
		sql.append("            CAST(A.KEY_CELL1_PRI AS CHAR) KEY_CELL1_PRI,                                                                               ");
		sql.append("            CAST(A.KEY_OFFICE1_PRI AS CHAR) KEY_OFFICE1_PRI,                                                                           ");
		sql.append("            CAST(A.KEY_HOME2_PRI AS CHAR) KEY_HOME2_PRI,                                                                               ");
		sql.append("            CAST(A.KEY_CELL2_PRI AS CHAR) KEY_CELL2_PRI,                                                                               ");
		sql.append("            CAST(A.KEY_OFFICE2_PRI AS CHAR) KEY_OFFICE2_PRI,                                                                           ");
		sql.append("            '' DATA_ROW_STATE                                                                                                          ");
		sql.append("     FROM (SELECT :f_hosp_code HOSP_CODE                                                                                               ");
		sql.append("                , :f_bunho     BUNHO                                                                                                   ");
		sql.append("                , :f_fkinp1001 FKINP1001                                                                                               ");
		sql.append("             FROM DUAL) B                                                                                                              ");
		sql.append("     LEFT JOIN NUR1001 A                                                                                                               ");
		sql.append("       ON A.HOSP_CODE = B.HOSP_CODE                                                                                                    ");
		sql.append("      AND A.BUNHO     = B.BUNHO                                                                                                        ");
		sql.append("      AND A.FKINP1001 = B.FKINP1001                                                                                                    ");
		sql.append("    WHERE B.HOSP_CODE = :f_hosp_code                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<NUR1001U00LayNUR1001Info> listInfo = new JpaResultMapper().list(query, NUR1001U00LayNUR1001Info.class);
		return listInfo;
	}
	
	@Override
	public String checkNUR1001U00isExist(String hospCode, String bunho, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'X'                                  ");
		sql.append("     FROM NUR1001 A                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code           ");
		sql.append("      AND A.BUNHO     = :f_bunho               ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<NUR9999R11layPaInfoInfo> getNUR9999R11layPaInfoInfo(String hospCode, String language, Date writeDate,
			Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.IPWON_DATE                                                                                                     ");
		sql.append("	    , A.TOIWON_DATE                                                                                                     ");
		sql.append("	    , A.HO_DONG1                                                                                                        ");
		sql.append("	    , FN_BAS_LOAD_GWA_NAME(A.GWA, :f_write_date, :f_hosp_code, :f_language)      GWA                                    ");
		sql.append("	    , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, :f_write_date, :f_hosp_code), '') DOCTOR                                 ");
		sql.append("	    , IFNULL(CONCAT(B.KEY_NAME1, ' ', B.KEY_RELATION1), '')                                                             ");
		sql.append("	    , IFNULL(B.KEY_HOME1   , '')                                                                                        ");
		sql.append("	    , IFNULL(B.KEY_CELL1   , '')                                                                                        ");
		sql.append("	    , IFNULL(B.KEY_OFFICE1 , '')                                                                                        ");
		sql.append("	    , IFNULL(CONCAT(B.KEY_NAME2, ' ', B.KEY_RELATION2), '')                                                             ");
		sql.append("	    , IFNULL(B.KEY_HOME2															, '')                                ");
		sql.append("	    , IFNULL(B.KEY_CELL2															, '')                                ");
		sql.append("	    , IFNULL(B.KEY_OFFICE2      													, '')                                ");
		sql.append("	    , IFNULL(FN_NUR_LOAD_INFE_INFO(:f_hosp_code, A.BUNHO) 							, '') INFE_INFO                      ");
		sql.append("	    , IFNULL(B.INPATIENT_COURSE													, '')                                	 ");
		sql.append("	    , IFNULL(FN_NUR_LOAD_DAMDANG_NURSE(:f_hosp_code, A.PKINP1001, :f_write_date) 	, '') DAMDANG_NURSE                  ");
		sql.append("	    , IFNULL(FN_OCS_LOAD_SANG_NAME(:f_hosp_code, A.BUNHO, A.PKINP1001) 			, '') SANG_NAME                      	 ");
		sql.append("	    , IFNULL(FN_OCS_LOAD_AGE(:f_hosp_code, A.BUNHO, :f_write_date) 				, '') AGE                            	 ");
		sql.append("	    , IFNULL(B.PAST_HIS                                                            , '')                                ");
		sql.append("	 FROM INP1001 A                                                                                                         ");
		sql.append("	 LEFT JOIN NUR1001 B ON B.HOSP_CODE  = A.HOSP_CODE                                                                      ");
		sql.append("						         AND B.FKINP1001  = A.PKINP1001                                                             ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                                        ");
		sql.append("	  AND A.PKINP1001 = :f_fkinp1001                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_write_date", writeDate);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR9999R11layPaInfoInfo> listInfo = new JpaResultMapper().list(query, NUR9999R11layPaInfoInfo.class);
		return listInfo;
	}
}
