package nta.med.data.dao.medi.bas.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.adma.BAS0101U04GrdDetailInfo;
import nta.med.data.model.ihis.bass.BAS0001U00grdDetailItemInfo;
import nta.med.data.model.ihis.bass.BAS0101U00GrdDetailListItemInfo;
import nta.med.data.model.ihis.bass.BAS0101U00grdDetailItemInfo;
import nta.med.data.model.ihis.bass.LoadDepartmentTypeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdCSC0108Info;
import nta.med.data.model.ihis.inps.INP1003U01cboEmergencyInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02LayProtectGubunListInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetGroupKeyInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01PrintNameInfo;
import nta.med.data.model.ihis.ocso.GwaListItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04CboJubsuGubunInfo;
import nta.med.data.model.ihis.system.GetORCAEnvInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
@Repository("bas0102Repository")
public class Bas0102RepositoryImpl extends SimpleJpaRepository<Bas0102, Long> implements Bas0102Repository {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0102RepositoryImpl(EntityManager entityManager) {
		super(Bas0102.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public Bas0102 save(Bas0102 entity) {
		return super.save(entity);
	}

	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public List<Bas0102> save(List<Bas0102> entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public void delete(Bas0102 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value = "Bas0102Repository")
	public String getTChkBAS0101U00Execute(String hospCode, String codeType, String code, String language){
		String sql = "SELECT 'Y' FROM Bas0102 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code  = :f_code AND language = :language";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("language", language);
		List<String> resultList = query.getResultList();
		if (!CollectionUtils.isEmpty(resultList)) {
			return resultList.get(0);
		}
		return null;
	}
	
	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public Integer updateBAS0101U00Execute(String hospCode, String userId, Date updDate, String codeName,
			 String groupKey, String remark, Double sortKey,
			 String codeType, String code, String language){
		String sql = "UPDATE Bas0102 SET updId = :q_user_id, updDate = :f_upd_date, codeName = :f_code_name , "
				+ "groupKey = :f_group_key, remark  = :f_remark, sortKey  = :f_sort_key "
				+ "WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code  = :f_code AND language = :language";
		Query query = entityManager.createQuery(sql);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_upd_date", updDate);
		query.setParameter("f_code_name", codeName);
		query.setParameter("f_group_key", groupKey);
		query.setParameter("f_remark", remark);
		query.setParameter("f_sort_key", sortKey);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public Integer deleteBAS0101U00Execute( String hospCode, String codeType, String code, String language){
		String sql = "DELETE FROM Bas0102 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code = :f_code AND language = :language ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("language", language);
		return query.executeUpdate();
	}

	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> getByCodeAndCodeNameAndCodeType(
			 String hospCode,
			 String code,
			 String find1,
			 String language){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode  AND a.code LIKE :code AND (a.code LIKE :find1 OR a.codeName LIKE :find1) " +
				   "AND a.codeType = 'DOCTOR_GRADE' AND a.language = :language ORDER BY a.code";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("find1", find1);
		query.setParameter("language", language);
		return query.getResultList();
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> getByCodeAndCodeType(String hospCode, String code, String codeType, String language){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode  AND a.code = :code "+
			"AND a.codeType = :codeType AND a.language = :language ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		return query.getResultList();
	}
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> getByHospCodeAndCodeType(String hospCode, String codeType1, String codeType2, String codeType3){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode "+
					"AND a.codeType IN (:codeType1, :codeType2, :codeType3) ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);

		query.setParameter("codeType1", codeType1);
		query.setParameter("codeType2", codeType2);
		query.setParameter("codeType3", codeType3);
		return query.getResultList();
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> getAllByLikeCodeAndCodeType(
			 String hospCode,
			 String code,
			 String codeType,
			 String language){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode  AND a.code LIKE :code "+
			"AND a.codeType = :codeType AND a.language = :language ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		return query.getResultList();
	}
	
	@Cacheable(value = "Bas0102Repository")
	public String getBAS0210U00layDupCheck(String hospCode, String language, String code){
		String sql = "SELECT 'Y'  FROM Bas0102 A WHERE A.hospCode = :f_hosp_code AND A.language = :f_language  AND A.codeType = 'JOHAP_GUBUN' AND A.code = :f_code ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_language", language);
		List<String> resultList = query.getResultList();
		if (!CollectionUtils.isEmpty(resultList)) {
			return resultList.get(0);
		}
		return null;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public String getCodeNameByCodeTypeAndCode(String hospCode,
			String language, String codeType, String code){
		String sql = "SELECT codeName FROM Bas0102  WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type  AND code = :f_code ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		List<String> resultList = query.getResultList();
		if (!CollectionUtils.isEmpty(resultList)) {
			return resultList.get(0);
		}
		return null;
	}

	@Cacheable(value = "Bas0102Repository")
	public String checkExitsByCodeType( String hospCode, String codeType,  String language){
		String sql = "SELECT DISTINCT 'Y' FROM Bas0102 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND language = :f_language ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<String> resultList = query.getResultList();
		if (!CollectionUtils.isEmpty(resultList)) {
			return resultList.get(0);
		}
		return null;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> getByCodeType(
			 String hospCode,
			 String codeType,
			 String language){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode AND a.codeType = :codeType AND a.language = :language order by a.hospCode, a.codeType, a.sortKey";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		return query.getResultList();
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> findByHospCodeAndCodeType(String hospCode, String codeType){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode AND a.codeType = :codeType order by a.language";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		return query.getResultList();
	}

	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> findByHospCodeAndCodeTypeAndCodename(String hospCode, String codeType, List<String> codeNameList){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode = :hospCode AND a.codeType = :codeType AND a.code IN :codeList order by a.language";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("codeList", codeNameList);
		return query.getResultList();
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<Bas0102> findByCodeTypeAndCodename(String codeType, List<String> codeNameList){
		String sql = "SELECT a FROM Bas0102 a WHERE a.hospCode IN (SELECT hospCode FROM Bas0102 WHERE codeType='ACCT_TYPE' AND code = '00') AND a.codeType = :codeType AND a.code IN :codeList ORDER BY a.hospCode";
		Query query = entityManager.createQuery(sql);
		query.setParameter("codeType", codeType);
		query.setParameter("codeList", codeNameList);
		return query.getResultList();
	}
	
	public List<Bas0102> getByCodeTypeAndCodeAndCodeName(String codeType, String code, String codeName)
	{
		String sql = "SELECT a FROM Bas0102 a WHERE a.codeType = :codeType AND a.code = :code and a.codeName = :codeName";
		Query query = entityManager.createQuery(sql);

		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("codeName", codeName);
		return query.getResultList();
	}
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getNuroReceptionTypeList(String language,
			String hospitalCode, String codeType, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if (isAll) {
			sql.append("SELECT '%', FN_ADM_MSG('221', :language)                                 ");
			sql.append("FROM DUAL                                                                ");
			sql.append("UNION                                                                    ");
		}
		sql.append("SELECT CODE, CODE_NAME                                                        ");
		sql.append("FROM BAS0102                                                                  ");
		sql.append("WHERE HOSP_CODE = :hospitalCode AND CODE_TYPE = :codeType  AND LANGUAGE = :language ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("codeType", codeType);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query,
				ComboListItemInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<TripleListItemInfo> getByCodeTypeList(String language,
			String hospitalCode, List<String> codeType, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if (isAll) {
			sql.append("SELECT '%', FN_ADM_MSG('221', :language), 'ALL'                                  ");
			sql.append("UNION                                                                            ");
		}
		sql.append("SELECT CODE, CODE_NAME, CODE_TYPE                                                    ");
		sql.append("FROM BAS0102                                                                         ");
		sql.append("WHERE HOSP_CODE = :hospitalCode AND CODE_TYPE IN :codeType  AND LANGUAGE = :language ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("codeType", codeType);
		
		List<TripleListItemInfo> list = new JpaResultMapper().list(query,
				TripleListItemInfo.class);
		return list;
	}

	@Override
	public String getJapanDateInfo(String hospCode, String language,
			String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', :naewonDate, :hospCode, :language) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("naewonDate", naewonDate);
		 
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<NuroOUT1101Q01PrintNameInfo> getNuroOUT1101Q01PrintNameInfo(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_NAME, A.SORT_KEY   ");
		sql.append("FROM BAS0102 A                   ");
		sql.append("WHERE A.HOSP_CODE = :hospCode    ");
		sql.append("  AND A.CODE_TYPE = 'PRINT_NAME' ");
		sql.append("  AND A.CODE      = 'SUJIN'      ");
		sql.append("  AND A.LANGUAGE = :language     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		List<NuroOUT1101Q01PrintNameInfo> list = new JpaResultMapper().list(
				query, NuroOUT1101Q01PrintNameInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOcsaComboListItemInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%' DOCTOR_GRADE                                                                 ");
		sql.append(" ,FN_NUR_LOAD_CODE_NAME('ALLTEXT', '%', :hospCode, :language) DOCTOR_GRADE_NAME          ");
		sql.append(" UNION ALL                                                                               ");
		sql.append(" SELECT A.CODE DOCTOR_GRADE                                                              ");
		sql.append(" , A.CODE_NAME DOCTOR_GRADE_NAME                                                         ");
		sql.append(" FROM BAS0102 A                                                                          ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                           ");
		sql.append(" AND A.CODE_TYPE = 'DOCTOR_GRADE'                                                        ");
		sql.append(" AND A.GROUP_KEY <> '2'                                                                  ");
		sql.append(" AND A.LANGUAGE = :language                                                              ");
		sql.append(" ORDER BY 1                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getOcsoOUTSANGU00FindWorker(
			String hospCode, String language, String sangEndSayU) {
	   StringBuilder sql = new StringBuilder();
	   sql.append("	SELECT A.CODE, 										");
	   sql.append("	A.CODE_NAME                                         ");
	   sql.append("	 FROM BAS0102 A                                     ");
	   sql.append("	WHERE A.CODE_TYPE = :sangEndSayU                    ");
	   sql.append("	  AND A.HOSP_CODE = :hospCode                       ");
	   sql.append(" AND A.LANGUAGE = :language                          ");
	   sql.append("	ORDER BY A.CODE ;                                   ");

	   Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("sangEndSayU", sangEndSayU);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
		
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<GwaListItemInfo> getGwaListItemInfo(String hospCode,
			String outJubsuyn) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GWA, A.BUSEO_NAME													");
		sql.append("	  FROM BAS0260 A                                                            ");
		sql.append("	 WHERE A.OUT_JUBSU_YN = :outJubsuyn  			                            ");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                           ");
		sql.append("	   AND A.START_DATE   = (SELECT MAX(B.START_DATE)                           ");
		sql.append("	                           FROM BAS0260 B                                   ");
		sql.append("	                          WHERE B.BUSEO_CODE  = A.BUSEO_CODE                ");
		sql.append("	                            AND B.START_DATE <= SYSDATE()                   ");
		sql.append("	                            AND B.HOSP_CODE   = A.HOSP_CODE  )              ");
		sql.append("	UNION                                                                       ");
		sql.append("	                                                                            ");
		sql.append("	SELECT '%' as GWA, FN_ADM_MSG('221', :language) as BUSEO_NAME               ");
		sql.append("	ORDER BY GWA;                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("outJubsuyn", outJubsuyn);
		
		List<GwaListItemInfo> listResult = new JpaResultMapper().list(query, GwaListItemInfo.class);
		return listResult;
	}
	
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getComboListItemInfoByCodeType(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CODE, CODE_NAME       ");
		sql.append("  FROM BAS0102			     ");
		sql.append(" WHERE HOSP_CODE = :hospCode ");
		sql.append("AND CODE_TYPE = :codeType    ");
		sql.append("AND LANGUAGE = :language    ");
		sql.append("ORDER BY SORT_KEY			 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<BAS0101U00grdDetailItemInfo> listBAS0101U00GrdDetail(String hosoCode,String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE , A.CODE  , A.CODE_NAME, A.GROUP_KEY, A.REMARK , A.SORT_KEY                  ");
		sql.append(" FROM BAS0102 A WHERE A.HOSP_CODE = :f_hosp_code AND A.CODE_TYPE = :f_code_type AND A.LANGUAGE = :language   ORDER BY A.CODE  ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hosoCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("language", language);
		List<BAS0101U00grdDetailItemInfo> listGrdDetail= new JpaResultMapper().list(query, BAS0101U00grdDetailItemInfo.class);
		return listGrdDetail;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getBAS0001U00CboHospJinGubun(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT CODE, CODE_NAME  FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE =:f_language  AND CODE_TYPE = 'HOSP_JIN_GUBUN' ORDER BY CODE ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getBAS0001U00FbxDodobuHyeunFindClick(String hospCode, String language, String codeType, String find) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE , A.CODE_NAME                                        ");
		sql.append(" FROM BAS0102 A                                                     ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code AND A.LANGUAGE = :f_language   ");
		sql.append(" AND A.CODE_TYPE    = :f_code_type                                  ");
		sql.append(" AND(A.CODE      LIKE :f_find1  OR A.CODE_NAME LIKE :f_find1  )     ");
		sql.append(" ORDER BY A.CODE													");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_find1", find + "%");
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getBAS0001U00FbxDodobuHyeunDataValidating(String hospCode, String language, String codeType, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE_NAME , SORT_KEY                                    ");
		sql.append(" FROM BAS0102                                                   ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE = :f_language      ");
		sql.append(" AND CODE_TYPE = :f_code_type AND CODE      = :f_code			");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<BAS0001U00grdDetailItemInfo> getBAS0001U00grdDetailItemInfo(String hospCode, String language, String codeType) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE, A.CODE, A.CODE_NAME, A.GROUP_KEY, A.REMARK , A.SORT_KEY    ");
		sql.append(" FROM BAS0102 A                                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code AND A.LANGUAGE = :f_language                  ");
		sql.append(" AND A.CODE_TYPE = :f_code_type                                                 ");
		sql.append(" ORDER BY A.CODE																");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<BAS0001U00grdDetailItemInfo> listResult = new JpaResultMapper().list(query, BAS0001U00grdDetailItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getBAS0210U00grdBAS0210GridColumnChanged(String hospCode,String language, String code) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT 'Y', A.CODE_NAME FROM BAS0102 A                                             						        ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code AND A.LANGUAGE = :f_language AND A.CODE_TYPE = 'JOHAP_GUBUN' AND A.CODE = :f_code  ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code", code);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getBAS0210U00fwkCommon(String hospCode,String language,String find) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.CODE , A.CODE_NAME                                      ");
		sql.append(" FROM BAS0102 A                                                   ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code 								  ");
		sql.append(" AND A.LANGUAGE = :f_language        						      ");
		sql.append(" AND A.CODE_TYPE = 'JOHAP_GUBUN'                                  ");
		sql.append(" AND (   A.CODE  LIKE :f_find1 OR A.CODE_NAME LIKE :f_find1 )     ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_find1", find + "%");
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCht0115Q01xEditGridCell10ListItem(
			String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE, CODE_NAME  					");
		sql.append("	FROM BAS0102                                ");
		sql.append("	WHERE HOSP_CODE = :hospCode                 ");
		sql.append("	AND CODE_TYPE = :codeType                   ");
		sql.append("	AND LANGUAGE = :language                    ");
		
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCht0115Q01cboDetailGubunListItem(
			String hospCode, String codeType, String language,String code99AndOrderBy) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%' CODE, FN_ADM_MSG(221,:language) CODE_NAME 	");
		sql.append("	UNION                                                   ");
		sql.append("	SELECT CODE, CODE_NAME                                  ");
		sql.append("	FROM BAS0102                                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode                             ");
		sql.append("	 AND CODE_TYPE = :codeType                              ");
		sql.append("	AND LANGUAGE = :language                                ");
		if("JOHAP_GUBUN".equalsIgnoreCase(code99AndOrderBy) ){
			sql.append(" AND CODE <> '99' ORDER BY CODE                         ");
		}
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<BAS0101U00GrdDetailListItemInfo> getBAS0101U00GrdDetailListItem(
			String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE							");		
		sql.append("	     , A.CODE                               ");
		sql.append("	     , A.CODE_NAME                          ");
		sql.append("	     , A.GROUP_KEY                          ");
		sql.append("	     , A.REMARK                             ");
		sql.append("	     , A.SORT_KEY                           ");
		sql.append("	  FROM BAS0102 A                            ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode              ");
		sql.append("	   AND A.CODE_TYPE = :codeType              ");
		sql.append("	   AND A.LANGUAGE = :language               ");
		sql.append("	 ORDER BY A.CODE                            ");
		 
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<BAS0101U00GrdDetailListItemInfo> list = new JpaResultMapper().list(query, BAS0101U00GrdDetailListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public String getBas0101U00TransactionDeleteChk(String hospCode,
			String codeType,String language) {
		StringBuilder sql = new StringBuilder();           
		sql.append("   SELECT 'Y'                          ");
        sql.append("   FROM BAS0102                        ");
        sql.append("   WHERE HOSP_CODE = :hospCode         ");
        sql.append("    AND CODE_TYPE = :codeType          ");
        sql.append("    AND LANGUAGE = :language           ");
        sql.append("    AND LIMIT 1                        ");

        Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getOUT0101Q01CboSex(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();   
		sql.append("SELECT CODE, CODE_NAME FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code  AND LANGUAGE =:f_language  AND CODE_TYPE = 'SEX_GUBUN' ");

        Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String callFnBasLoadCodeName(String codeType, String code,
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_CODE_NAME(:codeType, :code, :hospCode, :language)");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOcsoOCS1003P01GetGroupKey(String hospCode, String language, String pkout1001, String codeType){
		StringBuilder sql = new StringBuilder(); 
		sql.append("SELECT B.GROUP_KEY                          ");
		sql.append("       FROM OUT1001 A                       ");
		sql.append("           ,BAS0102 B                       ");
		sql.append("      WHERE A.HOSP_CODE  = :f_hosp_code     ");
		sql.append("        AND A.PKOUT1001  = :naewon_key      ");
		sql.append("        AND B.HOSP_CODE  = A.HOSP_CODE      ");
		sql.append("        AND B.CODE_TYPE  = :f_code_type     ");
		sql.append("        AND B.LANGUAGE   = :f_language      ");
		sql.append("        AND B.CODE       = A.JUBSU_GUBUN    ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		query.setParameter("naewon_key", pkout1001);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getComboJubsuGubun(String hospCode,String language, boolean orderBySortKey) {
		StringBuilder sql = new StringBuilder(); 
		sql.append("  SELECT A.CODE, A.REMARK               ");
		sql.append("     FROM BAS0102 A                     ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("    AND A.LANGUAGE =:f_language         ");
		sql.append("    AND A.CODE_TYPE = 'JUBSU_GUBUN'     ");
		if(orderBySortKey){
			sql.append(" ORDER BY A.SORT_KEY			    ");
		}else{
			sql.append(" ORDER BY 1						    ");
		}
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCHT0115Q00LayoutCommon(String hospCode,String language) {
		StringBuilder sql = new StringBuilder(); 
		sql.append(" SELECT '%', FN_ADM_MSG(221,:f_language)    ");
		sql.append("  UNION                                     ");
		sql.append(" SELECT CODE, CODE_NAME                     ");
		sql.append("   FROM BAS0102                             ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code            ");
		sql.append("  AND LANGUAGE =:f_language                 ");
		sql.append("    AND CODE_TYPE = 'SUSIK_GUBUN'           ");
		sql.append("    AND CODE      < '8'						");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCodeNameListItem (String hospCode, String codeType, String order, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE, CODE_NAME 			");
		sql.append("	FROM BAS0102                    ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("	AND CODE_TYPE = :f_code_type    ");
		sql.append("  AND LANGUAGE = :f_language        ");
		
		if (!StringUtils.isEmpty(order)){
			sql.append("	ORDER BY CODE    ");
		}
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<ComboListItemInfo> getAdmMsgListItem(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ' ', FN_ADM_MSG(3395, :f_language)	 ");
		sql.append("	UNION ALL                                    ");
		sql.append("	SELECT CODE, CODE_NAME FROM                  ");
		sql.append("	BAS0102                                      ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code               ");
		sql.append("	AND LANGUAGE = :f_language                   ");
		sql.append("	AND CODE_TYPE = :f_code_type                 ");
		sql.append("	ORDER BY 1                                   ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getEditGridOcs0131ListItem(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE     , A.CODE_NAME 						   ");
		sql.append("	 FROM BAS0102 A                                            " );
		sql.append("	 WHERE A.HOSP_CODE   = :hospCode                           " );
		sql.append("	 AND A.CODE_TYPE   = :codeType                             " );
		sql.append("  	 AND A.LANGUAGE = :language                                ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.SORT_KEY             " );
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<ComboListItemInfo> getAdmMesgListItemInfo (String language, String hospCode, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '', FN_ADM_MSG('3395',:f_language)  ");
		sql.append("	  UNION                                    ");
		sql.append("	SELECT CODE, CODE_NAME                     ");
		sql.append("	 FROM BAS0102                              ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code             ");
		sql.append("	  AND CODE_TYPE = :f_code_type             ");
		sql.append("	  ORDER BY 1;                              ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCodeCodeNameListItemInfo(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE                     ");
		sql.append("	, CODE_NAME                     ");
		sql.append("	FROM BAS0102                    ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("	AND LANGUAGE = :f_language      ");
		sql.append("	AND CODE_TYPE = :f_code_type    ");
		sql.append("	ORDER BY CODE                   ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCodeCodeNameWhereFind1Item (String hospCode, String codeType, String find1, boolean isTwo, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE						  ");
		sql.append("	,A.CODE_NAME                          ");
		sql.append("	FROM BAS0102 A                        ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code      ");
		sql.append("	AND A.CODE_TYPE = :f_code_type        ");
		sql.append("	AND(A.CODE LIKE :f_find1       		  ");
		sql.append("	OR A.CODE_NAME LIKE :f_find1  )		  ");
		sql.append("    AND A.LANGUAGE = :f_language		  ");
		sql.append("	ORDER BY A.CODE                       ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		if(isTwo){
			query.setParameter("f_find1", "%" + find1 + "%");
		}else{
			query.setParameter("f_find1", find1 + "%");
		}
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCodeNameSortKeyListItem (String hospCode, String language, String codeType, String fCode){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE_NAME			   ");
		sql.append("	, SORT_KEY                     ");
		sql.append("	FROM BAS0102                   ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code ");
		sql.append("    AND LANGUAGE = :f_language	   ");
		sql.append("	AND CODE_TYPE = :f_code_type   ");
		sql.append("	AND CODE = :f_code             ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", fCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0102Repository")
	public List<BAS0101U04GrdDetailInfo> getBAS0101U04GrdDetailInfo(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE                   ");
		sql.append("      , A.CODE                        ");
		sql.append("      , A.CODE_NAME                   ");
		sql.append("      , A.GROUP_KEY                   ");
		sql.append("      , A.REMARK                      ");
		sql.append("      , A.SORT_KEY                    ");
		sql.append("   FROM BAS0102 A                     ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("  	AND A.LANGUAGE = :f_language      ");
		sql.append("    AND A.CODE_TYPE = :f_code_type    ");
		sql.append("  ORDER BY A.CODE                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<BAS0101U04GrdDetailInfo> list = new JpaResultMapper().list(query, BAS0101U04GrdDetailInfo.class);
		return list;
	}

	public List<BAS0101U04GrdDetailInfo> getBAS0101U04GrdDetailInfoIgnoreLanguage(String hospCode, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE                   ");
		sql.append("      , A.CODE                        ");
		sql.append("      , A.CODE_NAME                   ");
		sql.append("      , A.GROUP_KEY                   ");
		sql.append("      , A.REMARK                      ");
		sql.append("      , A.SORT_KEY                    ");
		sql.append("   FROM BAS0102 A                     ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("    AND A.CODE_TYPE = :f_code_type    ");
		sql.append("  ORDER BY A.CODE                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		
		List<BAS0101U04GrdDetailInfo> list = new JpaResultMapper().list(query, BAS0101U04GrdDetailInfo.class);
		return list;
	}
	
	@Override
	public List<PHY2001U04CboJubsuGubunInfo> getPHY2001U04CboJubsuGubunInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%'                                " );
		sql.append("      , FN_ADM_MSG('221', :f_language)     " );
		sql.append("      , cast(0 as char)                    " );
		sql.append("   FROM DUAL                               " );
		sql.append("  UNION                                    " );
		sql.append(" SELECT '88'                               " );
		sql.append("      , 'リハビリ診察'                         " );
		sql.append("      , cast(1 as char)                    " );
		sql.append("   FROM DUAL                               " );
		sql.append("  UNION                                    " );
		sql.append(" SELECT CODE                               " );
		sql.append("      , CODE_NAME                          " );
		sql.append("      , cast(SORT_KEY  as char)            " );
		sql.append("   FROM BAS0102                            " );
		sql.append("  WHERE HOSP_CODE = :f_hosp_code           " );
		sql.append("  AND LANGUAGE = :f_language               " );
		sql.append("    AND CODE_TYPE = 'JUBSU_GUBUN'          " );
		sql.append("  ORDER BY 3								");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<PHY2001U04CboJubsuGubunInfo> list = new JpaResultMapper().list(query, PHY2001U04CboJubsuGubunInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<NuroOUT0101U02LayProtectGubunListInfo> getNuroOUT0101U02LayProtectGubunListInfo(
			String hospCode, String language, String codeType, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.CODE																				");
		sql.append("     , A.CODE_NAME                                                                          ");
		sql.append("  FROM BAS0102 A                                                                            ");
		sql.append(" WHERE A.HOSP_CODE    = :hospCode                                                           ");
		sql.append("  AND A.LANGUAGE      = :language                                                         ");
		sql.append("   AND A.CODE_TYPE    = :codeType                                                           ");
		sql.append("   AND(A.CODE      LIKE CONCAT(:find1,'%') OR A.CODE_NAME LIKE CONCAT(:find1,'%') )         ");
		sql.append(" ORDER BY A.CODE                                                                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		query.setParameter("find1", find1);
	
		List<NuroOUT0101U02LayProtectGubunListInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02LayProtectGubunListInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<NuroOUT1001U01GetGroupKeyInfo> getNuroOUT1001U01GetGroupKeyInfo(String hospCode, String language, String codeType, String code) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT A.GROUP_KEY								 ");
		sql.append("  FROM BAS0102 A                                 ");
		sql.append(" WHERE     A.HOSP_CODE = :hospCode               ");
		sql.append("  AND A.LANGUAGE     = :language                 ");
		sql.append("       AND A.CODE_TYPE = :codeType               ");
		sql.append("       AND A.CODE = :code                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);

		List<NuroOUT1001U01GetGroupKeyInfo> list = new JpaResultMapper().list(query, NuroOUT1001U01GetGroupKeyInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0102Repository")
	public List<ComboListItemInfo> getCLIS2015U02CboStatus(String hospCode, String language, String codeType, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if (isAll) {
			sql.append("SELECT '%', FN_ADM_MSG('221', :f_language)       ");
			sql.append("UNION                                            ");
		}
		sql.append("	SELECT CODE                     ");
		sql.append("	, CODE_NAME                     ");
		sql.append("	FROM BAS0102                    ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("  AND LANGUAGE     = :f_language    ");
		sql.append("	AND CODE_TYPE = :f_code_type    ");
		sql.append("	ORDER BY 1                      ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getCodeByCodeTypeAndCodeName(String hospCode, String codeType, String language, String codeName) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE		FROM BAS0102							");
		sql.append(" WHERE HOSP_CODE = :hosp_code 								");
		sql.append("   AND CODE_TYPE = :code_type								");
		sql.append("   AND LANGUAGE = :langauge 								");
		sql.append("   AND CODE_NAME = :code_name        						");

		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("code_type", codeType);
		query.setParameter("langauge", language);
		query.setParameter("code_name", codeName);
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public String getCodeUsingORCA(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                              	");
		sql.append(" CODE                                                                                	");
		sql.append("     FROM                                                                            	");
		sql.append("         BAS0102                                                                     	");
		sql.append("     WHERE                                                                           	");
		sql.append("             HOSP_CODE                                           =        :hospCode   	");
		sql.append("             AND CODE_TYPE                                       =        'ACCT_TYPE'	");
		sql.append("             AND LANGUAGE                                        =        :language   	");
	                
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}		
		return null;
	}
	
	@Override
	public List<GetORCAEnvInfo> getORCAEnvInfo(String hospCode, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                                	");
		sql.append("   MAX(case when CODE = 'ORCA_IP' then CODE_NAME else '' end) ORCA_IP,                 	");
		sql.append("   MAX(case when CODE = 'ORCA_PORT' then CODE_NAME else '' end) ORCA_PORT, 			 	");
		sql.append("   MAX(case when CODE = 'ORCA_USER' then CODE_NAME else '' end) ORCA_USER,             	");
		sql.append("   MAX(case when CODE = 'ORCA_PWD' then CODE_NAME else '' end) ORCA_PWD    			 	");
		sql.append("     FROM                                                                          	 	");
		sql.append("         BAS0102                                                               	 	 	");
		sql.append("     WHERE                                                                             	");
		sql.append("         HOSP_CODE       = :hospCode                                                   	");
		sql.append("         AND CODE_TYPE   =        'ACCT_ORCA'                                          	");
		sql.append("         AND LANGUAGE    = :language                                                   	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<GetORCAEnvInfo> list = new JpaResultMapper().list(query, GetORCAEnvInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getPersonListItemInfo(String hospCode, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT '%' CODE , FN_ADM_MSG('221',:f_language) CODE_NAME   		");
		sql.append(" UNION ALL 															");
		sql.append("  SELECT DISTINCT  A.CODE , A.CODE_NAME                             ");
		sql.append("    FROM BAS0102 A                    		        				");
		sql.append("    WHERE HOSP_CODE = :f_hosp_code  			    				");
		sql.append("    AND A.CODE_TYPE = 'BILLING_TYPE'      					    	");
		sql.append("    AND A.LANGUAGE = :f_language      					    		");
		sql.append("    ORDER BY 1     					                				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getINV0101ComboListItemInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT DISTINCT A.CODE																		");
		sql.append("     , A.CODE_NAME                                                                          ");
		sql.append("  FROM BAS0102 A                                                                            ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                        ");
		sql.append("   AND A.CODE_TYPE    = 'ADMIN_GUBUN'                                                       ");
		sql.append(" ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.SORT_KEY                                              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
	
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	//[Start] Med-1.5.2 Basic Design: MED-8065
	@CacheEvict(value = "Bas0102Repository", allEntries = true)
	public Integer updateBas0102U04(String userId, Date updDate, String codeName, String codeType, String code, String hospCode, String language){
		String sql = " UPDATE Bas0102 SET updId = :q_user_id, updDate = :f_upd_date, codeName = :f_code_name "
				+ " WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code  = :f_code AND language = :language ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_upd_date", updDate);
		query.setParameter("f_code_name", codeName);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	public BigDecimal getSeqValue(String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT SeqValue                				");
		sql.append("  FROM SWT_Sequence        					");
		sql.append(" WHERE SeqName = :seqName       			");
		sql.append("   AND HOSP_CODE = :hospCode           		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);
		query.setParameter("hospCode", hospCode);
		List<BigDecimal> seqValue = query.getResultList();
		if(!CollectionUtils.isEmpty(seqValue)){
			return seqValue.get(0);
		}
		return null;
	}
	
	@Override
	public Integer updateSequencePidSeq(String codeName, String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE SWT_Sequence                			");
		sql.append("  SET SeqValue = :codeName        			");
		sql.append(" WHERE HOSP_CODE = :hospCode       			");
		sql.append(" AND SeqName = :seqName                     ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeName", CommonUtils.parseBigDecimal(codeName));
		query.setParameter("hospCode", hospCode);
		query.setParameter("seqName", seqName);
		return query.executeUpdate();
	}
	
	@Override
	public Integer updateSequenceSeqStep(String codeName, String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE SWT_Sequence                			");
		sql.append("  SET SeqInc = :codeName        			");
		sql.append(" WHERE HOSP_CODE = :hospCode       			");
		sql.append(" AND SeqName = :seqName                     ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeName", CommonUtils.parseInteger(codeName));
		query.setParameter("hospCode", hospCode);
		query.setParameter("seqName", seqName);
		return query.executeUpdate();
	}
	
	//[End] Med-1.5.2 Basic Design: MED-8065
	
	@Override
	public List<LoadDepartmentTypeInfo> getDepartmentTypeInfo(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE                        ");
		sql.append("      , A.CODE_TYPE                   ");
		sql.append("      , A.HOSP_CODE                   ");
		sql.append("      , A.CODE_NAME                   ");
		sql.append("   FROM BAS0102 A                     ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("    AND A.CODE_TYPE = :f_code_type    ");
		sql.append("    AND A.LANGUAGE  = :f_language     ");
		sql.append("  ORDER BY A.CODE                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<LoadDepartmentTypeInfo> list = new JpaResultMapper().list(query, LoadDepartmentTypeInfo.class);
		return list;
	}
	
	@Override
	public List<INP1003U01cboEmergencyInfo> getINP1003U01cboEmergencyInfo(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT  ''          CODE						");
		sql.append("           , ''          CODE_NAME					");
		sql.append("           , '0'         NUMBER						");
		sql.append("      UNION ALL										");
		sql.append("     SELECT A.CODE       CODE						");
		sql.append("          , A.CODE_NAME  CODE_NAME					");
		sql.append("          , '1'          NUMBER						");
		sql.append("       FROM BAS0102 A								");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("        AND A.CODE_TYPE = 'EMERGENCY_GUBUN'			");
		sql.append("      ORDER BY NUMBER, CODE							");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<INP1003U01cboEmergencyInfo> list = new JpaResultMapper().list(query, INP1003U01cboEmergencyInfo.class);
		return list;
	}
	
	@Override
	public List<INP1003U00grdCSC0108Info> getINP1003U00grdCSC0108(String hospCode, String categoryGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT                    									");
		sql.append("    	A.CODE,                    								");
		sql.append("        A.CODE_NAME,                    						");
		sql.append("        'N'                    									");
		sql.append("    FROM                    									");
		sql.append("    	BAS0102 A                    							");
		sql.append("    WHERE                    									");
		sql.append("    	A.HOSP_CODE = :f_hosp_code                    			");
		sql.append("        AND A.CODE_TYPE = :f_category_gubun                    	");
		sql.append("        ORDER BY A.CODE                    						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_category_gubun", categoryGubun);
		
		List<INP1003U00grdCSC0108Info> listInfo = new JpaResultMapper().list(query, INP1003U00grdCSC0108Info.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getByCodeTypeContainNull(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '' CODE							");
		sql.append("          , '' CODE_NAME					");
		sql.append("          FROM DUAL							");
		sql.append("      UNION 								");
		sql.append("     SELECT CODE							");
		sql.append("          , CODE_NAME						");
		sql.append("       FROM BAS0102							");
		sql.append("      WHERE HOSP_CODE = :f_hosp_code		");
		sql.append("        AND CODE_TYPE = :f_code_type		");
		sql.append("        AND LANGUAGE  = :f_language   		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1001R09cboWingGubun(String hospCode, String language, String codeType) {		
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT B.CODE                                            ");
		sql.append("        , B.CODE_NAME                                       ");
		sql.append("   FROM (SELECT '%'          CODE                           ");
		sql.append("        , FN_ADM_MSG('221',:f_language)    CODE_NAME        ");
		sql.append("        , 0         SORT_KEY                                ");
		sql.append("    FROM DUAL                                               ");
		sql.append("   UNION ALL                                                ");
		sql.append("   SELECT A.CODE          CODE                              ");
		sql.append("        , A.CODE_NAME     CODE_NAME                         ");
		sql.append("        , A.SORT_KEY      SORT_KEY                          ");
		sql.append("      FROM BAS0102 A                                        ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                        ");
		sql.append("      AND A.CODE_TYPE = :f_code_type                        ");
		sql.append("      AND A.LANGUAGE  = :f_hosp_code                        ");
		sql.append("    ORDER BY SORT_KEY) B                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}
	