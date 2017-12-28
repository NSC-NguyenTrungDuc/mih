package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INP1003Q00grdINP1003Info {

	private String bunho;
	private String suname;
	private Date reserDate;
	private String tel2;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String reserEndType;
	private Double reserFkinp1001;
	private String sangBigo;
	private String hoDongName;
	private String age;
	private String ipwonMokjuk;
	private String ipwonRtn2;
	private String sogyeYn;
	private String hopeRoom;
	private String remark;
	private String userName;

	public INP1003Q00grdINP1003Info(String bunho, String suname, Date reserDate, String tel2, String gwa,
			String gwaName, String doctor, String doctorName, String reserEndType, Double reserFkinp1001,
			String sangBigo, String hoDongName, String age, String ipwonMokjuk, String ipwonRtn2, String sogyeYn,
			String hopeRoom, String remark, String userName) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.reserDate = reserDate;
		this.tel2 = tel2;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.reserEndType = reserEndType;
		this.reserFkinp1001 = reserFkinp1001;
		this.sangBigo = sangBigo;
		this.hoDongName = hoDongName;
		this.age = age;
		this.ipwonMokjuk = ipwonMokjuk;
		this.ipwonRtn2 = ipwonRtn2;
		this.sogyeYn = sogyeYn;
		this.hopeRoom = hopeRoom;
		this.remark = remark;
		this.userName = userName;
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

	public Date getReserDate() {
		return reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	public String getTel2() {
		return tel2;
	}

	public void setTel2(String tel2) {
		this.tel2 = tel2;
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

	public String getReserEndType() {
		return reserEndType;
	}

	public void setReserEndType(String reserEndType) {
		this.reserEndType = reserEndType;
	}

	public Double getReserFkinp1001() {
		return reserFkinp1001;
	}

	public void setReserFkinp1001(Double reserFkinp1001) {
		this.reserFkinp1001 = reserFkinp1001;
	}

	public String getSangBigo() {
		return sangBigo;
	}

	public void setSangBigo(String sangBigo) {
		this.sangBigo = sangBigo;
	}

	public String getHoDongName() {
		return hoDongName;
	}

	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getIpwonMokjuk() {
		return ipwonMokjuk;
	}

	public void setIpwonMokjuk(String ipwonMokjuk) {
		this.ipwonMokjuk = ipwonMokjuk;
	}

	public String getIpwonRtn2() {
		return ipwonRtn2;
	}

	public void setIpwonRtn2(String ipwonRtn2) {
		this.ipwonRtn2 = ipwonRtn2;
	}

	public String getSogyeYn() {
		return sogyeYn;
	}

	public void setSogyeYn(String sogyeYn) {
		this.sogyeYn = sogyeYn;
	}

	public String getHopeRoom() {
		return hopeRoom;
	}

	public void setHopeRoom(String hopeRoom) {
		this.hopeRoom = hopeRoom;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

}
