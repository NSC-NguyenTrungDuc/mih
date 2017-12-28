package nta.med.data.model.ihis.ocsa;

public class OCS0503Q00DoctorListInfo {
	private String doctor;
	private String doctorName;
	private String doctorSort;
	public OCS0503Q00DoctorListInfo(String doctor, String doctorName,
			String doctorSort) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.doctorSort = doctorSort;
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
	public String getDoctorSort() {
		return doctorSort;
	}
	public void setDoctorSort(String doctorSort) {
		this.doctorSort = doctorSort;
	}
}
