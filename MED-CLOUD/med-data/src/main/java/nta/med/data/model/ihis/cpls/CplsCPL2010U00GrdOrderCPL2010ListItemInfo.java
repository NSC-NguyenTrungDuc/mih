package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CplsCPL2010U00GrdOrderCPL2010ListItemInfo {
	private Date orderDate;
	private String orderTime;
	private String gwaName;
	private String inOutGubun;
	private String doctorName;
	private Date jubsuDate;
	private String jubsuTime;
	private String afterActYn;
	private String bunho;
	private String gwa;
	private String gubun;
	private String doctor;
	private Date reserDate;
	private String jubsuja;
	private String jubsujaName;
	private Double groupSer;
	private String key;
	private String ifDataSendYn;
	public CplsCPL2010U00GrdOrderCPL2010ListItemInfo(Date orderDate, String orderTime, String gwaName,
			String inOutGubun, String doctorName, Date jubsuDate, String jubsuTime, String afterActYn, String bunho,
			String gwa, String gubun, String doctor, Date reserDate, String jubsuja, String jubsujaName,
			Double groupSer, String key, String ifDataSendYn) {
		super();
		this.orderDate = orderDate;
		this.orderTime = orderTime;
		this.gwaName = gwaName;
		this.inOutGubun = inOutGubun;
		this.doctorName = doctorName;
		this.jubsuDate = jubsuDate;
		this.jubsuTime = jubsuTime;
		this.afterActYn = afterActYn;
		this.bunho = bunho;
		this.gwa = gwa;
		this.gubun = gubun;
		this.doctor = doctor;
		this.reserDate = reserDate;
		this.jubsuja = jubsuja;
		this.jubsujaName = jubsujaName;
		this.groupSer = groupSer;
		this.key = key;
		this.ifDataSendYn = ifDataSendYn;
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
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Date getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public String getAfterActYn() {
		return afterActYn;
	}
	public void setAfterActYn(String afterActYn) {
		this.afterActYn = afterActYn;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}
	public String getJubsuja() {
		return jubsuja;
	}
	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}
	public String getJubsujaName() {
		return jubsujaName;
	}
	public void setJubsujaName(String jubsujaName) {
		this.jubsujaName = jubsujaName;
	}
	public Double getGroupSer() {
		return groupSer;
	}
	public void setGroupSer(Double groupSer) {
		this.groupSer = groupSer;
	}
	public String getKey() {
		return key;
	}
	public void setKey(String key) {
		this.key = key;
	}
	public String getIfDataSendYn() {
		return ifDataSendYn;
	}
	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}
	
}