package nta.med.data.model.ihis.cpls;

public class CPL0108U00InitGrdDetailListItemInfo {
	private String codeType;
	private String code;
	private String codeName;
	private String codeNameRe;
	private String systemGubun;
	private String codeValue;

	public CPL0108U00InitGrdDetailListItemInfo(String codeType, String code,
			String codeName, String codeNameRe, String systemGubun,
			String codeValue) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.codeNameRe = codeNameRe;
		this.systemGubun = systemGubun;
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

	public String getSystemGubun() {
		return systemGubun;
	}

	public void setSystemGubun(String systemGubun) {
		this.systemGubun = systemGubun;
	}

	public String getCodeValue() {
		return codeValue;
	}

	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}

}
