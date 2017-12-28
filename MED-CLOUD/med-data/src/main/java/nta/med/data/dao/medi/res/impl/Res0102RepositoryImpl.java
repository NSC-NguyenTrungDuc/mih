package nta.med.data.dao.medi.res.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.res.Res0102RepositoryCustom;
import nta.med.data.model.ihis.nuro.BookedDetailInfo;
import nta.med.data.model.ihis.nuro.DoctorScheduleInfo;
import nta.med.data.model.ihis.nuro.KCCKGetDoctorWorkingTimeInfo;
import nta.med.data.model.ihis.nuro.KCCKGetLimitScheduleDoctorInfo;
import nta.med.data.model.ihis.nuro.KCCKScheduleDoctorStartEndDateHistory;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0102Info;
import nta.med.data.model.ihis.nuro.NuroRES0102U00UpdateRES0102Info;
import nta.med.data.model.ihis.nuro.NuroRES1001U00AverageTimeListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleConditionListItemInfo;
import nta.med.data.model.ihis.nuro.RES1001U00FrmModifyReserGrdRES1001Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00CreateTimeComboInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2;

public class Res0102RepositoryImpl implements Res0102RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Res0102RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuroRES0102U00GrdRES0102Info> getNuroRES0102U00GrdRES0102Info(
			String hospCode, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR            ,         ");
		sql.append("       A.GWA               ,         ");
		sql.append("       A.START_DATE        ,         ");
		sql.append("       A.AVG_TIME          ,         ");
		sql.append("       A.JINRYO_BREAK_YN   ,         ");
		sql.append("       A.AM_START_HHMM1    ,         ");
		sql.append("       A.AM_START_HHMM2    ,         ");
		sql.append("       A.AM_START_HHMM3    ,         ");
		sql.append("       A.AM_START_HHMM4    ,         ");
		sql.append("       A.AM_START_HHMM5    ,         ");
		sql.append("       A.AM_START_HHMM6    ,         ");
		sql.append("       A.AM_START_HHMM7    ,         ");
		sql.append("       A.AM_END_HHMM1      ,         ");
		sql.append("       A.AM_END_HHMM2      ,         ");
		sql.append("       A.AM_END_HHMM3      ,         ");
		sql.append("       A.AM_END_HHMM4      ,         ");
		sql.append("       A.AM_END_HHMM5      ,         ");
		sql.append("       A.AM_END_HHMM6      ,         ");
		sql.append("       A.AM_END_HHMM7      ,         ");
		sql.append("       A.PM_START_HHMM1    ,         ");
		sql.append("       A.PM_START_HHMM2    ,         ");
		sql.append("       A.PM_START_HHMM3    ,         ");
		sql.append("       A.PM_START_HHMM4    ,         ");
		sql.append("       A.PM_START_HHMM5    ,         ");
		sql.append("       A.PM_START_HHMM6    ,         ");
		sql.append("       A.PM_START_HHMM7    ,         ");
		sql.append("       A.PM_END_HHMM1      ,         ");
		sql.append("       A.PM_END_HHMM2      ,         ");
		sql.append("       A.PM_END_HHMM3      ,         ");
		sql.append("       A.PM_END_HHMM4      ,         ");
		sql.append("       A.PM_END_HHMM5      ,         ");
		sql.append("       A.PM_END_HHMM6      ,         ");
		sql.append("       A.PM_END_HHMM7      ,         ");
		sql.append("       A.AM_GWA_ROOM1      ,         ");
		sql.append("       A.AM_GWA_ROOM2      ,         ");
		sql.append("       A.AM_GWA_ROOM3      ,         ");
		sql.append("       A.AM_GWA_ROOM4      ,         ");
		sql.append("       A.AM_GWA_ROOM5      ,         ");
		sql.append("       A.AM_GWA_ROOM6      ,         ");
		sql.append("       A.AM_GWA_ROOM7      ,         ");
		sql.append("       A.PM_GWA_ROOM1      ,         ");
		sql.append("       A.PM_GWA_ROOM2      ,         ");
		sql.append("       A.PM_GWA_ROOM3      ,         ");
		sql.append("       A.PM_GWA_ROOM4      ,         ");
		sql.append("       A.PM_GWA_ROOM5      ,         ");
		sql.append("       A.PM_GWA_ROOM6      ,         ");
		sql.append("       A.PM_GWA_ROOM7      ,         ");
		sql.append("       A.RES_AM_START_HHMM1,         ");
		sql.append("       A.RES_AM_START_HHMM2,         ");
		sql.append("       A.RES_AM_START_HHMM3,         ");
		sql.append("       A.RES_AM_START_HHMM4,         ");
		sql.append("       A.RES_AM_START_HHMM5,         ");
		sql.append("       A.RES_AM_START_HHMM6,         ");
		sql.append("       A.RES_AM_START_HHMM7,         ");
		sql.append("       A.RES_AM_END_HHMM1  ,         ");
		sql.append("       A.RES_AM_END_HHMM2  ,         ");
		sql.append("       A.RES_AM_END_HHMM3  ,         ");
		sql.append("       A.RES_AM_END_HHMM4  ,         ");
		sql.append("       A.RES_AM_END_HHMM5  ,         ");
		sql.append("       A.RES_AM_END_HHMM6  ,         ");
		sql.append("       A.RES_AM_END_HHMM7  ,         ");
		sql.append("       A.RES_PM_START_HHMM1,         ");
		sql.append("       A.RES_PM_START_HHMM2,         ");
		sql.append("       A.RES_PM_START_HHMM3,         ");
		sql.append("       A.RES_PM_START_HHMM4,         ");
		sql.append("       A.RES_PM_START_HHMM5,         ");
		sql.append("       A.RES_PM_START_HHMM6,         ");
		sql.append("       A.RES_PM_START_HHMM7,         ");
		sql.append("       A.RES_PM_END_HHMM1  ,         ");
		sql.append("       A.RES_PM_END_HHMM2  ,         ");
		sql.append("       A.RES_PM_END_HHMM3  ,         ");
		sql.append("       A.RES_PM_END_HHMM4  ,         ");
		sql.append("       A.RES_PM_END_HHMM5  ,         ");
		sql.append("       A.RES_PM_END_HHMM6  ,         ");
		sql.append("       A.RES_PM_END_HHMM7  ,         ");
		sql.append("       A.DOC_RES_LIMIT     ,         ");
		sql.append("       A.ETC_RES_LIMIT     ,         ");
		sql.append("       A.END_DATE                    ");
		sql.append("       ,A.OUT_HOSP_RES_LIMIT         ");
		sql.append("  FROM RES0102 A                     ");
		sql.append(" WHERE A.HOSP_CODE  = :hospCode      ");
		sql.append("   AND A.DOCTOR     = :doctor      	 ");
		sql.append(" ORDER BY A.START_DATE DESC          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);

		List<NuroRES0102U00GrdRES0102Info> list = new JpaResultMapper().list(
				query, NuroRES0102U00GrdRES0102Info.class);
		return list;
	}
	
	@Override
	public String getNuroRES0102U00CheckDoctor1(String hospCode, String doctor, String startDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                                ");
		sql.append("FROM RES0102                                              ");
		sql.append("WHERE HOSP_CODE  = :hospCode                           ");
		sql.append("  AND DOCTOR     = :doctor                              ");
		sql.append("  AND START_DATE = DATE_FORMAT(:startDate, '%Y/%m/%d') ");
		sql.append("  LIMIT  1                                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("startDate", startDate);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}
	
	
	
	@Override
	public String getNuroRES0102U00CheckDoctor1(String hospCode, String doctor, String startDate, String gwa, String jinryoBreakYn){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                                											");
		sql.append("FROM RES0102  A                                            											");
		sql.append("WHERE A.HOSP_CODE  = :hospCode                           											");
		sql.append("  AND A.DOCTOR     = :doctor                              											");
		sql.append("  AND A.GWA     = :gwa                        														");
		sql.append("  AND A.JINRYO_BREAK_YN     = :jinryoBreakYn                  										");
		sql.append("  AND DATE_FORMAT(A.START_DATE, '%Y/%m/%d') > DATE_FORMAT(:startDate, '%Y/%m/%d') 					");
		sql.append("  LIMIT  1                                                											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("gwa", gwa);
		query.setParameter("jinryoBreakYn", jinryoBreakYn);
		query.setParameter("startDate", startDate);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<String> getDoctorExamStatus(String hospitalCode, String sessionHospCode, String type, Date examPreDate,
											String examPreTime, String doctorCode, boolean isOtherClinic) {


		StringBuilder sql = new StringBuilder();
		if(isOtherClinic){
			sql.append("SELECT FN_OUT_CHECK_DOCTOR_JINRYO_OTHER(:type, :examPreDate, :examPreTime , :doctorCode, :hospitalCode , :sessionHospCode) ");
		}else{
			sql.append("SELECT FN_OUT_CHECK_DOCTOR_JINRYO(:type, :examPreDate, :examPreTime , :doctorCode, :sessionHospCode) ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		query.setParameter("type", type);
		query.setParameter("examPreDate", examPreDate);
		query.setParameter("examPreTime", examPreTime);
		query.setParameter("doctorCode", doctorCode);

		List<String> list = query.getResultList();

		return list;
	}

	@Override
	public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> getNuroReservationScheduleConditionList(String hospitalCode,
																												String examPreDate, String doctorCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.AM_START_HHMM as amStartTime,                                                           ");
		sql.append("        A.AM_END_HHMM  as amEndTime,                                                              ");
		sql.append("        A.PM_START_HHMM as pmStartTime,                                                           ");
		sql.append("        A.PM_END_HHMM as pmEndTime                                                                ");
		sql.append(" FROM (                                                                                           ");
		sql.append("        SELECT IFNULL(                                                                            ");
		sql.append("                CASE dayofweek(STR_TO_DATE(:examPreDate, '%Y/%m/%d'))                             ");
		sql.append("                   WHEN '1' THEN A.RES_AM_START_HHMM1                                             ");
		sql.append("                   WHEN '2' THEN A.RES_AM_START_HHMM2                                             ");
		sql.append("                   WHEN '3' THEN A.RES_AM_START_HHMM3                                             ");
		sql.append("                   WHEN '4' THEN A.RES_AM_START_HHMM4                                             ");
		sql.append("                   WHEN '5' THEN A.RES_AM_START_HHMM5                                             ");
		sql.append("                   WHEN '6' THEN A.RES_AM_START_HHMM6                                             ");
		sql.append("                   WHEN '7' THEN A.RES_AM_START_HHMM7                                             ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') AM_START_HHMM,                                                       ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(STR_TO_DATE(:examPreDate, '%Y/%m/%d'))                             ");
		sql.append("                   WHEN '1' THEN A.RES_AM_END_HHMM1                                               ");
		sql.append("                   WHEN '2' THEN A.RES_AM_END_HHMM2                                               ");
		sql.append("                   WHEN '3' THEN A.RES_AM_END_HHMM3                                               ");
		sql.append("                   WHEN '4' THEN A.RES_AM_END_HHMM4                                               ");
		sql.append("                   WHEN '5' THEN A.RES_AM_END_HHMM5                                               ");
		sql.append("                   WHEN '6' THEN A.RES_AM_END_HHMM6                                               ");
		sql.append("                   WHEN '7' THEN A.RES_AM_END_HHMM7                                               ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') AM_END_HHMM,                                                         ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(STR_TO_DATE(:examPreDate, '%Y/%m/%d'))                             ");
		sql.append("                   WHEN '1' THEN A.RES_PM_START_HHMM1                                             ");
		sql.append("                   WHEN '2' THEN A.RES_PM_START_HHMM2                                             ");
		sql.append("                   WHEN '3' THEN A.RES_PM_START_HHMM3                                             ");
		sql.append("                   WHEN '4' THEN A.RES_PM_START_HHMM4                                             ");
		sql.append("                   WHEN '5' THEN A.RES_PM_START_HHMM5                                             ");
		sql.append("                   WHEN '6' THEN A.RES_PM_START_HHMM6                                             ");
		sql.append("                   WHEN '7' THEN A.RES_PM_START_HHMM7                                             ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') PM_START_HHMM,                                                       ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(STR_TO_DATE(:examPreDate, '%Y/%m/%d'))                             ");
		sql.append("                   WHEN '1' THEN A.RES_PM_END_HHMM1                                               ");
		sql.append("                   WHEN '2' THEN A.RES_PM_END_HHMM2                                               ");
		sql.append("                   WHEN '3' THEN A.RES_PM_END_HHMM3                                               ");
		sql.append("                   WHEN '4' THEN A.RES_PM_END_HHMM4                                               ");
		sql.append("                   WHEN '5' THEN A.RES_PM_END_HHMM5                                               ");
		sql.append("                   WHEN '6' THEN A.RES_PM_END_HHMM6                                               ");
		sql.append("                   WHEN '7' THEN A.RES_PM_END_HHMM7                                               ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') PM_END_HHMM                                                          ");
		sql.append("        FROM RES0102 A                                                                            ");
		sql.append("        WHERE A.HOSP_CODE  = :hospitalCode                                                        ");
		sql.append("                AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                                          ");
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("                AND A.DOCTOR     = :doctorCode                                                    ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("                AND STR_TO_DATE(:examPreDate, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE     ");
		}
		sql.append("        ) A                                                                                       ");
		sql.append("limit 0,1		                                                                                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		query.setParameter("examPreDate", examPreDate);

		List<NuroRES1001U00ReservationScheduleConditionListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00ReservationScheduleConditionListItemInfo.class);

		return list;
	}

	@Override
	public List<NuroRES1001U00AverageTimeListItemInfo> getAverageTimeList(String hospitalCode, String examPreDate, String doctorCode) {


		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.AVG_TIME, 10) avg_time,                                                       ");
		sql.append("         IFNULL(A.DOC_RES_LIMIT, 1) doc_res_limit                                              ");
		sql.append(" FROM RES0102 A                                                                                ");
		sql.append("         WHERE A.HOSP_CODE  = :hospitalCode                                                    ");
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("        AND A.DOCTOR     = :doctorCode                                                      ");
		}
		sql.append("        AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                                                ");
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("        AND STR_TO_DATE(:examPreDate, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE       ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate", examPreDate);
		}

		List<NuroRES1001U00AverageTimeListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00AverageTimeListItemInfo.class);

		return list;
	}
	
	@Override
	public boolean updateNuroRES0102U00UpdateRES0102Info(String hospCode, NuroRES0102U00UpdateRES0102Info nuroRES0102U00UpdateRES0102Info){
		try {
			StringBuilder sql = new StringBuilder();
			sql.append("UPDATE RES0102                                                      ");
			sql.append("SET UPD_ID             = :q_user_id            ,                    ");
			sql.append("   UPD_DATE           = SYSDATE()               ,                   ");
			sql.append("   AVG_TIME           = :f_avg_time           ,                     ");
			sql.append("   JINRYO_BREAK_YN    = :f_jinryo_break_yn    ,                     ");
			sql.append("   AM_START_HHMM1     = :f_am_start_hhmm1     ,                     ");
			sql.append("   AM_START_HHMM2     = :f_am_start_hhmm2     ,                     ");
			sql.append("   AM_START_HHMM3     = :f_am_start_hhmm3     ,                     ");
			sql.append("   AM_START_HHMM4     = :f_am_start_hhmm4     ,                     ");
			sql.append("   AM_START_HHMM5     = :f_am_start_hhmm5     ,                     ");
			sql.append("   AM_START_HHMM6     = :f_am_start_hhmm6     ,                     ");
			sql.append("   AM_START_HHMM7     = :f_am_start_hhmm7     ,                     ");
			sql.append("   AM_END_HHMM1       = :f_am_end_hhmm1       ,                     ");
			sql.append("   AM_END_HHMM2       = :f_am_end_hhmm2       ,                     ");
			sql.append("   AM_END_HHMM3       = :f_am_end_hhmm3       ,                     ");
			sql.append("   AM_END_HHMM4       = :f_am_end_hhmm4       ,                     ");
			sql.append("   AM_END_HHMM5       = :f_am_end_hhmm5       ,                     ");
			sql.append("   AM_END_HHMM6       = :f_am_end_hhmm6       ,                     ");
			sql.append("   AM_END_HHMM7       = :f_am_end_hhmm7       ,                     ");
			sql.append("   PM_START_HHMM1     = :f_pm_start_hhmm1     ,                     ");
			sql.append("   PM_START_HHMM2     = :f_pm_start_hhmm2     ,                     ");
			sql.append("   PM_START_HHMM3     = :f_pm_start_hhmm3     ,                     ");
			sql.append("   PM_START_HHMM4     = :f_pm_start_hhmm4     ,                     ");
			sql.append("   PM_START_HHMM5     = :f_pm_start_hhmm5     ,                     ");
			sql.append("   PM_START_HHMM6     = :f_pm_start_hhmm6     ,                     ");
			sql.append("   PM_START_HHMM7     = :f_pm_start_hhmm7     ,                     ");
			sql.append("   PM_END_HHMM1       = :f_pm_end_hhmm1       ,                     ");
			sql.append("   PM_END_HHMM2       = :f_pm_end_hhmm2       ,                     ");
			sql.append("   PM_END_HHMM3       = :f_pm_end_hhmm3       ,                     ");
			sql.append("   PM_END_HHMM4       = :f_pm_end_hhmm4       ,                     ");
			sql.append("   PM_END_HHMM5       = :f_pm_end_hhmm5       ,                     ");
			sql.append("   PM_END_HHMM6       = :f_pm_end_hhmm6       ,                     ");
			sql.append("   PM_END_HHMM7       = :f_pm_end_hhmm7       ,                     ");
			sql.append("   AM_GWA_ROOM1       = :f_am_gwa_room1       ,                     ");
			sql.append("   AM_GWA_ROOM2       = :f_am_gwa_room2       ,                     ");
			sql.append("   AM_GWA_ROOM3       = :f_am_gwa_room3       ,                     ");
			sql.append("   AM_GWA_ROOM4       = :f_am_gwa_room4       ,                     ");
			sql.append("   AM_GWA_ROOM5       = :f_am_gwa_room5       ,                     ");
			sql.append("   AM_GWA_ROOM6       = :f_am_gwa_room6       ,                     ");
			sql.append("   AM_GWA_ROOM7       = :f_am_gwa_room7       ,                     ");
			sql.append("   PM_GWA_ROOM1       = :f_pm_gwa_room1       ,                     ");
			sql.append("   PM_GWA_ROOM2       = :f_pm_gwa_room2       ,                     ");
			sql.append("   PM_GWA_ROOM3       = :f_pm_gwa_room3       ,                     ");
			sql.append("   PM_GWA_ROOM4       = :f_pm_gwa_room4       ,                     ");
			sql.append("   PM_GWA_ROOM5       = :f_pm_gwa_room5       ,                     ");
			sql.append("   PM_GWA_ROOM6       = :f_pm_gwa_room6       ,                     ");
			sql.append("   PM_GWA_ROOM7       = :f_pm_gwa_room7       ,                     ");
			sql.append("   RES_AM_START_HHMM1 = :f_res_am_start_hhmm1 ,                     ");
			sql.append("   RES_AM_START_HHMM2 = :f_res_am_start_hhmm2 ,                     ");
			sql.append("   RES_AM_START_HHMM3 = :f_res_am_start_hhmm3 ,                     ");
			sql.append("   RES_AM_START_HHMM4 = :f_res_am_start_hhmm4 ,                     ");
			sql.append("   RES_AM_START_HHMM5 = :f_res_am_start_hhmm5 ,                     ");
			sql.append("   RES_AM_START_HHMM6 = :f_res_am_start_hhmm6 ,                     ");
			sql.append("   RES_AM_START_HHMM7 = :f_res_am_start_hhmm7 ,                     ");
			sql.append("   RES_AM_END_HHMM1   = :f_res_am_end_hhmm1   ,                     ");
			sql.append("   RES_AM_END_HHMM2   = :f_res_am_end_hhmm2   ,                     ");
			sql.append("   RES_AM_END_HHMM3   = :f_res_am_end_hhmm3   ,                     ");
			sql.append("   RES_AM_END_HHMM4   = :f_res_am_end_hhmm4   ,                     ");
			sql.append("   RES_AM_END_HHMM5   = :f_res_am_end_hhmm5   ,                     ");
			sql.append("   RES_AM_END_HHMM6   = :f_res_am_end_hhmm6   ,                     ");
			sql.append("   RES_AM_END_HHMM7   = :f_res_am_end_hhmm7   ,                     ");
			sql.append("   RES_PM_START_HHMM1 = :f_res_pm_start_hhmm1 ,                     ");
			sql.append("   RES_PM_START_HHMM2 = :f_res_pm_start_hhmm2 ,                     ");
			sql.append("   RES_PM_START_HHMM3 = :f_res_pm_start_hhmm3 ,                     ");
			sql.append("   RES_PM_START_HHMM4 = :f_res_pm_start_hhmm4 ,                     ");
			sql.append("   RES_PM_START_HHMM5 = :f_res_pm_start_hhmm5 ,                     ");
			sql.append("   RES_PM_START_HHMM6 = :f_res_pm_start_hhmm6 ,                     ");
			sql.append("   RES_PM_START_HHMM7 = :f_res_pm_start_hhmm7 ,                     ");
			sql.append("   RES_PM_END_HHMM1   = :f_res_pm_end_hhmm1   ,                     ");
			sql.append("   RES_PM_END_HHMM2   = :f_res_pm_end_hhmm2   ,                     ");
			sql.append("   RES_PM_END_HHMM3   = :f_res_pm_end_hhmm3   ,                     ");
			sql.append("   RES_PM_END_HHMM4   = :f_res_pm_end_hhmm4   ,                     ");
			sql.append("   RES_PM_END_HHMM5   = :f_res_pm_end_hhmm5   ,                     ");
			sql.append("   RES_PM_END_HHMM6   = :f_res_pm_end_hhmm6   ,                     ");
			sql.append("   RES_PM_END_HHMM7   = :f_res_pm_end_hhmm7   ,                     ");
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getDocResLimit())) {
				sql.append("   DOC_RES_LIMIT      = :f_doc_res_limit      ,                 ");
			}
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getEtcResLimit())) {
				sql.append("   ETC_RES_LIMIT      = :f_etc_res_limit      ,                 ");
			}
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getOutHospResLimit())) {
				sql.append("   OUT_HOSP_RES_LIMIT      = :f_out_hosp_res_limit      ,                 ");
			}
			sql.append("   END_DATE           = STR_TO_DATE(:f_end_date, '%Y/%m/%d')        ");
			sql.append("WHERE HOSP_CODE          = :f_hosp_code                             ");
			sql.append("  AND DOCTOR             = :f_doctor                                ");
			sql.append("  AND DATE_FORMAT(START_DATE, '%Y/%m/%d')         = DATE_FORMAT(:f_start_date, '%Y/%m/%d')   ");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("q_user_id", nuroRES0102U00UpdateRES0102Info.getUserId());
			query.setParameter("f_avg_time", nuroRES0102U00UpdateRES0102Info.getAvgTime());
			query.setParameter("f_jinryo_break_yn", nuroRES0102U00UpdateRES0102Info.getJinryoBreakYn());
			query.setParameter("f_am_start_hhmm1", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm1());
			query.setParameter("f_am_start_hhmm2", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm2());
			query.setParameter("f_am_start_hhmm3", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm3());
			query.setParameter("f_am_start_hhmm4", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm4());
			query.setParameter("f_am_start_hhmm5", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm5());
			query.setParameter("f_am_start_hhmm6", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm6());
			query.setParameter("f_am_start_hhmm7", nuroRES0102U00UpdateRES0102Info.getAmStartHhmm7());
			query.setParameter("f_am_end_hhmm1", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm1());
			query.setParameter("f_am_end_hhmm2", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm2());
			query.setParameter("f_am_end_hhmm3", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm3());
			query.setParameter("f_am_end_hhmm4", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm4());
			query.setParameter("f_am_end_hhmm5", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm5());
			query.setParameter("f_am_end_hhmm6", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm6());
			query.setParameter("f_am_end_hhmm7", nuroRES0102U00UpdateRES0102Info.getAmEndHhmm7());
			query.setParameter("f_pm_start_hhmm1", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm1());
			query.setParameter("f_pm_start_hhmm2", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm2());
			query.setParameter("f_pm_start_hhmm3", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm3());
			query.setParameter("f_pm_start_hhmm4", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm4());
			query.setParameter("f_pm_start_hhmm5", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm5());
			query.setParameter("f_pm_start_hhmm6", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm6());
			query.setParameter("f_pm_start_hhmm7", nuroRES0102U00UpdateRES0102Info.getPmStartHhmm7());
			query.setParameter("f_pm_end_hhmm1", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm1());
			query.setParameter("f_pm_end_hhmm2", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm2());
			query.setParameter("f_pm_end_hhmm3", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm3());
			query.setParameter("f_pm_end_hhmm4", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm4());
			query.setParameter("f_pm_end_hhmm5", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm5());
			query.setParameter("f_pm_end_hhmm6", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm6());
			query.setParameter("f_pm_end_hhmm7", nuroRES0102U00UpdateRES0102Info.getPmEndHhmm7());
			query.setParameter("f_am_gwa_room1", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom1());
			query.setParameter("f_am_gwa_room2", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom2());
			query.setParameter("f_am_gwa_room3", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom3());
			query.setParameter("f_am_gwa_room4", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom4());
			query.setParameter("f_am_gwa_room5", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom5());
			query.setParameter("f_am_gwa_room6", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom6());
			query.setParameter("f_am_gwa_room7", nuroRES0102U00UpdateRES0102Info.getAmGwaRoom7());
			query.setParameter("f_pm_gwa_room1", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom1());
			query.setParameter("f_pm_gwa_room2", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom2());
			query.setParameter("f_pm_gwa_room3", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom3());
			query.setParameter("f_pm_gwa_room4", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom4());
			query.setParameter("f_pm_gwa_room5", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom5());
			query.setParameter("f_pm_gwa_room6", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom6());
			query.setParameter("f_pm_gwa_room7", nuroRES0102U00UpdateRES0102Info.getPmGwaRoom7());
			query.setParameter("f_res_am_start_hhmm1", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm1());
			query.setParameter("f_res_am_start_hhmm2", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm2());
			query.setParameter("f_res_am_start_hhmm3", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm3());
			query.setParameter("f_res_am_start_hhmm4", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm4());
			query.setParameter("f_res_am_start_hhmm5", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm5());
			query.setParameter("f_res_am_start_hhmm6", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm6());
			query.setParameter("f_res_am_start_hhmm7", nuroRES0102U00UpdateRES0102Info.getResAmStartHhmm7());
			query.setParameter("f_res_am_end_hhmm1", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm1());
			query.setParameter("f_res_am_end_hhmm2", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm2());
			query.setParameter("f_res_am_end_hhmm3", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm3());
			query.setParameter("f_res_am_end_hhmm4", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm4());
			query.setParameter("f_res_am_end_hhmm5", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm5());
			query.setParameter("f_res_am_end_hhmm6", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm6());
			query.setParameter("f_res_am_end_hhmm7", nuroRES0102U00UpdateRES0102Info.getResAmEndHhmm7());
			query.setParameter("f_res_pm_start_hhmm1", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm1());
			query.setParameter("f_res_pm_start_hhmm2", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm2());
			query.setParameter("f_res_pm_start_hhmm3", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm3());
			query.setParameter("f_res_pm_start_hhmm4", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm4());
			query.setParameter("f_res_pm_start_hhmm5", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm5());
			query.setParameter("f_res_pm_start_hhmm6", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm6());
			query.setParameter("f_res_pm_start_hhmm7", nuroRES0102U00UpdateRES0102Info.getResPmStartHhmm7());
			query.setParameter("f_res_pm_end_hhmm1", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm1());
			query.setParameter("f_res_pm_end_hhmm2", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm2());
			query.setParameter("f_res_pm_end_hhmm3", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm3());
			query.setParameter("f_res_pm_end_hhmm4", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm4());
			query.setParameter("f_res_pm_end_hhmm5", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm5());
			query.setParameter("f_res_pm_end_hhmm6", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm6());
			query.setParameter("f_res_pm_end_hhmm7", nuroRES0102U00UpdateRES0102Info.getResPmEndHhmm7());
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getDocResLimit())) {
				query.setParameter("f_doc_res_limit", nuroRES0102U00UpdateRES0102Info.getDocResLimit());
			}
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getEtcResLimit())) {
				query.setParameter("f_etc_res_limit", nuroRES0102U00UpdateRES0102Info.getEtcResLimit());
			}
			if(!StringUtils.isEmpty(nuroRES0102U00UpdateRES0102Info.getOutHospResLimit())) {
				query.setParameter("f_out_hosp_res_limit", nuroRES0102U00UpdateRES0102Info.getOutHospResLimit());
			}
			query.setParameter("f_end_date", nuroRES0102U00UpdateRES0102Info.getEndDate());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_doctor", nuroRES0102U00UpdateRES0102Info.getDoctor());
			query.setParameter("f_start_date", nuroRES0102U00UpdateRES0102Info.getStartDate());
			      
			query.executeUpdate();
			return true;
		}catch (Exception ex) {
			LOGGER.error(ex.getMessage(),ex);
			return false;
		}
	}

	@Override
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> getOcsaOCS0503U00GetFindWorkerListInfoProcess3(
			String hospCode,String naweonDate,String refCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT C.DOCTOR,                                                    ");        
		sql.append(" C.DOCTOR_NAME,                                                      ");        
		sql.append(" (CASE                                                               ");        
		sql.append(" WHEN C.AM_START_HHMM IS NOT NULL AND C.PM_START_HHMM IS NOT NULL    ");        
		sql.append(" THEN 'AM/PM'                                                        ");        
		sql.append(" WHEN C.AM_START_HHMM IS NOT NULL AND C.PM_START_HHMM IS NULL        ");        
		sql.append(" THEN 'AM'                                                           ");        
		sql.append(" WHEN C.AM_START_HHMM IS NULL AND C.PM_START_HHMM IS NOT NULL        ");        
		sql.append(" THEN 'PM'                                                           ");        
		sql.append(" END) AMPM                                                           ");        
		sql.append(" FROM ( SELECT A.DOCTOR                                              ");        
		sql.append(" ,B.DOCTOR_NAME                                                      ");        
		sql.append(" ,A.JINRYO_BREAK_YN                                                  ");        
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))        ");        
		sql.append(" when 1 then A.RES_PM_END_HHMM1                                      ");        
		sql.append(" when 2 then A.RES_PM_END_HHMM2                                      ");        
		sql.append(" when 3 then A.RES_PM_END_HHMM3                                      ");        
		sql.append(" when 4 then A.RES_PM_END_HHMM4                                      ");        
		sql.append(" when 5 then A.RES_PM_END_HHMM5                                      ");        
		sql.append(" when 6 then A.RES_PM_END_HHMM6                                      ");        
		sql.append(" when 7 then A.RES_PM_END_HHMM7                                      ");        
		sql.append(" end AM_START_HHMM                                                   ");        
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))        ");
		sql.append(" when 1 then A.RES_PM_END_HHMM1                                      ");        
		sql.append(" when 2 then A.RES_AM_END_HHMM2                                      ");        
		sql.append(" when 3 then A.RES_AM_END_HHMM3                                      ");        
		sql.append(" when 4 then A.RES_AM_END_HHMM4                                      ");        
		sql.append(" when 5 then A.RES_AM_END_HHMM5                                      ");        
		sql.append(" when 6 then A.RES_AM_END_HHMM6                                      ");        
		sql.append(" when 7 then A.RES_AM_END_HHMM7                                      ");       
		sql.append(" end AM_END_HHMM                                                     ");       
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))        ");       
		sql.append(" when 1 then A.RES_PM_END_HHMM1                                      ");       
		sql.append(" when 2 then A.RES_PM_END_HHMM2                                      ");       
		sql.append(" when 3 then A.RES_PM_END_HHMM3                                      ");       
		sql.append(" when 4 then A.RES_PM_END_HHMM4                                      ");       
		sql.append(" when 5 then A.RES_PM_END_HHMM5                                      ");       
		sql.append(" when 6 then A.RES_PM_END_HHMM6                                      ");       
		sql.append(" when 7 then A.RES_PM_END_HHMM7                                      ");       
		sql.append(" end PM_START_HHMM                                                   ");       
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))        ");       
		sql.append(" when 1 then A.RES_PM_END_HHMM1                                      ");       
		sql.append(" when 2 then A.RES_PM_END_HHMM2                                      ");       
		sql.append(" when 3 then A.RES_PM_END_HHMM3                                      ");       
		sql.append(" when 4 then A.RES_PM_END_HHMM4                                      ");       
		sql.append(" when 5 then A.RES_PM_END_HHMM5                                      ");       
		sql.append(" when 6 then A.RES_PM_END_HHMM6                                      ");       
		sql.append(" when 7 then A.RES_PM_END_HHMM7                                      ");       
		sql.append(" end PM_END_HHMM                                                     ");       
		sql.append(" FROM RES0102 A                                                      ");       
		sql.append(" ,( SELECT X.DOCTOR                                                  ");       
		sql.append(" ,X.DOCTOR_NAME                                                      ");       
		sql.append(" FROM BAS0270 X                                                      ");       
		sql.append(" WHERE X.HOSP_CODE  = :f_hosp_code                                   ");       
		sql.append(" AND X.DOCTOR_GWA = :f_ref_code) B                                   ");       
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                   ");       
		sql.append(" AND A.DOCTOR     = B.DOCTOR                                         ");       
		sql.append(" AND A.START_DATE = ( SELECT MAX( Z.START_DATE )                     ");       
		sql.append(" FROM RES0102 Z                                                      ");       
		sql.append(" WHERE Z.HOSP_CODE   = :f_hosp_code                                  ");       
		sql.append(" AND Z.DOCTOR      = B.DOCTOR                                        ");       
		sql.append(" AND Z.START_DATE <= STR_TO_DATE( :f_naewon_date,'%Y/%m/%d' ))       ");                  
		sql.append(" AND A.JINRYO_BREAK_YN != 'Y' ) C                                    ");       
		sql.append(" WHERE C.AM_START_HHMM IS NOT NULL                                   ");       
		sql.append(" OR C.PM_START_HHMM IS NOT NULL                                      ");       
		sql.append(" ORDER BY 1                                                          ");       
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_naewon_date", naweonDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ref_code", refCode);
		List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> listWorker= new JpaResultMapper().list(query, OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2.class); 
		return listWorker;
	}

	@Override
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> getOcsaOCS0503U00GetFindWorkerListInfoProcess4(String hospCode,String naweonDate,String refCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT C.DOCTOR,                                                                 ");
		sql.append(" C.DOCTOR_NAME,                                                                   ");
		sql.append(" (CASE                                                                            ");
		sql.append(" WHEN C.AM_START_HHMM IS NOT NULL AND C.PM_START_HHMM IS NOT NULL                 ");
		sql.append(" THEN 'AM/PM'                                                                     ");
		sql.append(" WHEN C.AM_START_HHMM IS NOT NULL AND C.PM_START_HHMM IS NULL                     ");
		sql.append(" THEN 'AM'                                                                        ");
		sql.append(" WHEN C.AM_START_HHMM IS NULL AND C.PM_START_HHMM IS NOT NULL                     ");
		sql.append(" THEN 'PM'                                                                        ");
		sql.append(" END) AMPM                                                                        ");
		sql.append(" FROM ( SELECT A.DOCTOR                                                           ");
		sql.append(" ,B.DOCTOR_NAME                                                                   ");
		sql.append(" ,A.JINRYO_BREAK_YN                                                               ");
		sql.append("                                                                                  ");
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))                     ");
		sql.append("  when 1 then AM_START_HHMM1                                                      ");
		sql.append("  when 2 then AM_START_HHMM2                                                      ");
		sql.append("  when 3 then AM_START_HHMM3                                                      ");
		sql.append("  when 4 then AM_START_HHMM4                                                      ");
		sql.append("  when 5 then AM_START_HHMM5                                                      ");
		sql.append("  when 6 then AM_START_HHMM6                                                      ");
		sql.append("  when 7 then AM_START_HHMM7                                                      ");
		sql.append("  end AM_START_HHMM                                                               ");
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))                     ");
		sql.append("  when 1 then A.AM_END_HHMM1                                                      ");
		sql.append("  when 2 then A.AM_END_HHMM2                                                      ");
		sql.append("  when 3 then A.AM_END_HHMM3                                                      ");
		sql.append("  when 4 then A.AM_END_HHMM4                                                      ");
		sql.append("  when 5 then A.AM_END_HHMM5                                                      ");
		sql.append("  when 6 then A.AM_END_HHMM6                                                      ");
		sql.append("  when 7 then A.AM_END_HHMM7                                                      ");
		sql.append("  end AM_END_HHMM                                                                 ");
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))                     ");
		sql.append("  when 1 then A.PM_START_HHMM1                                                    ");
		sql.append("  when 2 then A.PM_START_HHMM2                                                    ");
		sql.append("  when 3 then A.PM_START_HHMM3                                                    ");
		sql.append("  when 4 then A.PM_START_HHMM4                                                    ");
		sql.append("  when 5 then A.PM_START_HHMM5                                                    ");
		sql.append("  when 6 then A.PM_START_HHMM6                                                    ");
		sql.append("  when 7 then A.PM_START_HHMM7                                                    ");
		sql.append("  end PM_START_HHMM                                                               ");
		sql.append(" ,case DAYOFWEEK ( STR_TO_DATE ( :f_naewon_date ,'%Y/%m/%d'))                     ");
		sql.append("  when 1 then A.PM_END_HHMM1                                                      ");
		sql.append("  when 2 then A.PM_END_HHMM2                                                      ");
		sql.append("  when 3 then A.PM_END_HHMM3                                                      ");
		sql.append("  when 4 then A.PM_END_HHMM4                                                      ");
		sql.append("  when 5 then A.PM_END_HHMM5                                                      ");
		sql.append("  when 6 then A.PM_END_HHMM6                                                      ");
		sql.append("  when 7 then A.PM_END_HHMM7                                                      ");
		sql.append("  end PM_END_HHMM                                                                 ");
		sql.append(" FROM RES0102 A                                                                   ");
		sql.append(" ,( SELECT X.DOCTOR                                                               ");
		sql.append(" ,X.DOCTOR_NAME                                                                   ");
		sql.append(" FROM BAS0270 X                                                                   ");
		sql.append(" WHERE X.HOSP_CODE  = :f_hosp_code                                                ");
		sql.append(" AND X.DOCTOR_GWA = :f_ref_code) B                                                ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                ");
		sql.append(" AND A.DOCTOR     = B.DOCTOR                                                      ");
		sql.append(" AND A.START_DATE = ( SELECT MAX( Z.START_DATE )                                  ");
		sql.append(" FROM RES0102 Z                                                                   ");
		sql.append(" WHERE Z.HOSP_CODE   = :f_hosp_code                                               ");
		sql.append(" AND Z.DOCTOR      = B.DOCTOR                                                     ");
		sql.append(" AND Z.START_DATE <= STR_TO_DATE( :f_naewon_date,'%Y/%m/%d' ))                    ");
		sql.append(" AND A.JINRYO_BREAK_YN != 'Y' ) C                                                 ");
		sql.append(" WHERE C.AM_START_HHMM IS NOT NULL                                                ");
		sql.append(" OR C.PM_START_HHMM IS NOT NULL                                                   ");
		sql.append(" ORDER BY 1                                                                       ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_naewon_date", naweonDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ref_code", refCode);
		List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> listWorker= new JpaResultMapper().list(query, OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2.class);
		return listWorker;
	}
	
	@Override
	public List<RES1001U00FrmModifyReserGrdRES1001Info> getRES1001U00FrmModifyReserGrdRES1001Info(String intWeek, String hospCode, String doctor, String date) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT IFNULL(RES_AM_START_HHMM" + intWeek + " ,'0000') AS AM_START,   ");               
		sql.append("       IFNULL(RES_AM_END_HHMM" + intWeek + " ,'0000') AS AM_END,       ");
		sql.append("       IFNULL(RES_PM_START_HHMM" + intWeek + " ,'0000') AS PM_START,   ");
		sql.append("       IFNULL(RES_PM_END_HHMM" + intWeek + " ,'0000') AS PM_END,       ");
		sql.append("  AVG_TIME                                                             ");
		sql.append("  FROM RES0102                                                         ");
		sql.append("  WHERE HOSP_CODE = :hospCode                                          ");
		sql.append("   AND DOCTOR = :doctor                                                ");
		sql.append("   AND STR_TO_DATE(:date, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE  ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);
		List<RES1001U00FrmModifyReserGrdRES1001Info> listItem= new JpaResultMapper().list(query, RES1001U00FrmModifyReserGrdRES1001Info.class);
		return listItem;
	}

	@Override
	public List<OcsaOCS0503U00CreateTimeComboInfo> createTimeComboOCS0503U00(String hospCode, String doctor, String intweek, Date date) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT RES_AM_START_HHMM");
		sql.append(intweek);
		sql.append(" AS AM_START,                                ");
		sql.append(" RES_AM_END_HHMM");
		sql.append(intweek);
		sql.append(" AS AM_END  ,                                ");
		sql.append(" RES_PM_START_HHMM");
		sql.append(intweek);
		sql.append(" AS PM_START,                                ");
		sql.append(" RES_PM_END_HHMM");
		sql.append(intweek);
		sql.append(" AS PM_END  ,                                ");
		sql.append(" AVG_TIME                                    ");
		sql.append(" FROM RES0102                                ");
		sql.append(" WHERE DOCTOR = :f_doctor                    ");
		sql.append(" AND HOSP_CODE = :f_hosp_code                ");
		sql.append(" AND :f_date BETWEEN START_DATE AND END_DATE ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_date", date);
		List<OcsaOCS0503U00CreateTimeComboInfo> listItem= new JpaResultMapper().list(query, OcsaOCS0503U00CreateTimeComboInfo.class);
		return listItem;
	}

	@Override
	public List<KCCKGetDoctorWorkingTimeInfo> getKCCKGetScheduleDoctorInfo(String hospitalCode, Date examPreDate, String doctorCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.AM_START_HHMM as amStartTime,                                                           ");
		sql.append("        A.AM_END_HHMM  as amEndTime,                                                              ");
		sql.append("        A.PM_START_HHMM as pmStartTime,                                                           ");
		sql.append("        A.PM_END_HHMM as pmEndTime , CAST(A.AVG_TIME AS CHAR) avgTime                             ");
		sql.append(" FROM (                                                                                           ");
		sql.append("        SELECT IFNULL(                                                                            ");
		sql.append("                CASE dayofweek(:examPreDate)                                                      ");
		sql.append("                   WHEN '1' THEN A.RES_AM_START_HHMM1                                             ");
		sql.append("                   WHEN '2' THEN A.RES_AM_START_HHMM2                                             ");
		sql.append("                   WHEN '3' THEN A.RES_AM_START_HHMM3                                             ");
		sql.append("                   WHEN '4' THEN A.RES_AM_START_HHMM4                                             ");
		sql.append("                   WHEN '5' THEN A.RES_AM_START_HHMM5                                             ");
		sql.append("                   WHEN '6' THEN A.RES_AM_START_HHMM6                                             ");
		sql.append("                   WHEN '7' THEN A.RES_AM_START_HHMM7                                             ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') AM_START_HHMM,                                                       ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(:examPreDate)                                                      ");
		sql.append("                   WHEN '1' THEN A.RES_AM_END_HHMM1                                               ");
		sql.append("                   WHEN '2' THEN A.RES_AM_END_HHMM2                                               ");
		sql.append("                   WHEN '3' THEN A.RES_AM_END_HHMM3                                               ");
		sql.append("                   WHEN '4' THEN A.RES_AM_END_HHMM4                                               ");
		sql.append("                   WHEN '5' THEN A.RES_AM_END_HHMM5                                               ");
		sql.append("                   WHEN '6' THEN A.RES_AM_END_HHMM6                                               ");
		sql.append("                   WHEN '7' THEN A.RES_AM_END_HHMM7                                               ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') AM_END_HHMM,                                                         ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(:examPreDate)                                                      ");
		sql.append("                   WHEN '1' THEN A.RES_PM_START_HHMM1                                             ");
		sql.append("                   WHEN '2' THEN A.RES_PM_START_HHMM2                                             ");
		sql.append("                   WHEN '3' THEN A.RES_PM_START_HHMM3                                             ");
		sql.append("                   WHEN '4' THEN A.RES_PM_START_HHMM4                                             ");
		sql.append("                   WHEN '5' THEN A.RES_PM_START_HHMM5                                             ");
		sql.append("                   WHEN '6' THEN A.RES_PM_START_HHMM6                                             ");
		sql.append("                   WHEN '7' THEN A.RES_PM_START_HHMM7                                             ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') PM_START_HHMM,                                                       ");
		sql.append("                IFNULL(                                                                           ");
		sql.append("                CASE dayofweek(:examPreDate)                                                      ");
		sql.append("                   WHEN '1' THEN A.RES_PM_END_HHMM1                                               ");
		sql.append("                   WHEN '2' THEN A.RES_PM_END_HHMM2                                               ");
		sql.append("                   WHEN '3' THEN A.RES_PM_END_HHMM3                                               ");
		sql.append("                   WHEN '4' THEN A.RES_PM_END_HHMM4                                               ");
		sql.append("                   WHEN '5' THEN A.RES_PM_END_HHMM5                                               ");
		sql.append("                   WHEN '6' THEN A.RES_PM_END_HHMM6                                               ");
		sql.append("                   WHEN '7' THEN A.RES_PM_END_HHMM7                                               ");
		sql.append("                   ELSE NULL                                                                      ");
		sql.append("                   END                                                                            ");
		sql.append("                   , '0000') PM_END_HHMM , A.AVG_TIME                                             ");
		sql.append("        FROM RES0102 A                                                                            ");
		sql.append("        WHERE A.HOSP_CODE  = :hospitalCode                                                        ");
		sql.append("                AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                                          ");
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("                AND A.DOCTOR     = :doctorCode                                                ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("                AND :examPreDate BETWEEN A.START_DATE AND A.END_DATE                           ");
		}
		sql.append("        ) A                                                                                        ");
		sql.append("limit 0,1		                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		query.setParameter("examPreDate", examPreDate);

		List<KCCKGetDoctorWorkingTimeInfo> list = new JpaResultMapper().list(query, KCCKGetDoctorWorkingTimeInfo.class);

		return list;
	}

	@Override
	public List<KCCKGetLimitScheduleDoctorInfo> getKCCKGetLimitScheduleDoctorInfo(String hospitalCode,
			Date examPreDate, String doctorCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  CAST(A.DOC_RES_LIMIT AS CHAR)                                                         ");
		sql.append("         , CAST(A.ETC_RES_LIMIT AS CHAR)                                                       ");
		sql.append("         , CAST(A.OUT_HOSP_RES_LIMIT AS CHAR)                                                  ");
		sql.append("  FROM RES0102 A                                                                 ");
		sql.append("  WHERE A.HOSP_CODE  = :hospitalCode                                             ");
		sql.append("  AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                                       ");
		sql.append("  AND A.DOCTOR     = :doctorCode                                                 ");
		sql.append("  AND :examPreDate BETWEEN A.START_DATE AND A.END_DATE  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		query.setParameter("examPreDate", examPreDate);
		List<KCCKGetLimitScheduleDoctorInfo> list = new JpaResultMapper().list(query, KCCKGetLimitScheduleDoctorInfo.class);

		return list;
	}

	@Override
	public List<KCCKScheduleDoctorStartEndDateHistory> getKCCKScheduleDoctorStartEndTime(String hospCode, String doctor, Date startDate, Date endDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  A.START_DATE                                     ");
		sql.append("         , A.END_DATE                                     ");
		sql.append("  FROM RES0102 A                                          ");
		sql.append("  WHERE A.HOSP_CODE  = :hospitalCode                      ");
		sql.append("  AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                ");
		sql.append("  AND A.DOCTOR     = :doctorCode                          ");
		sql.append("  AND :startDate BETWEEN A.START_DATE AND A.END_DATE    ");
		sql.append(" UNION                                                    ");
		sql.append(" SELECT  A.START_DATE                                     ");
		sql.append("         , A.END_DATE                                     ");
		sql.append("  FROM RES0102 A                                          ");
		sql.append("  WHERE A.HOSP_CODE  = :hospitalCode                      ");
		sql.append("  AND IFNULL(A.JINRYO_BREAK_YN, 'N') = 'N'                ");
		sql.append("  AND A.DOCTOR     = :doctorCode                          ");
		sql.append("  AND :endDate BETWEEN A.START_DATE AND A.END_DATE    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("doctorCode", doctor);
		query.setParameter("startDate", startDate);
		query.setParameter("endDate", endDate);
		List<KCCKScheduleDoctorStartEndDateHistory> list = new JpaResultMapper().list(query, KCCKScheduleDoctorStartEndDateHistory.class);

		return list;
	}

	@Override
	public List<DoctorScheduleInfo> findScheduleByCondition(String hospCode, String departmentCode, String startDate, String endDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT C.DOCTOR_GRADE, A.GWA, B.DOCTOR, DATE_FORMAT(A.START_DATE, '%Y%m%d'), DATE_FORMAT(A.END_DATE, '%Y%m%d'), CAST(A.AVG_TIME AS CHAR),		");
		sql.append("        CAST(A.ETC_RES_LIMIT AS CHAR),CAST(A.DOC_RES_LIMIT AS CHAR), A.RES_AM_START_HHMM1, A.RES_AM_END_HHMM1, A.RES_PM_START_HHMM1,        	");
		sql.append("        A.RES_PM_END_HHMM1, A.RES_AM_START_HHMM2, A.RES_AM_END_HHMM2, A.RES_PM_START_HHMM2, A.RES_PM_END_HHMM2,             					");
		sql.append("        A.RES_AM_START_HHMM3, A.RES_AM_END_HHMM3, A.RES_PM_START_HHMM3, A.RES_PM_END_HHMM3, A.RES_AM_START_HHMM4,            					");
		sql.append("        A.RES_AM_END_HHMM4, A.RES_PM_START_HHMM4, A.RES_PM_END_HHMM4, A.RES_AM_START_HHMM5, A.RES_AM_END_HHMM5,              					");
		sql.append("        A.RES_PM_START_HHMM5, A.RES_PM_END_HHMM5, A.RES_AM_START_HHMM6, A.RES_AM_END_HHMM6, A.RES_PM_START_HHMM6,            					");
		sql.append("        A.RES_PM_END_HHMM6, A.RES_AM_START_HHMM7, A.RES_AM_END_HHMM7, A.RES_PM_START_HHMM7, A.RES_PM_END_HHMM7              				 	");
		sql.append(" FROM   RES0102 A  ,  BAS0272 B  , BAS0271 C                                                                                                    ");
		sql.append(" WHERE  A.HOSP_CODE = :hospitalCode AND A.START_DATE <= STR_TO_DATE(:startDate,  '%Y%m%d') AND A.END_DATE >= STR_TO_DATE(:startDate,  '%Y%m%d') ");
		sql.append(" AND A.GWA = :departmentCode                                                                                                					");
		sql.append(" AND B.HOSP_CODE = :hospitalCode AND  A.DOCTOR =CONCAT(B.DOCTOR_GWA, B.DOCTOR)  AND B.DOCTOR = C.DOCTOR                                         ");
		sql.append(" ORDER BY A.DOCTOR                                                                                                    		             		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("startDate", startDate);
		//query.setParameter("endDate", endDate);

		List<DoctorScheduleInfo> list = new JpaResultMapper().list(query, DoctorScheduleInfo.class);
		return list;
	}

	@Override
	public List<BookedDetailInfo> findBookDetails(String hospCode, String departmentCode, String startDate, String endDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   DOCTOR, DATE_FORMAT(NAEWON_DATE, '%Y%m%d'), JUBSU_TIME, RES_INPUT_GUBUN                                                              ");
		sql.append(" FROM     OUT1001                                                                                                                              ");
		sql.append(" WHERE    (HOSP_CODE = :hospitalCode OR OUT_HOSP_CODE = :hospitalCode) AND RESER_YN = 'Y' AND NAEWON_DATE >= STR_TO_DATE(:startDate,  '%Y%m%d')           ");
		sql.append("          AND NAEWON_DATE <= STR_TO_DATE(:endDate,  '%Y%m%d') AND GWA = :departmentCode                                                                   ");
		sql.append(" ORDER BY DOCTOR, DATE_FORMAT(NAEWON_DATE, '%Y%m%d')                                                                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("startDate", startDate);
		query.setParameter("endDate", endDate);

		List<BookedDetailInfo> list = new JpaResultMapper().list(query, BookedDetailInfo.class);
		return list;
	}
	
	@Override
	public boolean  isDifferentTimeFrameByCondition(String hospCode, String departmentCode, String startDate, String endDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT 																																			");
		sql.append("   CAST(A.AVG_TIME AS CHAR)  AVG_TIME																												");
		sql.append("  FROM   RES0102 A  ,  BAS0272 B  , BAS0271 C                                                                                                    	");
		sql.append("  WHERE  A.HOSP_CODE = :hospitalCode AND A.START_DATE <= STR_TO_DATE(:startDate,  '%Y%m%d') AND A.END_DATE >= STR_TO_DATE(:startDate,  '%Y%m%d') 	");
		sql.append("  AND A.GWA = :departmentCode                                                                                                						");
		sql.append("  AND B.HOSP_CODE = :hospitalCode AND  A.DOCTOR =CONCAT(B.DOCTOR_GWA, B.DOCTOR)  AND B.DOCTOR = C.DOCTOR         									");
		sql.append("  GROUP BY AVG_TIME 																																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("startDate", startDate);

		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.size() > 1){
			 return true;
		}
		return false;
	}
	
	@Override
	public String  getDepartmentTimeFrameByCondition(String hospCode, String departmentCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  select CAST(A.AVG_TIME AS CHAR)  AVG_TIME from BAS0260 A where A.HOSP_CODE = :hospitalCode and A.GWA = :departmentCode and A.LANGUAGE = :language	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("language", language);

		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		}
		return "30";
	}
}

