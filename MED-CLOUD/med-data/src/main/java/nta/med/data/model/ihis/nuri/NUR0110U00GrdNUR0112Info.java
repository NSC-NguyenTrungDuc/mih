package nta.med.data.model.ihis.nuri;

public class NUR0110U00GrdNUR0112Info {

	private String nurGrCode;
	private String nurMdCode;
	private String nurSoCode;
	private String nurSoName;
	private String sortKey;
	private String ment;
	private String vald;

	public NUR0110U00GrdNUR0112Info(String nurGrCode, String nurMdCode, String nurSoCode, String nurSoName,
			String sortKey, String ment, String vald) {
		super();
		this.nurGrCode = nurGrCode;
		this.nurMdCode = nurMdCode;
		this.nurSoCode = nurSoCode;
		this.nurSoName = nurSoName;
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

	public String getNurSoCode() {
		return nurSoCode;
	}

	public void setNurSoCode(String nurSoCode) {
		this.nurSoCode = nurSoCode;
	}

	public String getNurSoName() {
		return nurSoName;
	}

	public void setNurSoName(String nurSoName) {
		this.nurSoName = nurSoName;
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
