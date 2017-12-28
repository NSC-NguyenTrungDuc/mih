package nta.med.data.dao.mss.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.data.dao.mss.HospitalRepositoryCustom;

public class HospitalRepositoryImpl implements HospitalRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public Integer setUpMovieTalk(String hospCode, Integer useMovieTalk, Integer useSurvey, String locale) {
		StringBuilder sql = new StringBuilder();
//		sql.append(" UPDATE hospital ");
//		sql.append(" SET IS_USE_MT = CASE WHEN :f_use_movie_talk is null OR :f_use_movie_talk = '' then  IS_USE_MT ELSE :f_use_movie_talk END, is_Use_Mis = case when :f_use_survey is null or :f_use_survey = '' then  IS_USE_MIS else :f_use_survey  END");
//		sql.append(" WHERE hospital_Code = :f_hosp_code AND locale = :f_locale ");
		
		sql.append(" UPDATE hospital SET ");
		if(!StringUtils.isEmpty(useMovieTalk)){
			sql.append(" is_use_mt = :f_use_movie_talk, ");
		}
		if(!StringUtils.isEmpty(useSurvey)){
			sql.append(" is_use_mis = :f_use_survey, ");
		}
		sql.append(" updated = SYSDATE() ");
		sql.append(" WHERE hospital_Code = :f_hosp_code AND locale = :f_locale ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(useMovieTalk)){
			query.setParameter("f_use_movie_talk", useMovieTalk);
		}
		if(!StringUtils.isEmpty(useSurvey)){
			query.setParameter("f_use_survey", useSurvey);
		}
		query.setParameter("f_locale", locale);
		
		return query.executeUpdate();
		
	}

}
