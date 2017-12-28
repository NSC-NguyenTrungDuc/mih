package nta.med.data.model.ihis.cpls;

public class Cpl3020U02ResultMapGrdRsltInfo {
	private String resultCode;
	private String hangmogCode;
	private String gumsaName;
	private String resultVal;

	public Cpl3020U02ResultMapGrdRsltInfo(String resultCode,
			String hangmogCode, String gumsaName, String resultVal) {
		super();
		this.resultCode = resultCode;
		this.hangmogCode = hangmogCode;
		this.gumsaName = gumsaName;
		this.resultVal = resultVal;
	}

	public String getResultCode() {
		return resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
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

	public String getResultVal() {
		return resultVal;
	}

	public void setResultVal(String resultVal) {
		this.resultVal = resultVal;
	}

}
