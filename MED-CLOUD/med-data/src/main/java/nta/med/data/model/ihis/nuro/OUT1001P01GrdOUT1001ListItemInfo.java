package nta.med.data.model.ihis.nuro;

public class OUT1001P01GrdOUT1001ListItemInfo {
	private Double pkout1001;
	private String bunho;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private Double jubsuNo;

	public OUT1001P01GrdOUT1001ListItemInfo(Double pkout1001, String bunho,
			String gwa, String gwaName, String doctor, String doctorName,
			Double jubsuNo) {
		super();
		this.pkout1001 = pkout1001;
		this.bunho = bunho;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.jubsuNo = jubsuNo;
	}

	public Double getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
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

	public Double getJubsuNo() {
		return jubsuNo;
	}

	public void setJubsuNo(Double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}

}
