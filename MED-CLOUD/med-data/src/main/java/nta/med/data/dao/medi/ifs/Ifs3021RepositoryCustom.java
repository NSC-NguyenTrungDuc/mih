package nta.med.data.dao.medi.ifs;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Ifs3021RepositoryCustom {
	public String callPrIfsSikaInputTest(String hospCode, String bunho, Date fromDate, Integer fromSik, Date toDate, Integer toSik);
}

