package nta.med.data.model.ihis.injs;

public class InjsComboListItemInfo {
	private String code;
    private String codeName;
	public InjsComboListItemInfo(String code, String codeName) {
		super();
		this.code = code;
		this.codeName = codeName;
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
}
