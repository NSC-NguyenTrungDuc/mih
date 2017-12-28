package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.bas.Bas0212;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.bass.BAS0212U00GrdItemInfo;
import nta.med.data.model.ihis.bass.BAS0212U00fwkGongbiCodeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceCode;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceInfo2;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("bas0212Repository")
public class Bas0212RepositoryImpl extends SimpleJpaRepository<Bas0212, Long> implements Bas0212Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0212RepositoryImpl(EntityManager entityManager) {
		super(Bas0212.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public Bas0212 save(Bas0212 entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public List<Bas0212> save(List<Bas0212> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	@Override
	public void delete(Bas0212 entity) {
		super.delete(entity);
	}
	
	@Override
	public String callFnBasLoadGongbiName(String gongbiCode, Date jukyongYmd, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GONGBI_NAME( :gongbiCode, :jukyongYmd, :language)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gongbiCode", gongbiCode);
		query.setParameter("jukyongYmd", jukyongYmd);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<NuroOUT0101U02GetInsuranceInfo2> getNuroOUT0101U02GetInsuranceInfo2(String find1, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT GONGBI_CODE																");
		sql.append("     , GONGBI_NAME                                                              ");
		sql.append("  FROM BAS0212                                                                  ");
		sql.append(" WHERE GONGBI_CODE  LIKE CONCAT(:find1,'%')  AND LANGUAGE = :language           ");
		sql.append("   AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN START_DATE AND END_DATE       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("find1", find1);
		query.setParameter("language", language);
		List<NuroOUT0101U02GetInsuranceInfo2> list = new JpaResultMapper().list(query,NuroOUT0101U02GetInsuranceInfo2.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Bas0212Repository")
	public String getNuroOUT0101U02GetInsuranceName(String gongbiCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT GONGBI_NAME															");
		sql.append("  FROM BAS0212                                                              ");
		sql.append(" WHERE GONGBI_CODE = :gongbiCode  AND LANGUAGE = :language                  ");
		sql.append("   AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN START_DATE AND END_DATE   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gongbiCode", gongbiCode);
		query.setParameter("language", language);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<NuroOUT0101U02GetInsuranceCode> getNuroOUT0101U02GetInsuranceCode(String lawNo, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT GONGBI_CODE										");	
		sql.append(" FROM BAS0212                                           ");
		sql.append(" WHERE LAW_NO    = :lawNo AND LANGUAGE = :language      ");
		sql.append("  AND SYSDATE() BETWEEN START_DATE AND END_DATE         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("lawNo", lawNo);
		query.setParameter("language", language);
		List<NuroOUT0101U02GetInsuranceCode> list = new JpaResultMapper().list(query,NuroOUT0101U02GetInsuranceCode.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<String> getBAS0212U00ListItem(String code, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT GONGBI_NAME                                                         ");
		sql.append(" FROM BAS0212                                                               ");
		sql.append(" WHERE GONGBI_CODE = :f_code AND LANGUAGE = :language                       ");
		sql.append(" AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", code);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<BAS0212U00fwkGongbiCodeInfo> getBAS0212U00fwkGongbiCode(String find1, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE , A.GONGBI_NAME                                               ");
		sql.append("   FROM BAS0212 A                                                                   ");
		sql.append("  WHERE (  A.GONGBI_CODE LIKE  :f_find1 OR A.GONGBI_NAME LIKE :f_find1 ) AND A.LANGUAGE = :language            ");
		sql.append("    AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE  ");
		sql.append("  ORDER BY CONCAT(A.GONGBI_CODE, DATE_FORMAT(A.START_DATE , '%Y%m%d'))				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_find1", "%" + find1 + "%");
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		List<BAS0212U00fwkGongbiCodeInfo> list = new JpaResultMapper().list(query,BAS0212U00fwkGongbiCodeInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<BAS0212U00GrdItemInfo> getBAS0212U00GrdItemInfo(String gongbiCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE                                                                            ");
		sql.append("      , A.START_DATE                                                                             ");
		sql.append("      , A.END_DATE                                                                               ");
		sql.append("      , A.LAW_NO                                                                                 ");
		sql.append("      , A.GONGBI_NAME                                                                            ");
		sql.append("      , A.TOTAL_YN                                                                               ");
		sql.append("      , A.GONGBI_JIYEOK                                                                          ");
		sql.append("   FROM BAS0212 A                                                                                ");
		sql.append("  WHERE A.GONGBI_CODE  LIKE :f_gongbi_code  AND A.LANGUAGE = :language                           ");
		sql.append("    AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE               ");
		sql.append("  ORDER BY CONCAT(IFNULL(A.LAW_NO, '  ') , A.GONGBI_CODE , DATE_FORMAT(A.START_DATE , '%Y%m%d')) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gongbi_code", "%" + gongbiCode + "%");
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		List<BAS0212U00GrdItemInfo> list = new JpaResultMapper().list(query,BAS0212U00GrdItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<String> getYByGongbiCodeAnDateBetWeen(String code, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                                                                    ");
		sql.append("  FROM BAS0212                                                                 ");
		sql.append("  WHERE GONGBI_CODE = :f_code  AND LANGUAGE = :language                        ");
		sql.append("   AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", code);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value = "Bas0212Repository")
	public List<String> getYByGongbiCodeAnDate(String gongbiCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                                                                    ");
		sql.append("  FROM BAS0212                                                                 ");
		sql.append("  WHERE GONGBI_CODE = :f_code   AND LANGUAGE = :language                       ");
		sql.append("   AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", gongbiCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public Integer updateBas0212ByGongbiCodeAndEndDate(String userId, String startDate, String gongbiCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE BAS0212 A                                                                        ");
		sql.append("    SET A.UPD_ID      = :q_user_id                                                       ");
		sql.append("      , A.UPD_DATE    = :f_upd_date                                                        ");
		sql.append("      , A.END_DATE    = DATE_SUB(STR_TO_DATE(:f_start_date, '%Y/%m/%d'),INTERVAL 1 DAY)  ");
		sql.append("  WHERE  A.GONGBI_CODE = :f_gongbi_code  AND A.LANGUAGE = :language                      ");
		sql.append("    AND A.END_DATE    = STR_TO_DATE('9998/12/31', '%Y/%m/%d')                            ");
		sql.append("    AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("q_user_id", userId);
		query.setParameter("f_upd_date", new Date());
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_gongbi_code", gongbiCode);
		query.setParameter("language", language);
	
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public Integer updateBas0212ByGongbiCodeAndStartDate(String userId,
			String endDate, String lawNo, String gongbiName, String totalYn,
			String gongbiJiyeok, String gongbiCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE BAS0212                            ");
		sql.append("     SET UPD_ID        = :q_user_id        ");
		sql.append("       , UPD_DATE      =  :f_upd_date      ");
		sql.append("       , END_DATE      = :f_end_date       ");
		sql.append("       , LAW_NO        = :f_law_no         ");
		sql.append("       , GONGBI_NAME   = :f_gongbi_name    ");
		sql.append("       , TOTAL_YN      = :f_total_yn       ");
		sql.append("       , GONGBI_JIYEOK = :f_gongbi_jiyeok  ");
		sql.append("   WHERE GONGBI_CODE   = :f_gongbi_code    ");
		sql.append("     AND START_DATE    = :f_start_date     ");
		sql.append("     AND LANGUAGE    = :language           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("q_user_id", userId);
		query.setParameter("f_upd_date", new Date());
		query.setParameter("f_end_date", endDate);
		query.setParameter("f_law_no", lawNo);
		query.setParameter("f_gongbi_name", gongbiName);
		query.setParameter("f_total_yn", totalYn);
		query.setParameter("f_gongbi_jiyeok", gongbiJiyeok);
		query.setParameter("f_gongbi_code", gongbiCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
	
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public Integer updateBas0212ByGongbiCodeAndEndDateCaseDelete(String gongbiCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE BAS0212                                                                           ");
		sql.append("   SET END_DATE        = STR_TO_DATE('9998/12/31', '%Y/%m/%d')                            ");
		sql.append(" WHERE GONGBI_CODE   = :f_gongbi_code  AND LANGUAGE = :language                           ");
		sql.append("   AND END_DATE        = DATE_SUB(STR_TO_DATE(:f_start_date, '%Y/%m/%d'),INTERVAL 1 DAY)  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gongbi_code", gongbiCode);
		query.setParameter("f_start_date", startDate);
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Bas0212Repository", allEntries = true)
	public Integer deleteBas0210(String gongbiCode, Date startDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" DELETE FROM BAS0212 WHERE GONGBI_CODE = :f_gongbi_code AND START_DATE  = :f_start_date AND LANGUAGE = :language ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gongbi_code", gongbiCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		return query.executeUpdate();
	}

	@Override
	public List<String> getGongbiCodeByGongbiName(String gongbiName, String language) {
		String sql = "SELECT GONGBI_CODE FROM BAS0212 WHERE GONGBI_NAME = :f_gongbi_name AND LANGUAGE = :language ";
		Query query = entityManager.createNativeQuery(sql);
		query.setParameter("f_gongbi_name", gongbiName);
		query.setParameter("language", language);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<ComboListItemInfo> findByHospCodeCodeType(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT												");
		sql.append("		CODE,											");
		sql.append("		CODE_NAME										");
		sql.append("	FROM												");
		sql.append("		BAS0102											");
		sql.append("	WHERE												");
		sql.append("		HOSP_CODE 		= :f_hosp_code			 		");
		sql.append("	  	AND CODE_TYPE 	= 'RESER_MEMO_CATEGORY'			");
		sql.append("	ORDER BY											");
		sql.append("		CODE											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
}

