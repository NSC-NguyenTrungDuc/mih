package nta.med.data.dao.medi.inp;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListNonSendYnInfo;

/**
 * @author dainguyen.
 */
public interface Inp3010RepositoryCustom {
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase0ElseElse(String hospCode, String language, String ioGubun, String sendYn, String bunho);
}

