package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8050U00grdNur8050HisInfo {

	private String bunho;
	private String suname;
	private String fkinp1001;
	private String gubun;
	private String detail;
	private Date writeDate;
	private String writeUser;
	private String writeUserName;
	private String confirmUser;
	private String confirmUserName;

	public NUR8050U00grdNur8050HisInfo(String bunho, String suname, String fkinp1001, String gubun, String detail,
			Date writeDate, String writeUser, String writeUserName, String confirmUser, String confirmUserName) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.fkinp1001 = fkinp1001;
		this.gubun = gubun;
		this.detail = detail;
		this.writeDate = writeDate;
		this.writeUser = writeUser;
		this.writeUserName = writeUserName;
		this.confirmUser = confirmUser;
		this.confirmUserName = confirmUserName;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(String fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getDetail() {
		return detail;
	}

	public void setDetail(String detail) {
		this.detail = detail;
	}

	public Date getWriteDate() {
		return writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

	public String getWriteUser() {
		return writeUser;
	}

	public void setWriteUser(String writeUser) {
		this.writeUser = writeUser;
	}

	public String getWriteUserName() {
		return writeUserName;
	}

	public void setWriteUserName(String writeUserName) {
		this.writeUserName = writeUserName;
	}

	public String getConfirmUser() {
		return confirmUser;
	}

	public void setConfirmUser(String confirmUser) {
		this.confirmUser = confirmUser;
	}

	public String getConfirmUserName() {
		return confirmUserName;
	}

	public void setConfirmUserName(String confirmUserName) {
		this.confirmUserName = confirmUserName;
	}

}
