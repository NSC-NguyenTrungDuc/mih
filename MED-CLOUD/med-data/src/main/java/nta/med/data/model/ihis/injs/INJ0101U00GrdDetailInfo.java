package nta.med.data.model.ihis.injs;

public class INJ0101U00GrdDetailInfo {
	private String codeType;
	private String code;
	private String codeName;
	private String rowState;
	public INJ0101U00GrdDetailInfo(String codeType, String code, String codeName) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
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
}
