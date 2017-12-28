package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5027RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00grdNURCntInfo;

/**
 * @author dainguyen.
 */
public class Nur5027RepositoryImpl implements Nur5027RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR5020U00grdNURCntInfo> getNUR5020U00grdNURCntInfo(String date, String hoDong, String hospCode, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT :f_date                  NUR_WRDT                             ");
		sql.append("        , :f_ho_dong               HO_DONG                              ");
		sql.append("        , B.CODE                   NUR_GRADE                            ");
		sql.append("        , B.CODE_NAME              NUR_GRADE_NAME                       ");
		sql.append("        , CAST(IFNULL(A.DAWN_CNT, 0) AS CHAR)        DAWN_CNT           ");
		sql.append("        , CAST(IFNULL(A.DAY_CNT, 0) AS CHAR)         DAY_CNT            ");
		sql.append("        , CAST(IFNULL(A.NIGHT_CNT, 0) AS CHAR)       NIGHT_CNT          ");
		sql.append("        , CAST(IFNULL(A.HOLI_CNT, 0) AS CHAR)        HOLI_CNT           ");
		sql.append("        , CAST(IFNULL(A.PAY_CNT, 0) AS CHAR)         PAY_CNT            ");
		sql.append("        , CAST(IFNULL(A.CHILDCARE_CNT, 0) AS CHAR)   CHILDCARE_CNT      ");
		sql.append("        , CAST(IFNULL(A.SPECIAL_CNT, 0) AS CHAR)     SPECIAL_CNT        ");
		sql.append("        , CAST(IFNULL(A.STUDY_CNT, 0) AS CHAR)        STUDY_CNT         ");
		sql.append("        , CAST(IFNULL(A.ABSENCE_CNT, 0) AS CHAR)        ABSENCE_CNT     ");
		sql.append("        , ''       								     DATA_ROW_STATE     ");
		sql.append("     FROM NUR0102 B                                                     ");
		sql.append("     LEFT JOIN NUR5027 A                                                ");
		sql.append("       ON A.HOSP_CODE       = B.HOSP_CODE                               ");
		sql.append("      AND A.NUR_GRADE       = B.CODE                                    ");
		sql.append("      AND A.NUR_WRDT        = STR_TO_DATE(:f_date, '%Y/%m/%d')          ");
		sql.append("      AND A.HO_DONG         = :f_ho_dong                                ");
		sql.append("    WHERE B.HOSP_CODE       = :f_hosp_code                              ");
		sql.append("      AND B.CODE_TYPE       = 'NURSE_GRADE'                             ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset											");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);

		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR5020U00grdNURCntInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdNURCntInfo.class);
		return listInfo;
	}
}

