package nta.med.data.model.ihis.ocso;

public class OUTSANGU00findBoxToDoctorInfo {
	private String doctor;
	private String doctorName;
	private String contKey;

	public OUTSANGU00findBoxToDoctorInfo(String doctor, String doctorName,
			String contKey) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.contKey = contKey;
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

}
