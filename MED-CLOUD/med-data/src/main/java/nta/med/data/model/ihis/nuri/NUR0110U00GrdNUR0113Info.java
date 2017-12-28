package nta.med.data.model.ihis.nuri;

public class NUR0110U00GrdNUR0113Info {

	private String nurGrCode;
	private String nurMdCode;
	private String nurActCode;
	private String nurActName;
	private String sortKey;
	private String ment;
	private String vald;

	public NUR0110U00GrdNUR0113Info(String nurGrCode, String nurMdCode, String nurActCode, String nurActName,
			String sortKey, String ment, String vald) {
		super();
		this.nurGrCode = nurGrCode;
		this.nurMdCode = nurMdCode;
		this.nurActCode = nurActCode;
		this.nurActName = nurActName;
		this.sortKey = sortKey;
		this.ment = ment;
		this.vald = vald;
	}

	public String getNurGrCode() {
		return nurGrCode;
	}

	public void setNurGrCode(String nurGrCode) {
		this.nurGrCode = nurGrCode;
	}

	public String getNurMdCode() {
		return nurMdCode;
	}

	public void setNurMdCode(String nurMdCode) {
		this.nurMdCode = nurMdCode;
	}

	public String getNurActCode() {
		return nurActCode;
	}

	public void setNurActCode(String nurActCode) {
		this.nurActCode = nurActCode;
	}

	public String getNurActName() {
		return nurActName;
	}

	public void setNurActName(String nurActName) {
		this.nurActName = nurActName;
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

	public String getVald() {
		return vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}
