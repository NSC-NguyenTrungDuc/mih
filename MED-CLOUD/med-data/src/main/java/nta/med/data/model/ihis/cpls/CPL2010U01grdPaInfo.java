package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CPL2010U01grdPaInfo {
	private String bunho ;
    private String suname ;
    private String gwaName ;
    private String gwa ;
    private String doctorName;
    private String doctor;
    private Date orderDate ;
    private String orderTime ;
    private Date jubsuDate ;
    private String jubsuTime ;
    private Date reserDate ;
    private String jubsujaName ;
    private Double groupSer ;
    private String key ;
	public CPL2010U01grdPaInfo(String bunho, String suname, String gwaName, String gwa, String doctorName,
			String doctor, Date orderDate, String orderTime, Date jubsuDate, String jubsuTime, Date reserDate,
			String jubsujaName, Double groupSer, String key) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.gwaName = gwaName;
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.doctor = doctor;
		this.orderDate = orderDate;
		this.orderTime = orderTime;
		this.jubsuDate = jubsuDate;
		this.jubsuTime = jubsuTime;
		this.reserDate = reserDate;
		this.jubsujaName = jubsujaName;
		this.groupSer = groupSer;
		this.key = key;
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
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
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
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
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
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
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
    
}
