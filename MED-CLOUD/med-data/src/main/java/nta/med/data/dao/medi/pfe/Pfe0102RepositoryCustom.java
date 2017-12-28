package nta.med.data.dao.medi.pfe;

import java.util.List;

import nta.med.data.model.ihis.endo.END1001U02GrdPurposeInfo;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdDCodeInfo;
import nta.med.data.model.ihis.system.LayConstantInfo;

/**
 * @author dainguyen.
 */
public interface Pfe0102RepositoryCustom {
	public List<PFE0101U00GrdDCodeInfo> getPFE0101U00GrdDCodeInfo(String hospCode,String codeType,String code,String codeName, String language);
	public List<LayConstantInfo> getOCSACTLayconstant(String hospCode,String codeType, String language);
	public List<END1001U02GrdPurposeInfo> getEND1001U02GrdPurposeInfo(String hospCode, String language);
}

