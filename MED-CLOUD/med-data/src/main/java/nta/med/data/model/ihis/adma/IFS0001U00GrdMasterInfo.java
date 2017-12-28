package nta.med.data.model.ihis.adma;

public class IFS0001U00GrdMasterInfo {
	private String codeType;
	private String codeTypeName;
	private String remark;
	public IFS0001U00GrdMasterInfo(String codeType, String codeTypeName,
			String remark) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.remark = remark;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
	public String getCodeTypeName() {
		return codeTypeName;
	}
	public void setCodeTypeName(String codeTypeName) {
		this.codeTypeName = codeTypeName;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
}
