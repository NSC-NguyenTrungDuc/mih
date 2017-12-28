package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0204U00MembListInfo {
	private String userId;
	private String userNm;
	public OcsaOCS0204U00MembListInfo(String userId, String userNm) {
		super();
		this.userId = userId;
		this.userNm = userNm;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getUserNm() {
		return userNm;
	}
	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}
	
}
