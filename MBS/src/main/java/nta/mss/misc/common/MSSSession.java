package nta.mss.misc.common;



public class MSSSession {

	private String hospCode;
	private String locale;
	private String userName;
	private String token;
	private String fullName;


	public MSSSession() {
		super();
	}

	public MSSSession(String hospCode, String locale, String userName) {
		super();
		this.hospCode = hospCode;
		this.locale = locale;
		this.userName = userName;
	}

	public MSSSession(String hospCode, String locale, String userName, String token, String fullName) {
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


}
