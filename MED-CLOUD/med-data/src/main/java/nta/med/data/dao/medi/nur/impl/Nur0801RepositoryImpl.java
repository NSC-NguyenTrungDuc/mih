package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0801;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0801Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

@Repository("nur0801Repository")
public class Nur0801RepositoryImpl extends SimpleJpaRepository<Nur0801, Long> implements Nur0801Repository {

	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Nur0801RepositoryImpl(EntityManager entityManager) {
		super(Nur0801.class, entityManager);
	}

	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Nur0801Repository", allEntries = true)
	public Nur0801 save(Nur0801 entity) {
		return super.save(entity);
	}

	@Override
	@CacheEvict(value = "Nur0801Repository", allEntries = true)
	public List<Nur0801> save(List<Nur0801> entities) {
		return super.save(entities);
	}

	@Override
	public List<Nur0801> findByHospCodeHoDong(String hospCode, String hoDong) {
		String sql = "SELECT T FROM Nur0801 T WHERE T.hospCode = :hospCode AND T.hoDong = :hoDong";
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);
		query.setParameter("hoDong", hoDong);
		return query.getResultList();
	}

	@Override
	public Integer updateByHospCodeHoDOng(String updId, String makeHFileYn, String hospCode, String hoDong) {
		String sql = "UPDATE Nur0801 SET updId = :updId, updDate = SYSDATE(), makeHFileYn = :makeHFileYn WHERE hospCode = :hospCode AND hoDong = :hoDong";
		Query query = entityManager.createQuery(sql);
		
		query.setParameter("updId", updId);
		query.setParameter("makeHFileYn", makeHFileYn);
		query.setParameter("hospCode", hospCode);
		query.setParameter("hoDong", hoDong);
		return query.executeUpdate();
	}

	@Override
	public Integer deleteByHospCodeHoDong(String hospCode, String hoDong) {
		String sql = "DELETE Nur0801 WHERE hospCode = :hospCode AND hoDong = :hoDong";
		Query query = entityManager.createQuery(sql);
		
		query.setParameter("hospCode", hospCode);
		query.setParameter("hoDong", hoDong);
		return query.executeUpdate();
	}

	@Override
	public List<ComboListItemInfo> getNUR0802U00xEditGridCel3(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.NEED_TYPE, '')        AS NEED_TYPE  ");
		sql.append("	      ,IFNULL(B.CODE_NAME, '')        AS CODE_NAME  ");
		sql.append("	FROM NUR0801 A                                      ");
		sql.append("	JOIN NUR0102 B ON B.HOSP_CODE = A.HOSP_CODE         ");
		sql.append("	              AND B.CODE_TYPE = 'NEED_TYPE'         ");
		sql.append("	              AND B.CODE      = A.NEED_TYPE         ");
		sql.append("	              AND B.LANGUAGE  = :f_language         ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getNUR8003R02cboHoDong(String hospCode, String needHType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%'     AS CODE                                            ");
		sql.append("	    , '全体'   AS CODE_NAME                                        ");
		sql.append("	FROM DUAL                                                         ");
		sql.append("	UNION                                                             ");
		sql.append("	SELECT  A.HO_DONG                                                 ");
		sql.append("	      , B.GWA_NAME                                                ");
		sql.append("	 FROM BAS0260 B                                                   ");
		sql.append("	    , NUR0801 A                                                   ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code                               ");
		sql.append("	  AND A.NEED_TYPE    IN (SELECT X.NEED_TYPE                       ");
		sql.append("	                           FROM NUR0811 X                         ");
		sql.append("	                          WHERE X.HOSP_CODE      = A.HOSP_CODE    ");
		sql.append("	                            AND X.NEED_H_TYPE    = :f_need_h_type ");
		sql.append("	                         )                                        ");
		sql.append("	  AND IFNULL(A.MAKE_H_FILE_YN, 'N') = 'Y'                         ");
		sql.append("	  AND B.HOSP_CODE    = A.HOSP_CODE                                ");
		sql.append("	  AND B.BUSEO_GUBUN  = '2'                                        ");
		sql.append("	  AND B.GWA          = A.HO_DONG                                  ");
		sql.append("	  AND CURRENT_DATE() BETWEEN B.START_DATE AND B.END_DATE          ");
		sql.append("	ORDER BY 1                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_h_type", needHType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getNUR8003U03CboHoDong(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  B.HO_DONG                  ");
		sql.append("	      , A.GWA_NAME                 ");
		sql.append("	  FROM  NUR0801     B              ");
		sql.append("	      , BAS0260     A              ");
		sql.append("	 WHERE  A.HOSP_CODE = :f_hosp_code ");
		sql.append("	   AND  B.HOSP_CODE = A.HOSP_CODE  ");
		sql.append("	   AND  B.HO_DONG   = A.GWA        ");
		sql.append("	   AND  A.BUSEO_GUBUN = '2'        ");
		sql.append("	   AND  A.GWA IS NOT NULL          ");
		sql.append("	   AND  A.LANGUAGE = :f_language   ");
		sql.append("	 ORDER BY B.HO_DONG                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

}
