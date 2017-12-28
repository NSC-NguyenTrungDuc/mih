package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;

/**
 * @author dainguyen.
 */
public interface Out1007RepositoryCustom {
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseEqualOAndElse(String hospCode, String bunho, Double out1001, String language);
}

