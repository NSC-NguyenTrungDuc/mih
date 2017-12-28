package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur6014RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR6011U01grdImageInfo;

/**
 * @author dainguyen.
 */
public class Nur6014RepositoryImpl implements Nur6014RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR6011U01grdImageInfo> getNUR6011U01grdImageInfo(String hospCode, String bunho, String fromDate, String buwiGubun, String assessorDate,
			Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT :f_bunho                    BUNHO                                    ");
		sql.append("        , :f_from_date                FROM_DATE                                ");
		sql.append("        , :f_buwi_gubun               BUWI_GUBUN                               ");
		sql.append("        , DATE_FORMAT(ASSESSOR_DATE, '%Y/%m/%d')               ASSESSOR_DATE   ");
		sql.append("        , LTRIM(LPAD(SEQ,5,'0')) SEQ                                           ");
		sql.append("        , ''                                                   IMAGE           ");
		sql.append("        , ''                                                   IMAGE1          ");
		sql.append("        , BEDSORE_BUWI_IMAGE                    IMAGE_PATH                     ");
		sql.append("        , ''                    IMAGE_BASE_PATH                     		   ");
		sql.append("        , ''                    DATA_ROW_STATE			                       ");
		sql.append("     FROM NUR6014 A                                                            ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                       ");
		sql.append("      AND A.BUNHO         = :f_bunho                                           ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y/%m/%d')              ");
		sql.append("      AND A.BEDSORE_BUWI  LIKE :f_buwi_gubun                                   ");
		sql.append("      AND A.ASSESSOR_DATE = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')          ");
		sql.append("    ORDER BY A.SEQ															   ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset											   ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_assessor_date", assessorDate);
		query.setParameter("f_buwi_gubun", buwiGubun);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR6011U01grdImageInfo> list = new JpaResultMapper().list(query, NUR6011U01grdImageInfo.class);
		return list;
	}
	
	@Override
	public String getNUR6011U01layImage(String hospCode, String bunho, String fromDate, String buwi, String assessorDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BEDSORE_BUWI_IMAGE IMAGE_PATH                                        ");
		sql.append("     FROM NUR6014 A                                                              ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                         ");
		sql.append("      AND A.BUNHO         = :f_bunho                                             ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                ");
		sql.append("      AND A.BEDSORE_BUWI  LIKE :f_buwi                                           ");
		sql.append("      AND A.ASSESSOR_DATE = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')            ");
		sql.append("      AND A.SEQ = 1                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_assessor_date", assessorDate);
		query.setParameter("f_buwi", buwi);
		
		List<String> list = query.getResultList();
		if(CollectionUtils.isEmpty(list) && list.size() > 0 ){
			return list.get(0);
		}
		return "";		
	}
	
	@Override
	public Double getNextSeq(String hospCode, String bunho, String fromDate, String bedsoreBuwi, String assessorDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(MAX(A.SEQ),0) + 1 SEQ                                          ");
		sql.append("     FROM NUR6014 A                                                             ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                        ");
		sql.append("      AND A.BUNHO         = :f_bunho                                            ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y%m%d')               ");
		sql.append("      AND A.BEDSORE_BUWI  = :f_bedsore_buwi                                     ");
		sql.append("      AND A.ASSESSOR_DATE = STR_TO_DATE(:f_assessor_date, '%Y%m%d')           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_assessor_date", assessorDate);
		query.setParameter("f_bedsore_buwi", bedsoreBuwi);
		
		List<Double> list = query.getResultList();
		return list.get(0);	
	}
	
	@Override
	public List<String> getNUR6011U01PrintSetlayImage(String hospCode, String bunho, String buwi, String fromDate, String assessorDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT BEDSORE_BUWI_IMAGE IMAGE_PATH                                         ");
		sql.append("     FROM NUR6014 A                                                             ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                        ");
		sql.append("      AND A.BUNHO         = :f_bunho                                            ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y/%m/%d')               ");
		sql.append("      AND A.BEDSORE_BUWI  LIKE :f_buwi                                          ");
		sql.append("      AND A.ASSESSOR_DATE = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')           ");
		sql.append("    ORDER BY SEQ                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_assessor_date", assessorDate);
		query.setParameter("f_buwi", buwi);
		
		List<String> list = query.getResultList();
		return list;	
	}
}

