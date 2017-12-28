package nta.med.data.dao.medi.cht.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.cht.Cht0110;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.model.ihis.chts.CHT0110Q01GrdCHT0110MListInfo;
import nta.med.data.model.ihis.chts.CHT0110U00grdCHT0110ItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00SangCodeListInfo;

/**
 * @author dainguyen.
 */
@Repository("cht0110Repository")
public class Cht0110RepositoryImpl extends SimpleJpaRepository<Cht0110, Long> implements Cht0110Repository {
	private static final Log LOGGER = LogFactory.getLog(Cht0110RepositoryImpl.class);
	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired
	public Cht0110RepositoryImpl(EntityManager entityManager) {
		super(Cht0110.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	public Cht0110 save(Cht0110 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	public List<Cht0110> save(List<Cht0110> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	@Override
	public void delete(Cht0110 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value="Cht0110Repository")
	public String getCHT0110U00GetCodeName(String hospCode,String code){
		String sqlQuery = "SELECT A.sangName FROM Cht0110 A WHERE A.hospCode = :f_hosp_code AND A.sangCode =   :f_code ";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@Cacheable(value="Cht0110Repository")
	public String getSangCodeExt(String hospCode,String sangCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_CODE_EXT				");
		sql.append(" FROM CHT0110 A						");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code	");
		sql.append("   AND A.SANG_CODE =   :f_sang_code	");
		sql.append(" ORDER BY A.START_DATE DESC LIMIT 1");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sang_code", sangCode);
		List<String> listStr = query.getResultList();
		
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		
		return null;
	}
	
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	public Integer deleteCHT0110U00(String hospCode,String sangCode){
		String sqlQuery = "DELETE Cht0110 WHERE hospCode = :f_hosp_code AND sangCode = :f_sang_code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sang_code", sangCode);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	public Integer updateCHT0110U00(String hospCode,String userId,
			String sangName,String sangNameHan
			,String sangNameSelf,Date endDate
			,String bulyongYn,String sangCode){
		String sqlQuery = "UPDATE Cht0110 SET updId = :q_user_id  , updDate  = SYSDATE(), sangName  = :f_sang_name , "
			+ "sangNameHan  = :f_sang_name_han , sangNameSelf   = :f_sang_name_self   , "
			+ "endDate = :f_end_date  , bulyongYn  = :f_bulyong_yn  WHERE hospCode = :f_hosp_code AND sangCode = :f_sang_code ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_sang_name", sangName);
		query.setParameter("f_sang_name_han", sangNameHan);
		query.setParameter("f_sang_name_self", sangNameSelf);
		query.setParameter("f_end_date", endDate);
		query.setParameter("f_bulyong_yn", bulyongYn);
		query.setParameter("f_sang_code", sangCode);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value="Cht0110Repository")
	public String getSangName(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_NAME						");	
		sql.append("  FROM CHT0110 A                        ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode          ");
		sql.append("   AND A.SANG_CODE = :code              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public String getGwaName(String hospCode, String language, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_NAME( :code, SYSDATE(), :hospCode, :language); ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("code", code);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public String getDoctorName(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_DOCTOR_NAME( :code, SYSDATE(), :hospCode )");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value="Cht0110Repository")
	public List<OcsaOCS0204U00SangCodeListInfo> getOcsaOCS0204U00SangCodeListOcsaOCS0204U00FindWorkerList(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SANG_CODE, A.SANG_NAME      ");
		sql.append("  FROM CHT0110 A                     ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("ORDER BY 1, 2                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<OcsaOCS0204U00SangCodeListInfo> list = new JpaResultMapper().list(query, OcsaOCS0204U00SangCodeListInfo.class);
		return list;
	}

	@Override
	@Cacheable(value="Cht0110Repository")
	public List<CHT0110U00grdCHT0110ItemInfo> getCHT0110U00grdCHT0110ItemInfo(String hospCode, String sangInx, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_CODE                             ,       																					");
		sql.append("        A.SANG_NAME                             ,       																					");
		sql.append("        A.SANG_NAME_HAN                         ,       																					");
		sql.append("        A.SANG_NAME_SELF                        ,       																					");
		sql.append("        CASE A.START_DATE WHEN '0000-00-00 00:00:00' THEN null ELSE A.START_DATE END AS START_DATE                          ,         		");
		sql.append("        CASE A.END_DATE WHEN '0000-00-00 00:00:00' THEN null ELSE A.END_DATE END AS END_DATE                           ,          			");
		sql.append("        A.BULYONG_YN                            ,       																					");
		sql.append("        A.SUGA_SANG_CODE                        ,       																					");
		sql.append("        A.SANG_NAME               SUGA_SANG_NAME,       																					");
		sql.append("        A.JUNYEOM_BUNRYU                        ,       																					");
		sql.append("        A.JUNYEOM_KIND                                  																					");         
		sql.append("   FROM CHT0110 A                                       																					");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                   																					");
		sql.append("     AND A.SANG_NAME_INX LIKE :f_sang_inx               																					");
		sql.append(" ORDER BY A.SANG_CODE																														");
	//	sql.append(" LIMIT 200            																														");
		if(startNum != null && offset != null){
			sql.append(" limit :startNum, :offset 																		    									");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sang_inx", "%" + sangInx + "%");
		if(startNum != null && offset != null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<CHT0110U00grdCHT0110ItemInfo> getCHT0110U00grdCHT0110ItemInfo= new JpaResultMapper().list(query, CHT0110U00grdCHT0110ItemInfo.class);
		return getCHT0110U00grdCHT0110ItemInfo;
	}

	@Override
	@Cacheable(value="Cht0110Repository")
	public String getCHT0110U00TChk(String hospCode, String sangCode) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT 'Y' FROM CHT0110 WHERE HOSP_CODE = :f_hosp_code AND SANG_CODE = :f_sang_code LIMIT 1 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sang_code", sangCode);
		List<String> tChk= query.getResultList();
		if(!CollectionUtils.isEmpty(tChk)){
			return tChk.get(0);
		}
		return null;
	}
	
	@Override
	@Cacheable(value="Cht0110Repository")
	public List<ComboListItemInfo> getOcsoLoadCht0110(String sangCode, String gijunDate){
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.SANG_CODE, A.SANG_NAME                                                                              ");
		sql.append("     FROM CHT0110 A                                                                                           ");
		sql.append("    WHERE A.SANG_CODE = :f_sang_code                                                                          ");
		sql.append("      AND A.START_DATE <= STR_TO_DATE(:f_gijun_date, '%Y/%m/%d')                                              ");
		sql.append("      AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) >= STR_TO_DATE(:f_gijun_date, '%Y/%m/%d')     ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sang_code", sangCode);
		query.setParameter("f_gijun_date", gijunDate);
		
		List<ComboListItemInfo> list= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value="Cht0110Repository")
	public String getLoadColumnCodeNameSangCodeCase(String sangCode,
			String orderDate, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SANG_NAME 																						  ");								
		sql.append("	 FROM CHT0110 A                                                                                           ");
		sql.append("	WHERE A.SANG_CODE = :sangCode                                                                             ");
		sql.append("	  AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE, '%Y/%m/%d')), '%Y/%m/%d') ");
		sql.append("	  AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE, '%Y/%m/%d')), '%Y/%m/%d') ");
		sql.append("	  AND A.HOSP_CODE   = :hospCode                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sangCode", sangCode);
		query.setParameter("orderDate", orderDate);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<CHT0110Q01GrdCHT0110MListInfo> getCHT0110Q01GrdCHT0110MListInfo(String hospCode, String ioGubun, String userId, String sangInx,Date date) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_CODE                             ,                                                                                  ");
		sql.append("        A.SANG_NAME                             ,                                                                                  ");
		sql.append("        A.SANG_NAME_HAN                         ,                                                                                  ");
		sql.append("        A.SANG_NAME_SELF                        ,                                                                                  ");
		sql.append("        ' ' SANG_NAME_INX                       ,                                                                                  ");
		sql.append("        A.START_DATE                            ,                                                                                  ");
		sql.append("        A.BULYONG_YN                            ,                                                                                  ");
		sql.append("        A.SUGA_SANG_CODE                        ,                                                                                  ");
		sql.append("        F.SANG_NAME               SUGA_SANG_NAME,                                                                                  ");
		sql.append("        A.JUNYEOM_BUNRYU                        ,                                                                                  ");
		sql.append("        A.JUNYEOM_KIND                          ,                                                                                  ");
		sql.append("        A.SAMANG_SANG_GROUP                     ,                                                                                  ");
		sql.append("        G.CODE_NAME            SAMANG_GROUP_NAME,                                                                                  ");
		sql.append("        B.RANK_CNT                                                                                                                 ");
		sql.append("   FROM                                                                                                                            ");
		sql.append("        (( CHT0110  F RIGHT JOIN (   SELECT * from CHT0110 A where  A.HOSP_CODE =:f_hosp_code                                      ");
		sql.append("	and A.START_DATE = (SELECT MAX(B.START_DATE)    FROM CHT0110 B WHERE B.HOSP_CODE = :f_hosp_code AND A.SANG_CODE=B.SANG_CODE))  ");
		sql.append(" A ON F.SANG_CODE = A.SUGA_SANG_CODE AND F.HOSP_CODE = A.HOSP_CODE ) 															   ");
		sql.append("        LEFT JOIN CHT0102  G ON G.CODE  = A.SAMANG_SANG_GROUP AND G.CODE_TYPE = 'G03' AND G.HOSP_CODE = A.HOSP_CODE )              ");
		sql.append("        LEFT JOIN VW_OUTSANG_RANK B ON B.SANG_CODE = A.SANG_CODE AND B.IO_GUBUN  = :f_io_gubun  AND B.DOCTOR = :f_user_id          ");
		sql.append("        AND    B.HOSP_CODE = A.HOSP_CODE                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code AND A.SANG_NAME_INX LIKE :f_sang_inx                                                            ");
		sql.append("    AND IFNULL(:f_date, SYSDATE()) BETWEEN DATE_FORMAT(A.START_DATE,'%Y/%d/%m') AND A.END_DATE                                     ");
		sql.append(" ORDER BY case A.SANG_CODE when '0000999' then 0 else IFNULL(B.RANK_CNT, 0) end DESC,                                              ");
		sql.append(" LENGTH(A.SANG_NAME_HAN), INSTR(A.SANG_NAME, :f_sang_inx), SUBSTR(A.SANG_NAME, 1, 30), A.SANG_CODE								   ");
		if(StringUtils.isEmpty(sangInx)){
			sql.append(" limit 100								");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_sang_inx","%" + sangInx + "%");
		query.setParameter("f_date", date);
		List<CHT0110Q01GrdCHT0110MListInfo> list= new JpaResultMapper().list(query, CHT0110Q01GrdCHT0110MListInfo.class);
		return list;
	}

	@Override
	public String callPrAdmUpdateMasterSang(String hospCode, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_UPDATE_MASTER_SANGS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);

		String result = (String)query.getOutputParameterValue("IO_ERR_FLAG");
		return result;
	}

	@Override
	@CacheEvict(value = "Cht0110Repository", allEntries = true)
	public String callPrCht0110U00UpdateMasterData(String hospCode) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CHT0110U00_UPDATE_MASTER_DATA");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.execute();
		String result = (String)query.getOutputParameterValue("O_ERR");
		return result;
	}
	
}

