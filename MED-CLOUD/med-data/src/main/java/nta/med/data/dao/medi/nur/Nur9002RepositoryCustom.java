package nta.med.data.dao.medi.nur;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface Nur9002RepositoryCustom {

	public List<String> getNUR1020Q00layFlagInfo(String hospCode, String bunho, String startDate);

	public String callFnNurMergeRemark(String hospCode, String bunho, String iDate);

}
