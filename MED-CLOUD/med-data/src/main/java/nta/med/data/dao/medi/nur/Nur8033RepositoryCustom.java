package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR8003U03GrdAInfo;

public interface Nur8033RepositoryCustom {

	public List<NUR8003U03GrdAInfo> getNUR8003U03GrdAInfo(String hospCode, String bunho, Date writeDate, String hoDong,
			String needGubun, String migrationDisp);

}
