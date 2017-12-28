package nta.med.data.model.ihis.invs;

public class INV6002U00GrdINV6002LoadcbxActorInfo {
	private String userId;
	private String userNm;
	
	public INV6002U00GrdINV6002LoadcbxActorInfo(String userId, String userNm) {
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
