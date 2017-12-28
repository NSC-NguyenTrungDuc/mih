package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2 {
	private String doctor;
	private String doctorName;
	private String ampm;

	public OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2(String doctor,
			String doctorName, String ampm) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.ampm = ampm;
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

	public String getAmpm() {
		return ampm;
	}

	public void setAmpm(String ampm) {
		this.ampm = ampm;
	}

}
