package nta.med.data.dao.medi.ocs.impl;

import nta.med.core.domain.ocs.Ocs0130;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.OcsLoadInputControlListItemInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import java.util.Collection;
import java.util.Collections;
import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public class Ocs0130RepositoryImpl extends SimpleJpaRepository<Ocs0130, Long> implements Ocs0130Repository {
	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Ocs0130RepositoryImpl(EntityManager entityManager) {
		super(Ocs0130.class, entityManager);
	}

	@Override
	public String getOCS0304U00GetDoctorYaksokOpenId(String hospCode,
			String doctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT C.YAKSOK_OPEN_ID  															");                                        
		sql.append("	FROM OCS0130 C,                                                                     ");
		sql.append("	     ( SELECT IFNULL(A.TONGGYE_DOCTOR, A.DOCTOR ) DOCTOR                            ");
		sql.append("	         FROM BAS0270 A                                                             ");
		sql.append("	        WHERE A.HOSP_CODE = :hospCode                                              ");
		sql.append("	          AND A.DOCTOR    = :doctor  			                                   ");
		sql.append("	          AND A.END_DATE  = (SELECT MAX(B.END_DATE)                                 ");
		sql.append("	                               FROM BAS0270 B                                       ");
		sql.append("	                              WHERE B.HOSP_CODE = A.HOSP_CODE                       ");
		sql.append("	                                AND B.DOCTOR    = A.DOCTOR ) ) D                    ");
		sql.append("	WHERE C.HOSP_CODE  = :hospCode                                                   ");
		sql.append("	  AND C.MEMB       = D.DOCTOR;                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);

		List<Object> listResult = query.getResultList();
		if(listResult!=null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OcsLoadInputControlListItemInfo> getOcslibControlListItem(String hospCode, String language, String inputControl) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.INPUT_CONTROL           input_control          					");
		sql.append("	       , A.INPUT_CONTROL_NAME    input_control_name                         ");
		sql.append("	       , A.SPECIMEN_CR_YN        specimen_code                              ");
		sql.append("	       , A.SURYANG_CR_YN         suryang                                    ");
		sql.append("	       , A.ORD_DANUI_CR_YN       ord_danui                                  ");
		sql.append("	       , A.DV_CR_YN              dv                                         ");
		sql.append("	       , A.NALSU_CR_YN           nalsu                                      ");
		sql.append("	       , A.JUSA_CR_YN            jusa                                       ");
		sql.append("	       , A.BOGYONG_CODE_CR_YN    bogyong_code                               ");
		sql.append("	       , A.TOIWON_DRG_CR_YN      toiwon_drg_yn                              ");
		sql.append("	       , A.PORTABLE_CR_YN        portable_yn                                ");
		sql.append("	       , A.AMT_CR_YN             amt                                        ");
		sql.append("	       , A.WONYOI_ORDER_YN_CR_YN wonyoi_order_yn                            ");
		sql.append("	    FROM OCS0133 A                                                          ");
		sql.append("	   WHERE A.HOSP_CODE = :hospCode AND A.LANGUAGE = :language                 ");
		sql.append("	     AND A.INPUT_CONTROL LIKE CONCAT(TRIM(:inputControl),'%')            ");
		sql.append("	   ORDER BY A.INPUT_CONTROL       											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("inputControl", inputControl);

		List<OcsLoadInputControlListItemInfo> listResult = new JpaResultMapper().list(query, OcsLoadInputControlListItemInfo.class);
		return listResult;
	}
	@Override
	@Cacheable(value = "Ocs0130Repository")
	public String getMembName(String hospCode, String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT MEMB_NAME 	");
		sql.append("	FROM OCS0130 	");
		sql.append("	WHERE HOSP_CODE = :hospCode 	");
		sql.append("	AND MEMB = :user_id 	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("user_id", userId);

		@SuppressWarnings("unchecked")
		List<Object> listResult = query.getResultList();
		if(listResult!=null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	@Override
	public List<ComboListItemInfo> getSangOpenDoctorNameInfo(String hospCode, String doctorGwa){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.SANG_OPEN_ID, A.DOCTOR_NAME 						");
		sql.append("	FROM OCS0130 B, 	                                        ");
		sql.append("	BAS0270 A 	                                                ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code	                        ");
		sql.append("	AND A.DOCTOR_GWA = :f_doctor_gwa	                        ");
		sql.append("	AND DATE_FORMAT(SYSDATE() ,'%Y%m%d') BETWEEN A.START_DATE 	");
		sql.append("	AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) 	");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE 	                            ");
		sql.append("	AND B.MEMB = A.SABUN 	                                    ");
		sql.append("	ORDER BY 1 	                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor_gwa", doctorGwa);

		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String getOcsComUserId(String hospCode, String userGubun, String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_LOAD_MEMB_COMID(:f_hosp_code,:f_user_gubun, :f_user_id) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_gubun", userGubun);
		query.setParameter("f_user_id", userId);
		List<Object> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			if(listResult.get(0) != null){
				return listResult.get(0).toString();
			}
		}
		return null;
	}

	@Override
	@CacheEvict(value = "Ocs0130Repository", allEntries = true)
	public Ocs0130 save(Ocs0130 baseEntity) {
		return super.save(baseEntity);
	}

	@Override
	@CacheEvict(value = "Ocs0130Repository", allEntries = true)
	public void delete(Ocs0130 baseEntity) {
		super.delete(baseEntity);
	}

	@Override
	@CacheEvict(value = "Ocs0130Repository", allEntries = true)
	public List<Ocs0130> save(List<Ocs0130> entities) {
		return super.save(entities);
	}
}


