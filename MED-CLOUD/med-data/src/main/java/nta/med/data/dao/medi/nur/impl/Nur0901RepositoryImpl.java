package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0901RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR9001U00layBojoListInfo;

/**
 * @author dainguyen.
 */
public class Nur0901RepositoryImpl implements Nur0901RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR9001U00layBojoListInfo> getNUR9001U00layBojoListInfo(String hospCode, String soapGubun, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.SOAP_BUN1          SOAP_BUN1,                                        ");
		sql.append("         A.SOAP_BUN1_NAME     SOAP_BUN1_NAME,                                   ");
		sql.append("         B.SOAP_BUN2          SOAP_BUN2,                                        ");
		sql.append("         B.SOAP_BUN2_NAME     SOAP_BUN2_NAME,                                   ");
		sql.append("         CAST(A.SORT_KEY AS CHAR) SORT_KEY,                                     ");
		sql.append("         CAST(B.SORT_KEY AS CHAR) SORT_KEY2                                     ");
		sql.append("    FROM NUR0901 A                                                              ");
		sql.append("    JOIN NUR0902 B                                                              ");
		sql.append("      ON B.HOSP_CODE     = A.HOSP_CODE                                          ");
		sql.append("     AND B.SOAP_GUBUN    = A.SOAP_GUBUN                                         ");
		sql.append("     AND B.SOAP_BUN1     = A.SOAP_BUN1                                          ");
		sql.append("     AND B.VALD          = 'Y'                                                  ");
		sql.append("     AND B.HO_DONG       = A.HO_DONG                                            ");
		sql.append("   WHERE A.HOSP_CODE     = :f_hosp_code                                         ");
		sql.append("     AND A.HO_DONG       = :f_ho_dong                                           ");
		sql.append("     AND A.SOAP_GUBUN    = :f_soap_gubun                                        ");
		sql.append("     AND A.VALD          = 'Y'                                                  ");
		sql.append("   ORDER BY A.SORT_KEY, A.SOAP_BUN1_NAME, B.SORT_KEY, B.SOAP_BUN2_NAME          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_soap_gubun", soapGubun);
		
		List<NUR9001U00layBojoListInfo> listInfo = new JpaResultMapper().list(query, NUR9001U00layBojoListInfo.class);
		return listInfo;
		
	}
}

