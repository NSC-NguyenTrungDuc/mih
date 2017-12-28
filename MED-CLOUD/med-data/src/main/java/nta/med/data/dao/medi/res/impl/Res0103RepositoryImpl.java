package nta.med.data.dao.medi.res.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103Info;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103ResInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00UpdateRES0103Info;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleConditionListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Res0103RepositoryImpl implements Res0103RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Res0103RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuroRES0102U00GrdRES0103Info> getNuroRES0102U00GrdRES0103Info(
			String hospCode, String doctor, String date) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR         ,                                  ");
		sql.append("       A.JINRYO_PRE_DATE,                                  ");
		sql.append("       A.AM_START_HHMM  ,                                  ");
		sql.append("       A.AM_END_HHMM    ,                                  ");
		sql.append("       A.PM_START_HHMM  ,                                  ");
		sql.append("       A.PM_END_HHMM    ,                                  ");
		sql.append("       A.REMARK         ,                                  ");
		sql.append("       A.AM_GWA_ROOM    ,                                  ");
		sql.append("       A.PM_GWA_ROOM                                       ");
		sql.append(" FROM RES0103 A                                            ");
		sql.append(" WHERE A.HOSP_CODE        = :hospCode                      ");
		sql.append("   AND A.DOCTOR           = :doctor                        ");
		sql.append("   AND A.JINRYO_PRE_DATE >= STR_TO_DATE(:date,'%Y/%m/%d')  ");
		sql.append("   AND A.RES_AM_START_HHMM IS NULL                         ");
		sql.append("   AND A.RES_AM_END_HHMM   IS NULL                         ");
		sql.append("   AND A.RES_PM_START_HHMM IS NULL                         ");
		sql.append("   AND A.RES_PM_END_HHMM   IS NULL                         ");
		sql.append("ORDER BY A.JINRYO_PRE_DATE                                 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);

		List<NuroRES0102U00GrdRES0103Info> list = new JpaResultMapper().list(
				query, NuroRES0102U00GrdRES0103Info.class);
		return list;
	}
	
	@Override
	public List<NuroRES0102U00GrdRES0103ResInfo> getNuroRES0102U00GrdRES0103ResInfo(String hospCode, String doctor, String date){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR             ,              ");
		sql.append("        A.JINRYO_PRE_DATE    ,              ");
		sql.append("        A.RES_AM_START_HHMM  ,              ");
		sql.append("        A.RES_AM_END_HHMM    ,              ");
		sql.append("        A.RES_PM_START_HHMM  ,              ");
		sql.append("        A.RES_PM_END_HHMM    ,              ");
		sql.append("        A.REMARK             ,              ");
		sql.append("        A.AM_GWA_ROOM        ,              ");
		sql.append("        A.PM_GWA_ROOM                       ");
		sql.append("   FROM RES0103 A                           ");
		sql.append("  WHERE A.HOSP_CODE        = :hospCode   ");
		sql.append("    AND A.DOCTOR           = :doctor      ");
		sql.append("    AND A.JINRYO_PRE_DATE >= STR_TO_DATE(:date,'%Y/%m/%d')        ");
		sql.append("    AND A.AM_START_HHMM IS NULL             ");
		sql.append("    AND A.AM_END_HHMM   IS NULL             ");
		sql.append("    AND A.PM_START_HHMM IS NULL             ");
		sql.append("    AND A.PM_END_HHMM   IS NULL             ");
		sql.append("  ORDER BY A.JINRYO_PRE_DATE                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);

		List<NuroRES0102U00GrdRES0103ResInfo> list = new JpaResultMapper().list(query, NuroRES0102U00GrdRES0103ResInfo.class);
		return list;
	}

	@Override
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorByJinryoDate(
			String hospCode, String doctor, String date, boolean byResPm) {
		StringBuilder sql = new StringBuilder();
		if (byResPm) {
			sql.append("SELECT A.DOCTOR                                                    ");
			sql.append("FROM RES0103 A                                                     ");
			sql.append("WHERE A.HOSP_CODE       = :hospCode                                ");
			sql.append("  AND A.DOCTOR          = :doctor                                  ");
			sql.append("  AND A.JINRYO_PRE_DATE = DATE_FORMAT(:date, '%Y/%m/%d')           ");
			sql.append("  AND A.RES_AM_START_HHMM IS NULL                                  ");
			sql.append("  AND A.RES_AM_END_HHMM   IS NULL                                  ");
			sql.append("  AND A.RES_PM_START_HHMM IS NULL                                  ");
			sql.append("  AND A.RES_PM_END_HHMM   IS NULL                                  ");
			sql.append("  AND (A.AM_START_HHMM IS NOT NULL OR A.PM_START_HHMM IS NOT NULL) ");
		} else {
			sql.append("SELECT A.DOCTOR                                                           ");
			sql.append("FROM RES0103 A                                                            ");
			sql.append("WHERE A.HOSP_CODE       = :hospCode                                       ");
			sql.append("  AND A.DOCTOR          = :doctor                                         ");
			sql.append("  AND A.JINRYO_PRE_DATE = DATE_FORMAT(:date, '%Y/%m/%d')                  ");
			sql.append("  AND A.AM_START_HHMM IS NULL                                             ");
			sql.append("  AND A.AM_END_HHMM   IS NULL                                             ");
			sql.append("  AND A.PM_START_HHMM IS NULL                                             ");
			sql.append("  AND A.PM_END_HHMM   IS NULL                                             ");
			sql.append("  AND (A.RES_AM_START_HHMM IS NOT NULL OR A.RES_PM_START_HHMM IS NOT NULL) ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);

		List<NuroRES0102U00GetDoctorInfo> list = new JpaResultMapper().list(
				query, NuroRES0102U00GetDoctorInfo.class);
		return list;
	}
	
	@Override
	public String getNuroRES0102U00CheckDoctor2(String hospCode, String doctor, String date){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                                           ");
		sql.append("FROM RES0103                                                         ");
		sql.append("WHERE HOSP_CODE       = :hospCode                                 ");
		sql.append("  AND DOCTOR          = :doctor                                    ");
		sql.append("  AND JINRYO_PRE_DATE = DATE_FORMAT(:date, '%Y/%m/%d')  ");
		sql.append("  AND RES_AM_START_HHMM IS NULL                                      ");
		sql.append("  AND RES_AM_END_HHMM   IS NULL                                      ");
		sql.append("  AND RES_PM_START_HHMM IS NULL                                      ");
		sql.append("  AND RES_PM_END_HHMM   IS NULL                                      ");
		sql.append("  AND (AM_START_HHMM IS NOT NULL OR PM_START_HHMM IS NOT NULL)       ");
		sql.append("LIMIT  1                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);

		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}
	
//	@Override
//	public boolean insertNuroRES0102U00InsertRES0103Request1(String hospCode, NuroRES0102U00UpdateRES0103Info nuroRES0102U00UpdateRES0103Info) throws Exception{
//		try{
//			StringBuilder sql = new StringBuilder();
//			sql.append("INSERT INTO RES0103                                                                       ");
//			sql.append("          ( SYS_DATE          , SYS_ID            , UPD_DATE        , UPD_ID          ,   ");
//			sql.append("            DOCTOR            , JINRYO_PRE_DATE   ,                                       ");
//			sql.append("            AM_START_HHMM     , AM_END_HHMM       ,                                       ");
//			sql.append("            PM_START_HHMM     , PM_END_HHMM       ,                                       ");
//			sql.append("            REMARK            , AM_GWA_ROOM       , PM_GWA_ROOM     , HOSP_CODE)          ");
//			sql.append("    VALUES                                                                                ");
//			sql.append("          ( SYSDATE()         , :q_user_id        , SYSDATE()       , :q_user_id      ,   ");
//			sql.append("            :f_doctor         , DATE_FORMAT(:f_jinryo_pre_date, '%Y/%m/%d'),              ");
//			sql.append("            :f_am_start_hhmm  , :f_am_end_hhmm    ,                                       ");
//			sql.append("            :f_pm_start_hhmm  , :f_pm_end_hhmm    ,                                       ");
//			sql.append("            :f_remark         , :f_am_gwa_room    , :f_pm_gwa_room  , :f_hosp_code    )   ");
//			
//			Query query = entityManager.createNativeQuery(sql.toString());
//			query.setParameter("f_hosp_code", hospCode);
//			query.setParameter("q_user_id", nuroRES0102U00UpdateRES0103Info.getUserId());
//			query.setParameter("f_doctor", nuroRES0102U00UpdateRES0103Info.getDoctor());
//			query.setParameter("f_jinryo_pre_date", nuroRES0102U00UpdateRES0103Info.getJinryoPreDate());
//			query.setParameter("f_am_start_hhmm", nuroRES0102U00UpdateRES0103Info.getAmStartHhmm());
//			query.setParameter("f_am_end_hhmm", nuroRES0102U00UpdateRES0103Info.getAmEndHhmm());
//			query.setParameter("f_pm_start_hhmm", nuroRES0102U00UpdateRES0103Info.getPmStartHhmm());
//			query.setParameter("f_pm_end_hhmm", nuroRES0102U00UpdateRES0103Info.getPmEndHhmm());
//			query.setParameter("f_remark", nuroRES0102U00UpdateRES0103Info.getRemark());
//			query.setParameter("f_am_gwa_room", nuroRES0102U00UpdateRES0103Info.getAmGwaRoom());
//			query.setParameter("f_pm_gwa_room", nuroRES0102U00UpdateRES0103Info.getPmGwaRoom());
//			
//			query.executeUpdate();
//			return true;
//		}catch(Exception e){
//			LOG.error(e.getMessage(),e);
//			return false;
//		}
//	}
	
	@Override
	public boolean updateNuroRES0102U00UpdateRES0103Request1(String hospCode, NuroRES0102U00UpdateRES0103Info nuroRES0102U00UpdateRES0103Info) throws Exception{
		try{
			StringBuilder sql = new StringBuilder();
			sql.append(" UPDATE RES0103                                                       ");
			sql.append(" SET UPD_ID          = :q_user_id        ,                            ");
			sql.append(" UPD_DATE        = SYSDATE()         ,                                ");
			sql.append(" AM_START_HHMM   = :f_am_start_hhmm  ,                                ");
			sql.append(" AM_END_HHMM     = :f_am_end_hhmm    ,                                ");
			sql.append(" PM_START_HHMM   = :f_pm_start_hhmm  ,                                ");
			sql.append(" PM_END_HHMM     = :f_pm_end_hhmm    ,                                ");
			sql.append(" REMARK          = :f_remark         ,                                ");
			sql.append(" AM_GWA_ROOM     = :f_am_gwa_room    ,                                ");
			sql.append(" PM_GWA_ROOM     = :f_pm_gwa_room                                     ");
			sql.append(" WHERE HOSP_CODE       = :f_hosp_code                                 ");
			sql.append(" AND DOCTOR          = :f_doctor                                      ");
			sql.append(" AND JINRYO_PRE_DATE = DATE_FORMAT(:f_jinryo_pre_date, '%Y/%m/%d')    ");
			sql.append(" AND RES_AM_START_HHMM IS NULL                                        ");
			sql.append(" AND RES_AM_END_HHMM   IS NULL                                        ");
			sql.append(" AND RES_PM_START_HHMM IS NULL                                        ");
			sql.append(" AND RES_PM_END_HHMM   IS NULL                                        ");
			sql.append(" AND (AM_START_HHMM IS NOT NULL OR PM_START_HHMM IS NOT NULL)         ");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("q_user_id", nuroRES0102U00UpdateRES0103Info.getUserId());
			query.setParameter("f_doctor", nuroRES0102U00UpdateRES0103Info.getDoctor());
			query.setParameter("f_jinryo_pre_date", nuroRES0102U00UpdateRES0103Info.getJinryoPreDate());
			query.setParameter("f_am_start_hhmm", nuroRES0102U00UpdateRES0103Info.getAmStartHhmm());
			query.setParameter("f_am_end_hhmm", nuroRES0102U00UpdateRES0103Info.getAmEndHhmm());
			query.setParameter("f_pm_start_hhmm", nuroRES0102U00UpdateRES0103Info.getPmStartHhmm());
			query.setParameter("f_pm_end_hhmm", nuroRES0102U00UpdateRES0103Info.getPmEndHhmm());
			query.setParameter("f_remark", nuroRES0102U00UpdateRES0103Info.getRemark());
			query.setParameter("f_am_gwa_room", nuroRES0102U00UpdateRES0103Info.getAmGwaRoom());
			query.setParameter("f_pm_gwa_room", nuroRES0102U00UpdateRES0103Info.getPmGwaRoom());
		
			query.executeUpdate();
			return true;
		}catch(Exception e){
			LOG.error(e.getMessage(),e);
			return false;
		}
	}
	
	@Override
	public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> getReservationScheduleConditionListItemInfo(String hospitalCode, String doctorCode, String examPreDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.RES_AM_START_HHMM  AM_START_HHMM,    ");
		sql.append("        A.RES_AM_END_HHMM    AM_END_HHMM,     ");
		sql.append("        A.RES_PM_START_HHMM  PM_START_HHMM,   ");
		sql.append("        A.RES_PM_END_HHMM    PM_END_HHMM      ");
		sql.append("FROM RES0103 A                                ");
		sql.append("WHERE A.HOSP_CODE        = :hospitalCode      ");
		if(!StringUtils.isEmpty(doctorCode)) {
			sql.append("        AND A.DOCTOR           = :doctorCode  ");
		}
		if(!StringUtils.isEmpty(examPreDate)) {
			sql.append("        AND A.JINRYO_PRE_DATE  = :examPreDate ");
		}
		sql.append("        AND A.AM_START_HHMM    IS NULL        ");
		sql.append("        AND A.AM_END_HHMM      IS NULL        ");
		sql.append("        AND A.PM_START_HHMM    IS NULL        ");
		sql.append("        AND A.PM_END_HHMM      IS NULL        ");
		sql.append("ORDER BY A.JINRYO_PRE_DATE                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if(!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate", examPreDate);
		}
		
		List<NuroRES1001U00ReservationScheduleConditionListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00ReservationScheduleConditionListItemInfo.class);
		return list;
	}
	
	@Override
	public String getNuroRES1001U00CheckingReservation(String hospitalCode, String sessionHospCode, String doctorCode, String examPreDate, String examPreTime, String inputType, boolean isOtherClinic){
		StringBuilder sql = new StringBuilder();
		if(isOtherClinic){
			sql.append("SELECT FN_RES_CHECK_RESER_POSSIBLE_OTHER(:hospitalCode, :sessionHospCode, :doctorCode, :examPreDate, :examPreTime, :inputType); ");
		}else{
			sql.append("SELECT FN_RES_CHECK_RESER_POSSIBLE(:sessionHospCode, :doctorCode, :examPreDate, :examPreTime, :inputType); ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		query.setParameter("doctorCode", doctorCode);
		query.setParameter("examPreDate", DateUtil.toDate(examPreDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("examPreTime", examPreTime);
		query.setParameter("inputType", inputType);

		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return "";
	}

	@Override
	public String getTChkRES1001U00FrmModifyReserGrdRES1001SavePerformer(String hospCode, String doctor, Date jinryoPreDate,String jinryoPreTime, String inputGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT FN_RES_CHECK_RESER_POSSIBLE(:f_hosp_code,:f_doctor, :f_jinryo_pre_date, :f_jinryo_pre_time, :f_input_gubun) ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_jinryo_pre_date", jinryoPreDate);
		query.setParameter("f_jinryo_pre_time", jinryoPreTime);
		query.setParameter("f_input_gubun", inputGubun);
		List<String> listTCheck= query.getResultList();
		if(listTCheck !=null && !listTCheck.isEmpty()){
			return listTCheck.get(0);
		}
		return null;
	}
}

