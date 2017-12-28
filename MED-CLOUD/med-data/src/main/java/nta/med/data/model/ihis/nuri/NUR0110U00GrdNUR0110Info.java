package nta.med.data.model.ihis.nuri;

public class NUR0110U00GrdNUR0110Info {

	private String nurGrCode;
	private String nurGrName;
	private String vald;
	private String sortKey;
	private String ment;

	public NUR0110U00GrdNUR0110Info(String nurGrCode, String nurGrName, String vald, String sortKey, String ment) {
		super();
		this.nurGrCode = nurGrCode;
		this.nurGrName = nurGrName;
		this.vald = vald;
		this.sortKey = sortKey;
		this.ment = ment;
	}

	public String getNurGrCode() {
		return nurGrCode;
	}

	public void setNurGrCode(String nurGrCode) {
		this.nurGrCode = nurGrCode;
	}

	public String getNurGrName() {
		return nurGrName;
	}

	public void setNurGrName(String nurGrName) {
		this.nurGrName = nurGrName;
	}

	public String getVald() {
		return vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

	public String getMent() {
		return ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

}
