package nta.med.data.model.ihis.ocsi;

public class OCS2005U02SetTabInfo {
	private Double pkocs2005;
	private String drtFromDate;
	private String drtToDate;
	private String sikaGubun;
	private String rownum;
	private String msg;
	public OCS2005U02SetTabInfo(Double pkocs2005, String drtFromDate, String drtToDate, String sikaGubun, String rownum,
			String msg) {
		super();
		this.pkocs2005 = pkocs2005;
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
		this.sikaGubun = sikaGubun;
		this.rownum = rownum;
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
	public String getSikaGubun() {
		return sikaGubun;
	}
	public void setSikaGubun(String sikaGubun) {
		this.sikaGubun = sikaGubun;
	}
	public String getRownum() {
		return rownum;
	}
	public void setRownum(String rownum) {
		this.rownum = rownum;
	}
	public String getMsg() {
		return msg;
	}
	public void setMsg(String msg) {
		this.msg = msg;
	}
	
	
	
}
