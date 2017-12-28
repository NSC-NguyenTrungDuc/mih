package nta.med.data.model.ihis.system;

public class LayConstantInfo {
	private String code ;
	private String codeName ;
	private String codeValue ;
	public LayConstantInfo(String code, String codeName, String codeValue) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.codeValue = codeValue;
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
	public String getCodeValue() {
		return codeValue;
	}
	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}
}
