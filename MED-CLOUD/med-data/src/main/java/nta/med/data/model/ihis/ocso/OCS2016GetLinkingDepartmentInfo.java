package nta.med.data.model.ihis.ocso;

public class OCS2016GetLinkingDepartmentInfo {

	private String departmentCode;
	private String departmentName;

	public OCS2016GetLinkingDepartmentInfo(String departmentCode, String departmentName) {
		super();
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	
	
}
