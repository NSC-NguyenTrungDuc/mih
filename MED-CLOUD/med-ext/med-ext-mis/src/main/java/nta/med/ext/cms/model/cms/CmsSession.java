package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class CmsSession {

	@JsonIgnore
	private String hospCode;

	@JsonIgnore
	private String locale;

	@JsonIgnore
	private String userName;

	@JsonProperty("token")
	private String token;

	@JsonProperty("full_name")
	private String fullName;

	@JsonIgnore
	private List<DepartmentModel> listDepartment;
	
	@JsonIgnore
	private Byte timeZone;

	public CmsSession() {
		super();
	}

	public CmsSession(String hospCode, String locale, String userName) {
		super();
		this.hospCode = hospCode;
		this.locale = locale;
		this.userName = userName;
	}

	public CmsSession(String hospCode, String locale, String userName, String token, String fullName) {
		super();
		this.hospCode = hospCode;
		this.locale = locale;
		this.userName = userName;
		this.token = token;
		this.fullName = fullName;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getFullName() {
		return fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	public List<DepartmentModel> getListDepartment() {
		return listDepartment;
	}

	public void setListDepartment(List<DepartmentModel> listDepartment) {
		this.listDepartment = listDepartment;
	}

	public Byte getTimeZone() {
		return timeZone;
	}

	public void setTimeZone(Byte timeZone) {
		this.timeZone = timeZone;
	}
}
