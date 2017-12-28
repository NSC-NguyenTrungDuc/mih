package nta.med.data.model.ihis.inps;

/**
 * @author vnc.tuyen
 */
public class INP1003U00fwkDoctorInfo {
    String doctor;
    String doctorName;
    String gwaName;
    
	public INP1003U00fwkDoctorInfo(String doctor, String doctorName, String gwaName) {
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
