package nta.med.data.model.ihis.nuri;

public class NUR1010Q00ChangeHosilSelect1Info {
	private String gwa;
	private String doctor;
	private String resident;
	private String hoCode1;
	private String hoDong1;
	private String hoCode2;
	private String hoDong2;
	private String bedNo;
	private String bedNo2;
	
	public NUR1010Q00ChangeHosilSelect1Info(String gwa, String doctor, String resident, String hoCode1, String hoDong1,
			String hoCode2, String hoDong2, String bedNo, String bedNo2) {
		super();
		this.gwa = gwa;
		this.doctor = doctor;
		this.resident = resident;
		this.hoCode1 = hoCode1;
		this.hoDong1 = hoDong1;
		this.hoCode2 = hoCode2;
		this.hoDong2 = hoDong2;
		this.bedNo = bedNo;
		this.bedNo2 = bedNo2;
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

	public String getResident() {
		return resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoCode2() {
		return hoCode2;
	}

	public void setHoCode2(String hoCode2) {
		this.hoCode2 = hoCode2;
	}

	public String getHoDong2() {
		return hoDong2;
	}

	public void setHoDong2(String hoDong2) {
		this.hoDong2 = hoDong2;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}

	public String getBedNo2() {
		return bedNo2;
	}

	public void setBedNo2(String bedNo2) {
		this.bedNo2 = bedNo2;
	}

}
