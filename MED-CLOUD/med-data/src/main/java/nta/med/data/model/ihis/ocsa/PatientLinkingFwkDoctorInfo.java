package nta.med.data.model.ihis.ocsa;

public class PatientLinkingFwkDoctorInfo {

	private String doctorCode;
	private String doctorName;

	public PatientLinkingFwkDoctorInfo(String doctorCode, String doctorName) {
		super();
		this.doctorCode = doctorCode;
		this.doctorName = doctorName;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

}
