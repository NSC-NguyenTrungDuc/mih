package nta.med.data.model.ihis.ocsi;

public class OCS2004U00layTabItemInfo {
    private String code;
    private String codeName;
    private String number;
	public OCS2004U00layTabItemInfo(String code, String codeName, String number) {
		super();
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
