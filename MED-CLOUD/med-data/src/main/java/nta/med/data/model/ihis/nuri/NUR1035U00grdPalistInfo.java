package nta.med.data.model.ihis.nuri;

public class NUR1035U00grdPalistInfo {
	private String hoCode;
	private String bunho;
	private String suName;
	private Double pkinp1001;
	private String ageSex;
	private String ipwonDate;
	private String doctorName;
	private String cycleOrderGroup;
	private String checkYn;
	
	public NUR1035U00grdPalistInfo(String hoCode, String bunho, String suName, Double pkinp1001, String ageSex,
			String ipwonDate, String doctorName, String cycleOrderGroup, String checkYn) {
		super();
		this.hoCode = hoCode;
		this.bunho = bunho;
		this.suName = suName;
		this.pkinp1001 = pkinp1001;
		this.ageSex = ageSex;
		this.ipwonDate = ipwonDate;
		this.doctorName = doctorName;
		this.cycleOrderGroup = cycleOrderGroup;
		this.checkYn = checkYn;
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

	public String getSuName() {
		return suName;
	}

	public void setSuName(String suName) {
		this.suName = suName;
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

	public String getCheckYn() {
		return checkYn;
	}

	public void setCheckYn(String checkYn) {
		this.checkYn = checkYn;
	}
	
}
