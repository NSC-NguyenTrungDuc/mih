package nta.med.data.model.ihis.cpls;

public class CplsCPL2010U00MlayConstantCPL2010ListItemInfo {
	private String code ;
	private String codeName ;
	private String codeValue ;
	public CplsCPL2010U00MlayConstantCPL2010ListItemInfo(String code,
			String codeName, String codeValue) {
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
