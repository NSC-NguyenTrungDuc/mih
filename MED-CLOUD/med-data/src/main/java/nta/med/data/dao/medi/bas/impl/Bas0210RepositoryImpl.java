package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.bas.Bas0210;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.model.ihis.bass.BAS0210U00grdBAS0210ItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetType;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayCommonInfo;

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
@Repository("bas0210Repository")
public class Bas0210RepositoryImpl extends SimpleJpaRepository<Bas0210, Long> implements Bas0210Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0210RepositoryImpl(EntityManager entityManager) {
		super(Bas0210.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	public Bas0210 save(Bas0210 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	public List<Bas0210> save(List<Bas0210> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	@Override
	public void delete(Bas0210 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value="Bas0210Repository")
	public String getBAS0210U00DupCheck(String gubun, Date startDate, String language){
		String sqlQuery = "SELECT 'Y' FROM Bas0210 WHERE gubun  = :f_gubun AND startDate  = :f_start_date AND language = :language";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_gubun", gubun);
		query.setParameter("language", language);
		query.setParameter("f_start_date", startDate);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	public Integer deleteBAS0210U00Execute(String gubun, Date startDate, String language){
		String sqlQuery = "DELETE FROM Bas0210 WHERE gubun  = :f_gubun  AND startDate = :f_start_date AND language = :language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	public Integer updateBAS0210U00ExecuteCaseInsert(String userId, Date startDate, String gubun, String language){
		String sqlQuery = " UPDATE Bas0210 SET updDate  = SYSDATE(), updId = :f_user_id, endDate = STR_TO_DATE(:f_start_date,'%c/%d/%Y') - 1 "
			+ "WHERE gubun  = :f_gubun AND startDate  <= :f_start_date and language = :language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_gubun", gubun);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0210Repository", allEntries = true)
	public Integer updateBAS0210Execute(String userId,
			 Date endDate, String gubunName, String johapGubun,
			 String gongbiYn, String gubun, Date startDate, String language){
		String sqlQuery = "UPDATE Bas0210 SET updId  = :f_user_id, updDate  = SYSDATE(), endDate = :f_end_date, "
			            + "gubunName = :f_gubun_name, johapGubun = :f_johap_gubun, gongbiYn = :f_gongbi_yn "
		            	+ "WHERE gubun = :f_gubun AND startDate = :f_start_date and language = :language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_end_date", endDate);
		query.setParameter("f_gubun_name", gubunName);
		query.setParameter("f_johap_gubun", johapGubun);
		query.setParameter("f_gongbi_yn", gongbiYn);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value="Bas0210Repository")
	public String getNuroChkGetGongbiYN(String gubun, String date, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(B.GONGBI_YN, 'Y') GONGBI_YN                        ");
		sql.append("   FROM BAS0210 B                                                 ");
		sql.append("  WHERE B.GUBUN = :f_gubun                     			           ");
		sql.append("    AND IFNULL(DATE_FORMAT(:f_naewon_date,'%Y/%m/%d'), SYSDATE()) ");
		sql.append("BETWEEN B.START_DATE AND B.END_DATE AND LANGUAGE = :language      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_gubun", gubun);
	    query.setParameter("f_naewon_date", date);
	    query.setParameter("language", language);
	    List<String> result = query.getResultList();
	 	if(!result.isEmpty()){
	 		return result.get(0);
	    }
		return null; 
	}

	@Override
	@Cacheable(value="Bas0210Repository")
	public List<BAS0210U00grdBAS0210ItemInfo> getBAS0210U00grdBAS0210ItemInfo(String hospCode, String language, Date startDate, String gubunCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GUBUN, A.GUBUN_NAME, 'Y'  RETRIEVE_YN, A.START_DATE, A.END_DATE, A.JOHAP_GUBUN,                                               ");
		sql.append(" FN_BAS_LOAD_CODE_NAME('JOHAP_GUBUN',  A.JOHAP_GUBUN,:f_hosp_code,:f_language)    JOHAP_NAME,GONGBI_YN                                  ");
		sql.append(" FROM BAS0210 A                                                                                                                         ");
		sql.append(" WHERE IFNULL(STR_TO_DATE(:f_start_date, '%Y/%m/%d'), DATE_FORMAT(SYSDATE() ,'%Y/%m/%d')) BETWEEN A.START_DATE AND   A.END_DATE           ");
		sql.append(" AND IFNULL(A.JOHAP_GUBUN,'%') LIKE :f_gubun_code AND A.LANGUAGE = :f_language                                                          ");
		sql.append(" ORDER BY A.GUBUN																														");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_language", language);
	    query.setParameter("f_start_date", startDate);
	    query.setParameter("f_gubun_code", gubunCode + "%");
	    List<BAS0210U00grdBAS0210ItemInfo> listGrdBas0210 = new JpaResultMapper().list(query, BAS0210U00grdBAS0210ItemInfo.class );
		return listGrdBas0210;
	}

	@Override
	public List<ORDERTRANSLayCommonInfo> getORDERTRANSLayCommonInfo(
			String hospCode, String gubun, String actingDate, String bunho, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GUBUN_NAME, IFNULL(B.IF_VALID_YN,'Y'), IFNULL(A.GONGBI_YN,'Y')                                                            ");
		sql.append("  FROM BAS0210 A, OUT0102 B                                                                                                         ");
		sql.append(" WHERE B.HOSP_CODE   = :f_hosp_code                                                                                                 ");
		sql.append("   AND A.GUBUN       = :f_gubun   AND A.LANGUAGE = :language                                                                        ");
		sql.append("   AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') BETWEEN A.START_DATE                                                                 ");
		sql.append("           AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                ");
		sql.append("   AND B.BUNHO       = :f_bunho                                                                                                     ");
		sql.append("   AND B.GUBUN       = A.GUBUN                                                                                                      ");
		sql.append("   AND B.START_DATE  = (SELECT MAX(Z.START_DATE)                                                                                    ");
		sql.append(" 			FROM OUT0102 Z                                                                                                          ");
		sql.append(" 		WHERE Z.HOSP_CODE   = B.HOSP_CODE                                                                                           ");
		sql.append(" 		AND Z.BUNHO = B.BUNHO                                                                                                       ");
		sql.append(" 			AND Z.GUBUN = B.GUBUN                                                                                                   ");
		sql.append(" 		AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') BETWEEN Z.START_DATE AND IFNULL(Z.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))) ");
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_gubun", gubun);
	    query.setParameter("f_acting_date", actingDate);
	    query.setParameter("f_bunho", bunho);
	    query.setParameter("language", language);
	    List<ORDERTRANSLayCommonInfo> listGrdBas0210 = new JpaResultMapper().list(query, ORDERTRANSLayCommonInfo.class );
		return listGrdBas0210;
	}

	@Override
	@Cacheable(value="Bas0210Repository")
	public List<String> getBAS0111U00LayGetJohap(String gubun, String naewonDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP_GUBUN                                                             ");
		sql.append(" FROM BAS0210 A                                                                   ");
		sql.append(" WHERE A.GUBUN     = :f_gubun AND A.LANGUAGE = :language                          ");
		sql.append(" AND STR_TO_DATE(:f_naewon_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_gubun", gubun);
	    query.setParameter("f_naewon_date", naewonDate);
	    query.setParameter("language", language);
	    List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	@Cacheable(value="Bas0210Repository")
	public String getNuroOUT0101U02GetTypeName(String gubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.GUBUN_NAME																	");
		sql.append("  FROM BAS0210 A                                                                    ");
		sql.append(" WHERE A.GUBUN       = :gubun AND A.LANGUAGE = :language                            ");
		sql.append("   AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN A.START_DATE AND END_DATE         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gubun", gubun);
		query.setParameter("language", language);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	

	@Override
	@Cacheable(value="Bas0210Repository")
	public List<NuroOUT0101U02GetType> getNuroOUT0101U02GetType(String johapGubun, String find1, String language) {
		StringBuilder sql = new StringBuilder();
		
		 sql.append("SELECT A.GUBUN																	");
		 sql.append("   , A.GUBUN_NAME                                                              ");
		 sql.append("FROM BAS0210 A                                                                 ");
		 sql.append("WHERE A.JOHAP_GUBUN LIKE CONCAT( :johapGubun, '%')                             ");
		 sql.append(" AND A.GUBUN       LIKE CONCAT(:find1, '%') AND A.LANGUAGE = :language         ");
		 sql.append(" AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN A.START_DATE AND END_DATE      ");
		 sql.append("ORDER BY A.GUBUN                                                               ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("johapGubun", johapGubun);
		query.setParameter("find1", find1);
		query.setParameter("language", language);
			
		List<NuroOUT0101U02GetType> list = new JpaResultMapper().list(query,NuroOUT0101U02GetType.class);
		return list;

	}
	
	@Override
	public String getOcs2015U00InsuranceInfo(String hospCode,String patientCode, String language) {
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT B.GUBUN_NAME															");
		 sql.append("FROM OUT0102 A , BAS0210 B                                                     ");
		 sql.append("WHERE A.HOSP_CODE = :f_hosp_code                            		            ");
		 sql.append(" AND A.BUNHO = :f_patient_code                                                 ");
		 sql.append(" AND A.GUBUN = B.GUBUN                                                         ");
		 sql.append(" AND B.LANGUAGE = :f_language                                                  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		query.setParameter("f_language", language);
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String getBAS0210U00DupCheckext(String language, String gubun, Date ipwonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y' 																			");
		sql.append("	FROM DUAL 																		");
		sql.append("	WHERE EXISTS ( SELECT 'X' 														");
		sql.append("					FROM BAS0210 A 													");
		sql.append("					WHERE A.LANGUAGE = :f_language									");
		sql.append("					  AND A.GUBUN     = :f_gubun 									");
		sql.append("					  AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE ) ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_language", language);
	    query.setParameter("f_gubun", gubun);
	    query.setParameter("f_gubun_ipwon_date", ipwonDate);
	    List<String> result = query.getResultList();
	 	if(!result.isEmpty()){
	 		return result.get(0);
	    }
		return null; 
	}

}

