package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.invs.INV4001U00ExportCSVInfo;

import nta.med.data.model.ihis.invs.INV4001U00ExportInfo;

import nta.med.data.model.ihis.invs.INV4001U00Grd4001Info;

public interface Inv4001RepositoryCustom {
	public List<INV4001U00Grd4001Info> getINV4001U00Grd4001Info(String hospCode, Date fromDate, Date toDate, String ipgoType);

	public List<INV4001U00ExportCSVInfo> getINV4001U00ExportCSVInfo(String hospCode, Date fromDate, Date toDate, String language);

	public List<INV4001U00ExportInfo> getINV4001U00ExportInfo(String hospCode, String language, Date fromDate, Date toDate);

}
