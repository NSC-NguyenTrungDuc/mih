package nta.med.data.model.ihis.invs;

public class INV0101U01GridMasterInfo {
	 private String codeType;
	 private String codeTypeName;
	 private String adminGubun;

	public INV0101U01GridMasterInfo(String codeType, String codeTypeName, String adminGubun) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.adminGubun = adminGubun;
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
	 
}
