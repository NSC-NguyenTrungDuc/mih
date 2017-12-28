package nta.med.data.model.ihis.drgs;

public class DrgsDRG5100P01LayAntiDataListItemInfo {
	private String gwaName;
	private String doctorName;
	public DrgsDRG5100P01LayAntiDataListItemInfo(String gwaName,
			String doctorName) {
		super();
		this.gwaName = gwaName;
		this.doctorName = doctorName;
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
