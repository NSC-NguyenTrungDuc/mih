package nta.med.data.dao.medi.bil;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bill.BIL2016R01GrdReportInfo;
import nta.med.data.model.ihis.bill.BIL2016R01GrdReportPaidDisCountInfo;

public interface Bil0102RepositoryCustom {

	public List<BIL2016R01GrdReportInfo> getGrdReportList(String hospCode, String language, Date fromDate, Date toDate,
			String assignDept, String assignDoctor, String exeDept, String exeDoctor, String serviceId, String personId,
			Integer startNum, Integer offset);
	
	public List<BIL2016R01GrdReportPaidDisCountInfo> getBIL2016R01GrdReportPaidDisCountInfo(String hospCode, String language, Date fromDate, Date toDate,
			String assignDept, String assignDoctor, String exeDept, String exeDoctor, String serviceId, String personId,
			Integer startNum, Integer offset);
}
