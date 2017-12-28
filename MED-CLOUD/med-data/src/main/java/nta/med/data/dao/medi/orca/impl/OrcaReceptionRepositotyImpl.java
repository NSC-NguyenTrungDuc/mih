package nta.med.data.dao.medi.orca.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.orca.OrcaReceptionRepositotyCustom;
import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimExaminationFeeInfo;

public class OrcaReceptionRepositotyImpl implements OrcaReceptionRepositotyCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ORCATransferOrdersClaimExaminationFeeInfo> getORCATransferOrdersClaimExaminationFeeInfo(String hospCode, Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  IO_FLAG                IO_FLAG       ,     ");
		sql.append("         TIME_CLASS        CLASS_TIME    ,          ");
		sql.append("         BUND_NUM                BUNDLE_NUMBER ,    ");
		sql.append("         CLASS_CODE        CLASS_CODE    ,          ");
		sql.append("         SUB_CODE                SUBCLASS_CODE ,    ");
		sql.append("         ACT_CODE                HANGMOG_CODE       ");
		sql.append(" FROM  ORCA_RECEPTION                               ");
		sql.append(" WHERE HOSP_CODE   =   :f_hosp_code                 ");
		sql.append(" AND FKOUT1001   =   :f_pkout1001                   ");
		sql.append(" ORDER BY CLASS_CODE								");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkout1001", pkout1001);
		List<ORCATransferOrdersClaimExaminationFeeInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersClaimExaminationFeeInfo.class);
		return list;
	}
}
