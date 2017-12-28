package nta.med.data.dao.medi.orca;

import java.util.List;

import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimExaminationFeeInfo;

public interface OrcaReceptionRepositotyCustom {
	public List<ORCATransferOrdersClaimExaminationFeeInfo> getORCATransferOrdersClaimExaminationFeeInfo(String hospCode, Double pkout1001);
}
