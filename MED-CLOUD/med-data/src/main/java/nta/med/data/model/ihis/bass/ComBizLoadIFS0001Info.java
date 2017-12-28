package nta.med.data.model.ihis.bass;

public class ComBizLoadIFS0001Info {
	private String codeType;
	private String codeTypeName;
	private String remark;
	private String sysDate;
	private String sysId;
	private String updDate;
	private String updId;

	public ComBizLoadIFS0001Info(String codeType, String codeTypeName,
			String remark, String sysDate, String sysId, String updDate,
			String updId) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.remark = remark;
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.updId = updId;
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

	public String getSysDate() {
		return sysDate;
	}

	public void setSysDate(String sysDate) {
		this.sysDate = sysDate;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdDate() {
		return updDate;
	}

	public void setUpdDate(String updDate) {
		this.updDate = updDate;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
