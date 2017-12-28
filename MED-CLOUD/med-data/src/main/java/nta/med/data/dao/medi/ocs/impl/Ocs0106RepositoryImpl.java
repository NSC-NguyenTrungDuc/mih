package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0106RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0106ListItemInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdComment3Info;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ocs0106RepositoryImpl implements Ocs0106RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0101U00GrdOcs0106ListItemInfo> getOCS0101U00GrdOcs0106ListItem(
			String hospCode, String slipCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.SLIP_CODE,									");
		sql.append("	      A.DEFAULT_YN,                                 ");
		sql.append("	      A.SPECIMEN_CODE,                              ");
		sql.append("	      B.SPECIMEN_NAME,                              ");
		sql.append("	      A.SEQ                                         ");
		sql.append("	 FROM OCS0106 A,                                    ");
		sql.append("	      OCS0116 B                                     ");
		sql.append("	WHERE A.SPECIMEN_CODE = B.SPECIMEN_CODE             ");
		sql.append("	  AND A.SLIP_CODE     = :slipCode                	");
		sql.append("	  AND B.HOSP_CODE     = :hospCode                	");
		sql.append("	ORDER BY A.SEQ                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("slipCode", slipCode);
		
		List<OCS0101U00GrdOcs0106ListItemInfo> list = new JpaResultMapper().list(query, OCS0101U00GrdOcs0106ListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS0101U00Grd0106CheckData(String hospCode, String slipCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'              			");
		sql.append("	  FROM OCS0103                      ");
		sql.append("	 WHERE SLIP_CODE = :slipCode        ");
		sql.append("	   AND HOSP_CODE  = :hospCode    ");
		sql.append("	   LIMIT 1                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("slipCode", slipCode);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<XRT1002U00GrdComment3Info> getXRT1002U00GrdComment3Info(String hospCode, String bunho, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.COMMENTS                                                ");
		sql.append("     , '1'                                                       ");
		sql.append("     , A.SER                                                     ");
		sql.append("  FROM OUT0106 A                                                 ");
		sql.append("     , OCS1003 B                                                 ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                             ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE                              ");
		sql.append("   AND A.BUNHO        = :f_bunho                                 ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                                      ");
		sql.append("   AND A.JUNDAL_TABLE = 'XRT'                                    ");
		sql.append("   AND A.IN_OUT_GUBUN = 'O'                                      ");
		sql.append("   AND A.FKOCS        = B.PKOCS1003                              ");
		sql.append("   AND DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d')   = :f_order_date    ");
		sql.append(" UNION                                                           ");
		sql.append("SELECT A.COMMENTS                                                ");
		sql.append("     , '2'                                                       ");
		sql.append("     , A.SER                                                     ");
		sql.append("  FROM OUT0106 A                                                 ");
		sql.append("     , OCS2003 B                                                 ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                             ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE                              ");
		sql.append("   AND A.BUNHO        = :f_bunho                                 ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                                      ");
		sql.append("   AND A.JUNDAL_TABLE = 'XRT'                                    ");
		sql.append("   AND A.IN_OUT_GUBUN = 'I'                                      ");
		sql.append("   AND A.FKOCS        = B.PKOCS2003                              ");
		sql.append("   AND DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d')   = :f_order_date    ");
		sql.append(" ORDER BY 2, 3;                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		
		List<XRT1002U00GrdComment3Info> list = new JpaResultMapper().list(query, XRT1002U00GrdComment3Info.class);
		return list;
	}
}

