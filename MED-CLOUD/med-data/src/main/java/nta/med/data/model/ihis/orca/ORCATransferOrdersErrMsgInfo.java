package nta.med.data.model.ihis.orca;

public class ORCATransferOrdersErrMsgInfo {
	private String hangmogCode ;
	private String hangmogName ;
	private String errCode      ;
	public ORCATransferOrdersErrMsgInfo(String hangmogCode, String hangmogName,
			String errCode) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.errCode = errCode;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getErrCode() {
		return errCode;
	}
	public void setErrCode(String errCode) {
		this.errCode = errCode;
	} 

}
