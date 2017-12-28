package nta.med.data.dao.medi.nur;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Nur5200RepositoryCustom {

	public void callPrNurNur5200SubDelete(String hospCode, String hoDong, String nurWrdt);

	public String getNUR5020U00layConfirmYn(String hospCode, Date fDate, String hoDong);
}
