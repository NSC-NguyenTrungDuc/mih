package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0802;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0802Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

@Repository("nur0802Repository")
public class Nur0802RepositoryImpl extends SimpleJpaRepository<Nur0802, Long> implements Nur0802Repository{

	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Nur0802RepositoryImpl(EntityManager entityManager) {
		super(Nur0802.class, entityManager);
	}

	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Nur0802Repository", allEntries = true)
	public Nur0802 save(Nur0802 entity) {
		return super.save(entity);
	}

	@Override
	@CacheEvict(value = "Nur0802Repository", allEntries = true)
	public List<Nur0802> save(List<Nur0802> entities) {
		return super.save(entities);
	}

	@Override
	public List<ComboListItemInfo> getNUR0802U00xEditGridCel1(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT IFNULL(A.NEED_GUBUN, '')         AS NEED_GUBUN ");
		sql.append("	               ,IFNULL(B.CODE_NAME, '')          AS CODE_NAME  ");
		sql.append("	FROM NUR0802 A                                                 ");
		sql.append("	JOIN NUR0102 B ON A.HOSP_CODE = B.HOSP_CODE                    ");
		sql.append("	              AND B.CODE_TYPE = 'NEED_GUBUN'                   ");
		sql.append("	              AND B.CODE      = A.NEED_GUBUN                   ");
		sql.append("	              AND B.LANGUAGE  = :f_language                    ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code                             ");
		sql.append("	ORDER BY A.NEED_GUBUN                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@Cacheable(value = "Nur0802Repository")
	public List<Nur0802> findByHospCodeNeedTypeNeedGubunNeedAsmtCode(String hospCode, String needType, String needGubun,
			String needAsmtCode) {
		
		String sql = "SELECT T FROM Nur0802 T WHERE T.hospCode = :hospCode AND T.needType = :needType AND T.needGubun = :needGubun AND T.needAsmtCode = :needAsmtCode";
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("needType", needType);
		query.setParameter("needGubun", needGubun);
		query.setParameter("needAsmtCode", needAsmtCode);
		
		return query.getResultList();
	}

	@Override
	@CacheEvict(value = "Nur0802Repository", allEntries = true)
	public Integer updateByHospCodeNeedGubunNeedTypeNeedAsmtCode(String userId, String makeHFileYn, String hospCode,
			String needGubun, String needType, String needAsmtCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE NUR0802 A                            ");
		sql.append("	 SET A.UPD_ID         = :f_user_id          ");
		sql.append("	   , A.UPD_DATE       = SYSDATE()           ");
		sql.append("	   , A.MAKE_H_FILE_YN = :f_make_h_file_yn   ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code        ");
		sql.append("	 AND A.NEED_GUBUN     = :f_need_gubun       ");
		sql.append("	 AND A.NEED_TYPE      = :f_need_type        ");
		sql.append("	 AND A.NEED_ASMT_CODE = :f_need_asmt_code   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_make_h_file_yn", makeHFileYn);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_type", needType);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Nur0802Repository", allEntries = true)
	public Integer deleteByHospCodeNeedGubunNeedTypeNeedAsmtCode(String hospCode, String needGubun, String needType,
			String needAsmtCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE FROM NUR0802                       ");
		sql.append("	WHERE HOSP_CODE     = :f_hosp_code        ");
		sql.append("	 AND NEED_GUBUN     = :f_need_gubun       ");
		sql.append("	 AND NEED_TYPE      = :f_need_type        ");
		sql.append("	 AND NEED_ASMT_CODE = :f_need_asmt_code   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_type", needType);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		
		return query.executeUpdate();
	}
	
}
