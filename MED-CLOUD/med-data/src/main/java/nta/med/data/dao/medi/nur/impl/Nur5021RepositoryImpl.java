package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5021RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGuhoGubunInfo;

/**
 * @author dainguyen.
 */
public class Nur5021RepositoryImpl implements Nur5021RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR5020U00grdGuhoGubunInfo> getNUR5020U00grdGuhoGubunInfoMode2(String hospCode, String hoDong, String date, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT  A.STAIR                                               ");
		sql.append("         , A.STAIR_NAME                                          ");
		sql.append("         , ifnull(cast(A.STAIR_TOTAL_CNT as char), '')			 ");
		sql.append("         , A.NUR_WRDT                                            ");
		sql.append("         , A.HO_DONG                                             ");
		sql.append("         , A.DANSONG_CNT                                         ");
		sql.append("         , A.HOSONG_CNT                                          ");
		sql.append("         , A.DOKBO_CNT                                           ");
		sql.append("      FROM NUR5021 A                                             ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                            ");
		sql.append("       AND A.HO_DONG   = :f_ho_dong                              ");
		sql.append("       AND A.NUR_WRDT  = STR_TO_DATE(:f_date, '%Y/%m/%d')        ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset									 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);

		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR5020U00grdGuhoGubunInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdGuhoGubunInfo.class);
		return listInfo;
	}
}

