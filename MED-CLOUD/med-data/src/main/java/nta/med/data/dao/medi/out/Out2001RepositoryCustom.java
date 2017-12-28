package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public interface Out2001RepositoryCustom {

	public String callPrOutCreateOut2001Temp(String hospCode, Integer pkOcs, String userId);

	public List<String> callPrOutMakeOrderDataOut(String hospCode, String language,
			String bunho, Date kaikeiDate, Integer pkOcs, String docUid,
			String insureUid, String orderUid, String sangUid, String doctor,
			String userId);
}

