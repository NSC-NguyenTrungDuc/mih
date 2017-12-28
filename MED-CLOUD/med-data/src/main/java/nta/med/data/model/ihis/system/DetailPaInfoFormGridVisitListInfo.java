package nta.med.data.model.ihis.system;

import java.sql.Timestamp;

public class DetailPaInfoFormGridVisitListInfo {
	private Timestamp comingDate;
    private String departmentName;
    private String typeName;
    private String doctorName;
    private Timestamp outDate;
	public DetailPaInfoFormGridVisitListInfo(Timestamp comingDate,
			String departmentName, String typeName, String doctorName,
			Timestamp outDate) {
		super();
		this.comingDate = comingDate;
		this.departmentName = departmentName;
		this.typeName = typeName;
		this.doctorName = doctorName;
		this.outDate = outDate;
	}
	public Timestamp getComingDate() {
		return comingDate;
	}
	public void setComingDate(Timestamp comingDate) {
		this.comingDate = comingDate;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	public String getTypeName() {
		return typeName;
	}
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Timestamp getOutDate() {
		return outDate;
	}
	public void setOutDate(Timestamp outDate) {
		this.outDate = outDate;
	}
    
}
