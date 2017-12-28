package nta.med.data.model.ihis.system;

public class FormGwaItemInfo {
	private String doctor;
    private String doctorGwa;
    private String gwaName;
	public FormGwaItemInfo(String doctor, String doctorGwa, String gwaName) {
		super();
		this.doctor = doctor;
		this.doctorGwa = doctorGwa;
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorGwa() {
		return doctorGwa;
	}
	public void setDoctorGwa(String doctorGwa) {
		this.doctorGwa = doctorGwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
}
