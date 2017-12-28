package nta.med.data.model.ihis.ocsi;

public class OCS1024U00xEditGridCell20Info {
	private String code ;
	private String codeName ;
	private String codeType;
	public OCS1024U00xEditGridCell20Info(String code, String codeName, String codeType) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.codeType = codeType;
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
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
	
}
