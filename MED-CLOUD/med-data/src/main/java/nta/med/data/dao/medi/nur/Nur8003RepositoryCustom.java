package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR8003Q00grdNur8003Info;
import nta.med.data.model.ihis.nuri.NUR8003Q00grdWritedInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03CopyDataInfo;

/**
 * @author dainguyen.
 */
public interface Nur8003RepositoryCustom {

	public List<NUR8003Q00grdWritedInfo> getNUR8003Q00grdWritedInfo1(String hospCode, String date, String hoDong);

	public List<NUR8003Q00grdWritedInfo> getNUR8003Q00grdWritedInfo2(String hospCode, String date, String hoDong);

	public List<NUR8003Q00grdNur8003Info> getNUR8003Q00grdNur8003Info(String hospCode, String queryDate, String hoDong);

	public List<NUR8003R02grdMasterInfo> getNUR8003R02grdMasterInfo(String hospCode, String fromDate, String toDate,
			String hoDong, String needHType, String bunho, String language);

	public List<NUR8003U03CopyDataInfo> getNUR8003U03CopyDataInfo(String hospCode, String bunho, Date writeDate);
}
