package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur6011RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetlayBuwiInfo;
import nta.med.data.model.ihis.nuri.NUR6011U01grdNur6011Info;

/**
 * @author dainguyen.
 */
public class Nur6011RepositoryImpl implements Nur6011RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR6011U01grdNur6011Info> getNUR6011U01grdNur6011Info(String hospCode, String language, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO																										  ");
		sql.append("        , DATE_FORMAT(A.FROM_DATE,'%Y/%m/%d')                                                          FROM_DATE          ");
		sql.append("        , IFNULL(DATE_FORMAT(A.END_DATE,'%Y/%m/%d'),'')                                                END_DATE           ");
		sql.append("        , A.FKINP1001                                                                                  FKINP1001          ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI1, :f_hosp_code, :f_language),'') CHK1               ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI2, :f_hosp_code, :f_language),'') CHK2               ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI3, :f_hosp_code, :f_language),'') CHK3               ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI4, :f_hosp_code, :f_language),'') CHK4               ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI5, :f_hosp_code, :f_language),'') CHK5               ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', A.BEDSORE_BUWI6, :f_hosp_code, :f_language),'') CHK6               ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI1,'')                                                                   BEDSORE_BUWI1      ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI2,'')                                                                   BEDSORE_BUWI2      ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI3,'')                                                                   BEDSORE_BUWI3      ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI4,'')                                                                   BEDSORE_BUWI4      ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI5,'')                                                                   BEDSORE_BUWI5      ");
		sql.append("        , IFNULL(A.BEDSORE_BUWI6,'')                                                                   BEDSORE_BUWI6      ");
		sql.append("        , ''                                                                   						   DATA_ROW_STATE     ");
		sql.append("     FROM NUR6011 A                                                                                                       ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                                      ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                                                          ");
		sql.append("    ORDER BY A.BUNHO, A.FROM_DATE DESC                                                                                    ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																						  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR6011U01grdNur6011Info> list = new JpaResultMapper().list(query, NUR6011U01grdNur6011Info.class);
		return list;
	}
	
	@Override
	public Integer nUR6011U01SaveLayoutUpdateNUR6011(String hospCode, String bunho, String fromDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   UPDATE NUR6011 A, (SELECT MAX(FROM_DATE) MAX_FROM_DATE                                       ");
		sql.append("                       FROM NUR6011                                                             ");
		sql.append("                      WHERE HOSP_CODE = :f_hosp_code                                            ");
		sql.append("                        AND BUNHO     = :f_bunho                                                ");
		sql.append("                        AND FROM_DATE <= STR_TO_DATE(:f_from_date, '%Y/%m/%d')) B               ");
		sql.append("     SET A.END_DATE = DATE_ADD(STR_TO_DATE(:f_from_date,'%Y/%m/%d'), INTERVAL -1 DAY)           ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                             ");
		sql.append("     AND A.BUNHO     = :f_bunho                                                                 ");
		sql.append("     AND A.FROM_DATE = B.MAX_FROM_DATE                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_bunho", bunho);
		
		return query.executeUpdate();
	}
	
	@Override
	public String getNUR6011SaveLayoutIsExist(String hospCode, String bunho, String fromDate, String assessorDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                              ");
		sql.append("     FROM DUAL                                                                             ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                               ");
		sql.append("                    FROM NUR6011                                                           ");
		sql.append("                   WHERE HOSP_CODE = :f_hosp_code                                          ");
		sql.append("                     AND BUNHO     = :f_bunho                                              ");
		sql.append("                     AND FROM_DATE = STR_TO_DATE(:f_from_date,'%Y/%m/%d')                  ");
		sql.append("                     AND STR_TO_DATE(:f_assessor_date,'%Y/%m/%d') BETWEEN FROM_DATE        ");
		sql.append("                          AND IFNULL(END_DATE, STR_TO_DATE('99981231','%Y%m%d')))          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_assessor_date", assessorDate);

		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<NUR6011U01PrintSetlayBuwiInfo> getNUR6011U01PrintSetlayBuwiInfo(String hospCode, String language, String bunho, String fromDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI1, A.HOSP_CODE, :f_language),'') CHK1           ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI2, A.HOSP_CODE, :f_language),'') CHK2           ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI3, A.HOSP_CODE, :f_language),'') CHK3           ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI4, A.HOSP_CODE, :f_language),'') CHK4           ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI5, A.HOSP_CODE, :f_language),'') CHK5           ");
		sql.append("        , IFNULL(FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI', BEDSORE_BUWI6, A.HOSP_CODE, :f_language),'') CHK6           ");
		sql.append("        , IFNULL(BEDSORE_BUWI1,'')                                                                                 ");
		sql.append("        , IFNULL(BEDSORE_BUWI2,'')                                                                                 ");
		sql.append("        , IFNULL(BEDSORE_BUWI3,'')                                                                                 ");
		sql.append("        , IFNULL(BEDSORE_BUWI4,'')                                                                                 ");
		sql.append("        , IFNULL(BEDSORE_BUWI5,'')                                                                                 ");
		sql.append("        , IFNULL(BEDSORE_BUWI6,'')                                                                                 ");
		sql.append("   FROM NUR6011 A                                                                                                  ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                ");
		sql.append("     AND A.BUNHO     = :f_bunho                                                                                    ");
		sql.append("     AND A.FROM_DATE = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		
		List<NUR6011U01PrintSetlayBuwiInfo> list = new JpaResultMapper().list(query, NUR6011U01PrintSetlayBuwiInfo.class);
		return list;
	}
}

