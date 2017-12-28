package nta.med.data.model.ihis.xrts;

import java.sql.Timestamp;

public class XRT1002U00LayPrintOrderInfo {
	private String bunho;
	private String suname;
	private String hoDong;
	private String hocode;
	private Timestamp birth;
	private String sex;
	private Integer age;
	private String orderDate;
	private String gwaName;
	private String doctorName;
	private String xrayName;
	private String xrtComments;
	private String gumsaMokjuk2;
	private String pkocs;
	private String xrayGubunName;
	private Timestamp xrayReserDate;
	private String xrayReserTime;
	private String patStatusName;
	private String patStatusCodeName;
	private String cplResult;
	private String cplGumsaDate;
	private String pacsSuname2;
	private String xrayMethod;
	private String xrayGubun;
	private String orderTime;
	private String birthJapan;
	private String weight;
	private String height;
	private String xrayCode;
	private String comment;
	private String buwiCode;
	private String buwiCodeName;
	private String valtage;
	private String curElectric;
	private String time;
	private String distance;
	private String grid;
	private String note;
	private Double pkxrt0201;
	public XRT1002U00LayPrintOrderInfo(String bunho, String suname,
			String hoDong, String hocode, Timestamp birth, String sex,
			Integer age, String orderDate, String gwaName, String doctorName,
			String xrayName, String xrtComments, String gumsaMokjuk2,
			String pkocs, String xrayGubunName, Timestamp xrayReserDate,
			String xrayReserTime, String patStatusName,
			String patStatusCodeName, String cplResult, String cplGumsaDate,
			String pacsSuname2, String xrayMethod, String xrayGubun,
			String orderTime, String birthJapan, String weight, String height,
			String xrayCode, String comment, String buwiCode,
			String buwiCodeName, String valtage, String curElectric,
			String time, String distance, String grid, String note,
			Double pkxrt0201) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.hoDong = hoDong;
		this.hocode = hocode;
		this.birth = birth;
		this.sex = sex;
		this.age = age;
		this.orderDate = orderDate;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.xrayName = xrayName;
		this.xrtComments = xrtComments;
		this.gumsaMokjuk2 = gumsaMokjuk2;
		this.pkocs = pkocs;
		this.xrayGubunName = xrayGubunName;
		this.xrayReserDate = xrayReserDate;
		this.xrayReserTime = xrayReserTime;
		this.patStatusName = patStatusName;
		this.patStatusCodeName = patStatusCodeName;
		this.cplResult = cplResult;
		this.cplGumsaDate = cplGumsaDate;
		this.pacsSuname2 = pacsSuname2;
		this.xrayMethod = xrayMethod;
		this.xrayGubun = xrayGubun;
		this.orderTime = orderTime;
		this.birthJapan = birthJapan;
		this.weight = weight;
		this.height = height;
		this.xrayCode = xrayCode;
		this.comment = comment;
		this.buwiCode = buwiCode;
		this.buwiCodeName = buwiCodeName;
		this.valtage = valtage;
		this.curElectric = curElectric;
		this.time = time;
		this.distance = distance;
		this.grid = grid;
		this.note = note;
		this.pkxrt0201 = pkxrt0201;
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
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHocode() {
		return hocode;
	}
	public void setHocode(String hocode) {
		this.hocode = hocode;
	}
	public Timestamp getBirth() {
		return birth;
	}
	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
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
	public String getXrayName() {
		return xrayName;
	}
	public void setXrayName(String xrayName) {
		this.xrayName = xrayName;
	}
	public String getXrtComments() {
		return xrtComments;
	}
	public void setXrtComments(String xrtComments) {
		this.xrtComments = xrtComments;
	}
	public String getGumsaMokjuk2() {
		return gumsaMokjuk2;
	}
	public void setGumsaMokjuk2(String gumsaMokjuk2) {
		this.gumsaMokjuk2 = gumsaMokjuk2;
	}
	public String getPkocs() {
		return pkocs;
	}
	public void setPkocs(String pkocs) {
		this.pkocs = pkocs;
	}
	public String getXrayGubunName() {
		return xrayGubunName;
	}
	public void setXrayGubunName(String xrayGubunName) {
		this.xrayGubunName = xrayGubunName;
	}
	public Timestamp getXrayReserDate() {
		return xrayReserDate;
	}
	public void setXrayReserDate(Timestamp xrayReserDate) {
		this.xrayReserDate = xrayReserDate;
	}
	public String getXrayReserTime() {
		return xrayReserTime;
	}
	public void setXrayReserTime(String xrayReserTime) {
		this.xrayReserTime = xrayReserTime;
	}
	public String getPatStatusName() {
		return patStatusName;
	}
	public void setPatStatusName(String patStatusName) {
		this.patStatusName = patStatusName;
	}
	public String getPatStatusCodeName() {
		return patStatusCodeName;
	}
	public void setPatStatusCodeName(String patStatusCodeName) {
		this.patStatusCodeName = patStatusCodeName;
	}
	public String getCplResult() {
		return cplResult;
	}
	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}
	public String getCplGumsaDate() {
		return cplGumsaDate;
	}
	public void setCplGumsaDate(String cplGumsaDate) {
		this.cplGumsaDate = cplGumsaDate;
	}
	public String getPacsSuname2() {
		return pacsSuname2;
	}
	public void setPacsSuname2(String pacsSuname2) {
		this.pacsSuname2 = pacsSuname2;
	}
	public String getXrayMethod() {
		return xrayMethod;
	}
	public void setXrayMethod(String xrayMethod) {
		this.xrayMethod = xrayMethod;
	}
	public String getXrayGubun() {
		return xrayGubun;
	}
	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}
	public String getOrderTime() {
		return orderTime;
	}
	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}
	public String getBirthJapan() {
		return birthJapan;
	}
	public void setBirthJapan(String birthJapan) {
		this.birthJapan = birthJapan;
	}
	public String getWeight() {
		return weight;
	}
	public void setWeight(String weight) {
		this.weight = weight;
	}
	public String getHeight() {
		return height;
	}
	public void setHeight(String height) {
		this.height = height;
	}
	public String getXrayCode() {
		return xrayCode;
	}
	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}
	public String getBuwiCode() {
		return buwiCode;
	}
	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}
	public String getBuwiCodeName() {
		return buwiCodeName;
	}
	public void setBuwiCodeName(String buwiCodeName) {
		this.buwiCodeName = buwiCodeName;
	}
	public String getValtage() {
		return valtage;
	}
	public void setValtage(String valtage) {
		this.valtage = valtage;
	}
	public String getCurElectric() {
		return curElectric;
	}
	public void setCurElectric(String curElectric) {
		this.curElectric = curElectric;
	}
	public String getTime() {
		return time;
	}
	public void setTime(String time) {
		this.time = time;
	}
	public String getDistance() {
		return distance;
	}
	public void setDistance(String distance) {
		this.distance = distance;
	}
	public String getGrid() {
		return grid;
	}
	public void setGrid(String grid) {
		this.grid = grid;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
	}
	public Double getPkxrt0201() {
		return pkxrt0201;
	}
	public void setPkxrt0201(Double pkxrt0201) {
		this.pkxrt0201 = pkxrt0201;
	}
}
