package nta.med.data.model.ihis.ocso;

import java.math.BigInteger;

public class OCSACT2GetPatientListINJInfo {
	private BigInteger numProtocol;
	private String reserGubun         ;
	private String bunho               ;
	private String suname              ;
	private String jundalTable        ;
	private String orderDate          ;
	private String reserDate          ;
	private String gwa                 ;
	private String gwaName            ;
	private String doctor              ;
	private String doctorName         ;
	private Double pkocs1003           ;
	private Double pkout1001           ;
	private String suname2             ;
	public OCSACT2GetPatientListINJInfo(BigInteger numProtocol, String reserGubun, String bunho, String suname,
			String jundalTable, String orderDate, String reserDate, String gwa, String gwaName, String doctor,
			String doctorName, Double pkocs1003, Double pkout1001, String suname2) {
		super();
		this.numProtocol = numProtocol;
		this.reserGubun = reserGubun;
		this.bunho = bunho;
		this.suname = suname;
		this.jundalTable = jundalTable;
		this.orderDate = orderDate;
		this.reserDate = reserDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.pkocs1003 = pkocs1003;
		this.pkout1001 = pkout1001;
		this.suname2 = suname2;
	}
	public BigInteger getNumProtocol() {
		return numProtocol;
	}
	public void setNumProtocol(BigInteger numProtocol) {
		this.numProtocol = numProtocol;
	}
	public String getReserGubun() {
		return reserGubun;
	}
	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
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
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getReserDate() {
		return reserDate;
	}
	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
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
	public Double getPkocs1003() {
		return pkocs1003;
	}
	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	
}
