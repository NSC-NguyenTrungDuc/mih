package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0805Info;

public interface Nur0805RepositoryCustom {

	public List<NUR0803U01grdNUR0805Info> getNUR0803U01grdNUR0805Info(String hospCode, String needGubun,
			String needAsmtCode, String needResultCode, Date startDate);

}
