package nta.med.data.model.ihis.nuri;

public class NUR1001U00LayINP1001Info {
	private String address;
	private String tel;
	private String gubunName;
	private String ipwonDate;
	private String toiwonDate;
	private String gwaName;
	private String doctorName;
	private String hoDongName;
	private String hoCode;
	private String bedNo;
	private String hoDong;
	private String gwa;
	
	public NUR1001U00LayINP1001Info(String address, String tel, String gubunName, String ipwonDate, String toiwonDate,
			String gwaName, String doctorName, String hoDongName, String hoCode, String bedNo, String hoDong,
			String gwa) {
		super();
		this.address = address;
		this.tel = tel;
		this.gubunName = gubunName;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.hoDongName = hoDongName;
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.hoDong = hoDong;
		this.gwa = gwa;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
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

	public String getHoDongName() {
		return hoDongName;
	}

	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
		
}
