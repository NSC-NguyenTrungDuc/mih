package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANOrderTransInfo;

/**
 * @author dainguyen.
 */
public interface Ifs1004RepositoryCustom {
	
	public List<ORDERTRANOrderTransInfo> getORDERTRANOrderTransInfo (String hospCode, String fkout1003, String transGubun);

	public String callPrIfsOrderProcMain(String hospCode, String ioGubun, Integer masterFk, String sendYn);

}

