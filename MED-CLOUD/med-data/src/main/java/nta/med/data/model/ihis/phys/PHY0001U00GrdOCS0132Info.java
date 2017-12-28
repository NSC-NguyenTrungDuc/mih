package nta.med.data.model.ihis.phys;

public class PHY0001U00GrdOCS0132Info {
	private String code;
    private String codeName;
    private String codeType;
    private String ment;
	public PHY0001U00GrdOCS0132Info(String code, String codeName,
			String codeType, String ment) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.codeType = codeType;
		this.ment = ment;
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
	public String getMent() {
		return ment;
	}
	public void setMent(String ment) {
		this.ment = ment;
	}
}
