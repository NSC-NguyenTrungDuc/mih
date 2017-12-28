package nta.med.data.dao.medi.adm.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.adm.Adm3100;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm3100Repository;
import nta.med.data.model.ihis.adma.ADM103UgrdUserGrpInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository("adm3100Repository")
public class Adm3100RepositoryImpl extends SimpleJpaRepository<Adm3100, Long> implements Adm3100Repository{
	private static Log LOG = LogFactory.getLog(Adm3100RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Adm3100RepositoryImpl(EntityManager entityManager) {
		super(Adm3100.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Adm3100Repository", allEntries = true)
	public Adm3100 save(Adm3100 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Adm3100Repository", allEntries = true)
	public List<Adm3100> save(List<Adm3100> entities) {
		return super.save(entities);
	}

	
	@CacheEvict(value = "Adm3100Repository", allEntries = true)
	@Override
	public void delete(Adm3100 entity) {
		super.delete(entity);
	}
	
	@CacheEvict(value = "Adm3100Repository", allEntries = true)
	public Integer updateADM103SaveLayout(String hospCode,
			 String groupNm, String sysId,
			 Date updTime, String userGroup, String language) {
		String sqlQuery = "UPDATE Adm3100 SET groupNm  = :f_group_nm  , upMemb  = :f_sys_id ,upTime = :f_upd_time WHERE hospCode  = :f_hosp_code AND userGroup  = :f_user_group AND language = :language ";
		Query query= entityManager.createQuery(sqlQuery.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_group_nm", groupNm);
		query.setParameter("f_sys_id", sysId); 
		query.setParameter("f_upd_time", updTime);
		query.setParameter("f_user_group", userGroup);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Adm3100Repository", allEntries = true)
	public Integer deleteADM103SaveLayout(String hospCode, String userGroup, String language) {
		String sqlQuery = "DELETE FROM Adm3100 WHERE hospCode = :f_hosp_code  AND userGroup   = :f_user_group AND language = :language ";
		Query query = entityManager.createQuery(sqlQuery.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_group", userGroup);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value="Adm3100Repository")
	public List<ADM103UgrdUserGrpInfo> getADM103UgrdUserGrpInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.USER_GROUP , A.GROUP_NM FROM ADM3100 A WHERE A.HOSP_CODE=:f_hosp_code AND A.LANGUAGE = :language    ");
		sql.append(" ORDER BY A.HOSP_CODE, A.USER_GROUP													                          ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<ADM103UgrdUserGrpInfo> list = new JpaResultMapper().list(query,ADM103UgrdUserGrpInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value="Adm3100Repository")
	public List<ComboListItemInfo> getComboUserGroup(String hospCode, String language,  boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append(" SELECT '%', FN_ADM_MSG(221,:language)			                          			");
			sql.append(" UNION                                                                   			");
		}
		sql.append(" SELECT A.USER_GROUP , A.GROUP_NM FROM ADM3100 A WHERE A.HOSP_CODE=:f_hosp_code AND A.LANGUAGE = :language    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}

}

