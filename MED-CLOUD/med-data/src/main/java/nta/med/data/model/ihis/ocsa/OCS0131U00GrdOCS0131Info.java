package nta.med.data.model.ihis.ocsa;

public class OCS0131U00GrdOCS0131Info {
	private String codeType;
	private String codeTypeName;
	private String ment;	  
	private String choiceUser;
	private String userId;
	public OCS0131U00GrdOCS0131Info(String codeType, String codeTypeName,
			String ment, String choiceUser, String userId) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
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
