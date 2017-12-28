package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayGongbiCodeInfo;

/**
 * @author dainguyen.
 */
public interface Out1002RepositoryCustom {
	public boolean deletePatientInsuranceInfo(String hospitalCode, String pkout1001);
	
	public List<NuroOUT1001U01LayGongbiCodeInfo> getNuroOUT1001U01LayGongbiCode(String hospCode, Double pkout1001);
}

