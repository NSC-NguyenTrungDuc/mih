package nta.med.data.model.ihis.ocsi;

public class OCS2004U00DupCheckInfo {
    private String drtFromDate;
    private String drtToDate;
    private String nurGrName;
    private String nurMdName;
    private String directGubun;
    private String directCode;
	public OCS2004U00DupCheckInfo(String drtFromDate, String drtToDate, String nurGrName, String nurMdName,
			String directGubun, String directCode) {
		super();
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
		this.nurGrName = nurGrName;
		this.nurMdName = nurMdName;
		this.directGubun = directGubun;
		this.directCode = directCode;
	}
	public String getDrtFromDate() {
		return drtFromDate;
	}
	public void setDrtFromDate(String drtFromDate) {
		this.drtFromDate = drtFromDate;
	}
	public String getDrtToDate() {
		return drtToDate;
	}
	public void setDrtToDate(String drtToDate) {
		this.drtToDate = drtToDate;
	}
	public String getNurGrName() {
		return nurGrName;
	}
	public void setNurGrName(String nurGrName) {
		this.nurGrName = nurGrName;
	}
	public String getNurMdName() {
		return nurMdName;
	}
	public void setNurMdName(String nurMdName) {
		this.nurMdName = nurMdName;
	}
	public String getDirectGubun() {
		return directGubun;
	}
	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}
	public String getDirectCode() {
		return directCode;
	}
	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}
    
}
