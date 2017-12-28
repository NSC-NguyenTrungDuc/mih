package nta.med.data.dao.medi.clis;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.clis.CLIS2015U02GrdProtocolInfo;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.data.model.ihis.clis.CLIS2015U04GetProtocolItemInfo;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface ClisProtocolRepositoryCustom {

	public List<CLIS2015U02GrdProtocolInfo> getCLIS2015U02GrdProtocolInfo(String hospCode, Integer clisSmoId, String bunho, String protocolCode,
			String protocolName, String status, Date startDate, Date endDate);
	public List<CLIS2015U03ProtocolListInfo> getCLIS2015U03ProtocolListInfo(String hospCode, String userId);
	public List<CLIS2015U04GetProtocolItemInfo> getCLIS2015U04ProtocolListItemInfo(Integer clisSmoId);
	public List<CLIS2015U04GetProtocolItemInfo> getCLIS2015U04GetProtocolListByPatientItem(String bunho);
	public List<ComboListItemInfo> getOCS0103U00GetProtocolInfo(String hospCode, String protoCode);
	public CLIS2015U03ProtocolListInfo getOCS0103U00GetNameProtocolInfo(String hospCode, String protoCode);
	
	public BigInteger getClis2015U09CheckSmoCodeOnDelete(String hospCode, String clisSmoId);

}
