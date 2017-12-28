package nta.med.data.dao.medi.ocs.impl;

import nta.med.core.domain.ocs.Ocs0170;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.SpeciFicCommentInputYnInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public class Ocs0170RepositoryImpl extends SimpleJpaRepository<Ocs0170, Long> implements Ocs0170Repository {
	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Ocs0170RepositoryImpl(EntityManager entityManager) {
		super(Ocs0170.class, entityManager);

	}

	@Override
	public List<SpeciFicCommentInputYnInfo> getSpeciFicCommentInputYnInfo(String hospCode, String hanmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SPECIFIC_COMMENT_TABLE_ID, SPECIFIC_COMMENT_COL_ID    ");
		sql.append("   FROM OCS0103 B, OCS0170 A                                    ");
		sql.append("  WHERE A.HOSP_CODE         = :f_hosp_code                      ");
		sql.append("   AND B.HANGMOG_CODE      = :f_hanmog_code                     ");
		sql.append("    AND B.HOSP_CODE         = A.HOSP_CODE                       ");
		sql.append("    AND B.SPECIFIC_COMMENT  = A.SPECIFIC_COMMENT     			"); 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hanmog_code", hanmogCode);
		List<SpeciFicCommentInputYnInfo> listResult = new JpaResultMapper().list(query, SpeciFicCommentInputYnInfo.class);
		return listResult;
	}
	@Override
	@Cacheable(value = "Ocs0170Repository")
	public String getLoadColumnCodeNameSpecificCommentCase(String specimen,
			String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SPECIFIC_COMMENT_NAME 			");
		sql.append("	 FROM OCS0170 A 	                    ");
		sql.append("	WHERE A.SPECIFIC_COMMENT  = :specimen   ");
		sql.append("	  AND A.HOSP_CODE         = :hospCode   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("specimen", specimen);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	@Override
	@Cacheable(value = "Ocs0170Repository")
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SPECIFIC_COMMENT              ");
		sql.append("       , A.SPECIFIC_COMMENT_NAME        ");
		sql.append("    FROM OCS0170 A                      ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code     ");
		sql.append("   ORDER BY A.SPECIFIC_COMMENT 			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value = "Ocs0170Repository")
	public List<Ocs0170> getHIOcsSpecificComment(String hospCode, String specificComment) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT a FROM Ocs0170 a WHERE a.hospCode = :hospCode AND a.specificComment = :specificComment");

		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("specificComment", specificComment);

		return query.getResultList();
	}

	@Override
	@CacheEvict(value = "Ocs0130Repository", allEntries = true)
	public Ocs0170 save(Ocs0170 ocs0170) {
		return super.save(ocs0170);
	}

	@Override
	@CacheEvict(value = "Ocs0130Repository", allEntries = true)
	public void delete(Ocs0170 ocs0170) {
		super.delete(ocs0170);
	}

	@Override
	public List<Ocs0170> save(List<Ocs0170> entities) {
		return super.save(entities);
	}
}

