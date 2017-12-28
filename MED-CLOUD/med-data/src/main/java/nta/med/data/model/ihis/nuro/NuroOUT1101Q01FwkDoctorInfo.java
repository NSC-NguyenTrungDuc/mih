package nta.med.data.model.ihis.nuro;

public class NuroOUT1101Q01FwkDoctorInfo {
	private String sabun;
    private String doctorName;
	public NuroOUT1101Q01FwkDoctorInfo(String sabun, String doctorName) {
		super();
		this.sabun = sabun;
		this.doctorName = doctorName;
	}
	public String getSabun() {
		return sabun;
	}
	public void setSabun(String sabun) {
		this.sabun = sabun;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	
}
