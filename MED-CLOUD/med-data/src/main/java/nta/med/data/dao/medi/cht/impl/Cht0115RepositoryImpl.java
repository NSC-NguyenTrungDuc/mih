package nta.med.data.dao.medi.cht.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.domain.cht.Cht0115;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.model.ihis.chts.CHT0115Q00GrdScInfo;
import nta.med.data.model.ihis.chts.CHT0115Q00SusikCodeInfo;
import nta.med.data.model.ihis.chts.CHT0115Q01grdCHT0115Info;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
@Repository("cht0115Repository")
public class Cht0115RepositoryImpl extends SimpleJpaRepository<Cht0115, Long> implements Cht0115Repository {
	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Cht0115RepositoryImpl(EntityManager entityManager) {
		super(Cht0115.class, entityManager);
	}

	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Cht0115Repository", allEntries = true)
	public Cht0115 save(Cht0115 entity) {
		return super.save(entity);
	}

	@CacheEvict(value = "Cht0115Repository", allEntries = true)
	public List<Cht0115> save(List<Cht0115> entity) {
		return super.save(entity);
	}

	@CacheEvict(value = "Cht0115Repository", allEntries = true)
	@Override
	public void delete(Cht0115 entity) {
		super.delete(entity);
	}

	@CacheEvict(value = "Cht0115Repository", allEntries = true)
	public Integer updateCht0115Q01TransactionModified(
			String updId,
			String susikName,
			String susikNameGana,
			Date susikCrDate,
			Date susikUpdDate,
			Date susikDisableDate,
			String susikGwanriNo,
			String susikGubun,
			String susikChangeCode,
			String susikDetailGubun,
			Date endDate,
			Double sort,
			String hospCode,
			String susikCode,
			Date startDate){
		String sql = "		UPDATE Cht0115										"
				+"		SET updId              = :updId           ,	"
				+"		    sysDate            = SYSDATE()              ,	"
				+"		    susikName          = :susikName        ,	"
				+"		    susikNameGana     = :susikNameGana    ,	"
				+"		    susikCrDate       = :susikCrDate      ,	"
				+"		    susikUpdDate      = :susikUpdDate     ,	"
				+"		    susikDisableDate  = :susikDisableDate ,	"
				+"		    susikGwanriNo     = :susikGwanriNo    ,	"
				+"		    susikGubun         = :susikGubun       ,	"
				+"		    susikChangeCode   = :susikChangeCode  ,	"
				+"		    susikDetailGubun  = :susikDetailGubun ,	"
				+"		    endDate            = :endDate          ,	"
				+"		    sort                = :sort               	"
				+"		WHERE hospCode           = :hospCode        	"
				+"		  AND susikCode          = :susikCode       	"
				+"		  AND startDate          = COALESCE(:startDate,'0000-00-00 00:00:00')";
		Query query = entityManager.createQuery(sql);
		query.setParameter("updId", updId);
		query.setParameter("susikName", susikName);
		query.setParameter("susikNameGana", susikNameGana);
		query.setParameter("susikCrDate", susikCrDate);
		query.setParameter("susikUpdDate", susikUpdDate);
		query.setParameter("susikDisableDate", susikDisableDate);
		query.setParameter("susikGwanriNo", susikGwanriNo);
		query.setParameter("susikGubun", susikGubun);
		query.setParameter("susikChangeCode", susikChangeCode);
		query.setParameter("susikDetailGubun", susikDetailGubun);
		query.setParameter("endDate", endDate);
		query.setParameter("sort", sort);
		query.setParameter("hospCode", hospCode);
		query.setParameter("susikCode", susikCode);
		query.setParameter("startDate", startDate);
		return query.executeUpdate();
	}

	@CacheEvict(value = "Cht0115Repository", allEntries = true)
	public Integer deleteCht0115Q01TransactionDeleted(
			String hospCode,
			String susikCode,
			Date startDate){
		String sql = "	DELETE Cht0115									       "
				+"	WHERE hospCode           = :hospCode                   "
				+"	  AND susikCode          = :susikCode                  "
				+"	  AND startDate          = COALESCE(:startDate,'0000-00-00 00:00:00')";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("susikCode", susikCode);
		query.setParameter("startDate", startDate);
		return query.executeUpdate();
	}

	@Override
//	@Cacheable(value = "Cht0115Repository")
	public List<CHT0115Q01grdCHT0115Info> getCHT0115Q01grdCHT0115ListItem(String hospCode, String susikDetail, Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUSIK_CODE													");
		sql.append("	     , SUSIK_NAME                                                   ");
		sql.append("	     , SUSIK_NAME_GANA                                              ");
		sql.append("	     , SUSIK_CR_DATE                                                ");
		sql.append("	     , SUSIK_UPD_DATE                                               ");
		sql.append("	     , SUSIK_DISABLE_DATE                                           ");
		sql.append("	     , SUSIK_GWANRI_NO                                              ");
		sql.append("	     , SUSIK_GUBUN                                                  ");
		sql.append("	     , SUSIK_CHANGE_CODE                                            ");
		sql.append("	     , SUSIK_DETAIL_GUBUN                                           ");
		sql.append("	     , START_DATE                                                   ");
		sql.append("	     , END_DATE                                                     ");
		sql.append("	     , SORT                                                         ");
		sql.append("	     , ''                                                           ");
		sql.append("	  FROM CHT0115                                                      ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                                        ");
		sql.append("	   AND SUSIK_DETAIL_GUBUN LIKE :susikDetail                         ");
		sql.append("	 ORDER BY SUSIK_DETAIL_GUBUN, SUSIK_CODE                            ");
		sql.append(" LIMIT :f_page_number,:f_offset                                         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("susikDetail", susikDetail);
		query.setParameter("f_page_number",pageNumber);
		query.setParameter("f_offset", offset);

		List<CHT0115Q01grdCHT0115Info> list = new JpaResultMapper().list(query, CHT0115Q01grdCHT0115Info.class);
		return list;
	}

	@Override
	@Cacheable(value = "Cht0115Repository")
	public String getCht0115Q01TransactionModifiedChk(String hospCode,
													  String susikCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT  'Y'							");
		sql.append("	FROM CHT0115                        ");
		sql.append("	WHERE HOSP_CODE  = :hospCode         ");
		sql.append("	  AND SUSIK_CODE = :susikCode    ");
		sql.append("	  LIMIT 1                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("susikCode", susikCode);

		List<Object> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && !StringUtils.isEmpty(list.get(0))){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value = "Cht0115Repository")
	public List<CHT0115Q00SusikCodeInfo> getCHT0115Q00SusikCodeInfo(String hospCode, String susikCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUSIK_NAME, A.SUSIK_NAME_GANA, A.SUSIK_DETAIL_GUBUN   ");
		sql.append(" FROM CHT0115 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                              ");
		sql.append("  AND A.SUSIK_CODE = :f_susik_code                              ");
		sql.append("   LIMIT 1 														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_susik_code", susikCode);
		List<CHT0115Q00SusikCodeInfo> list = new JpaResultMapper().list(query, CHT0115Q00SusikCodeInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Cht0115Repository")
	public List<CHT0115Q00GrdScInfo> getCHT0115Q00GrdScPost(String hospCode,String susikDetailGubun, String susikName) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUSIK_CODE        , A.SUSIK_NAME        ,                                 ");
		sql.append(" A.SUSIK_NAME_GANA   , A.SUSIK_DETAIL_GUBUN                                         ");
		sql.append("  FROM CHT0115 A                                                                    ");
		sql.append("   WHERE A.HOSP_CODE          = :f_hosp_code                                        ");
		sql.append("    AND A.SUSIK_DETAIL_GUBUN = :f_susik_detail_gubun                                ");
		sql.append("  AND (    A.SUSIK_NAME      LIKE :f_susik_name                                     ");
		sql.append("   OR A.SUSIK_NAME_GANA LIKE :f_susik_name )                                        ");
		sql.append(" AND IFNULL(A.SUSIK_DISABLE_DATE, STR_TO_DATE('99991231', '%Y%m%d')) >= SYSDATE()   ");
		sql.append("  ORDER BY A.SORT, A.SUSIK_NAME														");
		if(StringUtils.isEmpty(susikName)){
			sql.append("  LIMIT 100							                                            ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_susik_detail_gubun", susikDetailGubun);
		query.setParameter("f_susik_name", "%"+susikName+"%");
		List<CHT0115Q00GrdScInfo> list = new JpaResultMapper().list(query, CHT0115Q00GrdScInfo.class);
		return list;
	}

	@Override
	public List<CHT0115Q00GrdScInfo> getCHT0115Q00GrdScPre(String hopsCode,String ioGubun, String userId, String susikDetailGubun,String susikName) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUSIK_CODE        ,A.SUSIK_NAME        ,                                      ");
		sql.append(" A.SUSIK_NAME_GANA   , A.SUSIK_DETAIL_GUBUN                                             ");
		sql.append(" FROM (select * from VW_OUTSANG_SUSIK_RANK where HOSP_CODE = :f_hosp_code) B RIGHT JOIN  CHT0115 A ON  B.SUSIK_CODE = A.SUSIK_CODE     ");
		sql.append("  AND B.IO_GUBUN = :f_io_gubun AND B.DOCTOR  = :f_user_id                               ");
		sql.append(" WHERE A.HOSP_CODE          = :f_hosp_code                                              ");
		sql.append("  AND A.SUSIK_DETAIL_GUBUN LIKE :f_susik_detail_gubun                                   ");
		sql.append("   AND (    A.SUSIK_NAME      LIKE :f_susik_name                                        ");
		sql.append("   OR A.SUSIK_NAME_GANA LIKE :f_susik_name )                                            ");
		sql.append("   AND IFNULL(A.SUSIK_DISABLE_DATE, STR_TO_DATE('99991231', '%Y%m%d')) >= SYSDATE()     ");
		sql.append(" ORDER BY IFNULL(B.RANK_CNT, 0) DESC, A.SORT, A.SUSIK_CODE, A.SUSIK_NAME				");
		if(StringUtils.isEmpty(susikName)){
			sql.append("  LIMIT 100							                                            ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hopsCode);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_susik_detail_gubun", susikDetailGubun);
		query.setParameter("f_susik_name", "%"+susikName+"%");
		List<CHT0115Q00GrdScInfo> list = new JpaResultMapper().list(query, CHT0115Q00GrdScInfo.class);
		return list;
	}

	@Override
	public String callPrAdmUpdateMasterSusik(String hospCode, String userId,
											 String procGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_UPDATE_MASTER_SUSIKS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class, ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PROC_GUBUN", procGubun);

		String result = (String)query.getOutputParameterValue("IO_ERR_FLAG");
		return result;
	}

}

