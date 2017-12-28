package nta.med.data.dao.medi.res.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.res.Res0104RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GridDoctorInfo;

/**
 * @author dainguyen.
 */
public class Res0104RepositoryImpl implements Res0104RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Res0104RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuroRES0102U00GridDoctorInfo> getNuroRES0102U00GridDoctor(String hospCode, String doctor){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR,                ");
		sql.append("       A.START_DATE,            ");
		sql.append("       A.END_DATE,              ");
		sql.append("       A.SAYU                   ");
		sql.append("FROM RES0104 A                  ");
		sql.append("WHERE A.HOSP_CODE = :hospCode   ");
		sql.append("  AND A.DOCTOR = :doctor        ");
		sql.append("ORDER BY A.START_DATE           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("doctor", doctor);
		query.setParameter("hospCode", hospCode);
		
		List<NuroRES0102U00GridDoctorInfo> list = new JpaResultMapper().list(query, NuroRES0102U00GridDoctorInfo.class);
		return list;
	}
	
	@Override
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorByStarDate(String hospCode, String doctor, String startDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR                                         ");
		sql.append("FROM RES0104 A                                          ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                           ");
		sql.append("  AND A.DOCTOR    = :doctor                             ");
		sql.append("  AND A.START_DATE = STR_TO_DATE(:startDate,'%Y/%m/%d') ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("doctor", doctor);
		query.setParameter("hospCode", hospCode);
		query.setParameter("startDate", startDate);
		
		List<NuroRES0102U00GetDoctorInfo> list = new JpaResultMapper().list(query, NuroRES0102U00GetDoctorInfo.class);
		return list;
	}
	
	@Override
	public String getNuroRES0102U00CheckDoctor3(String hospCode, String doctor, String date){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                                 ");
		sql.append("FROM RES0104                                               ");
		sql.append("WHERE HOSP_CODE = :hospCode                             ");
		sql.append("  AND DOCTOR    = :doctor                                ");
		sql.append("  AND START_DATE = DATE_FORMAT(:date,'%Y/%m/%d')   ");
		sql.append("  LIMIT  1                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);

		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getRES1001U00CheckJinryoYn(String hospCode, String doctor, Date preDate, String preTime) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_RES_LOAD_JINRYO_TIME_YN(:doctor, :preDate, :preTime, :hospCode)  ");
	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", preDate);
		query.setParameter("preTime", preTime);

		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		}
		return null;
	}
	
//	@Override
//	public boolean InsertNuroRES0102U00InsertRES0104(String hospCode, NuroRES0102U00UpdateRES0104Info nuroRES0102U00UpdateRES0104Info){
//		try{
//			StringBuilder sql = new StringBuilder();
//			sql.append("INSERT INTO RES0104                                                                        ");
//			sql.append("          ( SYS_DATE    , SYS_ID      , UPD_DATE , UPD_ID     , DOCTOR    ,                ");
//			sql.append("            START_DATE  , END_DATE    , END_YN   , SAYU       , HOSP_CODE )                ");
//			sql.append("    VALUES                                                                                 ");
//			sql.append("          ( SYSDATE()    , :q_user_id  , SYSDATE(), :q_user_id , :f_doctor     ,           ");
//			sql.append("            DATE_FORMAT(:f_start_date, '%Y/%m/%d'), DATE_FORMAT(:f_end_date, '%Y/%m/%d') , ");
//			sql.append("            'N'      , :f_sayu    , :f_hosp_code  )                                        ");
//			
//			Query query = entityManager.createNativeQuery(sql.toString());
//			query.setParameter("f_hosp_code", hospCode);
//			query.setParameter("q_user_id", nuroRES0102U00UpdateRES0104Info.getUserId());
//			query.setParameter("f_doctor", nuroRES0102U00UpdateRES0104Info.getDoctor());
//			query.setParameter("f_start_date", nuroRES0102U00UpdateRES0104Info.getStartDate());
//			query.setParameter("f_end_date", nuroRES0102U00UpdateRES0104Info.getEndDate());
//			query.setParameter("f_sayu", nuroRES0102U00UpdateRES0104Info.getSayu());
//			
//			query.executeUpdate();
//			
//			return true;
//		}catch(Exception e){
//			LOG.error(e.getMessage(),e);
//			return false;
//		}
//	}

}

