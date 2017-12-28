package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;


import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0002RepositoryCustom;
import nta.med.data.model.ihis.xrts.XRT0001U00GrdRadioListInfo;

/**
 * @author dainguyen.
 */
public class Xrt0002RepositoryImpl implements Xrt0002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<XRT0001U00GrdRadioListInfo> getXRT0001U00GrdRadioListItemInfo(String hospCode, String xrayCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.XRAY_CODE                                   ");
		sql.append("      , A.XRAY_GUBUN                                  ");
		sql.append("      , A.XRAY_CODE_IDX                               ");
		sql.append("      , A.XRAY_CODE_IDX_NM                            ");
		sql.append("      , A.TUBE_VOL                                    ");
		sql.append("      , A.TUBE_CUR                                    ");
		sql.append("      , A.XRAY_TIME                                   ");
		sql.append("      , A.TUBE_CUR_TIME                               ");
		sql.append("      , A.IRRADIATION_TIME                            ");
		sql.append("      , A.XRAY_DISTANCE                               ");
		sql.append("   FROM XRT0002 A                                     ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                    ");
		sql.append("    AND A.XRAY_CODE = :f_xray_code                    ");
		sql.append("  ORDER BY A.XRAY_GUBUN, A.XRAY_CODE, A.XRAY_CODE_IDX ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_xray_code", xrayCode);
		List<XRT0001U00GrdRadioListInfo> listGrd= new JpaResultMapper().list(query, XRT0001U00GrdRadioListInfo.class);
		return listGrd;
	}
}

