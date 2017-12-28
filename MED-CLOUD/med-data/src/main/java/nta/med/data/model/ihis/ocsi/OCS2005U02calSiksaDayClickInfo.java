package nta.med.data.model.ihis.ocsi;

public class OCS2005U02calSiksaDayClickInfo {

	private Double pkocs2005;
	private String drtFromDate;
	private String drtToDate;
	private String nutDate;
	private String bldGubun;
	private Double fkinp1001;
	private String msg;
	
	public OCS2005U02calSiksaDayClickInfo(Double pkocs2005, String drtFromDate, String drtToDate, String nutDate, String bldGubun, Double fkinp1001, String msg){
		this.pkocs2005 = pkocs2005;
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
		this.nutDate = nutDate;
		this.bldGubun = bldGubun;
		this.fkinp1001 = fkinp1001;
		this.msg = msg;
	}

	public Double getPkocs2005() {
		return pkocs2005;
	}

	public void setPkocs2005(Double pkocs2005) {
		this.pkocs2005 = pkocs2005;
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

	public String getNutDate() {
		return nutDate;
	}

	public void setNutDate(String nutDate) {
		this.nutDate = nutDate;
	}

	public String getBldGubun() {
		return bldGubun;
	}

	public void setBldGubun(String bldGubun) {
		this.bldGubun = bldGubun;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getMsg() {
		return msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}
	
}
