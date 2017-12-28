package nta.med.data.model.ihis.bass;

public class BAS0270FwdDoctorInfo {
	private String doctor;
	private String doctorName;
	private String doctorGwa;
	public BAS0270FwdDoctorInfo(String doctor, String doctorName,
			String doctorGwa) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.doctorGwa = doctorGwa;
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
	public String getDoctorGwa() {
		return doctorGwa;
	}
	public void setDoctorGwa(String doctorGwa) {
		this.doctorGwa = doctorGwa;
	}
}
