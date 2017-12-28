package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur7001RepositoryCustom;
import nta.med.data.model.ihis.nuri.NuriMeasurePhysicalConditionListItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListRowFocusChangedInfo;
import nta.med.data.model.phr.SyncBloodPressureInfo;
import nta.med.data.model.phr.SyncHeartRateInfo;
import nta.med.data.model.phr.SyncHeightInfo;
import nta.med.data.model.phr.SyncRespirationRateInfo;
import nta.med.data.model.phr.SyncTemperatureInfo;
import nta.med.data.model.phr.SyncWeightInfo;

/**
 * @author dainguyen.
 */
public class Nur7001RepositoryImpl implements Nur7001RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Nur7001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuriMeasurePhysicalConditionListItemInfo> getNuriMeasurePhysicalConditionListItemInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUNHO                    BUNHO,                          ");
		sql.append("       A.MEASURE_DATE             MEASURE_DATE,                   ");
		sql.append("       IFNULL(A.SEQ, 0)              SEQ,                         ");
		sql.append("       IFNULL(A.HEIGHT, 0)           HEIGHT,                      ");
		sql.append("       IFNULL(A.WEIGHT, 0)           WEIGHT,                      ");
		sql.append("       IFNULL(A.BP_FROM, 0)          BP_FROM,                     ");
		sql.append("       IFNULL(A.BP_TO, 0)            BP_TO,                       ");
		sql.append("       IFNULL(A.BODY_HEAT, 0)        BODY_HEAT,                   ");
		sql.append("       IFNULL(A.PULSE, 0)            PULSE,                       ");
		sql.append("       B.SUNAME                   SUNAME,                         ");
		sql.append("       IFNULL(A.SPO2, 0)             SPO2,                        ");
		sql.append("       A.MEASURE_TIME             MEASURE_TIME,                   ");
		sql.append("       IFNULL(A.BREATH, 0)           BREATH,                      ");
		sql.append("       FN_ADM_LOAD_USER_NAME(A.UPD_ID, :hospitalCode) UPD_ID      ");
		sql.append("  FROM NUR7001 A, OUT0101 B                                       ");
		sql.append(" WHERE A.HOSP_CODE = :hospitalCode                                ");
		sql.append("   AND A.BUNHO     = :bunho                                       ");
		sql.append("   AND A.VALD      = 'Y'                                          ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                  ");
		sql.append("   AND B.BUNHO  = A.BUNHO                                         ");
		sql.append(" ORDER BY 2 DESC                                                  ");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<NuriMeasurePhysicalConditionListItemInfo> list = new JpaResultMapper().list(query, NuriMeasurePhysicalConditionListItemInfo.class);
		
		return list;
	}

	@Override
	public List<PHY2001U04GrdPatientListRowFocusChangedInfo> getGrdPatientListRowFocusChangedInfo(String hospCode, String bunho, Date measureDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.BP_FROM                                      " );
		sql.append("        , B.BP_TO                                      " );
		sql.append("        , B.PULSE                                      " );
		sql.append("        , B.BODY_HEAT                                  " );
		sql.append("     FROM (                                            " );
		sql.append("           SELECT MAX(SEQ) SEQ                         " );
		sql.append("             FROM NUR7001 A                            " );
		sql.append("            WHERE A.HOSP_CODE    = :f_hosp_code        " );
		sql.append("              AND A.BUNHO        = :f_bunho            " );
		sql.append("              AND A.MEASURE_DATE = :f_measure_date     " );
		sql.append("           )     AA                                    " );
		sql.append("       , NUR7001 B                                     " );
		sql.append("   WHERE B.HOSP_CODE    = :f_hosp_code                 " );
		sql.append("     AND B.BUNHO        = :f_bunho                     " );
		sql.append("     AND B.MEASURE_DATE = :f_measure_date              " );
		sql.append("     AND B.SEQ          = AA.SEQ                       " );
		sql.append("     AND B.VALD         = 'Y'							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_measure_date", measureDate);
		List<PHY2001U04GrdPatientListRowFocusChangedInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdPatientListRowFocusChangedInfo.class);
		
		return list;
	}

	@Override
	public List<SyncHeightInfo> getPatientHeightByPatient(String hospCode, String patientCode) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT                                                                                          " );
		sql.append("       ID									    as  sync_id,	                                    " );
		sql.append("       CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,         " );
		sql.append(" 			HEIGHT									as	height,                                     " );
		sql.append(" 			SYS_DATE								as	created,							        " );
		sql.append(" 			UPD_DATE								as	updated			                            " );
		sql.append(" 			,  VALD                 				as  vald			                            " );
		sql.append("   	FROM                                                                                            " );
		sql.append(" 			NUR7001																		            " );
		sql.append("   	WHERE 1 = 1		                                                                                " );
		sql.append(" 			AND BUNHO 					=		:patientCode										" );
		sql.append(" 			AND HOSP_CODE				=		:hospCode										    " );
		sql.append(" 			AND HEIGHT					IS NOT NULL												    " );
		sql.append("   	ORDER BY																				        " );
		sql.append(" 			MEASURE_DATE 				ASC	                                                        " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncHeightInfo> list = new JpaResultMapper().list(query, SyncHeightInfo.class);
		return list;
	}

	@Override
	public List<SyncWeightInfo> getPatientWeightByPatient(String hospCode, String patientCode) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT                                                                                          " );
		sql.append("       ID									    as  sync_id,	                                    " );
		sql.append("       CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,         " );
		sql.append(" 			WEIGHT									as	weigth,                                     " );
		sql.append(" 			SYS_DATE								as	created,							        " );
		sql.append(" 			UPD_DATE								as	updated			                            " );
		sql.append(" 			,  VALD                 				as  vald			                            " );
		sql.append("   	FROM                                                                                            " );
		sql.append(" 			NUR7001																		            " );
		sql.append("   	WHERE 1 = 1		                                                                                " );
		sql.append(" 			AND BUNHO 					=		:patientCode										" );
		sql.append(" 			AND HOSP_CODE				=		:hospCode										    " );
		sql.append(" 			AND WEIGHT					IS NOT NULL												    " );
		sql.append("   	ORDER BY																				        " );
		sql.append(" 			MEASURE_DATE 				ASC	                                                        " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncWeightInfo> list = new JpaResultMapper().list(query, SyncWeightInfo.class);
		return list;
	}

	@Override
	public List<SyncTemperatureInfo> getPatientTemperatureByPatient(String hospCode, String patientCode) {

		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT                                                                                          " );
		sql.append("       ID									    as  sync_id,	                                    " );
		sql.append("       CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,         " );
		sql.append(" 			BODY_HEAT								as	temperature,                                " );
		sql.append(" 			SYS_DATE								as	created,							        " );
		sql.append(" 			UPD_DATE								as	updated			                            " );
		sql.append(" 			,  VALD                 				as  vald			                            " );
		sql.append("   	FROM                                                                                            " );
		sql.append(" 			NUR7001																		            " );
		sql.append("   	WHERE 1 = 1		                                                                                " );
		sql.append(" 			AND BUNHO 					=		:patientCode										" );
		sql.append(" 			AND HOSP_CODE				=		:hospCode										    " );
		sql.append(" 			AND BODY_HEAT					IS NOT NULL												" );
		sql.append("   	ORDER BY																				        " );
		sql.append(" 			MEASURE_DATE 				ASC	                                                        " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncTemperatureInfo> list = new JpaResultMapper().list(query, SyncTemperatureInfo.class);
		return list;
	}

	@Override
	public List<SyncHeartRateInfo> getPatientHeartRateByPatient(String hospCode, String patientCode) {

		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT                                                                                          " );
		sql.append("       ID									    as  sync_id,	                                    " );
		sql.append("       CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,         " );
		sql.append(" 			PULSE								as	heart_rate,		                                " );
		sql.append(" 			SYS_DATE								as	created,							        " );
		sql.append(" 			UPD_DATE								as	updated			                            " );
		sql.append(" 			,  VALD                 				as  vald			                            " );
		sql.append("   	FROM                                                                                            " );
		sql.append(" 			NUR7001																		            " );
		sql.append("   	WHERE 1 = 1		                                                                                " );
		sql.append(" 			AND BUNHO 					=		:patientCode										" );
		sql.append(" 			AND HOSP_CODE				=		:hospCode										    " );
		sql.append(" 			AND PULSE					IS NOT NULL													" );
		sql.append("   	ORDER BY																				        " );
		sql.append(" 			MEASURE_DATE 				ASC	                                                        " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncHeartRateInfo> list = new JpaResultMapper().list(query, SyncHeartRateInfo.class);
		return list;
	}

	@Override
	public List<SyncRespirationRateInfo> getPatientRespirationRateByPatient(String hospCode, String patientCode) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT                                                                                          " );
		sql.append("       ID									    as  sync_id,	                                    " );
		sql.append("       CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,         " );
		sql.append(" 			BREATH								as	respiration_rate,		                        " );
		sql.append(" 			SYS_DATE								as	created,							        " );
		sql.append(" 			UPD_DATE								as	updated			                            " );
		sql.append(" 			,  VALD                 				as  vald			                            " );
		sql.append("   	FROM                                                                                            " );
		sql.append(" 			NUR7001																		            " );
		sql.append("   	WHERE 1 = 1		                                                                                " );
		sql.append(" 			AND BUNHO 					=		:patientCode										" );
		sql.append(" 			AND HOSP_CODE				=		:hospCode										    " );
		sql.append(" 			AND BREATH					IS NOT NULL													" );
		sql.append("   	ORDER BY																				        " );
		sql.append(" 			MEASURE_DATE 				ASC	                                                        " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncRespirationRateInfo> list = new JpaResultMapper().list(query, SyncRespirationRateInfo.class);
		return list;
	}

	@Override
	public List<SyncBloodPressureInfo> getPatientBloodPressureByPatient(String hospCode, String patientCode) {

		StringBuilder sql = new StringBuilder();
		sql.append(" 		SELECT                                                                                            " );
		sql.append("          ID									    as  sync_id,	                                      " );
		sql.append("          CONCAT(DATE_FORMAT(MEASURE_DATE, '%Y-%m-%d'), ' ', MEASURE_TIME) as datetime_record,            " );
		sql.append(" 				BP_FROM									as	low_blood_pressure,						      " );
		sql.append(" 				BP_TO									  as	high_blood_pressure,                      " );
		sql.append(" 				SYS_DATE								as	created,							 	      " );
		sql.append(" 				UPD_DATE								as	updated			                              " );
		sql.append(" 			,  VALD                 				as  vald			                            	  " );
		sql.append("   	  FROM                                                                                                " );
		sql.append(" 				NUR7001																		              " );
		sql.append("   		WHERE 1 = 1		                                                                                  " );
		sql.append(" 				AND BUNHO 					=		:patientCode										  " );
		sql.append(" 				AND HOSP_CODE				=		:hospCode											  " );
		sql.append(" 				AND BP_FROM					IS NOT NULL													  " );
		sql.append(" 				AND BP_TO					  IS NOT NULL												  " );
		sql.append("   		ORDER BY																				 	      " );
		sql.append(" 				MEASURE_DATE 				ASC			                                                  " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<SyncBloodPressureInfo> list = new JpaResultMapper().list(query, SyncBloodPressureInfo.class);
		return list;
	}
	
	@Override
	public String getNUR6011U01GetNurseInfoWeight(String hospCode, String bunho, String jukyongDate){
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT CAST(FN_NUR_LOAD_WEIGHT(:f_hosp_code, :f_bunho, STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d')) AS CHAR) FROM DUAL  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jukyong_date", jukyongDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
}

