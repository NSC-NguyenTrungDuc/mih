package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0803;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0803Info;
import nta.med.data.model.ihis.nuri.NUR0812U00GrdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03LayNurPointsInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03SetFindWorkerInfo;

@Repository("nur0803Repository")
public class Nur0803RepositoryImpl extends SimpleJpaRepository<Nur0803, Long> implements Nur0803Repository {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Nur0803RepositoryImpl(EntityManager entityManager) {
		super(Nur0803.class, entityManager);
	}

	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Nur0803Repository", allEntries = true)
	public Nur0803 save(Nur0803 entity) {
		return super.save(entity);
	}

	@Override
	@CacheEvict(value = "Nur0803Repository", allEntries = true)
	public List<Nur0803> save(List<Nur0803> entities) {
		return super.save(entities);
	}

	@Override
	@CacheEvict(value = "Nur0803Repository", allEntries = true)
	public void delete(Nur0803 entity) {
		super.delete(entity);
	}
	
	@Override
	public List<NUR0812U00GrdDetailInfo> getNUR0812U00GrdDetailInfo(String hospCode, String language, String codeType,
			String needHType, Integer startNum, Integer offset) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_H_TYPE          AS NEED_H_TYPE             ");
		sql.append("	     , A.NEED_GUBUN           AS NEED_GUBUN              ");
		sql.append("	     , B.CODE_NAME            AS CODE_NAME               ");
		sql.append("	     , A.NEED_ASMT_CODE       AS NEED_ASMT_CODE          ");
		sql.append("	     , C.NEED_ASMT_NAME       AS NEED_ASMT_NAME          ");
		sql.append("	     , A.PAYLOAD_NO           AS PAYLOAD_NO              ");
		sql.append("	FROM NUR0812 A                                           ");
		sql.append("	JOIN NUR0102 B ON B.HOSP_CODE = A.HOSP_CODE              ");
		sql.append("	              AND B.CODE_TYPE = :f_code_type             ");
		sql.append("	              AND B.CODE      = A.NEED_GUBUN             ");
		sql.append("	              AND B.LANGUAGE  = :f_language              ");
		sql.append("	JOIN NUR0803 C ON C.HOSP_CODE       = A.HOSP_CODE        ");
		sql.append("	              AND C.NEED_GUBUN      = A.NEED_GUBUN       ");
		sql.append("	              AND C.NEED_ASMT_CODE  = A.NEED_ASMT_CODE   ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code                       ");
		sql.append("	  AND A.NEED_H_TYPE  = :f_need_h_type                    ");
		sql.append("	ORDER BY A.NEED_GUBUN, B.CODE_NAME, A.NEED_ASMT_CODE     ");

		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset								");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_h_type", needHType);

		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0812U00GrdDetailInfo> list = new JpaResultMapper().list(query, NUR0812U00GrdDetailInfo.class);
		return list;
	}

	@Override
	@CacheEvict(value = "Nur0803Repository", allEntries = true)
	public List<Nur0803> findByNeedGubun(String hospCode, String needGubun) {
		String sql = "SELECT T FROM Nur0803 T WHERE hospCode = :hospCode AND needGubun = :needGubun";
		
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("needGubun", needGubun);
		return query.getResultList();
	}

	@Override
	public List<NUR0803U01grdNUR0803Info> getNUR0803U01grdNUR0803Info(String hospCode, String needGubun, String hfile,
			String enable) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_GUBUN       AS    NEED_GUBUN                                                                                    ");
		sql.append("	     , A.NEED_ASMT_CODE   AS    NEED_ASMT_CODE                                                                                ");
		sql.append("	     , A.START_DATE       AS    START_DATE                                                                                    ");
		sql.append("	     , A.END_DATE         AS    END_DATE                                                                                      ");
		sql.append("	     , A.NEED_ASMT_NAME   AS    NEED_ASMT_NAME                                                                                ");
		sql.append("	     , A.SORT_KEY         AS    SORT_KEY                                                                                      ");
		sql.append("	     , A.GLOBAL_YN        AS    GLOBAL_YN                                                                                     ");
		sql.append("	  FROM NUR0803 A                                                                                                              ");
		sql.append("	 WHERE A.HOSP_CODE  =    :f_hosp_code                                                                                         ");
		sql.append("	   AND A.NEED_GUBUN LIKE :f_need_gubun                                                                                        ");
		sql.append("	   AND (   (:f_hfile = '%')                                                                                                   ");
		sql.append("	        OR (:f_hfile = 'Y' AND A.GLOBAL_YN = 'Y')                                                                             ");
		sql.append("	       )                                                                                                                      ");
		sql.append("	   AND (   (:f_enable = '%')                                                                                                  ");
		sql.append("	        OR (:f_enable = 'Y' AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))) ");
		sql.append("	       )                                                                                                                      ");
		sql.append("	 ORDER BY A.NEED_GUBUN                                                                                                        ");
		sql.append("	        , A.NEED_ASMT_CODE                                                                                                    ");
		sql.append("	        , A.SORT_KEY                                                                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_enable", enable);
		query.setParameter("f_hfile", hfile);
		
		List<NUR0803U01grdNUR0803Info> list = new JpaResultMapper().list(query, NUR0803U01grdNUR0803Info.class);
		return list;
	}

	@Override
	public List<Nur0803> findByHospCodeNeedGubunNeedAsmtCodeFDate(String hospCode, String needGubun, String asmtCode,
			Date fDate) {
		String sql = "SELECT T FROM Nur0803 T WHERE hospCode = :hospCode AND needGubun = :needGubun AND needAsmtCode = :needAsmtCode AND :f_date BETWEEN startDate AND IFNULL(endDate, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))";
		
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("needGubun", needGubun);
		query.setParameter("needAsmtCode", asmtCode);
		query.setParameter("f_date", fDate);
		
		return query.getResultList();
	}

	@Override
	public Integer updateByHospCodeNeedGubunNeedAsmtCodeStartDate(String userId, String needAsmtName, String globalYn,
			Date endDate, Double sortKey, String hospCode, String needGubun, String needAsmtCode, Date startDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE NUR0803 A                            ");
		sql.append("	  SET A.UPD_ID         = :f_user_id         ");
		sql.append("	   , A.UPD_DATE        = SYSDATE()          ");
		sql.append("	   , A.NEED_ASMT_NAME  = :f_need_asmt_name  ");
		sql.append("	   , A.GLOBAL_YN       = :f_global_yn       ");
		sql.append("	   , A.END_DATE        = :f_end_date        ");
		sql.append("	   , A.SORT_KEY        = :f_sort_key        ");
		sql.append("	  WHERE A.HOSP_CODE    = :f_hosp_code       ");
		sql.append("	  AND A.NEED_GUBUN     = :f_need_gubun      ");
		sql.append("	  AND A.NEED_ASMT_CODE = :f_need_asmt_code  ");
		sql.append("	  AND A.START_DATE     = :f_start_date      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_need_asmt_name", needAsmtName);
		query.setParameter("f_global_yn", globalYn);
		query.setParameter("f_end_date", endDate);
		query.setParameter("f_sort_key", sortKey);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		query.setParameter("f_start_date", startDate);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer deleteByHospCodeNeedGubunNeedAsmtCodeStartDate(String hospCode, String needGubun,
			String needAsmtCode, Date startDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE NUR0803	                          ");
		sql.append("	  WHERE HOSP_CODE    = :f_hosp_code       ");
		sql.append("	  AND NEED_GUBUN     = :f_need_gubun      ");
		sql.append("	  AND NEED_ASMT_CODE = :f_need_asmt_code  ");
		sql.append("	  AND START_DATE     = :f_start_date      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		query.setParameter("f_start_date", startDate);
		
		return query.executeUpdate();
	}

	@Override
	public List<NUR8003U03LayNurPointsInfo> getNUR8003U03LayNurPointsInfo(String hospCode, String bunho,
			String startDate, Date queryDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.DAYOFMON                                                                                           	AS WRITE_DATE                            ");
		sql.append("	     , CONCAT(A.A_POINT, '/', A.B_POINT, '/', A.C_POINT)                                                      	AS NEED_POINT                            ");
		sql.append("	     , FN_NUR_LOAD_NUR_NEED_COUNT(B.HOSP_CODE, A.A_POINT, A.B_POINT, A.C_POINT, A.DAYOFMON, B.WRITE_HODONG) 	AS NEED_YN                               ");
		sql.append("	     , IFNULL(CAST(B.WRITE_CNT AS CHAR), '')                                                                                                             ");
		sql.append("	     , IFNULL(B.WRITE_HODONG, '')                                                                                                                        ");
		sql.append("	  FROM ( SELECT DATE_ADD(STR_TO_DATE(:f_start_date, '%Y/%m/%d'), INTERVAL Y.CNT DAY)							AS DAYOFMON                              ");
		sql.append("	              , FN_NUR_LOAD_NUR_NEED_POINT(:f_hosp_code, :f_bunho, DATE_ADD(STR_TO_DATE(:f_start_date, '%Y/%m/%d'),INTERVAL Y.CNT DAY) ,'A') AS A_POINT  ");
		sql.append("	              , FN_NUR_LOAD_NUR_NEED_POINT(:f_hosp_code, :f_bunho, DATE_ADD(STR_TO_DATE(:f_start_date, '%Y/%m/%d'),INTERVAL Y.CNT DAY) ,'B') AS B_POINT  ");
		sql.append("	              , FN_NUR_LOAD_NUR_NEED_POINT(:f_hosp_code, :f_bunho, DATE_ADD(STR_TO_DATE(:f_start_date, '%Y/%m/%d'),INTERVAL Y.CNT DAY) ,'C') AS C_POINT  ");
		sql.append("	              , :f_bunho BUNHO                                                                                                                           ");
		sql.append("	           FROM ( select @rownum\\:=@rownum+1 CNT                                                                                                        ");
		sql.append("	                from (SELECT @rownum\\:=-1) r, INP1001                                                                                                   ");
		sql.append("	                limit 42) Y                                                                                                                              ");
		sql.append("			) A                                                                                                                                              ");
		sql.append("	  LEFT JOIN ( SELECT Z.HOSP_CODE                                                                                                                         ");
		sql.append("	              , Z.WRITE_DATE                                                                                                                             ");
		sql.append("	              , COUNT(*)        AS WRITE_CNT                                                                                                             ");
		sql.append("	              , Z.BUNHO                                                                                                                                  ");
		sql.append("	              , Z.WRITE_HODONG                                                                                                                           ");
		sql.append("	           FROM NUR8003 Z                                                                                                                                ");
		sql.append("	          WHERE Z.HOSP_CODE  = :f_hosp_code                                                                                                              ");
		sql.append("	            AND Z.WRITE_DATE BETWEEN :f_query_date AND LAST_DAY(:f_query_date)                                                                           ");
		sql.append("	          GROUP BY Z.HOSP_CODE                                                                                                                           ");
		sql.append("	                 , Z.WRITE_DATE                                                                                                                          ");
		sql.append("	                 , Z.BUNHO                                                                                                                               ");
		sql.append("	                 , Z.WRITE_HODONG                                                                                                                        ");
		sql.append("			) B ON  B.WRITE_DATE	= A.DAYOFMON                                                                                                             ");
		sql.append("			   AND B.BUNHO     		= A.BUNHO                                                                                                                ");
		sql.append("	 ORDER BY DAYOFMON                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_query_date", queryDate);
		query.setParameter("f_start_date", startDate);
		
		List<NUR8003U03LayNurPointsInfo> list = new JpaResultMapper().list(query, NUR8003U03LayNurPointsInfo.class);
		return list;
	}

	@Override
	public List<NUR8003U03SetFindWorkerInfo> getNUR8003U03SetFindWorkerInfo(String hospCode, String needGubun,
			String needAsmtCode, Date startDate, String needResultCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.NEED_SO_CODE  SM_CODE                                                                                 ");
		sql.append("	     , B.NEED_SO_NAME  SM_DETAIL                                                                               ");
		sql.append("	     , ifnull(cast(B.NEED_SO_POINT as char), '') SM_POINT                                                      ");
		sql.append("	  FROM NUR0803 C                                                                                               ");
		sql.append("	     , NUR0804 A                                                                                               ");
		sql.append("	     , NUR0805 B                                                                                               ");
		sql.append("	 WHERE C.HOSP_CODE          = :f_hosp_code                                                                     ");
		sql.append("	   AND C.NEED_GUBUN         = :f_need_gubun                                                                    ");
		sql.append("	   AND C.NEED_ASMT_CODE     = :f_need_asmt_code                                                                ");
		sql.append("	   AND :f_start_date        BETWEEN C.START_DATE AND IFNULL(C.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	   AND A.HOSP_CODE          = C.HOSP_CODE                                                                      ");
		sql.append("	   AND A.NEED_GUBUN         = C.NEED_GUBUN                                                                     ");
		sql.append("	   AND A.NEED_ASMT_CODE     = C.NEED_ASMT_CODE                                                                 ");
		sql.append("	   AND A.START_DATE         = C.START_DATE                                                                     ");
		sql.append("	   AND A.NEED_RESULT_CODE   = :f_need_result_code                                                              ");
		sql.append("	   AND B.HOSP_CODE          = A.HOSP_CODE                                                                      ");
		sql.append("	   AND B.NEED_GUBUN         = A.NEED_GUBUN                                                                     ");
		sql.append("	       AND B.NEED_ASMT_CODE     = A.NEED_ASMT_CODE                                                             ");
		sql.append("	       AND B.NEED_RESULT_CODE   = A.NEED_RESULT_CODE                                                           ");
		sql.append("	       AND B.START_DATE         = A.START_DATE                                                                 ");
		sql.append("	     ORDER BY B.SORT_KEY                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_need_result_code", needResultCode);
		
		List<NUR8003U03SetFindWorkerInfo> list = new JpaResultMapper().list(query, NUR8003U03SetFindWorkerInfo.class);
		return list;
	}
}
