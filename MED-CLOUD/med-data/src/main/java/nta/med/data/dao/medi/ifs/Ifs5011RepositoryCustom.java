package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANSSangSendAllInfo;

/**
 * @author dainguyen.
 */
public interface Ifs5011RepositoryCustom {
	public List<ORDERTRANSSangSendAllInfo> getORDERTRANSSangSendAllInfo(String hospCode);
}

