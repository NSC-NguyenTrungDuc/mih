package nta.med.data.model.ihis.drgs;

public class Drg0102U01GrdDetailItemInfo {
	private String codeType;
	private String code;
	private String code2;
	private String codeName;
	private String codeValue;
	private String remark;

	public Drg0102U01GrdDetailItemInfo(String codeType, String code,
			String code2, String codeName, String codeValue, String remark) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.code2 = code2;
		this.codeName = codeName;
		this.codeValue = codeValue;
		this.remark = remark;
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

	public String getCode2() {
		return code2;
	}

	public void setCode2(String code2) {
		this.code2 = code2;
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

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

}
