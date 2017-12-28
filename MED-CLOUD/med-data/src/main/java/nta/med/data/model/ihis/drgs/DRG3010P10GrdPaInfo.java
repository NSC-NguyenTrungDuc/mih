package nta.med.data.model.ihis.drgs;

import java.util.Date;

public class DRG3010P10GrdPaInfo {
    private String bunho;
    private String suname;
    private String sex;
    private String age;
    private String resident;
    private String doctorName;
    private String hoDong;
    private String hoDongName;
    private String appendYn;
    private String juninpYn;
    private String hopeDate;
    private Double pkinp1001;
    private String toiwonYn;
    private String magamBunryu;
    private String orderDate;
    private String hoCode;
    private String actBuseo;
	public DRG3010P10GrdPaInfo(String bunho, String suname, String sex, String age, String resident, String doctorName,
			String hoDong, String hoDongName, String appendYn, String juninpYn, String hopeDate, Double pkinp1001,
			String toiwonYn, String magamBunryu, String orderDate, String hoCode, String actBuseo) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.age = age;
		this.resident = resident;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoDongName = hoDongName;
		this.appendYn = appendYn;
		this.juninpYn = juninpYn;
		this.hopeDate = hopeDate;
		this.pkinp1001 = pkinp1001;
		this.toiwonYn = toiwonYn;
		this.magamBunryu = magamBunryu;
		this.orderDate = orderDate;
		this.hoCode = hoCode;
		this.actBuseo = actBuseo;
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
	public String getAge() {
		return age;
	}
	public void setAge(String age) {
		this.age = age;
	}
	public String getResident() {
		return resident;
	}
	public void setResident(String resident) {
		this.resident = resident;
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
	public String getHoDongName() {
		return hoDongName;
	}
	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}
	public String getAppendYn() {
		return appendYn;
	}
	public void setAppendYn(String appendYn) {
		this.appendYn = appendYn;
	}
	public String getJuninpYn() {
		return juninpYn;
	}
	public void setJuninpYn(String juninpYn) {
		this.juninpYn = juninpYn;
	}
	public String getHopeDate() {
		return hopeDate;
	}
	public void setHopeDate(String hopeDate) {
		this.hopeDate = hopeDate;
	}
	public Double getPkinp1001() {
		return pkinp1001;
	}
	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}
	public String getToiwonYn() {
		return toiwonYn;
	}
	public void setToiwonYn(String toiwonYn) {
		this.toiwonYn = toiwonYn;
	}
	public String getMagamBunryu() {
		return magamBunryu;
	}
	public void setMagamBunryu(String magamBunryu) {
		this.magamBunryu = magamBunryu;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getActBuseo() {
		return actBuseo;
	}
	public void setActBuseo(String actBuseo) {
		this.actBuseo = actBuseo;
	}
    
}
