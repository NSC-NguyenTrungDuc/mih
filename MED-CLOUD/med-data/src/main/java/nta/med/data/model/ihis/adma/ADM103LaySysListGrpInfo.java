package nta.med.data.model.ihis.adma;

public class ADM103LaySysListGrpInfo {
    private String sysId;
    private String sysNm;
	public ADM103LaySysListGrpInfo(String sysId, String sysNm) {
		super();
		this.sysId = sysId;
		this.sysNm = sysNm;
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
    
}
