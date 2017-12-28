package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur9999RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR9999R11grdNUR9999Info;

/**
 * @author dainguyen.
 */
public class Nur9999RepositoryImpl implements Nur9999RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR9999R11grdNUR9999Info> getNUR9999R11grdNUR9999Info(String hospCode, Double fkinp1001, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.FKINP1001 AS CHAR)                                                                            ");
		sql.append("	     , CAST(A.PKNUR9999 AS CHAR)                                                                            ");
		sql.append("	     , A.GUBUN                                                                                              ");
		sql.append("	     , IFNULL(FN_NUR_LOAD_CODE_NAME('SUMMARY_GUBUN', A.GUBUN, :f_hosp_code, :f_language), '') AS GUBUN_NAME ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.WRITE_DATE, '%Y/%m/%d'), '')                                                    ");
		sql.append("	     , A.BUNHO                                                                                              ");
		sql.append("	     , A.SUNAME                                                                                             ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.BIRTH, '%Y/%m/%d'), '')                                                         ");
		sql.append("	     , IFNULL(A.AGE, '')                                                                                    ");
		sql.append("	     , IFNULL(A.GWA    , '')                                                                                ");
		sql.append("	     , IFNULL(A.DOCTOR , '')                                                                                ");
		sql.append("	     , IFNULL(A.REASON , '')                                                                                ");
		sql.append("	     , IFNULL(A.ADDRESS, '')                                                                                ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.IPWON_DATE , '%Y/%m/%d'), '')                                                   ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d'), '')                                                   ");
		sql.append("	     , IFNULL(A.HO_DONG           , '')                                                                     ");
		sql.append("	     , IFNULL(A.DAMDANG_NURSE     , '')                                                                     ");
		sql.append("	     , IFNULL(A.LEADER_NURSE      , '')                                                                     ");
		sql.append("	     , IFNULL(A.TEL               , '')                                                                     ");
		sql.append("	     , IFNULL(A.SANG_NAME         , '')                                                                     ");
		sql.append("	     , IFNULL(A.PAST_HIS          , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY1_RELATION     , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY1_HOME         , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY1_PHONE        , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY1_OFFICE       , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY2_RELATION     , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY2_HOME         , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY2_PHONE        , '')                                                                     ");
		sql.append("	     , IFNULL(A.KEY2_OFFICE       , '')                                                                     ");
		sql.append("	     , IFNULL(A.INFECTION         , '')                                                                     ");
		sql.append("	     , IFNULL(A.TABOO             , '')                                                                     ");
		sql.append("	     , IFNULL(A.INPATIENT_COURSE  , '')                                                                     ");
		sql.append("	     , IFNULL(A.NURSING_PASS      , '')                                                                     ");
		sql.append("	     , IFNULL(A.CONTINUE_NURSING  , '')                                                                     ");
		sql.append("	     , IFNULL(A.FOOD              , '')                                                                     ");
		sql.append("	     , IFNULL(A.FOOD_ADL          , '')                                                                     ");
		sql.append("	     , IFNULL(A.FOOD_ADL_CMT      , '')                                                                     ");
		sql.append("	     , IFNULL(A.EXCRETION         , '')                                                                     ");
		sql.append("	     , IFNULL(A.EXCRETION_ADL     , '')                                                                     ");
		sql.append("	     , IFNULL(A.EXCRETION_ADL_CMT , '')                                                                     ");
		sql.append("	     , IFNULL(A.MOVE              , '')                                                                     ");
		sql.append("	     , IFNULL(A.MOVE_ADL          , '')                                                                     ");
		sql.append("	     , IFNULL(A.MOVE_ADL_CMT      , '')                                                                     ");
		sql.append("	     , IFNULL(A.WASH              , '')                                                                     ");
		sql.append("	     , IFNULL(A.WASH_ADL          , '')                                                                     ");
		sql.append("	     , IFNULL(A.WASH_ADL_CMT      , '')                                                                     ");
		sql.append("	     , IFNULL(A.WARE_ADL          , '')                                                                     ");
		sql.append("	     , IFNULL(A.WARE_ADL_CMT      , '')                                                                     ");
		sql.append("	     , IFNULL(A.COMMUNICATION     , '')                                                                     ");
		sql.append("	     , IFNULL(A.SLEEP             , '')                                                                     ");
		sql.append("	     , IFNULL(A.TUBE              , '')                                                                     ");
		sql.append("	     , IFNULL(A.COMMENTS          , '')                                                                     ");
		sql.append("	  FROM NUR9999 A                                                                                            ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                           ");
		sql.append("	   AND A.FKINP1001 = :f_fkinp1001                                                                           ");
		sql.append("	 ORDER BY PKNUR9999 DESC                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_language", language);
		
		List<NUR9999R11grdNUR9999Info> lstResult = new JpaResultMapper().list(query, NUR9999R11grdNUR9999Info.class);
		return lstResult;
	}
}
