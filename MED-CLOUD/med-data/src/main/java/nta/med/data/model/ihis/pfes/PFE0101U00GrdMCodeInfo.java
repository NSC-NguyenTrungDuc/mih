package nta.med.data.model.ihis.pfes;

public class PFE0101U00GrdMCodeInfo {
	private String codeType ;
	private String codeTypeName ;
	public PFE0101U00GrdMCodeInfo(String codeType, String codeTypeName) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
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
}
