package nta.med.orca.gw.service.order;

import java.util.List;

public interface OrderAdministrator {

	public boolean updatePaidOrder(String hospCode, String receptionDate, List<String> refIdList);
}
