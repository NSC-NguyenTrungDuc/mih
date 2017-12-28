package nta.med.data.model.ihis.ocsa;

public class OCS0208Q00LayTabGubunInfo {
	private String code ;
	private String codeName ;
	private String code3;
	public OCS0208Q00LayTabGubunInfo(String code, String codeName, String code3) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.code3 = code3;
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
	public String getCode3() {
		return code3;
	}
	public void setCode3(String code3) {
		this.code3 = code3;
	}
	

}
