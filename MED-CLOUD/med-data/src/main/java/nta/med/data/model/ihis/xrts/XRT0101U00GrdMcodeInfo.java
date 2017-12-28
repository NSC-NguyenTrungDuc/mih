package nta.med.data.model.ihis.xrts;

public class XRT0101U00GrdMcodeInfo {
	private String codeType ;
	private String codeTypeName ;
	public XRT0101U00GrdMcodeInfo(String codeType, String codeTypeName) {
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
