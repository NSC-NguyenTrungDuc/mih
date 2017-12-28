package nta.med.data.model.ihis.nuro;

public class ORDERTRANSAPIHangmogInfo {

	private String hangmogCode;
	private String hangmogName;

	public ORDERTRANSAPIHangmogInfo(String hangmogCode, String hangmogName) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
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
