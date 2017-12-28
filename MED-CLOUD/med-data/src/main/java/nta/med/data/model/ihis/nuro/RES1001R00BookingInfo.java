package nta.med.data.model.ihis.nuro;

public class RES1001R00BookingInfo {
	private String bunhoLink;
	private String gwaName;
	private String doctorName;
	private String naewonDate;
	private String jubsuTime;
	public RES1001R00BookingInfo(String bunhoLink, String gwaName, String doctorName, String naewonDate,
			String jubsuTime) {
		super();
		this.bunhoLink = bunhoLink;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.naewonDate = naewonDate;
		this.jubsuTime = jubsuTime;
	}
	public String getBunhoLink() {
		return bunhoLink;
	}
	public void setBunhoLink(String bunhoLink) {
		this.bunhoLink = bunhoLink;
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
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}

}
