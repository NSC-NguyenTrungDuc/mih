package nta.med.data.model.ihis.adma;

public class Ocs0131U01Grd0131ListItemInfo {
	private String codeType;
	private String codeTypeName;
	private String adminGubun;
	private String ment;
	private String choiceUser;
	private String userId;

	public Ocs0131U01Grd0131ListItemInfo(String codeType, String codeTypeName,
			String adminGubun, String ment, String choiceUser, String userId) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.adminGubun = adminGubun;
		this.ment = ment;
		this.choiceUser = choiceUser;
		this.userId = userId;
	}

	public String getCodeType() {
		return codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	public String getCodeTypeName() {
		return codeTypeName;
	}

	public void setCodeTypeName(String codeTypeName) {
		this.codeTypeName = codeTypeName;
	}

	public String getAdminGubun() {
		return adminGubun;
	}

	public void setAdminGubun(String adminGubun) {
		this.adminGubun = adminGubun;
	}

	public String getMent() {
		return ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

	public String getChoiceUser() {
		return choiceUser;
	}

	public void setChoiceUser(String choiceUser) {
		this.choiceUser = choiceUser;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}
