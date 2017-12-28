package nta.med.data.model.ihis.orca;

public class ORCATransferOrdersLstSgCodeInfo {
	private String hangmogCode ;
	private String hangmogName ;
	private String sgCode      ;
	public ORCATransferOrdersLstSgCodeInfo(String hangmogCode,
			String hangmogName, String sgCode) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.sgCode = sgCode;
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
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}        
	
}
