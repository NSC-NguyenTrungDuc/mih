package nta.med.data.model.ihis.ocsa;

public class OCSAOCS0270Q00GridBAS0270RowInfo {
	private String doctor;
    private String doctorName;
    private String contKey;
    private String departmentName ;
	public OCSAOCS0270Q00GridBAS0270RowInfo(String doctor, String doctorName, String contKey, String departmentName) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.contKey = contKey;
		this.departmentName = departmentName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	
}
