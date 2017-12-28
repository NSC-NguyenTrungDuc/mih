package nta.med.data.model.ihis.cpls;

public class CPL0108U00InitGrdMasterListItemInfo {
	private String codeType;
	private String codeTypeName;

	public CPL0108U00InitGrdMasterListItemInfo(String codeType,
			String codeTypeName) {
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
