package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.invs.INV6000U00GrdINV6001Info;
import nta.med.data.model.ihis.invs.INV6000U00LayINV6000Info;
import nta.med.data.model.ihis.invs.INV6000U00LaySummaryDetailInfo;

public interface Inv6000RepositoryCustom {
	public List<INV6000U00GrdINV6001Info> getINV6000U00GrdINV6001Info(String hospCode, String language, Double fkinv6000, String jaeryoCode, String startNum, String offset, String difference);
	public List<INV6000U00LaySummaryDetailInfo> getINV6000U00LaySummaryDetailInfo(String hospCode, String language, String magamMonth);
	public List<INV6000U00LayINV6000Info> getINV6000U00LayINV6000Info(String hospCode, String month);
	public ComboListItemInfo callPrInvMakeStockCounts(String hospCode, String proc, String month, String userId, String inputUser, Date inputDate, String remark);
}
