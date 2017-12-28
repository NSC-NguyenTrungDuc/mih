package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.xrt.Xrt0102;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayMakeTabPageListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayPacsInfoListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0101U00GrdDcodeInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayCPLInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("Xrt0102Repository")
public class Xrt0102RepositoryImpl extends SimpleJpaRepository<Xrt0102, Long> implements Xrt0102Repository {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Xrt0102RepositoryImpl(EntityManager entityManager) {
		super(Xrt0102.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	public Xrt0102 save(Xrt0102 entity) {
		return super.save(entity);
	}
	
	
	@Override
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	public List<Xrt0102> save(List<Xrt0102> entities) {
		return super.save(entities);
	}
	
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	@Override
	public void delete(Xrt0102 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value="Xrt0102Repository")
	public String getYValueLayDupD(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code){
		String sqlQuery = "SELECT 'Y' FROM Xrt0102 WHERE hospCode = :f_hosp_code AND language = :f_language  AND codeType = :f_code_type AND code = :f_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@Cacheable(value="Xrt0102Repository")
	public List<String> checkExistValueXrt0101U00ExecuteCase1(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language, @Param("f_code_type") String codeType){
		String sqlQuery = "SELECT 'X'  FROM Xrt0102 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type";
		Query query= entityManager.createQuery(sqlQuery);

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);

		List<String> listStr = query.getResultList();
		return listStr;
	}
	
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	public Integer deleteXrt0102XRT0101U00ExecuteCase1(@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,@Param("f_code_type") String codeType){
		String sqlQuery = "DELETE Xrt0102 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type";
		Query query = entityManager.createQuery(sqlQuery);

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);

		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	public Integer updateXrt0102XRT0101U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,@Param("q_user_id") String userId,
			@Param("f_code2") String code2,@Param("f_code_name") String codeName,@Param("f_seq") Double seq,
			@Param("f_code_value") String codeValue,@Param("f_code_type") String codeType,@Param("f_code") String code){
		String sqlQuery = "UPDATE Xrt0102 SET updId  = :q_user_id, updDate    = SYSDATE(), code2  = :f_code2, codeName   = :f_code_name, "
					+ "seq   = :f_seq , codeValue   = :f_code_value WHERE hospCode   = :f_hosp_code AND language = :f_language AND codeType = :f_code_type AND code  = :f_code ";
		Query query = entityManager.createQuery(sqlQuery);

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_code2", code2);
		query.setParameter("f_code_name", codeName);
		query.setParameter("f_seq", seq);
		query.setParameter("f_code_value", codeValue);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Xrt0102Repository", allEntries = true)
	public Integer deleteXrt0102XRT0101U00ExecuteCase2(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code){
		String sqlQuery = "DELETE Xrt0102 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type AND code  = :f_code ";
		Query query = entityManager.createQuery(sqlQuery);

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);

		return query.executeUpdate();
	}
	
	@Cacheable(value="Xrt0102Repository")
	public String getXRT0001U00FbxDataValidatingSelectXRT0102(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,@Param("f_code") String code){
		String sqlQuery = "SELECT codeName FROM Xrt0102 where hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type  AND code = :f_code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@Cacheable(value="Xrt0102Repository")
	public List<Xrt0102> getByCodeTypeAndCode(@Param("hospCode") String hospCode,@Param("f_language") String language,
			@Param("codeType") String codeType, @Param("code") String code){
		String sqlQuery = "SELECT xrt FROM Xrt0102 xrt where xrt.hospCode = :hospCode AND xrt.language = :f_language AND xrt.codeType = :codeType  "
				+ " AND xrt.code like CONCAT(:code, '%') AND IFNULL(xrt.code2, 'Y') <> 'N' ORDER BY xrt.seq";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		List<Xrt0102> listStr = query.getResultList();
		return listStr;
	}
	
	@Cacheable(value="Xrt0102Repository")
	public List<Xrt0102> getByCodeType(@Param("hospCode") String hospCode,@Param("f_language") String language,@Param("codeType") String codeType){
		String sqlQuery = "SELECT xrt FROM Xrt0102 xrt where xrt.hospCode = :hospCode AND xrt.language = :f_language AND xrt.codeType = :codeType  AND IFNULL(xrt.code2, 'Y') <> 'N' ORDER BY xrt.seq";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("codeType", codeType);
		List<Xrt0102> listStr = query.getResultList();
		return listStr;
	}
	
	
	@Override
	public List<XRT0000Q00LayMakeTabPageListItemInfo> getXRT0000Q00LayMakeTabPage(String hospCode, String language) {
		StringBuilder sql=new StringBuilder();
		sql.append(" SELECT '%', FN_ADM_MSG('221',:language)  , -1                        ");
		sql.append("     UNION ALL                                                          ");
		sql.append("         SELECT CODE2, CODE_NAME , SEQ                                  ");
		sql.append("             FROM XRT0102                                               ");
		sql.append("              WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE =:language    ");
		sql.append("        AND CODE_TYPE = 'X1' AND CODE2 <> 'N' ORDER BY 3				");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<XRT0000Q00LayMakeTabPageListItemInfo> listLayMakeTab= new JpaResultMapper().list(query,XRT0000Q00LayMakeTabPageListItemInfo.class);
		return listLayMakeTab;
	}
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<XRT0101U00GrdDcodeInfo> getXRT0101U00GrdDCodeListItemInfo(String hospCode,String language, String codeType) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT CODE_TYPE, CODE, CODE2, CODE_NAME, CODE_NAME2, SEQ, CODE_VALUE                         ");
		sql.append("      , CONCAT(IFNULL(TRIM(LPAD(SEQ,5,'0')),''),IFNULL(CODE_TYPE,''),IFNULL(CODE,''))          ");
		sql.append("   FROM XRT0102                                                                                ");
		sql.append("  WHERE HOSP_CODE        = :f_hosp_code   AND LANGUAGE =:f_language                            ");
		sql.append(" AND CODE_TYPE        = :f_code_type ORDER BY SEQ, CODE                                        ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<XRT0101U00GrdDcodeInfo> listGrdDCode= new JpaResultMapper().list(query, XRT0101U00GrdDcodeInfo.class);
		return listGrdDCode;
	}
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<ComboListItemInfo> getXRT0001U00InitializeComboListItemInfo(String hospCode, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME FROM XRT0102 WHERE HOSP_CODE = :f_hosp_code ");
		sql.append("  AND LANGUAGE = :f_language AND CODE_TYPE = 'X1' ORDER BY CODE     ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> getInitializeComboList= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return getInitializeComboList;
	}
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<ComboListItemInfo> getXRT0001U00MakeFindWorker(String hospCode, String language, String codeType, String find1,String orderBy) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME FROM XRT0102                                                                        ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE = :f_language AND CODE_TYPE = :f_code_type                      ");
		sql.append(" AND (CODE LIKE CONCAT('%',IFNULL(:f_find1,''),'%') OR CODE_NAME LIKE CONCAT('%',IFNULL(:f_find1,''),'%'))  ");
		if(orderBy.equalsIgnoreCase("CODE")){
			sql.append(" ORDER BY CODE																								");
		}else{
			sql.append(" ORDER BY SEQ																								");
		}
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_find1", find1);
		List<ComboListItemInfo> listFindWorker= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listFindWorker;
	}
	
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<XRT0000Q00LayPacsInfoListItemInfo> getXRT0000Q00LayPacsInfo(String hospCode, String codeType, String language, boolean orderByCode) {
		StringBuilder sql= new StringBuilder();
		sql.append("	SELECT CODE, CODE_NAME, CODE_VALUE  ");
		sql.append("	FROM XRT0102                        ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code      ");
		sql.append("	 AND CODE_TYPE = :f_code_type       ");
		sql.append("	 AND LANGUAGE = :language           ");
		if(orderByCode){
			sql.append("	 ORDER BY CODE                       ");
		}else{
			sql.append("	 ORDER BY SEQ                       ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("language", language);
		
		List<XRT0000Q00LayPacsInfoListItemInfo> listLayPacs = new JpaResultMapper().list(query, XRT0000Q00LayPacsInfoListItemInfo.class);
		return listLayPacs;
	}
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<ComboListItemInfo> getXRT0122U00LayComboItemInfo(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT ''	CODE											 ");
		sql.append("	     , ''    CODE_NAME                                            ");
		sql.append("	 UNION                                                   ");
		sql.append("	SELECT CODE                        CODE                  ");
		sql.append("	     , CONCAT(CODE , '  :  ' , CODE_NAME)  CODE_NAME     ");
		sql.append("	  FROM XRT0102                                           ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                          ");
		sql.append("	   AND CODE_TYPE = 'X1'                                  ");
		sql.append("	   AND IFNULL(CODE2,'Y') <> 'N'                          ");
		sql.append("	   AND LANGUAGE = :language                              ");
		sql.append("	 ORDER BY 2                                             ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listLayPacs = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listLayPacs;
	}
	
	@Override
	@Cacheable(value="Xrt0102Repository")
	public String getXRT0122U00LayCodeName(String hospCode, String code, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE_NAME  					");
		sql.append("	FROM XRT0102                        ");
		sql.append("	WHERE HOSP_CODE = :hospCode         ");
		sql.append("	AND CODE_TYPE = 'X1'                ");
		sql.append("	AND IFNULL(CODE2,'Y') != 'N'        ");
		sql.append("	AND CODE      = :code               ");
		sql.append("	AND LANGUAGE  = :language           ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<ComboListItemInfo> getComboListItemInfoFromXRT0102(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT CODE  CODE      	                                  ");
		sql.append("	     , CONCAT(CODE , '  :  ' , CODE_NAME)  CODE_NAME	      ");
		sql.append("	  FROM XRT0102	                                              ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code	 AND LANGUAGE  = :f_language  ");
		sql.append("	   AND CODE_TYPE = 'X1'                                      ");
		sql.append("	   AND IFNULL(CODE2,'Y') <> 'N'	                             ");
		sql.append("	 ORDER BY SEQ	                                             ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_language", language);
	    		
	    List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
	    return list;
	}

	@Override
	@Cacheable(value="Xrt0102Repository")
	public String getCodeNameFromXRT0102(String hospCode, String language, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE_NAME	");
		sql.append("	FROM XRT0102	");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code AND CODE_TYPE = 'X1'	");
		sql.append("	AND IFNULL(CODE2,'Y') <> 'N' AND LANGUAGE  = :f_language	");
		sql.append("	AND CODE = :f_code	");
		
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_language", language);
	    query.setParameter("f_code", code);
	    		
	    @SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value="Xrt0102Repository")
	public List<ComboListItemInfo> getXRT1002U00GrdXrayMethod(String hospCode,String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'N' CHHECK    , A.CODE_NAME METHOD  FROM XRT0102 A                                          ");
		sql.append(" WHERE A.CODE_TYPE = :f_code_type   AND A.HOSP_CODE = :f_hosp_code AND A.LANGUAGE = :f_language     ");
		sql.append(" ORDER BY 1                                                                                         ");
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_language", language);
	    query.setParameter("f_code_type", codeType);
	    List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
	    return list;
	}
	
	@Override
	public List<XRT1002U00LayCPLInfo> getXRT1002U00LayCPLInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(B.HANGMOG_NAME,FN_CPL_GUMSA_NM('1',A.CODE,NULL, :hospCode))                     ");
		sql.append("     , FN_CPL_HANGMOG_RESULT(:f_bunho,A.CODE, :hospCode)                                      ");
		sql.append("     , FN_CPL_HANGMOG_RESULT_DATE(:f_bunho,A.CODE, :hospCode)                                 ");
		sql.append("  FROM XRT0102 A LEFT JOIN OCS0103 B ON B.HANGMOG_CODE = A.CODE AND B.HOSP_CODE = A.HOSP_CODE ");
		sql.append(" WHERE A.HOSP_CODE       = :hospCode                                                          ");
		sql.append("   AND A.CODE_TYPE       = 'CPL_RESULT'                                                       ");
		sql.append("   limit 0,1;                                                                                 ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("f_bunho", bunho);
	    		
	    List<XRT1002U00LayCPLInfo> list = new JpaResultMapper().list(query, XRT1002U00LayCPLInfo.class);
	    return list;
	}


	@Override
	public boolean isExistedXrt0102(String hospCode, String codeType, String code, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y' 											");
		sql.append("	FROM XRT0102                       				 	");
		sql.append("	WHERE HOSP_CODE = :hospCode          				");
		sql.append("	AND CODE_TYPE = :codeType AND CODE = :code          ");
		sql.append("	AND LANGUAGE = :language        					");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		return false;
	}
}

