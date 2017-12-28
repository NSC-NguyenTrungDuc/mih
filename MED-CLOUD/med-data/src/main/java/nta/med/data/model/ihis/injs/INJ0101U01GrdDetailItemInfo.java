package nta.med.data.model.ihis.injs;

public class INJ0101U01GrdDetailItemInfo {
	private String codeType;
	private String code;
	private String codeName;
	private String remark;
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
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public INJ0101U01GrdDetailItemInfo(String codeType, String code,
			String codeName, String remark) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.remark = remark;
	}
}
