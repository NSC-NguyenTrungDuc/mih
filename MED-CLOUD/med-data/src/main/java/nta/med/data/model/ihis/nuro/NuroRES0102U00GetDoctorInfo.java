package nta.med.data.model.ihis.nuro;

public class NuroRES0102U00GetDoctorInfo {
	private String doctor;

	public NuroRES0102U00GetDoctorInfo(String doctor) {
		super();
		this.doctor = doctor;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	
}
