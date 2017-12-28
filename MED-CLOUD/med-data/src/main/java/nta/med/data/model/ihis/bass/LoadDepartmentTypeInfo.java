package nta.med.data.model.ihis.bass;

public class LoadDepartmentTypeInfo {
	private String code;
	private String codeType;
	private String hospCode;
	private String codeName;
	
	public LoadDepartmentTypeInfo(String code, String codeType, String hospCode, String codeName) {
		super();
		this.code = code;
		this.codeType = codeType;
		this.hospCode = hospCode;
		this.codeName = codeName;
	}
	
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	
}
