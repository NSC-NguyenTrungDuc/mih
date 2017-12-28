package nta.med.data.model.ihis.adma;

import java.io.Serializable;

public class ADM103UgrdUserGrpInfo implements Serializable {
	private String userGroup;
	private String groupNm;
	public ADM103UgrdUserGrpInfo(String userGroup, String groupNm) {
		super();
		this.userGroup = userGroup;
		this.groupNm = groupNm;
	}
	public String getUserGroup() {
		return userGroup;
	}
	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}
	public String getGroupNm() {
		return groupNm;
	}
	public void setGroupNm(String groupNm) {
		this.groupNm = groupNm;
	}
	
}
