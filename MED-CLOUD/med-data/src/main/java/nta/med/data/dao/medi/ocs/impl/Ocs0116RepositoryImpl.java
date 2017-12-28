package nta.med.data.dao.medi.ocs.impl;

import nta.med.core.domain.ocs.Ocs0116;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public class Ocs0116RepositoryImpl extends SimpleJpaRepository<Ocs0116, Long> implements Ocs0116Repository {
	@PersistenceContext
	private EntityManager entityManager;
	@Autowired
	public Ocs0116RepositoryImpl(EntityManager entityManager) {
		super(Ocs0116.class, entityManager);

	}
	@Override
	@Cacheable(value = "Ocs0116Repository")
	public String getOCS0116GetCodeNameByCode(String code, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT SPECIMEN_NAME 				");
		sql.append("	 FROM OCS0116                       ");
		sql.append("	WHERE SPECIMEN_CODE = :code       ");
		if(!StringUtils.isEmpty(hospCode)){
			sql.append("	AND HOSP_CODE = :hospCode       ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("code", code);
		if(!StringUtils.isEmpty(hospCode)){
			query.setParameter("hospCode", hospCode);
		}
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	@Override
	@Cacheable(value = "Ocs0116Repository")
	public List<ComboListItemInfo> getOCS0113U00GetFindWorker(String hospCode, boolean isOrder) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SPECIMEN_CODE, A.SPECIMEN_NAME 		");
		sql.append("	  FROM OCS0116 A                                ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                  ");
		if(isOrder){
			sql.append("	ORDER BY A.SPECIMEN_CODE                  	");
		}
		sql.append("	AND A.LANGUAGE = :f_language       				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	@Override
	public String getLoadColumnNameSpecimenCodeHangmogCase(String argu2,
			String argu1, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT B.SPECIMEN_NAME 							");
		sql.append("	 FROM OCS0116 B, OCS0113 A                      ");
		sql.append("	WHERE A.HANGMOG_CODE  = :argu2                  ");
		sql.append("	  AND A.SPECIMEN_CODE = :argu1                  ");
		sql.append("	  AND A.HOSP_CODE     = :hospCode               ");
		sql.append("	  AND A.SPECIMEN_CODE = B.SPECIMEN_CODE         ");
		sql.append("	  AND A.HOSP_CODE     = B.HOSP_CODE             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("argu2", argu2);
		query.setParameter("argu1", argu1);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	@Override
	@Cacheable(value = "Ocs0116Repository")
	public String getCpl0108U00DupYn(String hospCode, String code, String gubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'									");
		sql.append("	 FROM OCS0116                               ");
		sql.append("	WHERE HOSP_CODE     = :f_hosp_code          ");
		sql.append("	  AND SPECIMEN_CODE = :f_code               ");
		sql.append("	  AND SPECIMEN_GUBUN = :gubun               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("gubun", gubun);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}


	@Override
	@CacheEvict(value = "Ocs0116Repository", allEntries = true)
	public Integer UpdateCpl0108U00Ocs0116(String updId, String specimenName, String hospCode, String specimenCode, String specimenGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE Ocs0116							   ");
		sql.append(" SET updId            = :updId             ");
		sql.append("   , updDate          = SYSDATE()          ");
		sql.append("   , specimenName     = :specimenName      ");
		//sql.append("   , modifyFlg     	  = :modifyFlg		   ");
		sql.append(" WHERE hospCode       = :hospCode          ");
		sql.append(" AND specimenCode     = :specimenCode      ");
		sql.append(" AND specimenGubun    = :specimenGubun     ");

		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("updId", updId);
		query.setParameter("specimenName", specimenName);
		//query.setParameter("modifyFlg", ModifyFlg.UPDATE.getValue());
		query.setParameter("hospCode", hospCode);
		query.setParameter("specimenCode", specimenCode);
		query.setParameter("specimenGubun", specimenGubun);

		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Ocs0116Repository", allEntries = true)
	public Ocs0116 save(Ocs0116 ocs0116) {
		return super.save(ocs0116);
	}
	@CacheEvict(value = "Ocs0116Repository", allEntries = true)
	public void delete (Ocs0116 ocs0116)
	{
		super.delete(ocs0116);
	}
	@Override
	@CacheEvict(value = "Ocs0116Repository", allEntries = true)
	public List<Ocs0116> save(List<Ocs0116> entities) {
		return super.save(entities);
	}
}

