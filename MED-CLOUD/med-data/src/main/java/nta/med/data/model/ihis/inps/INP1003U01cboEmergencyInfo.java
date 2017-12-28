package nta.med.data.model.ihis.inps;

public class INP1003U01cboEmergencyInfo {
	
	private String code;
	private String codeName;
	private String number;
	
	public INP1003U01cboEmergencyInfo(String code, String codeName, String number){
		this.code = code;
		this.codeName = codeName;
		this.number = number;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getNumber() {
		return number;
	}

	public void setNumber(String number) {
		this.number = number;
	}
	
	
}
