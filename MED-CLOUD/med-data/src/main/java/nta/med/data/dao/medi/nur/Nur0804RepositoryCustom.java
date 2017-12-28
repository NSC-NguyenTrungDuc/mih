package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0804Info;

public interface Nur0804RepositoryCustom {

	public List<NUR0803U01grdNUR0804Info> getNUR0803U01grdNUR0804Info(String hospCode, String needGubun,
			String needAsmtCode, Date startDate);
}
