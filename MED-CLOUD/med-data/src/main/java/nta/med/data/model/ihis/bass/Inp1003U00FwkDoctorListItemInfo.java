package nta.med.data.model.ihis.bass;

public class Inp1003U00FwkDoctorListItemInfo {
	private String doctor;
	private String doctorName;
	private String gwaName;
	
	public Inp1003U00FwkDoctorListItemInfo(String doctor, String doctorName,
			String gwaName) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gwaName = gwaName;
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
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	
}
