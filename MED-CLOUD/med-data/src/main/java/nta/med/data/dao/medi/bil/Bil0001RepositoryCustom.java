package nta.med.data.dao.medi.bil;

import nta.med.data.model.ihis.bill.BIL2016U00DetailServiceInfo;
import nta.med.data.model.ihis.bill.BIL2016U00ServiceInfo;

import java.util.List;

public interface Bil0001RepositoryCustom {
	
	public List<BIL2016U00DetailServiceInfo> findByHangMogCodeAndCodeTypeAndHangMogCode(String hospCode, String codeType, String hangMogCode);
	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfoCaseVisitFee(String hospCode, String language, String codeName, Integer pageNumber, Integer offset);
	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfoCaseSearchAll(String hospCode, String hangmogNameInx, String orderGubun, String codeType, String language, Integer pageNumber, Integer offset);
}
