package nta.med.data.model.ihis.ocsa;

public class OCS0311U00grdHangmogCodeListInfo {
	private String setPart ;
	private String hangmogCode ;
	private String hangmogName ;
	public OCS0311U00grdHangmogCodeListInfo(String setPart, String hangmogCode,
			String hangmogName) {
		super();
		this.setPart = setPart;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
	}
	public String getSetPart() {
		return setPart;
	}
	public void setSetPart(String setPart) {
		this.setPart = setPart;
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
	
}
