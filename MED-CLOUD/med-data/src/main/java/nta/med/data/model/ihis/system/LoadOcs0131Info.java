package nta.med.data.model.ihis.system;

import java.util.Date;

public class LoadOcs0131Info {
	private String codeType;
    private String codeTypeName;
    private String choiceUser;
    private String ment;
    private Date sysDate;
    private String updId;
    private Date updDate;
	public LoadOcs0131Info(String codeType, String codeTypeName,
			String choiceUser, String ment, Date sysDate, String updId,
			Date updDate) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.choiceUser = choiceUser;
		this.ment = ment;
		this.sysDate = sysDate;
		this.updId = updId;
		this.updDate = updDate;
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
	public String getChoiceUser() {
		return choiceUser;
	}
	public void setChoiceUser(String choiceUser) {
		this.choiceUser = choiceUser;
	}
	public String getMent() {
		return ment;
	}
	public void setMent(String ment) {
		this.ment = ment;
	}
	public Date getSysDate() {
		return sysDate;
	}
	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Date getUpdDate() {
		return updDate;
	}
	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}
}
