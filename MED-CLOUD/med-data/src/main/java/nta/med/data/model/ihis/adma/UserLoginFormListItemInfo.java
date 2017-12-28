package nta.med.data.model.ihis.adma;

public class UserLoginFormListItemInfo {
	private String userId;
	private String userNm;
	private String userGroup;
	private String hospCode;
	public UserLoginFormListItemInfo(String userId, String userNm,
			String userGroup, String hospCode) {
		super();
		this.userId = userId;
		this.userNm = userNm;
		this.userGroup = userGroup;
		this.hospCode = hospCode;
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
	public String getUserGroup() {
		return userGroup;
	}
	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	
}
