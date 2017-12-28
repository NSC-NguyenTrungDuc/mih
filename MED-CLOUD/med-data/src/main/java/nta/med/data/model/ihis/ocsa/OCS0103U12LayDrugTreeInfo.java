package nta.med.data.model.ihis.ocsa;

public class OCS0103U12LayDrugTreeInfo {
	private String code;
	private String codeName;
	private String code1;
	private String codeName1;

	public OCS0103U12LayDrugTreeInfo(String code, String codeName,
			String code1, String codeName1) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.code1 = code1;
		this.codeName1 = codeName1;
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

	public String getCode1() {
		return code1;
	}

	public void setCode1(String code1) {
		this.code1 = code1;
	}

	public String getCodeName1() {
		return codeName1;
	}

	public void setCodeName1(String codeName1) {
		this.codeName1 = codeName1;
	}

}
