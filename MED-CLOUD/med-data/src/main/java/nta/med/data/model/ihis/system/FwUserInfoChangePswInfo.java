package nta.med.data.model.ihis.system;

import java.util.Date;

public class FwUserInfoChangePswInfo {
	private Date  userEndYmd ;
	private String pswd  ;
	public FwUserInfoChangePswInfo(Date userEndYmd, String pswd) {
		super();
		this.userEndYmd = userEndYmd;
		this.pswd = pswd;
	}
	public Date getUserEndYmd() {
		return userEndYmd;
	}
	public void setUserEndYmd(Date userEndYmd) {
		this.userEndYmd = userEndYmd;
	}
	public String getPswd() {
		return pswd;
	}
	public void setPswd(String pswd) {
		this.pswd = pswd;
	}
	
}
