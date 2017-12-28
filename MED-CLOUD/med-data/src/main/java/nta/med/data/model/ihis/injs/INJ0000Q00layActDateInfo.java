package nta.med.data.model.ihis.injs;

import java.util.Date;

public class INJ0000Q00layActDateInfo {
	private String jundalTable ;
	private String jundalPart ;
	private String bunho ;
	private Date orderDate ;
	private String inOutGubun ;
	private String gwa ;
	private String doctor ;
	private String doctorName ;
	private Date reserDate ;
	private String comments ;
	private Date jubsuDate ;
	private Date actDate ;
	private Double pkinj1001 ;
	private String hangmogName ;
	public INJ0000Q00layActDateInfo(String jundalTable, String jundalPart, String bunho, Date orderDate,
			String inOutGubun, String gwa, String doctor, String doctorName, Date reserDate, String comments,
			Date jubsuDate, Date actDate, Double pkinj1001, String hangmogName) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.inOutGubun = inOutGubun;
		this.gwa = gwa;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.reserDate = reserDate;
		this.comments = comments;
		this.jubsuDate = jubsuDate;
		this.actDate = actDate;
		this.pkinj1001 = pkinj1001;
		this.hangmogName = hangmogName;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
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
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public Date getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public Date getActDate() {
		return actDate;
	}
	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}
	public Double getPkinj1001() {
		return pkinj1001;
	}
	public void setPkinj1001(Double pkinj1001) {
		this.pkinj1001 = pkinj1001;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	
}
