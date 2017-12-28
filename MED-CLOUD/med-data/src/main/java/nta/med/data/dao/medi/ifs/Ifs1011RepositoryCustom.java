package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANSangTransInfo;

/**
 * @author dainguyen.
 */
public interface Ifs1011RepositoryCustom {
	public List<ORDERTRANSangTransInfo> getORDERTRANSangTransInfo(String hospCode, String fkout1003);
}

