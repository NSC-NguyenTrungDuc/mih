package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inp.Inp5001RepositoryCustom;
import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckDeleteInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02getMagamStatus1Info;

/**
 * @author dainguyen.
 */
public class Inp5001RepositoryImpl implements Inp5001RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Inp5001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS2005U02getMagamStatus1Info> getOCS2005U02getMagamStatus1(String hospCode, String magamDate, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.NUT_JO_MAGAM_YN    B														");
		sql.append("          , A.NUT_JU_MAGAM_YN    L														");
		sql.append("          , A.NUT_SEOK_MAGAM_YN  D														");
		sql.append("       FROM INP5001 A																	");
		sql.append("      WHERE A.HOSP_CODE  = :f_hosp_code													");
		sql.append("        AND A.MAGAM_DATE = STR_TO_DATE(:f_magam_date, '%Y/%m/%d')						");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset														");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_magam_date", magamDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<OCS2005U02getMagamStatus1Info> list = new JpaResultMapper().list(query, OCS2005U02getMagamStatus1Info.class);
		return list;
		
	}
	
	@Override
	public List<OCS2005U02RecoveryDataCheckDeleteInfo> getOCS2005U02RecoveryDataCheckDeleteInfo(String hospCode, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.CHARGE_YN																	");
		sql.append("          , A.NUT_JO_MAGAM_YN															");
		sql.append("          , A.NUT_JU_MAGAM_YN															");
		sql.append("          , A.NUT_SEOK_MAGAM_YN															");
		sql.append("          , DATE_FORMAT(A.MAGAM_DATE, '%Y/%m/%d') MAGAM_DATE							");
		sql.append("       FROM INP5001 A																	");
		sql.append("      WHERE A.HOSP_CODE  = :f_hosp_code													");
		sql.append("        AND A.MAGAM_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d')					");
		sql.append("                             AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')						");
		sql.append("      ORDER BY A.MAGAM_DATE DESC														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<OCS2005U02RecoveryDataCheckDeleteInfo> list = new JpaResultMapper().list(query, OCS2005U02RecoveryDataCheckDeleteInfo.class);
		return list;
	}
	
	@Override
	public String getNutIsSiksaMagamYn(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT FN_NUT_IS_SIKSA_MAGAM_YN(:f_hosp_code) FROM DUAL							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public List<OCS2005U02RecoveryDataCheckInfo> getOCS2005U02RecoveryDataCheckInfo(String hospCode, Date magamDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.CHARGE_YN, 'N')            CHARGE_YN			");
		sql.append("	     , IFNULL(A.NUT_JO_MAGAM_YN, 'N')      NUT_JO_MAGAM_YN		");
		sql.append("	     , IFNULL(A.NUT_JU_MAGAM_YN, 'N')      NUT_JU_MAGAM_YN		");
		sql.append("	     , IFNULL(A.NUT_SEOK_MAGAM_YN, 'N')    NUT_SEOK_MAGAM_YN	");
		sql.append("	     , ''   							   MAGAM_DATE			");
		sql.append("	FROM INP5001 A 													");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code								");
		sql.append("	  AND A.MAGAM_DATE  = :f_magam_date								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_magam_date", magamDate);
		
		List<OCS2005U02RecoveryDataCheckInfo> listInfo = new JpaResultMapper().list(query, OCS2005U02RecoveryDataCheckInfo.class);
		return listInfo;
	}

	@Override
	public List<OCS2005U02RecoveryDataCheckInfo> getOCS2005U02RecoveryDataCheckInfoByMinMaxDate(String hospCode,
			Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  IFNULL(A.CHARGE_YN, '')                           AS  CHARGE_YN			");
		sql.append("	      , IFNULL(A.NUT_JO_MAGAM_YN, '')                     AS  NUT_JO_MAGAM_YN	");
		sql.append("	      , IFNULL(A.NUT_JU_MAGAM_YN, '')                     AS  NUT_JU_MAGAM_YN	");
		sql.append("	      , IFNULL(A.NUT_SEOK_MAGAM_YN, '')                   AS  NUT_SEOK_MAGAM_YN	");
		sql.append("	      , IFNULL(DATE_FORMAT(A.MAGAM_DATE, '%Y/%m/%d'), '') AS  MAGAM_DATE		");
		sql.append("	FROM INP5001 A																	");
		sql.append("	WHERE A.HOSP_CODE  = :f_hosp_code												");
		sql.append("	 AND A.MAGAM_DATE BETWEEN :f_from_date AND :f_to_date							");
		sql.append("	ORDER BY A.MAGAM_DATE DESC														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<OCS2005U02RecoveryDataCheckInfo> listInfo = new JpaResultMapper().list(query, OCS2005U02RecoveryDataCheckInfo.class);
		return listInfo;
	}
}

