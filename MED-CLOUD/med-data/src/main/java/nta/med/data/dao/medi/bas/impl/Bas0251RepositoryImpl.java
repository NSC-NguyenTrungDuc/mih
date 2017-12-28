package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.Bas0251;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0251Repository;
import nta.med.data.model.ihis.bass.HoGradeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */

@Repository("bas0251Repository")
public class Bas0251RepositoryImpl extends SimpleJpaRepository<Bas0251, Long> implements Bas0251Repository {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0251RepositoryImpl(EntityManager entityManager) {
		super(Bas0251.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0251Repository", allEntries = true)
	public Bas0251 save(Bas0251 entity) {
		return super.save(entity);
	}

	@CacheEvict(value = "Bas0251Repository", allEntries = true)
	public List<Bas0251> save(List<Bas0251> entities) {
		return super.save(entities);
	}

	@Override
	@Cacheable(value = "Bas0251Repository")
	public List<Bas0251> findByHospCode(String hospCode) {
		String sql = " SELECT T FROM Bas0251 T WHERE hospCode = :f_hosp_code AND SYSDATE() BETWEEN startDate and endDate ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		
		return query.getResultList();
	}
	
	@Override
	@Cacheable(value = "Bas0251Repository")
	public List<HoGradeInfo> getHoGradeInfo(String hospCode, String find1, String startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_GRADE																");
		sql.append("	      ,IFNULL(A.HO_GRADE_NAME, '')												");
		sql.append("	FROM BAS0251 A																	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code												");
		sql.append("	 AND (A.HO_GRADE LIKE :f_find1 OR A.HO_GRADE_NAME LIKE :f_find1)				");
		sql.append("	 AND DATE_FORMAT(:f_start_date,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE	");
		sql.append("	ORDER BY HO_GRADE																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1 + "%");
		query.setParameter("f_start_date", startDate);

		List<HoGradeInfo> lstResult = new JpaResultMapper().list(query, HoGradeInfo.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00cboFromToHoGrade(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																								");
		sql.append("		A.HO_GRADE,																						");
		sql.append("		A.HO_GRADE_NAME																					");
		sql.append("	FROM																								");
		sql.append("		BAS0251 A																						");
		sql.append("	WHERE																								");
		sql.append("		A.HOSP_CODE    								= :f_hosp_code										");
		sql.append("		AND CURRENT_DATE() 	BETWEEN A.START_DATE AND A.END_DATE											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00fbxToGwa(String hospCode, String date, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																								");
		sql.append("		A.GWA         		gwa,																		");
		sql.append("	    A.GWA_NAME    		gwa_name																	");
		sql.append("	FROM																								");
		sql.append("		VW_GWA_NAME A																					");
		sql.append("	WHERE																								");
		sql.append("		A.HOSP_CODE   							= :f_hosp_code 											");
		sql.append("	  	AND A.BUSEO_GUBUN 						= '1'													");
		sql.append("	  	AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN A.START_DATE AND A.END_DATE						");
		sql.append("	  	AND ((A.GWA LIKE :f_find1) OR (A.GWA_NAME LIKE :f_find1))										");
		sql.append("	  	AND A.IPWON_YN 							= 'Y'													");
		sql.append("	ORDER BY 1																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_find1", find1 + "%");
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

}
