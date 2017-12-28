package nta.med.data.model.ihis.inps;

public class INP1001Q00grdINP1001Info {
	Double pkinp1001;
	String ipwonDate;
	String toiwonDate;
	String gwa;
	String gwaName;
	String doctor;
	String doctorName;
	String hoDong1;
	String hoDongName;
	String hoCode1;
	String bedNo;
	String jaewonDays;
	String jaewonFlag;

	public INP1001Q00grdINP1001Info(Double pkinp1001, String ipwonDate, String toiwonDate, String gwa, String gwaName,
			String doctor, String doctorName, String hoDong1, String hoDongName, String hoCode1, String bedNo,
			String jaewonDays, String jaewonFlag) {
		super();
		this.pkinp1001 = pkinp1001;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hoDong1 = hoDong1;
		this.hoDongName = hoDongName;
		this.hoCode1 = hoCode1;
		this.bedNo = bedNo;
		this.jaewonDays = jaewonDays;
		this.jaewonFlag = jaewonFlag;
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

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoDongName() {
		return hoDongName;
	}

	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}

	public String getJaewonDays() {
		return jaewonDays;
	}

	public void setJaewonDays(String jaewonDays) {
		this.jaewonDays = jaewonDays;
	}

	public String getJaewonFlag() {
		return jaewonFlag;
	}

	public void setJaewonFlag(String jaewonFlag) {
		this.jaewonFlag = jaewonFlag;
	}

}
