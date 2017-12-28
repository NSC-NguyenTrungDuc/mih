package nta.med.data.model.ihis.nuri;

public class NUR9001U00grdPalistInfo {
	private String hoCode;
	private String bunho;
	private String suname;
	private Double pkinp1001;
	private String ageSex;
	private String ipwonDate;
	private String doctorName;
	private String cycleOrderGroup;
	
	public NUR9001U00grdPalistInfo(String hoCode, String bunho, String suname, Double pkinp1001, String ageSex,
			String ipwonDate, String doctorName, String cycleOrderGroup) {
		super();
		this.hoCode = hoCode;
		this.bunho = bunho;
		this.suname = suname;
		this.pkinp1001 = pkinp1001;
		this.ageSex = ageSex;
		this.ipwonDate = ipwonDate;
		this.doctorName = doctorName;
		this.cycleOrderGroup = cycleOrderGroup;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getAgeSex() {
		return ageSex;
	}

	public void setAgeSex(String ageSex) {
		this.ageSex = ageSex;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getCycleOrderGroup() {
		return cycleOrderGroup;
	}

	public void setCycleOrderGroup(String cycleOrderGroup) {
		this.cycleOrderGroup = cycleOrderGroup;
	}
		
}
