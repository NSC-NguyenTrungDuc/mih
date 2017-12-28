package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0113RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0113Info;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0113ListItemInfo;

/**
 * @author dainguyen.
 */
public class Ocs0113RepositoryImpl implements Ocs0113RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0113U00GrdOCS0113ListItemInfo> getOCS0113U00GrdOCS0113ListItem(
			String hospCode, String hangmongCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.HANGMOG_CODE ,   						");
		sql.append("	      A.SEQ          ,                          ");
		sql.append("	      A.DEFAULT_YN   ,                          ");
		sql.append("	      A.SPECIMEN_CODE,                          ");
		sql.append("	      B.SPECIMEN_NAME,                          ");
		sql.append("	      A.HANGMOG_START_DATE,                     ");
		sql.append("	      ''                                        ");
		sql.append("	 FROM OCS0113 A,                                ");
		sql.append("	      OCS0116 B                                 ");
		sql.append("	WHERE A.HOSP_CODE     = :hospCode            ");
		sql.append("	  AND A.HANGMOG_CODE  = :hangmongCode         ");
		sql.append("	  AND B.HOSP_CODE     = A.HOSP_CODE             ");
		sql.append("	  AND B.SPECIMEN_CODE = A.SPECIMEN_CODE         ");
		sql.append("	ORDER BY A.SEQ                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmongCode", hangmongCode);
		
		List<OCS0113U00GrdOCS0113ListItemInfo> list = new JpaResultMapper().list(query, OCS0113U00GrdOCS0113ListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0103U00GrdOCS0113Info> getOCS0103U00GrdOCS0113Info(String hospCode, String aHangmogCode, String aHangmogStartDate) {
		StringBuilder sql = new StringBuilder();
		 sql.append("  SELECT A.HANGMOG_CODE                                                            ");
		 sql.append("       , A.SEQ                                                                     ");
		 sql.append("       , A.DEFAULT_YN                                                              ");
		 sql.append("       , A.SPECIMEN_CODE                                                           ");
		 sql.append("       , B.SPECIMEN_NAME                                                           ");
		 sql.append("       , A.HOSP_CODE                                                               ");
		 sql.append("       , A.HANGMOG_START_DATE                                                      ");
		 sql.append("    FROM OCS0116 B                                                                 ");
		 sql.append("       , OCS0113 A                                                                 ");
		 sql.append("   WHERE A.HOSP_CODE     = :f_hosp_code                                            ");
		 sql.append("     AND A.HANGMOG_CODE  = :f_aHangmogCode                                         ");
		 sql.append("     AND A.HANGMOG_START_DATE = STR_TO_DATE(:f_aHangmogStartDate,'%Y/%m/%d')       ");
		 sql.append("     AND B.HOSP_CODE     = A.HOSP_CODE                                             ");
		 sql.append("     AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                         ");
		 sql.append("   ORDER BY A.SEQ																	");

		 Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_aHangmogCode", aHangmogCode);
		 query.setParameter("f_aHangmogStartDate", aHangmogStartDate);
		 List<OCS0103U00GrdOCS0113Info> list = new JpaResultMapper().list(query, OCS0103U00GrdOCS0113Info.class);
		return list;  
		 
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SPECIMEN_CODE                     ");
		sql.append("      , B.SPECIMEN_NAME                     ");
		sql.append("   FROM OCS0116 B                           ");
		sql.append("      , OCS0113 A                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code          ");
		sql.append("    AND A.HANGMOG_CODE = :f_hangmog_code    ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE       ");
		sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE   ");
		sql.append("  ORDER BY A.SPECIMEN_CODE  				");
		Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_hangmog_code", hangmogCode);
		 List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
			return list;  
	}
}

