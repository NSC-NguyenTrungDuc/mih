package nta.med.data.model.ihis.ocsi;

public class OCS2005U00grdNur0112Info {
	private String nurSoCode ;
	private String nurSoName ;
	private String nurGrCode ;
	private String nurMdCode ;
	public OCS2005U00grdNur0112Info(String nurSoCode, String nurSoName, String nurGrCode, String nurMdCode) {
		super();
		this.nurSoCode = nurSoCode;
		this.nurSoName = nurSoName;
		this.nurGrCode = nurGrCode;
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
	
}
