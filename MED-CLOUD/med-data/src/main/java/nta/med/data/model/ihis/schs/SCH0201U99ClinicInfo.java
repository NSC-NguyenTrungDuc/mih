package nta.med.data.model.ihis.schs;

public class SCH0201U99ClinicInfo {
	private String yoyangName;
	private String gwaName;
	private String doctorName;
    
	public SCH0201U99ClinicInfo(String yoyangName, String gwaName, String doctorName) {
		super();
		this.yoyangName = yoyangName;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
	}

	public String getYoyangName() {
		return yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	
	
}
