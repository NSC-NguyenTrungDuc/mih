package nta.med.data.model.ihis.injs;

public class InjsINJ1001FormJusaBedLayPatientItemInfo {

	private String codeType;
	private String code;
	private String codeName;
	private String suname;
	private String sex;

	public InjsINJ1001FormJusaBedLayPatientItemInfo(String codeType,
			String code, String codeName, String suname, String sex) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.suname = suname;
		this.sex = sex;
	}

	public String getCodeType() {
		return codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

}
