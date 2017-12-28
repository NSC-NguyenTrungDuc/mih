package nta.med.data.model.ihis.emr;

public class EmailToInfo {
	private String email;
	private String userName;
	private String userId;
	
	public EmailToInfo(String email, String userName, String userId) {
		super();
		this.email = email;
		this.userName = userName;
		this.userId = userId;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	
}
