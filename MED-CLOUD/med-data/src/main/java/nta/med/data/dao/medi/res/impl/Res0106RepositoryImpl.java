package nta.med.data.dao.medi.res.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.res.Res0106RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleListItemInfo;

/**
 * @author dainguyen.
 */
public class Res0106RepositoryImpl implements Res0106RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Res0106RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<String> getCboAvgTime(){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.TIME_TERM 				");
		sql.append("FROM RES0106 A                           	");
		sql.append("ORDER BY CAST(A.TIME_TERM AS SIGNED)     	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<NuroRES1001U00ReservationScheduleListItemInfo> getReservationScheduleList(String hospitalCode, String examPreDate, String departmentCode, String doctorCode,
			String fromTime, String toTime, String avgTime){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT                                           																								");                                                                      
		sql.append("	        A.TIME                  JINRYO_PRE_TIME,                                                                                               " );
		sql.append("	        ''                       BUNHO,                                                                                                        " );
		sql.append("	        ''                       SUNAME,                                                                                                       " );
		sql.append("	        ''                       SUNAME2,                                                                                                      " );
		sql.append("	        ''                       CHOJAE,                                                                                                       " );
		sql.append("	        ''                       RESER_DATE,                                                                                                   " );
		sql.append("	        ''                       PKOUT1001,                                                                                                    " );
		sql.append("	        STR_TO_DATE(:examPreDate, '%Y/%m/%d')       JINRYO_PRE_DATE,                                                                           " );
		sql.append("	        :departmentCode                   GWA,                                                                                                 " );
		sql.append("	        ''                       JUBSU_NO,                                                                                                     " );
		sql.append("	        ''                       gubun,                                                                                                        " );
		sql.append("	        :doctorCode                DOCTOR,                                                                                                     " );
		sql.append("	        ''                       RES_GUBUN             ,                                                                                       " );
		sql.append("	        ''                       RES_CHANGGU           ,                                                                                       " );
		sql.append("	        'Z'                      RES_INPUT_GUBUN       ,                                                                                       " );
		sql.append("	        'N'                      NAEWON_YN      ,                                                                                              " );
		sql.append("	        'Y'                      NEWROW         ,                                                                                              " );
		sql.append("	        FN_RES_LOAD_JINRYO_TIME_YN(:doctorCode, STR_TO_DATE(:examPreDate, '%Y/%m/%d'), A.TIME, :hospitalCode) JINRYO_YN                        " );
		sql.append("	FROM RES0106 A                                                                                                                                 " );
		sql.append("	WHERE A.TIME_TERM          = '1'                                                                                                         	   " );
		sql.append("	  AND A.TIME              >= :fromTime                                                                                                         " );
		sql.append("	  AND A.TIME              <= :toTime                                                                                                           " );
		sql.append("	  AND MOD( ROUND(DATE_FORMAT( SUBTIME(STR_TO_DATE(A.TIME,'%H%i%s') ,STR_TO_DATE(:fromTime,'%H%i%s')),'%i')), :avgTime) = 0               	   " );                                   
		sql.append("	ORDER BY 1, 15   																															   " );		
		                
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("examPreDate", examPreDate);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("doctorCode", doctorCode);
		query.setParameter("fromTime", fromTime);
		query.setParameter("toTime", toTime);
		query.setParameter("avgTime", avgTime);
		
		List<NuroRES1001U00ReservationScheduleListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00ReservationScheduleListItemInfo.class);
		return list;
	}
}

