package nta.med.data.dao.medi.inp;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;

/**
 * @author dainguyen.
 */
public interface Inp3018RepositoryCustom {
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseElseElse(String hospCode, Double pkout, String language);
}

