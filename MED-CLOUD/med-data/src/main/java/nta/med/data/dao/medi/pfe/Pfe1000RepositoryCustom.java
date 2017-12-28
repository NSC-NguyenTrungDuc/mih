package nta.med.data.dao.medi.pfe;

import java.util.List;

import nta.med.data.model.ihis.endo.END1001U02DsvDwInfo;

/**
 * @author dainguyen.
 */
public interface Pfe1000RepositoryCustom {
	public List<END1001U02DsvDwInfo> getEND1001U02DsvDwInfo(String hospCode, Double fkocs);
	public Double getMaxPKPFE1000ByHospCode(String hospCode); 
}

