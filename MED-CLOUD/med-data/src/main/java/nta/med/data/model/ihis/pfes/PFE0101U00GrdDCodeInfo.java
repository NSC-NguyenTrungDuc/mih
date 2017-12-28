package nta.med.data.model.ihis.pfes;

public class PFE0101U00GrdDCodeInfo {
    private String codeType    ;
    private String code         ;
    private String codeName    ;
    private String codeNameRe ;
    private String codeValue   ;
	public PFE0101U00GrdDCodeInfo(String codeType, String code,
			String codeName, String codeNameRe, String codeValue) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.codeNameRe = codeNameRe;
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
	public String getCodeNameRe() {
		return codeNameRe;
	}
	public void setCodeNameRe(String codeNameRe) {
		this.codeNameRe = codeNameRe;
	}
	public String getCodeValue() {
		return codeValue;
	}
	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}
    

}
