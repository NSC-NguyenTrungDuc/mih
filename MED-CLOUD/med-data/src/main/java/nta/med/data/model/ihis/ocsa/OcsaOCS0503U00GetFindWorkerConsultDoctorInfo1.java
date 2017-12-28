package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1 {
	private String doctor;
	private String doctorName;
	public OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1(String doctor,
			String doctorName) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
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
	
}
