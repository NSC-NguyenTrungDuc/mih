package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CPL3010U01LaySpecimenInfo {
	private String bunho               ;
	private String suname              ;
	private String sex                 ;
	private Date birth               ;
	private String gwa                 ;
	private String doctorName         ;
	private String hoDong             ;
	private String hoCode             ;
	private Date orderDate          ;
	private String jubsuDate          ;
	private Date partJubsuDate     ;
	private String jubsuTime          ;
	private String partJubsuTime     ;
	private String jubsuja             ;
	private String inOutGubun        ;
	private String jundalGubun        ;
	private String specimenCode       ;
	private String specimenName       ;
	private String tat1                ;
	private String tat2                ;
	private Integer age                 ;
	public CPL3010U01LaySpecimenInfo(String bunho, String suname, String sex,
			Date birth, String gwa, String doctorName, String hoDong,
			String hoCode, Date orderDate, String jubsuDate,
			Date partJubsuDate, String jubsuTime, String partJubsuTime,
			String jubsuja, String inOutGubun, String jundalGubun,
			String specimenCode, String specimenName, String tat1, String tat2,
			Integer age) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.birth = birth;
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.orderDate = orderDate;
		this.jubsuDate = jubsuDate;
		this.partJubsuDate = partJubsuDate;
		this.jubsuTime = jubsuTime;
		this.partJubsuTime = partJubsuTime;
		this.jubsuja = jubsuja;
		this.inOutGubun = inOutGubun;
		this.jundalGubun = jundalGubun;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.tat1 = tat1;
		this.tat2 = tat2;
		this.age = age;
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
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public String getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public Date getPartJubsuDate() {
		return partJubsuDate;
	}
	public void setPartJubsuDate(Date partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public String getPartJubsuTime() {
		return partJubsuTime;
	}
	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}
	public String getJubsuja() {
		return jubsuja;
	}
	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getJundalGubun() {
		return jundalGubun;
	}
	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}
	public String getSpecimenCode() {
		return specimenCode;
	}
	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getTat1() {
		return tat1;
	}
	public void setTat1(String tat1) {
		this.tat1 = tat1;
	}
	public String getTat2() {
		return tat2;
	}
	public void setTat2(String tat2) {
		this.tat2 = tat2;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	
}
