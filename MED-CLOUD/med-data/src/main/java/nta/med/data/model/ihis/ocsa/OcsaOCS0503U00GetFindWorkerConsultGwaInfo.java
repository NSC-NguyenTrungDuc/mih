package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0503U00GetFindWorkerConsultGwaInfo {
	private String hangmogCode;
	private String hangmogName;
	public OcsaOCS0503U00GetFindWorkerConsultGwaInfo(String hangmogCode,
			String hangmogName) {
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