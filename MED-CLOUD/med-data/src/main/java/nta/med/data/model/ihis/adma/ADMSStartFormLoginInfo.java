package nta.med.data.model.ihis.adma;

public class ADMSStartFormLoginInfo {
	private String grpId;
	private String grpNm;
	private String sysId;
	private String sysNm;
	private String dispGrpId;
	public ADMSStartFormLoginInfo(String grpId, String grpNm, String sysId,
			String sysNm, String dispGrpId) {
		super();
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.sysId = sysId;
		this.sysNm = sysNm;
		this.dispGrpId = dispGrpId;
	}
	public String getGrpId() {
		return grpId;
	}
	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}
	public String getGrpNm() {
		return grpNm;
	}
	public void setGrpNm(String grpNm) {
		this.grpNm = grpNm;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getSysNm() {
		return sysNm;
	}
	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}
	public String getDispGrpId() {
		return dispGrpId;
	}
	public void setDispGrpId(String dispGrpId) {
		this.dispGrpId = dispGrpId;
	}
	
	
}
