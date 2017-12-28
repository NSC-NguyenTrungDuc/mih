package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5025RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00grdCommentInfo;

/**
 * @author dainguyen.
 */
public class Nur5025RepositoryImpl implements Nur5025RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR5020U00grdCommentInfo> getNUR5020U00grdCommentInfo(String hospCode, String date, String hoDong, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DATE_FORMAT(A.COMMENT_DATE, '%Y/%m/%d')                  ");
		sql.append("        , A.HO_DONG                                                ");
		sql.append("        , A.REMARK                                                 ");
		sql.append("        , CAST(A.SEQ AS CHAR)                                      ");
		sql.append("        , '' DATA_ROW_STATE                                        ");
		sql.append("     FROM NUR5025 A                                                ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                               ");
		sql.append("      AND A.HO_DONG   = :f_ho_dong                                 ");
		sql.append("      AND A.COMMENT_DATE = STR_TO_DATE(:f_date, '%Y/%m/%d')        ");
		sql.append("    ORDER BY SEQ                                                   ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset										");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);

		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR5020U00grdCommentInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdCommentInfo.class);
		return listInfo;
	}
}

