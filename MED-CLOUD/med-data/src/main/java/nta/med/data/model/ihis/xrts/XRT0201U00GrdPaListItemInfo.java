package nta.med.data.model.ihis.xrts;

import java.util.Date;

public class XRT0201U00GrdPaListItemInfo {
	private String inOutGubun;
	private Date orderDate;
	private String orderTime;
	private String bunho;
	private String suname;
	private String suname2;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String reserYn;
	private String emergency;
	private Double naewonKey;
	private String jundalTable;
	private String trialPatient;

	public XRT0201U00GrdPaListItemInfo(String inOutGubun, Date orderDate,
			String orderTime, String bunho, String suname, String suname2,
			String gwa, String gwaName, String doctor, String doctorName,
			String reserYn, String emergency, Double naewonKey,
			String jundalTable, String trialPatient) {
		super();
		this.inOutGubun = inOutGubun;
		this.orderDate = orderDate;
		this.orderTime = orderTime;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.reserYn = reserYn;
		this.emergency = emergency;
		this.naewonKey = naewonKey;
		this.jundalTable = jundalTable;
		this.trialPatient = trialPatient;
	}

	public String getInOutGubun() {
		return inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public String getOrderTime() {
		return orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
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

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
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

	public String getReserYn() {
		return reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public Double getNaewonKey() {
		return naewonKey;
	}

	public void setNaewonKey(Double naewonKey) {
		this.naewonKey = naewonKey;
	}

	public String getJundalTable() {
		return jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}

	public String getTrialPatient() {
		return trialPatient;
	}

	public void setTrialPatient(String trialPatient) {
		this.trialPatient = trialPatient;
	}

}