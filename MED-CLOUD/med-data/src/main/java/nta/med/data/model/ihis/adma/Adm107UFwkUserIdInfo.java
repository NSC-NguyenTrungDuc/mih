package nta.med.data.model.ihis.adma;

public class Adm107UFwkUserIdInfo {
	private String userId ;
	private String userNm ;
	private String groupUser ;
	public Adm107UFwkUserIdInfo(String userId, String userNm, String groupUser) {
		super();
		this.userId = userId;
		this.userNm = userNm;
		this.groupUser = groupUser;
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
	public String getGroupUser() {
		return groupUser;
	}
	public void setGroupUser(String groupUser) {
		this.groupUser = groupUser;
	}
	
}
