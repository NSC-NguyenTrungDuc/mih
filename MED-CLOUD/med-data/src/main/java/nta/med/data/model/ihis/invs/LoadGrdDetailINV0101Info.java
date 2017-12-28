package nta.med.data.model.ihis.invs;

public class LoadGrdDetailINV0101Info {

	private String codeType;
	private String code;
	private String codeName;
	private String sortKey;
	private String code2;
	private String code3;
	private String remark;

	public LoadGrdDetailINV0101Info(String codeType, String code, String codeName, String sortKey, String code2,
			String code3, String remark) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
		this.code2 = code2;
		this.code3 = code3;
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

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

	public String getCode2() {
		return code2;
	}

	public void setCode2(String code2) {
		this.code2 = code2;
	}

	public String getCode3() {
		return code3;
	}

	public void setCode3(String code3) {
		this.code3 = code3;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

}
