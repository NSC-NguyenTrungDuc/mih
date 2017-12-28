package nta.med.data.dao.medi.sch.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.sch.Sch0109;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.schs.ComboGumsaListItemInfo;
import nta.med.data.model.ihis.schs.ComboGumsaPartListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("sch0109Repository")
public class Sch0109RepositoryImpl extends SimpleJpaRepository<Sch0109, Long> implements Sch0109Repository {
	private static final Log LOGGER = LogFactory.getLog(Sch0109RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Sch0109RepositoryImpl(EntityManager entityManager) {
		super(Sch0109.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public Sch0109 save(Sch0109 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public List<Sch0109> save(List<Sch0109> entities) {
		return super.save(entities);
	}
	
	
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	@Override
	public void delete(Sch0109 entity) {
		super.delete(entity);
	}
	
	@Override
	@Cacheable(value="Sch0109Repository")
	public List<Sch0109> getSCH0109U00GrdDetailInfo(String hospCode, 
			String language, String codeType) {
		String sqlQuery = "SELECT A FROM Sch0109 A WHERE A.hospCode = :hospCode AND A.codeType = :codeType AND A.language = :language ORDER BY A.code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		List<Sch0109> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value="Sch0109Repository")
	public List<Sch0109> getSCH0201Q04GetCboInfo(String hospCode, 
			String language, String codeType) {
		String sqlQuery = "SELECT a FROM Sch0109 a WHERE a.hospCode = :hospCode AND a.codeType = :codeType AND a.language = :language ORDER BY a.codeName2";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		List<Sch0109> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value="Sch0109Repository")
	public String getSCH0109U00LayDupD(String hospCode,String language,
			String codeType, String code) {
		String sqlQuery = "SELECT DISTINCT 'Y' FROM Sch0109 WHERE hospCode = :hospCode AND language = :language AND codeType = :codeType AND code = :code ";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}

	@Override
	@Cacheable(value="Sch0109Repository")
	public String getSCH0109XSavePerformer(String hospCode,String language,
			String codeType) {
		String sqlQuery = "SELECT DISTINCT 'Y' FROM Sch0109 WHERE hospCode = :hospCode AND language = :language AND codeType = :codeType ";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}

	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public Integer deleteSCH0109XSavePerformer1(String hospCode,
			String language,String codeType) {
		String sqlQuery = "DELETE Sch0109 WHERE hospCode = :hospCode AND language = :language AND codeType = :codeType";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public Integer deleteSCH0109XSavePerformer(String hospCode,String language,
			String codeType, String code) {
		String sqlQuery = "DELETE Sch0109 WHERE hospCode = :hospCode AND language = :language AND codeType = :codeType AND code = :code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public Integer updateSCH0109XSavePerformer(String sysId,
			Date updDate, String codeName,
			String codeName2, String code2,
			String hospCode, String codeType,
			String code) {
		String sqlQuery = "UPDATE Sch0109 SET sysId = :sysId, updDate = :updDate, codeName  = :codeName"
				        +" , codeName2 = :codeName2, code2 = :code2 "
				        +" WHERE hospCode = :hospCode AND codeType = :codeType AND code = :code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("sysId", sysId);
		query.setParameter("updDate", updDate); 
		query.setParameter("codeName", codeName);
		query.setParameter("codeName2", codeName2); 
		query.setParameter("code2", code2);
		query.setParameter("hospCode", hospCode); 
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Sch0109Repository", allEntries = true)
	public Integer updateSCH0109WithSeq(String sysId, Date updDate,
			String codeName, String codeName2,
			String code2, Double seq,
			String hospCode, String language,
			String codeType, String code) {
		String sqlQuery = "UPDATE Sch0109 SET sysId = :sysId, updDate = :updDate, codeName  = :codeName "
			            +" , codeName2 = :codeName2, code2 = :code2, seq  = :seq "
			            +" WHERE hospCode = :hospCode AND language = :language AND codeType = :codeType AND code = :code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("sysId", sysId); 
		query.setParameter("updDate", updDate);
		query.setParameter("codeName", codeName); 
		query.setParameter("codeName2", codeName2);
		query.setParameter("code2", code2); 
		query.setParameter("seq", seq);
		query.setParameter("hospCode", hospCode); 
		query.setParameter("language", language);
		query.setParameter("codeType", codeType); 
		query.setParameter("code", code);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value="Sch0109Repository")
	public List<String> getNuroInspectionOrderCodeNameInfo(String hospitalCode, String codeType, String code2) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE_NAME CMT_TEXT                  ");
		sql.append("    FROM SCH0109                           ");
		sql.append("   WHERE HOSP_CODE = :hospitalCode         ");
		sql.append("   AND CODE_TYPE = :codeType		       ");
		sql.append("   AND CODE2 = :code2			           ");
		sql.append(" ORDER BY CODE;                             ");
		                
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code2", code2);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	@Cacheable(value="Sch0109Repository")
	public List<String> getNuroInspectionOrderText(String hospitalCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT CODE_NAME INFO_TEXT       ");
		sql.append("    FROM SCH0109                           ");
		sql.append("   WHERE HOSP_CODE = :hospitalCode         ");
		sql.append("   AND CODE_TYPE = :codeType		       ");
		sql.append("   AND LANGUAGE = :language				   ");
		sql.append(" ORDER BY CODE;                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	@Cacheable(value="Sch0109Repository")
	public List<String> getNuroInspectionOrderMaxCodeName(String hospitalCode, String codeType, List<String> reserPart) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MAX(CODE_NAME) CMT_TEXT        ");
		sql.append("      FROM SCH0109                    ");
		sql.append("     WHERE HOSP_CODE = :hospitalCode  ");
		sql.append("       AND CODE_TYPE = :codeType      ");
		sql.append("       AND CODE2     IN (:reserPart)  ");
		sql.append("     GROUP BY CODE_NAME2              ");
		sql.append("     ORDER BY MAX(CODE_NAME2)         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("codeType", codeType);
		query.setParameter("reserPart", reserPart);
		
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value="Sch0109Repository")
	public List<ComboGumsaListItemInfo> getComboGumsaListItemInfo(
			String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%'    CODE					 ");					
		sql.append("	     , '全体' CODE_NAME               ");
		sql.append("	     , 0     SEQ                     ");
		sql.append("	UNION ALL                            ");
		sql.append("	SELECT CODE                          ");
		sql.append("	     , CODE_NAME                     ");
		sql.append("	     , SEQ                           ");
		sql.append("	  FROM SCH0109                       ");
		sql.append("	 WHERE HOSP_CODE = :hospCode         ");
		sql.append("	   AND CODE_TYPE = 'GROUP'           ");
		sql.append("	ORDER BY SEQ                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		List<ComboGumsaListItemInfo> listResult = new JpaResultMapper().list(query, ComboGumsaListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboGumsaPartListItemInfo> getComboGumsaPartListItemInfo(
			String hospCode, String jundalTable) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%'    CODE								");		
		sql.append("	     , '全体' CODE_NAME                          ");
		sql.append("	UNION ALL                                       ");
		sql.append("	SELECT A.JUNDAL_PART       CODE                 ");
		sql.append("	, A.JUNDAL_PART_NAME  CODE_NAME                 ");
		sql.append("	FROM SCH0001 A                                  ");
		sql.append("	WHERE A.HOSP_CODE    = :hospCode                ");
		sql.append("	AND A.JUNDAL_TABLE LIKE  :jundalTable        ");
		sql.append("	ORDER BY CODE                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		
		List<ComboGumsaPartListItemInfo> listResult = new JpaResultMapper().list(query, ComboGumsaPartListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value="Sch0109Repository")
	public List<ComboListItemInfo> getSCH0201Q12CboAppointmentList(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%'    CODE						");
		sql.append("	     , FN_ADM_MSG(221,:language)		");
		sql.append("	UNION ALL                               ");
		sql.append("	(SELECT CODE                             ");
		sql.append("	     , CODE_NAME                        ");
		sql.append("	  FROM SCH0109                          ");
		sql.append("	 WHERE HOSP_CODE = :hospCode            ");
		sql.append("	   AND CODE_TYPE = 'GROUP'              ");
		sql.append("	   AND LANGUAGE = :language             ");
		sql.append("	ORDER BY SEQ   )                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value="Sch0109Repository")
	public List<ComboListItemInfo> getSCH3001U00GetCboGumsa(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE                         ");
		sql.append("      , CODE_NAME                    ");
		sql.append("   FROM SCH0109                      ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code     ");
		sql.append("    AND LANGUAGE = :f_language       ");
		sql.append("    AND CODE_TYPE = :f_code_type     ");
		sql.append("  ORDER BY CODE_NAME2                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getComboGumsaListItemInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%'    CODE,                           ");
		sql.append(" FN_ADM_MSG('221',:f_language) CODE_NAME       ");
		sql.append(" UNION ALL                                     ");
		sql.append(" SELECT CODE                                   ");
		sql.append("      , CODE_NAME                              ");
		sql.append("   FROM SCH0109                                ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code               ");
		sql.append("    AND CODE_TYPE = 'GROUP'                    ");
		sql.append("    AND LANGUAGE = :f_language                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public boolean isExistedSCH0109(String hospCode, String codeType, String code, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM SCH0109 A                       	 	    		");
		sql.append("	WHERE A.CODE_TYPE     = :f_code_type   		    	    ");
		sql.append("      AND A.LANGUAGE = :f_language                          ");
		sql.append("      AND A.HOSP_CODE = :f_hosp_code                        ");
		sql.append("      AND A.CODE = :f_code                          		");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);	
		query.setParameter("f_language", language);	
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	
}

