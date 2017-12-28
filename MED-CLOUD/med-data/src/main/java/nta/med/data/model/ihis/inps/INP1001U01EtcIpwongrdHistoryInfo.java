package nta.med.data.model.ihis.inps;

public class INP1001U01EtcIpwongrdHistoryInfo {
	Double pkinp1001;
	String ipwonDate;
	String toiwonDate;
	String gwa;
	String doctor;
	String ipwonType;
	
	public INP1001U01EtcIpwongrdHistoryInfo(Double pkinp1001, String ipwonDate, String toiwonDate, String gwa,
			String doctor, String ipwonType) {
		super();
		this.pkinp1001 = pkinp1001;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.gwa = gwa;
		this.doctor = doctor;
		this.ipwonType = ipwonType;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(String toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getIpwonType() {
		return ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}

}
