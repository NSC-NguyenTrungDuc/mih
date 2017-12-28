package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.bas.Bas0110;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.data.model.ihis.bass.BAS0110BAS0110Q00GrdInfo;
import nta.med.data.model.ihis.bass.BAS0110U00GrdJohapListItemInfo;
import nta.med.data.model.ihis.bass.BAS0111U00GrdMasterItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetJohapInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */

@Repository("bas0110Repository")
public class Bas0110RepositoryImpl extends SimpleJpaRepository<Bas0110, Long> implements Bas0110Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0110RepositoryImpl(EntityManager entityManager) {
		super(Bas0110.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0110Repository", allEntries = true)
	public Bas0110 save(Bas0110 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Bas0110Repository", allEntries = true)
	public List<Bas0110> save(List<Bas0110> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0110Repository", allEntries = true)
	@Override
	public void delete(Bas0110 entity) {
		super.delete(entity);
	}
	
	@CacheEvict(value="Bas0110Repository", allEntries = true)
	public Integer updateBas0110U00TransactionModified(
			String updId,
			String johapName,
			String zipCode1,
			String zipCode2,
			String address,
			String tel,
			String giho,
			String remark,
			String checkDigitYn,
			String johap,
			Date startDate,
			String johapGubun,
			String language){
		String sqlQuery = "UPDATE Bas0110 	   						   "
			             +"	  SET updDate           = SYSDATE()        "   
			             +"	    , updId             = :updId           " 
			             +"	    , johapName         = :johapName       " 
			             +"	    , zipCode1          = :zipCode1        " 
			             +"	    , zipCode2          = :zipCode2        " 
			             +"	    , address           = :address         " 
			             +"	    , tel               = :tel             " 
			             +"	    , giho              = :giho            " 
			             +"	    , remark            = :remark          " 
			             +"	    , checkDigitYn      = :checkDigitYn    " 
			             +"	WHERE johap             = :johap           " 
			             +"	  AND startDate         = :startDate       " 
			             +"	  AND johapGubun        = :johapGubun  AND language = :language    ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("updId", updId);
		query.setParameter("johapName", johapName);
		query.setParameter("zipCode1", zipCode1);
		query.setParameter("zipCode2", zipCode2);
		query.setParameter("address", address);
		query.setParameter("tel", tel);
		query.setParameter("giho", giho);
		query.setParameter("remark", remark);
		query.setParameter("checkDigitYn", checkDigitYn);
		query.setParameter("johap", johap);
		query.setParameter("startDate", startDate);
		query.setParameter("johapGubun", johapGubun);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value="Bas0110Repository", allEntries = true)
	public Integer deleteBas0110U00TransactionDeleted(
			String johap,
			Date startDate,
			String johapGubun,
			String language){
		String sqlQuery = "	DELETE FROM Bas0110			   "
				+"	WHERE johap       = :johap     " 
				+"	  AND startDate  = :startDate  " 
				+"	  AND johapGubun = :johapGubun AND language = :language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("johap", johap);
		query.setParameter("startDate", startDate);
		query.setParameter("johapGubun", johapGubun);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	public List<BAS0110U00GrdJohapListItemInfo> getBAS0110U00GrdJohapListItem(
			 String johapGubun, String johap, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JOHAP       ,																																");
		sql.append("	      A.START_DATE   ,                                                                                                                              ");
		sql.append("	      A.JOHAP_NAME  ,                                                                                                                               ");
		sql.append("	      A.JOHAP_GUBUN ,                                                                                                                               ");
		sql.append("	      A.ZIP_CODE1   ,                                                                                                                               ");
		sql.append("	      A.ZIP_CODE2   ,                                                                                                                               ");
		sql.append("	      A.ADDRESS     ,                                                                                                                               ");
		sql.append("	      A.CD          ,                                                                                                                               ");
		sql.append("	      A.BOHEOMJA_NO ,                                                                                                                               ");
		sql.append("	      A.DODOBUHYEUN_NO ,                                                                                                                            ");
		sql.append("	      A.LAW_NO,                                                                                                                                     ");
		sql.append("	     CONCAT(B.ZIP_NAME1,'  ',B.ZIP_NAME2) ADDRESS1 ,                                                                                                ");
		sql.append("	      A.TEL         ,                                                                                                                               ");
		sql.append("	      A.GIHO        ,                                                                                                                               ");
		sql.append("	      A.REMARK,                                                                                                                                     ");
		sql.append("	      A.CHECK_DIGIT_YN,                                                                                                                             ");
		sql.append("		  ''																																			");	
		sql.append("	 FROM BAS0123 B RIGHT JOIN BAS0110 A ON A.ZIP_CODE1 = B.ZIP_CODE1  AND A.ZIP_CODE2 = B.ZIP_CODE2 AND A.LANGUAGE = :language                         ");
		sql.append("	WHERE A.JOHAP_GUBUN LIKE :johapGubun                                                                                                                ");
		sql.append("	  AND A.JOHAP LIKE :johap                                                                                                                           ");
		sql.append("	  AND IFNULL(STR_TO_DATE(:startDate, '%Y/%m/%d'),SYSDATE()) BETWEEN A.START_DATE                                                                    ");
		sql.append("	                             AND IFNULL(A.END_DATE,STR_TO_DATE( '9998/12/31', '%Y/%m/%d'))                                                          ");
		sql.append("	ORDER BY A.JOHAP,  A.START_DATE DESC                                                                                                                ");
		if(StringUtils.isEmpty(johap)&&StringUtils.isEmpty(johapGubun)){
			sql.append("	LIMIT 100                                                                                                                                           ");
		}
		 Query query= entityManager.createNativeQuery(sql.toString());
	     query.setParameter("johapGubun", "%" + johapGubun + "%");
	     query.setParameter("johap", johap + "%");
	     query.setParameter("startDate", startDate);
	     query.setParameter("language", language);
	     
	     List<BAS0110U00GrdJohapListItemInfo> listResult = new JpaResultMapper().list(query, BAS0110U00GrdJohapListItemInfo.class);
	     return listResult;
	}

	@Override
	@Cacheable(value="Bas0110Repository")
	public String getBas0110U00LayDupChk( String gubun, Date startDate, String johap, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'								                        ");
		sql.append("	 FROM BAS0110                                                   ");
		sql.append("	WHERE JOHAP_GUBUN = :gubun                                      ");
		sql.append("	  AND START_DATE  = :f_start_date                               ");
		sql.append("	  AND JOHAP       = :f_johap AND LANGUAGE = :language           ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("gubun", gubun);
	    query.setParameter("f_start_date", startDate);
	    query.setParameter("f_johap", johap);
	    query.setParameter("language", language);
	     
	     List<Object> list = query.getResultList();
	     if(!CollectionUtils.isEmpty(list) && list.get(0) != null){
	    	 return list.get(0).toString();
	     }
	     return null;
	}

	@Override
	@Cacheable(value="Bas0110Repository")
	public List<BAS0110BAS0110Q00GrdInfo> getBAS0110BAS0110Q00GrdInfo(String hospCode, String language, String johapGubun,
			String searchGubun, String searchWord) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP                                                                                                                   ");
		sql.append("      , A.START_DATE                                                                                                              ");
		sql.append("      , A.JOHAP_NAME                                                                                                              ");
		sql.append("      , A.JOHAP_GUBUN                                                                                                             ");
		sql.append("      , A.ZIP_CODE1                                                                                                               ");
		sql.append("      , A.ZIP_CODE2                                                                                                               ");
		sql.append("      , A.ADDRESS                                                                                                                 ");
		sql.append("      , A.TEL                                                                                                                     ");
		sql.append("      , A.LAW_NO                                                                                                                  ");
		sql.append("      , A.DODOBUHYEUN_NO                                                                                                          ");
		sql.append("      , A.BOHEOMJA_NO                                                                                                             ");
		sql.append("      , A.CD                                                                                                                      ");
		sql.append("      , A.GIHO                                                                                                                    ");
		sql.append("      , A.REMARK                                                                                                                  ");
		sql.append("      , A.CHECK_DIGIT_YN                                                                                                          ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME('JOHAP_GUBUN', A.JOHAP_GUBUN,:f_hosp_code,:f_language)                                              ");
		sql.append("   FROM BAS0110 A                                                                                                                 ");
		sql.append("  WHERE (:f_johap_gubun = '%'                                                                                                     ");
		sql.append("    AND ( (:f_search_gubun = '1'                                                                                                  ");
		sql.append("    AND    A.JOHAP LIKE :f_search_word                                                                                            ");
		sql.append("          )                                                                                                                       ");
		sql.append("     OR   (:f_search_gubun = '2'                                                                                                  ");
		sql.append("    AND    A.JOHAP_NAME LIKE :f_search_word                                                                                       ");
		sql.append("          )                                                                                                                       ");
		sql.append("        )                                                                                                                         ");
		sql.append("       )                                                                                                                          ");
		sql.append("     OR(:f_johap_gubun <> '%'                                                                                                     ");
		sql.append("    AND :f_johap_gubun  = A.JOHAP_GUBUN                                                                                           ");
		sql.append("    AND ( (:f_search_gubun = '1'                                                                                                  ");
		sql.append("    AND    A.JOHAP LIKE  :f_search_word                                                                                           ");
		sql.append("          )                                                                                                                       ");
		sql.append("     OR   (:f_search_gubun = '2'                                                                                                  ");
		sql.append("    AND    A.JOHAP_NAME LIKE  :f_search_word                                                                                      ");
		sql.append("          )                                                                                                                       ");
		sql.append("        )                                                                                                                         ");
		sql.append("       )                                                                                                                          ");
		sql.append("    AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE   AND A.LANGUAGE = :f_language                                              ");
		sql.append("  ORDER BY CONCAT(IFNULL(A.JOHAP_GUBUN,''), IFNULL(LPAD(A.JOHAP, '8', '0'),''),IFNULL(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'),''))  limit 200 ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
	    query.setParameter("f_johap_gubun", johapGubun);
	    query.setParameter("f_search_gubun", searchGubun);
	    query.setParameter("f_search_word", "%" + searchWord + "%");
	    List<BAS0110BAS0110Q00GrdInfo> listResult = new JpaResultMapper().list(query, BAS0110BAS0110Q00GrdInfo.class);
	    return listResult;
	}

	@Override
	@Cacheable(value="Bas0110Repository")
	public List<BAS0111U00GrdMasterItemInfo> getBAS0111U00GrdMasterItemInfo(String johapGubun, String johap, String naewonDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP_GUBUN                                                                   ");
		sql.append("      , A.JOHAP                                                                         ");
		sql.append("      , A.JOHAP_NAME                                                                    ");
		sql.append("   FROM BAS0110 A                                                                       ");
		sql.append("  WHERE  A.JOHAP_GUBUN = :f_johap_gubun AND A.LANGUAGE = :language                      ");
		sql.append("    AND A.JOHAP       = :f_johap                                                        ");
		sql.append("    AND STR_TO_DATE(:f_naewon_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE     ");
		sql.append("  ORDER BY CONCAT(A.JOHAP, DATE_FORMAT(A.START_DATE, '%Y%m%d'), A.JOHAP_GUBUN)			");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_johap_gubun", johapGubun);
		query.setParameter("f_johap", johap);
	    query.setParameter("f_naewon_date", naewonDate);
	    query.setParameter("language", language);
	    List<BAS0111U00GrdMasterItemInfo> listResult = new JpaResultMapper().list(query, BAS0111U00GrdMasterItemInfo.class);
	    return listResult;
	}
	
	@Override
	@Cacheable(value="Bas0110Repository")
	public List<String> getJohapNameByJohapAndStartDate(String johap, String startDate, String language)
	{
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JOHAP_NAME                                                             ");
		sql.append(" FROM BAS0110 A                                                                 ");
		sql.append(" WHERE  A.JOHAP = :f_johap AND A.LANGUAGE = :language                           ");
		sql.append(" AND STR_TO_DATE(:f_start_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_johap", johap );
		query.setParameter("f_start_date",  startDate);
		query.setParameter("language",  language);

		return query.getResultList();
	}
	
	@Override
	@Cacheable(value="Bas0110Repository")
	public List<NuroOUT0101U02GetJohapInfo> getNuroOUT0101U02GetJohapInfo(String johap, Date date, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP_NAME         JOHAP_NAME												");
		sql.append("     , A.JOHAP_GUBUN        JOHAP_GUBUN                                             ");
		sql.append("  FROM BAS0110 A                                                                    ");
		sql.append(" WHERE A.JOHAP     = :johap  AND A.LANGUAGE = :language                             ");
		sql.append("   AND :date BETWEEN A.START_DATE AND A.END_DATE         							");
		sql.append("   AND A.JOHAP_GUBUN <> 'XX'                                                        ");
		sql.append("   AND A.START_DATE = (SELECT MAX(Z.START_DATE)                                     ");
		sql.append("                         FROM BAS0110 Z                                             ");
		sql.append("                        WHERE Z.JOHAP     = A.JOHAP                                 ");
		sql.append("                          AND Z.JOHAP_GUBUN <> 'XX'                                 ");
		sql.append("                            )                                                       ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("johap", johap);
		query.setParameter("date", date);
		query.setParameter("language", language);	
		List<NuroOUT0101U02GetJohapInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02GetJohapInfo.class);
		return list;
	}
}

