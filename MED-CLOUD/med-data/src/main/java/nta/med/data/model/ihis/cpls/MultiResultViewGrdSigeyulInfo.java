package nta.med.data.model.ihis.cpls;

public class MultiResultViewGrdSigeyulInfo {
	private String bunho;
    private String hangmogCode;
    private String gumsaName;
	public MultiResultViewGrdSigeyulInfo(String bunho, String hangmogCode,
			String gumsaName) {
		super();
		this.bunho = bunho;
		this.hangmogCode = hangmogCode;
		this.gumsaName = gumsaName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getGumsaName() {
		return gumsaName;
	}
	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}
}
