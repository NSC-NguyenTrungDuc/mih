package nta.med.data.model.ihis.adma;

public class CheckAdminUserInfo {
	private String userScrt;
	private String userGroup;
	private String userYn;
	private Integer clisSmoId;
	//TODO remove 2 line below
	private String hospCode;
	private String language;
	public CheckAdminUserInfo(String userScrt, String userGroup, String userYn,
							  Integer clisSmoId, String hospCode, String language) {
		super();
		this.userScrt = userScrt;
		this.userGroup = userGroup;
		this.userYn = userYn;
		this.clisSmoId = clisSmoId;
		this.hospCode = hospCode;
		this.language = language;
	}
	public String getUserScrt() {
		return userScrt;
	}
	public void setUserScrt(String userScrt) {
		this.userScrt = userScrt;
	}
	public String getUserGroup() {
		return userGroup;
	}
	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}
	public String getUserYn() {
		return userYn;
	}
	public void setUserYn(String userYn) {
		this.userYn = userYn;
	}
	public Integer getClisSmoId() {
		return clisSmoId;
	}
	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
}
