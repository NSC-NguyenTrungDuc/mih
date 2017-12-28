package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0803Info;
import nta.med.data.model.ihis.nuri.NUR0812U00GrdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03LayNurPointsInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03SetFindWorkerInfo;

public interface Nur0803RepositoryCustom {

	public List<NUR0812U00GrdDetailInfo> getNUR0812U00GrdDetailInfo(String hospCode, String language, String codeType,
			String needHType, Integer startNum, Integer offset);

	public List<NUR0803U01grdNUR0803Info> getNUR0803U01grdNUR0803Info(String hospCode, String needGubun, String hfile,
			String enable);

	public Integer updateByHospCodeNeedGubunNeedAsmtCodeStartDate(String userId, String needAsmtName, String globalYn,
			Date endDate, Double sortKey, String hospCode, String needGubun, String needAsmtCode, Date startDate);

	public Integer deleteByHospCodeNeedGubunNeedAsmtCodeStartDate(String hospCode, String needGubun,
			String needAsmtCode, Date startDate);

	public List<NUR8003U03LayNurPointsInfo> getNUR8003U03LayNurPointsInfo(String hospCode, String bunho,
			String startDate, Date queryDate);

	public List<NUR8003U03SetFindWorkerInfo> getNUR8003U03SetFindWorkerInfo(String hospCode, String needGubun,
			String needAsmtCode, Date startDate, String needResultCode);
}
