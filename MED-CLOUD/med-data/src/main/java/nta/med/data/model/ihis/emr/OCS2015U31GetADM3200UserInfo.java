package nta.med.data.model.ihis.emr;

public class OCS2015U31GetADM3200UserInfo {
	private String userId;
	private String sysId;
	private String userGroup;
	private String userNm;

	public OCS2015U31GetADM3200UserInfo(String userId, String sysId,
			String userGroup, String userNm) {
		super();
		this.userId = userId;
		this.sysId = sysId;
		this.userGroup = userGroup;
		this.userNm = userNm;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUserGroup() {
		return userGroup;
	}

	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}

	public String getUserNm() {
		return userNm;
	}

	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}

}