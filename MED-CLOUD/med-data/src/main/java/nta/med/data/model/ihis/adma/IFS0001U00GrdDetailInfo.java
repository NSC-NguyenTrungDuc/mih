package nta.med.data.model.ihis.adma;

public class IFS0001U00GrdDetailInfo {
	private String codeType;
	private String code;
	private String codeName;
	private String remark;
	public IFS0001U00GrdDetailInfo(String codeType, String code,
			String codeName, String remark) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
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
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
}
