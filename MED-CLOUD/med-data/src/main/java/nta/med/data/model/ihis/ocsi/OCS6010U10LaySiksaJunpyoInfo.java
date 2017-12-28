package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10LaySiksaJunpyoInfo {

	private String bunho;
	private Double fkinp1001;
	private String suname;
	private String suname2;
	private Date birth;
	private Integer age;
	private String sex;
	private Double height;
	private Double weight;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String hoDong;
	private String hoDongName;
	private String hoCode;
	private String sikGubun;
	private String siksagubun;
	private Date drtFromDate;
	private String drtToDate;
	private String orderDate;
	private String sangName;
	private String directCode;

	public OCS6010U10LaySiksaJunpyoInfo(String bunho, Double fkinp1001, String suname, String suname2, Date birth,
			Integer age, String sex, Double height, Double weight, String gwa, String gwaName, String doctor,
			String hoDong, String hoDongName, String hoCode, String sikGubun, String siksagubun, Date drtFromDate,
			String drtToDate, String orderDate, String sangName, String directCode) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.age = age;
		this.sex = sex;
		this.height = height;
		this.weight = weight;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.hoDong = hoDong;
		this.hoDongName = hoDongName;
		this.hoCode = hoCode;
		this.sikGubun = sikGubun;
		this.siksagubun = siksagubun;
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
		this.orderDate = orderDate;
		this.sangName = sangName;
		this.directCode = directCode;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}

	public Date getBirth() {
		return birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public Double getHeight() {
		return height;
	}

	public void setHeight(Double height) {
		this.height = height;
	}

	public Double getWeight() {
		return weight;
	}

	public void setWeight(Double weight) {
		this.weight = weight;
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

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
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

	public String getSikGubun() {
		return sikGubun;
	}

	public void setSikGubun(String sikGubun) {
		this.sikGubun = sikGubun;
	}

	public String getSiksagubun() {
		return siksagubun;
	}

	public void setSiksagubun(String siksagubun) {
		this.siksagubun = siksagubun;
	}

	public Date getDrtFromDate() {
		return drtFromDate;
	}

	public void setDrtFromDate(Date drtFromDate) {
		this.drtFromDate = drtFromDate;
	}

	public String getDrtToDate() {
		return drtToDate;
	}

	public void setDrtToDate(String drtToDate) {
		this.drtToDate = drtToDate;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	public String getSangName() {
		return sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}

	public String getDirectCode() {
		return directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}

}
