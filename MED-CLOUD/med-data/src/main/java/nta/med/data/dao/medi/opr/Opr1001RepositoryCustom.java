package nta.med.data.dao.medi.opr;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1020Q00laySusulInfoInfo;

/**
 * @author dainguyen.
 */
public interface Opr1001RepositoryCustom {

	public List<NUR1020Q00laySusulInfoInfo> getNUR1020Q00laySusulInfoInfo(String hospCode, String language,
			String bunho, Double fkinp1001, String fromOpDate, String toOpDate);

}
