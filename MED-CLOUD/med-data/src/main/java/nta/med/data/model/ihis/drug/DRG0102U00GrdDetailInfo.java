package nta.med.data.model.ihis.drug;

public class DRG0102U00GrdDetailInfo {
	private String codeType;
    private String code;
    private String codeName;
    private String codeValue;
	public DRG0102U00GrdDetailInfo(String codeType, String code,
			String codeName, String codeValue) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.codeValue = codeValue;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
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
	public String getCodeValue() {
		return codeValue;
	}
	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}
}
