package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR5020U00grdTransInfo {

	private Double pknur5023;
	private Date nurWrdt;
	private String hoDong;
	private String gubun;
	private String gubunName;
	private String bunho;
	private String suname;
	private String fromGwa;
	private String toGwa;
	private String fromHoCode;
	private String toHoCode;
	private String fromGwaName;
	private String toGwaName;
	private String age;
	private String sex;
	private String image1;
	private String image2;

	public NUR5020U00grdTransInfo(Double pknur5023, Date nurWrdt, String hoDong, String gubun, String gubunName,
			String bunho, String suname, String fromGwa, String toGwa, String fromHoCode, String toHoCode,
			String fromGwaName, String toGwaName, String age, String sex, String image1, String image2) {
		super();
		this.pknur5023 = pknur5023;
		this.nurWrdt = nurWrdt;
		this.hoDong = hoDong;
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.bunho = bunho;
		this.suname = suname;
		this.fromGwa = fromGwa;
		this.toGwa = toGwa;
		this.fromHoCode = fromHoCode;
		this.toHoCode = toHoCode;
		this.fromGwaName = fromGwaName;
		this.toGwaName = toGwaName;
		this.age = age;
		this.sex = sex;
		this.image1 = image1;
		this.image2 = image2;
	}

	public Double getPknur5023() {
		return pknur5023;
	}

	public void setPknur5023(Double pknur5023) {
		this.pknur5023 = pknur5023;
	}

	public Date getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
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

	public String getFromGwa() {
		return fromGwa;
	}

	public void setFromGwa(String fromGwa) {
		this.fromGwa = fromGwa;
	}

	public String getToGwa() {
		return toGwa;
	}

	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}

	public String getFromHoCode() {
		return fromHoCode;
	}

	public void setFromHoCode(String fromHoCode) {
		this.fromHoCode = fromHoCode;
	}

	public String getToHoCode() {
		return toHoCode;
	}

	public void setToHoCode(String toHoCode) {
		this.toHoCode = toHoCode;
	}

	public String getFromGwaName() {
		return fromGwaName;
	}

	public void setFromGwaName(String fromGwaName) {
		this.fromGwaName = fromGwaName;
	}

	public String getToGwaName() {
		return toGwaName;
	}

	public void setToGwaName(String toGwaName) {
		this.toGwaName = toGwaName;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getImage1() {
		return image1;
	}

	public void setImage1(String image1) {
		this.image1 = image1;
	}

	public String getImage2() {
		return image2;
	}

	public void setImage2(String image2) {
		this.image2 = image2;
	}

}
