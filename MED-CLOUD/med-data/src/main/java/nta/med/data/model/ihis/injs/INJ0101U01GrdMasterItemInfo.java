package nta.med.data.model.ihis.injs;

public class INJ0101U01GrdMasterItemInfo {
	private String codeType ;
	private String codeTypeName ;
	private String adminGubun ;
	private String remark ;
	public INJ0101U01GrdMasterItemInfo(String codeType, String codeTypeName,
			String adminGubun, String remark) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.adminGubun = adminGubun;
		this.remark = remark;
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
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	      
	

}
