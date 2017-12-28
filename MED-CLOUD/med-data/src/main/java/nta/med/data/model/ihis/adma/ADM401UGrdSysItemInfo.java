package nta.med.data.model.ihis.adma;

public class ADM401UGrdSysItemInfo {
	private String sysId ;
	private String sysNm ;
	private String admSysYn ;
	private String msgSysYn ;
	public ADM401UGrdSysItemInfo(String sysId, String sysNm, String admSysYn,
			String msgSysYn) {
		super();
		this.sysId = sysId;
		this.sysNm = sysNm;
		this.admSysYn = admSysYn;
		this.msgSysYn = msgSysYn;
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
	public String getAdmSysYn() {
		return admSysYn;
	}
	public void setAdmSysYn(String admSysYn) {
		this.admSysYn = admSysYn;
	}
	public String getMsgSysYn() {
		return msgSysYn;
	}
	public void setMsgSysYn(String msgSysYn) {
		this.msgSysYn = msgSysYn;
	}
	
}
