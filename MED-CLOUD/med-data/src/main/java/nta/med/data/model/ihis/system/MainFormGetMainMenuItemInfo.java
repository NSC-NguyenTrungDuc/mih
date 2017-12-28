package nta.med.data.model.ihis.system;

public class MainFormGetMainMenuItemInfo {
	private String grpId       ;
	private String grpNm       ;
	private String sysId       ;
	private String sysNm       ;
	private String dispGrpId  ;
	private String dispGrpNm  ;
	private String sysDesc     ;
	public MainFormGetMainMenuItemInfo(String grpId, String grpNm,
			String sysId, String sysNm, String dispGrpId, String dispGrpNm,
			String sysDesc) {
		super();
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.sysId = sysId;
		this.sysNm = sysNm;
		this.dispGrpId = dispGrpId;
		this.dispGrpNm = dispGrpNm;
		this.sysDesc = sysDesc;
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
	public String getDispGrpNm() {
		return dispGrpNm;
	}
	public void setDispGrpNm(String dispGrpNm) {
		this.dispGrpNm = dispGrpNm;
	}
	public String getSysDesc() {
		return sysDesc;
	}
	public void setSysDesc(String sysDesc) {
		this.sysDesc = sysDesc;
	}
	
}
