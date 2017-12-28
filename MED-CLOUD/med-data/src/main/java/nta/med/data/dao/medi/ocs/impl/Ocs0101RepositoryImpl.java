package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.ocs.Ocs0101;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0101ListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U15LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17LayHangwiGubunInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00laySlipItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0113U00LaySlipListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0203U00LaySlipInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00layTabItemInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository
public class Ocs0101RepositoryImpl extends SimpleJpaRepository<Ocs0101, Long>  implements Ocs0101Repository {
	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Ocs0101RepositoryImpl(EntityManager entityManager) {
		super(Ocs0101.class, entityManager);

	}
	@Override
	public List<OCS0108U00laySlipItemInfo> getOCS0108U00laySlipItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SLIP_GUBUN, A.SLIP_GUBUN_NAME,                        ");
		sql.append("        B.SLIP_CODE , B.SLIP_NAME                               ");
		sql.append("   FROM OCS0101 A,                                              ");
		sql.append("        OCS0102 B                                               ");
		sql.append("  WHERE B.HOSP_CODE  = :f_hosp_code                             ");
		sql.append("    AND A.SLIP_GUBUN = B.SLIP_GUBUN                             ");
		sql.append("    AND A.LANGUAGE = B.LANGUAGE                             	");
		sql.append("    AND A.LANGUAGE = :f_language                             	");
		sql.append("    AND EXISTS ( SELECT 'X'                                     ");
		sql.append("                   FROM OCS0103 C                               ");
		sql.append("                  WHERE C.SLIP_CODE           = B.SLIP_CODE     ");
		sql.append("                    AND C.HOSP_CODE           = B.HOSP_CODE     ");
		sql.append("                    AND IFNULL(C.JAERYO_YN, 'N') = 'Y')         ");
		sql.append("  ORDER BY A.SLIP_GUBUN, B.SLIP_CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode); 
		query.setParameter("f_language", language); 
		List<OCS0108U00laySlipItemInfo> listLaySlip =new JpaResultMapper().list(query, OCS0108U00laySlipItemInfo.class);                        
		return listLaySlip;
	}


	@Override
	@Cacheable(value= "Ocs0101Repository")
	public List<OCS0101U00GrdOcs0101ListItemInfo> getOCS0101U00ListItem(String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULl(A.SLIP_GUBUN , ' ') SLIP_GUBUN,				");
		sql.append("	       IFNULl(A.SLIP_GUBUN_NAME, ' ') SLIP_GUBUN_NAME,      ");
		sql.append("	      ''									                ");
		sql.append("	FROM OCS0101 A                                              ");
		sql.append("  WHERE A.LANGUAGE  = :f_language                             	");
		sql.append("	 ORDER BY 1                                                 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<OCS0101U00GrdOcs0101ListItemInfo> list = new JpaResultMapper().list(query, OCS0101U00GrdOcs0101ListItemInfo.class);
		return list;
		
	}
	@Cacheable("Ocs0101Repository")
	@Override
	public String getOCS0101U00Grd0101CheckData(String value, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'              		");
		sql.append("	  FROM OCS0101                  ");
		sql.append("	 WHERE SLIP_GUBUN = :value      ");
		sql.append("    AND LANGUAGE = :f_language      ");
		sql.append("	   LIMIT 1                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("value", value);
		query.setParameter("f_language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0113U00LaySlipListItemInfo> getOCS0113U00LaySlipItem(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT A.SLIP_GUBUN, A.SLIP_GUBUN_NAME, B.SLIP_CODE , B.SLIP_NAME	");
		sql.append("	FROM OCS0101 A																");
		sql.append("	JOIN OCS0102 B ON A.SLIP_GUBUN = B.SLIP_GUBUN AND A.LANGUAGE = B.LANGUAGE	");
		sql.append("	JOIN OCS0103 C ON C.HOSP_CODE = B.HOSP_CODE									");
		sql.append("	              AND C.SLIP_CODE = B.SLIP_CODE									");
		sql.append("	              AND IFNULL(C.SPECIMEN_YN, 'N') = 'Y'							");
		sql.append("	WHERE B.HOSP_CODE  = :hospCode												");
		sql.append("    AND A.LANGUAGE = :f_language      											");
		sql.append("	ORDER BY A.SLIP_GUBUN, B.SLIP_CODE											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		
		List<OCS0113U00LaySlipListItemInfo> listResult = new JpaResultMapper().list(query, OCS0113U00LaySlipListItemInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U17LayHangwiGubunInfo> getOCS0103U17LayHangwiGubunListItem(
			String hospCode, String userId, String slip_gubun, String inputTab, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_GUBUN                  ,		");
		sql.append("	       A.SLIP_GUBUN_NAME             ,      ");
		sql.append("	       B.SLIP_CODE                   ,      ");
		sql.append("	       B.SLIP_NAME                   ,      ");
		sql.append("	       'Y'                CODE_YN    ,      ");
		sql.append("	       0                                    ");
		sql.append("	  FROM OCS0101 A,                           ");
		sql.append("	       OCS0102 B                            ");
		sql.append("	 WHERE A.SLIP_GUBUN = :slip_gubun 		    ");  // 'N'
		sql.append("	   AND B.HOSP_CODE  = :f_hosp_code          ");
		sql.append("	   AND B.SLIP_GUBUN = A.SLIP_GUBUN          ");
		sql.append("	   AND A.LANGUAGE  = B.LANGUAGE          	");
		sql.append("	   AND A.LANGUAGE  = :f_language          	");
		sql.append("	 UNION ALL                                  ");
		sql.append("	SELECT DISTINCT                             ");
		sql.append("	       D.SLIP_GUBUN                         ");
		sql.append("	     , D.SLIP_GUBUN_NAME                    ");
		sql.append("	     , C.SLIP_CODE                          ");
		sql.append("	     , C.SLIP_NAME                          ");
		sql.append("	     , 'Y' CODE_YN                          ");
		sql.append("	     , 0                                    ");
		sql.append("	  FROM OCS0142 A                            ");
		sql.append("	     , (SELECT DISTINCT HOSP_CODE, ORDER_GUBUN, SLIP_CODE FROM OCS0103 WHERE HOSP_CODE = :f_hosp_code) B                            ");
		sql.append("	     , OCS0102 C                            ");
		sql.append("	     , OCS0101 D                            ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code         ");
		sql.append("	   AND A.INPUT_TAB   = :inputTab            "); // '08'
		sql.append("	   AND A.MAIN_YN     = 'N'                  ");
//		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE          ");
		sql.append("	   AND B.ORDER_GUBUN = A.ORDER_GUBUN        ");
		sql.append("	   AND C.HOSP_CODE   = B.HOSP_CODE          ");
		sql.append("	   AND C.SLIP_CODE   = B.SLIP_CODE          ");
		sql.append("	   AND D.SLIP_GUBUN  = C.SLIP_GUBUN         ");
		sql.append("	   AND D.LANGUAGE  = C.LANGUAGE          	");
		sql.append("	   AND D.LANGUAGE  = :f_language          	");
		sql.append("	 UNION ALL                                  ");
		sql.append("	SELECT 'AAAA'                               ");
		sql.append("	      ,'セット処置'                           ");
		sql.append("	      ,B.YAKSOK_CODE                        ");
		sql.append("	      ,B.YAKSOK_NAME                        ");
		sql.append("	      ,'U'            CODE_YN               ");
		sql.append("	      ,A.SEQ                                ");
		sql.append("	  FROM OCS0300 A                            ");
		sql.append("	      ,OCS0301 B                            ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code       ");
		sql.append("	   AND A.MEMB          = 'ADMIN'            ");
		sql.append("	   AND A.INPUT_TAB     = :inputTab               ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE        ");
		sql.append("	   AND B.FKOCS0300_SEQ = A.PK_SEQ           ");
		sql.append("	   AND B.MEMB          = A.MEMB             ");
		sql.append("	 UNION ALL                                  ");
		sql.append("	SELECT 'AAAB'                               ");
		sql.append("	      ,'セット処置(個人)'                      ");
		sql.append("	      ,B.YAKSOK_CODE                        ");
		sql.append("	      ,B.YAKSOK_NAME                        ");
		sql.append("	      ,'K'            CODE_YN               ");
		sql.append("	      ,A.SEQ                                ");
		sql.append("	  FROM OCS0300 A                            ");
		sql.append("	      ,OCS0301 B                            ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code       ");
		sql.append("	   AND A.MEMB          = :f_user            ");
		sql.append("	   AND A.INPUT_TAB     = :inputTab               ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE        ");
		sql.append("	   AND B.FKOCS0300_SEQ = A.PK_SEQ           ");
		sql.append("	   AND B.MEMB          = A.MEMB             ");
		sql.append("	 UNION ALL                                  ");
		sql.append("	SELECT 'MTLA'                               ");
		sql.append("	      ,'セット材料'                           ");
		sql.append("	      ,B.YAKSOK_CODE                        ");
		sql.append("	      ,B.YAKSOK_NAME                        ");
		sql.append("	      ,'M'            CODE_YN               ");
		sql.append("	      ,A.SEQ                                ");
		sql.append("	  FROM OCS0300 A                            ");
		sql.append("	      ,OCS0301 B                            ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code       ");
		sql.append("	   AND A.MEMB          = 'ADMIN'            ");
		sql.append("	   AND A.INPUT_TAB     = '00'               ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE        ");
		sql.append("	   AND B.FKOCS0300_SEQ = A.PK_SEQ           ");
		sql.append("	   AND B.MEMB          = A.MEMB             ");
		sql.append("	 UNION ALL                                  ");
		sql.append("	SELECT 'MTLB'                               ");
		sql.append("	      ,'セット材料(個人)'                      ");
		sql.append("	      ,B.YAKSOK_CODE                        ");
		sql.append("	      ,B.YAKSOK_NAME                        ");
		sql.append("	      ,'N'            CODE_YN               ");
		sql.append("	      ,A.SEQ                                ");
		sql.append("	  FROM OCS0300 A                            ");
		sql.append("	      ,OCS0301 B                            ");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code       ");
		sql.append("	   AND A.MEMB          = :f_user            ");
		sql.append("	   AND A.INPUT_TAB     = '00'               ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE        ");
		sql.append("	   AND B.FKOCS0300_SEQ = A.PK_SEQ           ");
		sql.append("	   AND B.MEMB          = A.MEMB             ");
		sql.append("	ORDER BY 1, 2, 6, 3                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user", userId);
		query.setParameter("slip_gubun", slip_gubun);
		query.setParameter("inputTab", inputTab);
		query.setParameter("f_language", language);
		
		List<OCS0103U17LayHangwiGubunInfo> list = new JpaResultMapper().list(query, OCS0103U17LayHangwiGubunInfo.class);
		return list;
	}
	@Cacheable("Ocs0101Repository")
	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfoOCS0101(String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%', CONCAT('%: ',FN_ADM_MSG('221',:f_language))                ");
		sql.append(" UNION ALL                                                              ");
		sql.append(" SELECT A.SLIP_GUBUN, CONCAT(A.SLIP_GUBUN,': ',A.SLIP_GUBUN_NAME)       ");
		sql.append("   FROM OCS0101 A                                                       ");
		sql.append("	   WHERE A.LANGUAGE  = :f_language          						");
		sql.append("   ORDER BY 1															");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<OCS0103U15LaySlipCodeTreeInfo> getOCS0103U15LaySlipCodeTreeInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SLIP_GUBUN     ,                                         ");
		sql.append("       A.SLIP_GUBUN_NAME,                                         ");
		sql.append("       B.SLIP_CODE      ,                                         ");
		sql.append("       B.SLIP_NAME                                                ");
		sql.append("  FROM OCS0101 A JOIN OCS0102 B ON  B.SLIP_GUBUN = A.SLIP_GUBUN   ");
		sql.append("   AND B.LANGUAGE  = A.LANGUAGE                               	  ");
		sql.append(" WHERE A.SLIP_GUBUN = 'C'                                         ");
		sql.append("   AND B.HOSP_CODE  = :f_hosp_code                                ");
		sql.append("	   AND A.LANGUAGE  = :f_language          					  ");
		sql.append(" ORDER BY A.SLIP_GUBUN, B.SLIP_CODE                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<OCS0103U15LaySlipCodeTreeInfo> list = new JpaResultMapper().list(query, OCS0103U15LaySlipCodeTreeInfo.class);
		return list;
	}
	
	@Override
	public List<OCS0203U00LaySlipInfo> getOCS0203U00LaySlipInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.SLIP_GUBUN                            ");
		sql.append("      ,B.SLIP_GUBUN_NAME                       ");
		sql.append("      ,D.SLIP_CODE                             ");
		sql.append("      ,D.SLIP_NAME                             ");
		sql.append("  FROM OCS0101 B,                              ");
		sql.append("       OCS0102 D                               ");
		sql.append(" WHERE D.HOSP_CODE           = :f_hosp_code    ");
		sql.append("   AND B.SLIP_GUBUN          = D.SLIP_GUBUN    ");
		sql.append("	   AND B.LANGUAGE  = D.LANGUAGE            ");
		sql.append("	   AND B.LANGUAGE  = :f_language           ");
		sql.append(" ORDER BY B.SLIP_GUBUN                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<OCS0203U00LaySlipInfo> list = new JpaResultMapper().list(query, OCS0203U00LaySlipInfo.class);
		return list;
	}

	@Override
	@CacheEvict(value = "Ocs0101Repository", allEntries = true)
	public Integer updateOcs0101U00Ocs0101Modified(String updId, String slipGubunName, String slipGubun, String language) {
		StringBuilder sql = new StringBuilder();
        sql.append(" UPDATE OCS0101						");
        sql.append(" SET UPD_ID = :updId,				");
        sql.append(" UPD_DATE = SYSDATE()			   ,");
        sql.append(" SLIP_GUBUN_NAME = :slipGubunName	");
        sql.append(" WHERE SLIP_GUBUN = :slipGubun		");
        sql.append("   AND LANGUAGE = :language  		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("updId", updId);
		query.setParameter("slipGubunName", slipGubunName);
		query.setParameter("slipGubun", slipGubun);
		query.setParameter("language", language);

		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Ocs0101Repository", allEntries = true)
	public Integer deleteOcs0101U00Ocs0101Deleted(String slipGubun, String language) {
		StringBuilder sql = new StringBuilder();

        sql.append(" DELETE FROM OCS0101            	");
        sql.append(" WHERE SLIP_GUBUN = :slipGubun		");
        sql.append("   AND LANGUAGE = :language  		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("slipGubun", slipGubun);
		query.setParameter("language", language);

		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Ocs0101Repository", allEntries = true)
	public Ocs0101 save(Ocs0101 ocs0101) {
		return super.save(ocs0101);
	}

	@Override
	@CacheEvict(value = "Ocs0101Repository", allEntries = true)
	public void delete(Ocs0101 baseEntity) {
		 super.delete(baseEntity);
	}
	@Override
	@CacheEvict(value = "Ocs0101Repository", allEntries = true)
	public List<Ocs0101> save(List<Ocs0101> entities) {
		return super.save(entities);
	}
	@Override
	public String getOCS2003U99GetSyokudomeCnt(String hospCode, String fkinp1001,
			String kijunDate) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																						");
		sql.append("		CAST(FN_OCSI_GET_SYOKUDOME_CNT(:f_hosp_code, :f_fkinp1001, :f_kijun_date) AS CHAR)		");
		sql.append("	FROM																						");
		sql.append("		DUAL																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_kijun_date", kijunDate);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	@Override
	public List<OCS2004U00layTabItemInfo> getOCS2004U00layTabItem() {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT				");
		sql.append("		'D4',           ");
		sql.append("		'臨時薬',       ");
		sql.append("		'0'               ");
		sql.append("	FROM                ");
		sql.append("		DUAL            ");
		sql.append("		UNION           ");
		sql.append("	SELECT              ");
		sql.append("		'DN',           ");
		sql.append("		'緊急時処置',    ");
		sql.append("		1               ");
		sql.append("	FROM                ");
		sql.append("		DUAL            ");
		sql.append("	ORDER BY            ");
		sql.append("		3               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<OCS2004U00layTabItemInfo> listInfo = new JpaResultMapper().list(query, OCS2004U00layTabItemInfo.class);
		return listInfo;
	}
}


