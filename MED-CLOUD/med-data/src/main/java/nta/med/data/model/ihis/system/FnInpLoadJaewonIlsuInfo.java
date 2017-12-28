package nta.med.data.model.ihis.system;

import java.util.Date;

public class FnInpLoadJaewonIlsuInfo {
	private String cpCode;
	private Date appDate;
	public FnInpLoadJaewonIlsuInfo(String cpCode, Date appDate) {
		super();
		this.cpCode = cpCode;
		this.appDate = appDate;
	}
	public String getCpCode() {
		return cpCode;
	}
	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}
	public Date getAppDate() {
		return appDate;
	}
	public void setAppDate(Date appDate) {
		this.appDate = appDate;
	}
}
