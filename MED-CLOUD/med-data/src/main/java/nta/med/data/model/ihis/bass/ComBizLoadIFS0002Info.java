package nta.med.data.model.ihis.bass;

import java.util.Date;

public class ComBizLoadIFS0002Info {
	private String codeType;
	private String code;
	private String codeName;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	public ComBizLoadIFS0002Info(String codeType, String code, String codeName,
			String remark, Date sysDate, String sysId, Date updDate,
			String updId) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
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
	public Date getSysDate() {
		return sysDate;
	}
	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public Date getUpdDate() {
		return updDate;
	}
	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}

	
}